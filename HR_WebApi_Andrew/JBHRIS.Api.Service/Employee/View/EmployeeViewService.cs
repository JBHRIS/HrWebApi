using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.View
{
    public class EmployeeViewService : IEmployeeViewService
    {
        private IEmployee_View_GetEmployeeBirthday _getEmployeeBirthdayView;
        private IEmployee_View_GetEmployee _getEmployeeView;

        public EmployeeViewService(IEmployee_View_GetEmployeeBirthday getEmployeeBirthdayView 
            , IEmployee_View_GetEmployee getEmployeeView)
        {
            _getEmployeeBirthdayView = getEmployeeBirthdayView;
            _getEmployeeView = getEmployeeView;
        }
        public List<EmployeeBirthdayViewDto> GetEmployeeBirthdayView(int Month, int Day)
        {
            return _getEmployeeBirthdayView.GetEmployeeBirthdayView(Month, Day);
        }
        public List<EmployeeViewDto> GetEmployeeView(List<string> employeeList)
        {
            return _getEmployeeView.GetEmployeeView(employeeList);
        }
    }
}
