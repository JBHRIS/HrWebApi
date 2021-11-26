using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.System.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserNotifyVdb
    {
    }
    /// <summary>
    /// 顯示帳號通知條件
    /// </summary>
    /// 
    public class SystemUserNotifyConditions : DataConditions
    {
        /// <summary>
        /// 被通知者
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 通知者
        /// </summary>
        public string UserCodeSend { get; set; }
        /// <summary>
        /// 判斷日期為今日
        /// </summary>
        public bool UseDate { get; set; }
        /// <summary>
        /// 通知類別
        /// </summary>
        public List<string> ListNotifyTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserNotifyConditions()
        {
            UserCode = "";
            UserCodeSend = "";
            UseDate = true;
            ListNotifyTypeCode = new List<string>();
        }
    }

    /// <summary>
    /// 顯示帳號通知
    /// </summary>
    public class SystemUserNotifyRow : StandardDataRow
    {
        /// <summary>
        /// 被通知者
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 通知者
        /// </summary>
        public string UserCodeSend { get; set; }
        /// <summary>
        /// 通知者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 通知類別
        /// </summary>
        public string NotifyTypeCode { get; set; }
        /// <summary>
        /// 通知類別
        /// </summary>
        public string NotifyTypeName { get; set; }
        /// <summary>
        /// 通知程式
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 程式主鍵
        /// </summary>
        public string AppCode { get; set; }
        /// <summary>
        /// 標題內容
        /// </summary>
        public string TitleContents { get; set; }
        /// <summary>
        /// 通知內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 已讀取
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 已讀取HtmlTag
        /// </summary>
        public string IsReadHtmlTag { get; set; }
        /// <summary>
        /// 讀取連結
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// 儲存帳號通知
    /// </summary>
    public class SystemUserNotifySaveResult : Message
    {

    }

    /// <summary>
    /// 儲存帳號通知資料
    /// </summary>
    public class SystemUserNotifySaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserNotifyRow> ListSystemUserNotify { get; set; }
    }

    /// <summary>
    /// 新增帳號通知
    /// </summary>
    public class SystemUserNotifyInsertResult : Message
    {

    }

    /// <summary>
    /// 新增帳號通知資料
    /// </summary>
    public class SystemUserNotifyInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserNotifyRow> ListSystemUserNotify { get; set; }
    }

    /// <summary>
    /// 修改帳號通知
    /// </summary>
    public class SystemUserNotifyUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改帳號通知資料
    /// </summary>
    public class SystemUserNotifyUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserNotifyRow> ListSystemUserNotify { get; set; }
    }

    /// <summary>
    /// 刪除帳號通知
    /// </summary>
    public class SystemUserNotifyDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除帳號通知資料
    /// </summary>
    public class SystemUserNotifyDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserNotifyRow> ListSystemUserNotify { get; set; }
    }
}