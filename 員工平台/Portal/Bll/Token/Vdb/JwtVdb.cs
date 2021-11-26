using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    class JwtVdb
    {
    }

    #region APIResult
    /// <summary>
    /// 呼叫 API 回傳的制式格式
    /// </summary>
    public class APIResult
    {
        /// <summary>
        /// 此次呼叫 API 是否成功
        /// </summary>
        public bool Status { get; set; } = false;
        /// <summary>
        /// 呼叫 API 失敗的錯誤訊息
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// 例外訊息
        /// </summary>
        public string StackTrace { get; set; } = "";
        /// <summary>
        /// 呼叫此API所得到的其他內容
        /// </summary>
        public Object Payload { get; set; } = null;
        /// <summary>
        /// 呼叫此API所得到的其他內容
        /// </summary>
        public Object Data { get; set; } = null;
        /// <summary>
        /// 有效的token
        /// </summary>
        public SigninRow Signin { get; set; } = null;
    }

    #endregion
}
