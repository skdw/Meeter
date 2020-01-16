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
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Meeter.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MeeterController : Controller
    {
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration _config;

        public string GoogleUri => "https://maps.googleapis.com/maps/api/js?key=" + _config.GetValue<string>("GoogleKey");

        public MeeterController(
            UserManager<User> usm,
            SignInManager<User> sim, NormalDataContext normalD, IConfiguration config)
        {
            userManager = usm;
            signInManager = sim;
            normalDataContext = normalD;
            _config = config;
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
            if (signed)
                return await Secret();
            else
            {
                ViewData["GoogleUri"] = GoogleUri;
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Secret()
        {
            var id = userManager.GetUserId(User);
            var us = await userManager.GetUserAsync(User);
            us.CreatedGroups = await normalDataContext.Groups.Include(x => x.Creator).Where(x => x.Creatorid == us.Id).ToArrayAsync();
            foreach(var gr in us.CreatedGroups)
            {
                gr.Events = await normalDataContext.Events.Include(x => x.Group).Where(x => x.GroupId == gr.Id).ToArrayAsync();

            }
            if(us.LocationId != null)
            {
                us.Location = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == us.LocationId);

                ViewData["locationlat"] = us.Location.Lat;
                ViewData["locationlng"] = us.Location.Lng;
                ViewData["GoogleUri"] = GoogleUri;
            }
            // return "Secret page";

            //model.JavascriptToRun = "ShowErrorPopup()";

            return View("Secret",us);
        }

        [HttpGet]
        public async Task<ActionResult> SetLocation()
        {
            var id = userManager.GetUserId(User);
            var loc = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
            ViewData["GoogleUri"] = GoogleUri;
            return View(loc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetLocation([FromForm]Location location)
        {
            var us = await userManager.GetUserAsync(User);
            var loc = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == location.Id);

            if(loc is null)
            {
                location.Id = us.Id;
                var res = await normalDataContext.Locations.AddAsync(location);
            }
            else
            {
                loc.Lat = location.Lat;
                loc.Lng = location.Lng;
            }

            us.LocationId = location.Id;

            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("Secret");
        }

        //[HttpGet("secretpolicy")]
        //[Authorize(Policy = "Claim.DoB")]
        //public ActionResult<string> SecretPolicy()
        //{
        //    return "Secret policy page";
        //}

        [HttpGet]
        public ActionResult<string> Login() => View();

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
                    return RedirectToAction("Index");
            }
            return Unauthorized();
        }

        [HttpGet]
        public ActionResult<string> Register() => View();

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

            var result = await userManager.CreateAsync(user, password);
            await normalDataContext.SaveChangesAsync();

            if (result.Succeeded)
            {
                // sign in
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult<string>> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public ActionResult AccesDenied()
        {
            return View();
        }

        //[HttpGet("users")]
        //public IEnumerable<IdentityUser> GetUsers()
        //{
        //    return context.Users.AsEnumerable();
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
    }
}
