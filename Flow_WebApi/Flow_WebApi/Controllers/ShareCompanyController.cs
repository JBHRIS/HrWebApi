using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareCompanyController : ControllerBase
    {

        private IShareCompanyInterFace _ShareCompanyInterface;

        public ShareCompanyController(IShareCompanyInterFace ShareCompany)
        {
            this._ShareCompanyInterface = ShareCompany;
        }

        /// <summary>
        /// 查詢Share用的公司代號及公司名稱
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetShareCompanyIdAndName")]
        public ApiResult<List<ShareCompanyVdb>> GetShareCompanyIdAndName()
        {
            ApiResult<List<ShareCompanyVdb>> mapiResult = new ApiResult<List<ShareCompanyVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._ShareCompanyInterface.GetShareCompanyIdAndName();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }







    }
}
