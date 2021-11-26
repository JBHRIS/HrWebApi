using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Overtime_Normal_GetOvertimeByDate : IOvertime_Normal_GetOvertimeByDate
    {
        private IUnitOfWork _unitOfWork;
        public Overtime_Normal_GetOvertimeByDate(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<OvertimeByDateDto> GetOvertimeByDate(OvertimeByDateEntry overtimeByDateEntry)
        {
                var result = new List<OvertimeByDateDto>();
                foreach (var item in overtimeByDateEntry.EmployeeList.Split(2100))
                {
                    var OverTimesByEntry = from ot in _unitOfWork.Repository<Ot>().Reads()
                                           where item.Contains(ot.Nobr)
                                           && overtimeByDateEntry.DateBegin <= ot.Bdate &&  overtimeByDateEntry.DateEnd >= ot.Bdate
                                           select new OvertimeByDateDto
                                           {
                                               EmployeeId = ot.Nobr,
                                               OvertimeDate = ot.Bdate,
                                               BeginTime = ot.Btime,
                                               EndTime = ot.Etime,
                                               OvertimeHours = ot.TotHours,
                                               ExpenseHours = ot.OtHrs,
                                               RestHours = ot.RestHrs
                                           };
                    result.AddRange(OverTimesByEntry.ToList());
                }

            return result;
        }
    }
}
