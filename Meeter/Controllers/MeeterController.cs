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

namespace Meeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeeterController : ControllerBase
    {
        private readonly MeeterDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public MeeterController(
            UserManager<IdentityUser> usm,
            SignInManager<IdentityUser> sim,
            MeeterDbContext ctx)
        {
            userManager = usm;
            signInManager = sim;
            context = ctx;
        }

        /*
        private readonly IAuthorizationService authorizationService;
        private readonly MeeterDbContext context;

        public MeeterController(IAuthorizationService authService, MeeterDbContext ctx)
        {
            authorizationService = authService;
            context = ctx;
        } */

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

        [HttpGet("index")]
        public ActionResult<string> Index()
        {
            return "Home page";
        }

        [HttpGet("secret")]
        [Authorize]
        public ActionResult<string> Secret()
        {
            return "Secret page";
        }

        [HttpGet("login")]
        public ActionResult<string> Login()
        {
            return Redirect("/login.html");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromForm] string username, [FromForm] string password)
        {
            // login functionality
            var user = await userManager.FindByNameAsync(username);

            if(user != null)
            {
                // sign in
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);
                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet("register")]
        public ActionResult<string> Register()
        {
            return Redirect("/register.html");
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromForm] string username, [FromForm] string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = ""
            };

            var result = await userManager.CreateAsync(user, password);
            if(result.Succeeded)
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

        [HttpGet("logout")]
        public async Task<ActionResult<string>> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }





        // GET api/meeter/users
        [HttpGet("users")]
        public IEnumerable<IdentityUser> GetUsers()
        {
            return context.Users.AsEnumerable();
        }

        // GET api/meeter/events
        [HttpGet("events")]
        public IEnumerable<Event> GetEvents()
        {
            return context.Events.OrderBy(e => e.DateTime).AsEnumerable();
        }

        // POST api/meeter/events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (@event.GroupId == 0)
                return BadRequest(ModelState);

            context.Events.Add(@event);

            await context.SaveChangesAsync();

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
