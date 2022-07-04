using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;

        public UserValidateService(IUserValidateDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration;
        }

        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="UserId">使用者輸入帳號</param>
        /// <param name="Password">使用者輸入密碼</param>
        /// <returns></returns>
        public ApiResult<string> ValidateUser(string UserId,string Password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            var user = _userDal.GetUserValidate(UserId);
            if(user != null)
            {
                if (user.LockoutEnabled)
                {
                    if(user.LockoutEnd == null)
                    {
                        apiResult.State = false;
                        apiResult.Result += "帳號已鎖定，請洽管理員解鎖";
                    }
                    else if (user.LockoutEnd > DateTime.Now)
                    {
                        apiResult.State = false;
                        var unLockDateTime = user.LockoutEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        apiResult.Result += $"帳號已鎖定，解鎖時間為：{unLockDateTime}";
                    }
                    else
                    {
                        _userDal.SetLockEnable(user.UserId,false,null);
                        apiResult = ValidPasswordAccessFailedCountLogin(Password, user);
                    }
                }
                else
                {
                    apiResult = ValidPasswordAccessFailedCountLogin(Password, user);
                }
            }
            return apiResult;
        }

        private ApiResult<string> ValidPasswordAccessFailedCountLogin(string inputPassword, Dto._System.UserValidateDto user)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            LoginLimitConfigDto loginLimitApiResult = _userDal.GetLoginLimitConfig();
            int MaxFaildLogin = loginLimitApiResult.MaxFaildLoginCount;
            int LockAccountSecond = loginLimitApiResult.LockAccountSecond;

            if (user.Password != inputPassword)
            {
                int errorCount = _userDal.AddAccessFailedCount(user.UserId);
                _userDal.AddSecurityLogs(user.UserId, SecurityLogsDto.LoginFailed);
                apiResult.Result = $"密碼輸入錯誤{errorCount}次";

                if(errorCount >= MaxFaildLogin)
                {
                    var LockoutEnd = DateTime.Now.AddSeconds(LockAccountSecond);
                    _userDal.SetLockEnable(user.UserId, true, LockoutEnd);
                    _userDal.AddSecurityLogs(user.UserId, SecurityLogsDto.LoginLock);
                    apiResult.Result = $"密碼輸入錯誤{MaxFaildLogin}次已鎖定，解鎖時間為：{LockoutEnd}";
                }
            }
            else
            {
                apiResult.State = true;
                apiResult.Result = user.UserId;
                _userDal.AddSecurityLogs(user.UserId, SecurityLogsDto.LoginSucceeded);
                _userDal.SetLockEnable(user.UserId, false, null);
            }
            return apiResult;
        }

        public bool SetLockEnable(string Nobr, bool Lockstate, DateTime? LockoutEnd)
        {
            return _userDal.SetLockEnable(Nobr, Lockstate, LockoutEnd);
        }
        public ApiResult<UpdateLoginLimitConfigDto> UpdateLoginLimitConfig(UpdateLoginLimitConfigDto loginLimitConfigDto)
        {
            return _userDal.UpdateLoginLimitConfig(loginLimitConfigDto);
        }

        public LoginLimitConfigDto GetLoginLimitConfig()
        {
            return _userDal.GetLoginLimitConfig();
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
