using System;
using System.Collections.Generic;
using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalendarFileGenerator.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IScheduleService _scheduleService;
        private readonly IIcalService _icalService;

        [BindProperty]
        public Schedule Schedule { get; set; }

        public IndexModel(IScheduleService scheduleService, IIcalService icalService)
        {
            _scheduleService = scheduleService;
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

        public IActionResult OnPostCreateFile()
        {
            var calendarEvents = _scheduleService.ParseSchedule(Schedule);

            var ics = _icalService.SerializeToIcal(calendarEvents);

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
                            new ScheduleDay { From = "8:00", Until = "17:00" },
                            new ScheduleDay(),
                            new ScheduleDay()
                }
            };
        }
    }
}
