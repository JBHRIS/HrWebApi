using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBHRIS.BLL.Dto
{
    public class AbsTakenDto
    {
        public string EmployeeID;
        public string Hcode;
        public string YYMM;
        public DateTime AttendDate;
        public DateTime BeginTime;
        public DateTime EndTime;
        public decimal Taken;
        public string Remark;
        public string Serno;
        public string CreateMan;
        public string Guid;
        public object PrimaryKey;
        public object Field01;
        public object Field02;
        public bool CheckAttendConflict = true;
        public bool Syscreate = false;
    }
}
