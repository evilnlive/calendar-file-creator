using CalendarFileGenerator.Web.Services;
using Xunit;

namespace CalendarFileGenerator.Web.Test.Services
{
    public class QueryStringParser_Test
    {
        [Fact]
        public void Empty_query_string_returns_null()
        {
            var queryString = string.Empty;

            var queryStringParser = new QueryStringParser();

            var result = queryStringParser.GetSchedule(queryString);

            Assert.Null(result);
        }
    }
}
