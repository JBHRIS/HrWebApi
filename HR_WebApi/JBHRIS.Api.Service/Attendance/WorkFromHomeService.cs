using HR_WebApi.Controllers.Attendance;
using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance.WorkFromHome;

namespace JBHRIS.Api.Service.Attendance
{
    public class WorkFromHomeService : IWorkFromHomeService
    {
        /// <summary>
        /// 線上打卡代碼
        /// </summary>
        private List<string> WebCardWhiteList = new List<string>()
        {
            "Web"
        };
        /// <summary>
        /// 公司卡機代碼(暫定)
        /// </summary>
        private List<string> WftAttendCardWhiteList = new List<string>()
        {
            "138",
            "139",
            "140"
        };
        private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private IAttCardService _attCardService;
        private IDiversionGroupService _diversionGroupService;
        private IDiversionShiftService _diversionShiftService;
        private IDiversionAttendTypeService _diversionAttendTypeService;
        private ITransCardService _transCardService;
        private IWorkLogService _workLogService;
        private ITemperoturyReportService _temperoturyReportService;
        public WorkFromHomeService(IAttend_View_GetAttendRote attend_View_GetAttendRote,
            IAttCardService attCardService,
            IDiversionGroupService diversionGroupService,
            IDiversionShiftService diversionShiftService,
            IDiversionAttendTypeService diversionAttendTypeService,
            ITransCardService transCardService,
            IWorkLogService workLogService,
            ITemperoturyReportService temperoturyReportService)
        {
            _attend_View_GetAttendRote = attend_View_GetAttendRote;
            _attCardService = attCardService;
            _diversionGroupService = diversionGroupService;
            _diversionShiftService = diversionShiftService;
            _diversionAttendTypeService = diversionAttendTypeService;
            _transCardService = transCardService;
            _workLogService = workLogService;
            _temperoturyReportService = temperoturyReportService;
        }

        public ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry)
        {
            return _diversionGroupService.GetDiversionGroup(getDiversionGroupEntry);
        }

        public ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry)
        {
            return _diversionShiftService.GetDiversionShift(getDiversionShiftEntry);
        }

        public ApiResult<List<DiversionShiftAttendReportDto>> GetDiversionShiftAttendReport(GetDiversionShiftAttendReportEntry getDiversionShiftAttendReportEntry)
        {
            ApiResult<List<DiversionShiftAttendReportDto>> apiResult = new ApiResult<List<DiversionShiftAttendReportDto>>();
            apiResult.State = false;
            try
            {
                List<DiversionShiftAttendReportDto> diversionShiftAttendReportDtos = new List<DiversionShiftAttendReportDto>();
                AttendanceEntry attendanceEntry = new AttendanceEntry() { EmployeeList = getDiversionShiftAttendReportEntry.EmployeeList, DateBegin = getDiversionShiftAttendReportEntry.DateBegin.Date, DateEnd = getDiversionShiftAttendReportEntry.DateEnd.Date };
                List<AttentRoteViewDto> attentRoteViewDtos = _attend_View_GetAttendRote.GetAttendRoteView(attendanceEntry);
                List<AttendCardDto> attendCardDtos = _attCardService.GetAttendCard(attendanceEntry);
                GetDiversionGroupEntry getDiversionGroupEntry = new GetDiversionGroupEntry() { EmployeeList = getDiversionShiftAttendReportEntry.EmployeeList, DateBegin = getDiversionShiftAttendReportEntry.DateBegin.Date, DateEnd = getDiversionShiftAttendReportEntry.DateEnd.Date };
                ApiResult<List<DiversionGroupDto>> apiResultDiversionGroups = GetDiversionGroup(getDiversionGroupEntry);

                diversionShiftAttendReportDtos = GetAttentRoteDiversionGroup(attentRoteViewDtos, attendCardDtos, apiResultDiversionGroups);
                diversionShiftAttendReportDtos = GetAttentRoteDiversionAttendType(diversionShiftAttendReportDtos);

                TransCardEntry transCardEntry = new TransCardEntry() { EmployeeList = getDiversionShiftAttendReportEntry.EmployeeList, StartDate = getDiversionShiftAttendReportEntry.DateBegin.Date, EndDate = getDiversionShiftAttendReportEntry.DateEnd.Date };
                List<AttendRangeCardDto> attendRangeCardDtos = _transCardService.GetAttendRangeCard(transCardEntry);
                GetWorkLogEntry getWorkLogEntry = new GetWorkLogEntry() { EmployeeList = getDiversionShiftAttendReportEntry.EmployeeList, DateBegin = getDiversionShiftAttendReportEntry.DateBegin.Date, DateEnd = getDiversionShiftAttendReportEntry.DateEnd.Date };
                ApiResult<List<WorkLogDto>> apiResultWorkLogs = _workLogService.GetWorkLog(getWorkLogEntry);
                List<WorkLogDto> workLogs = new List<WorkLogDto>();
                if (apiResultWorkLogs.State) workLogs = apiResultWorkLogs.Result; else workLogs = null;
                GetTemperoturyReportEntry getTemperoturyReportEntry = new GetTemperoturyReportEntry() { EmployeeList = getDiversionShiftAttendReportEntry.EmployeeList, DateBegin = getDiversionShiftAttendReportEntry.DateBegin.Date, DateEnd = getDiversionShiftAttendReportEntry.DateEnd.Date };
                ApiResult<List<TemperoturyReportDto>> apiResultTemperoturyReports = _temperoturyReportService.GetTemperoturyReport(getTemperoturyReportEntry);
                List<TemperoturyReportDto> temperoturyReports = new List<TemperoturyReportDto>();
                if (apiResultTemperoturyReports.State) temperoturyReports = apiResultTemperoturyReports.Result; else temperoturyReports = null;
                diversionShiftAttendReportDtos = AttendErrorList(diversionShiftAttendReportDtos, attendRangeCardDtos, workLogs, temperoturyReports);

                apiResult.Result = diversionShiftAttendReportDtos;
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        private List<DiversionShiftAttendReportDto> GetAttentRoteDiversionGroup(List<AttentRoteViewDto> attentRoteViewDtos, List<AttendCardDto> attendCardDtos, ApiResult<List<DiversionGroupDto>> apiResultDiversionGroups)
        {
            List<DiversionShiftAttendReportDto> diversionShiftAttendReportDtos = new List<DiversionShiftAttendReportDto>();

            foreach (var atr in attentRoteViewDtos)
            {
                string CardOnTime = null;
                string CardOffTime = null;
                if (attendCardDtos != null)
                {
                    AttendCardDto attendCardDto = attendCardDtos.Find(a => (atr.AttendDate == a.PuchInDate) && (atr.EmployeeId == a.EmployeeID));
                    if (attendCardDto != null)
                    {
                        CardOnTime = attendCardDto.PuchInOnTime;
                        CardOffTime = attendCardDto.PuchInOffTime;
                    }
                }

                string WorkLocation = null;
                string DiversionGroupType = null;
                if (apiResultDiversionGroups.State)
                {
                    DiversionGroupDto diversionGroupDto = apiResultDiversionGroups.Result.Find(a => (atr.EmployeeId == a.EmployeeId) && (atr.AttendDate >= a.BeginDate && atr.AttendDate <= a.EndDate));
                    if (diversionGroupDto != null)
                    {
                        WorkLocation = diversionGroupDto.WorkLocation;
                        DiversionGroupType = diversionGroupDto.DiversionGroupType;
                    }
                }

                DiversionShiftAttendReportDto diversionShiftAttendReportDto = new DiversionShiftAttendReportDto()
                {
                    EmployeeId = atr.EmployeeId,
                    EmployeeName = atr.EmployeeName,
                    AttendDate = atr.AttendDate,
                    Rote = atr.RoteCode,
                    RoteName = atr.RoteName,
                    CardOnTime = CardOnTime,
                    CardOffTime = CardOffTime,
                    Location = WorkLocation,
                    DiversionGroup = DiversionGroupType,
                    DiversionGroupName = null,
                    DiversionAttendType = null,
                    DiversionAttendTypeName = null,
                    AttendErrorList = null
                };
                diversionShiftAttendReportDtos.Add(diversionShiftAttendReportDto);
            }
            return diversionShiftAttendReportDtos;
        }
        private List<DiversionShiftAttendReportDto> GetAttentRoteDiversionAttendType(List<DiversionShiftAttendReportDto> diversionShiftAttendReportDtos)
        {
            if (diversionShiftAttendReportDtos.Count > 0)
            {
                var DiversionGroupList = diversionShiftAttendReportDtos.GroupBy(d => d.DiversionGroup).Select(d => d.FirstOrDefault() != null ? d.FirstOrDefault().DiversionGroup : null).ToList();
                diversionShiftAttendReportDtos = diversionShiftAttendReportDtos.OrderBy(d => d.AttendDate).ToList();
                GetDiversionShiftEntry getDiversionShiftEntry = new GetDiversionShiftEntry()
                {
                    DiversionGroupList = DiversionGroupList,
                    DateBegin = diversionShiftAttendReportDtos[0].AttendDate,
                    DateEnd = diversionShiftAttendReportDtos[diversionShiftAttendReportDtos.Count - 1].AttendDate
                };

                ApiResult<List<DiversionShiftDto>> apiResultDiversionShifts = GetDiversionShift(getDiversionShiftEntry);
                if (apiResultDiversionShifts.State)
                {
                    foreach (var d in diversionShiftAttendReportDtos)
                    {
                        DiversionShiftDto diversionShiftDto = apiResultDiversionShifts.Result.Find(a => (d.DiversionGroup == a.DiversionGroup) && (d.AttendDate == a.AttendDate));
                        if (diversionShiftDto != null)
                        {
                            d.DiversionGroupName = diversionShiftDto.DiversionGroupName;
                            d.DiversionAttendType = diversionShiftDto.DiversionAttendType;
                            d.DiversionAttendTypeName = diversionShiftDto.DiversionAttendTypeName;
                        }
                    }
                }
            }
            return diversionShiftAttendReportDtos;
        }
        private bool HaveCardCode(AttendRangeCardDto attendRangeCardDto, List<string> whiteListCode)
        {
            bool haveCardCode = false;
            if (attendRangeCardDto != null)
            {
                if (attendRangeCardDto.Cards != null)
                {
                    haveCardCode = attendRangeCardDto.Cards.Find(a => whiteListCode.Contains(a.Code)) != null ? true : false;
                }
            }
            return haveCardCode;
        }
        private List<DiversionShiftAttendReportDto> AttendErrorList(List<DiversionShiftAttendReportDto> diversionShiftAttendReportDtos, List<AttendRangeCardDto> attendRangeCardDtos, List<WorkLogDto> workLogDtos, List<TemperoturyReportDto> temperoturyReportDtos)
        {
            if (diversionShiftAttendReportDtos.Count > 0)
            {
                var DiversionAttendTypeList = diversionShiftAttendReportDtos.GroupBy(d => d.DiversionAttendType).Select(d => d.FirstOrDefault() != null ? d.FirstOrDefault().DiversionAttendType : null).ToList();

                ApiResult<List<DiversionAttendTypeDto>> apiResultDiversionAttendTypes = _diversionAttendTypeService.GetDiversionAttendTypes(DiversionAttendTypeList);
                if (apiResultDiversionAttendTypes.State)
                {
                    foreach (var d in diversionShiftAttendReportDtos)
                    {
                        d.AttendErrorList = new List<string>();
                        DiversionAttendTypeDto diversionAttendType = apiResultDiversionAttendTypes.Result.Find(a => d.DiversionAttendType == a.DiversionAttendType);
                        if (diversionAttendType == null)
                        {
                            //d.AttendErrorList.Add("資料缺失");
                        }
                        else
                        {
                            if (diversionAttendType.CheckWorkLog)
                            {
                                /// NoWorkLog未填寫工作日誌
                                bool HaveWorkLog = workLogDtos.Find(a => (d.EmployeeId == a.EmployeeId) && (d.AttendDate == a.AttendDate)) != null ? true : false;

                                if (!HaveWorkLog)
                                {
                                    d.AttendErrorList.Add("未填寫工作日誌");
                                }
                            }

                            if (diversionAttendType.CheckWebCard)
                            {
                                /// NoWebCard未線上打卡
                                /// Code Web
                                AttendRangeCardDto attendRangeCardDto = attendRangeCardDtos.Find(a => (d.EmployeeId == a.EmployeeID) && (d.AttendDate == a.AttendDate));
                                bool HaveWebCard = HaveCardCode(attendRangeCardDto, WebCardWhiteList);

                                if (!HaveWebCard)
                                {
                                    d.AttendErrorList.Add("未線上打卡");
                                }
                            }

                            if (diversionAttendType.CheckTemperoturyReport)
                            {
                                /// NoTemperoturyReport未回報體溫
                                bool HaveTemperoturyReport = temperoturyReportDtos.Find(a => (d.EmployeeId == a.EmployeeId) && (d.AttendDate == a.AttendDate)) != null ? true : false;

                                if (!HaveTemperoturyReport)
                                {
                                    d.AttendErrorList.Add("未回報體溫");
                                }
                            }

                            if (diversionAttendType.CheckWfhAttend)
                            {
                                /// WFH_Attend居家工作期間進公司(需要透過CARD.CODE來判斷是公司卡機)
                                /// list string 白名單
                                AttendRangeCardDto attendRangeCardDto = attendRangeCardDtos.Find(a => (d.EmployeeId == a.EmployeeID) && (d.AttendDate == a.AttendDate));
                                bool HaveWfhAttend = HaveCardCode(attendRangeCardDto, WftAttendCardWhiteList);

                                if (!HaveWfhAttend)
                                {
                                    d.AttendErrorList.Add("居家工作期間進公司");
                                }
                            }
                        }
                    }
                }
            }

            return diversionShiftAttendReportDtos;
        }
    }
}
