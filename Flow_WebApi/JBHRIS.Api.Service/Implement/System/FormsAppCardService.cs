using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsAppCardService : IFormsAppCardInterface
    {
        private ISystem_FormsAppCard_View _ISystem_FormsAppCard_View;

        public FormsAppCardService(ISystem_FormsAppCard_View system_FormsAppCard_View)
        {
            this._ISystem_FormsAppCard_View = system_FormsAppCard_View;
        }

        public CardFlowAppRow GetFormsAppCardByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            return this._ISystem_FormsAppCard_View.GetFormsAppCardByProcessId( ProcessFlowID,  Sign,  SignState,  Status);
        }
    }
}
