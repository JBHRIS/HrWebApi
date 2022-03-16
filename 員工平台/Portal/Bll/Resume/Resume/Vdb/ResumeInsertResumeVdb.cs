using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Resume.vdb
{
    public class ResumeInsertResumeVdb
    {

    }

    public class ResumeInsertReusumeConditions : DataConditions
    {
        public string Code { get; set; }

        public string UsercCode { get; set; }
        public string ResumeName { get; set; }
        public DateTime? DateB { get; set; }
        public DateTime? DateD { get; set; }
        public string Status { get; set; }


        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeInsertResumeApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeInsertResumeRow
    {
       

    }
}
