using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IAppSettingConfigurationHandler
    {
        List<AppSettingConfigurationDto> GetAppSettingConfiguration();



        ///AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr("Scanning", Nobr);


        AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr(string SettingValue, string Nobr);


    }
}






