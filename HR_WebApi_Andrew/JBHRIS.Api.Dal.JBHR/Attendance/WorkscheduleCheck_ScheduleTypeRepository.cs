using JBHRIS.Api.Dal.Attendance;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance
{
    public class WorkscheduleCheck_ScheduleTypeRepository : IWorkscheduleCheck_ScheduleTypeRepository
    {
        private IUnitOfWork _unitOfWork;

        public WorkscheduleCheck_ScheduleTypeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ScheduleTypeDto> GetScheduleTypeList()
        {
            return _unitOfWork.Repository<Rote>().Reads().Select(p=>new {p.Rote1,p.OnTime,p.OffTime }).ToList()
                .Select(p => new ScheduleTypeDto
                {
                    AttenType = ConvertToScheduleType(p.Rote1),
                    Code = p.Rote1,
                    Interval = 24,
                    OnTime = p.OnTime,
                    OffTime = p.OffTime
                }).ToList();
        }
        string ConvertToScheduleType(string Rote)
        {
            return new string[] { "00", "0X", "0Z" }.Contains(Rote) ? Rote : "";
        }
        public Dictionary<string, List<WorkScheduleDto>> GetWorkScheduleList(WorkschedulecheckEntry workschedulecheckEntry)
        {
            var result = new Dictionary<string, List<WorkScheduleDto>>();

            var attendData = _unitOfWork.Repository<Attend>().Reads()
                .Where(p => workschedulecheckEntry.EmployeeList.Contains(p.Nobr)
                && p.Adate >= workschedulecheckEntry.DateBegin
                && p.Adate <= workschedulecheckEntry.DateEnd)
                .Select(p => new { p.Nobr, p.Adate, p.Rote, p.RoteH }).ToList().GroupBy(p => p.Nobr);
            foreach (var att in attendData)
            {
                result.Add(att.Key, att.Select(p => new WorkScheduleDto { AttendanceDate = p.Adate, ScheduleType = p.Rote }).ToList());
            }
            return result;
        }
    }
}
