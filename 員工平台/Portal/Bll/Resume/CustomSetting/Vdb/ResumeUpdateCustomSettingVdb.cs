using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.CustomSetting.vdb
{
    class ResumeUpdateCustomSettingVdb
    {

    }
    public class ResumeUpdateCustomSettingConditions : DataConditions
    {
        public string Code { get; set; }

        public string CustomSettingName { get; set; }
        public string CustomSetting { get; set; }


        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public class ResumeUpdateCustomSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeUpdateCustomSettingRow
    {
      
    }
}