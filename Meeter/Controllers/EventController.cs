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
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public EventController(
            UserManager<User> usm,
            SignInManager<User> sim, NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;
            normalDataContext = normalD;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
                return await IndexAdmin();
            else
                return await IndexUser();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            List<Event> events = await normalDataContext.Events
                .Include(x => x.Group)
                .ThenInclude(x => x.Memberships)
                .ToListAsync();
            return View("Index", events);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> IndexUser()
        {
            var id = userManager.GetUserId(User);
            List<Event> events = await normalDataContext.Events
                .Include(x => x.Group)
                .ThenInclude(x => x.Memberships)
                .Where(x => x.Group.Memberships.Where(m => m.UserId == id).Any())
                .ToListAsync();
            return View("Index", events);
        }

        public async Task<IActionResult> GetEventInfo(int? id)
        {
            Event model = await normalDataContext.Events
                .Include(x => x.Group)
                .Include(x => x.Group.Memberships)
                .Include(x => x.Group.Creator)
                .Include(x => x.Place)
                .Include(x => x.Preferences)
                .FirstOrDefaultAsync(x => x.Id == id);

            foreach (var membership in model.Group.Memberships)
            {
                if (membership.User is null)
                    membership.User = await normalDataContext.Users.FindAsync(membership.UserId);

                if (!(membership.User is null) && membership.User.Location is null)
                    membership.User.Location = await normalDataContext.Locations.FindAsync(membership.User.LocationId);
            }

            ViewData["locationlat"] = 52.2;
            ViewData["locationlng"] = 21.0;

            return View(model);
        }
        
        public async Task<ActionResult> Create(int? id)
        {
            var model = new Event
            {
                Group = await normalDataContext.Groups.FirstOrDefaultAsync(x => x.Id == id),
                DateTime = DateTime.Now
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

            return RedirectToAction("GetGroupInfo", "Group", new { groupid = model.GroupId });
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            Event model = await normalDataContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            int groupi = model.GroupId;
            normalDataContext.Events.Remove(normalDataContext.Events.Find(id));
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetGroupInfo", "Group",new { groupid = groupi });
        }
    }
}