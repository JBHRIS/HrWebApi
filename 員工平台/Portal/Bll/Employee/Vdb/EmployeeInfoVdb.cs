using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class EmployeeInfoVdb
    {
    }

    public class EmployeeInfoConditions : DataConditions
    {
        public List<string> ListEmpId { get; set; }
    }


    //public class EmployeeInfoApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}


    public class EmployeeInfoApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeId { get; set; }
            public string idNo { get; set; }
            public string sex { get; set; }
            public DateTime birthday { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string telphoneNo { get; set; }
            public string residentCertificateId { get; set; }
            public string passportId { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class EmployeeInfoRow : StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEnglishName { get; set; }
        public string EmpSex { get; set; }
        public DateTime EmpBirthday { get; set; }
        public string EmpMasked { get; set; }
        public string EmpBlood { get; set; }
        public string EmpMarried { get; set; }
    }

    /// <summary>
    /// 選員工的樹狀結構
    /// </summary>
    public class DeptEmpRow
    {
        /// <summary>
        /// 部門或員工類別
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 部門代碼或員工工號
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 部門名稱或是姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 角色代碼(員工或主管或其它角色，可識別為無法選擇)
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 代碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 父層代碼
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// PathCode
        /// </summary>
        public string PathCode { get; set; }
        /// <summary>
        /// PathName
        /// </summary>
        public string PathName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DeptEmpRow()
        {
            PathCode = "";
            PathName = "";
        }
    }
}