using System;
using System.Collections.Generic;
using System.Text;

namespace HRWebService.Dto.Vdb
{
    public class AccountVdb
    {
        /// <summary>
        /// 是否驗證通過
        /// </summary>
        public bool Verification { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }


    }
}
