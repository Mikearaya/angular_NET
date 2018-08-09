using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class Jornal
    {
        public uint JornalId { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Reference { get; set; }
    }
}
