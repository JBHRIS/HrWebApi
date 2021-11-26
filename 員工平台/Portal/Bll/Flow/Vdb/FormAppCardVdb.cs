using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormAppCardVdb
    {
    }
    public class FormAppCardConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormAppCardApiRow : StandardDataBaseApiRow
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
            public List<FlowAppCard> FlowApps { get; set; }
        }
        public result Result { get; set; }
    }
    public class FormAppCardRow
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
        public List<FlowAppCard> FlowApps { get; set; }
    }
    public class FlowAppCard
    {
        public int AutoKey { get; set; }
        public string ProcessID { get; set; }
        public string Code { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string RoteID { get; set; }
        public DateTime? RoteDateTimeB { get; set; }
        public DateTime? RoteDateTimeE { get; set; }
        public DateTime? CardDateTimeB { get; set; }
        public DateTime? CardDateTimeE { get; set; }
        public DateTime? Date { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public DateTime DateTimeB { get; set; }
        public DateTime DateTimeE { get; set; }
        public string CardLostCode { get; set; }
        public string CardLostName { get; set; }
        public string CauseID1 { get; set; }
        public string CauseName1 { get; set; }
        public string CauseID2 { get; set; }
        public string CauseName2 { get; set; }
        public string Note { get; set; }
        public string Info { get; set; }
        public string MailBody { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
        public string ExceptionalCode { get; set; }
        public string ExceptionalName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
