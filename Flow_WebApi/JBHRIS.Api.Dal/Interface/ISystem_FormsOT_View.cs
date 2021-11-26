using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_FormsOT_View
    {
        OTFlowAppRow GetFormsAppOTByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status);
        OTFlowAppsRow GetFormsAppOTByAutoKey(int AutoKey, string SignState, string Status);
    }
}
