using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Models.JBContent;

namespace JBAppService.Api.Dal.Implement.JB
{
    public class AttEndHandler : IAttEndHandler
    {

        private JBDBContent _JBDBContent;

        public AttEndHandler(JBDBContent content)
        {
            this._JBDBContent = content;
        }

        public List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {

            List<AttEndDetailDto> rdlist = new List<AttEndDetailDto>();
            try
            {
                rdlist = (from b in this._JBDBContent.HRM_BASE_BASE
                          join at in this._JBDBContent.HRM_ATTEND_ATTEND on b.EMPLOYEE_ID equals at.EMPLOYEE_ID
                          join c in this._JBDBContent.HRM_ATTEND_ATTEND_CARD on b.EMPLOYEE_ID equals c.EMPLOYEE_ID
                          join r in this._JBDBContent.HRM_ATTEND_ROTE on at.ROTE_ID equals r.ROTE_ID
                          where b.EMPLOYEE_CODE == Nobr && BDate <= at.ATTEND_DATE && at.ATTEND_DATE <= EDate
                          select new AttEndDetailDto
                          {
                              Nobr = b.EMPLOYEE_CODE,
                              ADate = at.ATTEND_DATE.Value,
                              RoteCode = r.ROTE_CODE,
                              RoteName = r.ROTE_CNAME,
                              ON_Time = r.ON_TIME,
                              OFF_Time = r.OFF_TIME,
                              T1 = c.ON_TIME,
                              T2 = c.OFF_TIME
                          }).ToList();


                /* { "接近 'OFFSET' 之處的語法不正確。\r\nFETCH 陳述式中的選項 NEXT 使用方式無效。"}
                     * sql serivce 需要20082r2 
                     * 只有 2008
                     */

                rdlist = rdlist.OrderBy(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();
            }
            catch (Exception ex)
            {

            }
           
            return rdlist;
        }
    }
}
