using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class AuthorizeHandlerService : IAuthorizeHandlerService
    {
        private IAppRegistryKeyBindHandler _IAppRegistryKeyBindHandler;
        private IBaseHandler _IBaseHandler;

        public AuthorizeHandlerService(IAppRegistryKeyBindHandler IAppRegistryKeyBindHandler, IBaseHandler IBaseHandler)
        {
            _IAppRegistryKeyBindHandler = IAppRegistryKeyBindHandler;
            _IBaseHandler = IBaseHandler;
        }
        public bool IsRegistry(string userId, string deviceId)
        {
            return _IAppRegistryKeyBindHandler.IsRegistry(userId, deviceId);
        }

        public void RegistryId(string userId, string deviceId)
        {
            var rBase = _IBaseHandler.GetBaseInfo(userId);
            _IAppRegistryKeyBindHandler.RegistryId(userId, deviceId, rBase.Name);
        }
    }
}
