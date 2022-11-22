using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        //Model Validation
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 or 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Descriptions is too long.")]   
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public EventType Type { get; set; }

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Concert.ToString(), ((int)EventType.Concert).ToString()),
            new SelectListItem(EventType.ComedyShow.ToString(), ((int)EventType.ComedyShow).ToString()),
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString())

        };
        //<option value="0">Conference</option>
    }
}
