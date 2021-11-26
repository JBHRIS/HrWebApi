using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepository;
        private ICardReasonRepository _cardReasonRepository;
        private ILogger _logger;
        public CardService(ICardRepository cardRepository, ICardReasonRepository cardReasonRepository, ILogger logger)
        {
            _cardRepository = cardRepository;
            _cardReasonRepository = cardReasonRepository;
            _logger = logger;
        }
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            return _cardRepository.GetCard(attendanceEntry);
        }

        public List<CardReasonDto> GetCardReason()
        {
            return _cardReasonRepository.GetCardReason();
        }
    }
}
