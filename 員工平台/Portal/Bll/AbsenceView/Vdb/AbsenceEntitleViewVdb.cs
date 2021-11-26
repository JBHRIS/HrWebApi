using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.AbsenceView.Vdb
{
  public  class AbsenceEntitleViewVdb
    {
    }
    public class AbsenceEntitleViewConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public List<string> leaveCodeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class AbsenceEntitleViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeId { get; set; }
            public string employeeName { get; set; }
            public string departmentCode { get; set; }
            public string departmentName { get; set; }
            public string leaveCode { get; set; }
            public string leaveName { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public string entitle { get; set; }
            public string taken { get; set; }
            public string balance { get; set; }
            public string unit { get; set; }
            public string remark { get; set; }
        }
        public List<Result> result { get; set; }
        
    }
    public class AbsenceEntitleViewRow
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public string AbsName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Entitle { get; set; }
        public string Leaved { get; set; }
        public string Remaining { get; set; }
        public string Unit { get; set; }
        public string Note { get; set; }
    }
}
