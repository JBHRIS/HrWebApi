using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class FormsService : IFormsInterface
    {
        private ISystem_Forms_View _system_Forms_View;
        public FormsService(ISystem_Forms_View system_Forms_View)
        {
            this._system_Forms_View = system_Forms_View;
        }

        public List<FormsDto> GetFormsList()
        {
            return this._system_Forms_View.GetFormsList();
        }

        public List<FormsDto> GetFormsListByCode(List<string> CodeList)
        {
            return this._system_Forms_View.GetFormsListByCode(CodeList);
        }

        public int GetProcessID()
        {
            return this._system_Forms_View.GetProcessID();
        }
    }
}
