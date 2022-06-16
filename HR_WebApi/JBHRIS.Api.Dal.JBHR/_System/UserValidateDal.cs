using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class UserValidateDal : IUserValidateDal
    {
        private IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;

        public UserValidateDal(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor = null)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContextAccessor?.HttpContext;
        }

        public int AddAccessFailedCount(string Nobr)
        {
            int AccessFailedCount = 0;
            try
            {
                var Repo = _unitOfWork.Repository<Base>();
                var emp = Repo.Read(p => p.Nobr == Nobr);
                if (emp != null)
                    emp.AccessFailedCount = emp.AccessFailedCount + 1;
                Repo.SaveChanges();
                AccessFailedCount = emp.AccessFailedCount;
            }
            catch
            {

            }
            return AccessFailedCount;
        }

        public ApiResult<string> AddSecurityLogs(string Nobr, string Action)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<SecurityLogs>();
                SecurityLogs securityLogs = new SecurityLogs()
                {
                    Id = Guid.NewGuid(),
                    Nobr = Nobr,
                    Action = Action,
                    ClientIpAddress = _httpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    BrowserInfo = _httpContext.Request.Headers["User-Agent"].ToString(),
                    CreationTime = DateTime.Now
                };
                Repo.Create(securityLogs);
                Repo.SaveChanges();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;
        }

        public UserValidateDto GetUserAdValidate(string AdName)
        {
            var emp = _unitOfWork.Repository<Base>().Read(p => p.NameAd == AdName);
            if (emp != null)
                return new UserValidateDto { Password = emp.Password, UserId = emp.Nobr };
            return null;
        }

        public UserValidateDto GetUserValidate(string userId)
        {
            var emp = _unitOfWork.Repository<Base>().Read(p => p.Nobr == userId);
            if (emp != null)
                return new UserValidateDto {
                    Password = emp.Password,
                    UserId = emp.Nobr,
                    LockoutEnabled = emp.LockoutEnabled,
                    LockoutEnd = emp.LockoutEnd 
                };
            return null;
        }

        public bool ResetAccessFailedCount(string Nobr)
        {
            bool state = false;
            try
            {
                var Repo = _unitOfWork.Repository<Base>();
                var emp = Repo.Read(p => p.Nobr == Nobr);
                if (emp != null)
                    emp.AccessFailedCount = 0;
                Repo.SaveChanges();
                state = true;
            }
            catch
            {

            }
            return state;
        }


        public bool SetLockEnable(string Nobr, bool Lockstate, DateTime? LockoutEnd)
        {
            var state = false;
            try
            {
                var Repo = _unitOfWork.Repository<Base>();
                var emp = Repo.Read(p => p.Nobr == Nobr);
                if (emp != null)
                {
                    if (Lockstate)
                    {
                        emp.LockoutEnd = LockoutEnd;
                    }
                    else
                    {
                        emp.LockoutEnd = null;
                        emp.AccessFailedCount = 0;
                    }
                    emp.LockoutEnabled = Lockstate;
                }
                Repo.SaveChanges();
                state = true;
            }
            catch
            {

            }
            return state;
        }

        public ApiResult<UpdateLoginLimitConfigDto> UpdateLoginLimitConfig(UpdateLoginLimitConfigDto loginLimitConfigDto)
        {
            ApiResult<UpdateLoginLimitConfigDto> apiResult = new ApiResult<UpdateLoginLimitConfigDto>();
            string KeyMan = loginLimitConfigDto.KeyMan;
            DateTime nowDateTime = DateTime.Now;
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<AppConfig>();
                var MaxFaildLoginCountRepo = Repo.Read(p => p.Category == "RwdPortal" && p.Code == "MaxFaildLoginCount");
                if (MaxFaildLoginCountRepo != null)
                {
                    MaxFaildLoginCountRepo.Value = loginLimitConfigDto.MaxFaildLoginCount.ToString();
                    MaxFaildLoginCountRepo.KeyMan = KeyMan;
                    MaxFaildLoginCountRepo.KeyDate = nowDateTime;
                }
                var LockAccountSecondRepo = Repo.Read(p => p.Category == "RwdPortal" && p.Code == "LockAccountSecond");
                if (LockAccountSecondRepo != null)
                {
                    LockAccountSecondRepo.Value = loginLimitConfigDto.LockAccountSecond.ToString();
                    LockAccountSecondRepo.KeyMan = KeyMan;
                    LockAccountSecondRepo.KeyDate = nowDateTime;
                }
                Repo.SaveChanges();
                apiResult.Result = new UpdateLoginLimitConfigDto()
                {
                    MaxFaildLoginCount = Convert.ToInt32(MaxFaildLoginCountRepo.Value),
                    LockAccountSecond = Convert.ToInt32(LockAccountSecondRepo.Value),
                    KeyMan = KeyMan,
                    KeyDate = nowDateTime
                };
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.Message.ToString();
            }
            return apiResult;
        }
        public LoginLimitConfigDto GetLoginLimitConfig()
        {
            LoginLimitConfigDto defaultConfig = new LoginLimitConfigDto() {  MaxFaildLoginCount = 3 , LockAccountSecond = 300};
            DateTime nowDateTime = DateTime.Now;
            AppConfig DefaultMaxFaildLogin = new AppConfig()
            {
                 Category = "RwdPortal",
                 Code = "MaxFaildLoginCount",
                 Comp = "",
                 NameP = "Portal登入錯誤次數上限",
                 Value = defaultConfig.MaxFaildLoginCount.ToString(),
                 Note = "Portal登入錯誤次數上限",
                 DataType = "String",
                 ControlType = "TextBox",
                 DataSource = "",
                 Sort = 0,
                 KeyDate = nowDateTime,
                 KeyMan = "JB"
            };
            AppConfig DefaultLockAccountSecond = new AppConfig()
            {
                Category = "RwdPortal",
                Code = "LockAccountSecond",
                Comp = "",
                NameP = "Portal登入帳號鎖定秒數",
                Value = defaultConfig.LockAccountSecond.ToString(),
                Note = "Portal登入帳號鎖定秒數",
                DataType = "String",
                ControlType = "TextBox",
                DataSource = "",
                Sort = 0,
                KeyDate = nowDateTime,
                KeyMan = "JB"
            };
            try
            {
                var Repo = _unitOfWork.Repository<AppConfig>();
                var MaxFaildLoginCountRepo = Repo.Read(p => p.Category == "RwdPortal" && p.Code == "MaxFaildLoginCount");
                if (MaxFaildLoginCountRepo != null)
                {
                    defaultConfig.MaxFaildLoginCount = Convert.ToInt32(MaxFaildLoginCountRepo.Value);
                }
                else
                {
                    Repo.Create(DefaultMaxFaildLogin);
                }

                var LockAccountSecondRepo = Repo.Read(p => p.Category == "RwdPortal" && p.Code == "LockAccountSecond");
                if (LockAccountSecondRepo != null)
                {
                    defaultConfig.LockAccountSecond = Convert.ToInt32(LockAccountSecondRepo.Value);
                }
                else
                {
                    Repo.Create(DefaultLockAccountSecond);
                }
                Repo.SaveChanges();
            }
            catch(Exception ex)
            {
            }
            return defaultConfig;
        }
    }
}
