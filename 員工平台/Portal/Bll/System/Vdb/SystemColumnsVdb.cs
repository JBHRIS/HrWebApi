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
    public class SystemColumnsVdb
    {
    }

    /// <summary>
    /// 顯示欄位設定條件
    /// </summary>
    public class SystemColumnsConditions : DataConditions
    {
        /// <summary>
        /// 資料表代碼
        /// </summary>
        public List<string> ListTablesCode { get; set; }
        /// <summary>
        /// 資料表代碼
        /// </summary>
        public string TablesCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemColumnsConditions()
        {
            ListTablesCode = new List<string>();
            TablesCode = "";
        }
    }

    /// <summary>
    /// 顯示欄位設定
    /// </summary>
    public class SystemColumnsRow : StandardDataRow
    {
        /// <summary>
        /// 資料表代碼
        /// </summary>
        public string TablesCode { get; set; }
        /// <summary>
        /// 資料表代碼
        /// </summary>
        public string TablesName { get; set; }
        /// <summary>
        /// 主鍵
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 敏感資料
        /// </summary>
        public bool IsSensitive { get; set; }
        /// <summary>
        /// 需要遮罩
        /// </summary>
        public bool NeedMask { get; set; }
        /// <summary>
        /// 預設值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 檢查代碼
        /// </summary>
        public bool CheckCode { get; set; }
        /// <summary>
        /// 關聯
        /// </summary>
        public string Related { get; set; }
        /// <summary>
        /// 允許修改
        /// </summary>
        public bool AllowUpdate { get; set; }
        /// <summary>
        /// 允許Null
        /// </summary>
        public bool AllowNull { get; set; }
        /// <summary>
        /// 允許空白
        /// </summary>
        public bool AllowEmpty { get; set; }
        /// <summary>
        /// 允許匯出
        /// </summary>
        public bool AllowExport { get; set; }
        /// <summary>
        /// 允許排序
        /// </summary>
        public bool AllowSort { get; set; }
        /// <summary>
        /// 欄位型態
        /// </summary>
        public string ColumnTypeCode { get; set; }
        /// <summary>
        /// 欄位型態
        /// </summary>
        public string ColumnTypeName { get; set; }
    }

    /// <summary>
    /// 儲存欄位設定
    /// </summary>
    public class SystemColumnsSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存欄位設定資料
    /// </summary>
    public class SystemColumnsSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemColumnsRow> ListSystemColumns { get; set; }
    }

    /// <summary>
    /// 新增欄位設定
    /// </summary>
    public class SystemColumnsInsertResult : Message
    {

    }

    /// <summary>
    /// 新增欄位設定資料
    /// </summary>
    public class SystemColumnsInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemColumnsRow> ListSystemColumns { get; set; }
    }

    /// <summary>
    /// 修改欄位設定
    /// </summary>
    public class SystemColumnsUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改欄位設定資料
    /// </summary>
    public class SystemColumnsUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemColumnsRow> ListSystemColumns { get; set; }
    }

    /// <summary>
    /// 刪除欄位設定
    /// </summary>
    public class SystemColumnsDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除欄位設定資料
    /// </summary>
    public class SystemColumnsDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemColumnsRow> ListSystemColumns { get; set; }
    }
}
