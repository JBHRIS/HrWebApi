using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class BSSIDService : IBSSIDInterface
    {

        private IBSSIDHandler _IBSSIDHandler;

        public BSSIDService(IBSSIDHandler bSSIDHandler)
        {
            this._IBSSIDHandler = bSSIDHandler;
        }

        public bool CheckBSSID(string BSSID)
        {
            return this._IBSSIDHandler.CheckBSSID(BSSID);
        }
        public int GetBssidCount()
        {
            return this._IBSSIDHandler.GetBssidCount();
        }
    }
}
