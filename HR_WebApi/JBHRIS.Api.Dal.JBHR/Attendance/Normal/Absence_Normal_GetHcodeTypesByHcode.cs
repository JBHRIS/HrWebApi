using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetHcodeTypesByHcode : IAbsence_Normal_GetHcodeTypesByHcode
    {
        private IUnitOfWork _unitOfWork;
        public Absence_Normal_GetHcodeTypesByHcode(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<HcodeDto> GetHcodeTypesByHcode(HcodeTypesByHcodeEntry hcodeTypesByHcodeEntry)
        {
            var result = new List<HcodeDto>();
            foreach (var item in hcodeTypesByHcodeEntry.Htype.Split(2100))
            {
                var HcodeTypesByHcodeEntry = from h in _unitOfWork.Repository<Hcode>().Reads()
                                             join ht in _unitOfWork.Repository<HcodeType>().Reads() on h.Htype equals ht.Htype
                                             into htGrp
                                             from htg in htGrp.DefaultIfEmpty()
                                             where item.Contains(h.Htype) 
                                             && hcodeTypesByHcodeEntry.Flag.Contains(h.Flag)
                                             select new HcodeDto
                                             {
                                                HCode = h.HCode1,
                                                HCodeDisp = h.HCodeDisp,
                                                HCodeName = h.HName,
                                                HCodeUnit = h.Unit,
                                                Flag = h.Flag,
                                                Htype = h.Htype,
                                             };
                result.AddRange(HcodeTypesByHcodeEntry);
            }
            return result.ToList();
        }
    }
}
