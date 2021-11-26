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
    public class ShareCodeVdb
    {
    }

    /// <summary>
    /// 共用代碼條件
    /// </summary>
    public class ShareCodeConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareCodeConditions()
        {
            GroupCode = "";
        }
    }

    /// <summary>
    /// 共用代碼
    /// </summary>
    public class ShareCodeRow : StandardDataRow
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
    public class ShareCodeSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存共用代碼資料
    /// </summary>
    public class ShareCodeSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 新增共用代碼
    /// </summary>
    public class ShareCodeInsertResult : Message
    {

    }

    /// <summary>
    /// 新增共用代碼資料
    /// </summary>
    public class ShareCodeInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 修改共用代碼
    /// </summary>
    public class ShareCodeUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改共用代碼資料
    /// </summary>
    public class ShareCodeUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }

    /// <summary>
    /// 刪除共用代碼
    /// </summary>
    public class ShareCodeDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除共用代碼資料
    /// </summary>
    public class ShareCodeDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCodeRow> ListShareCode { get; set; }
    }
}
