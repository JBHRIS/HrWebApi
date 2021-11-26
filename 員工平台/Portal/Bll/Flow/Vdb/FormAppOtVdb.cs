using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormAppOtVdb
    {
    }
    public class FormAppOtConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormAppOtApiRow : StandardDataBaseApiRow
    {
        public class UploadFile
        {
            public int UploadID { get; set; }
            public string UploadName { get; set; }
            public string ServerName { get; set; }
            public string Description { get; set; }
            public string Blob { get; set; }
            public string Type { get; set; }
            public int Size { get; set; }
        }

        public class result
        {
            public string EmpID { get; set; }
            public string EmpCode { get; set; }
            public string EmpNameC { get; set; }
            public string State { get; set; }
            public string Cond1 { get; set; }
            public string Cond2 { get; set; }
            public string Cond3 { get; set; }
            public string Cond4 { get; set; }
            public string Cond5 { get; set; }
            public string Cond6 { get; set; }
            public Decimal Amount { get; set; }
            public string RoteID { get; set; }
            public List<FlowAppOt> FlowApps { get; set; }
        }

        public result Result { get; set; }
    }
    public class FormAppOtRow
    {
        public string EmpID { get; set; }
        public string EmpCode { get; set; }
        public string EmpNameC { get; set; }
        public string State { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public string Cond4 { get; set; }
        public string Cond5 { get; set; }
        public string Cond6 { get; set; }
        public Decimal Amount { get; set; }
        public string RoteID { get; set; }
        public List<FlowAppOt> FlowApps { get; set; }
    }
    public class FlowAppOt
    {
        public string EmpID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string RoteID { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public DateTime DateB1 { get; set; }
        public DateTime DateE1 { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string TimeB1 { get; set; }
        public string TimeE1 { get; set; }
        public DateTime DateTimeB { get; set; }
        public DateTime DateTimeE { get; set; }
        public DateTime DateTimeB1 { get; set; }
        public DateTime DateTimeE1 { get; set; }
        public string Code { get; set; }
        public string RoteCode { get; set; }
        public string RoteName { get; set; }
        public string RotehCode { get; set; }
        public string RotehName { get; set; }
        public string OtCateCode { get; set; }
        public string OtCateName { get; set; }
        public string OtrcdCode { get; set; }
        public string OtrcdName { get; set; }
        public string OtCat { get; set; }
        public string CauseID { get; set; }
        public string CauseName { get; set; }
        public Decimal Amount { get; set; }
        public string HoliDayUnitName { get; set; }
        public string Note { get; set; }
        public string Info { get; set; }
        public string KeyName { get; set; }
        public string EventDate { get; set; }
        public string MailBody { get; set; }
        public Decimal Use { get; set; }
        public string UnitCode { get; set; }
        public bool IsExceptionUse { get; set; }
        public Decimal ExceptionUse { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
        public bool Today { get; set; }
        public string ProcessID { get; set; }
        public string Serno { get; set; }
        public string JobName { get; set; }
        public string JobCode { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public string DeptsCode { get; set; }
        public string DeptsName { get; set; }
        public string sGuid { get; set; }
        public int AutoKey { get; set; }
        public string Key { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
