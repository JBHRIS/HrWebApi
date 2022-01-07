using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Service.Employee.Normal;
using JBHRIS.Api.Service.Employee.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_Api_Demo.Controllers
{
    /// <summary>
    /// 人事控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeInfoService _employeeService;
        private IEmployeeListService _employeeListService;
        private IEmployeeViewService _employeeViewService;
        private IEmployeeRoleService _employeeRoleService;
        private ILogger _logger;

        private IDeptViewService _deptViewService;
        private IEmployeeJobStatusService _employeeJobStatusService;
        private IJobViewService _jobViewService;
        //private IOtherCodeViewService _otherCodeViewService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="employeeService">員工基本服務</param>
        /// <param name="employeeListService">員工清單服務</param>
        /// <param name="employeeViewService">員工檢視表服務</param>
        ///// <param name="deptViewService">部門檢視表服務</param>
        ///// <param name="jobViewService">職稱檢視表服務</param>
        public EmployeeController(IEmployeeInfoService employeeService
            , IEmployeeListService employeeListService
            , IEmployeeViewService employeeViewService
            , IEmployeeRoleService employeeRoleService
            , ILogger logger
            , IDeptViewService deptViewService
            , IEmployeeJobStatusService employeeJobStatusService
            , IJobViewService jobViewService
            //,IOtherCodeViewService otherCodeViewService
            )
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
            _employeeViewService = employeeViewService;
            _employeeRoleService = employeeRoleService;
            _logger = logger;
            _deptViewService = deptViewService;
            _employeeJobStatusService = employeeJobStatusService;
            _jobViewService = jobViewService;
            //_otherCodeViewService = otherCodeViewService;
        }

        /// <summary>
        /// 取得員工到職日
        /// </summary>
        /// <returns></returns>
        [Route("GetEmployeeStartWorkDate")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetEmployeeStartWorkDate,Admin")]
        public ApiResult<DateTime?> GetEmployeeStartWorkDate(string EmployeeID)
        {
            _logger.Info("開始呼叫EmployeeJobStatusService.GetEmployeeStartWorkDate");
            return _employeeJobStatusService.GetEmployeeStartWorkDate(EmployeeID);
        }

        /// <summary>
        /// 檢查員工異動資料
        /// </summary>
        /// <returns></returns>
        [Route("CheckEmployeeJobStatusChange")]
        [HttpPost]
        [Authorize(Roles = "Employee/CheckEmployeeJobStatusChange,Admin")]
        public ApiResult<string> CheckEmployeeJobStatusChange(BasettsDto basettsDto)
        {
            _logger.Info("開始呼叫EmployeeJobStatusService.CheckChange");
            return _employeeJobStatusService.CheckEmployeeJobStatusChange(basettsDto);
        }

        /// <summary>
        /// 取得員工異動資料
        /// </summary>
        /// <returns></returns>
        [Route("GetCurrentJobStatus")]
        [HttpPost]
        [Authorize(Roles = "Employee/EmployeeJobStatusAddChange,Admin")]
        public ApiResult<BasettsDto> GetCurrentJobStatus(string Nobr,DateTime Adate)
        {
            _logger.Info("開始呼叫EmployeeJobStatusService.GetCurrentJobStatus");
            return _employeeJobStatusService.GetCurrentJobStatus(Nobr, Adate);
        }

        /// <summary>
        /// 新增員工異動
        /// </summary>
        /// <returns></returns>
        [Route("EmployeeJobStatusAddChange")]
        [HttpPost]
        [Authorize(Roles = "Employee/EmployeeJobStatusAddChange,Admin")]
        public ApiResult<string> EmployeeJobStatusAddChange(BasettsDto basettsDto)
        {
            _logger.Info("開始呼叫EmployeeJobStatusService.AddChange");
            return _employeeJobStatusService.AddChange(basettsDto);
        }

        /// <summary>
        /// 取得所有員工
        /// </summary>
        /// <returns></returns>
        [Route("GetPeople")]
        [HttpGet]
        [Authorize(Roles = "Employee/GetPeople,Admin")]
        public ApiResult<List<EmployeeViewDto>> GetPeople()
        {
            _logger.Info("開始呼叫EmployeeListService.GetPeople");
            ApiResult<List<EmployeeViewDto>> apiResult = new ApiResult<List<EmployeeViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetPeople();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得部門清單
        /// </summary>
        /// <returns></returns>
        [Route("GetAllPeopleByDept")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetAllPeopleByDept,Admin")]
        public ApiResult<List<string>> GetAllPeopleByDept(GetPeopleByDeptEntry getPeopleByDeptEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetAllPeopleByDept");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetAllPeopleByDept(getPeopleByDeptEntry.deptList, getPeopleByDeptEntry.checkDate);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得部門清單(有參考角色權限)
        /// </summary>
        /// <returns></returns>
        [Route("GetPeopleByDept")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetPeopleByDept,Admin")]
        public ApiResult<List<string>> GetPeopleByDept(GetPeopleByDeptEntry getPeopleByDeptEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleByDept");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                var employeeList = _employeeRoleService.GetAllowEmloyeeList(User);
                apiResult.Result = _employeeListService.GetPeopleByDept(employeeList, getPeopleByDeptEntry.deptList, getPeopleByDeptEntry.checkDate);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得兼職部門即期向下清單(有參考角色權限)
        /// </summary>
        /// <returns></returns>
        [Route("GetPeopleByDepartmentExtraTree")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetPeopleByDeptExtraTree,Admin")]
        public ApiResult<List<string>> GetPeopleByDeptExtraTree(GetPeopleByDeptTreeEntry peopleByDeptTreeEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleByDeptExtraTree");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                var employeeList = _employeeRoleService.GetAllowEmloyeeDeptExtraTreeList(User);
                var Nobr = User.Identity.Name;
                List<string> FilterEmpList = _employeeListService.GetPeopleByDeptTree(employeeList, peopleByDeptTreeEntry.checkDate, peopleByDeptTreeEntry.InCludeManager);
                FilterEmpList.Add(Nobr);
                apiResult.Result = FilterEmpList.Distinct().ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得部門即期向下清單(有參考角色權限)
        /// </summary>
        /// <returns></returns>
        [Route("GetPeopleByDeptTree")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetPeopleByDeptTree,Admin")]
        public ApiResult<List<string>> GetPeopleByDeptTree(GetPeopleByDeptTreeEntry peopleByDeptTreeEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleByDeptTree");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                var employeeList = _employeeRoleService.GetAllowEmloyeeDeptTreeList(User);
                var Nobr = User.Identity.Name;
                List<string> FilterEmpList = _employeeListService.GetPeopleByDeptTree(employeeList, peopleByDeptTreeEntry.checkDate, peopleByDeptTreeEntry.InCludeManager);
                FilterEmpList.Add(Nobr);
                apiResult.Result = FilterEmpList.Distinct().ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得簽核部門即期向下清單(有參考角色權限)
        /// </summary>
        /// <returns></returns>
        [Route("GetPeopleByDeptaTree")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetPeopleByDeptaTree,Admin")]
        public ApiResult<List<string>> GetPeopleByDeptaTree(GetPeopleByDeptaTreeEntry peopleByDeptaTreeEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleByDeptaTree");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                var employeeList = _employeeRoleService.GetAllowEmloyeeDeptaTreeList(User);
                var Nobr = User.Identity.Name;
                List<string> FilterEmpList = _employeeListService.GetPeopleByDeptaTree(employeeList, peopleByDeptaTreeEntry.checkDate, peopleByDeptaTreeEntry.InCludeManager);
                FilterEmpList.Add(Nobr);
                apiResult.Result = FilterEmpList.Distinct().ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得員工基本資料
        /// </summary>
        /// <param name="employeeList">工號清單</param>
        /// <returns></returns>
        [Route("GetEmployeeInfo")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetEmployeeInfo,Admin")]
        public ApiResult<List<EmployeeInfoDto>> GetEmployeeInfo(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeInfo");
            ApiResult<List<EmployeeInfoDto>> apiResult = new ApiResult<List<EmployeeInfoDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetEmployeeInfo(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得員工基本資料(前端)
        /// </summary>
        /// <remarks>
        /// ["A0003","A0017","A1423"]
        /// </remarks>
        /// <param name="employeeList">工號清單</param>
        /// <returns></returns>
        [Route("GetEmployeeInfoView")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetEmployeeInfoView,Admin")]
        public ApiResult<List<EmployeeInfoViewDto>> GetEmployeeInfoView(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeInfoView");
            ApiResult<List<EmployeeInfoViewDto>> apiResult = new ApiResult<List<EmployeeInfoViewDto>>();
            apiResult.State = false;
            try
            {
                //return photo base64string
                apiResult.Result = _employeeService.GetEmployeeInfoView(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得員工檢視表
        /// </summary>
        /// <param name="employeeList"></param>
        /// <returns></returns>
        [Route("GetEmployeeView")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetEmployeeView,Admin")]
        public ApiResult<List<EmployeeViewDto>> GetEmployeeView(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeView");
            ApiResult<List<EmployeeViewDto>> apiResult = new ApiResult<List<EmployeeViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeViewService.GetEmployeeView(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得生日名單
        /// </summary>
        /// <param name="employeeBirthdayEntry"></param>
        /// <returns></returns>
        [Route("GetPeopleBirthday")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetPeopleBirthday,Admin")]
        public ApiResult<List<string>> GetPeopleBirthday(EmployeeBirthdayEntry employeeBirthdayEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleBirthday");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetPeopleByBirthday(employeeBirthdayEntry.employeeList, employeeBirthdayEntry.months);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得考績記錄
        /// </summary>
        /// <returns></returns>
        [Route("GetEffemployView")]
        [HttpPost]
        [Authorize(Roles = "Employee/GetEffemployView,Admin")]
        public ApiResult<List<EffemployViewDto>> GetEffemployView(EffemployEntryDto effemployEntryDto)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEffemployView");
            ApiResult<List<EffemployViewDto>> apiResult = new ApiResult<List<EffemployViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetEffemployView(effemployEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得試用期人員名單
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        [Route("GetPeopleApDate")]
        [HttpGet]
        [Authorize(Roles = "Employee/GetPeopleApDate,Admin")]
        public ApiResult<List<PeopleApDateViewDto>> GetPeopleApDate(DateTime BeginDate, DateTime EndDate)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleApDate");
            ApiResult<List<PeopleApDateViewDto>> apiResult = new ApiResult<List<PeopleApDateViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetPeopleApDate(BeginDate,EndDate);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得所有試用期狀態
        /// </summary>
        /// <returns></returns>
        [Route("GetAllPassType")]
        [HttpGet]
        [Authorize(Roles = "Employee/GetAllPassType,Admin")]
        public ApiResult<List<AllPassTypeDto>> GetAllPassType()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetAllPassType");
            ApiResult<List<AllPassTypeDto>> apiResult = new ApiResult<List<AllPassTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetAllPassType();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 更新員工基本資料
        /// </summary>
        /// <returns></returns>
        [Route("UpdateEmployeeInfo")]
        [HttpPost]
        [Authorize(Roles = "Employee/UpdateEmployeeInfo,Admin")]
        public ApiResult<bool> UpdateEmployeeInfo(UpdateEmployeeInfoViewDto empInfo)
        {
            _logger.Info("開始呼叫EmployeeInfoService.UpdateEmployeeInfo");
            ApiResult<bool> apiResult = new ApiResult<bool>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.UpdateEmployeeInfo(empInfo);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得親屬關係
        /// </summary>
        /// <returns></returns>
        [Route("GetRelcodeView")]
        [HttpGet]
        [Authorize(Roles = "Employee/GetRelcodeView,Admin")]
        public ApiResult<List<RelcodeDto>> GetRelcodeView()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetRelcodeView");
            ApiResult<List<RelcodeDto>> apiResult = new ApiResult<List<RelcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetRelcodeView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得編制部門
        /// </summary>
        /// <returns></returns>
        [Route("GetDept")]
        [HttpGet]
        [Authorize(Roles = "Employee/GetDept,Admin")]
        public ApiResult<List<DeptDto>> GetDept()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetDept");
            ApiResult<List<DeptDto>> apiResult = new ApiResult<List<DeptDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _deptViewService.GetDeptView().OrderBy(p => p.DepartmentIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        ///<summary>
        /// 取得簽核部門
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepta")]
        [Authorize(Roles = "Employee/GetDepta,Admin")]
        public ApiResult<List<DeptDto>> GetDepta()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetDepta");
            ApiResult<List<DeptDto>> apiResult = new ApiResult<List<DeptDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _deptViewService.GetDeptaView().OrderBy(p => p.DepartmentIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        ///// <summary>
        ///// 取得成本部門
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetDepts")]
        //public List<DeptDto> GetDepts()
        //{
        //    return _deptViewService.GetDeptsView();
        //}

        /// <summary>
        /// 取得職稱
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJob")]
        [Authorize(Roles = "Employee/GetJob,Admin")]
        public ApiResult<List<JobDto>> GetJob()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetJob");
            ApiResult<List<JobDto>> apiResult = new ApiResult<List<JobDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _jobViewService.GetJob().OrderBy(p => p.JobIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得職類
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJobs")]
        [Authorize(Roles = "Employee/GetJobs,Admin")]
        public ApiResult<List<JobDto>> GetJobs()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetJobs");
            ApiResult<List<JobDto>> apiResult = new ApiResult<List<JobDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _jobViewService.GetJobs().OrderBy(p=>p.JobIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得職等
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJobl")]
        [Authorize(Roles = "Employee/GetJobl,Admin")]
        public ApiResult<List<JobDto>> GetJobl()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetJobl");
            ApiResult<List<JobDto>> apiResult = new ApiResult<List<JobDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _jobViewService.GetJobl().OrderBy(p => p.JobIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得職級
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJobo")]
        [Authorize(Roles = "Employee/GetJobo,Admin")]
        public ApiResult<List<JobDto>> GetJobo()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetJobo");
            ApiResult<List<JobDto>> apiResult = new ApiResult<List<JobDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _jobViewService.GetJobo().OrderBy(p => p.JobIdDisplay).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }


        /// <summary>
        /// 取得異動代碼
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTtsCode")]
        [Authorize(Roles = "Employee/GetTtsCode,Admin")]
        public ApiResult<List<TtscodeDto>> GetTtsCode()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetTtsCode");
            ApiResult<List<TtscodeDto>> apiResult = new ApiResult<List<TtscodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetTtscode().OrderBy(p => p.Sort).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得公司別代碼
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetComp")]
        [Authorize(Roles = "Employee/GetComp,Admin")]
        public ApiResult<List<CompDto>> GetComp()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetComp");
            ApiResult<List<CompDto>> apiResult = new ApiResult<List<CompDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetComp().OrderBy(p => p.Sort).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得離職原因代碼
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOutReason")]
        [Authorize(Roles = "Employee/GetOutReason,Admin")]
        public ApiResult<List<OutcdDto>> GetOutReason()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetOutReason");
            ApiResult<List<OutcdDto>> apiResult = new ApiResult<List<OutcdDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetOutReason().OrderBy(p => p.Outcd).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得異動原因代碼
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTtscd")]
        [Authorize(Roles = "Employee/GetTtscd,Admin")]
        public ApiResult<List<TtscdDto>> GetTtscd()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetTtscd");
            ApiResult<List<TtscdDto>> apiResult = new ApiResult<List<TtscdDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetTtscd().OrderBy(p => p.TtscdDisp).ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得員工特殊規則
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmployeeRule")]
        [Authorize(Roles = "Employee/GetEmployeeRule,Admin")]
        public ApiResult<List<EmployeeRuleDto>> GetEmployeeRule(EmployeeRuleEntry employeeRuleEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeRule");
            ApiResult<List<EmployeeRuleDto>> apiResult = new ApiResult<List<EmployeeRuleDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetEmployeeRule(employeeRuleEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }


        /// <summary>
        /// 取得員工基本資料(宏亞)
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="hunyaEmployeeInfoEntry">工號、時間</param>
        /// <returns></returns>
        [Route("GetHunyaEmployeeInfoView")]
        [HttpPost]
        //[Authorize(Roles = "Employee/GetHunyaEmployeeInfoView,Admin")]
        public ApiResult<List<HunyaEmployeeInfoViewDto>> GetHunyaEmployeeInfoView(HunyaEmployeeInfoEntry hunyaEmployeeInfoEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetHunyaEmployeeInfoView");
            ApiResult<List<HunyaEmployeeInfoViewDto>> apiResult = new ApiResult<List<HunyaEmployeeInfoViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetHunyaEmployeeInfoView(hunyaEmployeeInfoEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}