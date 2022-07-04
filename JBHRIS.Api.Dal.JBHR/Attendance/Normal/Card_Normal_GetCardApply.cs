using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_GetCardApply : ICard_Normal_GetCardApply
    {
        private IUnitOfWork _unitOfWork;

        public Card_Normal_GetCardApply(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CardApplyDto> GetCardApplys()
        {
            return _unitOfWork.Repository<Cardapp>().Reads().Select(p => new CardApplyDto
            {
                CardNo = p.Cardno,
                DateBegin = p.Bdate,
                DateEnd = p.Edate,
                EmplyeeId = p.Nobr
            }).ToList();
        }
    }
}
