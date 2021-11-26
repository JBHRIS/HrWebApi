using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Absence_Normal_GetHcodeTypes : IAbsence_Normal_GetHcodeTypes
    {

        private IUnitOfWork _unitOfWork;
        public Absence_Normal_GetHcodeTypes(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<HcodeTypeDto> GetHcodeTypes()
        {
            var result = new List<HcodeTypeDto>();
            var HcodeTypes = from ht in _unitOfWork.Repository<HcodeType>().Reads()
                             where ht.Sort>0
                             orderby ht.Sort ascending
                             select new HcodeTypeDto
                             {
                                Htype = ht.Htype,
                                TypeName = ht.TypeName,
                                GetCode = ht.GetCode,
                                Sort = ht.Sort,
                                YearMax = ht.YearMax,
                                AutoCreateHours = ht.AutoCreateHours,
                                MergeDisplay = ht.MergeDisplay,
                                Unit = ht.Unit,
                                KeyDate = ht.KeyDate,
                                KeyMan = ht.KeyMan,
                                ExtendCode = ht.ExtendCode,
                                ExpireCode = ht.ExpireCode,
                             };
            result.AddRange(HcodeTypes);
            return result.ToList();
        }
    }
}
