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
    public class SystemUserInfoVdb
    {
    }

    /// <summary>
    /// 顯示帳號管理資訊條件
    /// </summary>
    public class SystemUserInfoConditions : DataConditions
    {
        /// <summary>
        /// 使用者代碼
        /// </summary>
        public List<string> ListUserCode { get; set; }
        /// <summary>
        /// 使用者代碼
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserInfoConditions()
        {
            ListUserCode = new List<string>();
            UserCode = "";
        }
    }

    /// <summary>
    /// 顯示帳號管理資訊
    /// </summary>
    public class SystemUserInfoRow : StandardDataRow
    {
        /// <summary>
        /// 使用者代碼
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 真實姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 匿名
        /// </summary>
        public string AnonymousName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份證
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 行動電話
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 行動電話生效日
        /// </summary>
        public DateTime TelA { get; set; }
        /// <summary>
        /// 行動電話失效日
        /// </summary>
        public DateTime TelD { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 信箱生效日
        /// </summary>
        public DateTime EmailA { get; set; }
        /// <summary>
        /// 信箱失效日
        /// </summary>
        public DateTime EmailD { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserInfoRow()
        {
            UserName = "";
            AnonymousName = "";
            Birthday = new DateTime(1900, 1, 1).Date;
            CardId = "";
            Address = "";
            Tel = "";
            TelA = new DateTime(1900, 1, 1).Date;
            TelD = new DateTime(1900, 1, 1).Date;
            Email = "";
            EmailA = new DateTime(1900, 1, 1).Date;
            EmailD = new DateTime(1900, 1, 1).Date;
            Sex = "9";
        }
    }

    /// <summary>
    /// 儲存帳號管理資訊
    /// </summary>
    public class SystemUserInfoSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存帳號管理資訊資料
    /// </summary>
    public class SystemUserInfoSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserInfoRow> ListSystemUserInfo { get; set; }
    }

    /// <summary>
    /// 新增帳號管理資訊
    /// </summary>
    public class SystemUserInfoInsertResult : Message
    {

    }

    /// <summary>
    /// 新增帳號管理資訊資料
    /// </summary>
    public class SystemUserInfoInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserInfoRow> ListSystemUserInfo { get; set; }
    }

    /// <summary>
    /// 修改帳號管理資訊
    /// </summary>
    public class SystemUserInfoUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改帳號管理資訊資料
    /// </summary>
    public class SystemUserInfoUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserInfoRow> ListSystemUserInfo { get; set; }
    }

    /// <summary>
    /// 刪除帳號管理資訊
    /// </summary>
    public class SystemUserInfoDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除帳號管理資訊資料
    /// </summary>
    public class SystemUserInfoDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserInfoRow> ListSystemUserInfo { get; set; }
    }
}
