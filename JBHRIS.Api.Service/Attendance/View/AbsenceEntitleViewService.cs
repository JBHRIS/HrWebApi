using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public class AbsenceEntitleViewService : IAbsenceEntitleViewService
    {
        IAttend_View_GetAbsenceEntitleView _attend_View_GetAbsenceEntitleView;
        ISalary_View_SalaryView _salary_View_SalaryView;

        public  AbsenceEntitleViewService(IAttend_View_GetAbsenceEntitleView attend_View_GetAbsenceEntitleView,
            ISalary_View_SalaryView salary_View_SalaryView) {
            _attend_View_GetAbsenceEntitleView = attend_View_GetAbsenceEntitleView;
            _salary_View_SalaryView = salary_View_SalaryView;
        }

        public ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry abseneceEntitleViewEntry)
        {
            return _attend_View_GetAbsenceEntitleView.GetAbsenceEntitleView(abseneceEntitleViewEntry);
        }

        public decimal GetAnnualLeave(string Nobr, DateTime dateTime)
        {
            return _salary_View_SalaryView.GetAnnualLeave(Nobr, dateTime);
        }

        public decimal GetCompensatoryLeave(string Nobr, DateTime dateTime)
        {
            return _salary_View_SalaryView.GetCompensatoryLeave(Nobr, dateTime);
        }
    }
}
