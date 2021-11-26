using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IEmpConfigurationHandler
    {

        /// <summary>
        /// 這個沒有用
        /// </summary>
        /// <returns></returns>
        List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr();

        /// <summary>
        /// 依照工號 取得個人設定檔
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr(string Nobr);


        /// <summary>
        /// 這個沒有用
        /// </summary>
        /// <returns></returns>
        AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr(string SettingValue, string Nobr);

    }
}
