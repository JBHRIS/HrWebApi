using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.Files.Vdb
{
    class ResumeUpdatefilesVdb
    {

    }
    public class ResumeUpdatefilesConditions : DataConditions
    {
        public string Code { get; set; }

        public string ResumeCode { get; set; }

        public string file1 { get; set; }
        public string file2 { get; set; }
        public string file3 { get; set; }
        public string file4 { get; set; }
        public string file5 { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public class ResumeUpdatefilesRow
    {
     

    }
}