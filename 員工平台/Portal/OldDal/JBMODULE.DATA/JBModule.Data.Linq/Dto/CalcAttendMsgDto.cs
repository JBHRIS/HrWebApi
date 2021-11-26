using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class CalcAttendMsgDto
    {
        public string Nobr { get; set; }
        public string Name { get; set; }
        public decimal Amt { get; set; }
        public string Rote { get; set; }
        public string RoteName { get; set; }
        public string Salcode { get; set; }
        public string SalName { get; set; }
        public string RoteBonus { get; set; }
        public DateTime Bdate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string Function { get; set; }
        public string FunctionName { get; set; }
        public bool checkAtt { get; set; }
        public bool checkOt{ get; set; }
    }
}
