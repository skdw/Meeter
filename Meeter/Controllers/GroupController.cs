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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public GroupController(
            UserManager<IdentityUser> usm,
            SignInManager<IdentityUser> sim,
            NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;

            normalDataContext = normalD;
        }
        public async Task<IActionResult> Index()
        {
            List<Group> groups = await normalDataContext.Groups.ToListAsync();
            return View(groups);
        }

        [HttpGet("groups")]
        public IEnumerable<Group> GetGroups()
        {
            return normalDataContext.Groups.AsEnumerable();
        }
        public async Task<IActionResult> GetGroupInfo(int? groupid)
        {
            Group model = await normalDataContext.Groups.FirstOrDefaultAsync(x => x.Id == groupid);
            User creator = await normalDataContext.Users.FirstOrDefaultAsync(x => x.Id == model.Creatorid); 
            ViewData["CreatorName"] = creator.FirstName;
            return View(model);

        }
        public async Task<IActionResult> GroupCreate()
        {
            // string 

            var model = new Group();
            //var test = context.Set<User>().ToArray();

            // var test2 = await userManager.FindByIdAsync("1");
            model.Creator = (User)await normalDataContext.Set<User>().FirstOrDefaultAsync(x => x.Id == "1");
            model.Creatorid = model.Creator.Id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GroupCreate([FromForm]Group model)
        {
            model.Creator = (User)await normalDataContext.Set<User>().FirstOrDefaultAsync(x => x.Id == model.Creatorid);


            normalDataContext.Add(model);
            //await normalDataContext.GroupMembers.AddAsync(new GroupMember
            //{
            //    GroupId = model.Id,
            //    User = model.Creator
            //});
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetGroupInfo",new { groupid=model.Id });
        }
    }
}