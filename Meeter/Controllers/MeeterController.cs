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
                return View();
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
            if(us.LocationId != null && us.Location is null)
            {
                us.Location = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == us.LocationId);

                ViewData["locationaddress"] = us.Location.Address;
                ViewData["locationlat"] = us.Location.Lat;
                ViewData["locationlng"] = us.Location.Lng;
            }
            return View("Secret",us);
        }

        [HttpGet]
        public async Task<ActionResult> SetLocation()
        {
            var us = await userManager.GetUserAsync(User);
            var loc = us.Location;
            if(loc is null)
                loc = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == us.LocationId);
            if (loc is null)
                loc = new Location() { Lat=52.232222f, Lng=21.008333f };
            return View(loc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetLocation([FromForm]Location location)
        {
            var us = await userManager.GetUserAsync(User);
            var loc = us.Location;
            if (loc is null)
                loc = await normalDataContext.Locations.FirstOrDefaultAsync(l => l.Id == us.LocationId);
            if (loc is null) // lokalizacja była nieustawiona
            {
                var res = await normalDataContext.Locations.AddAsync(location);
                loc = location;
            }
            else
            {
                loc.Lat = location.Lat;
                loc.Lng = location.Lng;
                loc.Address = location.Address;
            }

            us.LocationId = loc.Id;
            us.Location = loc;

            await userManager.UpdateAsync(us);
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
        public async Task<ActionResult<string>> Register([FromForm] string username, [FromForm] string password, [FromForm] string email, [FromForm] string phonenumber, [FromForm] string fname, [FromForm] string lname)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                PhoneNumber = phonenumber,
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
