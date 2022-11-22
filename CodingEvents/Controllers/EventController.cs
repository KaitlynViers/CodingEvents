using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    
    public class EventsController : Controller
    {
        //static private Dictionary<string,string> Events = new Dictionary<string, string>();
        //static private List<Event> Events = new List<Event>();
        // [HttpGet]
        public IActionResult Index()
        {
            /* Events.Add("Dan Howell");
             Events.Add("Taylor Swift");
             Events.Add("Graduation"); */

            // New event method will let the user add events to the list.
            //ViewBag.events = EventData.GetAll(); 

            //Easier way of user adding event with less of a chance of a code breaking.
            List<Event> events = new List<Event> (EventData.GetAll()); 


            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
       // [Route("/Events/Add")] Did not need since changed name from NewEvent to Add
        public IActionResult Add(AddEventViewModel addEventViewModel)
            //passing in AddEventViewModel instead of Events newEvent to implement ViewModel
        {
            if (ModelState.IsValid)
            {
                /* Events.Add(name,desc);*/
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type= addEventViewModel.Type
                };
                EventData.Add(newEvent);
                return Redirect("/Events");
            }
            return View(addEventViewModel);
        }
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
            {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
            }

        [Route("/Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventtoEdit = editingEvent;
            ViewBag.title = "Edit Event" + editingEvent.Name + "(id=" + editingEvent.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/Events");
        }
    }
}
