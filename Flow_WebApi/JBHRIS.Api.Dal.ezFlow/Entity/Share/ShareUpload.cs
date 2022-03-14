using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class ShareUpload
    {
        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string Code { get; set; }
        public string CompanyId { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string UploadName { get; set; }
        public string ServerName { get; set; }
        public string Note { get; set; }
        public byte[] Blob { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public bool? SystemUse { get; set; }
        public int Sort { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
