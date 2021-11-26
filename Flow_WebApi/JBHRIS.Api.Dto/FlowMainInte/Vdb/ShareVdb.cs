using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    /// <summary>
    /// ShareVdb
    /// </summary>
    public class ShareVdb
    {
    }


    /// <summary>
    /// 共用代碼群組
    /// </summary>
    public class ShareCodeGroupRow
    {
        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 共用代碼
        /// </summary>
        public List<ShareCodeRow> ShareCode { get; set; }
    }

    /// <summary>
    /// 共用代碼
    /// </summary>
    public class ShareCodeRow
    {
        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 顯示
        /// </summary>
        public bool Display { get; set; }
    }
}
