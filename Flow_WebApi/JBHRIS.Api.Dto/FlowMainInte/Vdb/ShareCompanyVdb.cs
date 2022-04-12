using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class ShareCompanyVdb
    {
        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string GroupCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FieldKey { get; set; }
        public string FieldValue { get; set; }
        public string ColumnTypeCode { get; set; }
        public string FormTypeCode { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
