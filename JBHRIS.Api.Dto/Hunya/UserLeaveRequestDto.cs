using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Hunya
{
    public class UserLeaveRequestDto
    {
        public string cmd { get; set; }
        public List<LeaveRequestDto> cmds { get; set; }
        public string sessionid { get; set; }
    }
    public class LeaveRequestDto
    {
        public string cmd { get; set; }
        public string 工號 { get; set; }
        public string 請假起始 { get; set; }
        public string 請假結束 { get; set; }
    }
}
