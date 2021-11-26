using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface IFormsAppAppointInterface
    {
        List<AppointVdb> GetFormsAppAppointByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status);
        List<AppointVdb> GetFormsAppAppointForHR();
    }
}
