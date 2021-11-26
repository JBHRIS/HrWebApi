using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class EmployeeSchoolDto
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 教育程度排序
        /// </summary>
        public int EduccodeSort { get; set; }
        /// <summary>
        /// 教育程度代碼
        /// </summary>
        public string Educcode { get; set; }
        /// <summary>
        /// 教育程度代碼名稱
        /// </summary>
        public string EduccodeName { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime Adate { get; set; }
        /// <summary>
        /// 畢業
        /// </summary>
        public bool Ok { get; set; }
        /// <summary>
        /// 學校
        /// </summary>
        public string Schl1 { get; set; }
        /// <summary>
        /// 科系
        /// </summary>
        public string Subj { get; set; }
        /// <summary>
        /// 入學日
        /// </summary>
        public string DateB { get; set; }
        /// <summary>
        /// 畢業日
        /// </summary>
        public string DateE { get; set; }
        /// <summary>
        /// 日夜校
        /// </summary>
        public string DayOrNight { get; set; }
        /// <summary>
        /// 科系組別
        /// </summary>
        public string SubjDetail { get; set; }
        /// <summary>
        /// 肄業
        /// </summary>
        public bool Graduated { get; set; }
    }
}
