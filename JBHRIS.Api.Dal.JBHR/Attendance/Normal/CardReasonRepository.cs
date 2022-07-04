using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class CardReasonRepository : ICardReasonRepository
    {
        private IUnitOfWork _unitOfWork;
        public CardReasonRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CardReasonDto> GetCardReason()
        {
            return _unitOfWork.Repository<Cardlosd>().Reads().Select(p => new CardReasonDto
            {
                Code = p.Code,
                Description = p.Descr,
                EffectsAttend = p.Att,
                Sort = p.Sort,
                KeyMan = p.KeyMan,
                KeyDate = p.KeyDate
            }).ToList();
        }
    }
}
