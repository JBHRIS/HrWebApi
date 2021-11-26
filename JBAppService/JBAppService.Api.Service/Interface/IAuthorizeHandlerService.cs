using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IAuthorizeHandlerService
    {
        bool IsRegistry(string userId, string deviceId);
        void RegistryId(string userId, string deviceId);
    }
}
