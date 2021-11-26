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
    public class GetEmpService : IGetEmpInterface
    {
        private ISystem_Emp_View _system_Emp_View;
        public GetEmpService(ISystem_Emp_View system_Emp_View)
        {
            this._system_Emp_View = system_Emp_View;
        }


        public List<EmpDto> GetEmpList()
        {
            return this._system_Emp_View.GetEmpList();
        }
        public List<EmpDto> GetEmpListByEmpId(List<string> EmpIdList)
        {
            return this._system_Emp_View.GetEmpListByEmpId(EmpIdList);
        }
    }
}
