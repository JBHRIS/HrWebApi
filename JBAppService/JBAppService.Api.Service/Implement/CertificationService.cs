using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Dto.ItemObject;
using JBAppService.Api.Service.Interface;
using System.Collections.Generic;

namespace JBAppService.Api.Service.Implement
{
    public class CertificationService : ICertificationService
    {
        private IAppSettingConfigurationHandler _appSettingConfigurationHandler;
        private IBaseHandler _baseHandler;
        private ICardAppDetailsHandler _cardAppDetailsHandler;
        private IFencePointsHandler _fencePointsHandler;
        private IPunchCardTypeHandler _punchCardTypeHandler;
        private IEmpConfigurationHandler _IEmpConfigurationHandler;

        public CertificationService(
            IAppSettingConfigurationHandler appSettingConfigurationHandler,
            IBaseHandler baseHandler,
            ICardAppDetailsHandler cardAppDetailsHandler,
            IEmpConfigurationHandler empConfigurationHandler,
            IFencePointsHandler fencePointsHandler,
            IPunchCardTypeHandler punchCardTypeHandler
            )
        {
            this._appSettingConfigurationHandler = appSettingConfigurationHandler;
            this._baseHandler = baseHandler;
            this._cardAppDetailsHandler = cardAppDetailsHandler;
            this._IEmpConfigurationHandler = empConfigurationHandler;
            this._fencePointsHandler = fencePointsHandler;
            this._punchCardTypeHandler = punchCardTypeHandler;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<AppSettingConfigurationDto> GetAppSettingConfiguration()
        {
            return this._appSettingConfigurationHandler.GetAppSettingConfiguration();
        }

        /// <summary>
        /// Polygon圍籬
        /// </summary>
        /// <returns></returns>
        public List<PointsGroupDto> GetFencePoints()
        {
            return this._fencePointsHandler.GetFencePoints();
        }

        /// <summary>
        /// Circle圍籬
        /// </summary>
        /// <returns></returns>
        public List<PointDto> GetCircleFence()
        {
            return this._fencePointsHandler.GetCircleFence();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<ItemObject> GetPunchCardType()
        {
            return this._punchCardTypeHandler.GetPunchCardType();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public BaseInfoDto GetUserInfo(string Nobr)
        {
            return this._baseHandler.GetBaseInfo(Nobr);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="latitudeCur"></param>
        /// <param name="longitudeCur"></param>
        /// <returns></returns>
        public bool isInPolygon(double latitudeCur, double longitudeCur)
        {
            return this._fencePointsHandler.isInPolygon(latitudeCur, longitudeCur);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        public int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code)
        {
            return this._cardAppDetailsHandler.SaveCardDetails(Dto, NotTran, Code);
        }

        /// <summary>
        /// 依照工號取得個人設定檔
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public List<AppSettingConfigurationDto> GetEmpConfigurationAll_by_Nobr(string Nobr)
        {
            return this._IEmpConfigurationHandler.GetEmpConfigurationAll_by_Nobr(Nobr);
        }
    }
}