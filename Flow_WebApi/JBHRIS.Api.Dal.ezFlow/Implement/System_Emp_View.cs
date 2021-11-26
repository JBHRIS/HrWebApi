using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto.System;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_Emp_View : ISystem_Emp_View
    {

        private ezFlowContext _context;

        public System_Emp_View(ezFlowContext ezFlowContext) {

            this._context = ezFlowContext;
        }

        public List<EmpDto> GetEmpList()
        {
            List<EmpDto> result = new List<EmpDto>();

            result = (from d in _context.Emps
                      select new EmpDto
                      {
                          EmpId = d.id,
                          Password = d.pw,
                          EmpName = d.name,
                          IsNeedAgent = (bool)d.isNeedAgent,
                          Email = d.email,
                          Sex = d.sex
                      }).ToList();

            return result;
        }

        public List<EmpDto> GetEmpListByEmpId(List<string> EmpIdList)
        {
            List<EmpDto> result = new List<EmpDto>();
            result = (from d in _context.Emps
                      where EmpIdList.Contains(d.id)
                      select new EmpDto
                      { 
                        EmpId = d.id,
                        EmpName = d.name,
                        Password = d.pw,
                        IsNeedAgent = (bool)d.isNeedAgent,
                        Email = d.email,
                        Sex = d.sex
                      }).ToList();
            return result;
        }
    }
}
