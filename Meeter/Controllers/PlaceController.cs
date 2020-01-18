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

            var location = await normalDataContext.Locations.Where(x => x.Lat == lat && x.Lng == lng).FirstOrDefaultAsync();
            if(location is null)
            {
                location = new Location() { Lat = lat, Lng = lng };
                normalDataContext.Locations.Add(location);
                await normalDataContext.SaveChangesAsync();
            }

            model.Location = location;
            model.LocationId = location.Id;

            model.OpenNow = open_now;
            model.UserRatingsTotal = user_ratings_total;

            foreach(string type in types)
            {
                var typeObj = await normalDataContext.PlaceTypes.Where(x => x.Type == type).FirstAsync();
                if(typeObj != null)
                    model.Types.Add(typeObj);
            }

            normalDataContext.Places.Add(model);
            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetPlaceInfo", new { id = model.Id });
        }

        [EnableCors]
        public async Task<IActionResult> GetFromAPI()
        {
            ViewData["lat"] = -33.8708902f;
            ViewData["lng"] = 151.2074116f;
            ViewData["radius"] = 1500;
            ViewData["type"] = "restaurant";
            return View();
        }
    }
}