using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class Suppliers
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string PayableAccount { get; set; }
        public string PayableDiscountAccount { get; set; }
        public string PurchaseAccount { get; set; }
        public sbyte TaxIncluded { get; set; }
        public int? CreditLimit { get; set; }
        public string AccountNumber { get; set; }
        public string BankAccount { get; set; }
        public sbyte Active { get; set; }
    }
}
