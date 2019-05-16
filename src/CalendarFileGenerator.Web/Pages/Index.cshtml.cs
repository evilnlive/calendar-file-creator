using System;
using System.Collections.Generic;
using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Models.Ics;
using CalendarFileGenerator.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalendarFileGenerator.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IQueryStringParser _queryStringParser;
        private readonly IIcalService _icalService;

        [BindProperty]
        public Schedule Schedule { get; set; }

        public IndexModel(IQueryStringParser queryStringParser, IIcalService icalService)
        {
            _queryStringParser = queryStringParser;
            _icalService = icalService;
        }

        public void OnGet()
        {
            Schedule = new Schedule
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7),
                Weeks = new List<ScheduleWeek> { CreateScheduleWeek() }
            };
        }

        public void OnPostAddWeek()
        {
            Schedule.Weeks.Add(CreateScheduleWeek());
        }

        public IActionResult OnPost()
        {
            var schedule = _queryStringParser.GetSchedule(Request.QueryString.Value);

            if (schedule == null)
            {
                return Page();
            }

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

            var ics = _icalService.SerializeToIcal(new List<CalendarEvent> { event1, event2 });

            return new ContentResult() { Content = ics, ContentType = "text/calendar" };
        }

        private static ScheduleWeek CreateScheduleWeek()
        {
            return new ScheduleWeek
            {
                Days = new List<ScheduleDay> {
                            new ScheduleDay { From = "8:00", Until = "17:00" },
                            new ScheduleDay { From = "8:00", Until = "17:00" },
                            new ScheduleDay { From = "8:00", Until = "17:00" },
                            new ScheduleDay { From = "8:00", Until = "17:00" },
                            new ScheduleDay { From = "8:00", Until = "17:00" }
                }
            };
        }
    }
}
