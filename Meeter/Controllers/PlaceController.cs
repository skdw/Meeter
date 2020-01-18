using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meeter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meeter.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlaceController : Controller
    {
        private readonly NormalDataContext normalDataContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public PlaceController(
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
            var places = await normalDataContext.Places.ToListAsync();
            return View(places);
        }

        public async Task<IActionResult> Create([FromQuery] Place place, [FromQuery] float lat, [FromQuery] float lng, 
            [FromQuery] bool open_now, [FromQuery] int user_ratings_total, [FromHeader] IEnumerable<string> types)
        {
            var model = place;
            return View(model);
        }

        [EnableCors]
        public async Task<IActionResult> GetFromAPI()
        {
            ViewData["lat"] = 51.2f;
            ViewData["lng"] = 21.0f;
            ViewData["radius"] = 1500;
            ViewData["type"] = "restaurant";
            return View();
        }
    }
}