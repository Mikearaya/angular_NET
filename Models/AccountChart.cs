using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class AccountChart
    {
        public string AccountCode { get; set; }
        public string SubAccountCode { get; set; }
        public string Name { get; set; }
        public sbyte Active { get; set; }
        public int LocationId { get; set; }
        public uint AccountId { get; set; }
        public string AccountType { get; set; }

        public Location Location { get; set; }
    }
}
