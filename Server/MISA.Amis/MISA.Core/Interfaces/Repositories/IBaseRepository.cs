using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy ra tất cả các bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        public IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy ra T theo id
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của T</param>
        /// <returns>T</returns>
        public T GetById(Guid id);

        /// <summary>
        /// Thêm mới bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public int Insert(T entity);

        /// <summary>
        /// Cập nhật bản ghi theo id
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Thông tin cần sửa đổi</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public int Update(Guid id, T entity);

        /// <summary>
        /// Xóa bản ghi
        /// CreatedBy: nvcuong (28/05/2021)
        /// </summary>
        /// <param name="id">Id của thực thể cần xóa</param>
        /// <returns>Số dòng trong DB bị ảnh hưởng</returns>
        public int Delete(Guid id);

        /// <summary>
        /// Lấy ra ị 1 thực thể qua property name
        /// </summary>
        /// <param name="column">Column cần lấy</param>
        /// <param name="value">Giá trị cần lấy</param>
        /// <returns>entity</returns>
        public T GetByProperty(string column, object value);

    }
}
