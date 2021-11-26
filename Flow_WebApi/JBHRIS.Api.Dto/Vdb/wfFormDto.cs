using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Vdb
{
    public class wfFormDto
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sFormName { get; set; }
        public string sFlowTree { get; set; }
        public string sStdNote { get; set; }
        public string sCheckNote { get; set; }
        public string sViewNote { get; set; }
        public string sEtcNote { get; set; }
        public int iDelay { get; set; }
        public int iAppCount { get; set; }
        public bool bNote { get; set; }
        public bool bSignNote { get; set; }
        public bool bSignState { get; set; }
        public bool bUploadFile { get; set; }
        public bool bAttend { get; set; }
        public bool bAgentApp { get; set; }
        public bool? b1 { get; set; }
        public bool? b2 { get; set; }
        public bool? b3 { get; set; }
        public bool? b4 { get; set; }
        public bool? b5 { get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string sTableName { get; set; }
        public string sSaveUrl { get; set; }
        public string sSaveMetod { get; set; }
        public int? iSort { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
