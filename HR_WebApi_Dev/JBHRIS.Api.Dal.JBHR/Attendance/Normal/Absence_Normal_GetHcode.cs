using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetHcode : IAbsence_Normal_GetHcode
    {
        private IUnitOfWork _unitOfWork;

        public Absence_Normal_GetHcode(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<HcodeDto> GetHcode(List<string> HcodeList)
        {
            var hcodeRepo = _unitOfWork.Repository<Hcode>();
            return hcodeRepo.Reads(p => HcodeList.Contains(p.HCode1))
                .Select(p => new HcodeDto
                {
                    Hcode = p.HCodeDisp,
                    Id = p.HCode1,
                    Hname = p.HName,
                    Interval = p.Absunit,
                    IsIncludeHoliday = p.InHoli,
                    Min = p.MinNum,
                    Unit = p.Unit,
                    Sex = p.Sex,
                    Sort = p.Sort,
                    System = p.Mang,
                    CreateTime = p.KeyDate,
                    CreateMan = p.KeyMan,
                }).ToList();
        }
    }
}
