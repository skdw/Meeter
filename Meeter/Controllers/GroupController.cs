using Meeter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Meeter.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GroupController : Controller
    {
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public GroupController(
            UserManager<User> usm,
            SignInManager<User> sim,
            NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;

            normalDataContext = normalD;
        }
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Index()
        {
            List<Group> groups = await normalDataContext.Groups.ToListAsync();
            //foreach (var gr in groups)
            //{
            //    gr.Creator = await normalDataContext.Users.FirstOrDefaultAsync(x=>x.Id==groups.

            //}
            return View(groups);
        }

        //[HttpGet("groups")]
        //public IEnumerable<Group> GetGroups()
        //{
        //    return normalDataContext.Groups.AsEnumerable();
        //}
        
        [HttpGet]
        public async Task<IActionResult> GetGroupInfo(int? groupid)// [FromForm(Name = "search")] string searchString)
        {
            Group model = await normalDataContext.Groups.FirstOrDefaultAsync(x => x.Id == groupid);
            
            User creator = (User)await normalDataContext.Users.FirstOrDefaultAsync(x => x.Id == model.Creatorid);
            //if (!string.IsNullOrEmpty(searchString))
               // model.Events = await normalDataContext.Events.Include(x => x.Group).Where(x => x.GroupId == groupid && x.EventName.Contains(searchString)).ToListAsync();
            //else
            model.Events = await normalDataContext.Events.Include(x => x.Group).Where(x => x.GroupId == groupid).ToListAsync();
            model.Memberships = await normalDataContext.GroupMembers.Include(x => x.User).Include(x => x.User.Location).Where(x => x.GroupId == groupid).ToListAsync();

            ViewData["CreatorName"] = creator.FullName;
            return View(model);
        }
        public IActionResult AddMember(int? id)
        {
            GroupMember groupMember = new GroupMember() { 
                GroupId = (int)id,
                Group = normalDataContext.Groups.Find(id)
            };
            return View(groupMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddMember([FromForm]GroupMember member) 
        {
            User existingUser = await normalDataContext.Users.FirstOrDefaultAsync(x => x.Id == member.User.Id); // czy zarejestrowany?
            if(existingUser is null)
            {
                member.User.isPesudoUser = true; // tylko jeśli niezarejestrowany kolega
                var entry = await normalDataContext.Users.AddAsync(member.User);
            }
            else // kolega zarejestrowany
            {
                if(normalDataContext.GroupMembers.Any(m => m.User.Id == member.User.Id && m.GroupId == member.GroupId)) // jest już w tej grupie
                    return RedirectToAction("GetGroupInfo", new { groupid = member.GroupId });

                member.User = existingUser;
                member.UserId = existingUser.Id;
            }

            await normalDataContext.GroupMembers.AddAsync(member);
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetGroupInfo", new { groupid = member.GroupId });
        }

        [HttpGet]
        public JsonResult CurrentMemberAutocomplete([FromQuery]string term = "") // v - inserted text
        {
            var objMemberlist = normalDataContext.Users
                            .Where(u => u.UserName.ToUpper()
                            .Contains(term.ToUpper()))
                            .Select(u => new { id = u.Id, label = u.UserName, firstname = u.FirstName, lastname = u.LastName, phonenumber = u.PhoneNumber, email = u.Email })
                            .Distinct().ToList();
            return Json(objMemberlist);
        }

        public async Task<IActionResult> GroupCreate()
        {
            var signed = signInManager.IsSignedIn(User);
            var id = userManager.GetUserId(User);
            var name = userManager.GetUserName(User);
            
            User creator = await userManager.GetUserAsync(User);

            var model = new Group()
            {
                Creator = creator,
                Creatorid = creator.Id
            };
            //var test = context.Set<User>().ToArray();

            // var test2 = await userManager.FindByIdAsync("1");

           //model.Creator = await normalDataContext.Set<User>().FirstOrDefaultAsync(x => x.Id == "1");
           //model.Creatorid = model.Creator.Id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GroupCreate([FromForm]Group model)
        {
            var id = userManager.GetUserId(User);
            User creator = await userManager.GetUserAsync(User);
            //var creator = await normalDataContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
            model.Creator = creator;
            model.Creatorid = creator.Id;
            //model.Creator = await normalDataContext.Set<User>().FirstOrDefaultAsync(x => x.Id == model.Creator.Id);
            //model.CreatorName = model.Creator.UserName;
            model.Creator.isPesudoUser = false;
            normalDataContext.Add(model);
            await normalDataContext.GroupMembers.AddAsync(new GroupMember
            {
                GroupId = model.Id,
                User = model.Creator
               //Userid = model.Creator.Id
            }); 
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetGroupInfo",new { groupid=model.Id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            List<Event> events = await normalDataContext.Events.Include(x => x.Group).Where(x => x.GroupId == id).ToListAsync();
            foreach(var e in events)
            {

                normalDataContext.Events.Remove(normalDataContext.Events.Find(e.Id));
            }
            normalDataContext.Groups.Remove(normalDataContext.Groups.Find(id));
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("Secret", "Meeter");
        }
        
    }
}