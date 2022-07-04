using Autofac;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Bll.Attendance.Action;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Module.Absence;
using JBHRIS.Api.Service.Salary.View;
using JBHRIS.Api.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbsenceCalculateService : IAbsenceCalculateService
    {
        private string ErrorMessage_CheckRemainHours = "剩餘時數不足";
        private string ErrorMessage_CheckAbsRepeat = "請假資料重複";
        private string ErrorMessage_CheckAbsSex = "假別性別";
        private IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo;
        private IAbsence_Normal_GetHcode _absence_Normal_GetHcode;
        private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private IAbsenceTakenRepository _absenceTakenRepository;
        private IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance;
        private IAttend_View_GetAbsenceTakenView _attend_View_GetAbsenceTakenView;
        private IAttend_Abs_Absd_CompositeDal _attend_Abs_Absd_CompositeDal;
        private IAbsence_Action_CalculateBll _absence_Action_CalculateBll;
        private ISalaryViewService _salaryViewService;
        private IConfiguration _configuration;
        private IContainer _container;

        public AbsenceCalculateService(IAbsence_Normal_GetHcode absence_Normal_GetHcode
            , IAbsence_Normal_GetAbsBalance absence_Normal_GetAbsBalance
            , IEmployee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo
            , IAttend_View_GetAbsenceTakenView attend_View_GetAbsenceTakenView
            , IAttend_View_GetAttendRote attend_View_GetAttendRote
            , IAttend_Abs_Absd_CompositeDal attend_Abs_Absd_CompositeDal
            , IAbsenceTakenRepository absenceTakenRepository
            , IAbsence_Action_CalculateBll absence_Action_CalculateBll
            , ISalaryViewService salaryViewService
            , IConfiguration configuration
            , IContainer container
            )
        {
            _employee_Normal_GetEmployeeInfo = employee_Normal_GetEmployeeInfo;
            _absence_Normal_GetHcode = absence_Normal_GetHcode;
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _absenceTakenRepository = absenceTakenRepository;
            _absence_Normal_GetAbsBalance = absence_Normal_GetAbsBalance;
            _attend_View_GetAbsenceTakenView = attend_View_GetAbsenceTakenView;
            _attend_Abs_Absd_CompositeDal = attend_Abs_Absd_CompositeDal;
            _absence_Action_CalculateBll = absence_Action_CalculateBll;
            _salaryViewService = salaryViewService;
            _configuration = configuration;
            _container = container;
        }
        #region 計算請假
        public ApiResult<List<CalAbsHoursDto>> GetAbsenceDataDetail(GetAbsenceDataDetailEntry absEntry)
        {
            var cal = CalAbsHours(absEntry);
            //if (_configuration["AbsenceDataDetail:Path"] == "")
            //{
            //    //半年
            //}
            //else
            //{

            //}
            return cal;
        }

        public ApiResult<List<CalAbsHoursDto>> CalAbsHours(GetAbsenceDataDetailEntry absEntry)
        {
            ApiResult<List<CalAbsHoursDto>> apiResult = new ApiResult<List<CalAbsHoursDto>>();
            apiResult.State = false;

            var getHcode = _absence_Normal_GetHcode.GetHcodeById(absEntry.HCode);
            bool inCludeHoliday = getHcode.InHoli;
            List<AttRoteViewDto> attRoteViewDtos = new List<AttRoteViewDto>();
            var StartDateTime = absEntry.StartDateTime.Date.AddDays(-1);
            var EndDateTime = absEntry.EndDateTime.Date.AddDays(1);
            List<string> EmployeeIds = new List<string>() { absEntry.Nobr };

            if (inCludeHoliday)
            {
                attRoteViewDtos = _attend_View_GetAttendRote.GetAttRoteH(EmployeeIds, StartDateTime, EndDateTime);
            }
            else
            {
                attRoteViewDtos = _attend_View_GetAttendRote.GetAttRote(EmployeeIds, StartDateTime, EndDateTime);
            }

            List<CalAbsHoursDto> absCalculateResult = _absence_Action_CalculateBll.AbsCalculate(absEntry, getHcode, attRoteViewDtos);
            apiResult.Result = absCalculateResult;

            apiResult.State = true;
            return apiResult;
        }

        public ApiResult<List<string>> CheckAbsenceDataDetail(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos)
        {
            //初始化
            ApiResult<List<string>> result = new ApiResult<List<string>>();
            result.Result = new List<string>();
            result.State = true;
            var conf = _configuration.Get<ConfigurationDto>();
            //Dal取得資料
            var hcode = _absence_Normal_GetHcode.GetHcodeById(calAbsHoursDtos.First().HCode);
            //取得模組套件
            var absenceCheckList = conf.GetModules<IAbsenceCheckModule>("AbsenceCheck", _container);
            //運行模組
            foreach (var chk in absenceCheckList)
            {
                var r = chk.Check(calAbsHoursDtos, hcode);
                if (!r.State)
                    result.State = false;

                result.Result.AddRange(r.Result);

                if (r.Message != null && r.Message.Trim().Length > 0)
                    result.Message += r.Message + Environment.NewLine;
            }

            return result;
        }

        public ApiResult<string> AbsenceDataSave(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos)
        {
            //初始化
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;

            //檢核資料
            ApiResult<List<string>> apiResult_CheckAbsenceDataDetail = CheckAbsenceDataDetail(user, calAbsHoursDtos);

            //如果檢核通過
            if (apiResult_CheckAbsenceDataDetail.State)
            {
                ApiResult<List<AbsBalanceOffsetViewDto>> offset = AbsBalanceOffset(user, calAbsHoursDtos);
                if (offset.State)
                {
                    offset.Result.ForEach(o =>
                    {
                        apiResult = _attend_Abs_Absd_CompositeDal.Insert(o);
                        ////Update Abs Less Balance(use hours ),Add leavehours (use hours )
                        //_attend_View_GetAbsenceTakenView.UpdateAbsenceBalanceLeavehoursView(o.absdDto.Absadd, o.absdDto.Usehour);
                        ////Insert Abs
                        //_attend_View_GetAbsenceTakenView.InsertAbsenceTakenView(o.absDto);
                        ////Insert Absd
                        //_attend_View_GetAbsenceTakenView.InsertAbsenceOffsetView(o.absdDto);
                    });
                }
                else
                {
                    apiResult.Message = offset.Message;
                }
            }
            else
            {
                apiResult.Message = apiResult_CheckAbsenceDataDetail.Message;
            }

            return apiResult;
        }

        public ApiResult<List<AbsBalanceOffsetViewDto>> AbsBalanceOffset(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos)
        {

            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            ApiResult<List<AbsBalanceOffsetViewDto>> apiResult = new ApiResult<List<AbsBalanceOffsetViewDto>>();
            apiResult.State = false;
            List<AbsenceBalanceDto> absenceBalanceDtos = new List<AbsenceBalanceDto>();

            foreach (var keyval in calAbsHoursDtos)
            {
                AbsenceBalanceEntry absenceEntryDto = new AbsenceBalanceEntry
                {
                    EmployeeList = new List<string>() { keyval.Nobr },
                    HtypeList = new List<string>() { keyval.HType },
                    EffectDate = keyval.AtteendDate
                };

                var absBalance = _absence_Normal_GetAbsBalance.GetAbsBalance(absenceEntryDto);
                absBalance.ForEach(abs =>
                {
                    absenceBalanceDtos.Add(abs);
                });
            }

            var AbsBalanceGroup = absenceBalanceDtos.Distinct(x => new
            {
                EmployeeId = x.EmployeeId,
                Bdate = x.Bdate,
                Edate = x.Edate,
                Btime = x.Btime,
                Etime = x.Etime,
                Hcode = x.Hcode,
                Htype = x.Htype,
                Unit = x.Unit,
                Flag = x.Flag,
                Tolhours = x.Tolhours,
                Balance = x.Balance,
                LeaveHours = x.LeaveHours,
                Yymm = x.Yymm
            }).OrderBy(p => p.Edate).ThenBy(x => x.Bdate).ToList();

            bool haveBalance = true; //得假剩餘時數充足
            List<AbsBalanceOffsetViewDto> absBalanceOffsetViews = new List<AbsBalanceOffsetViewDto>();
            foreach (var keyval in calAbsHoursDtos)
            {
                decimal totLessPlus = 0;
                var a = 0;
                bool calTotHours = true;
                for (int k = 0; k < AbsBalanceGroup.Count; k = a)
                {
                    var absB = AbsBalanceGroup[k];
                    a = a + 1;
                    if (keyval.AtteendDate >= absB.Bdate && keyval.AtteendDate <= absB.Edate)
                    {
                        decimal useHours = 0;
                        if (calTotHours)
                        {
                            useHours = keyval.TotHours + totLessPlus;
                        }
                        else
                        {
                            useHours = totLessPlus;
                        }

                        var b = absB.Balance - useHours;
                        if (b >= 0)
                        {
                            var AbssubtractGuid = Guid.NewGuid().ToString();
                            AbsBalanceOffsetViewDto offsetViewDto = new AbsBalanceOffsetViewDto
                            {
                                absdDto = new AbsdDto
                                {
                                    Absadd = absB.Guid,
                                    Abssubtract = AbssubtractGuid,
                                    Usehour = useHours,
                                    KeyDate = DateTime.Now,
                                    KeyMan = userInfo.UserId != null ? userInfo.UserId : "",
                                },
                                absDto = new AbsDto()
                                {
                                    Guid = AbssubtractGuid,
                                    Nobr = keyval.Nobr,
                                    Bdate = keyval.AtteendDate,
                                    Edate = keyval.AtteendDate,
                                    Btime = keyval.OnTime,
                                    Etime = keyval.OffTime,
                                    HCode = keyval.HCode,
                                    TolHours = keyval.TotHours,
                                    Serno = keyval.Serno,
                                    Syscreate = keyval.Syscreate,
                                    AName = keyval.AName,
                                    KeyDate = DateTime.Now,
                                    KeyMan = userInfo.UserId != null ? userInfo.UserId : "",
                                    Yymm = _salaryViewService.GetSalaryYymm(DateTime.Now, keyval.Nobr)
                                }
                            };
                            absBalanceOffsetViews.Add(offsetViewDto);
                            absB.Balance = b;
                            totLessPlus = 0;
                            break;
                        }
                        else
                        {
                            a = 0;
                            AbsBalanceGroup.Remove(AbsBalanceGroup[k]);
                            calTotHours = false;
                            totLessPlus = (decimal)(0 - b);
                        }
                    }
                }

                if (totLessPlus > 0)
                {
                    haveBalance = false;
                    apiResult.Message = ErrorMessage_CheckRemainHours + "：" + keyval.AtteendDate.ToString("yyyy/MM/dd") + "使用" + keyval.TotHours;
                    break;
                }
            }

            if (haveBalance)
            {
                apiResult.State = true;
                apiResult.Result = absBalanceOffsetViews;
            }

            return apiResult;
        }

        public ApiResult<List<AbsBalanceOffsetViewDto>> CheckRemainHours(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos)
        {
            var absBalanceOffset = AbsBalanceOffset(user, calAbsHoursDtos);
            return absBalanceOffset;
        }

        public ApiResult<string> CheckAbsRepeat(List<CalAbsHoursDto> calAbsHoursDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            List<CalAbsHoursDetailDto> CalAbsHoursDetails = new List<CalAbsHoursDetailDto>();
            foreach (var c in calAbsHoursDtos)
            {
                foreach (var cd in c.CalAbsHoursDetails)
                {
                    CalAbsHoursDetails.Add(cd);
                }
            }

            foreach (var c in CalAbsHoursDetails)
            {

                AbsenceEntry absenceEntryDto = new AbsenceEntry
                {
                    EmployeeList = new List<string>() { c.Nobr },
                    DateBegin = c.ADate,
                    DateEnd = c.ADate,
                    HcodeList = new List<string>() { c.HCode }
                };

                var absTaken = _absenceTakenRepository.GetAbsenceTaken(absenceEntryDto);

                foreach (var abs in absTaken)
                {
                    var absDateTimeB = abs.BeginDate.AddTime(abs.BeginTime);
                    var absDateTimeE = abs.EndDate.AddTime(abs.EndTime);
                    if (c.StartDateTime >= absDateTimeB && c.EndDateTime <= absDateTimeE)
                    {
                        apiResult.State = false;
                        apiResult.Message = ErrorMessage_CheckAbsRepeat;
                        break;
                    }
                }
            }
            return apiResult;
        }

        public ApiResult<string> CheckAbsSex(List<CalAbsHoursDto> calAbsHoursDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            foreach (var c in calAbsHoursDtos)
            {
                var getHcode = _absence_Normal_GetHcode.GetHcodeById(c.HCode);
                var Emp = _employee_Normal_GetEmployeeInfo.GetEmployeeInfo(new List<string>() { c.Nobr }).FirstOrDefault();
                if (getHcode.Sex == null || getHcode.Sex.Trim().Length == 0)
                {
                }
                else if (Emp.Sex != getHcode.Sex.Trim())
                {
                    apiResult.State = false;
                    apiResult.Message = ErrorMessage_CheckAbsSex;
                    break;
                }
            }
            return apiResult;
        }
        #endregion
    }
}
