using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Vendor : BaseEntity
    {
        public Guid VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }

        public string TaxCode { get; set; }

        public string Address { get; set; }

        public int Debt { get; set; }
        public string IdCard { get; set; }
        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public Guid VendorGroupId { get; set; }

        public string VendorGroupName { get; set; }

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int IsCustomer { get; set; }
        public string XungHo { get; set; }

        public string FullName { get; set; }
    }
}
