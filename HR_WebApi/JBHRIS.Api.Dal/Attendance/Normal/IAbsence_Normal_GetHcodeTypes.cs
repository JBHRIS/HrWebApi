using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsence_Normal_GetHcodeTypes
    {
        List<HcodeTypeDto> GetHcodeTypes();
    }
}
