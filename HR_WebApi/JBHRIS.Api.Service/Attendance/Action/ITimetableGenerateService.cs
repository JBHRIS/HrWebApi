using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Action
{
    public interface ITimetableGenerateService
    {
        ApiResult<List<TmtableDto>> Generate(TimetableGenerateEntry timetableGenerateEntry);
    }
}
