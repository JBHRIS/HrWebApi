using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IBSSIDInterface
    {
        bool CheckBSSID(string BSSID);
        int GetBssidCount();
    }
}
