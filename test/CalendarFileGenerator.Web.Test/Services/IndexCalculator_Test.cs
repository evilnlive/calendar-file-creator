using CalendarFileGenerator.Web.Services;
using Xunit;

namespace CalendarFileGenerator.Web.Test.Services
{
    public class IndexCalculator_Test
    {
        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(10, 1, 0)]
        [InlineData(10, 2, 1)]
        [InlineData(20, 2, 0)]
        public void When_index_and_number_of_weeks_Then_week_is_returned(int index, int weekCount, int expected)
        {
            var sut = new IndexCalculator();

            var result = sut.WeekIndex(index, weekCount);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(6, 6)]
        [InlineData(7, 0)]
        [InlineData(8, 1)]
        public void When_index_Then_day_index_is_returned(int index, int expected)
        {
            var sut = new IndexCalculator();

            var result = sut.DayIndex(index);

            Assert.Equal(expected, result);
        }
    }
}
