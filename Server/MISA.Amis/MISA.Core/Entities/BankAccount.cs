using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class BankAccount : BaseEntity
    {
        public Guid BankAccountId { get; set; }

        public string AccountNumber { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }

        public string City { get; set; }

        public Guid VendorId { get; set; }

    }
}
