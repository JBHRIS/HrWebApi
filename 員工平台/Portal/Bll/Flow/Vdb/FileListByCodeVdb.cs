using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    public class FileListByCodeVdb
    {
    }

    public class FileListByCodeConditions : DataConditions
    {

    }

    public class FileListByCodeApiRow : StandardDataBaseApiRow
    {
        public List<Result> result { get; set; }

        public class Result
        {
            public decimal AutoKey { get; set; }
            public string SystemCode { get; set; }
            public string Code { get; set; }
            public string CompanyId { get; set; }
            public string Key1 { get; set; }
            public string Key2 { get; set; }
            public string Key3 { get; set; }
            public string UploadName { get; set; }
            public string ServerName { get; set; }
            public string Note { get; set; }
            public string Blob { get; set; }
            public string Type { get; set; }
            public decimal Size { get; set; }
            public bool? SystemUse { get; set; }
            public decimal Sort { get; set; }
            public string Status { get; set; }
            public string InsertMan { get; set; }
            public DateTime? InsertDate { get; set; }
            public string UpdateMan { get; set; }
            public DateTime? UpdateDate { get; set; }
        }

    }

    public class FileListByCodeRow
    {
        public decimal AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string Code { get; set; }
        public string CompanyId { get; set; }
        public string Type { get; set; }
        public decimal Size { get; set; }
        public string UploadName { get; set; }

    }
}
