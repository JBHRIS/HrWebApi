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
    public class FormsAppService : IFormsAppInterface
    {
        private ISystem_FormsApp_View _system_FormsApp_View;
        public FormsAppService(ISystem_FormsApp_View system_FormsApp_View)
        {
            this._system_FormsApp_View = system_FormsApp_View;
        }

        public List<FormsAppDto> GetFormsAppList()
        {
            return _system_FormsApp_View.GetFormsAppList();
        }

        public List<FormsAppDto> GetFormsAppListById(List<int> Id)
        {
            return _system_FormsApp_View.GetFormsAppListById(Id);
        }
    }
}
