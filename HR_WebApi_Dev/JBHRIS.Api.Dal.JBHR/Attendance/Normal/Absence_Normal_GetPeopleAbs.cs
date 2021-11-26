using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetPeopleAbs : IAbsence_Normal_GetPeopleAbs
    {
        private IUnitOfWork _unitOfWork;

        public Absence_Normal_GetPeopleAbs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<string> GetPeopleAbs(AbsenceEntryDto absenceEntryDto)
        {
            var abscRepo = _unitOfWork.Repository<Absc>();
            List<string> result = new List<string>();
            foreach (var emp in absenceEntryDto.employeeList.Split(1000))
            {
                result.AddRange(abscRepo.Reads(p => emp.Contains(p.Nobr) && absenceEntryDto.HcodeList.Contains(p.HCode)
                 && absenceEntryDto.DateBegin >= p.Bdate && p.Bdate <= absenceEntryDto.DateEnd)
                      .Select(p => p.Nobr).Distinct().ToList());
            }
            return result.Distinct().ToList();
        }
    }
}
