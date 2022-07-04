using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using System;

namespace JBHRIS.Api.Dal._System
{
    public interface IUserValidateDal
    {
        UserValidateDto GetUserValidate(string userId);
        UserValidateDto GetUserAdValidate(string AdName);
        int AddAccessFailedCount(string Nobr);
        bool ResetAccessFailedCount(string Nobr);
        ApiResult<string> AddSecurityLogs(string Nobr,string Action);
        bool SetLockEnable(string Nobr,bool Lockstate, DateTime? LockoutEnd);
        ApiResult<UpdateLoginLimitConfigDto> UpdateLoginLimitConfig(UpdateLoginLimitConfigDto loginLimitConfigDto);

        LoginLimitConfigDto GetLoginLimitConfig();
    }
}