using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
  public  class AbsenceEntry
    {
        /// <summary>
        /// 員工編號清單
        /// </summary>
        public List<string> EmployeeList { get; set; }
        /// <summary>
        /// 假別代碼清單
        /// </summary>
        public List<string> HcodeList { get; set; }
        /// <summary>
        /// 請假日期起
        /// </summary>
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// 請假日期迄
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}
