
using System;

namespace JBHR.Att
{
    public class AbsentEntitle
    {
        public string EmployeeId { get; set; }
        public string Hcode { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Entitle { get; set; }
        public decimal Taken { get; set; }
        public decimal Balance { get; set; }
        public string Guid { get; set; }
    }
}