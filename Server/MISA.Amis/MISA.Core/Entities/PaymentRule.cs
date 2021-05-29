using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class PaymentRule : BaseEntity
    {
        public Guid PaymentRuleId { get; set; }
        public string PaymentRuleName { get; set; }

        public int MaxDate { get; set; }

        public int MaxDebt { get; set; }

        public string ReceiveAccount { get; set; }

        public string ReceiveAccountNumber { get; set; }
        public string PaymentAccount { get; set; }
        public string PaymentAccountNumber { get; set; }

        public Guid VendorId { get; set; }
    }
}
