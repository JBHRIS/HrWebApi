using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Absence
{
    public class CheckAbsRepeat_AbsenceCheckModule : IAbsenceCheckModule
    {
        private readonly IAbsenceTakenRepository _absenceTakenRepository;
        private string ErrorMessage_CheckAbsRepeat = "請假資料重複";

        public CheckAbsRepeat_AbsenceCheckModule(IAbsenceTakenRepository absenceTakenRepository)
        {
            _absenceTakenRepository = absenceTakenRepository;
        }
        public ApiResult<List<string>> Check(List<CalAbsHoursDto> calAbsHoursDtos, HcodeDto hcodeDto)
        {
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = true;
            apiResult.Message = "";
            apiResult.Result = new List<string>();

            //抓期間所有假別，有請假就是重複
            AbsenceEntry absenceEntryDto = new AbsenceEntry
            {
                EmployeeList = new List<string>() { calAbsHoursDtos.First().Nobr },
                DateBegin = calAbsHoursDtos.First().AtteendDate.AddDays(-1),
                DateEnd = calAbsHoursDtos.Last().AtteendDate.AddDays(1),
                HcodeList = new List<string>() { }//無關假別
            };
            var checkAbs = calAbsHoursDtos.Select(p => new { EmployeeID = p.Nobr, BeginTime = p.AtteendDate.AddTime(p.OnTime), EndTime = p.AtteendDate.AddTime(p.OffTime) });
            var absTaken = _absenceTakenRepository.GetAbsenceTaken(absenceEntryDto);

            foreach (var abs in absTaken)
            {
                var absDateTimeB = abs.BeginDate.AddTime(abs.BeginTime);
                var absDateTimeE = abs.EndDate.AddTime(abs.EndTime);
                var existAbs = checkAbs.Where(p => p.BeginTime < absDateTimeE && p.EndTime > absDateTimeB);
                if (existAbs.Any())
                {
                    apiResult.State = false;
                    apiResult.Message = ErrorMessage_CheckAbsRepeat;
                    apiResult.Result.Add(ErrorMessage_CheckAbsRepeat + "，日期：" + abs.BeginDate.ToString("yyyy/MM/dd"));
                }
            }

            return apiResult;
        }
    }
}
