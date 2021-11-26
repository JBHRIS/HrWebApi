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
    public class ShareSendQueueVdb
    {
    }

    /// <summary>
    /// 顯示寄送條件
    /// </summary>
    public class ShareSendQueueConditions : DataConditions
    {
        /// <summary>
        /// 寄送類別代碼
        /// </summary>
        public List<string> ListSendTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareSendQueueConditions()
        {
            ListSendTypeCode = new List<string>();
        }
    }

    /// <summary>
    /// 顯示寄送
    /// </summary>
    public class ShareSendQueueRow : StandardDataRow
    {
        /// <summary>
        /// 寄送類別代碼
        /// </summary>
        public string SendTypeCode { get; set; }
        /// <summary>
        /// 寄送類別名稱
        /// </summary>
        public string SendTypeName { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string FromAddr { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string ToAddr { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        /// 副本
        /// </summary>
        public string ToAddrCopy { get; set; }
        /// <summary>
        /// 副本
        /// </summary>
        public string ToNameCopy { get; set; }
        /// <summary>
        /// 密
        /// </summary>
        public string ToAddrConfidential { get; set; }
        /// <summary>
        /// 密
        /// </summary>
        public string ToNameConfidential { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內文
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 寄送次數
        /// </summary>
        public int Retry { get; set; }
        /// <summary>
        /// 寄送成功
        /// </summary>
        public bool Sucess { get; set; }
        /// <summary>
        /// 暫停
        /// </summary>
        public bool Suspend { get; set; }
        /// <summary>
        /// 寄送時間
        /// </summary>
        public DateTime DateSend { get; set; }
    }

    /// <summary>
    /// 儲存寄送
    /// </summary>
    public class ShareSendQueueSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存寄送資料
    /// </summary>
    public class ShareSendQueueSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareSendQueueRow> ListShareSendQueue { get; set; }
    }

    /// <summary>
    /// 新增寄送
    /// </summary>
    public class ShareSendQueueInsertResult : Message
    {

    }

    /// <summary>
    /// 新增寄送資料
    /// </summary>
    public class ShareSendQueueInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareSendQueueRow> ListShareSendQueue { get; set; }
    }

    /// <summary>
    /// 修改寄送
    /// </summary>
    public class ShareSendQueueUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改寄送資料
    /// </summary>
    public class ShareSendQueueUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareSendQueueRow> ListShareSendQueue { get; set; }
    }

    /// <summary>
    /// 刪除寄送
    /// </summary>
    public class ShareSendQueueDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除寄送資料
    /// </summary>
    public class ShareSendQueueDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareSendQueueRow> ListShareSendQueue { get; set; }
    }
}
