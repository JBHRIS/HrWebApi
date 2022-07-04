using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AttCardService : IAttCardService
    {
        private ICard_Normal_GetAttCard _card_Normal_GetAttCard;
        private ICard_Normal_SaveAttCard _card_Normal_SaveAttCard;
        private ICard_Normal_UpdateAttCard _card_Normal_UpdateAttCard;

        public AttCardService(
            ICard_Normal_GetAttCard card_Normal_GetAttCard,
            ICard_Normal_SaveAttCard card_Normal_SaveAttCard,
            ICard_Normal_UpdateAttCard card_Normal_UpdateAttCard
            )
        {
            _card_Normal_GetAttCard = card_Normal_GetAttCard;
            _card_Normal_SaveAttCard = card_Normal_SaveAttCard;
            _card_Normal_UpdateAttCard = card_Normal_UpdateAttCard;
        }

        public List<AttendCardDto> GetAttendCard(AttendanceEntry attendanceEntry)
        {
            return _card_Normal_GetAttCard.GetAttendCard(attendanceEntry);
        }

        public ApiResult<string> SaveAttendCard(List<AttCardDto> attCardDtos)
        {
            return _card_Normal_SaveAttCard.SaveAttendCard(attCardDtos);
        }

        public ApiResult<string> UpdateAttCard(List<AttCardDto> attCardDtos)
        {
            return _card_Normal_UpdateAttCard.UpdateAttCard(attCardDtos);
        }
    }
}
