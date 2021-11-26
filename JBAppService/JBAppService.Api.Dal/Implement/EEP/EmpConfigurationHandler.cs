using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class EmpConfigurationHandler : IEmpConfigurationHandler
    {

        private JBEEPContext _context;

        public EmpConfigurationHandler(JBEEPContext context)
        {
            this._context = context;
        }

        public AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr(string SettingValue, string Nobr)
        {

            AppSettingConfigurationDto result = new AppSettingConfigurationDto();
            result = (from Con in _context.EmpConfiguration
                      where Con.SettingValue == SettingValue && Con.Nobr == Nobr
                      select new AppSettingConfigurationDto
                      {
                          AutoKey = Con.AutoKey,
                          SettingValue = Con.SettingItem,
                          SettingItem = Con.SettingItem,
                          KeyMan = Con.KeyMan,
                          KeyDate = Con.KeyDate,
                          Note = ""
                      }).FirstOrDefault();


            return result;
        }

        public List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr()
        {
            List<AppSettingConfigurationDto> result = new List<AppSettingConfigurationDto>();
            result = (from Con in _context.EmpConfiguration
                      select new AppSettingConfigurationDto
                      {
                          AutoKey = Con.AutoKey,
                          SettingValue = Con.SettingItem,
                          SettingItem = Con.SettingItem,
                          KeyMan = Con.KeyMan,
                          KeyDate = Con.KeyDate,
                          Note = ""
                      }).ToList();


            return result;
        }

        public List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr(string Nobr)
        {
            List<AppSettingConfigurationDto> result = new List<AppSettingConfigurationDto>();
            result = (from Con in _context.EmpConfiguration
                      where Con.Nobr == Nobr
                      select new AppSettingConfigurationDto
                      {
                          AutoKey = Con.AutoKey,
                          SettingValue = Con.SettingItem,
                          SettingItem = Con.SettingItem,
                          KeyMan = Con.KeyMan,
                          KeyDate = Con.KeyDate,
                          Note = ""
                      }).ToList();


            return result;
        }
		
		//FCoinReutersCBNFTSpaceDCFedNow
		//RUNEKATOMSMLUNAANKR
		//CCELAKELPROMEODCRPABAKEBTGX
		//OHUSDFTMFLOWMGODCRPROM
		//CRXDCRENUSDNODCRPROM
		//FCoinReutePROMrsCBNFTSODCRpaceDCFedNow
		//RUNEKATOMSMLUNAANKRPROM
		//CCELAKELEODCCADARPABAKEBTGX
		//OHUSDFTMFLOWMGODCRCELR
		//CRXDCRENGNOUSDNODCRGTOCEANBAL

    }
}
