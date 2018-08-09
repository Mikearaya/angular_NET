using System;
using System.Collections.Generic;

namespace angularNet.Models
{
    public partial class AccountCategory
    {
        public AccountCategory()
        {
            AccountType = new HashSet<AccountType>();
        }

        public int AccCatId { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }

        public ICollection<AccountType> AccountType { get; set; }
    }
}
