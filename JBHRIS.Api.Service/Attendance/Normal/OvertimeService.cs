using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class OvertimeService : IOvertimeService
    {
        //private ILogger _logger;
        private IAttend_View_GetOvertimeSearch _attend_View_GetOvertimeSearch;
        private IOvertime_Normal_GetOvertimeByDate _overtime_Normal_GetOvertimeByDate;
        //private IOvertime_Normal_GetOvertimeType _overtime_Normal_GetOvertimeType;
        //private IOvertime_Normal_GetPeopleOvertime _overtime_Normal_GetPeopleOvertime;
        private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private IEmployee_View_GetEmployee _employee_View_GetEmployee;

        //public OvertimeService(ILogger logger)
        //{
        //    _logger = logger;
        //}
        public OvertimeService(
            //ILogger logger,
            IAttend_View_GetOvertimeSearch attend_View_GetOvertimeSearch,
            IOvertime_Normal_GetOvertimeByDate overtime_Normal_GetOvertimeByDate,
            //IOvertime_Normal_GetOvertimeType overtime_Normal_GetOvertimeType,
            //IOvertime_Normal_GetPeopleOvertime overtime_Normal_GetPeopleOvertime,
            IAttend_View_GetAttendRote attend_View_GetAttendRote,
            IEmployee_View_GetEmployee employee_View_GetEmployee)
        {
            //_logger = logger;
            _attend_View_GetOvertimeSearch = attend_View_GetOvertimeSearch;
            //_overtime_Normal_GetOvertimeType = overtime_Normal_GetOvertimeType;
            //_overtime_Normal_GetPeopleOvertime = overtime_Normal_GetPeopleOvertime;
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _employee_View_GetEmployee = employee_View_GetEmployee;
            _overtime_Normal_GetOvertimeByDate = overtime_Normal_GetOvertimeByDate;
        }

        public ApiResult<OvertimeDto> CalculateOvertime(OvertimeApplyDto overtimeApplyDto)
        {
            ApiResult<OvertimeDto> apiResult = new ApiResult<OvertimeDto>();
            apiResult.State = false;
            try
            {
                List<Tuple<DateTime, DateTime>> _workTimeList = new List<Tuple<DateTime, DateTime>>();
                var Begin = overtimeApplyDto.OvertimeDate.Date.AddTime(overtimeApplyDto.BeginTime);
                var End = overtimeApplyDto.OvertimeDate.Date.AddTime(overtimeApplyDto.EndTime);
                _workTimeList.Add(new Tuple<DateTime, DateTime>(Begin, End));
                List<AttRoteViewDto> attRoteViewDtos = new List<AttRoteViewDto>();
                DateTime StartDateTime = overtimeApplyDto.OvertimeDate.AddDays(-1);
                DateTime EndDateTime = overtimeApplyDto.OvertimeDate.AddDays(1);
                List<string> EmployeeIds = new List<string>() { overtimeApplyDto.EmployeeId };
                attRoteViewDtos = _attend_View_GetAttendRote.GetAttRote(EmployeeIds, StartDateTime, EndDateTime);
                List<Tuple<DateTime, DateTime>> _AttendAndRotehRestList = new List<Tuple<DateTime, DateTime>>();
                attRoteViewDtos.ForEach(attR =>
                {
                    if(attR.RoteCode == "00" || attR.RoteCode == "0X" || attR.RoteCode == "0Z")
                    {
                        List<Tuple<DateTime, DateTime>> attRoteHsRest = new List<Tuple<DateTime, DateTime>>();
                        var attRoteHs = _attend_View_GetAttendRote.GetAttRoteH(EmployeeIds, attR.AttendDate, attR.AttendDate);
                        attRoteHs.ForEach(r =>
                        {
                            attRoteHsRest.AddRange(r.RoteRestTime);
                        });
                        _AttendAndRotehRestList.AddRange(attRoteHsRest);
                    }
                    else
                    {
                        _AttendAndRotehRestList.Add(new Tuple<DateTime, DateTime>(attR.RoteOnTime, attR.RoteOffTime));
                    }
                });

                List<Tuple<DateTime, DateTime>> GetAbsenteeismList = JBHRIS.Api.Tools.DataTransform.GetAbsenteeismList(_workTimeList, _AttendAndRotehRestList);
                decimal EmpOtMin = _employee_View_GetEmployee.GetEmployeeOtMin(overtimeApplyDto.EmployeeId);
                decimal calTotMin = 0;
                decimal calOtHour = 0;
                GetAbsenteeismList.ForEach(rel =>
                {
                    var TotalMinutes = (decimal)(rel.Item2.Subtract(rel.Item1).TotalMinutes);
                    calTotMin += TotalMinutes;

                });

                if(calTotMin > 0)
                {
                    if(EmpOtMin > 0)
                    {
                        var minute = Math.Floor(calTotMin / EmpOtMin); //間格數，無條件捨去
                        if (minute > 0)
                        {
                            //最小數
                            calOtHour = (minute * EmpOtMin) / 60;
                        }
                    }
                    else
                    {
                        calOtHour = calTotMin / 60;
                    }
                }

                OvertimeDto overtimeDto = new OvertimeDto() 
                {
                    EmployeeId = overtimeApplyDto.EmployeeId,
                    OvertimeDate = overtimeApplyDto.OvertimeDate.Date,
                    BeginTime = overtimeApplyDto.BeginTime,
                    EndTime = overtimeApplyDto.EndTime,
                    OvertimeHours = calOtHour,
                    ExpenseHours = calOtHour,
                    RestHours = 0,
                    OvertimeReason = overtimeApplyDto.OvertimeReason,
                    Remark = overtimeApplyDto.Remark
                };

                apiResult.State = true;
                apiResult.Result = overtimeDto;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> CheckOvertime(OvertimeDto overtimeDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var CheckOverTimeRepeat = _attend_View_GetOvertimeSearch.CheckOverTimeNoRepeat(overtimeDto);
            apiResult = CheckOverTimeRepeat;
            return apiResult;
        }

        public ApiResult<List<CheckOvertimeDataDto>> CheckOvertimeData(List<OvertimeByDateDto> overtimeByDateDtos)
        {
            decimal moreThenHour = 46;//加班不得超過46小時
            List<string> HolidayCodeList = new List<string>() { "00", "0Z" };//假日代碼(不含假日前八小時)

            ApiResult<List<CheckOvertimeDataDto>> apiResult = new ApiResult<List<CheckOvertimeDataDto>>();
            apiResult.State = false;
            try
            {
                AttendanceEntry attendanceEntry = new AttendanceEntry()
                {
                    EmployeeList = overtimeByDateDtos.Select(r => r.EmployeeId).Distinct().ToList(),
                    DateBegin = overtimeByDateDtos.Min(r => r.OvertimeDate.AddTime(r.BeginTime)).Date,
                    DateEnd = overtimeByDateDtos.Max(r => r.OvertimeDate.AddTime(r.EndTime)).Date
                };
                List<AttentRoteViewDto> attRoteViewDtos = _attend_View_GetAttendRote.GetAttendRoteView(attendanceEntry);
                Dictionary<string, decimal> dicEmpTotHours = new Dictionary<string, decimal>();
                foreach(var item in overtimeByDateDtos)
                {
                    decimal calOverTime = NotInHolidayHours(HolidayCodeList, attRoteViewDtos, item);//不含假日前八小時

                    decimal TotHours = 0;
                    bool haveEmp = dicEmpTotHours.TryGetValue(item.EmployeeId, out TotHours);
                    if (haveEmp)
                    {
                        TotHours += calOverTime;
                        dicEmpTotHours[item.EmployeeId] = TotHours;
                    }
                    else
                    {
                        TotHours = calOverTime;
                        dicEmpTotHours.Add(item.EmployeeId, TotHours);
                    }
                }

                var moreThenHours = dicEmpTotHours.Where(p => p.Value > moreThenHour).ToList();
                if(moreThenHours.Count == 0)
                {
                    apiResult.State = true;
                }
                else
                {
                    foreach(var item in moreThenHours)
                    {
                        apiResult.Message += item.Key + $"超過{moreThenHour}小時\n";
                    }
                }

                List<CheckOvertimeDataDto> checkOvertimeDataDtos = new List<CheckOvertimeDataDto>();
                foreach (var item in dicEmpTotHours)
                {
                    checkOvertimeDataDtos.Add(new CheckOvertimeDataDto()
                    {
                        EmployeeId = item.Key,
                        TotHours = item.Value
                    });
                }
                apiResult.Result = checkOvertimeDataDtos;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message.ToString();
                apiResult.StackTrace = ex.StackTrace.ToString();
            }
            return apiResult;
        }

        private static decimal NotInHolidayHours(List<string> HolidayCodeList, List<AttentRoteViewDto> attRoteViewDtos, OvertimeByDateDto item)
        {
            bool isHoliday = attRoteViewDtos.Where(r =>
                                                  HolidayCodeList.Contains(r.RoteCode)
                                                  && r.EmployeeId == item.EmployeeId
                                                  && r.AttendDate == item.OvertimeDate
                                            ).Count() > 0 ? true : false;
            decimal calOverTime = item.OvertimeHours;
            if (isHoliday)
            {
                //不含假日前八小時
                calOverTime = calOverTime - 8;
                if (calOverTime <= 0)
                    calOverTime = 0;
            }

            return calOverTime;
        }

        public List<OvertimeByDateDto> GetOvertimeByDate(OvertimeByDateEntry overtimeByDateEntry)
        {
            return _overtime_Normal_GetOvertimeByDate.GetOvertimeByDate(overtimeByDateEntry);
        }

        public List<OvertimeTypeDto> GetOvertimeType()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPeopleOvertime(AttendanceEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public ApiResult<string> SaveOvertime(List<OvertimeDto> overtimeDtos,string KeyMan)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            foreach (var o in overtimeDtos)
            {
                var check = CheckOvertime(o);
                apiResult = check;
                if (check.State == false)
                {
                    break;
                }
            }

            if (apiResult.State)
            {
                apiResult = _attend_View_GetOvertimeSearch.SaveOvertime(overtimeDtos, KeyMan);
            }

            return apiResult;
        }


    }
}
