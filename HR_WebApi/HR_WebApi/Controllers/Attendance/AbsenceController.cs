using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Absence.View;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Dto.Hunya;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 請假服務
    /// </summary>
    /// <description>
    /// 請假服務的輔助說明
    /// </description>
    /// <remarks>測試123</remarks>    
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private IAbsenceService _absenceService;
        private IAbsenceCalculateService _absenceCalculateService;
        private ILogger _logger;
        /// <summary>
        /// 請假控制器
        /// </summary>
        /// <param name="absenceService">請假服務</param>
        /// <param name="logger"></param>
        public AbsenceController(IAbsenceService absenceService,IAbsenceCalculateService absenceCalculateService,ILogger logger)
        {
            _absenceService = absenceService;
            _absenceCalculateService = absenceCalculateService;
            _logger = logger;
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns>產生的結果</returns>
        /// <remarks>請假服務的輔助說明</remarks>  
        [Route("GetAbsenceTaken")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsenceTaken,Admin")]
        public ApiResult<List<AbsenceTakenDto>> GetAbsenceTaken(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceTaken");
            ApiResult<List<AbsenceTakenDto>> apiResult = new ApiResult<List<AbsenceTakenDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsenceTaken(absenceEntryDto);
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceCancel")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsenceCancel,Admin")]
        public ApiResult<List<AbsenceCancelDto>> GetAbsenceCancel(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceCancel");
            ApiResult<List<AbsenceCancelDto>> apiResult = new ApiResult<List<AbsenceCancelDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsenceCancel(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得剩餘時數
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsBalance")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsBalance,Admin")]
        public ApiResult<List<AbsenceBalanceDto>> GetAbsBalance(AbsenceBalanceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsBalance");
            ApiResult<List<AbsenceBalanceDto>> apiResult = new ApiResult<List<AbsenceBalanceDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsBalance(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 請假名單
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetPeopleAbs")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetPeopleAbs,Admin")]
        public ApiResult<List<string>> GetPeopleAbs(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetPeopleAbs");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetPeopleAbs(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcode")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetHcode,Admin")]
        public ApiResult<List<HcodeDto>> GetHcode()
        {
            _logger.Info("開始呼叫AbsenceService.GetHcode");
            ApiResult<List<HcodeDto>> apiResult = new ApiResult<List<HcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcode();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得假別類別
        /// </summary>
        /// <returns></returns>
        [Route("GetHcodeTypes")]
        [HttpGet]
        [Authorize(Roles = "Absence/GetHcodeTypes,Admin")]
        public ApiResult<List<HcodeTypeDto>> GetHcodeTypes()
        {
            _logger.Info("開始呼叫AbsenceService.GetHcodeTypes");
            ApiResult<List<HcodeTypeDto>> apiResult = new ApiResult<List<HcodeTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcodeTypes();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得請假類別假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcodeTypesByHcode")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetHcodeTypesByHcode,Admin")]
        public ApiResult<List<HcodeDto>> GetHcodeTypesByHcode(HcodeTypesByHcodeEntry hcodeTypesByHcodeEntry)
        {
            _logger.Info("開始呼叫AbsenceService.GetHcodeTypes");
            ApiResult<List<HcodeDto>> apiResult = new ApiResult<List<HcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcodeTypesByHcode(hcodeTypesByHcodeEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 產生請假明細
        /// </summary>
        [Route("GetAbsenceDataDetail")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsenceDataDetail,Admin")]
        public ApiResult<List<CalAbsHoursDto>> GetAbsenceDataDetail(GetAbsenceDataDetailEntry getAbsenceDataDetailEntry)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceDataDetail");
            ApiResult<List<CalAbsHoursDto>> apiResult = _absenceCalculateService.GetAbsenceDataDetail(getAbsenceDataDetailEntry);
            return apiResult;
        }

        /// <summary>
        ///檢查請假明細
        /// </summary>
        [Route("CheckAbsenceDataDetail")]
        [HttpPost]
        [Authorize(Roles = "Absence/CheckAbsenceDataDetail,Admin")]
        public ApiResult<List<string>> CheckAbsenceDataDetail(List<CalAbsHoursDto> calAbsHoursDtos)
        {
            _logger.Info("開始呼叫AbsenceService.CheckAbsenceDataDetail");
            ApiResult<List<string>> apiResult = _absenceCalculateService.CheckAbsenceDataDetail(User,calAbsHoursDtos);
            return apiResult;
        }

        /// <summary>
        /// 請假存入
        /// </summary>
        [Route("AbsenceDataSave")]
        [HttpPost]
        [Authorize(Roles = "Absence/AbsenceDataSave,Admin")]
        public ApiResult<string> AbsenceDataSave(List<CalAbsHoursDto> calAbsHoursDtos)
        {
            _logger.Info("開始呼叫AbsenceService.AbsenceDataSave");
            ApiResult<string> apiResult = _absenceCalculateService.AbsenceDataSave(User,calAbsHoursDtos);
            return apiResult;
        }

        /// <summary>
        /// 請假存入(宏亞)
        /// </summary>
        [Route("HunyaAbsenceDataSave")]
        [HttpPost]
        [Authorize(Roles = "Absence/HunyaAbsenceDataSave,Admin")]
        public async Task<LoginResponseDto> HunyaAbsenceDataSave(HunyaAbsenceDataSaveEntry hunyaAbsenceDataSaveEntry)
        {
            try
            {
                #region 登入取得sessionID
                var urlLogin = "http://mestest.hunya.com/cooperation";
                LoginRequestDto loginRequestDto = new LoginRequestDto()
                {
                    key = "hunya00xxP@ssw0rd",
                    user = "hr"
                };
                var jsonLogin = JsonConvert.SerializeObject(loginRequestDto);
                HttpClient clientLogin = new HttpClient();
                HttpContent contentLogin = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
                var responseLogin = await clientLogin.PostAsync(urlLogin, contentLogin);
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(await responseLogin.Content.ReadAsStringAsync());
                #endregion

                #region 用session ID呼叫API傳入請假資料
                var url = "http://mestest.hunya.com/dbcmd";
                UserLeaveRequestDto userLeaveDto = new UserLeaveRequestDto()
                {
                    sessionid = loginResponseDto.sessionid,
                    cmd = "hr_user_leave",
                    工號 = hunyaAbsenceDataSaveEntry.Nobr,
                    請假起始 = hunyaAbsenceDataSaveEntry.AtteendDate.Date.AddTime(hunyaAbsenceDataSaveEntry.OnTime).ToString("yyyy-MM-dd HH:mm"),
                    請假結束 = hunyaAbsenceDataSaveEntry.AtteendDate.Date.AddTime(hunyaAbsenceDataSaveEntry.OffTime).ToString("yyyy-MM-dd HH:mm")
                };
                var jsonLeave = JsonConvert.SerializeObject(userLeaveDto);
                HttpClient clientLeave = new HttpClient();
                HttpContent contentLeave = new StringContent(jsonLeave, Encoding.UTF8, "application/json");
                var responseLeave = await clientLeave.PostAsync(url, contentLeave);
                #endregion
                LoginResponseDto leaveResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(await responseLeave.Content.ReadAsStringAsync());
                if (!leaveResponseDto.pass)
                {
                    _logger.Info("AbsenceService.HunyaAbsenceDataSave錯誤：" + JsonConvert.SerializeObject(url));
                    _logger.Info("AbsenceService.HunyaAbsenceDataSave錯誤：" + JsonConvert.SerializeObject(userLeaveDto));
                }
                return leaveResponseDto;
            }
            catch (Exception ex)
            {
                var err = new LoginResponseDto()
                {
                    pass = false,
                    sessionid = ex.Message.ToString()
                };
                _logger.Info("AbsenceService.HunyaAbsenceDataSave錯誤："+ex.Message.ToString());
                return err;
            }
        }
    }
}