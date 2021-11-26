using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class COLDEF
    {
        public string TABLE_NAME { get; set; }
        public string FIELD_NAME { get; set; }
        public decimal? SEQ { get; set; }
        public string FIELD_TYPE { get; set; }
        public string IS_KEY { get; set; }
        public decimal? FIELD_LENGTH { get; set; }
        public string CAPTION { get; set; }
        public string EDITMASK { get; set; }
        public string NEEDBOX { get; set; }
        public string CANREPORT { get; set; }
        public string EXT_MENUID { get; set; }
        public decimal? FIELD_SCALE { get; set; }
        public string DD_NAME { get; set; }
        public string DEFAULT_VALUE { get; set; }
        public string CHECK_NULL { get; set; }
        public string QUERYMODE { get; set; }
        public string CAPTION1 { get; set; }
        public string CAPTION2 { get; set; }
        public string CAPTION3 { get; set; }
        public string CAPTION4 { get; set; }
        public string CAPTION5 { get; set; }
        public string CAPTION6 { get; set; }
        public string CAPTION7 { get; set; }
        public string CAPTION8 { get; set; }
    }
}
