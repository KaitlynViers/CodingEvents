using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    
    public class EventsController : Controller
    {
        static private Dictionary<string,string> Events = new Dictionary<string, string>();
        [HttpGet]
        public IActionResult Index()
        {
           /* Events.Add("Dan Howell");
            Events.Add("Taylor Swift");
            Events.Add("Graduation"); */
           // New event method will let the user add events to the list.
            ViewBag.events = Events;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string desc)
        {
            Events.Add(name, desc);
            return Redirect("/Events");
        }
    }
}
