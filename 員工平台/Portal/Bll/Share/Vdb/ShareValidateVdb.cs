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
    class ShareValidateVdb
    {
    }

    /// <summary>
    /// 驗証條件
    /// </summary>
    public class ShareValidateConditions : DataConditions
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareValidateConditions()
        {
        }
    }

    /// <summary>
    /// 驗証
    /// </summary>
    public class ShareValidateRow : StandardDataRow
    {
        /// <summary>
        /// 參數
        /// </summary>
        public string Param { get; set; }
        /// <summary>
        /// 開啟時間
        /// </summary>
        public DateTime DateOpen { get; set; }
    }

    /// <summary>
    /// 儲存驗証
    /// </summary>
    public class ShareValidateSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存驗証資料
    /// </summary>
    public class ShareValidateSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareValidateRow> ListShareValidate { get; set; }
    }

    /// <summary>
    /// 新增驗証
    /// </summary>
    public class ShareValidateInsertResult : Message
    {

    }

    /// <summary>
    /// 新增驗証資料
    /// </summary>
    public class ShareValidateInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareValidateRow> ListShareValidate { get; set; }
    }

    /// <summary>
    /// 修改驗証
    /// </summary>
    public class ShareValidateUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改驗証資料
    /// </summary>
    public class ShareValidateUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareValidateRow> ListShareValidate { get; set; }
    }

    /// <summary>
    /// 刪除驗証
    /// </summary>
    public class ShareValidateDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除驗証資料
    /// </summary>
    public class ShareValidateDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareValidateRow> ListShareValidate { get; set; }
    }
}
