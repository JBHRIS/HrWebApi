using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppShiftShortService : IFormsAppShiftShortInterface
    {
        private ISystem_FormsAppShiftShort_View _ISystem_FormsAppShiftShort_View;
        public FormsAppShiftShortService(ISystem_FormsAppShiftShort_View system_FormsAppShiftShort_View)
        {
            this._ISystem_FormsAppShiftShort_View = system_FormsAppShiftShort_View;
        }

        public List<ShiftShortVdb> GetFormsAppShiftShortByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppShiftShort_View.GetFormsAppShiftShortByProcessId(ProcessFlowID,  Sign,  SignState,  Status);
        }
    }
}
