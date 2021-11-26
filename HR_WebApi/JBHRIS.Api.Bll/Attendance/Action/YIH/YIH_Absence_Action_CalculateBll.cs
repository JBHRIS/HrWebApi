using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance.Action.YIH
{
    public class YIH_Absence_Action_CalculateBll : Absence_Action_CalculateBll
    {
        public YIH_Absence_Action_CalculateBll(IConfiguration configuration) : base(configuration)
        {

        }
        public override List<CalAbsHoursDto> AbsCalculate(GetAbsenceDataDetailEntry absEntry, HcodeDto getHcode, List<AttRoteViewDto> attRoteViewDtos)
        {
            var calResults = base.AbsCalculate(absEntry, getHcode, attRoteViewDtos);
            if (calResults.Any() && calResults.Count() == 1)//只有一筆
            {
                var result = calResults.First();
                var attRoteView = attRoteViewDtos.FirstOrDefault(p => p.AttendDate == result.AtteendDate);
                if (attRoteView != null)
                {
                    if (attRoteView.RoteRestTime.Any())
                    {
                        var firstRest = attRoteView.RoteRestTime.First();
                        if (result.Unit == "小時" && absEntry.StartDateTime >= firstRest.Item1 && absEntry.StartDateTime <= firstRest.Item2 && absEntry.EndDateTime >= attRoteView.RoteOffTime)
                            //單位小時，開始時間介於第一段休息時間，結束時間等於下班時間
                        {
                            result.TotHours = 4;
                        }
                        else if (result.Unit == "小時" && absEntry.EndDateTime >= firstRest.Item1 && absEntry.EndDateTime <= firstRest.Item2 && absEntry.StartDateTime <= attRoteView.RoteOnTime)
                        //單位小時，結束時間介於第一段休息時間，開始時間等於上班時間
                        {
                            result.TotHours = 4;
                        }
                    }
                }
            }
            return calResults;
        }
    }
}
