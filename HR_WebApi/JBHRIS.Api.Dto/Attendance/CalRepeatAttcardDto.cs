using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CalRepeatAttcardDto
    {
        public List<AttCardDto> RepeatAttcard { get; set; }
        public List<AttCardDto> NoRepeatAttcard { get; set; }
    }
}
