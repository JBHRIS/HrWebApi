using JBHRIS.Api.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Bll
{
    public static class GetUserInfos
    {
        public static UserInfo GetUserInfo(ClaimsPrincipal user)
        {
            UserInfo userInfo = new UserInfo();
            var userData = user.Claims.FirstOrDefault(p => p.Type.Contains("userdata"));
            if (userData != null)
            {
                userInfo = JsonConvert.DeserializeObject<UserInfo>(userData.Value);
            }
            return userInfo;
        }
    }
}
