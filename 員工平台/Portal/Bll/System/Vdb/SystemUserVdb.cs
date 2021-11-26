using Bll.Share.Vdb;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.System.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserVdb
    {
    }

    /// <summary>
    /// 顯示帳號管理條件
    /// </summary>
    public class SystemUserConditions : DataConditions
    {
        /// <summary>
        /// 是否要載入資訊資料
        /// </summary>
        public bool UseInfo { get; set; }
        /// <summary>
        /// 是否要取得圖片檔
        /// </summary>
        public bool UseBlob { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserConditions()
        {
            UseInfo = false;
            UseBlob = false;
        }
    }

    /// <summary>
    /// 顯示帳號管理
    /// </summary>
    public class SystemUserRow : StandardDataRow
    {
        /// <summary>
        /// 公司別
        /// </summary>
        public string CompnayId { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string AccountCode { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string AccountPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MoneyPassword { get; set; }
        /// <summary>
        /// 權限代碼(總合)
        /// </summary>
        public int RoleKey { get; set; }
        /// <summary>
        /// 註冊過(非第三方)
        /// </summary>
        public bool IsRegistered { get; set; }
        /// <summary>
        /// 帳號管理資訊
        /// </summary>
        public SystemUserInfoRow SystemUserInfo { get; set; }
        /// <summary>
        /// 檔案管理代碼
        /// </summary>
        public string ShareUploadCode { set; get; }
        /// <summary>
        /// 二進位存放資料庫
        /// </summary>
        public Binary ShareUploadBlob { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserRow()
        {
            MoneyPassword = "";
            RoleKey = 64;
            IsRegistered = true;
            SystemUserInfo = new SystemUserInfoRow();
            ShareUploadCode = "";
            ShareUploadBlob = null;
        }
    }

    public class UserRow 
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string AccountCode { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public List< string> ListAccountPassword { get; set; }
        /// <summary>
        /// 權限代碼(總合)
        /// </summary>
        public int RoleKey { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public UserRow()
        {
            AccountName = "";
            RoleKey = 64;
        }
    }

    /// <summary>
    /// 儲存帳號管理
    /// </summary>
    public class SystemUserSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存帳號管理資料
    /// </summary>
    public class SystemUserSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserRow> ListSystemUser { get; set; }
    }

    /// <summary>
    /// 新增帳號管理
    /// </summary>
    public class SystemUserInsertResult : Message
    {

    }

    /// <summary>
    /// 新增帳號管理資料
    /// </summary>
    public class SystemUserInsertRow : InsertRow
    {
        /// <summary>
        /// 帳號管理
        /// </summary>
        public List<SystemUserRow> ListSystemUser { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SystemUserInsertSignUpRow : InsertRow
    {
        /// <summary>
        /// 帳號管理
        /// </summary>
        public SystemUserRow SystemUser { get; set; }
        /// <summary>
        /// 帳號管理資訊
        /// </summary>
        public SystemUserInfoRow SystemUserInfo { get; set; }
        /// <summary>
        /// 第三方連結
        /// </summary>
        public SystemUserAccountBindRow SystemUserAccountBind { get; set; }
        /// <summary>
        /// 儲存個人圖片
        /// </summary>
        public ShareUploadRow ShareUpload { get; set; }
    }

    /// <summary>
    /// 修改帳號管理
    /// </summary>
    public class SystemUserUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改帳號管理資料
    /// </summary>
    public class SystemUserUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserRow> ListSystemUser { get; set; }
    }

    /// <summary>
    /// 刪除帳號管理
    /// </summary>
    public class SystemUserDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除帳號管理資料
    /// </summary>
    public class SystemUserDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserRow> ListSystemUser { get; set; }
    }
}
