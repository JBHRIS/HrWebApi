using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Entry;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JBHRIS.Api.Service.Employee.View
{
    public interface IUserPasswordService
    {
        public ApiResult<string> VerifyIdentity(VerifyIdentityEntry verifyIdentityEntry);
        public bool UpdatePassword(string Nobr, UpdatePasswordEntry updatePasswordEntry);
        public bool ChangePassword(ChangePasswordEntry changePasswordEntry);
    }
}
