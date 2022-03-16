using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.CustomSetting.vdb
{
    public class ResumeGetCustomSettingVdb
    {

    }
  
    public class ResumeGetCustomSettingConditions : DataConditions
    {

    }
    public class ResumeGetCustomSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeGetCustomSettingRow
    {
        public string Code { get; set; }

        public string CustomSettingName { get; set; }
        public string CustomSetting { get; set; }
        

        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
