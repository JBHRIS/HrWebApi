using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IFencePointsHandler
    {
        /// <summary>
        /// Polygon圍籬
        /// </summary>
        /// <returns></returns>
        List<PointsGroupDto> GetFencePoints();

        /// <summary>
        /// Circle圍籬
        /// </summary>
        /// <returns></returns>
        List<PointDto> GetCircleFence();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<FencePointsDto> GetFencePointsList();


        /// <summary>
        /// 判斷是否在圍籬內
        /// </summary>
        /// <param name="latitudeCur"></param>
        /// <param name="longitudeCur"></param>
        /// <returns></returns>
        bool isInPolygon(double latitudeCur, double longitudeCur);
    }
}
