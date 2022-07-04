using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class CardMachineSettingDal : ICardMachineSettingDal
    {
        private IUnitOfWork _unitOfWork;

        public CardMachineSettingDal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CardMachineSettingDto GetCardMachineSetting(string settingId)
        {
            var cardMachineSettigRepo = _unitOfWork.Repository<USys7>();
            var cardMachineSetting = cardMachineSettigRepo.Read(p => p.Auto == Convert.ToInt32(settingId));
            if (cardMachineSetting != null)
            {
                CardMachineSettingDto result = new CardMachineSettingDto
                {
                    CodePosition = cardMachineSetting.CodePos.Value,
                    CodeLength = cardMachineSetting.CodeLen.Value,
                    DatePosition = cardMachineSetting.DatePos.Value,
                    DateLength = cardMachineSetting.DateLen.Value,
                    TimePosition = cardMachineSetting.TimePos.Value,
                    TimeLength = cardMachineSetting.TimeLen.Value,
                    SernoPosition = cardMachineSetting.SerPos.Value,
                    SernoLength = cardMachineSetting.SerLen.Value,
                    TextType = cardMachineSetting.TextType,
                    SpiltSignal = cardMachineSetting.SpiltSignal,
                    IgnoreSignal = cardMachineSetting.IgnoreSignal,
                    CardNoIsEmployeeId = cardMachineSetting.Cardnoeuqalnobr.Value,
                    DateFormat = cardMachineSetting.DateFormat,
                    NobrLength = cardMachineSetting.NobrLen.Value,
                    NobrPosition = cardMachineSetting.NobrPos.Value,
                    TimeFormat = cardMachineSetting.TimeFormat
                };
                return result;
            }
            return null;
        }
    }
}
