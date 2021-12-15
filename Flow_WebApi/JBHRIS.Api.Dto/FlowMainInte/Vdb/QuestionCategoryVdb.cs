﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class QuestionCategoryVdb
    {

        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string GroupCode { get; set; }


        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }     
        public bool? SystemUse { get; set; }
        public int Sort { get; set; }

        public string Status { get; set; }

        public string InsertMan { get; set; }

        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
