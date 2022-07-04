using System;

namespace HR_WebApi.Dto.Attendance
{
    /*
     * 工號,AB分流,工作地(生效日、失效日=>可能長期下來還是有機會改變)
     */
    public class DiversionGroupDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiversionGroupType { get; set; }
        public string WorkLocation { get; set; }

    }
}