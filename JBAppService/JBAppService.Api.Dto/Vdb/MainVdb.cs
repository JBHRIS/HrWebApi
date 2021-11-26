using System;
using System.Collections.Generic;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class MainVdb
    {
    }

    /// <summary>
    /// 新聞內容
    /// </summary>
    public class NewsRow
    {
        /// <summary>
        /// NewsID
        /// </summary>
        public string NewsID { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string NewsHead { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string NewsBody { get; set; }
        /// <summary>
        /// 公告開始日期
        /// </summary>
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 公告失效日期
        /// </summary>
        public DateTime PostDeadline { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        public bool IsOn { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Int64 Sort { get; set; }
        /// <summary>
        /// 公告者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFileOld { get; set; }
        /// <summary>
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFileNew { get; set; }
    }

    /// <summary>
    /// 新聞內容延伸
    /// </summary>
    public class NewsExtendRow : NewsRow
    {
        private DateTime _PostDate;
        /// <summary>
        /// 公告開始日期
        /// </summary>
        public new DateTime PostDate
        {
            set
            {
                _PostDate = value;
              //  base.PostDate = value.ToString("yyyy-mm-dd hh:mm:ss.mmm");
            }
            get
            {
                return _PostDate;
            }
        }

        private DateTime _PostDeadline;
        /// <summary>
        /// 公告失效日期
        /// </summary>
        public new DateTime PostDeadline
        {
            set
            {
                _PostDeadline = value;
               // base.PostDeadline = value.ToString("yyyy-mm-dd hh:mm:ss.mmm");
            }
            get
            {
                return _PostDeadline;
            }
        }
        private DateTime _UpdateDate;
        /// <summary>
        /// 修改日期
        /// </summary>
        public new DateTime UpdateDate
        {
            set
            {
                _UpdateDate = value;
              //  base.UpdateDate = value.ToString("yyyy-mm-dd hh:mm:ss.mmm");
            }
            get
            {
                return _UpdateDate;
            }
        }
    }

    /// <summary>
    /// 語系
    /// </summary>
    public class LanguageMessageRow
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 語系1
        /// </summary>
        public string Language1 { get; set; }
        /// <summary>
        /// 語系2
        /// </summary>
        public string Language2 { get; set; }
        /// <summary>
        /// 語系3
        /// </summary>
        public string Language3 { get; set; }
        /// <summary>
        /// 語系4
        /// </summary>
        public string Language4 { get; set; }
        /// <summary>
        /// 語系5
        /// </summary>
        public string Language5 { get; set; }
    }

    /// <summary>
    /// 節點審核
    /// </summary>
    public class FlowNodeFinishRow : MessageRow
    {
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Finish { get; set; }
        /// <summary>
        /// 目前待審核人員
        /// </summary>
        public EmpInfo ToEmp { get; set; }
    }
    public class EmpInfo
    {
        /// <summary>
        /// 目前待審核工號
        /// </summary>
        public string Emp_idDefault { get; set; }
        /// <summary>
        /// 目前待審核姓名
        /// </summary>
        public string Emp_NameDefault { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string PosName { get; set; }
    }
}
