using HR_WebApi.Helpers;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.FlowMainInte;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.FlowMainIntegrationHandler
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowMainIntegrationHandle : ControllerBase
    {

                
        private IFlowMainIntegrationHandleInterface _flowMainIntegrationHandlerService;
        private readonly JwtHelpers _jwt;

        public FlowMainIntegrationHandle(IFlowMainIntegrationHandleInterface  flowMainIntegrationHandleInterface , JwtHelpers JwtHelpers)
        {

            this._flowMainIntegrationHandlerService = flowMainIntegrationHandleInterface;
            this._jwt = JwtHelpers;
        }




        /// <summary>
        /// 取得待審核資料list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowSignRoleFullDataByNow")]
        public ApiResult<List<FlowSignRoleRow>> GetFlowSignRoleFullDataByNow([FromBody] GetFlowSignRoleDto Dto)
        {

            ApiResult<List<FlowSignRoleRow>> mapiResult = new ApiResult<List<FlowSignRoleRow>>();

            /*
             * 請參考 FlowTree 
             */
            List<string> FlowTreeID = new List<string>();
            if (Dto.FlowTreeID != null && Dto.FlowTreeID.Length != 0)
            {
                FlowTreeID.Add(Dto.FlowTreeID);
            }
            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._flowMainIntegrationHandlerService.GetFlowSignRoleFullDataByNow(Dto.SignEmpID, FlowTreeID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);
                
                mapiResult.State = true;
                mapiResult.Message = "";
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowSignRole")]
        public ApiResult<List<FlowSignRoleRow>> GetFlowSignRole([FromBody] GetFlowSignRoleDto Dto)
        {

            ApiResult<List<FlowSignRoleRow>> mapiResult = new ApiResult<List<FlowSignRoleRow>>();
            try
            {
                mapiResult.Result  = this._flowMainIntegrationHandlerService.GetFlowSignRole(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.FlowTreeID, Dto.SignDate);
                mapiResult.State = true;
                mapiResult.Message = "";
            }
            catch (Exception ex)
            {
                mapiResult.State = false ;
                mapiResult.Message = ex.Message;
            }


            return mapiResult;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowViewAbs")]
        public ApiResult<List<FlowViewAbsRow>> GetFlowViewAbs([FromBody] GetFlowViewAbsDto Dto)
        {
            ApiResult<List<FlowViewAbsRow>> mapiResult = new ApiResult<List<FlowViewAbsRow>>();

            try
            {
                mapiResult.Result = this._flowMainIntegrationHandlerService.GetFlowViewAbs(Dto.ListEmpID, Dto.DateB, Dto.DateE, Dto.FormCode, Dto.State, Dto.ProcessFlowID, Dto.Cond1, Dto.Cond2, Dto.Cond3, Dto.Handle);
                mapiResult.State = true;
                mapiResult.Message = "";


            }
            catch (Exception ex)
            {

                mapiResult.State = false;
                mapiResult.Message = ex.Message;

            }


            return mapiResult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ListFlowNodeFinish")]
        public int ListFlowNodeFinish([FromBody] List<NodeFinishRow> ListNodeFinish)
        {
            return this._flowMainIntegrationHandlerService.ListFlowNodeFinish(ListNodeFinish); 
        }

        //取得目前待審核的表單-請假
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
            [Route("GetFlowSignAbs")]
            public List<FlowSignAbsRow> GetFlowSignAbs([FromBody] FlowSignRowDto Dto)
            {
                return this._flowMainIntegrationHandlerService.GetFlowSignAbs(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);
            }

        //取得目前待審核的表單-請假(外框是總筆數)
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HttpPost]
        [Route("GetFlowSignAbsData")]
        public FlowSignAbsDataRow GetFlowSignAbsData([FromBody] FlowSignRowDto Dto)
        {
            FlowSignAbsDataRow Vdbs = new FlowSignAbsDataRow();

            List<FlowSignAbsRow> Vdb = this._flowMainIntegrationHandlerService.GetFlowSignAbs(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);

            PageCategory page = new PageCategory();
            page.PageTotalCount = (Vdb.Count() + Dto.PageRows - 1) / Dto.PageRows;
            page.pageCurrent = Dto.PageCurrent;
            page.PageRows = Dto.PageRows;

            Vdbs.Page = page;
            Vdbs.ListFlowSignAbs = Vdb.Skip((Dto.PageCurrent - 1) * Dto.PageRows).Take(Dto.PageRows).ToList();

            return Vdbs;


        }
         
        
        
        //取得目前待審核的表單-銷假
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [HttpPost]
        [Route("GetFlowSignAbsc")]
        public FlowSignAbscDataRow GetFlowSignAbsc([FromBody] FlowSignRowDto Dto)
        {
              FlowSignAbscDataRow Vdbs = new FlowSignAbscDataRow();

            





            ApiResult<List<FlowSignAbscRow>> mapiResult = new ApiResult<List<FlowSignAbscRow>>();
            try
            {
                //List<FlowSignAbscRow> Vdb = this._flowMainIntegrationHandlerService.GetFlowSignAbsc(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);

                mapiResult.Result = this._flowMainIntegrationHandlerService.GetFlowSignAbsc(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);

                PageCategory page = new PageCategory();
                page.PageTotalCount = (mapiResult.Result.Count() + Dto.PageRows - 1) / Dto.PageRows;
                page.pageCurrent = Dto.PageCurrent;
                page.PageRows = Dto.PageRows;

                Vdbs.Page = page;
                Vdbs.ListFlowSignAbsc = mapiResult.Result.Skip((Dto.PageCurrent - 1) * Dto.PageRows).Take(Dto.PageRows).ToList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {
                mapiResult.Message = ex.Message;
                mapiResult.State = false;
            }

            return Vdbs;
        }

        //取得目前待審核的表單-公出
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowSignAbs1")]
        public FlowSignAbsDataRow GetFlowSignAbs1([FromBody] FlowSignRowDto Dto)
        {
            FlowSignAbsDataRow Vdbs = new FlowSignAbsDataRow();

            List<FlowSignAbsRow> Vdb = this._flowMainIntegrationHandlerService.GetFlowSignAbs1(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate);

            PageCategory page = new PageCategory();
            page.PageTotalCount = (Vdb.Count() + Dto.PageRows - 1) / Dto.PageRows;
            page.pageCurrent = Dto.PageCurrent;
            page.PageRows = Dto.PageRows;

            Vdbs.Page = page;
            Vdbs.ListFlowSignAbs = Vdb.Skip((Dto.PageCurrent - 1) * Dto.PageRows).Take(Dto.PageRows).ToList();


            ApiResult<List<FlowViewAbsRow>> mapiResult = new ApiResult<List<FlowViewAbsRow>>();
            try
            {
                mapiResult.State = true;
            }
            catch (Exception  ex)
            {
                mapiResult.State = false;
                mapiResult.Message = ex.Message;

            }

            return Vdbs;
        }


        //取得目前待審核的表單-忘刷
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowSignCard")]
        public bool GetFlowSignCard()
        {
            bool result = false;
            return result;
        }


        //取得目前待審核的表單-調班
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RunServiceByProcessID")]
        public bool RunServiceByProcessID(int ProcessFlowID)
        {
            return this._flowMainIntegrationHandlerService.RunServiceByProcessID(ProcessFlowID);
        }


        /// <summary>
        /// 取得目前待審核的表單-加班單
        /// </summary>
        /// <param name="Dto"></param>
        [HttpPost]
        [Route("GetFlowSignOT")]
        public FlowSignOTDetail GetFlowSignOT([FromBody] FlowSignOTRowDto Dto)
        {
            return this._flowMainIntegrationHandlerService.GetFlowSignOT(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate, Dto.PageCurrent, Dto.PageRows);
        }


        /// <summary>
        /// 取得目前待審核的表單-加班單
        /// </summary>
        /// <param name="Dto"></param>
        [HttpPost]
        [Route("GetFlowSignOT1")]
        public FlowSignOTDetail GetFlowSignOT1([FromBody] FlowSignOTRowDto Dto)
        {
            return this._flowMainIntegrationHandlerService.GetFlowSignOT1(Dto.SignEmpID, Dto.SignRoleID, Dto.RealSignEmpID, Dto.RealSignRoleID, Dto.SignDate, Dto.PageCurrent, Dto.PageRows);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="NodeFinish"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FlowNodeFinish")]
        public ActionResultRow FlowNodeFinish([FromBody] NodeFinishRow NodeFinish)
        {
            var EmpID = User.Claims.FirstOrDefault(p => p.Type == "EmpID");

            NodeFinish.ManInfo = new ManInfoRow();
            NodeFinish.ManInfo.EmpID = EmpID.Value;


            ApiResult<List<FlowViewAbscRow>> mapiResult = new ApiResult<List<FlowViewAbscRow>>();
            try
            {

            }
            catch (Exception ex)
            {

                
            }

            return this._flowMainIntegrationHandlerService.FlowNodeFinish(NodeFinish);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFlowViewAbsc")]
        public ApiResult<List<FlowViewAbscRow>> GetFlowViewAbsc([FromBody] FlowViewRowDto dto)
        {
            ApiResult<List<FlowViewAbscRow>> mapiResult = new ApiResult<List<FlowViewAbscRow>>();
            try
            {
                mapiResult.Result = this._flowMainIntegrationHandlerService.GetFlowViewAbsc(dto.ListEmpID, dto.DateB, dto.DateE, dto.FormCode,dto.State, dto.ProcessFlowID, dto.Cond1, dto.Cond2, dto.Cond3, dto.Handle);
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