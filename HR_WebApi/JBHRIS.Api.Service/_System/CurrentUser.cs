using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace JBHRIS.Api.Service._System
{
    public class CurrentUser
    {
        private IHttpContextAccessor _identity;

        public CurrentUser(IHttpContextAccessor identity)
        {
            _identity = identity;
        }
        public string GetUserName()
        {
            return _identity.HttpContext.User.Identity.Name;
        }
        public UserInfo UserInfo
        {
            get
            {
                UserInfo userInfo = new UserInfo();
                var userData = _identity.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Contains("userdata"));
                if (userData != null)
                {
                    userInfo = JsonConvert.DeserializeObject<UserInfo>(userData.Value);
                }
                return userInfo;
            }
        }
    }
}
