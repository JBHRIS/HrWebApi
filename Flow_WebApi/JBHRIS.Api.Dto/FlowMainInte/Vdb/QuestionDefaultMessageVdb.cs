using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class QuestionDefaultMessageVdb
    {

        public int AutoKey { get; set; }

        public string CompanyId { get; set; }

        public string Code { get; set; }
            
        public string Name { get; set; }
        public string Contents { get; set; }
        public int RoleKey { get; set; }
        public string Note { get; set; }

        public string Status { get; set; }

        public string InsertMan { get; set; }

        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
