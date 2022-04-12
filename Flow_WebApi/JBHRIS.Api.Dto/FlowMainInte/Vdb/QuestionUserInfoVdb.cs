using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class QuestionUserInfoVdb
    {

        public int AutoKey { get; set; }

        public string CompanyId { get; set; }

        public string Code { get; set; }
        public string AccountCode { get; set; }
        public string AccountPassword { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int RoleKey { get; set; }

        public string Email { get; set; }
        public string Content { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }


        public string Note { get; set; }

        

        public string Status { get; set; }
        public string InsertMan { get; set; }

        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
