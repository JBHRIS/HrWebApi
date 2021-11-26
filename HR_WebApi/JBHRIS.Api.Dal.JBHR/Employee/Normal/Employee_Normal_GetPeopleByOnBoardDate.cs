using JBHRIS.Api.Dal.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Employee.Normal
{
    public class Employee_Normal_GetPeopleByOnBoardDate : IEmployee_Normal_GetPeopleByOnBoardDate
    {
        private JBHRContext _context;

        ///// <summary>
        ///// 1:到職 , 2:離職 , 3:停薪留職 ,4:停薪復職 , 5:停薪離職 , 6:異動 
        ///// </summary>
        //private List<string> TtscodeList = new List<string> {"1","4","6" };

        public Employee_Normal_GetPeopleByOnBoardDate(JBHRContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得期間到職名單
        /// </summary>
        /// <param name="beginDate">開始日期</param>
        /// <param name="endDate">結束日期</param>
        /// <returns></returns>
        public List<string> GetPeopleByOnBoardDate(List<string> employeeList, DateTime beginDate, DateTime endDate)
        {
            List<string> result = new List<string>();
            foreach (var emps in employeeList.Split(1000))
            {
                result.AddRange(_GetPeopleByOnBoardDate(employeeList, beginDate, endDate));
            }
            return result;
        }

        List<string> _GetPeopleByOnBoardDate(List<string> employeeList, DateTime beginDate, DateTime endDate)
        {
            List<string> result = new List<string>();

            result = (from bt in _context.Basetts
                      where endDate >= bt.Adate && endDate <= bt.Ddate.Value
                      && bt.Indt >= beginDate && bt.Indt <= endDate
                      && employeeList.Contains(bt.Nobr)
                      select bt.Nobr).Distinct().ToList();

            return result;
        }
    }
}
