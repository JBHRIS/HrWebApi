using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.JBHR.Repository;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetAbsBalance: IAbsence_Normal_GetAbsBalance
    {
        private IUnitOfWork _unitOfWork;
        public Absence_Normal_GetAbsBalance(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceBalanceEntry absenceEntryDto)
        {
            var result = new List<AbsenceBalanceDto>();

            foreach (var empList in absenceEntryDto.EmployeeList.Split(1000))
            {
                var AbsEffectData = from abs in _unitOfWork.Repository<Abs>().Reads()
                                    join h in _unitOfWork.Repository<Hcode>().Reads() on abs.HCode equals h.HCode1
                                    where empList.Contains(abs.Nobr)
                                    && h.Flag == "+"
                                    && absenceEntryDto.HtypeList.Contains(h.Htype)
                                    && (absenceEntryDto.EffectDate >= abs.Bdate && absenceEntryDto.EffectDate <= abs.Edate)
                                    select new AbsenceBalanceDto
                                    {
                                        EmployeeId = abs.Nobr,
                                        Bdate = abs.Bdate,
                                        Edate = abs.Edate,
                                        Btime = abs.Btime,
                                        Etime = abs.Etime,
                                        Balance = abs.Balance,
                                        Hcode = abs.HCode,
                                        Htype = h.Htype,
                                        Unit = h.Unit,
                                        Flag = h.Flag,
                                        LeaveHours = abs.LeaveHours,
                                        Tolhours = abs.TolHours,
                                        Yymm = abs.Yymm,
                                        Guid = abs.Guid
                                    };
                result.AddRange(AbsEffectData);
            }
            return result.ToList();
        }
    }
}
