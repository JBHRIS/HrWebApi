using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.ResumeSetting.vdb
{
    class ResumeSettingUpdateResumeSettingVdb
    {

    }
    public class ResumeSettingUpdateResumeSettingConditions : DataConditions
    {
        public string Code { get; set; }

        public string UsercCode { get; set; }
        public string CustomSetting { get; set; }


        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public class ResumeSettingUpdateResumeSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeSettingUpdateResumeSettingRow
    {
      
    }
}