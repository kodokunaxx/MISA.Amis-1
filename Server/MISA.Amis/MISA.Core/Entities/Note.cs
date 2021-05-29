using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class Note : BaseEntity
    {
        public Guid NoteId { get; set; }

        public string NoteContent { get; set; }

        public Guid VendorId { get; set; }
    }
}
