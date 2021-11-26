using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UFilter
    {
        public int Autokey { get; set; }
        public int? UCode { get; set; }
        public string QName { get; set; }
        public string QKeycontb { get; set; }
        public string QKeyconte { get; set; }
        public string QVarval { get; set; }
        public string QCond { get; set; }
        public string QCond1 { get; set; }
        public string QOrder { get; set; }
        public string QSubq { get; set; }
        public string QHaving { get; set; }
        public string QCode { get; set; }
        public string QAttr { get; set; }
        public string Usernobr { get; set; }
        public string Formname { get; set; }
        public string System { get; set; }
    }
}
