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
    public class ShareUserVdb
    {
    }

    /// <summary>
    /// 共用代碼條件
    /// </summary>
    public class ShareUserConditions : DataConditions
    {
        
        public string CompanyId { get; set; }
       
        public ShareUserConditions()
        {
            CompanyId = "";
        }
    }

    /// <summary>
    /// 共用代碼
    /// </summary>
    public class ShareUserRow : StandardDataRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// CompanyId
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// AccountCode
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// RoleKey
        /// </summary>
        public int RoleKey { get; set; }
        /// <summary>
        ///DateA
        /// </summary>
        public DateTime? DateA { get; set; }
        /// <summary>
        ///DateD
        /// </summary>
        public DateTime? DateD { get; set; }
    }

    /// <summary>
    /// 儲存共用代碼
    /// </summary>
    public class ShareUserSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存共用代碼資料
    /// </summary>
    public class ShareUserSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 新增共用代碼
    /// </summary>
    public class ShareUserInsertResult : Message
    {

    }

    /// <summary>
    /// 新增共用代碼資料
    /// </summary>
    public class ShareUserInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 修改共用代碼
    /// </summary>
    public class ShareUserUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改共用代碼資料
    /// </summary>
    public class ShareUserUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUserRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 刪除共用代碼
    /// </summary>
    public class ShareUserDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除共用代碼資料
    /// </summary>
    public class ShareUserDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUserRow> ListShareCode { get; set; }
    }
}
