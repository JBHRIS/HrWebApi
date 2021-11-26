using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_GetCardReason : ICard_Normal_GetCardReason
    {
        private IUnitOfWork _unitOfWork;

        public Card_Normal_GetCardReason(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CardReasonDto> GetCardReason()
        {
            var cardReasonRepo = _unitOfWork.Repository<Cardlosd>();
            return cardReasonRepo.Reads().Select(p => new CardReasonDto
            {
                EffectAttend = p.Att,
                CardReasonCode = p.Code,
                CardReasonName = p.Descr,
                CreateTime = p.KeyDate,
                CreateMan = p.KeyMan,
                Sort = p.Sort,
            }).ToList();
        }
    }
}
