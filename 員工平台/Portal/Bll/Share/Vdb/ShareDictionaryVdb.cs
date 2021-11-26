using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    public class ShareDictionaryVdb
    {
    }

    /// <summary>
    /// 共用代碼條件
    /// </summary>
    public class ShareDictionaryConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public List<string> ListGroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareDictionaryConditions()
        {
            ListGroupCode = new List<string>();
        }
    }

    /// <summary>
    /// 共用代碼
    /// </summary>
    public class ShareDictionaryRow : StandardDataRow
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// Key1
        /// </summary>
        public string Name1 { get; set; }
        /// <summary>
        /// Key2
        /// </summary>
        public string Name2 { get; set; }
        /// <summary>
        /// Key3
        /// </summary>
        public string Name3 { get; set; }
    }

    /// <summary>
    /// 儲存共用代碼
    /// </summary>
    public class ShareDictionarySaveResult : Message
    {

    }

    /// <summary>
    /// 儲存共用代碼資料
    /// </summary>
    public class ShareDictionarySaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDictionaryRow> ListShareDictionary { get; set; }
    }

    /// <summary>
    /// 新增共用代碼
    /// </summary>
    public class ShareDictionaryInsertResult : Message
    {

    }

    /// <summary>
    /// 新增共用代碼資料
    /// </summary>
    public class ShareDictionaryInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDictionaryRow> ListShareDictionary { get; set; }
    }

    /// <summary>
    /// 修改共用代碼
    /// </summary>
    public class ShareDictionaryUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改共用代碼資料
    /// </summary>
    public class ShareDictionaryUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDictionaryRow> ListShareDictionary { get; set; }
    }

    /// <summary>
    /// 刪除共用代碼
    /// </summary>
    public class ShareDictionaryDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除共用代碼資料
    /// </summary>
    public class ShareDictionaryDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDictionaryRow> ListShareDictionary { get; set; }
    }
}
