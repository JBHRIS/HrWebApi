﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ResumeSetting.vdb
{
    public class ResumeSettingInsertResumeSettingVdb
    {

    }

    public class ResumeSettingInsertReusumeConditions : DataConditions
    {
        public string Code { get; set; }

        public string UsercCode { get; set; }
        public string CustomSetting { get; set; }


        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeSettingInsertResumeSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeSettingInsertResumeSettingRow
    {
       

    }
}
