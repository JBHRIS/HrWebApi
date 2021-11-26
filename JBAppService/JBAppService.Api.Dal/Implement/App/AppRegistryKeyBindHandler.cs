using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using System;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.App
{
    public class AppRegistryKeyBindHandler : IAppRegistryKeyBindHandler
    {
        private AppDBContext _AppDBContext;

        public AppRegistryKeyBindHandler(AppDBContext context)
        {
            _AppDBContext = context;
        }

        public bool IsRegistry(string EmpID, string RegistryKey)
        {
            bool result = false;

            var data  = (from app in _AppDBContext.AppRegistryKey_Bind
                      where app.Status == true
                      && (app.Nobr == EmpID || app.APP_RegistryKey == RegistryKey)
                      select app).ToList();

            result = (from c in data
                      where (c.APP_RegistryKey.Trim() == RegistryKey && c.Nobr.Trim() != EmpID)
                            || (c.APP_RegistryKey.Trim() != RegistryKey && c.Nobr.Trim() == EmpID)
                      select c).Any();

            return result;
        }

        public bool RegistryId(string userId, string deviceId,string name)
        {
            bool result = false;

            var data = (from app in _AppDBContext.AppRegistryKey_Bind
                        where app.Status == true && app.Nobr == userId
                        select app).FirstOrDefault();

            try
            {
                if (data == null)
                {
                    data = new AppRegistryKey_Bind();
                    data.APP_RegistryKey = deviceId;
                    data.Nobr = userId;
                    data.Name = name;
                    data.Status = true;
                    data.KeyMan = "System";
                    data.KeyDate = DateTime.Now;

                    _AppDBContext.AppRegistryKey_Bind.Add(data);
                    _AppDBContext.SaveChanges();

                }
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}