using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public class AbnormalViewService: IAbnormalViewService
    {
        IAttend_View_GetAbnormalSearch _attend_View_GetAbnormalSearch;
        public AbnormalViewService(IAttend_View_GetAbnormalSearch  attend_View_GetAbnormalSearch)
        {
            _attend_View_GetAbnormalSearch = attend_View_GetAbnormalSearch;
        }

        public ApiResult<List<AbnormalSearchViewDto>> GetAbnormalSearchView(AbnormalSearchViewEntry abnormalSearchViewEntry)
        {
            return _attend_View_GetAbnormalSearch.GetAbnormalSearchView(abnormalSearchViewEntry);
        }
    }
}
