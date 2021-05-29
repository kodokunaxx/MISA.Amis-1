using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa  bản ghi gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa bản ghi gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
