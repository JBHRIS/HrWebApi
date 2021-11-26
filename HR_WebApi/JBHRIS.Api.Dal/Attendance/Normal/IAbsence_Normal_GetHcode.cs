using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsence_Normal_GetHcode
    {
        List<HcodeDto> GetHcode();
        HcodeDto GetHcodeById(string code);
    }
}
