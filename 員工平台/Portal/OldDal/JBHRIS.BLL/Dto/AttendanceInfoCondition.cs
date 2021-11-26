using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttendanceInfoCondition
    {
        public AttendanceInfoCondition()
        {
            EmployeeList = new List<string>();
        }
        public List<string> EmployeeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public bool RefreshStatus { get; set; }
        //public CalculationMode CalcMode { get; set; }
    }
    //public enum CalculationMode
    //{
    //    Normal,
    //    Fast,
    //}
}
