using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dal.Models.JBContent;
using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.App.JB
{
    public class CardAppDetailsHandler : ICardAppDetailsHandler
    {
        private AppDBContext _AppDBContext;
        private JBDBContent _JBDBContent;

        public CardAppDetailsHandler(AppDBContext mAppDBContext, JBDBContent mJBDBContent)
        {
            this._AppDBContext = mAppDBContext;
            this._JBDBContent = mJBDBContent;
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
                /* 20210415
				 * 1,826,024.01
                 * Nobr = EMPLOYEE_CODE
                 * EMPLOYEE_CODE => EMPLOYEE_ID  轉換
                 * HRM_ATTEND_CARD_DATA_TEMP  用 EMPLOYEE_ID 找
                 * 資料顯示 Nobr
                 * jb公司內部 工號轉換
                 *
                 * by chenyuwei
                 */
                BaseInfoDto BaseInfoDto = new BaseInfoDto();
                BaseInfoDto = (from u in this._JBDBContent.HRM_BASE_BASE
                               where u.EMPLOYEE_CODE == Nobr
                               select new BaseInfoDto
                               {
                                   Nobr = u.EMPLOYEE_ID,
                                   Name = u.NAME_C
                               }).FirstOrDefault();

                result = (from c in this._JBDBContent.HRM_ATTEND_CARD_DATA_TEMP
                          where c.EMPLOYEE_ID == BaseInfoDto.Nobr && BDate <= c.CARD_DATE && c.CARD_DATE <= EDate
                          && (c.CardAppDetailsID ?? 0) > 0
                          select new CardRowDataDto
                          {
                              AutoKey = c.CardAppDetailsID ?? 0,
                              Nobr = Nobr,
                              CardNo = c.CARD_NO,
                              ADate = c.CARD_DATE_TIME ?? DateTime.Now,
                              ON_Time = c.CARD_TIME,

                              IPAddress = c.IP_ADDRESS,
                              IsForgetCard = c.IS_FORGET_CARD == "Y",
                              Memo = c.MEMO ?? "",
                              Serno = c.SERIAL_NO ?? "",
                              SSID = "",
                              BSSID = "",
                              MAC = "",
                              IP_Address = c.IP_ADDRESS,
                              APP_RegistryKey = "",
                              CardType = "",
                              Address = "",
                              Coordinate = new Location(),
                              CardStart = c.CARD_DATE_TIME ?? DateTime.Now,
                              CardProcess = c.CARD_DATE_TIME ?? DateTime.Now,
                              CardSend = c.UPDATE_DATE ?? DateTime.Now,
                              Reason = "",
                              Remarks = ""
                          }).ToList();

                /* { "接近 'OFFSET' 之處的語法不正確。\r\nFETCH 陳述式中的選項 NEXT 使用方式無效。"}
                 * sql serivce 需要20082r2
                 * 只有 2008
				 * https://uniswap.org/
                 */

                result = result.OrderByDescending(m => m.ADate).ThenByDescending(m => m.ON_Time).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();

                foreach (var item in result)
                {
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        public int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code)
        {
            int result = 0;
            try
            {
                Models.AppDBContext.CardAppDetails Detail = new Models.AppDBContext.CardAppDetails();
                Detail.Nobr = Dto.Nobr;
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

                /* 20210414
                   * Nobr = EMPLOYEE_CODE
                   * 因刷卡轉出勤會出錯誤  轉出勤用 EMPLOYEE_ID
                   * EMPLOYEE_CODE => EMPLOYEE_ID  轉換
                   * HRM_ATTEND_CARD_DATA_TEMP  用 EMPLOYEE_ID 找
                   * 資料顯示 Nobr
                   * jb公司內部 工號轉換
                   *
                   * by chenyuwei
                   */

                BaseInfoDto BaseInfoDto = new BaseInfoDto();
                BaseInfoDto = (from u in this._JBDBContent.HRM_BASE_BASE
                               where u.EMPLOYEE_CODE == Dto.Nobr
                               select new BaseInfoDto
                               {
                                   Nobr = u.EMPLOYEE_ID,
                                   Name = u.NAME_C
                               }).FirstOrDefault();

                DateTime DateTimeNow = DateTime.Now;

                CultureInfo MyCultureInfo = new CultureInfo("zh-TW");
                HRM_ATTEND_CARD_DATA_TEMP mCard = new HRM_ATTEND_CARD_DATA_TEMP();
                mCard.CARD_TYPE = "";
                mCard.EMPLOYEE_ID = BaseInfoDto.Nobr;
                mCard.CARD_DATE = DateTime.Parse(DateTimeNow.ToString("yyyy-MM-dd"), MyCultureInfo);
                mCard.CARD_TIME = DateTimeNow.ToString("HHmm");
                mCard.CARD_NO = BaseInfoDto.Nobr;
                mCard.CARD_DATE_TIME = mCard.CARD_DATE.Value.AddHours(Convert.ToInt32(mCard.CARD_TIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(mCard.CARD_TIME.Substring(2, 2)));
                mCard.CREATE_DATE = DateTimeNow;
                mCard.CREATE_MAN = BaseInfoDto.Nobr;

                if (NotTran)
                {
                    mCard.NOT_TRAN = "Y";//
                }
                else
                {
                    mCard.NOT_TRAN = "N";//
                }
                mCard.IS_FORGET_CARD = "N";
                mCard.IP_ADDRESS = Dto.IP_Address;
                mCard.MEMO = Dto.Reason;
                mCard.SERIAL_NO = "";
                mCard.UPDATE_MAN = BaseInfoDto.Nobr;
                mCard.UPDATE_DATE = DateTimeNow;
                mCard.CardAppDetailsID = result;
                this._JBDBContent.HRM_ATTEND_CARD_DATA_TEMP.Add(mCard);
                this._JBDBContent.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag)
        {
            int result = 0;
            try
            {
                Models.AppDBContext.CardAppDetails Detail = new Models.AppDBContext.CardAppDetails();
                Detail.Nobr = Dto.Nobr;
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
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        /// <summary>
        /// 沒再用不想寫抓db
        /// </summary>
        /// <param name="CardType"></param>
        /// <returns></returns>
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
        public bool SaveCardMsg(SaveCardAppDetailsDto dto, bool notTran, string code)
        {
            BaseInfoDto BaseInfoDto = new BaseInfoDto();
            BaseInfoDto = (from u in this._JBDBContent.HRM_BASE_BASE
                           where u.EMPLOYEE_CODE == dto.Nobr
                           select new BaseInfoDto
                           {
                               Nobr = u.EMPLOYEE_ID,
                               Name = u.NAME_C
                           }).FirstOrDefault();


            DateTime DateTimeNow = DateTime.Now;

            var Data = (from c in _JBDBContent.HRM_ATTEND_CARD_DATA_TEMP
                        where c.EMPLOYEE_ID == BaseInfoDto.Nobr
                        && c.CARD_DATE_TIME.HasValue
                        && c.CARD_DATE_TIME.Value.Date == DateTimeNow.Date
                        select c).ToList();

            var CheckData = (from c in Data
                             where c.CARD_DATE_TIME.Value.ToString("yyyy/MM/dd HH:mm") == DateTimeNow.ToString("yyyy/MM/dd HH:mm")
                             select c).Any();

            return CheckData;
        }
    }
}