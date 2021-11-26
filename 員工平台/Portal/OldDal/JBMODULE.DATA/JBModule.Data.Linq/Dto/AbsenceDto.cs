using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class AbsenceDto
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
        public string Hcode;
        /// <summary>
        /// 假別顯示代碼
        /// </summary>
        public string HcodeDisp;
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string Hname;
        /// <summary>
        /// 請假日期
        /// </summary>
        public DateTime Adate;
        /// <summary>
        /// 起始時間
        /// </summary>
        public DateTime BeginTime;
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime;
        /// <summary>
        /// 請假資料Guid
        /// </summary>
        public string Guid;
        /// <summary>
        /// 表單序號
        /// </summary>
        public string Serno;
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo;
        /// <summary>
        /// 申請時數(天數)
        /// </summary>
        public decimal Taken;
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit;
    }
}
