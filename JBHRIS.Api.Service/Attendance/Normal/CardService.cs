using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class CardService : ICardService
    {
        private ICard_Normal_GetCard _card_Normal_GetCard;
        private ICard_Normal_GetCardReason _card_Normal_GetCardReason;
        private ICardRepository _cardRepository;
        private ICard_Normal_GetCardApply _card_Normal_GetCardApply;

        private ICard_Normal_CheckForgetCard _card_Normal_CheckForgetCard;
        private ICard_Normal_SaveForgetCard _card_Normal_SaveForgetCard;


        public CardService( ICard_Normal_GetCardApply card_Normal_GetCardApply, 
            ICard_Normal_CheckForgetCard card_Normal_CheckForgetCard, 
            ICard_Normal_SaveForgetCard card_Normal_SaveForgetCard,
            ICard_Normal_SaveAttCard card_Normal_SaveAttCard,
            ICardRepository cardRepository
            )
        {
            //_card_Normal_GetCard = card_Normal_GetCard;
            //_card_Normal_GetCardReason = card_Normal_GetCardReason;
            _card_Normal_GetCardApply = card_Normal_GetCardApply;
            _card_Normal_CheckForgetCard = card_Normal_CheckForgetCard;
            _card_Normal_SaveForgetCard = card_Normal_SaveForgetCard;
            _cardRepository = cardRepository;
        }
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            return _cardRepository.GetCard(attendanceEntry);
        }

        public List<CardApplyDto> GetCardApplys()
        {
            return _card_Normal_GetCardApply.GetCardApplys();
        }

        public List<CardReasonDto> GetCardReason()
        {
            return _card_Normal_GetCardReason.GetCardReason();
        }

        public bool Insert(CardDto card, out string msg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 忘刷存入後端系統
        /// </summary>
        /// <param name="forgetCardApplyDto"></param>
        /// <returns></returns>
        public ApiResult<string> SaveForgetCard(ForgetCardApplyDto forgetCardApplyDto)
        {
            return _card_Normal_SaveForgetCard.SaveForgetCard(forgetCardApplyDto);
        }

        /// <summary>
        /// 忘刷檢核
        /// </summary>
        /// <param name="forgetCardApplyDto"></param>
        /// <returns></returns>
        public ApiResult<string> CheckForgetCard(ForgetCardApplyDto forgetCardApplyDto)
        {
            return _card_Normal_CheckForgetCard.CheckForgetCard(forgetCardApplyDto);
        }

    }
}
