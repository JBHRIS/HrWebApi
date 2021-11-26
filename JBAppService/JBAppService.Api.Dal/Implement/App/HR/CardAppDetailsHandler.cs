using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.App.HR
{
    public class CardAppDetailsHandler : ICardAppDetailsHandler
    {
        private AppDBContext _AppDBContext;
        private JBHRContext _JBHRContext;

        public CardAppDetailsHandler(AppDBContext mAppDBContext, JBHRContext mJBHRContext)
        {
            this._AppDBContext = mAppDBContext;
            this._JBHRContext = mJBHRContext;
        }

        public bool CheckAPP_RegistryKey(string Nobr, string APP_RegistryKey)
        {
            bool result = false;

            try
            {
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageRow"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public List<CardRowDataDto> GetCardDetail(string Url, string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            List<CardRowDataDto> result = new List<CardRowDataDto>();
            try
            {
                result = (from c in this._JBHRContext.Card
                          where c.Nobr == Nobr && BDate <= c.Adate && c.Adate <= EDate
                          && (c.CardAppDetailsId ?? 0) > 0
                          select new CardRowDataDto
                          {
                              AutoKey = c.CardAppDetailsId ?? 0,
                              Nobr = c.Nobr,
                              CardNo = c.Cardno,
                              ADate = c.Adate,
                              ON_Time = c.Ontime,

                              IPAddress = c.Ipadd,
                              IsForgetCard = c.Los,

                              Memo = c.Meno ?? "",
                              Serno = c.Serno ?? "",
                              Reason = c.Reason,

                              SSID = "",
                              BSSID = "",
                              MAC = "",
                              IP_Address = "",
                              APP_RegistryKey = "",
                              CardType = "",
                              Address = "",
                              Coordinate = new Location { },
                              CardStart = DateTime.Now,
                              CardProcess = DateTime.Now,
                              CardSend = DateTime.Now,
                              Remarks = "",
                          }).OrderByDescending(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();

                foreach (var item in result)
                {
                    if (item.ON_Time.Length < 4)
                    {
                        item.ON_Time = "0000";
                    }
                    item.ADate = new DateTime(item.ADate.Year, item.ADate.Month, item.ADate.Day, int.Parse(item.ON_Time.Substring(0, 2).ToString()), int.Parse(item.ON_Time.Substring(2, 2).ToString()), 0);

                    if (item.AutoKey != 0)
                    {
                        Models.AppDBContext.CardAppDetails details = (from Details in this._AppDBContext.CardAppDetails
                                                                      where Details.AutoKey == item.AutoKey
                                                                      select Details).FirstOrDefault();

                        //item.ADate = details.CardStart ?? item.ADate;
                        item.SSID = details.SSID ?? "";
                        item.BSSID = details.BSSID ?? "";
                        item.MAC = details.MAC ?? "";
                        item.IP_Address = details.IP_Address ?? "";
                        item.APP_RegistryKey = details.APP_RegistryKey ?? "";
                        item.CardType = details.CardTypeCode;
                        item.Address = details.Address ?? "";
                        item.Coordinate = new Location { Latitude = details.Latitude ?? 0, Longitude = details.Longitude ?? 0 };
                        item.CardStart = details.CardStart ?? DateTime.Now;
                        item.CardProcess = details.CardProcess ?? DateTime.Now;
                        item.CardSend = details.CardSend ?? DateTime.Now;
                        item.Remarks = details.Remarks ?? "";

                        List<int> CardImage = (from image in this._AppDBContext.CardAppImages
                                               where image.CardAppDetailsID == item.AutoKey
                                               select image.AutoKey).ToList();

                        List<string> Images = new List<string>();
                        foreach (var image in CardImage)
                        {
                            string URL = string.Format(@"{0}/{1}/{2}", Url, Nobr, image);
                            Images.Add(URL);
                        }

                        item.Images = Images;
                    }

                    item.CardType = PunchCardType(item.CardType);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code)
        {
            int result = 0;

            try
            {
                BaseInfoDto baseInfo = new BaseInfoDto();
                baseInfo = (from Base in _JBHRContext.Base
                            where Base.Nobr == Dto.Nobr
                            select new BaseInfoDto
                            {
                                Nobr = Base.Nobr,
                                Name = Base.NameC
                            }).FirstOrDefault();

                Models.AppDBContext.CardAppDetails Detail = new Models.AppDBContext.CardAppDetails();
                Detail.Nobr = baseInfo.Nobr.Trim();
                Detail.SSID = Dto.SSID;
                Detail.BSSID = Dto.BSSID;
                Detail.MAC = Dto.MAC;
                Detail.IP_Address = Dto.IP_Address;
                Detail.APP_RegistryKey = Dto.APP_RegistryKey;
                Detail.QRCODE = Dto.QRCode;
                Detail.CardTypeCode = Dto.CardTypeCode;
                Detail.Address = Dto.Address;
                Detail.Latitude = Dto.Coordinate.Latitude;
                Detail.Longitude = Dto.Coordinate.Longitude;
                Detail.CardStart = Dto.CardStart;
                Detail.CardProcess = Dto.CardProcess;
                Detail.CardSend = Dto.CardSend;
                Detail.Reason = Dto.Reason;
                Detail.Remarks = Dto.Remarks;
                Detail.KeyDate = DateTime.Now;
                this._AppDBContext.CardAppDetails.Add(Detail);
                this._AppDBContext.SaveChanges();
                result = Detail.AutoKey;

                /* NotTran 目前 先不列入刷卡轉出勤
                 * 避免影響計算出勤時間
                 */

                DateTime CardTime = DateTime.Now;

                CultureInfo MyCultureInfo = new CultureInfo("zh-TW");
                Card mCard = new Card();
                mCard.Code = Code;
                mCard.Nobr = baseInfo.Nobr.Trim();
                mCard.Adate = DateTime.Parse(CardTime.ToString("yyyy-MM-dd"), MyCultureInfo);
                mCard.Ontime = CardTime.ToString("HHmm"); ;
                mCard.Cardno = "";
                mCard.KeyDate = CardTime;
                mCard.KeyMan = baseInfo.Nobr.Trim();
                mCard.NotTran = NotTran;//
                mCard.Days = 0;
                mCard.Reason = "";// SignTypeDto.Reason;
                mCard.Los = false;
                mCard.Ipadd = Dto.IP_Address;
                mCard.Meno = Dto.Remarks;
                mCard.Serno = "";
                mCard.Fulltime = mCard.Adate.AddHours(Convert.ToInt32(mCard.Ontime.Substring(0, 2))).AddMinutes(Convert.ToInt32(mCard.Ontime.Substring(2, 2)));
                mCard.CardAppDetailsId = result;
                this._JBHRContext.Card.Add(mCard);
                this._JBHRContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag)
        {
            return 0;
        }

        public bool SaveCardMsg(SaveCardAppDetailsDto Dto, bool notTran, string code)
        {
            BaseInfoDto baseInfo = new BaseInfoDto();
            baseInfo = (from Base in _JBHRContext.Base
                        where Base.Nobr == Dto.Nobr
                        select new BaseInfoDto
                        {
                            Nobr = Base.Nobr,
                            Name = Base.NameC
                        }).FirstOrDefault();

            DateTime DateTimeNow = DateTime.Now;

            var Data = (from c in _JBHRContext.Card
                         where c.Nobr == baseInfo.Nobr && c.Adate == DateTimeNow.Date
                         select new
                         {
                             c.Nobr,
                             c.Fulltime,
                             c.Adate,
                             c.Ontime
                         }).ToList();

            var CheckData = (from c in Data
                             where c.Nobr == baseInfo.Nobr &&
                             c.Adate == DateTimeNow.Date && c.Ontime == DateTimeNow.ToString("HHmm")
                             select 1).Any();

            return CheckData;
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