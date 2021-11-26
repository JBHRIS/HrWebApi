using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetAbsenceTaken : IAbsence_Normal_GetAbsenceTaken
    {
        private IUnitOfWork _unitOfWork;

        public Absence_Normal_GetAbsenceTaken(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntryDto absenceEntryDto)
        {
            var abscRepo = _unitOfWork.Repository<Absc>();
            List<AbsenceTakenDto> result = new List<AbsenceTakenDto>();
            foreach (var emp in absenceEntryDto.employeeList.Split(1000))
            {
                result.AddRange(abscRepo.Reads(p => emp.Contains(p.Nobr) && absenceEntryDto.HcodeList.Contains(p.HCode)
                 && absenceEntryDto.DateBegin >= p.Bdate && p.Bdate <= absenceEntryDto.DateEnd)
                      .Select(p => new AbsenceTakenDto
                      {
                          EmployeeId = p.Nobr,
                          AbsenceDate = p.Bdate,
                          BeginTime = p.Btime,
                          EndTime = p.Etime,
                          Hcode = p.HCode,
                          Remark = p.Note,
                          Taken = p.TolHours,
                          Guid = p.Guid,
                          CreateMan = p.KeyMan,
                          CreateTime = p.KeyDate,
                          YYMM = p.Yymm
                      }).ToList());
            }
            return result;
        }
    }
}
