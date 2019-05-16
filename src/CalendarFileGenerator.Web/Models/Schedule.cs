using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Models
{
    public class Schedule
    {
        public IEnumerable<ScheduleWeek> Weeks { get; set; }
    }
}
