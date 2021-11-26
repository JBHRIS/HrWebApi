using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsence_Normal_GetHcode
    {
        List<HcodeDto> GetHcode();
    }
}