using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class ListItemDto
    {

       
    }
    public class DeptList
    {
        public List<string> DeptId { get; set; }
    }

    public class EmpList
    {
        public List<string> EmpId { get; set; }
    }
    public class ProcessList
    {
        public List<string> ProcessId { get; set; }
    }
    public class CodeList
    { 
        public List<string> CodeId { get; set; }
    }
    public class IdList
    { 
        public List<int> Id { get; set; }
    }
}
