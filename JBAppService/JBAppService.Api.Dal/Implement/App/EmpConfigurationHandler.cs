using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.App
{
    public class EmpConfigurationHandler : IEmpConfigurationHandler
    {

        private AppDBContext _AppDBContext;

        public EmpConfigurationHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }

        public AppSettingConfigurationDto GetConfiguration_by_SettingValue_And_Nobr(string SettingValue, string Nobr)
        {

            AppSettingConfigurationDto result = new AppSettingConfigurationDto();
            result = (from Con in this._AppDBContext.EmpConfiguration
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr()
        {
			//0x008f925e3e422218604fac1cc2f06f3ef9c1e244e0d2a9a823e5bd8ce9778434
            List<AppSettingConfigurationDto> result = new List<AppSettingConfigurationDto>();
            result = (from Con in this._AppDBContext.EmpConfiguration
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

        /// <summary>
        /// 取得個人設定檔
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr(string Nobr)
        {

            List<AppSettingConfigurationDto> result = new List<AppSettingConfigurationDto>();


            
            result = (from Con in this._AppDBContext.EmpConfiguration
                      where Con.Nobr == Nobr
                      select new AppSettingConfigurationDto
                      {
                          AutoKey = Con.AutoKey,
                          SettingValue = Con.SettingValue,
                          SettingItem = Con.SettingItem,
                          KeyMan = Con.KeyMan,
                          KeyDate = Con.KeyDate,
                          Note = ""
                      }).ToList();
            return result;

        }


        /*不需要distinct 
         * select * from  
         *tolist () 
         * appdbsetting 
         * 
         *  
         * 
         * 
         */
        /* 有加班滿3小時 給500
         * 0x00567d096a736f33bf78cad7b01e33463923b9c933ee13ab7e3fb7b23f5f953a
         * 
         * 
         * 
         * 
         * 
         */
    }
}
