using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Licenses.Vdb
{
    public class ResumeLicensesVdb
    {

    }
  
    public class ResumeGetLicensesConditions : DataConditions
    {

    }
    public class ResumeGetLicensesApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeGetLicensesRow
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }

      public string  ReleaseAgent { get; set; }
        public string LicenseContent { get; set; }
        public DateTime? DateB { get; set; }
        public DateTime? DateE { get; set; }
        public bool IsInternal { get; set; }
        public string NationalExam { get; set; }
        public string LicenseNo { get; set; }
        public string Note { get; set; }
         public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
