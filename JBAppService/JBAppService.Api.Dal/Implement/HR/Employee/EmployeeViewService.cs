using JBAppService.Api.Dal.Interface.Employee;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.HR.Employee
{
    public class EmployeeViewService: IEmployeeViewService
    {

        private JBHRContext _context;
        public EmployeeViewService(JBHRContext context)
        {
            this._context = context;
        }

        public List<EmployeeJobViewDto> GetEmployeeJobView(List<string> employeeList)
        {
            List<EmployeeJobViewDto> result = new List<EmployeeJobViewDto>();

            result = (from a in this._context.Basetts
                      join b in this._context.Base on a.Nobr equals b.Nobr
                      join d in this._context.Dept on a.Dept equals d.DNo into ad
                      from adg in ad.DefaultIfEmpty()
                      join j in this._context.Job on a.Job equals j.Job1 into aj
                      from ajg in aj.DefaultIfEmpty()
                      where DateTime.Today >= a.Adate && DateTime.Today <= a.Ddate
                      && employeeList.Contains(a.Nobr)
                      && new string[] { "1", "4", "6" }.Contains(a.Ttscode)
                      select new EmployeeJobViewDto
                      {
                          Company = a.Comp,
                          Department = a.Dept,
                          DepartmentName = adg.DName,
                          EmployeeId = a.Nobr,
                          EmployeeName = b.NameC,
                          Job = ajg.JobDisp,
                          JobName = ajg.JobName,
                      }).ToList();
            return result;
        }
		//PSWAPBTXTTCFNCTYAAPLSOLOQSCOINNAKDARKK
    }
}
