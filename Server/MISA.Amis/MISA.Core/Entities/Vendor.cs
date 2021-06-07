using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Vendor : BaseEntity
    {
        #region Properties
        #region Common
        public Guid VendorId { get; set; }

        public int? IsCustomer { get; set; }

        public string TaxCode { get; set; }
        
        [Required]
        [Duplication]
        public string VendorCode { get; set; }
        
        //[Required]
        public string VendorName { get; set; }
        
        public string Address { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Website { get; set; }
        
        public string VendorGroup { get; set; }
        
        public string Employee { get; set; }

        public string VendorXungHo { get; set; }

        public string VendorFullName { get; set; }

        public string Debt { get; set; }
        #endregion

        #region Contact

        public string ContactXungHo { get; set; }

        public string ContactFullName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string DDPL { get; set; }

        public string RecipientFullName { get; set; }

        public string RecipientEmail { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public string ContactTele { get; set; }

        public string IdCard { get; set; }

        public DateTime? IssuedOn { get; set; }

        public string Place { get; set; }

        #endregion

        #region PaymentRule

        public string PaymentRule { get; set; }

        public string MaxDate { get; set; }

        public string MaxDebt { get; set; }

        public string ReceiveAccount { get; set; }

        public string ReceiveAccountName { get; set; }
        public string PaymentAccount { get; set; }
        public string PaymentAccountName { get; set; }
        #endregion

        #region Address

        public string Country { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string Ward { get; set; }

        #endregion

        #region Note

        public string NoteContent { get; set; }

        #endregion

        #region Bank
        public string BankAccount { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }
        public string City { get; set; }

        #endregion

        #endregion
    }
}
