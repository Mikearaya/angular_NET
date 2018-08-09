using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class BankAccounts
    {
        public uint BankId { get; set; }
        public string Name { get; set; }
        public string BankAccountCode { get; set; }
        public string BankCreditAccount { get; set; }
        public string BankDebitAccount { get; set; }
    }
}
