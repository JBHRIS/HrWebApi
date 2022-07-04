using System;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class EmployeeBirthdayViewDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}