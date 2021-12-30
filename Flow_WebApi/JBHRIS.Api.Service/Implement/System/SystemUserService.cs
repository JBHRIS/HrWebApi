using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class SystemUserService : SystemUserInterFace
    {
        private ISystem_SystemUser_View _ISystem_SystemUser_View;
        public SystemUserService(ISystem_SystemUser_View system_SystemUser_View)
        {
            this._ISystem_SystemUser_View = system_SystemUser_View;
        }

        public List<SystemUserVdb> GetSystemUser()
        {
            return this._ISystem_SystemUser_View.GetSystemUser();
        }
       

       

    }
}
