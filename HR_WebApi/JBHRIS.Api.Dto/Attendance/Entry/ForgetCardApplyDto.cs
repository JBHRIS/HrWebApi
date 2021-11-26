
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    /// <summary>
    /// 忘刷
    /// </summary>
    public class ForgetCardApplyDto
    {
        public string EmployeeId { get; set; }
        public DateTime CardDate { get; set; }
        public string CardTime { get; set; }
        public string Reason { get; set; }
        public string Cardno { get; set; }
        public string KeyMan { get; set; }
        public string Position { get; set; }
        public bool NotTran { get; set; }
        public string IpAddress { get; set; }
        public string Remark { get; set; }
        public string Serno { get; set; }

        //預設值
        public ForgetCardApplyDto()
        {
            this.NotTran = false;
            this.IpAddress = "";
            this.Remark = "";
            this.Serno = "";
        }
    }
}
