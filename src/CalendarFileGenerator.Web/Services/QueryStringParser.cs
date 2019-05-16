using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Services.Interfaces;
using System;

namespace CalendarFileGenerator.Web.Services
{
    public class QueryStringParser : IQueryStringParser
    {
        public Schedule GetSchedule(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return null;
            }

            return new Schedule();
        }
    }
}
