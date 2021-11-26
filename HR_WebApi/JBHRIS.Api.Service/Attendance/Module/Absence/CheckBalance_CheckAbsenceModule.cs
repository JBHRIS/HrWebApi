using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Salary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Absence
{
    public class CheckBalance_CheckAbsenceModule : IAbsenceCheckModule
    {
        private IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance;
        private ISalaryViewService _salaryViewService;

        public CheckBalance_CheckAbsenceModule(IAbsence_Normal_GetAbsBalance absence_Normal_GetAbsBalance, ISalaryViewService salaryViewService)
        {
            _absence_Normal_GetAbsBalance = absence_Normal_GetAbsBalance;
            _salaryViewService = salaryViewService;
        }

        private string ErrorMessage_CheckRemainHours = "剩餘時數不足";

        public ApiResult<List<string>> Check(List<CalAbsHoursDto> calAbsHoursDtos, HcodeDto hcodeDto)
        {
            //UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            apiResult.Result = new List<string>();
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
                    if (!absenceBalanceDtos.Any(p => p.Guid == abs.Guid))
                        absenceBalanceDtos.Add(abs);
                });
            }

            var AbsBalanceGroup = absenceBalanceDtos.OrderBy(p => p.Edate).ThenBy(x => x.Bdate).ToList();

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
                                    KeyMan = "",
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
                                    KeyMan = "",
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
                    apiResult.Message = ErrorMessage_CheckRemainHours ;
                    apiResult.Result.Add(ErrorMessage_CheckRemainHours + "：" + keyval.AtteendDate.ToString("yyyy/MM/dd") + "使用" + keyval.TotHours);
                    break;
                }
            }

            if (haveBalance)
            {
                apiResult.State = true;
                //apiResult.Result = "";
            }

            return apiResult;
        }
    }
}
