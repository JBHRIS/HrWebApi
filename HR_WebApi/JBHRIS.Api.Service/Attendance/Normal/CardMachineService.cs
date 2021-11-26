using Hangfire;
using Hangfire.Dashboard.Management.Metadata;
using JBHRIS.Api.Bll.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Normal;
using JBHRIS.Api.Dto.Employee.Normal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    [ManagementPage("收卡服務Dll")]
    public class CardMachineService : ICardMachineService
    {
        private ICardMachineSettingDal _cardMachineSettingDal;
        private ICardTextRecordConvertBll _cardTextRecordConvertBll;
        private ICardService _cardService;

        public CardMachineService(ICardMachineSettingDal cardMachineSettingDal, ICardTextRecordConvertBll cardTextRecordConvertBll)
        {
            _cardMachineSettingDal = cardMachineSettingDal;
            _cardTextRecordConvertBll = cardTextRecordConvertBll;
            //_cardService = cardService;
        }
        public CardMachineSettingDto GetCardMachineSetting(string SettingId)
        {

            return _cardMachineSettingDal.GetCardMachineSetting(SettingId);
        }
        [Hangfire.Dashboard.Management.Support.Job]
        [DisplayName("拋轉刷卡文字檔")]
        [Description("設定參數並自動讀取刷卡檔內容")]
        [AutomaticRetry(Attempts = 3)]   //自動重試
        [DisableConcurrentExecution(90)] //禁止使用並行
        public List<CardTextRecordDto> GetCardTextRecords([DisplayData("收卡設定檔編號",
                     "",
                     "輸入收卡設定檔編號")]string SettingId
            , [DisplayData("文字檔位置",
                     "",
                     "檔案夾路徑")] string TextFileFolder
            , [DisplayData("回應結果內容編碼",
                     "",
                     "常見的有 UTF-8、Unicode、ASCII，錯誤的編碼會導致內容無法正確呈現",
                     "",
                     ConvertType = typeof(EncodingsInputDataList))] string encoding
            , [DisplayData("檔案格式",
                     "",
                     "預設為*.txt","*.txt")]
        string FileExtension = "*.txt")
        {
            List<CardTextRecordDto> results = new List<CardTextRecordDto>();
            var cardMachineSetting = GetCardMachineSetting(SettingId);
            string[] textFiles = System.IO.Directory.GetFiles(TextFileFolder, FileExtension);
            foreach (var textFile in textFiles)
            {
                string[] TextLines = System.IO.File.ReadAllLines(textFile, Encoding.GetEncoding(encoding));
                foreach (var text in TextLines)
                {
                    CardTextRecordDto result = new CardTextRecordDto
                    {
                        TextContent = text,
                        CardRecord = null,
                        State = true,
                        ErrorMessage = ""
                    };
                    results.Add(Convert_CardTextRecord_To_CardRecord(cardMachineSetting, result));
                }
            }
            return results.Where(p => !p.State).ToList();
        }

        private CardTextRecordDto Convert_CardTextRecord_To_CardRecord(CardMachineSettingDto cardMachineSetting, CardTextRecordDto cardTextRecord)
        {
            List<CardApplyDto> cardApplyDtos = new List<CardApplyDto>();
            cardApplyDtos = _cardService.GetCardApplys();
            var result = _cardTextRecordConvertBll.Convert_CardTextRecord_To_CardRecord(cardMachineSetting, cardApplyDtos, cardTextRecord);

            return result;
        }


        public CardTextRecordDto InsertCardTextRecord(CardTextRecordDto cardText)
        {
            if (!cardText.State) return cardText;
            if (cardText.CardRecord == null)
            {
                cardText.ErrorMessage += Environment.NewLine + "轉檔失敗：" + cardText.TextContent;
                cardText.State = false;
                return cardText;
            }
            //if (!employees.Contains(cardText.CardRecord.EmployeeId))
            //{
            //    cardText.ErrorMessage += Environment.NewLine + "工號" + cardText.CardRecord.EmployeeId + "未在允許名單內";
            //    cardText.State = false;
            //    continue;
            //}
            string msg = "";
            var card = new CardDto
            {
                EmployeeID = cardText.CardRecord.EmployeeId,
                Forget = false,
                ForgetReason = "",
                PuchInDate = cardText.CardRecord.CardDate,
                PuchInTime = cardText.CardRecord.CardTime,
                Remarks = "",
                Source = cardText.CardRecord.Source,
            };
            if (_cardService.Insert(card, out msg))
            {
                cardText.ErrorMessage += Environment.NewLine + msg;
                cardText.State = false;
            }
            return cardText;
        }
        public class EncodingsInputDataList : IInputDataList
        {
            public Dictionary<string, string> GetData()
            {
                Dictionary<string, string> additionalEncodes = new Dictionary<string, string>();
                additionalEncodes.Add("big5", "繁體中文big5");
                return additionalEncodes.Union(Encoding.GetEncodings()
                               .GroupBy(f => f.Name, (f1, f2) => f2.FirstOrDefault())
                               .ToDictionary(f => f.Name, f => f.DisplayName)).ToDictionary(p => p.Key, p => p.Value);
            }

            public string GetDefaultValue()
            {
                return null;
            }
        }
    }
}
