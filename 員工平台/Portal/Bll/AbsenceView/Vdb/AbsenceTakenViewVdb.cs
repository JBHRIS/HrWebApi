using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.AbsenceView.Vdb
{
  public  class AbsenceTakenViewVdb
    {
    }
    public class AbsenceTakenViewConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public List<string> leaveCodeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class AbsenceTakenViewApiRow : StandardDataBaseApiRow
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
            public string beginTime { get; set; }
            public string endTime { get; set; }
            public string taken { get; set; }
            public string unit { get; set; }
            public string remark { get; set; }
        }

        public List<Result> result { get; set; }
        

    }
    public class AbsenceTakenViewRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string AbsName { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public string AbsBeginTime { get; set; }
        public string AbsEndTime { get; set; }
        public string AbsHours { get; set; }
        public string Unit { get; set; }
        public string Note { get; set; }
    }
}
