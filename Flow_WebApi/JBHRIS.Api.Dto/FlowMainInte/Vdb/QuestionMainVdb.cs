using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class QuestionMainVdb
    {

        public int AutoKey { get; set; }

        public string CompanyId { get; set; }

        public string Code { get; set; }
        public string SystemCategoryCode { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }

        public string Name { get; set; }

        public string TitleContent { get; set; }
        public string Content { get; set; }
        public string QuestionCategoryCode { get; set; }
        public string QuestionCategoryName { get; set; }
        public string IpAddress { get; set; }
        public DateTime DateE { get; set; }

        public bool Complete { get; set; }

        public string Note { get; set; }

        

        public string Status { get; set; }
        public string InsertMan { get; set; }

        public string InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public string UpdateDate { get; set; }

    }
}
