using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class Currency
    {
        public uint CurrencyId { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }
        public string Symbole { get; set; }
        public string Country { get; set; }
    }
}
