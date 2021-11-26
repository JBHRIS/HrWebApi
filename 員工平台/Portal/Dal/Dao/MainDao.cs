using Bll;
using Bll.Share.Vdb;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class MainDao
    {
        /// <summary>
        /// 預設日期
        /// </summary>
        public DateTime _DefDate = new DateTime(1900, 1, 1).Date;

        /// <summary>
        /// 最小日期
        /// </summary>
        public DateTime _MinDate = new DateTime(1900, 1, 1).Date;

        /// <summary>
        /// 最大日期
        /// </summary>
        public DateTime _MaxDate = new DateTime(2099, 12, 31).Date;

        /// <summary>
        /// 現在日期
        /// </summary>
        public DateTime _NowDate = DateTime.Now;

        /// <summary>
        /// 現在日期
        /// </summary>
        public DateTime _NowDateTime = DateTime.Now;

        /// <summary>
        /// 系統代碼
        /// </summary>
        public string _SystemCode = "Performance";

        /// <summary>
        /// 
        /// </summary>
        public dcShareDataContext dcShare;

        /// <summary>
        /// 
        /// </summary>
        public MainDao() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public MainDao(IDbConnection conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public MainDao(string ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public MainDao(dcShareDataContext dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 寫記錄
        /// </summary>
        /// <param name="MessageTypeCode">0.訊息,1.提醒,2.警告,3.錯誤,9.其它</param>
        /// <param name="Contents">訊息內容</param>
        /// <param name="SystemContents">例外內容</param>
        /// <param name="AppName">應用程式</param>
        /// <param name="IpAddress">ip</param>
        /// <param name="InsertMan">輸入者</param>
        /// <returns>ShareMessageInsertResult</returns>
        public List<ShareMessageInsertResult> MessageLog(string MessageTypeCode, string Contents, string SystemContents, string AppName, string IpAddress, string InsertMan)
        {
            var rShareMessage = new ShareMessageInsertRow();
            var ListShareMessage = new List<ShareMessageRow>();
            var ItemShareMessage = new ShareMessageRow();
            ItemShareMessage.MessageTypeCode = MessageTypeCode;
            ItemShareMessage.Contents = Contents;
            ItemShareMessage.SystemContents = SystemContents;
            ListShareMessage.Add(ItemShareMessage);
            rShareMessage.ListShareMessage = ListShareMessage;
            rShareMessage.AppName = AppName;
            rShareMessage.IpAddress = IpAddress;
            rShareMessage.InsertMan = InsertMan;


            ShareMessageDao oShareMessage = new ShareMessageDao(dcShare);
            var Vdb = oShareMessage.ShareMessageInsert(rShareMessage);

            return Vdb;
        }

        /// <summary>
        /// 取得顯示訊息內容(多筆)
        /// </summary>
        /// <param name="ListCode">訊息代碼</param>
        /// <returns>List ShareDisplayMessageContentsRow</returns>
        public List<ShareDisplayMessageContentsRow> MessageShow(List<string> ListCode)
        {
            var oShareDisplayMessage = new ShareDisplayMessageDao(dcShare);
            var Vdb = oShareDisplayMessage.GetShareDisplayMessageContents(ListCode);

            return Vdb;
        }

        /// <summary>
        /// 取得顯示訊息內容(單筆)
        /// </summary>
        /// <param name="Code">訊息代碼</param>
        /// <returns>ShareDisplayMessageContentsRow</returns>
        public ShareDisplayMessageContentsRow MessageShow(string Code)
        {
            var oShareDisplayMessage = new ShareDisplayMessageDao(dcShare);
            var Vdb = oShareDisplayMessage.GetShareDisplayMessageContents(Code);

            return Vdb;
        }

        /// <summary>
        /// 取得共用代碼
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <param name="Key1"></param>
        /// <param name="Key2"></param>
        /// <param name="Key3"></param>
        /// <returns>List NameCodeRow</returns>
        public List<NameCodeRow> ShareCodeNameCode(string GroupCode = "", string Key1 = "", string Key2 = "", string Key3 = "")
        {
            var oShareCode = new ShareCodeDao(dcShare);
            var Vdb = oShareCode.GetNameCode(GroupCode, Key1, Key2, Key3);

            return Vdb;
        }

        /// <summary>
        /// 取得共用代碼
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <param name="Key1"></param>
        /// <param name="Key2"></param>
        /// <param name="Key3"></param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> ShareCodeTextValue(string GroupCode = "", string Key1 = "", string Key2 = "", string Key3 = "")
        {
            var oShareCode = new ShareCodeDao(dcShare);
            var Vdb = oShareCode.GetTextValue(GroupCode, Key1, Key2, Key3);

            return Vdb;
        }
    }
}