using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class HrFile
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public byte[] FileBinary { get; set; }
        public bool? IsStoredInDb { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string FileType { get; set; }
        public int? FileSize { get; set; }
        public string FileDesc { get; set; }
        public string FileNameExt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
