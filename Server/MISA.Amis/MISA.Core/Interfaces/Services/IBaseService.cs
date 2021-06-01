using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy ra tất cả các bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        public  ServiceResult GetAll();

        /// <summary>
        /// Lấy ra T theo id
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của T</param>
        /// <returns>T</returns>
        public ServiceResult GetById(Guid id);

        /// <summary>
        /// Thêm mới bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public ServiceResult Insert(T entity);

        /// <summary>
        /// Cập nhật bản ghi theo id
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Thông tin cần sửa đổi</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public ServiceResult Update(Guid id, T entity);

        /// <summary>
        /// Xóa bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của thực thể cần xóa</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public ServiceResult Delete(Guid id);
    }
}
