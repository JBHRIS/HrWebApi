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
    public class ShareDefaultVdb
    {
    }

    /// <summary>
    /// 系統預設值條件
    /// </summary>
    public class ShareDefaultConditions : DataConditions
    {
        /// <summary>
        /// 群組代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareDefaultConditions()
        {
            GroupCode = "";
        }
    }

    /// <summary>
    /// 系統預設值
    /// </summary>
    public class ShareDefaultRow : StandardDataRow
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
        /// <summary>
        /// 系統專用(不可刪或修改)
        /// </summary>
        public bool SystemUse { get; set; }
    }

    /// <summary>
    /// 系統共用參數
    /// </summary>
    public class DefaultSystemRow
    {
        /// <summary>
        /// 維護
        /// </summary>
        public bool Maintain { get; set; }
        /// <summary>
        /// 測試
        /// </summary>
        public bool Test { get; set; }
        /// <summary>
        /// 資料遮罩
        /// </summary>
        public bool DataMask { get; set; }
        /// <summary>
        /// 萬用帳號
        /// </summary>
        public string UniversalAccountCode { get; set; }
        /// <summary>
        /// 萬用密碼
        /// </summary>
        public string UniversalAccountPassword { get; set; }
        /// <summary>
        /// 系統管理者信箱
        /// </summary>
        public List<string> AdminMail { get; set; }
        /// <summary>
        /// 測試信箱
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// 測試帳號
        /// </summary>
        public string TestAccountCode { get; set; }
        /// <summary>
        /// 前端登入網頁
        /// </summary>
        public string LoginPage { get; set; }
        /// <summary>
        /// 前端主頁
        /// </summary>
        public string MainPage { get; set; }
        /// <summary>
        /// 無權限導回網址
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// 網址驗証分鐘數
        /// </summary>
        public int UrlValidMinutes { get; set; }
        /// <summary>
        /// 資料暫存
        /// </summary>
        public bool DataCache { get; set; }
        /// <summary>
        /// 公司代碼---影響程式判斷
        /// </summary>
        public string CompanyId { get; set; }
    }

    /// <summary>
    /// 郵件
    /// </summary>
    public class DefaultMailRow
    {
        /// <summary>
        /// 郵件主機的位置
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 驗證
        /// </summary>
        public bool IsNeedCredentials { get; set; }
        /// <summary>
        /// 驗證Ssl
        /// </summary>
        public bool IsNeedSsl { get; set; }
        /// <summary>
        /// 寄件者
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 寄件者名稱
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 啟用測試模式
        /// </summary>
        public bool EnableTestMode { get; set; }
        /// <summary>
        /// 測試信箱
        /// </summary>
        public List<string> TestMail { get; set; }
        /// <summary>
        /// 停止發信
        /// </summary>
        public bool DisableSend { get; set; }
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 傳輸模式
        /// </summary>
        public string CredentialsType { get; set; }
        /// <summary>
        /// 最大重試次數
        /// </summary>
        public int MaxRetry { get; set; }
        /// <summary>
        /// 重試延遲(min)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容標頭
        /// </summary>
        public string BodyHead { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string BodyContent { get; set; }
        /// <summary>
        /// 內容結尾
        /// </summary>
        public string BodyFoot { get; set; }
    }

    /// <summary>
    /// OAuth2參數
    /// </summary>
    public class DefaultOAuth2Row
    {
        /// <summary>
        /// 權限範圍
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 本網站認證網頁
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// 本網站綁定網頁
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// OAuth2帳號
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// OAuth2密碼
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// 取得Token網頁
        /// </summary>
        public string TokenUrl { get; set; }
        /// <summary>
        /// 取得UserInfo網頁
        /// </summary>
        public string UserInfoUrl { get; set; }
        /// <summary>
        /// 取得認證登入網頁
        /// </summary>
        public string AuthUrl { get; set; }
    }

    /// <summary>
    /// OAuth2Google參數
    /// </summary>
    public class DefaultOAuth2GoogleRow : DefaultOAuth2Row
    {

    }

    /// <summary>
    /// OAuth2Facebook參數
    /// </summary>
    public class DefaultOAuth2FacebookRow : DefaultOAuth2Row
    {

    }

    public class DefaultOAuth2LineRow : DefaultOAuth2Row
    {

    }

    /// <summary>
    /// 商品共用參數
    /// </summary>
    public class DefaultArticleRow
    {
        /// <summary>
        /// 商加加入筆數上限
        /// </summary>
        public int ItemsAddCountMax { get; set; }
    }

    /// <summary>
    /// 儲存系統預設值代碼
    /// </summary>
    public class ShareDefaultSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存系統預設值代碼資料
    /// </summary>
    public class ShareDefaultSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDefaultRow> ListShareDefault { get; set; }
    }

    /// <summary>
    /// 新增系統預設值代碼
    /// </summary>
    public class ShareDefaultInsertResult : Message
    {

    }

    /// <summary>
    /// 新增系統預設值代碼資料
    /// </summary>
    public class ShareDefaultInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDefaultRow> ListShareDefault { get; set; }
    }

    /// <summary>
    /// 修改系統預設值代碼
    /// </summary>
    public class ShareDefaultUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改系統預設值代碼資料
    /// </summary>
    public class ShareDefaultUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDefaultRow> ListShareDefault { get; set; }
    }

    /// <summary>
    /// 刪除系統預設值代碼
    /// </summary>
    public class ShareDefaultDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除系統預設值代碼資料
    /// </summary>
    public class ShareDefaultDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareDefaultRow> ListShareDefault { get; set; }
    }
}
