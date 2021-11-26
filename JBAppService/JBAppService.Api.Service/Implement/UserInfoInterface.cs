using JBAppService.Api.Dto;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class UserInfoInterface : IUserInfoInterface
    {

        public UserInfoInterface()
        {

        }

        public string[] GetApiRoles(string UserId)
        {
            throw new NotImplementedException();
        }

        public UserInfoDto GetUserInfo(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
