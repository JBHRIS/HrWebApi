using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.JobConditions.Vdb
{
    public class ResumeInsertJobConditionsVdb
    {

    }

    public class ResumeInsertJobConditionsConditions : DataConditions
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }
        public string WorkingTimeType { get; set; }
        public string WorkingTime { get; set; }
        public string OtherWorkingTime { get; set; }
        public string Shift { get; set; }
        public string EnabledWorkTime { get; set; }
        public string Treatment { get; set; }
        public string WorkingPlace { get; set; }
        public bool RemoteWork { get; set; }
        public string JobTitle { get; set; }
        public string JobType { get; set; }
        public string Duty { get; set; }
        public string Job { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public class ResumeInsertJobConditionsApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeInsertJobConditionsRow
    {
       

    }
}
