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
    public class ShareTagVdb
    {
    }

    /// <summary>
    /// 顯示標籤條件
    /// </summary>
    public class ShareTagConditions : DataConditions
    {
        /// <summary>
        /// 標籤類別代碼
        /// </summary>
        public string TagCategoryCode { get; set; }
        /// <summary>
        /// 標籤代碼
        /// </summary>
        public List<string> ListCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ShareTagConditions()
        {
            ListCode = new List<string>();
            TagCategoryCode = "";
        }
    }

    /// <summary>
    /// 顯示標籤
    /// </summary>
    public class ShareTagRow : StandardDataRow
    {
        /// <summary>
        /// 標籤類別代碼
        /// </summary>
        public string TagCategoryCode { get; set; }
    }

    /// <summary>
    /// 儲存標籤
    /// </summary>
    public class ShareTagSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存標籤資料
    /// </summary>
    public class ShareTagSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareTagRow> ListShareTag { get; set; }
    }

    /// <summary>
    /// 新增標籤
    /// </summary>
    public class ShareTagInsertResult : Message
    {

    }

    /// <summary>
    /// 新增標籤資料
    /// </summary>
    public class ShareTagInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareTagRow> ListShareTag { get; set; }
    }

    /// <summary>
    /// 修改標籤
    /// </summary>
    public class ShareTagUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改標籤資料
    /// </summary>
    public class ShareTagUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareTagRow> ListShareTag { get; set; }
    }

    /// <summary>
    /// 刪除標籤
    /// </summary>
    public class ShareTagDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除標籤資料
    /// </summary>
    public class ShareTagDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<ShareTagRow> ListShareTag { get; set; }
    }
}
