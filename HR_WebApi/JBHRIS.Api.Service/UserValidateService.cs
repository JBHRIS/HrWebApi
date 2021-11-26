using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dto;
using System;
using System.Linq;

namespace JBHRIS.Api.Service
{
    /// <summary>
    /// 使用者驗證服務
    /// </summary>
    public class UserValidateService
    {
        private IUserValidateDal _userDal;

        public UserValidateService(IUserValidateDal userDal)
        {
            _userDal = userDal;
        }

        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public ApiResult<string> ValidateUser(string UserId,string Password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var user = _userDal.GetUserValidate(UserId);
            if (user != null && user.Password == Password)
            {
                apiResult.State = true;
                apiResult.Result = user.UserId;
            }
            return apiResult;
        }

        /// <summary>
        /// Ad驗證使用者
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public ApiResult<string> ValidateAdUser(string AdName)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var user = _userDal.GetUserAdValidate(AdName);
            if (user != null)
            {
                apiResult.State = true;
                apiResult.Result = user.UserId;
            }
            return apiResult;
        }
    }
}
