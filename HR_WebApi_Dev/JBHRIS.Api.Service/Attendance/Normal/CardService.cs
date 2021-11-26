using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class CardService : ICardService
    {
        private ICard_Normal_GetCard _card_Normal_GetCard;
        private ICard_Normal_GetCardReason _card_Normal_GetCardReason;

        public CardService(ICard_Normal_GetCard card_Normal_GetCard, ICard_Normal_GetCardReason card_Normal_GetCardReason )
        {
            _card_Normal_GetCard = card_Normal_GetCard;
            _card_Normal_GetCardReason = card_Normal_GetCardReason;
        }
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            return _card_Normal_GetCard.GetCard(attendanceEntry);
        }

        public List<CardReasonDto> GetCardReason()
        {
            return _card_Normal_GetCardReason.GetCardReason();
        }
    }
}
