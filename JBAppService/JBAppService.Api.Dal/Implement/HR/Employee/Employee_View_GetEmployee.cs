using JBAppService.Api.Dal.Interface.Employee;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR.Employee
{
    public class Employee_View_GetEmployee : IEmployee_View_GetEmployee
    {
        private JBHRContext _context;
        public Employee_View_GetEmployee(JBHRContext context)
        {
            this._context = context;
        }
        public List<ApiRolesDto> GetApiRoles(List<string> Nobr)
        {
            List<ApiRolesDto> result = new List<ApiRolesDto>();


            
            return result;


        }
    }
}
