using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Autobiography.Vdb
{
    public class ResumeAutobiographyVdb
    {

    }

    public class ResumeGetAutobiographyConditions : DataConditions
    {

    }
    public class ResumeGetAutobiographyApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeGetAutobiographyRow
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }

      public string Content { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
