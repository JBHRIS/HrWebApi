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
    public class AbsenceCancelRepository : IAbsenceCancelRepository
    {
        private IUnitOfWork _unitOfWork;
        public AbsenceCancelRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        public List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntry absenceEntryDto)
        {
            var result = new List<AbsenceCancelDto>();
            foreach (var item in absenceEntryDto.EmployeeList.Split(2100))
            {
                var AbsencesCancelByEntry = from Absc in _unitOfWork.Repository<Absc>().Reads()
                                            join b in _unitOfWork.Repository<Base>().Reads() on Absc.Nobr equals b.Nobr
                                            join h in _unitOfWork.Repository<Hcode>().Reads() on Absc.HCode equals h.HCode1
                                            where item.Contains(Absc.Nobr)
                                            && absenceEntryDto.HcodeList.Contains(h.HCodeDisp) && h.Flag == "-"
                                            && Absc.Bdate >= absenceEntryDto.DateBegin && Absc.Bdate <= absenceEntryDto.DateEnd
                                            select new AbsenceCancelDto
                                            {
                                                EmployeeID = Absc.Nobr,
                                                EmployeeName = b.NameC,
                                                HolidayCode = h.HCodeDisp,
                                                HolidayName = h.HName,
                                                BeginDate = Absc.Bdate,
                                                EndDate = Absc.Edate,
                                                BeginTime = Absc.Btime,
                                                EndTime = Absc.Etime,
                                                AbsenceAmount = Absc.TolHours,
                                                AbsenceUnit = h.Unit
                                            };
                result.AddRange(AbsencesCancelByEntry);
            }
            return result.ToList();
        }
    }
}
