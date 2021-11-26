using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareUploadVdb
    {
    }

    /// <summary>
    /// 顯示檔案管理條件
    /// </summary>
    public class ShareUploadConditions : DataConditions
    {
        /// <summary>
        /// 是否要取得圖片檔
        /// </summary>
        public bool UseBlob { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public List<string> ListCode { get; set; }
        /// <summary>
        /// Key1
        /// </summary>
        public string Key1 { get; set; }
        /// <summary>
        /// Key1
        /// </summary>
        public List<string> ListKey1 { get; set; }
        /// <summary>
        /// Key2
        /// </summary>
        public string Key2 { get; set; }
        /// <summary>
        /// Key3
        /// </summary>
        public string Key3 { get; set; }
        /// <summary>
        /// Sort
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareUploadConditions()
        {
            UseBlob = true;
            ListCode = new List<string>();
            Key1 = "";
            ListKey1 = new List<string>();
            Key2 = "";
            Key3 = "";
            Sort = 0;
        }
    }

    /// <summary>
    /// 顯示檔案管理
    /// </summary>
    public class ShareUploadRow : StandardDataRow
    {
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
        /// 檔案名稱
        /// </summary>
        public string UploadName { get; set; }
        /// <summary>
        /// 加密後的檔案名稱
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 二進位存放資料庫
        /// </summary>
        public Binary Blob { get; set; }
        /// <summary>
        /// ImageUrl
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 檔案型態
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 檔案大小
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 系統專用
        /// </summary>
        public bool SystemUse { get; set; }
    }

    /// <summary>
    /// 儲存檔案管理
    /// </summary>
    public class ShareUploadSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存檔案管理資料
    /// </summary>
    public class ShareUploadSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUploadRow> ListShareUpload { get; set; }
    }

    /// <summary>
    /// 新增檔案管理
    /// </summary>
    public class ShareUploadInsertResult : Message
    {

    }

    /// <summary>
    /// 新增檔案管理資料
    /// </summary>
    public class ShareUploadInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUploadRow> ListShareUpload { get; set; }
    }

    /// <summary>
    /// 修改檔案管理
    /// </summary>
    public class ShareUploadUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改檔案管理資料
    /// </summary>
    public class ShareUploadUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUploadRow> ListShareUpload { get; set; }
    }

    /// <summary>
    /// 刪除檔案管理
    /// </summary>
    public class ShareUploadDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除檔案管理資料
    /// </summary>
    public class ShareUploadDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareUploadRow> ListShareUpload { get; set; }
    }
}
