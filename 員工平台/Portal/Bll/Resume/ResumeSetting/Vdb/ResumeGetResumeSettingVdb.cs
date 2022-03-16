using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ResumeSetting.vdb
{
    public class ResumeSettingGetResumeSettingVdb
    {

    }
  
    public class ResumeSettingGetResumeSettingConditions : DataConditions
    {

    }
    public class ResumeSettingGetResumeSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeSettingGetResumeSettingRow 
    {
        public string Code { get; set; }

        public string UsercCode { get; set; }
        public string CustomSetting { get; set; }
        

        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
