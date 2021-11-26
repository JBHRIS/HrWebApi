using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppAppointService : IFormsAppAppointInterface
    {
        private ISystem_FormsAppAppoint_View _ISystem_FormsAppAppoint_View;
        public FormsAppAppointService(ISystem_FormsAppAppoint_View system_FormsAppAppoint_View)
        {
            this._ISystem_FormsAppAppoint_View = system_FormsAppAppoint_View;
        }

        public List<AppointVdb> GetFormsAppAppointByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppAppoint_View.GetFormsAppAppointByProcessId(ProcessFlowID,  Sign,  SignState,  Status);
        }
        public List<AppointVdb> GetFormsAppAppointForHR()
        {
            return this._ISystem_FormsAppAppoint_View.GetFormsAppAppointForHR();
        }
    }
}
