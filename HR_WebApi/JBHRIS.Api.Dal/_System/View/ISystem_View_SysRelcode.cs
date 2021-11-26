using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysRelcode
    {
        public List<RelcodeDto> GetRelcodeView();
    }
}
