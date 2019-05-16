using System.Collections.Generic;
using System.Text;
using CalendarFileGenerator.Web.Models.Ics;
using CalendarFileGenerator.Web.Services.Interfaces;

namespace CalendarFileGenerator.Web.Services
{
    public class IcalService : IIcalService
    {
        private const string CalendarFormat = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//hacksw/handcal//NONSGML v1.0//EN
{0}END:VCALENDAR";

        private const string EventFormat = @"BEGIN:VEVENT
DTSTART:{0}
DTEND:{1}
SUMMARY:{2}
END:VEVENT";

        private const string DateFormat = "yyyyMMddTHHmmssZ";

        public string SerializeToIcal(IEnumerable<CalendarEvent> events)
        {
            var eventsStringBuilder = new StringBuilder();

            foreach (var calendarEvent in events)
            {
                eventsStringBuilder.AppendLine(
                    string.Format(
                        EventFormat,
                        calendarEvent.From.ToUniversalTime().ToString(DateFormat),
                        calendarEvent.Until.ToUniversalTime().ToString(DateFormat),
                        calendarEvent.Title));
            }

            var ical = string.Format(CalendarFormat, eventsStringBuilder);

            return ical;
        }
    }
}
