using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Contact : BaseEntity
    {
        public Guid ContactId { get; set; }
        public string XungHo { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Recipient { get; set; }

        public string RecipientEmail { get; set; }

        public string RecipientPhone { get; set; }

        public Guid VendorId { get; set; }



    }
}
