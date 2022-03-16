using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Resume.ResumeInvitations.Vdb
{
    class ResumeUpdateResumeInvitationsVdb
    {

    }
    public class ResumeUpdateResumeInvitationsConditions : DataConditions
    {
        public string Code { get; set; }

        public string CompanyName { get; set; }
        public string JobName { get; set; }
        public DateTime? InvitationTime { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public class ResumeUpdateResumeInvitationsApiRow : StandardDataBaseApiRow
    {

    }
    public class ResumeUpdateResumeInvitationsRow
    {
     

    }
}