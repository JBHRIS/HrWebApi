using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class ShiftChangeService : IShiftChangeService
    {
        private IRoteChangeRepository _roteChangeRepository;
        private IShiftChange_Normal_CheckDayShiftChange _shiftChange_Normal_CheckDayShiftChange;
        private IShiftChange_Normal_SaveDayShiftChange _shiftChange_Normal_SaveDayShiftChange;
        private ILogger _logger;
        public ShiftChangeService(IRoteChangeRepository roteChangeService
            , IShiftChange_Normal_CheckDayShiftChange shiftChange_Normal_CheckDayShiftChange
            , IShiftChange_Normal_SaveDayShiftChange shiftChange_Normal_SaveDayShiftChange
            , ILogger logger
            )
        {
            _roteChangeRepository = roteChangeService;
            _shiftChange_Normal_CheckDayShiftChange = shiftChange_Normal_CheckDayShiftChange;
            _shiftChange_Normal_SaveDayShiftChange = shiftChange_Normal_SaveDayShiftChange;
            _logger = logger;
        }

        public ApiResult<string> CheckDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto)
        {
            return _shiftChange_Normal_CheckDayShiftChange.CheckDayShiftChange(dayShiftChangeApplyDto);
        }


        public ApiResult<string> SaveDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto)
        {
            return _shiftChange_Normal_SaveDayShiftChange.SaveDayShiftChange(dayShiftChangeApplyDto);
        }
    }
}
