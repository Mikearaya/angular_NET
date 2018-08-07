using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class AccountType
    {
        public int AccTypeId { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }

        public AccountCategory CategoryNavigation { get; set; }
    }
}
