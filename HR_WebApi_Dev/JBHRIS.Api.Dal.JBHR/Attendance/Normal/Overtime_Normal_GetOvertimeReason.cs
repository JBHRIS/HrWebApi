using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Overtime_Normal_GetOvertimeReason : IOvertime_Normal_GetOvertimeReason
    {
        private IUnitOfWork _unitOfWork;

        public Overtime_Normal_GetOvertimeReason(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            var otrcdRepo = _unitOfWork.Repository<Otrcd>();
            return otrcdRepo.Reads().Select(p => new OvertimeReasonDto
            {
                Id = p.Otrcd1,
                Code = p.OtrcdDisp,
                Name = p.Otrname,
                Sort = p.Sort,
                CreateTime = p.KeyDate,
                CreateMan = p.KeyMan,
            }).ToList();
        }
    }
}
