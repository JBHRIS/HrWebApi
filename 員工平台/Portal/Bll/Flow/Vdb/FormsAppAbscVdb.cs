using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormsAppAbscVdb
    {
    }
    public class FormsAppAbscConditions : DataConditions
    {
        public string Nobr { get; set; }
        public DateTime BDate { get; set; }
        public DateTime EDate { get; set; }
    }
    public class FormsAppAbscApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeID { get; set; }
            public string employeeName { get; set; }
            public string idProcess { get; set; }
            public string holidayCode { get; set; }
            public string holidayName { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public string beginTime { get; set; }
            public string endTime { get; set; }
            public int absenceAmount { get; set; }
            public string absenceUnit { get; set; }
        }
        public List<Result> result { get; set; }
    }
    public class FormsAppAbscRow
    {
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime AbscDateB { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime AbscDateE { get; set; }
        
        /// <summary>
        /// 起始時間
        /// </summary>
        public string AbscTimeB { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string AbscTimeE { get; set; }
        /// <summary>
        /// 共計
        /// </summary>
        public Decimal AbscTotalTime { get; set; }
        /// <summary>
        /// 請假單號
        /// </summary>
        public string ProcessId { get; set; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HolidayName { get; set; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HolidayCode { get; set; }
        public Guid Guid { get; set; }
        public FormsAppAbscRow()
        {
            Guid = Guid.NewGuid();
        }
    }
}
