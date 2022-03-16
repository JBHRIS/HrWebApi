using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Autobiography.Vdb
{
    public class ResumeInsertAutobiographyVdb
    {

    }

    public class ResumeInsertAutobiographyConditions : DataConditions
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }

        public string Content { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public class ResumeInsertAutobiographyApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeInsertAutobiographyRow
    {
       

    }
}
