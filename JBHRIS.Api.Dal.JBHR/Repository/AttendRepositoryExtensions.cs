using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Action;

namespace JBHRIS.Api.Dal.JBHR
{
    public static class AttendRepositoryExtensions
    {
        public static IQueryable<T> GetCurrentOnJob<T>(this IRepository<T> repository, List<string> employeeList, DateTime BeginDate,DateTime EndDate)
        where T : Basetts
        {
            var result = repository.Reads().Where(p => employeeList.Contains(p.Nobr) && new string[] { "1", "4", "6" }.Contains(p.Ttscode) && EndDate >= p.Adate && BeginDate <= p.Ddate);
            return result;
        }
        public static IQueryable<T> GetCurrentOnJob<T>(this IRepository<T> repository, DateTime BeginDate, DateTime EndDate)
        where T : Basetts
        {
            var result = repository.Reads().Where(p => new string[] { "1", "4", "6" }.Contains(p.Ttscode) && EndDate >= p.Adate && BeginDate <= p.Ddate);
            return result;
        }

    }
}
