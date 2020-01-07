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
        private readonly MeeterDbContext context;
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public GroupController(
            UserManager<IdentityUser> usm,
            SignInManager<IdentityUser> sim,
            MeeterDbContext ctx, NormalDataContext normalD)
        {
            userManager = usm;
            signInManager = sim;
            context = ctx;
            normalDataContext = normalD;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("groups")]
        public IEnumerable<Group> GetGroups()
        {
            return normalDataContext.Groups.AsEnumerable();
        }
        public async Task<IActionResult> GroupCreate()
        {
            // string 

            var model = new Group();

            model.Creator = (User)await context.Users.FirstOrDefaultAsync(x => x.Id == "1");
            


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GroupCreate(Group model)
        {
            //if (!ModelState.IsValid)
            //{

            //    return View(model);
            //}
            Group group = new Group
            {
                Name = model.Name,

                Creator = model.Creator
            };
            await normalDataContext.Groups.AddAsync(group);
            await normalDataContext.GroupMembers.AddAsync(new GroupMember
            {
                GroupId = group.Id
                //, User = group.Creator
            });
            return RedirectToAction("Index");
        }
    }
}