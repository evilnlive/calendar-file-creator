using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Models.Ics;
using CalendarFileGenerator.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CalendarFileGenerator.Web.Pages
{
    public class FileModel : PageModel
    {
        private readonly IQueryStringParser _queryStringParser;
        private readonly IIcalService _icalService;

        public FileModel(IQueryStringParser queryStringParser, IIcalService icalService)
        {
            _queryStringParser = queryStringParser;
            _icalService = icalService;
        }

        public Schedule Schedule { get; set; }

        public IActionResult OnGet()
        {
            var schedule = _queryStringParser.GetSchedule(Request.QueryString.Value);

            Schedule = schedule;

            var event1 = new CalendarEvent
            {
                Title = "Möte 1",
                From = new DateTime(2015, 01, 01, 15, 30, 0),
                Until = new DateTime(2015, 01, 01, 16, 30, 0)
            };

            var event2 = new CalendarEvent
            {
                Title = "Möte 2",
                From = new DateTime(2015, 01, 01, 19, 30, 0),
                Until = new DateTime(2015, 01, 01, 20, 30, 0)
            };

            var ics = _icalService.SerializeToIcal(new List<CalendarEvent> { event1, event2});

            return new ContentResult() {  Content= ics, ContentType= "text/calendar"};
        }
    }
}