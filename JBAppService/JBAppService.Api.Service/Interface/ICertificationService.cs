using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface ICertificationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ItemObject> GetPunchCardType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AppSettingConfigurationDto> GetAppSettingConfiguration();

        /// <summary>
        /// polygon圍籬
        /// </summary>
        /// <returns></returns>
        List<PointsGroupDto> GetFencePoints();


        /// <summary>
        /// polygon圍籬
        /// </summary>
        /// <returns></returns>
        List<PointDto> GetCircleFence();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitudeCur"></param>
        /// <param name="longitudeCur"></param>
        /// <returns></returns>
        bool isInPolygon(double latitudeCur, double longitudeCur);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        BaseInfoDto GetUserInfo(string Nobr);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code);


        /// <summary>
        /// 依照工號取得個人設定檔
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr(string Nobr);

    }
}
