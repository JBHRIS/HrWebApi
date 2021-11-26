using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class AttEndHandler  : IAttEndHandler
    {

        private JBEEPContext _content;

        public AttEndHandler( JBEEPContext context)
        {
            this._content = context;
        }


        public List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            List<AttEndDetailDto> rdlist = new List<AttEndDetailDto>();
            rdlist = (from b in _content.HRM_BASE_BASE
                     join at in _content.HRM_ATTEND_ATTEND on b.EMPLOYEE_ID equals at.EMPLOYEE_ID
                     join c in _content.HRM_ATTEND_ATTEND_CARD on b.EMPLOYEE_ID equals  c.EMPLOYEE_ID
                     join r in _content.HRM_ATTEND_ROTE on at.ROTE_ID equals r.ROTE_ID
                     where b.EMPLOYEE_CODE ==Nobr && BDate <= at.ATTEND_DATE && at.ATTEND_DATE <= EDate
                     select new AttEndDetailDto
                     {
                         Nobr = b.EMPLOYEE_CODE,
                         ADate = at.ATTEND_DATE.Value,
                         RoteCode = r.ROTE_CODE,
                         RoteName = r.ROTE_CNAME,
                         ON_Time = r.ON_TIME,
                         OFF_Time = r.OFF_TIME,
                         T1 = c.ON_TIME_1,
                         T2 = c.OFF_TIME_2
                     }).OrderBy(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();
            return rdlist ;
        }
    }
}
