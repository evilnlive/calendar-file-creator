namespace CalendarFileGenerator.Web.Services.Interfaces
{
    public interface IIndexCalculator
    {
        int WeekIndex(int index, int weekCount);

        int DayIndex(int index);
    }
}
