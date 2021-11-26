using JBAppService.Api.Dto.FencePoints;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class CardDataViewDto
    {

    }


    public class CardRowDataDto
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public DateTime ADate { get; set; }
        public string ON_Time { get; set; }
        public string CardNo { get; set; }
        public string IPAddress { get; set; }
        public bool IsForgetCard { get; set; }
        public string Memo { get; set; }
        public string Serno { get; set; }

        /// <summary>
        /// SSID
        /// </summary>
        public string SSID { get; set; }
        /// <summary>
        /// BSSID
        /// </summary>
        public string BSSID { get; set; }
        /// <summary>
        /// MAC
        /// </summary>
        public string MAC { get; set; }
        /// <summary>
        /// IP位置
        /// </summary>
        public string IP_Address { get; set; }
        /// <summary>
        /// APP安裝機碼
        /// </summary>
        public string APP_RegistryKey { get; set; }

        /// <summary>
        /// 打卡類型代碼
        /// </summary>
        //public string CardCode { get; set; }
        /// <summary>
        /// 打卡類型名稱
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 經緯度座標
        /// </summary>
        public Location Coordinate { get; set; }
        /// <summary>
        /// 打卡開始時間
        /// </summary>
        public DateTime CardStart { get; set; }
        /// <summary>
        /// 打卡流程中時間
        /// </summary>
        public DateTime CardProcess { get; set; }
        /// <summary>
        /// 打卡送出時間
        /// </summary>
        public DateTime CardSend { get; set; }
        /// <summary>
        /// 個人因素
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// QRCdoe
        /// </summary>
        //public string QRCode { get; set; }
        /// <summary>
        /// 上傳照片 url
        /// </summary>
        public List<string> Images { get; set; }

    }
}
