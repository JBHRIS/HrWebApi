using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class IdTablesData
    {
        public string IAutoKey { get; set; }
        public Guid? SCode { get; set; }
        public string SName { get; set; }
        public string SSourceCode { get; set; }
        public string STargetCode { get; set; }
        public string TableCateorgySCode { get; set; }
        public string TableTypeSCode { get; set; }
        public bool? BEssential { get; set; }
        public int IImportSort { get; set; }
        public string ImportTypeSCode { get; set; }
        public string ReplaceSCode { get; set; }
        public string SNote { get; set; }
        public int ISort { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
