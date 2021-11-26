using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class AppSettingConfigurationHandler : IAppSettingConfigurationHandler
    {

        private JBEEPContext _context;

        public AppSettingConfigurationHandler( JBEEPContext context)
        {
            this._context = context;    
        }

        public List<AppSettingConfigurationDto> GetAppSettingConfiguration()
        {
            List<AppSettingConfigurationDto> result = (from config in _context.AppSetting_Configuration
                                                       select new AppSettingConfigurationDto
                                                       {
                                                           AutoKey = config.AutoKey,
                                                           SettingValue = config.SettingValue,
                                                           SettingItem = config.SettingItem,
                                                           KeyMan = config.KeyMan,
                                                           KeyDate = config.KeyDate,
                                                           Note = config.Note
                                                       }).ToList();
            return result;
        }

        public AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr(string SettingValue, string Nobr)
        {
            throw new NotImplementedException();
        }
    }
}
