using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetHcode : IAbsence_Normal_GetHcode
    {
        private IUnitOfWork _unitOfWork;
        public Absence_Normal_GetHcode(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<HcodeDto> GetHcode()
        {
            var hcodes = from h in _unitOfWork.Repository<Hcode>().Reads()
                          select new HcodeDto
                          {
                              HCode = h.HCode1,
                              Flag = h.Flag,
                              HCodeDisp = h.HCodeDisp,
                              HCodeName = h.HName,
                              HCodeUnit = h.Unit,
                              Htype = h.Htype,
                              Che = h.Che,
                              InHoli = h.InHoli,
                              Sex = h.Sex
                          };
            return hcodes.ToList();
        }

        public HcodeDto GetHcodeById(string code)
        {
            var hcodes = from h in _unitOfWork.Repository<Hcode>().Reads()
                         where code == h.HCode1
                         select new HcodeDto
                         {
                             HCode = h.HCode1,
                             Flag = h.Flag,
                             HCodeDisp = h.HCodeDisp,
                             HCodeName = h.HName,
                             HCodeUnit = h.Unit,
                             Htype = h.Htype,
                             Che = h.Che,
                             AbsUnit = h.Absunit,
                             Minnum = h.MinNum,
                             InHoli = h.InHoli,
                             Sex = h.Sex
                         };
            return hcodes.FirstOrDefault();
        }
    }
}
