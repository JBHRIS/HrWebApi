using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.ezEngineServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CFlowManageController : ControllerBase
    {
        private ICFlowManageInterface _ICFlowManageInterface;

        public CFlowManageController(ICFlowManageInterface cFlowManageInterface)
        {
            _ICFlowManageInterface = cFlowManageInterface;
        }
        /// <summary>
        /// 流程重送(含上點重送)
        /// </summary>
        /// <returns>List int</returns>
        [HttpPost]
        [Route("FlowResubmit")]
        public ApiResult<List<int>> FlowResubmit(CFlowResubmitConditionDto cFlowResubmitConditionDto)
        {
            ApiResult<List<int>> mapiResult = new ApiResult<List<int>>();
            mapiResult.State = false;
            try
            {
                var Data = this._ICFlowManageInterface.FlowResubmit(cFlowResubmitConditionDto.lsProcessID, cFlowResubmitConditionDto.idEmp_Agent, cFlowResubmitConditionDto.bPreviousStep);
                mapiResult.Result = Data;
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
        /// <summary>
        /// 指定簽核人員
        /// </summary>
        /// <returns>List int</returns>
        [HttpPost]
        [Route("FlowSignSet")]
        public ApiResult<List<int>> FlowSignSet([FromBody] CFlowSignSetConditionDto cFlowSignSetConditionDto)
        {
            ApiResult<List<int>> mapiResult = new ApiResult<List<int>>();
            mapiResult.State = false;
            try
            {
                var Data = this._ICFlowManageInterface.FlowSignSet(cFlowSignSetConditionDto.lsProcessID, cFlowSignSetConditionDto.Man_Default, cFlowSignSetConditionDto.Man_Agent);
                mapiResult.Result = Data;
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
        /// <summary>
        /// 簽核(可駁回)
        /// </summary>
        /// <returns>List int</returns>
        [HttpPost]
        [Route("FlowSignWorkFinish")]
        public ApiResult<List<int>> FlowSignWorkFinish(CFlowSignWorkFinishDto cFlowSignWorkFinishDto)
        {
            ApiResult<List<int>> mapiResult = new ApiResult<List<int>>();
            mapiResult.State = false;
            try
            {
                var Data = this._ICFlowManageInterface.FlowSignWorkFinish(cFlowSignWorkFinishDto.lsProcessID, cFlowSignWorkFinishDto.EmpId, cFlowSignWorkFinishDto.Note, cFlowSignWorkFinishDto.Sign, cFlowSignWorkFinishDto.EmpSameUp);
                mapiResult.Result = Data;
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
        /// <summary>
        /// 簽核
        /// </summary>
        /// <returns>String</returns>
        [HttpPost]
        [Route("FlowSign")]
        public ApiResult<String> FlowSign(CFlowSignDto cFlowSignDto)
        {
            ApiResult<String> mapiResult = new ApiResult<String>();
            mapiResult.State = false;
            try
            {
                this._ICFlowManageInterface.FlowSign(cFlowSignDto.lsProcessID, cFlowSignDto.EmpId);
                mapiResult.Result = "True";
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Result = "False";
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
        /// <summary>
        /// 刪除整個流程
        /// </summary>
        /// <param name="ProcessFlowId">ProcessFlowId</param>
        /// <returns>bool</returns>
        [HttpGet]
        [Route("DeleteProcessFlow")]
        public ApiResult<bool> DeleteProcessFlow(int ProcessFlowId)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();
            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._ICFlowManageInterface.DeleteProcessFlow(ProcessFlowId);
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="State">狀態</param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>List int</returns>
        [HttpPost]
        [Route("FlowStateSet")]
        public ApiResult<List<int>> FlowStateSet(FlowStateSet cFlowStateSet)
        {
            ApiResult<List<int>> mapiResult = new ApiResult<List<int>>();
            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._ICFlowManageInterface.FlowStateSet(cFlowStateSet.lsProcessID, cFlowStateSet.State, cFlowStateSet.idEmp);
                mapiResult.State = true;

            }
            catch (Exception ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }
    }
}
