using JBHRIS.Api.Dal.Attendance.Normal;
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
        private ILogger _logger;
        public RoteChangeService(IRoteChangeRepository roteChangeService, ILogger logger)
        {
            _roteChangeRepository = roteChangeService;
            _logger = logger;
        }
        public List<RoteChangeDto> GetRoteChange(AttendanceEntry attendanceEntry)
        {
            return _roteChangeRepository.GetRoteChange(attendanceEntry);
        }
    }
}
