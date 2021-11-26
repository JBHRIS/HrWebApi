using JBAppService.Api.Dto.FencePoints;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class CardAppDetailsDto
    {
        /// <summary>
        /// 案件流水號
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ADate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ON_Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsForgetCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
        ///// <summary>
        ///// 打卡類型代碼
        ///// </summary>
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
        /// 上傳照片 url
        /// </summary>
        public List<string> Images { get; set; }

    }


    public class SaveCardAppDetailsDto
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 電子圍離
        /// </summary>
        //public string Fence { get; set; }
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
        /// 打卡類型
        /// </summary>
        public string CardTypeCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// QRCode 碼
        /// </summary>
        public string QRCode { get; set;  }
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
        /// 上傳照片 GUID
        /// </summary>
        public List<string> UploadImageGUID { get; set; }


        /// <summary>
        /// 照片檔案
        /// </summary>
        //List<IFormFile> Images { get; set; }


    }
}
