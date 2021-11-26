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
    public class FormsAppCardController : ControllerBase
    {

        private IFormsAppCardInterface _IFormsAppCardInterface;

        public FormsAppCardController(IFormsAppCardInterface formsAppCardInterface)
        {
            this._IFormsAppCardInterface = formsAppCardInterface;
        }

        /// <summary>
        /// 取得忘刷單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppCardByProcessId")]
        public ApiResult<CardFlowAppRow> GetFormsAppCardByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<CardFlowAppRow> mapiResult = new ApiResult<CardFlowAppRow>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppCardInterface.GetFormsAppCardByProcessId(ProcessFlowID, Sign, SignState, Status);
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
