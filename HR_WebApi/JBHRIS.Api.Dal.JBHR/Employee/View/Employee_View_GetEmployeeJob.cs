using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Linq;
//using System.Data.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetEmployeeJob : IEmployee_View_GetEmployeeJob
    {
        private IUnitOfWork _unitOfWork;

        public Employee_View_GetEmployeeJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<EmployeeJobViewDto> GetEmployeeJobView(List<string> employeeList)
        {
            var sql = from a in _unitOfWork.Repository<Basetts>().Reads()
                      join b in _unitOfWork.Repository<Base>().Reads() on a.Nobr equals b.Nobr
                      join da in _unitOfWork.Repository<Depta>().Reads() on a.Deptm equals da.DNo
                      join d in _unitOfWork.Repository<Dept>().Reads() on a.Dept equals d.DNo into ad
                      from adg in ad.DefaultIfEmpty()
                      join j in _unitOfWork.Repository<Job>().Reads() on a.Job equals j.Job1 into aj
                      from ajg in aj.DefaultIfEmpty()
                      where DateTime.Today >= a.Adate && DateTime.Today <= a.Ddate
                      && employeeList.Contains(a.Nobr)
                      && new string[] { "1", "4", "6" }.Contains(a.Ttscode)
                      select new EmployeeJobViewDto
                      {
                          IsDeptMang = (adg.Nobr == null || adg.Nobr.Trim().Length == 0) ? false:true,
                          Company = a.Comp,
                          Department = a.Dept,
                          DepartmentName = adg.DName,
                          DeptA = da.DNo,
                          DeptAName = da.DName,
                          EmployeeId = a.Nobr,
                          EmployeeName = b.NameC,
                          Job = ajg.JobDisp,
                          JobName = ajg.JobName,
                          Saladr = a.Saladr
                      };
            return sql.ToList();
        }
    }
}
