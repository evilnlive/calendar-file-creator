using System;
using System.Collections.Generic;
using System.Linq;
using CalendarFileGenerator.Web.Models;
using CalendarFileGenerator.Web.Models.Ics;
using CalendarFileGenerator.Web.Services.Interfaces;

namespace CalendarFileGenerator.Web.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IIndexCalculator _indexCalculator;

        public ScheduleService(IIndexCalculator indexCalculator)
        {
            _indexCalculator = indexCalculator;
        }

        public IEnumerable<CalendarEvent> ParseSchedule(Schedule schedule)
        {
            var calendarEvents = new List<CalendarEvent>();
            var startDate = schedule.StartDate;
            var endDate = schedule.EndDate;
            var numberOfDays = (endDate - startDate).Days + 1;

            var startIndex = (int)startDate.DayOfWeek - 1;

            if(startIndex < 0 )
            {
                startIndex = 6;
            }

            var stopIndex = startIndex + numberOfDays;

            var firstMonday = startDate.AddDays(-startIndex);

            for (int i = startIndex; i < stopIndex; i++)
            {
                var scheduleDay = GetScheduleDay(i, schedule);

                var from = scheduleDay.From?.Trim();
                var until = scheduleDay.Until?.Trim();

                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(until))
                {
                    continue;
                }

                var currentDate = firstMonday.AddDays(i);
                var fromTime = DateTime.Parse(from);
                var untilTime = DateTime.Parse(until);

                calendarEvents.Add(new CalendarEvent
                {
                    From = currentDate.AddHours(fromTime.Hour).AddMinutes(fromTime.Minute),
                    Until = currentDate.AddHours(untilTime.Hour).AddMinutes(untilTime.Minute),
                    Title = $"From {from} to {until}"
                });
            }

            return calendarEvents;
        }

        private ScheduleDay GetScheduleDay(int index, Schedule schedule)
        {
            var weeks = schedule.Weeks.ToArray();
            var weekCount = weeks.Length;

            var weekIndex = _indexCalculator.WeekIndex(index, weekCount);
            var dayIndex = _indexCalculator.DayIndex(index);

            return weeks[weekIndex].Days[dayIndex];
        }
    }
}
