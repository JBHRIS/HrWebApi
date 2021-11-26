using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetDept : IEmployee_View_GetDept
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetDept(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DeptDto> GetDeptView()
        {
            var data = from p in _unitOfWork.Repository<Dept>().Reads()
                       join b in _unitOfWork.Repository<Base>().Reads() on p.Nobr equals b.Nobr
                       into bgrp
                       from bg in bgrp.DefaultIfEmpty()
                       where DateTime.Now >= p.Adate && DateTime.Now <= p.Ddate
                       select new DeptDto
                       {
                           DepartmentId = p.DNo,
                           DepartmentName = p.DName,
                           DepartmentNameE = p.DEname,
                           DepartmentIdDisplay = p.DNoDisp,
                           DirectorEmployeeId = bg.Nobr,
                           DirectorEmployeeName = bg.NameC
                       };
            return data.ToList();
        }
    }
}
