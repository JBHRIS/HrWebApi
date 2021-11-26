using JBHRIS.Api.Bll.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class CardTextRecordConvertBll : ICardTextRecordConvertBll
    {
        public CardTextRecordDto Convert_CardTextRecord_To_CardRecord(CardMachineSettingDto cardMachineSetting, List<CardApplyDto> cardApplyDtos, CardTextRecordDto inputCardText)
        {
            if (cardMachineSetting == null)
                throw new Exception("無效的卡機設定檔");
            if (cardMachineSetting.TextType == "Position")//位置
            {
                return ConvertByPosition(cardMachineSetting, cardApplyDtos, inputCardText);
            }
            else if (cardMachineSetting.TextType == "Signal")//符號
            {
                return ConvertBySignal(cardMachineSetting, cardApplyDtos, inputCardText);
            }
            else throw new Exception("無效的卡片格式判斷類別");
        }

        private CardTextRecordDto ConvertByPosition(CardMachineSettingDto cardMachineSetting, List<CardApplyDto> cardApplyDtos, CardTextRecordDto inputCardText)
        {
            try
            {
                var cardNo = inputCardText.TextContent.Substring(cardMachineSetting.NobrPosition, cardMachineSetting.NobrLength);
                string EmployeeId = GetEmployeeIdByPosition(cardMachineSetting, cardApplyDtos, inputCardText, cardNo);

                string CardDateString = inputCardText.TextContent.Substring(cardMachineSetting.DatePosition, cardMachineSetting.DateLength);
                DateTime? CardDate = ConvertCardDateStringToDate(CardDateString, cardMachineSetting.DateFormat, inputCardText);

                string CardTimeString = inputCardText.TextContent.Substring(cardMachineSetting.TimePosition, cardMachineSetting.TimeLength);
                string? CardTime = ConvertCardTimeStringToTime(CardTimeString, cardMachineSetting.TimeFormat, inputCardText);

                string Source = inputCardText.TextContent.Substring(cardMachineSetting.CodePosition, cardMachineSetting.CodeLength);

                inputCardText.CardRecord = new CardRecordDto
                {
                    CardDate = CardDate.GetValueOrDefault(new DateTime()),
                    CardTime = CardTime,
                    EmployeeId = EmployeeId,
                    Source = Source,
                };
                return inputCardText;
            }
            catch (Exception ex)
            {
                inputCardText.State = false;
                inputCardText.ErrorMessage += ex.Message + Environment.NewLine;
                return inputCardText;
            }
        }

        private string? ConvertCardTimeStringToTime(string cardTimeString, string timeFormat, CardTextRecordDto inputCardText)
        {
            DateTime cardTime;
            if (DateTime.TryParseExact(cardTimeString, timeFormat, null, System.Globalization.DateTimeStyles.None, out cardTime))
                return cardTime.ToString("HHmm");
            else
            {
                inputCardText.State = false;
                inputCardText.ErrorMessage += string.Format("無效的時間格式({0})", cardTimeString) + Environment.NewLine;
            }
            return null;
        }

        private DateTime? ConvertCardDateStringToDate(string cardDateString, string dateFormat, CardTextRecordDto inputCardText)
        {
            DateTime cardDate;
            if (DateTime.TryParseExact(cardDateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out cardDate))
                return cardDate;
            else
            {
                inputCardText.State = false;
                inputCardText.ErrorMessage += string.Format("無效的日期格式({0})", cardDateString) + Environment.NewLine;
            }
            return null;
        }

        private static string GetEmployeeIdByPosition(CardMachineSettingDto cardMachineSetting, List<CardApplyDto> cardApplyDtos, CardTextRecordDto inputCardText, string cardNo)
        {
            if (cardMachineSetting.CardNoIsEmployeeId)
            {
                return cardNo;
            }
            else
            {
                var cardApply = cardApplyDtos.FirstOrDefault(p =>
                        inputCardText.CardRecord.CardDate >= p.DateBegin
                        && inputCardText.CardRecord.CardDate <= p.DateEnd
                        && p.CardNo == cardNo);//有效期限內的領卡資料
                if (cardApply != null)
                    return cardApply.EmplyeeId;
                else
                {
                    inputCardText.State = false;
                    inputCardText.ErrorMessage += "找不到領卡資料(卡號：" + cardNo + ")" + Environment.NewLine;
                }
            }

            return "Error_GetEmployeeIdByPosition";
        }

        private CardTextRecordDto ConvertBySignal(CardMachineSettingDto cardMachineSetting, List<CardApplyDto> cardApplyDtos, CardTextRecordDto inputCardText)
        {
            throw new NotImplementedException();
        }
    }
}
