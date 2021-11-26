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
    public class ShareUserGroupVdb
    {
    }

    /// <summary>
    /// 共用代碼條件
    /// </summary>
    public class ShareUserGroupConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareUserGroupConditions()
        {
            GroupCode = "";
        }
    }

    /// <summary>
    /// 共用代碼
    /// </summary>
    public class ShareUserGroupRow : StandardDataRow
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// Key1
        /// </summary>
        public string Key1 { get; set; }
        /// <summary>
        /// Key2
        /// </summary>
        public string Key2 { get; set; }
        /// <summary>
        /// Key3
        /// </summary>
        public string Key3 { get; set; }
        /// <summary>
        /// 備用1
        /// </summary>
        public string Column1 { get; set; }
        /// <summary>
        /// 備用2
        /// </summary>
        public string Column2 { get; set; }
        /// <summary>
        /// 備用3
        /// </summary>
        public string Column3 { get; set; }
        /// <summary>
        /// 系統專用(不可刪或修改)
        /// </summary>
        public bool SystemUse { get; set; }
    }

    /// <summary>
    /// 儲存共用代碼
    /// </summary>
    public class ShareUserGroupSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存共用代碼資料
    /// </summary>
    public class ShareUserGroupSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 新增共用代碼
    /// </summary>
    public class ShareUserGroupInsertResult : Message
    {

    }

    /// <summary>
    /// 新增共用代碼資料
    /// </summary>
    public class ShareUserGroupInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 修改共用代碼
    /// </summary>
    public class ShareUserGroupUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改共用代碼資料
    /// </summary>
    public class ShareUserGroupUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUserGroupRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 刪除共用代碼
    /// </summary>
    public class ShareUserGroupDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除共用代碼資料
    /// </summary>
    public class ShareUserGroupDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUserGroupRow> ListShareCode { get; set; }
    }
}
