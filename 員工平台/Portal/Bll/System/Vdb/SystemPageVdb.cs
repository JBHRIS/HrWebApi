using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.System.Vdb
{
    public class SystemPageVdb
    {
    }

    /// <summary>
    /// 顯示檔案結構管理條件
    /// </summary>
    public class SystemPageConditions : DataConditions
    {
        /// <summary>
        /// 所屬分類代碼
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 父層代碼
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemPageConditions()
        {
            TypeCode = "";
            ParentCode = "";
        }
    }


    /// <summary>
    /// 顯示檔案結構管理
    /// </summary>
    public class SystemPageRow : StandardDataRow
    {
        /// <summary>
        /// 所屬分類代碼
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 所屬分類名稱
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 路徑
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 檔名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 檔案抬頭
        /// </summary>
        public string FileTitle { get; set; }
        /// <summary>
        /// 權限代碼(總合)
        /// </summary>
        public int RoleKey { get; set; }
        /// <summary>
        /// 父層代碼
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 建立Tree使用
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 建立Tree使用
        /// </summary>
        public int CodeId { get; set; }
        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 標籤
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 超連結
        /// </summary>
        public bool Href { get; set; }
        /// <summary>
        /// 開新窗
        /// </summary>
        public bool OpenWindow { get; set; }
        public int Order { get; set; }
        /// <summary>
        /// PathCode
        /// </summary>
        public string PathCode { get; set; }
        /// <summary>
        /// PathName
        /// </summary>
        public string PathName { get; set; }
        /// <summary>
        /// 是否有權限
        /// </summary>
        public bool IsAuth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemPageRow()
        {
            PathCode = "";
            PathName = "";
            Href = true;
            OpenWindow = false;
        }
    }
}
