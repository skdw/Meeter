using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meeter.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Meeter.Controllers
{
    [Route("api/[controller]/[action]")]
    // [ApiController]
    public class MeeterController : Controller
    {
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public MeeterController(
            UserManager<User> usm,
            SignInManager<User> sim, NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;
            normalDataContext = normalD;
        }

        /*
       public async Task<ActionResult<string>> OnGetAsync(int documentId)
       {
           Event @event = context.Events.Find(documentId);

           if (@event == null)
           {
               return new NotFoundResult();
           }

           var authorizationResult = await authorizationService
                   .AuthorizeAsync(User, @event, Operations.Read);

           if (authorizationResult.Succeeded)
           {
               return "Success!";
           }
           else if (User.Identity.IsAuthenticated)
           {
               return new ForbidResult();
           }
           else
           {
               return new ChallengeResult();
           }
       }
   */

        [HttpGet]
        public async Task<ActionResult<string>> Index()
        {
            var signed = signInManager.IsSignedIn(User);
            var id = userManager.GetUserId(User);
            var name = userManager.GetUserName(User);
            if (signed)
                return await Secret();
            else
                return Redirect("/splashscreen.html");
            //return "Home page - username: " + name + "  id: " + id + "  signed " + signed;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Secret()
        {
            var id = userManager.GetUserId(User);
            var Us = await userManager.GetUserAsync(User);
            Us.CreatedGroups = await normalDataContext.Groups.Include(x => x.Creator).Where(x => x.Creatorid == Us.Id).ToArrayAsync();
            foreach(var gr in Us.CreatedGroups)
            {
                gr.Events = await normalDataContext.Events.Include(x => x.Group).Where(x => x.GroupId == gr.Id).ToArrayAsync();

            }
            if(Us.LocationId!=null)
            {
                Us.Location =await normalDataContext.Locations.FirstOrDefaultAsync(x => x.Id == Us.LocationId);

                ViewData["locationlat"] = Us.Location.Lat;
                ViewData["locationlng"] = Us.Location.Lng;
            }
            // return "Secret page";

            //model.JavascriptToRun = "ShowErrorPopup()";

            return View("Secret",Us);
        }

        [HttpGet]
        public ActionResult Location()
        {
            return Redirect("/location.html");
        }

        [HttpPost]
        public async Task<ActionResult<Task>> Location([FromHeader] float lat, [FromHeader] float lng)
        {
            var signed = signInManager.IsSignedIn(User);
            if(signed)
            {
                var user = await userManager.GetUserAsync(User);

                Location location = new Location()
                {
                    Lat = lat,
                    Lng = lng
                    
                };
                if(user.LocationId!=null)
                    normalDataContext.Locations.Remove(normalDataContext.Locations.Find(user.LocationId));
                await normalDataContext.Locations.AddAsync(location);
                await normalDataContext.SaveChangesAsync();
                user.LocationId = location.Id;

                user.Location = location;
              //  ViewData["locationlat"] = location.Lat;
                //ViewData["locationlng"] = location.Lng;
                await userManager.UpdateAsync(user);
                await normalDataContext.SaveChangesAsync();
                return View("Secret", user);
            }
            return Redirect("/splashscreen.html");
        }

        //[HttpGet("secretpolicy")]
        //[Authorize(Policy = "Claim.DoB")]
        //public ActionResult<string> SecretPolicy()
        //{
        //    return "Secret policy page";
        //}

        [HttpGet]
        public ActionResult<string> Login()
        {
            return Redirect("/login.html");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromForm] string username, [FromForm] string password)
        {
            // login functionality
            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                // sign in
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return Unauthorized();
        }

        [HttpGet]
        public ActionResult<string> Register()
        {
            return Redirect("/register.html");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromForm] string username, [FromForm] string password, [FromForm] string email, [FromForm] string fname, [FromForm] string lname)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                FirstName = fname,
                LastName = lname
            };

            // var result = await userManager.CreateAsync(user, password);
            var result = await userManager.CreateAsync(user, password);

            //await normalDataContext.Users.AddAsync(user);
            await normalDataContext.SaveChangesAsync();

            if (result.Succeeded)
            {
                // sign in
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult<string>> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        //[HttpGet("users")]
        //public IEnumerable<IdentityUser> GetUsers()
        //{
        //    return context.Users.AsEnumerable();
        //}

        //[HttpGet("groups")]
        //public IEnumerable<Group> GetGroups()
        //{
        //    return normalDataContext.Groups.AsEnumerable();
        //}

        //[HttpPost("groups")]
        //public async Task<IActionResult> PostGroup([FromForm] string groupName, [FromForm] string[] user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var selectedUsersTasks = user.Select(async user_id => await context.Users.FindAsync(user_id) as User);
        //    var selectedUsers = await Task.WhenAll(selectedUsersTasks);

        //    var groupMembers = selectedUsers.Select(u => new GroupMember { User = u }).ToArray();

        //    var creator = await userManager.GetUserAsync(User) as User;

        //    Group group = new Group()
        //    {
        //        Name = groupName,
        //      //  Creator = creator
        //    };

        //    //foreach (var member in group.Memberships)
        //    //    member.Group = group;

        //    normalDataContext.Groups.Add(group);

        //    await context.SaveChangesAsync();

        //    return CreatedAtAction("GetGroups", new { id = group.Id }, group);
        //}


        // GET api/meeter/events
        [HttpGet("events")]
        public IEnumerable<Event> GetEvents()
        {
            return normalDataContext.Events.OrderBy(e => e.DateTime).AsEnumerable();
        }

        // POST api/meeter/events
        [HttpPost("events")]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (@event.GroupId == 0)
                return BadRequest(ModelState);

            normalDataContext.Events.Add(@event);

            await normalDataContext.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = @event.Id }, @event);
        }



        // GET api/meeter
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/meeter/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/meeter
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/meeter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/meeter/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
