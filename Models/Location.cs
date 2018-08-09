using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class Location
    {
        public Location()
        {
            AccountChart = new HashSet<AccountChart>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public ICollection<AccountChart> AccountChart { get; set; }
    }
}
