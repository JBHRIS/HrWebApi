using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public class OverTimeViewService : IOverTimeViewService
    {
        IAttend_View_GetOvertimeSearch _IAttend_View_GetOvertimeSearch;
        public OverTimeViewService(IAttend_View_GetOvertimeSearch IAttend_View_GetOvertimeSearch)
        {
            _IAttend_View_GetOvertimeSearch = IAttend_View_GetOvertimeSearch;
        }

        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            return _IAttend_View_GetOvertimeSearch.GetOvertimeReason();
        }

        public ApiResult<List<OverTimeSearchViewDto>> GetOverTimeSearchView(OverTimeSearchViewEntry overTimeSearchViewEntry)
        {
            return _IAttend_View_GetOvertimeSearch.GetOverTimeSearchView(overTimeSearchViewEntry);
        }
    }
}
