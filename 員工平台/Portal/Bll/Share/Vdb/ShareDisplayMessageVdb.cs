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
    public class ShareDisplayMessageVdb
    {
    }

    /// <summary>
    /// 顯示訊息條件
    /// </summary>
    public class ShareDisplayMessageConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string DisplayTypeCode { get; set; }
    }

    /// <summary>
    /// 顯示訊息
    /// </summary>
    public class ShareDisplayMessageRow : StandardDataRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public string DisplayTypeCode { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string DisplayTypeName { get; set; }
        /// <summary>
        /// 對應欄位名稱
        /// </summary>
        public string TitleContents { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareDisplayMessageRow()
        {
        }
    }

    /// <summary>
    /// 顯示訊息內容
    /// </summary>
    public class ShareDisplayMessageContentsRow
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 對應欄位名稱
        /// </summary>
        public string TitleContents { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Contents { get; set; }
    }

    /// <summary>
    /// 儲存顯示訊息
    /// </summary>
    public class ShareDisplayMessageSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存顯示訊息資料
    /// </summary>
    public class ShareDisplayMessageSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDisplayMessageRow> ListShareDisplayMessage { get; set; }
    }

    /// <summary>
    /// 新增顯示訊息
    /// </summary>
    public class ShareDisplayMessageInsertResult : Message
    {

    }

    /// <summary>
    /// 新增顯示訊息資料
    /// </summary>
    public class ShareDisplayMessageInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDisplayMessageRow> ListShareDisplayMessage { get; set; }
    }

    /// <summary>
    /// 修改顯示訊息
    /// </summary>
    public class ShareDisplayMessageUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改顯示訊息資料
    /// </summary>
    public class ShareDisplayMessageUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDisplayMessageRow> ListShareDisplayMessage { get; set; }
    }

    /// <summary>
    /// 刪除顯示訊息
    /// </summary>
    public class ShareDisplayMessageDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除顯示訊息資料
    /// </summary>
    public class ShareDisplayMessageDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDisplayMessageRow> ListShareDisplayMessage { get; set; }
    }
}
