using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class ReceiptPayment : BaseEntity
    {
        public Guid ReceiptPaymentId { get; set; }

        public string RecipientFullName { get; set; }

        //public Guid? VendorId { get; set; }
        public string VendorCode { get; set; }

        public string VendorName { get; set; }

        public string VendorCodeGrid { get; set; }

        public string VendorNameGrid { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ReasonPayment { get; set; }

        public string Employee { get; set; }

        public int? Quantity { get; set; }
        //public Guid? AccountId { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        public string Money { get; set; }

        public string BankAccountNumber { get; set; }

        //public Guid? BankAccountId { get; set; }
        public DateTime? KBADate { get; set; }

        [Required]
        [Duplication]
        public string VoucherNumber { get; set; }

        public DateTime? VoucherDate { get; set; }

        public string Explain { get; set; }

    }
}
