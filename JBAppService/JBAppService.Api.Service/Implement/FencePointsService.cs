using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class FencePointsService : IFencePointsService
    {

        private IFencePointsHandler _IFencePointsHandler;

        public FencePointsService(IFencePointsHandler fencePointsHandler)
        {
            this._IFencePointsHandler = fencePointsHandler;
        }

        public List<PointsGroupDto> GetFencePoints()
        {
            return this._IFencePointsHandler.GetFencePoints();
        }

        public List<FencePointsDto> GetFencePointsList()
        {
            return this._IFencePointsHandler.GetFencePointsList();

        }

        public bool isInPolygon(double latitudeCur, double longitudeCur)
        {
			//matic 0.512
            return false;
        }

    }
}
