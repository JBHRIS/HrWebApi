using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto.FencePoints;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class CardAppDetailsHandler : ICardAppDetailsHandler
    {

        private JBHRContext _context;


        public CardAppDetailsHandler( JBHRContext context )
        {
            this._context = context;
        }

        public bool CheckAPP_RegistryKey(string Nobr, string APP_RegistryKey)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageRow"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public List<CardRowDataDto> GetCardDetail(string Url ,string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {

            List<CardRowDataDto> result = new List<CardRowDataDto>();
            try
            {
                result = (from c in _context.Card
                          join Details in _context.CardAppDetails on c.CardAppDetailsId equals Details.AutoKey into CardData
                          from RowData in CardData.DefaultIfEmpty()
                          where c.Nobr == Nobr && BDate <= c.Adate && c.Adate <= EDate
                          select new CardRowDataDto
                          {
                              AutoKey = c.CardAppDetailsId ?? 0,
                              Nobr = c.Nobr,
                              CardNo = c.Cardno,
                              ADate =  c.Adate,
                              ON_Time = c.Ontime,

                              IPAddress = c.Ipadd,
                              IsForgetCard = c.Los,
                              Memo = c.Meno ?? "",
                              Serno = c.Serno ?? "",
                              SSID = RowData.Ssid ?? "",
                              BSSID = RowData.Bssid ?? "",
                              MAC = RowData.Mac ?? "",
                              IP_Address = RowData.IpAddress ?? "",
                              APP_RegistryKey = RowData.AppRegistryKey ?? "",
                              CardType = RowData.CardTypeCode,
                              Address = RowData.Address ?? "",
                              Coordinate = new Location { Latitude = RowData.Latitude ?? 0, Longitude = RowData.Longitude ?? 0 },
                              CardStart = RowData.CardStart ?? DateTime.Now,
                              CardProcess = RowData.CardProcess ?? DateTime.Now,
                              CardSend = RowData.CardSend ?? DateTime.Now,
                              Reason = c.Reason,
                              Remarks = RowData.Remarks ?? "",
                          }).OrderByDescending(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();

                foreach (var item in result)
                {
                    List<int> CardImage = (from image in this._context.CardAppImages
                                           where image.CardAppDetailsId == item.AutoKey
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




        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        public int SaveCardDetails(SaveCardAppDetailsDto Dto , bool  NotTran, string Code) 
        {
            int result = 0;


            try
            {

                CardAppDetails Detail = new CardAppDetails();
                Detail.Nobr = Dto.Nobr;
                Detail.Ssid = Dto.SSID;
                Detail.Bssid = Dto.BSSID;
                Detail.Mac = Dto.MAC;
                Detail.IpAddress = Dto.IP_Address;
                Detail.AppRegistryKey = Dto.APP_RegistryKey;
                Detail.CardTypeCode = Dto.CardTypeCode;
                Detail.Address = Dto.Address;
                Detail.Latitude = Dto.Coordinate.Latitude ;
                Detail.Longitude = Dto.Coordinate.Longitude;
                Detail.CardStart = Dto.CardStart;
                Detail.CardProcess = Dto.CardProcess;
                Detail.CardSend = Dto.CardSend;
                Detail.Reason = Dto.Reason;
                Detail.Remarks = Dto.Remarks;
                Detail.KeyDate = DateTime.Now;
                _context.CardAppDetails.Add(Detail);
                _context.SaveChanges();
                result = Detail.AutoKey;

                CultureInfo MyCultureInfo = new CultureInfo("zh-TW");
                Card mCard = new Card();
                mCard.Code = "";
                mCard.Nobr = Dto.Nobr;
                mCard.Adate = DateTime.Parse(Dto.CardStart.ToString("yyyy-MM-dd"), MyCultureInfo);
                mCard.Ontime = Dto.CardStart.ToString("HHmm"); ;
                mCard.Cardno = "";
                mCard.KeyDate = DateTime.Now;
                mCard.KeyMan = Dto.Nobr;
                mCard.NotTran = NotTran;
                mCard.Days = 0;
                mCard.Reason = "";// SignTypeDto.Reason;
                mCard.Los = false;
                mCard.Ipadd = Dto.IP_Address;
                mCard.Meno = Dto.Remarks;
                mCard.Serno = "";
                mCard.Fulltime = mCard.Adate.AddHours(Convert.ToInt32(mCard.Ontime.Substring(0, 2))).AddMinutes(Convert.ToInt32(mCard.Ontime.Substring(2, 2)));
                mCard.CardAppDetailsId = result;
                _context.Card.Add(mCard);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
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

        private string PunchCardType(string CardType)
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
            }
            return result;


        }
    }
}