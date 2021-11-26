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
    public class ShareCompanyVdb
    {
    }

    /// <summary>
    /// 公司預設值條件
    /// </summary>
    public class ShareCompanyConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareCompanyConditions()
        {
            GroupCode = "";
        }
    }

    /// <summary>
    /// 公司預設值
    /// </summary>
    public class ShareCompanyRow : StandardDataRow
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// 對應欄位名稱
        /// </summary>
        public string FieldKey { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string FieldValue { get; set; }
        /// <summary>
        /// 欄位型態
        /// </summary>
        public string ColumnTypeCode { get; set; }
        /// <summary>
        /// 欄位型態
        /// </summary>
        public string ColumnTypeName { get; set; }
        /// <summary>
        /// 輸入型態
        /// </summary>
        public string FormTypeCode { get; set; }
        /// <summary>
        /// 輸入型態
        /// </summary>
        public string FormTypeName { get; set; }
    }

    /// <summary>
    /// 公司參數
    /// </summary>
    public class CompanySettingRow
    {
        /// <summary>
        /// 公司代碼
        /// </summary>
        public string AccountCode { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登入圖片檔名
        /// </summary>
        public string FileNameLoginPage { get; set; }
        /// <summary>
        /// 選單上圖片檔名
        /// </summary>
        public string FileNameMenuTop { get; set; }
        /// <summary>
        /// 網站Ico檔名
        /// </summary>
        public string FileNameSiteIco { get; set; }
        /// <summary>
        /// HR系統Api路徑
        /// </summary>
        public string ApiHr { get; set; }
        /// <summary>
        /// Flow系統Api路徑
        /// </summary>
        public string ApiFlow { get; set; }
        /// <summary>
        /// HrConn
        /// </summary>
        public string ConnHr { get; set; }
        /// <summary>
        /// FlowConn
        /// </summary>
        public string ConnFlow { get; set; }
        /// <summary>
        /// HrApiConnection
        /// </summary>
        public string HrApiConnection { get; set; }
        /// <summary>
        /// App設定檔DB的連線字串
        /// </summary>
        public string ConnApp { get; set; }
    }

    /// <summary>
    /// 儲存公司預設值代碼
    /// </summary>
    public class ShareCompanySaveResult : Message
    {

    }

    /// <summary>
    /// 儲存公司預設值代碼資料
    /// </summary>
    public class ShareCompanySaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCompanyRow> ListShareCompany { get; set; }
    }

    /// <summary>
    /// 新增公司預設值代碼
    /// </summary>
    public class ShareCompanyInsertResult : Message
    {

    }

    /// <summary>
    /// 新增公司預設值代碼資料
    /// </summary>
    public class ShareCompanyInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCompanyRow> ListShareCompany { get; set; }
    }

    /// <summary>
    /// 修改公司預設值代碼
    /// </summary>
    public class ShareCompanyUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改公司預設值代碼資料
    /// </summary>
    public class ShareCompanyUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCompanyRow> ListShareCompany { get; set; }
    }

    /// <summary>
    /// 刪除公司預設值代碼
    /// </summary>
    public class ShareCompanyDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除公司預設值代碼資料
    /// </summary>
    public class ShareCompanyDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareCompanyRow> ListShareCompany { get; set; }
    }
}
