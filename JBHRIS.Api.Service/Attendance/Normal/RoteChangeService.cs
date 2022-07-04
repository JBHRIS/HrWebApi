using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class RoteChangeService : IRoteChangeService
    {
        private IRoteChangeRepository _roteChangeRepository;
        private IRote_Normal_CheckLongShiftChange _rote_Normal_CheckLongShiftChange;
        private IEmployee_View_EmployeeJobStatus _employee_View_EmployeeJobStatus;
        private ILogger _logger;
        public RoteChangeService(IRoteChangeRepository roteChangeService
            , IRote_Normal_CheckLongShiftChange rote_Normal_CheckLongShiftChange
            , IEmployee_View_EmployeeJobStatus employee_View_EmployeeJobStatus
            , ILogger logger
            )
        {
            _roteChangeRepository = roteChangeService;
            _rote_Normal_CheckLongShiftChange = rote_Normal_CheckLongShiftChange;
            _employee_View_EmployeeJobStatus = employee_View_EmployeeJobStatus;
            _logger = logger;
        }

        public ApiResult<string> CheckLongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto)
        {
            return _rote_Normal_CheckLongShiftChange.CheckLongShiftChange(longShiftChangeApplyDto);
        }

        public List<RoteChangeDto> GetRoteChange(AttendanceEntry attendanceEntry)
        {
            return _roteChangeRepository.GetRoteChange(attendanceEntry);
        }

        public ApiResult<string> SaveLongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto)
        {
            var longShiftBasettsDto = _employee_View_EmployeeJobStatus.GetCurrentJobStatus(longShiftChangeApplyDto.EmployeeId, longShiftChangeApplyDto.ChangeDate);

            longShiftBasettsDto.Nobr = longShiftChangeApplyDto.EmployeeId;
            longShiftBasettsDto.Adate = longShiftChangeApplyDto.ChangeDate;
            longShiftBasettsDto.Rotet = longShiftChangeApplyDto.AfterShiftGroupCode;
            longShiftBasettsDto.Ttscode = "6";

            return _employee_View_EmployeeJobStatus.AddChange(longShiftBasettsDto);
        }
    }
}
