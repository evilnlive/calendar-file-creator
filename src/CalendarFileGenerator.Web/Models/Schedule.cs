using System;
using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Models
{
    public class Schedule
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public IEnumerable<ScheduleWeek> Weeks { get; set; }
    }
}
