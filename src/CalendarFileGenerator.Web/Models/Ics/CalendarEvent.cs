﻿using System;

namespace CalendarFileGenerator.Web.Models.Ics
{
    public class CalendarEvent
    {
        public string Title { get; set; }

        public DateTime From { get; set; }

        public DateTime Until { get; set; }
    }
}