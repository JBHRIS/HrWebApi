using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IBSSIDHandler
    {
        bool CheckBSSID(string BSSID);
        /// <summary>
        /// 檢查是否有設定BSSID
        /// </summary>
        /// <returns></returns>
        int GetBssidCount();
    }
}
