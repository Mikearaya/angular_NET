using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class GeneralLedger
    {
        public uint LedgerId { get; set; }
        public string AccountId { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
