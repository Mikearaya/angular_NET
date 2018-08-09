using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class CalendarPeriod
    {
        public uint PeriodId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public sbyte Active { get; set; }
    }
}
