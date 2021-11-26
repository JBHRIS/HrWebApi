using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public class CardViewService : ICardViewService
    {
        IAttend_View_GetCardSearch _Attend_View_GetCardSearch;
        public CardViewService(IAttend_View_GetCardSearch Attend_View_GetCardSearch) 
        {
            _Attend_View_GetCardSearch = Attend_View_GetCardSearch;
        }

        public ApiResult<List<CardSearchViewDto>> GetCardSearchView(CardSearchViewEntry cardSearchViewEntry)
        {
            return _Attend_View_GetCardSearch.GetCardSearchView(cardSearchViewEntry);
        }
    }
}
