using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class VendorGroup : BaseEntity
    {
        public Guid VendorGroupId { get; set; }

        public string VendorGroupName { get; set; }

    }
}
