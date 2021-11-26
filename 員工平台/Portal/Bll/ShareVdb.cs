using Bll.Share.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareVdb
    {
        
    }

    /// <summary>
    /// 資料共用條件
    /// </summary>
    public class DataConditions
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 資料狀態
        /// </summary>
        public List<string> ListStatus { set; get; }
        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { set; get; }
        /// <summary>
        /// 顯示筆數
        /// </summary>
        public int Take { set; get; }
        /// <summary>
        /// 重叫次數
        /// </summary>
        public int ReCallFrequencyMax { set; get; }
        /// <summary>
        /// 重叫間隔時間(秒)
        /// </summary>
        public int ReCallIntervalSec { set; get; }
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { set; get; }
        /// <summary>
        /// RefreshToken
        /// </summary>
        public string RefreshToken { set; get; }
        /// <summary>
        /// 忽略驗証日期
        /// </summary>
        public bool IgnoreValidDate { set; get; }
        /// <summary>
        /// 系統代碼
        /// </summary>
        public string SystemCode { set; get; }
        /// <summary>
        /// 公司參數
        /// </summary>
        public CompanySettingRow CompanySetting;
        /// <summary>
        /// 
        /// </summary>
        public DataConditions()
        {
            Key = "";
            AutoKey = 0;
            Code = "";
            ListStatus = new List<string>();
            ListStatus.Add("1");
            Keyword = "";
            Take = 2000;
            ReCallFrequencyMax = 999999;
            ReCallIntervalSec = 1;
            AccessToken = "";
            RefreshToken = "";
            IgnoreValidDate = true;
            SystemCode = "";
        }
    }

    /// <summary>
    /// 資料共用Api-基本欄位
    /// </summary>
    public class StandardDataBaseApiRow
    {
        public bool state { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public StandardDataBaseApiRow()
        {
            state = false;
            message = "";
            stackTrace = "";
        }
    }

    /// <summary>
    /// 資料共用-基本欄位
    /// </summary>
    public class StandardDataBaseRow
    {
        /// <summary>
        /// SystemCode
        /// </summary>
        public string SystemCode { set; get; }
        /// <summary>
        /// 自動編號
        /// </summary>
        public int AutoNumber { set; get; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public StandardDataBaseRow()
        {
            AutoNumber = 0;
            AutoKey = 0;
            Key = "";
            Code = Guid.NewGuid().ToString();
            Name = "";
        }
    }

    /// <summary>
    /// 資料共用
    /// </summary>
    public class StandardDataRow: StandardDataBaseRow
    {
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { set; get; }
        /// <summary>
        /// 排序及是否顯示0=不顯示
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 說明
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 資料狀態
        /// </summary>
        public string Status { set; get; }
        /// <summary>
        /// 新增者
        /// </summary>
        public string InsertMan { set; get; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public DateTime InsertDate { set; get; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { set; get; }
        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public StandardDataRow()
        {
            DateA = new DateTime(1900, 1, 1).Date;
            DateD = new DateTime(9999, 12, 31).Date;
            Sort = 999999;
            Note = "";
            Status = "1";
            InsertMan = "System";
            InsertDate = DateTime.Now;
            UpdateMan = "System";
            UpdateDate = DateTime.Now;
            Keyword = "";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChangeDataRow
    {

        /// <summary>
        /// 程式名稱
        /// </summary>
        public string AppName { set; get; }
        /// <summary>
        /// Ip位置
        /// </summary>
        public string IpAddress { set; get; }
        /// <summary>
        /// 檢查資料
        /// </summary>
        public bool DataCheck { set; get; }
        /// <summary>
        /// 向資料庫請求SubmitChanges
        /// </summary>
        public bool SubmitChanges { set; get; }
        /// <summary>
        /// 修改條件
        /// </summary>
        public string UpdateCond { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public ChangeDataRow()
        {
            AppName = "";
            IpAddress = "";
            DataCheck = true;
            SubmitChanges = true;
            UpdateCond = "";
        }
    }

    /// <summary>
    /// 資料新增共用
    /// </summary>
    public class InsertRow : ChangeDataRow
    {
        /// <summary>
        /// 新增者
        /// </summary>
        public string InsertMan { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public InsertRow()
        {
            InsertMan = "";
        }
    }

    /// <summary>
    /// 資料修改共用
    /// </summary>
    public class UpdateRow : ChangeDataRow
    {
        /// <summary>
        /// 修改者
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public UpdateRow()
        {
            UpdateMan = "";
        }
    }

    /// <summary>
    /// 資料刪除共用
    /// </summary>
    public class DeleteRow : ChangeDataRow
    {
        /// <summary>
        /// 修改者
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DeleteRow()
        {
            UpdateMan = "";
        }
    }

    /// <summary>
    /// 資料儲存共用
    /// </summary>
    public class SaveRow : ChangeDataRow
    {
        /// <summary>
        /// 修改者
        /// </summary>
        public string UpdateMan { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public SaveRow()
        {
            UpdateMan = "";
        }
    }

    /// <summary>
    /// 訊息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 訊息代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 訊息內容
        /// </summary>
        public string Contents { set; get; }
        /// <summary>
        /// 系統內容Exception
        /// </summary>
        public Exception SystemContents { set; get; }
        /// <summary>
        /// 是否可通過
        /// </summary>
        public bool Pass { set; get; }
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
        /// <summary>
        /// 類別判斷用
        /// </summary>
        public string Category { set; get; }
        /// <summary>
        /// Description
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 欄位1
        /// </summary>
        public string Column1 { set; get; }
        /// <summary>
        /// 欄位2
        /// </summary>
        public string Column2 { set; get; }
        /// <summary>
        /// 欄位3
        /// </summary>
        public string Column3 { set; get; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Sort { set; get; }
    }

    /// <summary>
    /// NameCodeRow
    /// </summary>
    public class NameCodeRow
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// Column1
        /// </summary>
        public string Column1 { set; get; }
        /// <summary>
        /// Count
        /// </summary>
        public int Count { set; get; }
    }

    /// <summary>
    /// KeyValueRow
    /// </summary>
    public class KeyValueRow
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { set; get; }
    }

    /// <summary>
    /// 檔案
    /// </summary>
    public class UploadFileRow : StandardDataRow
    {
        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string UploadName { get; set; }
        /// <summary>
        /// 伺服器檔案名稱
        /// </summary>
        public string ServerName { get; set; }
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
}
