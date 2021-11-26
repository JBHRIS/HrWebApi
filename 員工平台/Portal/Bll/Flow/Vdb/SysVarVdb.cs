using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    public class SysVarVdb
    {
    }
    public class SysVarConditions : DataConditions
    {
    }
    public class SysVarApiRow:StandardDataBaseApiRow
    {
        public class Result
        {
            public string Url { get; set; }
            public string MailServer { get; set; }
            public string MailId { get; set; }
            public string MailPassword { get; set; }
            public string SenderMail { get; set; }
            public string SenderName { get; set; }
            public string WebServiceURL { get; set; }
            public int MaxKey { get; set; }
            public bool SysClose { get; set; }
        }
        public List<Result> result { get; set; }
    }
    public class SysVarRow
    {
        public string Url { get; set; }
        public string MailServer { get; set; }
        public string MailId { get; set; }
        public string MailPassword { get; set; }
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string WebServiceURL { get; set; }
        public int MaxKey { get; set; }
        public bool SysClose { get; set; }
    }
       
}
