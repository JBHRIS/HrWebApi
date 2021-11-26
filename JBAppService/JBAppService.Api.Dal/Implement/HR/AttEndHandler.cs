using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class AttEndHandler : IAttEndHandler
    {

        private JBHRContext _context;
        public AttEndHandler(JBHRContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 取得班別 上下班時間
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageRow"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            List<AttEndDetailDto> rdlist = new List<AttEndDetailDto>();
            rdlist = (from a in _context.Attend
                      join r in _context.Rote on a.Rote equals r.Rote1
                      join ac in _context.Attcard on a.Nobr equals ac.Nobr into JoinData
                      from left in JoinData.DefaultIfEmpty()
                      where a.Nobr == Nobr && BDate <= a.Adate && a.Adate <= EDate
                      select new AttEndDetailDto
                      {
                          Nobr = a.Nobr,
                          ADate = a.Adate,
                          RoteCode = a.Rote,
                          RoteName = r.Rotename,
                          ON_Time = r.OnTime,
                          OFF_Time = r.OffTime,
                          T1 = r.OnTime,
                          T2 = r.OffTime
                      }).OrderByDescending(m => m.ADate).Skip((PageNumber - 1) * PageRow).Take(PageRow).ToList();
            return rdlist;
        }
		
		/*1 4 5 30 15 1y 3m*/
		/*browserslist/browserslist/*/
    }
}
