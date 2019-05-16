using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Models
{
    public class ScheduleWeek
    {
        public IList<ScheduleDay> Days { get; set; }
    }
}