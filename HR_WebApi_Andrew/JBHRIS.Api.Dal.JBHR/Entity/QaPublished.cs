using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QaPublished
    {
        public int Id { get; set; }
        public string QtplCode { get; set; }
        public DateTime PublishDatetime { get; set; }
        public DateTime FillFormDatetimeB { get; set; }
        public DateTime FillFormDatetimeE { get; set; }
        public bool IsPublished { get; set; }
        public string WritedBy { get; set; }
        public bool SentMail { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public bool Cancel { get; set; }
        public bool IsAnonymous { get; set; }
        public bool ViewSummaryOpening { get; set; }
        public bool ViewSummaryClosed { get; set; }
    }
}
