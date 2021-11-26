using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IUserInfoInterface
    {
        string[] GetApiRoles(string UserId);

        UserInfoDto GetUserInfo(string UserId);
    }
}
