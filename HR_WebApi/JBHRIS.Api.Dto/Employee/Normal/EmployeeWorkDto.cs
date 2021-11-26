using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class EmployeeWorkDto
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 異動日
        /// </summary>
        public DateTime? Adate { get; set; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime? Ddate { get; set; }
        /// <summary>
        /// 異動代碼
        /// </summary>
        public string Ttscode { get; set; }
        /// <summary>
        /// 編制部門代碼
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        public string Depta { get; set; }
        /// <summary>
        /// 成本部門代碼
        /// </summary>
        public string Depts { get; set; }
        /// <summary>
        /// 職位名稱代碼
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        public string Jobl { get; set; }
        /// <summary>
        /// 職類代碼
        /// </summary>
        public string Jobs { get; set; }
        /// <summary>
        /// 職級代碼
        /// </summary>
        public string Jobo { get; set; }
        /// <summary>
        /// 公司別代碼
        /// </summary>
        public string Comp { get; set; }
        /// <summary>
        /// 薪別代碼
        /// </summary>
        public string Saltp { get; set; }
        /// <summary>
        /// 員工類別代碼
        /// </summary>
        public string Empcd { get; set; }

        /// <summary>
        /// 異動代碼名稱
        /// </summary>
        public string TtscodeName { get; set; }
        /// <summary>
        /// 編制部門代碼名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 簽核部門代碼名稱
        /// </summary>
        public string DeptaName { get; set; }
        /// <summary>
        /// 成本部門代碼名稱
        /// </summary>
        public string DeptsName { get; set; }
        /// <summary>
        /// 職位名稱代碼名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 職等代碼名稱
        /// </summary>
        public string JoblName { get; set; }
        /// <summary>
        /// 職類代碼名稱
        /// </summary>
        public string JobsName { get; set; }
        /// <summary>
        /// 職級代碼名稱
        /// </summary>
        public string JoboName { get; set; }
        /// <summary>
        /// 公司別代碼名稱
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// 薪別代碼名稱
        /// </summary>
        public string SaltpName { get; set; }
        /// <summary>
        /// 員工類別代碼名稱
        /// </summary>
        public string EmpcdName { get; set; }
    }
}
