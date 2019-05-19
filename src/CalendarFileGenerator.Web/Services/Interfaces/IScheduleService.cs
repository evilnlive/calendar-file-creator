using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Models.Ics;
using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<CalendarEvent> ParseSchedule(Schedule schedule);
    }
}
