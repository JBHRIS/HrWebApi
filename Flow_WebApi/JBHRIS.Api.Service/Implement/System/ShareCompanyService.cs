using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class ShareCompanyService : IShareCompanyInterFace
    {
        private ISystem_ShareCompany_View _ISystem_ShareCompany_View;
        public ShareCompanyService(ISystem_ShareCompany_View system_ShareCompany_View)
        {
            this._ISystem_ShareCompany_View = system_ShareCompany_View;
        }
        public List<ShareCompanyVdb> GetShareCompanyIdAndName()
        {
            return this._ISystem_ShareCompany_View.GetShareCompanyIdAndName();
        }

    }
}
