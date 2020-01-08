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
    public class EventController : Controller
    {

        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public EventController(
            UserManager<IdentityUser> usm,
            SignInManager<IdentityUser> sim, NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;
            normalDataContext = normalD;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Event> searchResult = await normalDataContext.Events.ToListAsync(); //Include(x => x.Company).Where(o => o.JobTitle.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }
        public async Task<IActionResult> GetEventInfo(int? id)
        {
            Event model = await normalDataContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            return View(model);

        }
        
        public async Task<ActionResult> Create(int? id)
        {
            var model = new Event
            {
                Group = await normalDataContext.Groups.FirstOrDefaultAsync(x => x.Id == id)

            };
            model.GroupId = model.Group.Id;


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event model)
        {
            model.Group = await normalDataContext.Groups.FirstOrDefaultAsync(x => x.Id == model.GroupId);
            model.Preferences = new List<UserPreference>();
            // model.Place = await normalDataContext.Places.FirstOrDefaultAsync(x => x.PlaceId == model.PlaceId.ToString());

            await normalDataContext.Events.AddAsync(model);
            await normalDataContext.SaveChangesAsync();

            return RedirectToAction("GetGroupInfo", "Group", new { groupid = model.Id });


        }
    }
}