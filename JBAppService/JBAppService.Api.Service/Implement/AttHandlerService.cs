using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class AttHandlerService : IAttHandlerService
    {


        private IAttEndHandler _IAttEndHandler;

        public AttHandlerService(IAttEndHandler attEndHandler)
        {
            this._IAttEndHandler = attEndHandler;
        }


        public List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            return this._IAttEndHandler.GetAttEndDetail( Nobr,  BDate,  EDate,  PageRow = 20,  PageNumber = 1);
        }
    }
}
