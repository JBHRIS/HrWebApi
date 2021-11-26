using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppShiftLongService : IFormsAppShiftLongInterface
    {
        private ISystem_FormsAppShiftLong_View _ISystem_FormsAppShiftLong_View;
        public FormsAppShiftLongService(ISystem_FormsAppShiftLong_View system_FormsAppShiftLong_View)
        {
            this._ISystem_FormsAppShiftLong_View = system_FormsAppShiftLong_View;
        }

        public List<ShiftLongVdb> GetFormsAppShiftLongByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppShiftLong_View.GetFormsAppShiftLongByProcessId(ProcessFlowID,  Sign,  SignState,  Status);
        }
    }
}
