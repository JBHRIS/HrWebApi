using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AttendanceService : IAttendanceService
    {
        IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        ICard_Normal_GetAttCard _card_Normal_GetAttCard;
        IAbsenceService _absenceService;
        IOverTimeViewService _overTimeViewService;
        IAttend_View_Abnormal _attend_View_Abnormal;
        IAttend_Normal_InsertAttend _attend_Normal_InsertAttend;
        IAttend_Normal_UpdateAttend _attend_Normal_UpdateAttend;

        public  AttendanceService(IAttend_View_GetAttendRote attend_View_GetAttendRote,
        ICard_Normal_GetAttCard card_Normal_GetAttCard,
        IAbsenceService absenceService,
        IOverTimeViewService overTimeViewService,
        IAttend_View_Abnormal attend_View_Abnormal,
        IAttend_Normal_InsertAttend attend_Normal_InsertAttend,
        IAttend_Normal_UpdateAttend attend_Normal_UpdateAttend)
        {
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _card_Normal_GetAttCard = card_Normal_GetAttCard;
            _absenceService = absenceService;
            _overTimeViewService = overTimeViewService;
            _attend_View_Abnormal = attend_View_Abnormal;
            _attend_Normal_InsertAttend = attend_Normal_InsertAttend;
            _attend_Normal_UpdateAttend = attend_Normal_UpdateAttend;
        }

        public CheckDataHaveAttLockDto CheckDataHaveAttLock(JBHRIS.Api.Dto.Files.TmtableImportDto tmtable, List<DateTime> lockAttDateList)
        {
            CheckDataHaveAttLockDto checkDataHaveAttLockDto = new CheckDataHaveAttLockDto();
            checkDataHaveAttLockDto.haveLockData = false;
            checkDataHaveAttLockDto.ErrorMessage = "出勤鎖檔：";

            int Year = Convert.ToInt32(tmtable.Yymm.Substring(0, 4));
            int Month = Convert.ToInt32(tmtable.Yymm.Substring(4, 2));

            int monthDay = DateTime.DaysInMonth(Year, Month);
            List<DateTime> haveDataDate = new List<DateTime>();
            for (int i = 1; i <= monthDay; i++)
            {
                var valueObj = tmtable.GetType().GetProperty("D" + i.ToString()).GetValue(tmtable);
                if (valueObj != null && valueObj.ToString().Trim().Length > 0)
                {
                    haveDataDate.Add(new DateTime(Year, Month, i));
                }
            }

            for (var i = 0; i < lockAttDateList.Count; i++)
            {
                var item = lockAttDateList[i];
                for (var h = 0; h < haveDataDate.Count; h++)
                {
                    var hdata = haveDataDate[h];
                    if (DateTime.Equals(item, hdata))
                    {
                        string andTxt = (i + 1) < lockAttDateList.Count ? "、" : "。";
                        checkDataHaveAttLockDto.haveLockData = true;
                        checkDataHaveAttLockDto.ErrorMessage += "D" + hdata.Day.ToString() + andTxt;
                    }
                }
            }
            return checkDataHaveAttLockDto;
        }

        public List<AttendanceDto> GetAttendance(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public ApiResult<List<AttendanceDetailDto>> GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry)
        {
            List<AttendanceDetailDto> attendanceDetailDtos = new List<AttendanceDetailDto>();
            AttendanceEntry attendanceEntry = new AttendanceEntry() {
                EmployeeList = attendanceDetailEntry.EmployeeList,
                DateBegin = attendanceDetailEntry.DateBegin,
                DateEnd = attendanceDetailEntry.DateEnd
            };
            OverTimeSearchViewEntry overTimeSearchView = new OverTimeSearchViewEntry
            {
                EmployeeList = attendanceDetailEntry.EmployeeList,
                DateBegin = attendanceDetailEntry.DateBegin,
                DateEnd = attendanceDetailEntry.DateEnd
            };
            var attendRotes = _attend_View_GetAttendRote.GetAttendRoteView(attendanceEntry);
            var listAbnormals = _attend_View_Abnormal.GetAbnormalViewDtos(attendanceEntry);
            var attendCards = _card_Normal_GetAttCard.GetAttendCard(attendanceEntry);
            var abss = new List<AbsenceTakenDto>();
            abss = _absenceService.GetAbsenceTaken(new AbsenceEntry()
            {
                EmployeeList = attendanceEntry.EmployeeList,
                DateBegin = attendanceEntry.DateBegin,
                DateEnd = attendanceEntry.DateEnd,
                HcodeList = new List<string>()
            }); ;
            var ots = new List<OverTimeSearchViewDto>();
            ots = _overTimeViewService.GetOverTimeSearchView(overTimeSearchView).Result;

            var data = from attR in attendRotes
                       join attC in attendCards
                       on new { X1 = attR.EmployeeId, X2 = attR.AttendDate } equals new { X1 = attC.EmployeeID, X2 = attC.PuchInDate }
                       into attCGrp
                       from attCG in attCGrp.DefaultIfEmpty()
                       select new AttendanceDetailDto()
                       {
                           EmployeeId = attR.EmployeeId,
                           EmployeeName = attR.EmployeeName,
                           AttendDate = attR.AttendDate,
                           RoteCode = attR.RoteCode,
                           RoteCodeDisp = attR.RoteCodeDisp,
                           RoteName = attR.RoteName,
                           RoteDateB = attR.AttendDate.ToShortDateString(),
                           RoteDateE = attR.AttendDate.ToShortDateString(),
                           RoteTimeB = attR.RoteTimeB,
                           RoteTimeE = attR.RoteTimeE,
                           CardDateB = attCG?.PuchInDate.ToShortDateString(),
                           CardDateE = attCG?.PuchInDate.ToShortDateString(),
                           CardTimeB = attCG?.PuchInOnTime,
                           CardTimeE = attCG?.PuchInOffTime,
                           LateMin = attR.LateMin,
                           EarlyMin = attR.EarlyMin,
                           Forget = attR.Forget,
                           IsAbs = attR.IsAbs,
                           ListAbs = null,
                           ListOt = null,
                           ListAbnormal = null
                       };

            attendanceDetailDtos = data.ToList();
            attendanceDetailDtos.ForEach(d =>
            {
                d.ListAbs = new List<AbsenceTakenDto>();
                d.ListOt = new List<OverTimeSearchViewDto>();
                d.ListAbnormal = new List<CheckAbnormalDto>();
                abss.ForEach(abs =>
                {
                    if (d.AttendDate == abs.BeginDate && d.EmployeeId == abs.EmployeeID)
                    {
                        d.ListAbs.Add(abs);
                    }
                });

                ots.ForEach(ot =>
                {
                    if (d.AttendDate == ot.OverTimeDate && d.EmployeeId == ot.EmployeeID)
                    {
                        d.ListOt.Add(ot);
                    }
                });

                listAbnormals.ForEach(abno =>
                {
                    if (d.AttendDate == abno.AttendanceDate && d.EmployeeId == abno.EmployeeId)
                    {
                        CheckAbnormalDto checkAbnormalDto = new CheckAbnormalDto()
                        {
                            Type = abno.Type,
                            Name = abno.State,
                            Check = abno.IsCheck,
                            Mins = abno.ErrorMins
                        };
                        d.ListAbnormal.Add(checkAbnormalDto);
                    }
                });
            });

            ApiResult<List<AttendanceDetailDto>> attendanceDetailResultDto = new ApiResult<List<AttendanceDetailDto>>();
            attendanceDetailResultDto.Result = attendanceDetailDtos;
            attendanceDetailResultDto.State = true;

            return attendanceDetailResultDto;
        }

        public ApiResult<List<CalendarDto>> GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry)
        {
            AttendanceEntry attendanceEntry = new AttendanceEntry()
            {
                EmployeeList = attendanceCalendarEntry.EmployeeList,
                DateBegin = attendanceCalendarEntry.DateBegin,
                DateEnd = attendanceCalendarEntry.DateEnd
            };

            OverTimeSearchViewEntry overTimeSearchView = new OverTimeSearchViewEntry
            {
                EmployeeList = attendanceCalendarEntry.EmployeeList,
                DateBegin = attendanceCalendarEntry.DateBegin,
                DateEnd = attendanceCalendarEntry.DateEnd
            };

            List<CalendarDto> attendanceCalendarDtos = new List<CalendarDto>();
            if(attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Attend") || attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abnormal"))
            {
                var attendRotes = _attend_View_GetAttendRote.GetAttendRoteView(attendanceEntry);

                attendRotes.ForEach(a => {
                    if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Attend"))
                    {
                        #region 出勤
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.AttendDate,
                            CalendarType = "Attend",
                            Color = "fff",
                            BeginTime = a.RoteTimeB,
                            EndTime = a.RoteTimeE,
                            EmployeeId = a.EmployeeId,
                            Remark = null,
                            Use = a.WkHrs,
                            Name = a.RoteName,
                            Sort = 1
                        });
                        #endregion
                    }
                    if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abnormal"))
                    {
                        #region 遲到
                        if (a.LateMin > 0)
                        {
                            attendanceCalendarDtos.Add(new CalendarDto()
                            {
                                CalendarDate = a.AttendDate,
                                CalendarType = "LateMins",
                                Color = "fff",
                                BeginTime = a.RoteTimeB,
                                EndTime = a.RoteTimeE,
                                EmployeeId = a.EmployeeId,
                                Remark = null,
                                Use = a.LateMin,
                                Name = "遲到",
                                Sort = 5
                            });
                        }
                        #endregion
                        #region 早退
                        if (a.EarlyMin > 0)
                        {
                            attendanceCalendarDtos.Add(new CalendarDto()
                            {
                                CalendarDate = a.AttendDate,
                                CalendarType = "EMins",
                                Color = "fff",
                                BeginTime = a.RoteTimeB,
                                EndTime = a.RoteTimeE,
                                EmployeeId = a.EmployeeId,
                                Remark = null,
                                Use = a.EarlyMin,
                                Name = "早退",
                                Sort = 5
                            });
                        }
                        #endregion
                        #region 忘刷
                        if (a.Forget > 0)
                        {
                            attendanceCalendarDtos.Add(new CalendarDto()
                            {
                                CalendarDate = a.AttendDate,
                                CalendarType = "Forget",
                                Color = "fff",
                                BeginTime = a.RoteTimeB,
                                EndTime = a.RoteTimeE,
                                EmployeeId = a.EmployeeId,
                                Remark = null,
                                Use = 1,
                                Name = "忘刷",
                                Sort = 5
                            });
                        }
                        #endregion
                        #region 曠職
                        if (a.IsAbs)
                        {
                            attendanceCalendarDtos.Add(new CalendarDto()
                            {
                                CalendarDate = a.AttendDate,
                                CalendarType = "Absenteeism",
                                Color = "fff",
                                BeginTime = a.RoteTimeB,
                                EndTime = a.RoteTimeE,
                                EmployeeId = a.EmployeeId,
                                Remark = null,
                                Use = 0,
                                Name = "曠職",
                                Sort = 5
                            });
                        }
                        #endregion
                    }
                });
            }

            #region 刷卡
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Card"))
            {
                //刷卡
                var attendCards = _card_Normal_GetAttCard.GetAttendCard(attendanceEntry);

                attendCards.ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.PuchInDate,
                        CalendarType = "Card",
                        Color = "fff",
                        BeginTime = a.PuchInOnTime,
                        EndTime = a.PuchInOffTime,
                        EmployeeId = a.EmployeeID,
                        Remark = null,
                        Use = 0,
                        Name = "刷卡",
                        Sort = 2
                    });
                });
            }
            #endregion
            #region 請假
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abs"))
            {
                //請假
                var abss = new List<AbsenceTakenDto>();
                abss = _absenceService.GetAbsenceTaken(new AbsenceEntry()
                {
                    EmployeeList = attendanceEntry.EmployeeList,
                    DateBegin = attendanceEntry.DateBegin,
                    DateEnd = attendanceEntry.DateEnd,
                    HcodeList = new List<string>()
                }); ;

                abss.ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.BeginDate,
                        CalendarType = "Abs",
                        Color = "fff",
                        BeginTime = a.BeginTime,
                        EndTime = a.EndTime,
                        EmployeeId = a.EmployeeID,
                        Remark = a.AbsenceUnit,
                        Use = a.AbsenceAmount,
                        Name = a.HolidayName,
                        Sort = 3
                    });
                });
            }
            #endregion
            #region 加班
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Ot"))
            {
                //加班
                var ots = new List<OverTimeSearchViewDto>();
                ots = _overTimeViewService.GetOverTimeSearchView(overTimeSearchView).Result;
                ots.ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.OverTimeDate,
                        CalendarType = "Ot",
                        Color = "fff",
                        BeginTime = a.BeginTime,
                        EndTime = a.EndTime,
                        EmployeeId = a.EmployeeID,
                        Remark = null,
                        Use = a.OverTimeTotalHours,
                        Name = "加班",
                        Sort = 4
                    });
                });
            }
            #endregion
            #region 異常 ex:早來、晚走
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abnormal"))
            {
                var listAbnormals = new List<AbnormalViewDto>();
                listAbnormals = _attend_View_Abnormal.GetAbnormalViewDtos(attendanceEntry);

                listAbnormals.ForEach(a =>
                {
                    if (!a.IsCheck)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.AttendanceDate,
                            CalendarType = a.Type,
                            Color = "fff",
                            BeginTime = a.ActualOnTime,
                            EndTime = a.ActualOffTime,
                            EmployeeId = a.EmployeeId,
                            Remark = null,
                            Use = a.ErrorMins,
                            Name = a.State,
                            Sort = 5
                        });
                    }
                });
            }
            #endregion
            ApiResult<List<CalendarDto>> calendarResultDto = new ApiResult<List<CalendarDto>>();
            calendarResultDto.Result = attendanceCalendarDtos;
            calendarResultDto.State = true;

            return calendarResultDto;
        }

        public List<string> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public List<string> GetPeopleWork(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public List<RoteDto> GetRote(string RoteCode)
        {
            return _attend_View_GetAttendRote.GetRote(RoteCode);
        }

        public List<RoteChangeDto> GetRoteChange(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public ApiResult<string> InsertAttend(List<AttendDto> attendanceDtos)
        {
            return _attend_Normal_InsertAttend.InsertAttend(attendanceDtos);
        }

        public ApiResult<string> UpdateAttend(List<AttendDto> attendanceDtos)
        {
            return _attend_Normal_UpdateAttend.UpdateAttend(attendanceDtos);
        }

        public ApiResult<string> UpdateAttendRote(UpdateAttendRoteEntry updateAttendRoteEntry,string keyman)
        {
            return _attend_View_GetAttendRote.UpdateAttendRote(updateAttendRoteEntry, keyman);
        }
    }
}
