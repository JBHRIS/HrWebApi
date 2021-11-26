using JBHR.Att.Attendance.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBHR.Att.Attendance
{
    public class WorkScheduleCheckGenerator
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public WorkScheduleCheckEntry WSCE = new WorkScheduleCheckEntry();
        public WorkScheduleCheckDto WSCD = new WorkScheduleCheckDto();
        public List<string> ErrologMsg = new List<string>();
        public int Interval = 11;
        public WorkScheduleCheckResult Result = new WorkScheduleCheckResult();
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        bool CW7SW = true;
        bool CITSW = true;
        public WorkScheduleCheckGenerator(string nobr, DateTime startDate, DateTime beginCheckDate, DateTime endCheckDate)
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM23", MainForm.COMPANY);
            CW7SW = AppConfig.GetConfig("CW7SW").GetString("True") == "True";
            CITSW = AppConfig.GetConfig("CITSW").GetString("True") == "True";

            WSCE.workScheduleCheck = WSCD;
            WSCD.ScheduleTypes = new List<ScheduleTypeDto>();
            WSCD.WorkSchedules = new List<WorkScheduleDto>();

            DateTime FirstMonth = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime LastMonth = new DateTime(endCheckDate.Year, endCheckDate.Month, 1);

            if (CW7SW || CITSW)
            {
                foreach (var item in db.ROTE)
                    WSCD.ScheduleTypes.Add(NewSTD(item));

                for (DateTime i = FirstMonth; i <= LastMonth; i = i.AddMonths(1))
                {
                    string Msg = "";
                    string YYMM = i.Year.ToString("0000") + i.Month.ToString("00");
                    var TMTABLE = db.TMTABLE.Where(p => p.NOBR == nobr && p.YYMM == YYMM);
                    if (TMTABLE.Any())
                    {
                        DataRow dataRow = TMTABLE.CopyToDataTable().Rows[0];
                        foreach (DataColumn dc in dataRow.Table.Columns)
                        {
                            if (dc.ColumnName.CompareTo("D1") >= 0 && dc.ColumnName.CompareTo("D99") <= 0)
                            {
                                DateTime DT = i.AddDays(int.Parse(dc.ColumnName.Remove(0, 1)) - 1);
                                if (WSCD.ScheduleTypes.Where(p => p.Code == dataRow[dc.ColumnName].ToString()).Any())
                                    WSCD.WorkSchedules.Add(NewWSD(DT, dataRow[dc.ColumnName].ToString()));
                                else
                                    Msg += string.Format("{0} 班別資料空白或異常", DT.ToString("yyyy/MM/dd"));
                            }
                        }
                    }
                    if (Msg.Trim().Length > 0)
                        ErrologMsg.Add(Msg);
                } 
            }
            WSCD.StartDate = startDate;
            WSCD.BeginCheckDate = beginCheckDate;
            WSCD.EndCheckDate = endCheckDate;
        }

        public WorkScheduleCheckResult Check()
        {
            Result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (WSCE.CheckTypes.Contains("CIT") && CITSW)
            {
                Result.workScheduleIssues.AddRange(CITCheck("CIT", WSCE.workScheduleCheck).workScheduleIssues);
            }
            if (WSCE.CheckTypes.Contains("CW7") && CW7SW)
            {
                Result.workScheduleIssues.AddRange(CW7Check("CW7", WSCE.workScheduleCheck).workScheduleIssues);
            }
            return Result;
        }

        public WorkScheduleCheckResult CITCheck(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (workScheduleCheck == null)
            {
                result.State = false;
                result.workScheduleIssues.Add(new WorkScheduleIssueDto
                {
                    IssueDate = DateTime.Now,
                    CheckType = CheckType,
                    ErrorCode = "CIT",
                    ErrorMessage = string.Format("未填入班表資料."),
                });
                return result;
            }
            workScheduleCheck.WorkSchedules = workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).ToList();

            TimeSpan interval = new TimeSpan();
            for (int i = 0; i < workScheduleCheck.WorkSchedules.Count; i++)
            {
                WorkScheduleDto work = workScheduleCheck.WorkSchedules[i];
                ScheduleTypeDto stype = workScheduleCheck.ScheduleTypes.Where(p => p.Code == work.ScheduleType).FirstOrDefault();
                WorkScheduleDto prework = new WorkScheduleDto();//= workScheduleCheck.WorkSchedules[i - 1];
                if (i > 0 && workScheduleCheck.WorkSchedules[i - 1].AttendanceDate.AddDays(1) == work.AttendanceDate)
                    prework = workScheduleCheck.WorkSchedules[i - 1];

                if (stype != null && work.AttendanceDate >= workScheduleCheck.StartDate)
                {
                    if (stype.AttenType == "00" || stype.AttenType == "0X" || stype.AttenType == "0Z")
                        interval += new TimeSpan(24, 0, 0);
                    else
                    {
                        interval += String48HRtoTimespan(stype.OnTime);//stype.OnTime;
                        if (prework != null)
                        {
                            if ((decimal)interval.TotalHours < stype.Interval
                                && work.AttendanceDate >= workScheduleCheck.BeginCheckDate && work.AttendanceDate <= workScheduleCheck.EndCheckDate)
                            {
                                result.State = false;
                                result.workScheduleIssues.Add(new WorkScheduleIssueDto
                                {
                                    IssueDate = work.AttendanceDate,
                                    CheckType = CheckType,
                                    ErrorCode = "CIT",
                                    ErrorMessage = string.Format("日期{0}班別{1}與前一日排班的間隔低於{2}小時.", work.AttendanceDate.ToString("yyyy-MM-dd"), stype.Code, stype.Interval),
                                });
                            }
                        }
                        interval = new TimeSpan(24, 0, 0) - String48HRtoTimespan(stype.OffTime); ;//stype.OffTime;
                    }
                }
            }

            return result;
        }

        int ContinouslyWorkingDaysSet = 7;
        string workDayAttendType = "";
        //public ILogger _logger;
        public WorkScheduleCheckResult CW7Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (workScheduleCheck == null)
            {
                result.State = false;
                //_logger.Warn("workScheduleCheck未設定");
                return result;
            }
            var ContinouslyWorkingDays = 0;
            foreach (var WorkSchedule in workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).Where(p => p.AttendanceDate >= workScheduleCheck.StartDate))
            {
                ContinouslyWorkingDays++;

                var scheduleType = workScheduleCheck.ScheduleTypes.SingleOrDefault(p => p.Code == WorkSchedule.ScheduleType);
                if (scheduleType != null && scheduleType.AttenType.Trim() != workDayAttendType)
                {
                    ContinouslyWorkingDays = 0;
                }

                if (ContinouslyWorkingDays >= ContinouslyWorkingDaysSet
                    && WorkSchedule.AttendanceDate >= workScheduleCheck.BeginCheckDate && WorkSchedule.AttendanceDate <= workScheduleCheck.EndCheckDate)
                {
                    result.State = false;
                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
                    {
                        IssueDate = WorkSchedule.AttendanceDate,
                        CheckType = CheckType,
                        ErrorCode = "CW7",
                        ErrorMessage = string.Format("{0}已連續工作第{1}天.", WorkSchedule.AttendanceDate.ToString("yyyy-MM-dd"), ContinouslyWorkingDays),
                    });
                }
            }
            return result;
        }

        private TimeSpan String48HRtoTimespan(string TimeString)
        {
            int result = 0;
            TimeSpan timeSpan = new TimeSpan();
            if (int.TryParse(TimeString, out result))
            {
                timeSpan = new TimeSpan(result / 100, result % 100, 0);
            }
            return timeSpan;
        }


        public static ScheduleTypeDto NewSTD(JBModule.Data.Linq.ROTE rote)
        {
            ScheduleTypeDto STD = new ScheduleTypeDto();
            STD.Code = rote.ROTE1;
            if (rote.ROTE1 == "00" || rote.ROTE1 == "0X" || rote.ROTE1 == "0Z")
                STD.AttenType = rote.ROTE1;
            else
                STD.AttenType = "";
            STD.Interval = 11;//排班間隔
            STD.OnTime = rote.ON_TIME;// != "" ? new TimeSpan(int.Parse(rote.ON_TIME.Substring(0, 2)), int.Parse(rote.ON_TIME.Substring(2, 2)), 0) : new TimeSpan(0, 0, 0);
            STD.OffTime = rote.OFF_TIME;// != "" ? new TimeSpan(int.Parse(rote.OFF_TIME.Substring(0, 2)), int.Parse(rote.OFF_TIME.Substring(2, 2)), 0) : new TimeSpan(0, 0, 0);
            return STD;
        }

        public static WorkScheduleDto NewWSD(DateTime AttendanceDate, string ScheduleType)
        {
            WorkScheduleDto WSD = new WorkScheduleDto();
            WSD.AttendanceDate = AttendanceDate;
            WSD.ScheduleType = ScheduleType;
            return WSD;
        }
    }
}
