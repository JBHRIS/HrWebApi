﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Licenses.Vdb
{
    public class ResumeInsertLicensesVdb
    {

    }
  
    public class ResumeInsertLicensesConditions : DataConditions
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }

        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTime? DateB { get; set; }
        public DateTime? DateE { get; set; }
        public string JobDescription { get; set; }
        public string Note { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeInsertLicensesApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeInsertLicensesRow
    {
       

    }
}
