using HR_WebApi.Api.Dto;
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
    public class Absence_Normal_GetAbsBalance : IAbsence_Normal_GetAbsBalance
    {
        private IUnitOfWork _unitOfWork;

        public Absence_Normal_GetAbsBalance(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntryDto absenceEntryDto)
        {
            var absRepo = _unitOfWork.Repository<Abs>();
            var hcodeRepo = _unitOfWork.Repository<Hcode>();
            var hcodeData = hcodeRepo.Reads(p => p.Flag == "+").Select(p => p.HCode1).ToList();
            List<AbsenceBalanceDto> result = new List<AbsenceBalanceDto>();
            foreach (var emp in absenceEntryDto.employeeList.Split(1000))
            {
                result.AddRange(absRepo.Reads(p => emp.Contains(p.Nobr) && absenceEntryDto.HcodeList.Contains(p.HCode) && hcodeData.Contains(p.HCode)
                 && absenceEntryDto.DateBegin >= p.Bdate && p.Bdate <= absenceEntryDto.DateEnd)
                      .Select(p => new AbsenceBalanceDto
                      {
                          EmployeeId = p.Nobr,
                          Balance = p.Balance.GetValueOrDefault(0),
                          DateBegin = p.Bdate.Date,
                          DateEnd = p.Edate.Date,
                          Entitle = p.TolHours,
                          Hcode = p.HCode,
                          Remark = p.Note,
                          Taken = p.LeaveHours.GetValueOrDefault(0),
                          Guid = p.Guid,
                          CreateTime = p.KeyDate,
                          CreateMan = p.KeyMan
                      }).ToList());
            }
            return result;
        }
    }
}
