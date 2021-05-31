using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Cờ Required yêu cầu không được để trống
    /// </summary>
    /// CreatedBy: nvcuong (30/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    /// <summary>
    /// Cờ Duplication yêu cầu thông tin không được trùng 
    /// </summary>
    /// CreatedBy: nvcuong (30/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplication : Attribute
    {

    }

    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa  bản ghi gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa bản ghi gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
