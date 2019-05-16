using CalendarFileGenerator.Web.Models;

namespace CalendarFileGenerator.Web.Services.Interfaces
{
    public interface IQueryStringParser
    {
        Schedule GetSchedule(string queryString);
    }
}
