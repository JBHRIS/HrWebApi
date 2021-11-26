using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement
{
    public class TestService : ITestInterface
    {
        private ISystem_Dept_View _system_Dept_View;
        public TestService(ISystem_Dept_View system_Dept_View)
        {
            this._system_Dept_View = system_Dept_View;
        }

        public List<ItemKeyValue> GetDeptList()
        {
            throw new NotImplementedException();
        }
    }
}
