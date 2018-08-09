using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class BankTransactions
    {
        public uint Id { get; set; }
        public string BankAccountId { get; set; }
        public string Amount { get; set; }
        public sbyte Reconcield { get; set; }
        public string PersonId { get; set; }
    }
}
