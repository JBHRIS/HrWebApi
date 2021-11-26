using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public class Absence_Action_CalculateBll : IAbsence_Action_CalculateBll
    {
        private IConfiguration _configuration;

        public Absence_Action_CalculateBll(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public virtual List<CalAbsHoursDto> AbsCalculate(GetAbsenceDataDetailEntry absEntry, HcodeDto getHcode, List<AttRoteViewDto> attRoteViewDtos)
        {
            List<Tuple<DateTime, DateTime>> _attendanceRote = new List<Tuple<DateTime, DateTime>>();
            List<Tuple<DateTime, DateTime>> _restList = new List<Tuple<DateTime, DateTime>>();
            Tuple<DateTime, DateTime> _userWrite = new Tuple<DateTime, DateTime>(absEntry.StartDateTime, absEntry.EndDateTime);
            attRoteViewDtos.ForEach(attR =>
            {
                _attendanceRote.Add(new Tuple<DateTime, DateTime>(attR.RoteOnTime, attR.RoteOffTime));
                _restList.AddRange(attR.RoteRestTime);
            });

            List<Tuple<DateTime, DateTime>> realAbsTimePeriod = DataTransform.GetRealAbsTimePeriod(_attendanceRote, _restList, _userWrite);
            List<CalAbsHoursDetailDto> absenceDataDeatilDtos = new List<CalAbsHoursDetailDto>();
            //var config = _configuration.Get<ConfigurationDto>();
            List<string> unitDayString = _configuration.GetSection("HcodeUnitString:Day").Get<string[]>().ToList();
            List<string> unitHourString = _configuration.GetSection("HcodeUnitString:Hour").Get<string[]>().ToList();
            List<string> unitMinuteString = _configuration.GetSection("HcodeUnitString:Minute").Get<string[]>().ToList();
            decimal RealTotHours = 0;
            for (var w = 0; w < realAbsTimePeriod.Count; w++)
            {
                var rel = realAbsTimePeriod[w];
                DateTime calEndDateTime = rel.Item2;
                var attRote = attRoteViewDtos.Where(p => rel.Item1 >= p.RoteOnTime && rel.Item2 <= p.RoteOffTime).FirstOrDefault();

                var TotalMinutes = (decimal)(rel.Item2.Subtract(rel.Item1).TotalMinutes);
                decimal Total = 0;
                if (unitDayString.Contains(getHcode.HCodeUnit.Trim()))
                {
                    Total = TotalMinutes / 60 / attRote.WorkHours;
                }
                else if (unitHourString.Contains(getHcode.HCodeUnit.Trim()))
                {
                    Total = TotalMinutes / 60;
                }
                else if (unitMinuteString.Contains(getHcode.HCodeUnit.Trim()))
                {
                    Total = TotalMinutes;
                }

                Total = Tools.NumbericConvert.RangeInterval(Total, getHcode.AbsUnit, NumbericConvert.DigitalMode.Ceiling);
                RealTotHours += Total;
                absenceDataDeatilDtos.Add(new CalAbsHoursDetailDto()
                {
                    ADate = attRote.AttendDate,
                    StartDateTime = rel.Item1,
                    EndDateTime = rel.Item2,
                    HCode = getHcode.HCode,
                    HType = getHcode.Htype,
                    Nobr = absEntry.Nobr,
                    Total = Total,
                    Unit = getHcode.HCodeUnit,
                    Che = getHcode.Che,
                    AbsUnit = getHcode.AbsUnit,
                    Minnum = getHcode.Minnum,
                    WorkHours = attRote.WorkHours
                });
            }
            IEnumerable<IGrouping<DateTime, CalAbsHoursDetailDto>> sameAbsAdates = absenceDataDeatilDtos.GroupBy(x => x.ADate);
            var Result = new List<CalAbsHoursDto>();
            foreach (IGrouping<DateTime, CalAbsHoursDetailDto> group in sameAbsAdates)
            {
                List<CalAbsHoursDetailDto> calAbsHoursDetailDtos = new List<CalAbsHoursDetailDto>();
                string Nobr = "";
                string Unit = "";
                string HCode = "";
                string Htype = "";
                decimal TotHours = 0;
                decimal WorkHours = 0;
                foreach (var g in group)
                {
                    Nobr = g.Nobr;
                    HCode = g.HCode;
                    Htype = g.HType;
                    Unit = g.Unit;
                    WorkHours = g.WorkHours;
                    TotHours += g.Total;
                    calAbsHoursDetailDtos.Add(new CalAbsHoursDetailDto
                    {
                        Nobr = g.Nobr,
                        ADate = g.ADate,
                        StartDateTime = g.StartDateTime,
                        EndDateTime = g.EndDateTime,
                        HCode = g.HCode,
                        HType = g.HType,
                        Total = g.Total,
                        Che = g.Che,
                        AbsUnit = g.AbsUnit,
                        Minnum = g.Minnum,
                        WorkHours = g.WorkHours,
                        Unit = g.Unit,
                    });
                }

                calAbsHoursDetailDtos = calAbsHoursDetailDtos.OrderByDescending(p => p.EndDateTime).ToList();
                string OffTime = calAbsHoursDetailDtos[0].EndDateTime.TimeStringBy48HR(group.Key).ToString();

                calAbsHoursDetailDtos = calAbsHoursDetailDtos.OrderBy(p => p.StartDateTime).ToList();
                string OnTime = calAbsHoursDetailDtos[0].StartDateTime.TimeStringBy48HR(group.Key).ToString();

                if (TotHours < getHcode.Minnum)
                    TotHours = getHcode.Minnum;

                if (TotHours > WorkHours)
                {
                    TotHours = WorkHours; 
                }

                Result.Add(new CalAbsHoursDto
                {
                    AtteendDate = group.Key,
                    Nobr = Nobr,
                    Unit = Unit,
                    OnTime = OnTime,
                    OffTime = OffTime,
                    TotHours = TotHours,
                    RealTotHours = RealTotHours,
                    WorkHours = WorkHours,
                    HCode = HCode,
                    HType = Htype,
                    CalAbsHoursDetails = calAbsHoursDetailDtos
                });
            }

            return Result;
        }
    }
}
