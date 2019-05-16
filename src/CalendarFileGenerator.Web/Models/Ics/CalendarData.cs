using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Models.Ics
{
    public class CalendarData
    {
        public IEnumerable<CalendarEvent> Events { get; set; }
    }
}
