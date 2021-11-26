using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class AbsenceDetail
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string Nobr;
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string NameC;
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HCode;
        /// <summary>
        /// 假別顯示代碼
        /// </summary>
        public string HCodeDisp;
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HName;
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit;
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime BeginDate;
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 得假
        /// </summary>
        public decimal Entitled;
        /// <summary>
        /// 已請
        /// </summary>
        public decimal Taken;
        /// <summary>
        /// 剩餘
        /// </summary>
        public decimal Balance;
        /// <summary>
        /// 得假資料Guid
        /// </summary>
        public string Guid;
    }
}
