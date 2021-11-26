using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FileStructureGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FileStructureCode { get; set; }
        public int Sequence { get; set; }
    }
}
