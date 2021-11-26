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
    public class AbsenceTakenRepository : IAbsenceTakenRepository
    {
        private IUnitOfWork _unitOfWork;
        public AbsenceTakenRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        public List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntry absenceEntryDto)
        {
            var result = new List<AbsenceTakenDto>();
            foreach (var item in absenceEntryDto.EmployeeList.Split(2100))
            {
              var AbsencesTakenByEntry = from abs in _unitOfWork.Repository<Abs>().Reads()
                                         join b in _unitOfWork.Repository<Base>().Reads() on abs.Nobr equals b.Nobr
                                         join h in _unitOfWork.Repository<Hcode>().Reads() on abs.HCode equals h.HCode1
                                         where item.Contains(abs.Nobr)
                                         && ( absenceEntryDto.HcodeList.Count > 0 ? absenceEntryDto.HcodeList.Contains(h.HCode1) : true)
                                         && h.Flag == "-" 
                                         && abs.Bdate >= absenceEntryDto.DateBegin && abs.Bdate <= absenceEntryDto.DateEnd 
                                         select new AbsenceTakenDto
                                         {
                                             EmployeeID = abs.Nobr,
                                             EmployeeName = b.NameC,
                                             HolidayCode = h.HCodeDisp,
                                             HolidayName = h.HName,
                                             BeginDate = abs.Bdate,
                                             EndDate = abs.Edate,
                                             BeginTime = abs.Btime,
                                             EndTime = abs.Etime,
                                             AbsenceAmount = abs.TolHours,
                                             AbsenceUnit = h.Unit
                                         };
                result.AddRange(AbsencesTakenByEntry);
            }
            return result.ToList();
        }
    }
}
