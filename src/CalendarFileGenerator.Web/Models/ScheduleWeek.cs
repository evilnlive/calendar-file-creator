using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Models
{
    public class ScheduleWeek
    {
        public IEnumerable<ScheduleDay> Days { get; set; }
    }
}