using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class SystemUserVdb
    {

        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string CompanyId { get; set; }
        public string UserName { get; set; }
        public string AccountCode { get; set; }
        public string AccountPassword { get; set; }
        public string MoneyPassword { get; set; }

        public int RoleKey { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public bool IsRegistered { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }

        public string InsertMan { get; set; }

        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
