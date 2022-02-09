using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetAbsenceEntitleView: IAttend_View_GetAbsenceEntitleView
    {
        private IUnitOfWork _unitOfWork;

        public Attend_View_GetAbsenceEntitleView(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry abseneceEntitleViewEntry)
        {
            ApiResult<List<AbsenceEntitleViewDto>> apiResult = new ApiResult<List<AbsenceEntitleViewDto>>();
            apiResult.State = false;
            try
            {
                var result = new List<AbsenceEntitleViewDto>();
                foreach (var item in abseneceEntitleViewEntry.EmployeeList.Split(2100))
                {
                    DateTime today = DateTime.Today;
                    var AbsencesTakenByEntry = from abs in _unitOfWork.Repository<Abs>().Reads()
                                               join b in _unitOfWork.Repository<Base>().Reads() on abs.Nobr equals b.Nobr
                                               join h in _unitOfWork.Repository<Hcode>().Reads() on abs.HCode equals h.HCode1
                                               join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                                               join d in _unitOfWork.Repository<Dept>().Reads() on btts.Dept equals d.DNo
                                               where item.Contains(abs.Nobr)
                                               && (abseneceEntitleViewEntry.LeaveCodeList.Count > 0 ? abseneceEntitleViewEntry.LeaveCodeList.Contains(h.HCode1) : true)
                                               && h.Flag == "+"
                                               && (abs.Edate >= abseneceEntitleViewEntry.DateBegin && abs.Bdate <= abseneceEntitleViewEntry.DateEnd)
                                               && (btts.Ddate >= today && btts.Adate <= today)
                                               && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                                               select new AbsenceEntitleViewDto
                                               {
                                                   EmployeeId = abs.Nobr,
                                                   EmployeeName = b.NameC,
                                                   LeaveCode = h.HCodeDisp,
                                                   LeaveName = h.HName,
                                                   BeginDate = abs.Bdate,
                                                   EndDate = abs.Edate,
                                                   Entitle = abs.TolHours,
                                                   Taken = (decimal)abs.LeaveHours,
                                                   Balance = (decimal)abs.Balance,
                                                   Unit = h.Unit,
                                                   Remark = abs.Note,
                                                   DepartmentCode = d.DNo,
                                                   DepartmentName = d.DName
                                               };
                    result.AddRange(AbsencesTakenByEntry);
                }
                apiResult.State = true;
                apiResult.Result = result.ToList();
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

    }
}
