using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.System;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_SysVar_View : ISystem_SysVar_View
    {
        private ezFlowContext _context;
        public System_SysVar_View(ezFlowContext context)
        {
            this._context = context;
        }

        public List<SysVarDto> GetSysVarList()
        {
            var result = (from d in _context.SysVars
                          select new SysVarDto
                          {
                              MailId = d.mailID,
                              MailPassword = d.mailPW,
                              MailServer = d.mailServer,
                              MaxKey = (int)d.maxKey,
                              SenderMail = d.senderMail,
                              SenderName = d.senderName,
                              SysClose = (bool)d.sysClose,
                              Url = d.urlRoot,
                              WebServiceURL = d.webSrvURL
                          }).ToList();
            return result;
        }
    }
}
