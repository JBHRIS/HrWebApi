using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_FormsAppAppoint_View
    {

        List<AppointVdb> GetFormsAppAppointByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status);
        List<AppointVdb> GetFormsAppAppointForHR();
    }
}
