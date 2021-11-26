using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Att.Vdb
{
    public class EmployeeLeaveSettlementVdb
    {
        public List<EmployeeLeaveInfo> EmployeeLeaveInfoList;
        public List<OutEmployeeInfo> OutEmployeeInfoList;
        public EmployeeLeaveSettlementCondition Condition;
    }
    public class EmployeeLeaveSettlementCondition
    {
        public string EmployeeIdBegin;
        public string EmployeeIdEnd;
        public DateTime OutDateBegin;
        public DateTime OutDateEnd;
    }
    public class EmployeeLeaveInfo
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmployeeId;
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmployeeName;
        /// <summary>
        /// 離職日期
        /// </summary>
        public DateTime OutDate;
        /// <summary>
        /// 參考薪資
        /// </summary>
        public decimal BaseSalary;
        /// <summary>
        /// 伙食津貼
        /// </summary>
        public decimal FoodSalary;
        /// <summary>
        /// 特休剩餘時數
        /// </summary>
        public decimal SpecialLeaveHours;
        /// <summary>
        /// 補休剩餘時數
        /// </summary>
        public decimal CompensatedLeaveHours;
        /// <summary>
        /// 彈休剩餘時數
        /// </summary>
        public decimal OptionalLeaveHours;
        /// <summary>
        /// 特休代金
        /// </summary>
        public decimal SpecialLeaveBonus;
        /// <summary>
        /// 補休代金
        /// </summary>
        public decimal CompensatedLeaveBonus;
        /// <summary>
        /// 彈休代金
        /// </summary>
        public decimal OptionalLeaveBonus;
    }
    public class OutEmployeeInfo
    {
        public string EmployeeId;
        public string EmployeeName;
        public DateTime OutDate;
        public List<EmployeeBaseSalaryInfo> BaseSalaryInfoList;
        public List<EmployeeAbsenceInfo> AbsInfoList;
    }
    public class EmployeeAbsenceInfo
    {
        public string EmployeeId;
        public string Type;
        public string Hcode;
        public decimal TotalHours;
    }
    public enum AbsType
    {
        SpecialGet,
        SpecialUse,
        CompensatedGet,
        CompensatedUse,
        OptionalGet,
        OptionalUse
    }
    public class EmployeeBaseSalaryInfo
    {
        public string EmployeeId;
        public string Salcode;
        public decimal Amt;
    }
}
