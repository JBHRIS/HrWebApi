using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee.View
{
    public class Employee_View_GetDepta : IEmployee_View_GetDepta
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetDepta(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DeptDto> GetDeptaView()
        {
            DateTime today = DateTime.Today;
            var data = _unitOfWork.Repository<Depta>().Reads().Where(p => today >= p.Adate && today <= p.Ddate)
                .Select(p => new DeptDto
                {
                    DepartmentId = p.DNo,
                    DepartmentName = p.DName,
                    DepartmentNameE = p.DEname,
                    DepartmentIdDisplay = p.DNoDisp

                }).ToList();
            return data;
        }
    }
}
