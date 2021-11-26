using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormAppOTService : IFormAppOTInterface
    {


        private ISystem_FormsOT_View _ISystem_FormsOT_View;

        public FormAppOTService(ISystem_FormsOT_View ISystem_FormsOT_View)
        {
            this._ISystem_FormsOT_View = ISystem_FormsOT_View;
        }

        public OTFlowAppRow GetFormsAppOTByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsOT_View.GetFormsAppOTByProcessId( ProcessFlowID,  Sign,  SignState, Status);
        }

        public OTFlowAppsRow GetFormsAppOTByAutoKey(int AutoKey, string SignState, string Status)
        {
            return this._ISystem_FormsOT_View.GetFormsAppOTByAutoKey(AutoKey, SignState, Status);
        }
    }
}
