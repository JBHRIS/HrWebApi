using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Entry;
using JBHRIS.Api.Dto.Salary.View;
using JBHRIS.Api.Service.Salary.Payroll;
using JBHRIS.Api.Service.Salary.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HR_Api_Demo.Controllers
{
    /// <summary>
    /// 薪資服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private ISalaryCalculationService _salaryCalculationService;
        private ISalaryViewService _salaryViewService;
        /// <summary>
        /// 
        /// </summary>
        public SalaryController(ISalaryCalculationService salaryCalculationService,
            ISalaryViewService salaryViewService)
        {
            _salaryCalculationService = salaryCalculationService;
            _salaryViewService = salaryViewService;
        }
        /// <summary>
        /// 計算薪資
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<string> Calculate()
        {
            var result = _salaryCalculationService.Calculate(new JBHRIS.Api.Dto.Salary.Payroll.SalaryCalculationEntry { ModuleTypes=new List<string> {"Test" } });
            return result;
        }

        /// <summary>
        /// 計薪年月
        /// </summary>
        /// <returns></returns>
        [Route("GetSalaryYymm")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetSalaryYymm,Admin")]
        public ApiResult<string> GetSalaryYymm(SalaryYymmEntryDto salaryYymmEntryDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _salaryViewService.GetSalaryYymm(salaryYymmEntryDto.Date, salaryYymmEntryDto.Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 判斷是否已經出勤鎖檔
        /// </summary>
        /// <returns></returns>
        [Route("IsAttendLock")]
        [HttpPost]
        [Authorize(Roles = "Salary/IsAttendLock,Admin")]
        public ApiResult<bool> IsAttendLock(IsAttendLockEntryDto isAttendLockEntryDto)
        {
            ApiResult<bool> apiResult = new ApiResult<bool>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _salaryViewService.IsAttendLock(isAttendLockEntryDto.Date, isAttendLockEntryDto.Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得計薪週期
        /// </summary>
        /// <returns></returns>
        [Route("GetSalDateCycle")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetSalDateCycle,Admin")]
        public ApiResult<GetSalDateCycleDto> GetSalDateCycle(GetSalDateCycleEntryDto getSalDateCycleEntryDto)
        {
            ApiResult<GetSalDateCycleDto> apiResult = new ApiResult<GetSalDateCycleDto>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _salaryViewService.GetSalDateCycle(getSalDateCycleEntryDto.Date, getSalDateCycleEntryDto.Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得出勤週期
        /// </summary>
        /// <returns></returns>
        [Route("GetAttDateCycle")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetAttDateCycle,Admin")]
        public ApiResult<GetAttDateCycleDto> GetAttDateCycle(GetAttDateCycleEntryDto getAttDateCycleEntryDto)
        {
            ApiResult<GetAttDateCycleDto> apiResult = new ApiResult<GetAttDateCycleDto>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _salaryViewService.GetAttDateCycle(getAttDateCycleEntryDto.Date, getAttDateCycleEntryDto.Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資鎖檔
        /// </summary>
        /// <returns></returns>
        [Route("GetSalaryLock")]
        [HttpGet]
        [Authorize(Roles = "Salary/GetSalaryLock,Admin")]
        public ApiResult<List<GetSalaryWageLockDto>> GetSalaryWageLock()
        {
            ApiResult<List<GetSalaryWageLockDto>> apiResult = new ApiResult<List<GetSalaryWageLockDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult.Result = _salaryViewService.GetSalaryWageLock(KeyMan);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得特休剩餘時數
        /// </summary>
        /// <returns></returns>
        [Route("GetAnnualLeave")]
        [HttpGet]
        [Authorize(Roles = "Salary/GetAnnualLeave,Admin")]
        public ApiResult<decimal> GetAnnualLeave(string YYMM, string Seq)
        {
            ApiResult<decimal> apiResult = new ApiResult<decimal>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult.Result = _salaryViewService.GetAnnualLeave(KeyMan, YYMM,  Seq);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message.ToString();
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 取得補休剩餘時數
        /// </summary>
        /// <returns></returns>
        [Route("GetCompensatoryLeave")]
        [HttpGet]
        [Authorize(Roles = "Salary/GetCompensatoryLeave,Admin")]
        public ApiResult<decimal> GetCompensatoryLeave(string YYMM, string Seq)
        {
            ApiResult<decimal> apiResult = new ApiResult<decimal>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult.Result = _salaryViewService.GetCompensatoryLeave(KeyMan, YYMM,  Seq);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單主檔
        /// </summary>
        /// <returns></returns>
        [Route("GetPayslipTitle")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetPayslipTitle,Admin")]
        public ApiResult<GetPayslipTitleDto> GetPayslipTitle(GetPayslipEntryDto getSalaryPayslipEntryDto)
        {
            ApiResult<GetPayslipTitleDto> apiResult = new ApiResult<GetPayslipTitleDto>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";

                if (_salaryViewService.CheckSalaryPassWord(KeyMan, getSalaryPayslipEntryDto.Password).State)
                {
                    apiResult.Result = _salaryViewService.GetPayslipTitle(KeyMan, getSalaryPayslipEntryDto.YYMM, getSalaryPayslipEntryDto.Seq);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月請假
        /// </summary>
        /// <returns></returns>
        [Route("GetAbsThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetAbsThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetAbsThisMonth(string YYMM,string Password)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, Password).State)
                {
                    apiResult.Result = _salaryViewService.GetAbsThisMonth(KeyMan, YYMM);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月加班
        /// </summary>
        /// <returns></returns>
        [Route("GetOtThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetOtThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetOtThisMonth(string YYMM,string Password)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, Password).State)
                {
                    apiResult.Result = _salaryViewService.GetOtThisMonth(KeyMan, YYMM);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月所得
        /// </summary>
        /// <returns></returns>
        [Route("GetEarningsThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetEarningsThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetEarningsThisMonth(GetPayslipEntryDto getSalaryPayslipEntryDto)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, getSalaryPayslipEntryDto.Password).State)
                {
                    apiResult.Result = _salaryViewService.GetEarningsThisMonth(KeyMan, getSalaryPayslipEntryDto.YYMM, getSalaryPayslipEntryDto.Seq);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月扣款
        /// </summary>
        /// <returns></returns>
        [Route("GetDeductionThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetDeductionThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetDeductionThisMonth(GetPayslipEntryDto getSalaryPayslipEntryDto)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, getSalaryPayslipEntryDto.Password).State)
                {
                    apiResult.Result = _salaryViewService.GetDeductionThisMonth(KeyMan, getSalaryPayslipEntryDto.YYMM, getSalaryPayslipEntryDto.Seq);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月實發薪資
        /// </summary>
        /// <returns></returns>
        [Route("GetSalaryThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetSalaryThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetSalaryThisMonth(GetPayslipEntryDto getSalaryPayslipEntryDto)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, getSalaryPayslipEntryDto.Password).State)
                {
                    apiResult.Result = _salaryViewService.GetSalaryThisMonth(KeyMan, getSalaryPayslipEntryDto.YYMM, getSalaryPayslipEntryDto.Seq);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資單-本月勞退新制
        /// </summary>
        /// <returns></returns>
        [Route("GetRetirementThisMonth")]
        [HttpPost]
        [Authorize(Roles = "Salary/GetRetirementThisMonth,Admin")]
        public ApiResult<List<BlockDetailDto>> GetRetirementThisMonth(string YYMM,string Password)
        {
            ApiResult<List<BlockDetailDto>> apiResult = new ApiResult<List<BlockDetailDto>>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                if (_salaryViewService.CheckSalaryPassWord(KeyMan, Password).State)
                {
                    apiResult.Result = _salaryViewService.GetRetirementThisMonth(KeyMan, YYMM);
                    apiResult.State = true;
                }
                else
                {
                    apiResult.Message = "薪資密碼錯誤";
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 設定薪資密碼
        /// </summary>
        /// <returns></returns>
        [Route("SetSalaryPassWord")]
        [HttpPost]
        [Authorize(Roles = "Salary/SetSalaryPassWord,Admin")]
        public ApiResult<string> SetSalaryPassWord(string password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult = _salaryViewService.SetSalaryPassWord(KeyMan, password);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 刪除薪資密碼
        /// </summary>
        /// <returns></returns>
        [Route("DeleteSalaryPassWord")]
        [HttpPost]
        [Authorize(Roles = "Salary/DeleteSalaryPassWord,Admin")]
        public ApiResult<string> DeleteSalaryPassWord(string Nobr)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult = _salaryViewService.DeleteSalaryPassWord(Nobr);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得薪資異動
        /// </summary>
        /// <returns></returns>
        [Route("GetSalaryChange")]
        [HttpGet]
        [Authorize(Roles = "Salary/GetSalaryChange,Admin")]
        public ApiResult<List<GetSalaryChangeDto>> GetSalaryChange(string Nobr, DateTime CheckDate)
        {
            return _salaryViewService.GetSalaryChange(Nobr, CheckDate);
        }

        /// <summary>
        /// 新增薪資異動
        /// </summary>
        /// <returns></returns>
        [Route("AddSalaryChange")]
        [HttpPost]
        [Authorize(Roles = "Salary/AddSalaryChange,Admin")]
        public ApiResult<string> AddSalaryChange(SalaryChangeInfoDto salaryInfo)
        {
            return _salaryViewService.AddSalaryChange(salaryInfo);
        }

        /// <summary>
        /// 新增多筆薪資異動
        /// </summary>
        /// <returns></returns>
        [Route("AddSalaryChangeList")]
        [HttpPost]
        [Authorize(Roles = "Salary/AddSalaryChangeList,Admin")]
        public ApiResult<string> AddSalaryChange(List<SalaryChangeInfoDto> salaryInfos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            try
            {
                List<ApiResult<string>> results = new List<ApiResult<string>>();
                foreach (var s in salaryInfos)
                {
                   results.Add(_salaryViewService.AddSalaryChange(s));
                }

                foreach(var r in results)
                {
                    if (!r.State)
                    {
                        apiResult.State = false;
                        apiResult.Result += r.Result;
                        apiResult.StackTrace += apiResult.StackTrace;
                    }
                }
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.Message.ToString();
                apiResult.StackTrace = ex.StackTrace.ToString();
            }
            return apiResult;
        }
    }

}