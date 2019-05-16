using CalendarFileGenerator.Web.Models.Ics;
using CalendarFileGenerator.Web.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalendarFileGenerator.Web.Test.Services
{
    public class IcalService_Test
    {
        private const string OneEvent = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//hacksw/handcal//NONSGML v1.0//EN
BEGIN:VEVENT
DTSTART:20150101T143000Z
DTEND:20150101T153000Z
SUMMARY:Möte 1
END:VEVENT
END:VCALENDAR";

        private const string TwoEvents = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//hacksw/handcal//NONSGML v1.0//EN
BEGIN:VEVENT
DTSTART:20150101T143000Z
DTEND:20150101T153000Z
SUMMARY:Möte 1
END:VEVENT
BEGIN:VEVENT
DTSTART:20150101T183000Z
DTEND:20150101T193000Z
SUMMARY:Möte 2
END:VEVENT
END:VCALENDAR";

        private readonly CalendarEvent Event1 = new CalendarEvent
        {
            Title = "Möte 1",
            From = new DateTime(2015, 01, 01, 15, 30, 0),
            Until = new DateTime(2015, 01, 01, 16, 30, 0)
        };

        private readonly CalendarEvent Event2 = new CalendarEvent
        {
            Title = "Möte 2",
            From = new DateTime(2015, 01, 01, 19, 30, 0),
            Until = new DateTime(2015, 01, 01, 20, 30, 0)
        };


        [Fact]
        public void When_adding_one_event_Then_it_can_be_serialized()
        {
            var events = new List<CalendarEvent> { Event1 };

            var sut = new IcalService();

            var ical = sut.SerializeToIcal(events);

            Assert.Equal(OneEvent, ical);
        }


        [Fact]
        public void When_adding_two_events_Then_they_can_be_serialized()
        {
            var events = new List<CalendarEvent> { Event1, Event2 };

            var sut = new IcalService();

            var ical = sut.SerializeToIcal(events);

            Assert.Equal(TwoEvents, ical);
        }
    }
}
