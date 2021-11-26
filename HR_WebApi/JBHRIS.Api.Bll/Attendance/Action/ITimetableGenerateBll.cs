using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using System.Collections.Generic;
using System.Linq;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public interface ITimetableGenerateBll
    {      
        List<TmtableDto> Generate(string YYMM, List<EmployeeInfo_HoliCode> employeeInfos_HoliCode, List<RotetDto> rotetList, List<HoliDto> calendarList, List<TmtableImportDto> tmtableImportDtos);
    }
}