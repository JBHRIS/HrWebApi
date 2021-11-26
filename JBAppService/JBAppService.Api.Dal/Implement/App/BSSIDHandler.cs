using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dal.Interface;

namespace JBAppService.Api.Dal.Implement.App
{
    public class BSSIDHandler : IBSSIDHandler
    {
        private AppDBContext _AppDBContext;

        public BSSIDHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }
        /// <summary>
        /// 檢查 WIFI BSSID 
        /// </summary>
        /// <param name="BSSID"></param>
        /// <returns></returns>
        public bool CheckBSSID(string BSSID)
        {
            bool result = false;

            result = (from wifi in this._AppDBContext.SSID_Identifier
                      where wifi.Status == true && wifi.BSSID.Trim() == BSSID.Trim()
                      select wifi).Any();

            return result;
        }
        public int GetBssidCount()
        {
            int result = 0;

            result = (from wifi in this._AppDBContext.SSID_Identifier
                      where wifi.Status == true
                      select wifi).Count();

            return result;
        }
    }
}
