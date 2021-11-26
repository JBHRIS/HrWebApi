using JBAppService.Api.Dal.Models.AppDBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IAppRegistryKeyBindHandler
    {
        bool IsRegistry(string EmpID, string RegistryKey);
        bool RegistryId(string userId, string deviceId, string name);
    }
}
