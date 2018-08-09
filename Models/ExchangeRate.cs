using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class ExchangeRate
    {
        public uint RateId { get; set; }
        public string CurrencyCode { get; set; }
        public float BuyRate { get; set; }
        public float SaleRate { get; set; }
        public DateTime Date { get; set; }
    }
}
