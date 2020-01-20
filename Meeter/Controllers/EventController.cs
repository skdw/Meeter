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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<ActionResult> AddPreferences(int? id)
        {
            List<UserPreference> model = new List<UserPreference>();
            Event e = await normalDataContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            List<GroupMember> groupMembers = normalDataContext.GroupMembers.Include(x => x.Group).Where(x => x.GroupId == e.GroupId).ToList();

            ViewData["list_pref"] = normalDataContext.PlaceTypes.ToList();
            foreach (var user in groupMembers)
            {
                user.User = await normalDataContext.Users.FirstOrDefaultAsync(x => x.Id == user.UserId);
                UserPreference up = new UserPreference
                {
                    User = user.User,
                    Event = e,
                    EventId = e.Id,
                    UserId = user.UserId


                };
                model.Add(up);
                // await normalDataContext.UserPreferences.AddAsync(up);

            }
            ViewBag.Preferences = new SelectList(normalDataContext.Types, "Id", "Name");
            //normalDataContext.SaveChanges();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddPreferences([FromForm] IEnumerable<UserPreference> preferences)
        {
            foreach (var item in preferences)
            {
                item.TypeId = item.Type.Id;
                List<UserPreference> upref = normalDataContext.UserPreferences.Include(x => x.User).Where(x => x.UserId == item.UserId).ToList();
                if (upref.Count == 0)
                {
                    normalDataContext.UserPreferences.Add(item);
                }
                else
                {
                    upref[0].Type = item.Type;
                    upref[0].TypeId = item.TypeId;
                }
            }
            normalDataContext.SaveChanges();

            return RedirectToAction("GetEventInfo", "Event", new { id = preferences.First().EventId });
        }


        public async Task<IActionResult> AddPreference([FromQuery] int memberId, [FromQuery] int eventId)
        {
            var member = await normalDataContext.GroupMembers.Where(x => x.Id == memberId).Include(x => x.User).FirstOrDefaultAsync();
            var @event = await normalDataContext.Events.Where(x => x.Id == eventId).FirstOrDefaultAsync();

            var model = await normalDataContext.UserPreferences.Where(x => x.UserId == member.UserId && x.EventId == @event.Id).FirstOrDefaultAsync();
            if (model is null)
                model = new UserPreference()
                {
                    UserId = member.UserId,
                    User = member.User,
                    EventId = @event.Id,
                    Event = @event
                };

            ViewBag.TypeId = new SelectList(normalDataContext.Types, "Id", "Name");
            ViewBag.UserId = new SelectList(normalDataContext.Users, "Id", "FullName");
            ViewBag.EventId = new SelectList(normalDataContext.Events, "Id", "EventName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPreference([FromForm] UserPreference userPreference)
        {
            var uspref = await normalDataContext.UserPreferences.Where(x => x.EventId == userPreference.EventId && x.UserId == userPreference.UserId).FirstOrDefaultAsync();
            var type = await normalDataContext.Types.Where(x => x.Id == userPreference.TypeId).FirstOrDefaultAsync();
            if (uspref is null)
            {
                var @event = await normalDataContext.Events.Where(x => x.Id == userPreference.EventId).FirstOrDefaultAsync();
                var user = await normalDataContext.Users.Where(x => x.Id == userPreference.UserId).FirstOrDefaultAsync();

                uspref = new UserPreference()
                {
                    EventId = userPreference.EventId,
                    Event = userPreference.Event,
                    UserId = userPreference.UserId,
                    User = userPreference.User
                };

                normalDataContext.UserPreferences.Add(uspref);
            }
            uspref.TypeId = userPreference.TypeId;
            uspref.Type = type;

            normalDataContext.SaveChanges();

            return RedirectToAction("GetEventInfo", "Event", new { id = userPreference.EventId });
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
            return RedirectToAction("GetGroupInfo", "Group", new { groupid = groupi });
        }
        [HttpGet]
        public JsonResult CurrentPreferenceAutocomplete([FromQuery]string term = "") // v - inserted text
        {
            var objMemberlist = normalDataContext.UserPreferences
                            .Where(u => u.Type.Name.ToUpper()
                            .Contains(term.ToUpper()))
                            .Select(u => new { id = u.Id, type = u.Type })
                            .Distinct().ToList();
            return Json(objMemberlist);
        }
    }

}