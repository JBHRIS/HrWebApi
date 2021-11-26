using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareMessageVdb
    {
    }

    /// <summary>
    /// 顯示訊息條件
    /// </summary>
    public class ShareMessageConditions : DataConditions
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List< string> ListMessageTypeCode { get; set; }
        /// <summary>
        /// 處理狀態
        /// </summary>
        public List<string> ListHandleStatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareMessageConditions()
        {
            ListMessageTypeCode = new List<string>();
            ListMessageTypeCode.Add("0");
            ListMessageTypeCode.Add("1");
            ListMessageTypeCode.Add("2");
            ListMessageTypeCode.Add("3");
            ListMessageTypeCode.Add("9");

            ListHandleStatusCode = new List<string>();
            ListHandleStatusCode.Add("01");
            ListHandleStatusCode.Add("02");
            ListHandleStatusCode.Add("03");
        }
    }

    /// <summary>
    /// 顯示訊息
    /// </summary>
    public class ShareMessageRow : StandardDataRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public string MessageTypeCode { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string MessageTypeName { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 系統內容
        /// </summary>
        public string SystemContents { get; set; }
        /// <summary>
        /// 處理狀態
        /// </summary>
        public string HandleStatusCode { get; set; }
        /// <summary>
        /// 處理狀態
        /// </summary>
        public string HandleStatusName { get; set; }
        /// <summary>
        /// 程式名稱
        /// </summary>
        public string AppName { set; get; }
        /// <summary>
        /// Ip位置
        /// </summary>
        public string IpAddress { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public ShareMessageRow()
        {
            HandleStatusCode = "01";
        }
    }

    /// <summary>
    /// 儲存訊息
    /// </summary>
    public class ShareMessageSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存訊息資料
    /// </summary>
    public class ShareMessageSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareMessageRow> ListShareMessage { get; set; }
    }

    /// <summary>
    /// 新增訊息
    /// </summary>
    public class ShareMessageInsertResult : Message
    {

    }

    /// <summary>
    /// 新增訊息資料
    /// </summary>
    public class ShareMessageInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareMessageRow> ListShareMessage { get; set; }
    }

    /// <summary>
    /// 修改訊息
    /// </summary>
    public class ShareMessageUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改訊息資料
    /// </summary>
    public class ShareMessageUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareMessageRow> ListShareMessage { get; set; }
    }

    /// <summary>
    /// 刪除訊息
    /// </summary>
    public class ShareMessageDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除訊息資料
    /// </summary>
    public class ShareMessageDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareMessageRow> ListShareMessage { get; set; }
    }
}
