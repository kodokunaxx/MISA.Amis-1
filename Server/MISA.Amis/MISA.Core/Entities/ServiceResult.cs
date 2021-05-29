using MISA.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Mã kết quả 
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// Message trả về cho dev
        /// </summary>
        public List<String> DevMessage { get; set; }

        /// <summary>
        /// Message trả về cho user
        /// </summary>
        public List<String> UserMessage { get; set; }

        /// <summary>
        /// Data trả về cho Client
        /// </summary>
        public object Data { get; set; }

        public ServiceResult()
        {
            ResultCode = (int)EnumServiceResult.Success;
            DevMessage = new List<string>();
            UserMessage = new List<string>();
            Data = null;
        }
    }
}
