using CalendarFileGenerator.Web.Models.Ics;
using System.Collections.Generic;

namespace CalendarFileGenerator.Web.Services.Interfaces
{
    public interface IIcalService
    {
        string SerializeToIcal(IEnumerable<CalendarEvent> events);
    }
}
