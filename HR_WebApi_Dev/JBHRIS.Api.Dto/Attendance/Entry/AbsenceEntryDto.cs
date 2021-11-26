using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
  public  class AbsenceEntryDto
    {
        public List<string> employeeList { get; set; }
        public List<string> HcodeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
