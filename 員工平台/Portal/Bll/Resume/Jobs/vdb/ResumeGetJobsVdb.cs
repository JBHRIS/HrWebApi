using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Jobs.Vdb
{
    public class ResumeJobsVdb
    {

    }

    public class ResumeGetJobsConditions : DataConditions
    {

    }
    public class ResumeGetJobsApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeGetJobsRow
    {
        public string Code { get; set; }

        public string AccountCode { get; set; }
        public string JobeCode { get; set; }
        public string ReplyType { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
