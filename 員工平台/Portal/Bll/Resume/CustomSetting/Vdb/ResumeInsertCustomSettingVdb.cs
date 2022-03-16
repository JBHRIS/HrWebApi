using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.CustomSetting.vdb
{
    public class ResumeInsertCustomSettingVdb
    {

    }

    public class ResumeInsertCustomSettingConditions : DataConditions
    {
        public string Code { get; set; }

        public string CustomSettingName { get; set; }
        public string CustomSetting { get; set; }


        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ResumeInsertCustomSettingApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeInsertCustomSettingRow
    {
       

    }
}
