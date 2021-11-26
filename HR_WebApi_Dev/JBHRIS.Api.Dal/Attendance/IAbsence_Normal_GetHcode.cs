using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsence_Normal_GetHcode
    {
        List<HcodeDto> GetHcode(List<string> HcodeList);
    }
}