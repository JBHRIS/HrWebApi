using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IFencePointsService
    {
        List<PointsGroupDto> GetFencePoints();

        List<FencePointsDto> GetFencePointsList();

        bool isInPolygon(double latitudeCur, double longitudeCur);
    }
}
