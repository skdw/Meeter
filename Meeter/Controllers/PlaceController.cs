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
            var places = await normalDataContext.Places.Include(x => x.Location).Include(x => x.Types).ToListAsync();
            return View(places);
        }

        //[HttpPost]
        // [EnableCors("GooglePolicy")]
        public async Task<IActionResult> Create([FromQuery] Place place, [FromQuery] float lat, [FromQuery] float lng, 
            [FromQuery] bool open_now, [FromQuery] int user_ratings_total, [FromHeader] IEnumerable<string> types)
        {
            if(place is null)
                return RedirectToAction("Index");

            var model = await normalDataContext.Places.Where(x => x.Id == place.Id).Include(x => x.Types).FirstOrDefaultAsync();
            if(model is null)
            {
                model = place;
                normalDataContext.Places.Add(model);
            }
            else
            {
                model.Icon = place.Icon;
                model.Name = place.Name;
                model.PriceLevel = place.PriceLevel;
                model.Rating = place.Rating;
                model.Vicinity = place.Vicinity;
            }

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
                var typeObj = await normalDataContext.Types.Where(x => x.Name == type).FirstOrDefaultAsync();
                if(typeObj != null)
                {
                    var typePlace = await normalDataContext.PlaceTypes.Include(x => x.Place).Include(x => x.Type).Where(x => x.Place.Id == model.Id && x.Type.Name == type).FirstOrDefaultAsync();
                    if(typePlace is null)
                        model.Types.Add(typeObj);
                }
            }

            await normalDataContext.SaveChangesAsync();
            return RedirectToAction("GetPlaceInfo", new { id = model.Id });
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> CreateFromAPI()
        {
            ViewData["lat"] = -33.8708902f;
            ViewData["lng"] = 151.2074116f;
            ViewData["radius"] = 1500;
            ViewData["type"] = "restaurant";
            return View("GetFromAPI");
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaceInfo(string id)
        {
            Place model = await normalDataContext.Places.FirstOrDefaultAsync(x => x.Id == id);

            return View(model);
        }
    }
}