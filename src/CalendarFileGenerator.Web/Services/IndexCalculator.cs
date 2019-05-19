using CalendarFileGenerator.Web.Services.Interfaces;

namespace CalendarFileGenerator.Web.Services
{
    public class IndexCalculator : IIndexCalculator
    {
        private const int DAYS_IN_A_WEEK = 7;

        public int WeekIndex(int index, int weekCount)
        {
            var weekIndex = index / DAYS_IN_A_WEEK;

            return weekIndex % weekCount;
        }

        public int DayIndex(int index)
        {
            return index % DAYS_IN_A_WEEK;
        }
    }
}
