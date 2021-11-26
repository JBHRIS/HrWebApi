using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class FileStructureGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FileStructureCode { get; set; }
        public int Sequence { get; set; }
    }
}
