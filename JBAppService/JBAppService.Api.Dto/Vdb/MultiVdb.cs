using System;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiVdb
    {
    }

    /// <summary>
    /// 訊息
    /// </summary>
    public class MessageRow
    {
        /// <summary>
        /// 訊息代碼
        /// </summary>
        public string MessageCode { set; get; }
        /// <summary>
        /// 訊息內容
        /// </summary>
        public string MessageContent { set; get; }
    }

    /// <summary>
    /// 錯誤訊息
    /// </summary>
    public class ErrorCollectionRow
    {
        /// <summary>
        /// 訊息類型
        /// </summary>
        public string ErrorType { set; get; }
        /// <summary>
        /// 訊息代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 說明
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { set; get; }
    }

    /// <summary>
    /// TextValueRow
    /// </summary>
    public class TextValueRow
    {
        /// <summary>
        /// Text
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { set; get; }
    }

    /// <summary>
    /// MonthRow
    /// </summary>
    public class MonthRow
    {
        /// <summary>
        /// Group
        /// </summary>
        public int Group { set; get; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { set; get; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
    }

    /// <summary>
    /// TwoDateTime
    /// </summary>
    public class TwoDateTime : MessageRow
    {
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { set; get; }
    }

    /// <summary>
    /// 檔案
    /// </summary>
    public class UploadFileRow
    {
        /// <summary>
        /// ID
        /// </summary>
        public int UploadID { get; set; }
        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string UploadName { get; set; }
        /// <summary>
        /// 伺服器檔案名稱
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 檔案說明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 二進位
        /// </summary>
        public string Blob { get; set; }
        /// <summary>
        /// 型態
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }
    }

    /// <summary>
    /// 檔案上傳相關資訊
    /// </summary>
    public class UploadFileSetInfoRow
    {
        /// <summary>
        /// 是否需要驗証
        /// </summary>
        public bool UploadValid { get; set; }
        /// <summary>
        /// 上傳檔案路徑
        /// </summary>
        public string UploadPath { get; set; }
        /// <summary>
        /// Domain
        /// </summary>
        public string UploadDomain { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        public string UploadUserID { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string UploadPassword { get; set; }
    }
}
