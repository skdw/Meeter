using Meeter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            model.Memberships = await normalDataContext.GroupMembers.Include(x => x.User).Where(x => x.GroupId == groupid).ToListAsync();
            ViewData["CreatorName"] = creator.FirstName;
            return View(model);

        }
        public async Task<IActionResult> AddMember(int? id)
        {
            GroupMember groupMember = new GroupMember() { GroupId = (int)id }; // tutaj nie powinno iść inne id dla grupy? 
            groupMember.User = new User() ;
            
            return View(groupMember);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddMember([FromForm]GroupMember model,[FromQuery(Name ="username")] int id)
        {
            await normalDataContext.Users.AddAsync(model.User);
            
            await normalDataContext.GroupMembers.AddAsync(model);
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetGroupInfo", new { groupid = model.GroupId });
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
    }
}