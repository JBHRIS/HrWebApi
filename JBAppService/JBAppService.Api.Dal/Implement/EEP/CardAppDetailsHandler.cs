using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto.FencePoints;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class CardAppDetailsHandler : ICardAppDetailsHandler
    {

        private JBEEPContext _context;

        public CardAppDetailsHandler(JBEEPContext context)
        {
            this._context = context;
        }

        public List<CardRowDataDto> GetCardDetail(string Url, string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            List<CardRowDataDto> result = new List<CardRowDataDto>();
            try
            {

                string NobrID = (from b in _context.HRM_BASE_BASE
                                 where b.EMPLOYEE_CODE == Nobr
                                 select b.EMPLOYEE_ID).FirstOrDefault();


                result = (from c in _context.HRM_ATTEND_CARD_DATA_TEMP
                          join Details in _context.CardAppDetails on c.CardAppDetailsID equals Details.AutoKey into CardData
                          from RowData in CardData.DefaultIfEmpty()
                          where c.EMPLOYEE_ID == NobrID && BDate <= c.CARD_DATE_TIME && c.CARD_DATE_TIME <= EDate.AddDays(1)
                          select new CardRowDataDto
                          {
                              AutoKey = c.CardAppDetailsID ?? 0,
                              Nobr = Nobr,
                              CardNo = c.CARD_NO,
                              ADate = c.CARD_DATE_TIME.Value,
                              ON_Time = c.CARD_TIME,

                              IPAddress = c.IP_ADDRESS,
                              IsForgetCard = c.IS_FORGET_CARD == "Y",
                              Memo = c.MEMO ?? "",
                              Serno = c.SERIAL_NO ?? "",
                              SSID = RowData.SSID ?? "",
                              BSSID = RowData.BSSID ?? "",
                              MAC = RowData.MAC ?? "",
                              IP_Address = RowData.IP_Address ?? "",
                              APP_RegistryKey = RowData.APP_RegistryKey ?? "",
                              CardType = RowData.CardTypeCode,
                              Address = RowData.Address ?? "",
                              Coordinate = new Location { Latitude = RowData.Latitude ?? 0, Longitude = RowData.Longitude ?? 0 },
                              CardStart = RowData.CardStart ?? DateTime.Now,
                              CardProcess = RowData.CardProcess ?? DateTime.Now,
                              CardSend = RowData.CardSend ?? DateTime.Now,
                              Reason = RowData.Reason,
                              Remarks = RowData.Remarks ?? "",
                          }).OrderByDescending(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();


                foreach (var item in result)
                {
                    List<int> CardImage = (from image in _context.CardAppImages
                                           where image.CardAppDetailsID == item.AutoKey
                                           select image.AutoKey).ToList();

                    List<string> Images = new List<string>();
                    foreach (var image in CardImage)
                    {
                        string URL = string.Format(@"{0}/{1}/{2}", Url, Nobr, image);
                        Images.Add(URL);
                    }
                    item.Images = Images;
                    item.CardType = PunchCardType(item.CardType);
                }


            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int SaveCardDetails(SaveCardAppDetailsDto Dto , bool NotTran, string Code)
        {
            int result = 0;


            try
            {
                string Nobr = (from b in _context.HRM_BASE_BASE
                               where b.EMPLOYEE_CODE == Dto.Nobr
                               select b.EMPLOYEE_ID).FirstOrDefault();






                DateTime DateTimeNow = DateTime.Now;

                CardAppDetails Detail = new CardAppDetails();
                Detail.Nobr = Nobr;
                Detail.SSID = Dto.SSID;
                Detail.BSSID = Dto.BSSID;
                Detail.MAC = Dto.MAC;
                Detail.IP_Address = Dto.IP_Address;
                Detail.APP_RegistryKey = Dto.APP_RegistryKey;
                Detail.CardTypeCode = Dto.CardTypeCode;
                Detail.Address = Dto.Address;
                Detail.Latitude = Dto.Coordinate.Latitude;
                Detail.Longitude = Dto.Coordinate.Longitude;
                Detail.CardStart = Dto.CardStart;
                Detail.CardProcess = Dto.CardProcess;
                Detail.CardSend = Dto.CardSend;
                Detail.Reason = Dto.Reason;
                Detail.Remarks = Dto.Remarks;
                Detail.KeyDate = DateTimeNow;
                _context.CardAppDetails.Add(Detail);
                _context.SaveChanges();
                result = Detail.AutoKey;

                CultureInfo MyCultureInfo = new CultureInfo("zh-TW");
                HRM_ATTEND_CARD_DATA_TEMP mCard = new HRM_ATTEND_CARD_DATA_TEMP();
                mCard.CARD_TYPE = "";
                mCard.EMPLOYEE_ID = Nobr;
                mCard.SOURCE_CODE = "";
                mCard.CARD_DATE = Convert.ToDateTime(Dto.CardStart.ToString("yyyy-MM-dd"));
                mCard.CARD_TIME = Dto.CardStart.ToString("HHmm");
                mCard.CARD_NO = Dto.Nobr;
                mCard.CARD_DATE_TIME = Dto.CardStart;



                if (NotTran)
                {
                    mCard.NOT_TRAN = "Y";
                }
                else
                {
                    mCard.NOT_TRAN = "N";
                }

                mCard.IS_FORGET_CARD = "N";

                mCard.CREATE_MAN = Nobr;
                mCard.CREATE_DATE = DateTimeNow;
                mCard.SERIAL_NO = "";
                mCard.UPDATE_MAN = Nobr;
                mCard.UPDATE_DATE = DateTimeNow;
                mCard.CardAppDetailsID = result;
                _context.HRM_ATTEND_CARD_DATA_TEMP.Add(mCard);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return result;
        }






        public string PunchCardType(string CardType)
        {
            string result = "";
            switch (CardType)
            {
                case "Normal":
                    result = "一般";
                    break;
                case "Overtime":
                    result = "加班";
                    break;
                case "Rest":
                    result = "休息";
                    break;
                default:
                    result = "";
                    break;
            }


            return result;


        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="APP_RegistryKey"></param>
        /// <returns></returns>
        public bool CheckAPP_RegistryKey( string Nobr , string  APP_RegistryKey)
        {

            bool result = false;
            string EmployeeID = (from b in _context.HRM_BASE_BASE
                           where b.EMPLOYEE_CODE == Nobr
                           select b.EMPLOYEE_ID).FirstOrDefault();

            string _APP_RegistryKey = (from d in _context.CardAppDetails
                                       where d.Nobr == EmployeeID
                                       select d.APP_RegistryKey).FirstOrDefault();

            if (_APP_RegistryKey == null || _APP_RegistryKey == APP_RegistryKey)
            {
                result = true;
            }
            return result;
        }

        public int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag)
        {
            throw new NotImplementedException();
        }

        public bool SaveCardMsg(SaveCardAppDetailsDto dto, bool notTran, string code)
        {
            throw new NotImplementedException();
        }
    }
}



