using System;
using System.Linq;

namespace JBHRIS.Api.Service
{
    /// <summary>
    /// 使用者驗證服務
    /// </summary>
    public class UserValidateService
    {
        public UserValidateService()
        {

        }

        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool ValidateUser(string UserId,string Password)
        {
            if (new string[] { "stanley", "shingo" }.Contains(UserId.ToLower()))
                return true;
            return false;
        }
    }
}
