using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Files;
using JBHRIS.Api.Dal.JBHR;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class ShiftChange_Normal_SaveDayShiftChange : IShiftChange_Normal_SaveDayShiftChange
    {
        private IUnitOfWork _unitOfWork;
        public ShiftChange_Normal_SaveDayShiftChange(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> SaveDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Rotechg>();

                Rotechg dayShiftChangeImport = new Rotechg
                {
                    Adate = DateTime.Parse(dayShiftChangeApplyDto.ShiftDate.ToString().Trim()),
                    Nobr = dayShiftChangeApplyDto.EmployeeId.Trim(),
                    Rote = dayShiftChangeApplyDto.AfterShiftCode.Trim(),
                    Code = dayShiftChangeApplyDto.Code.Trim(),
                    KeyMan = dayShiftChangeApplyDto.KeyMan,
                    KeyDate = DateTime.Now
                };

                Repo.Create(dayShiftChangeImport);

                Repo.SaveChanges();

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            //apiResult.Result
            return apiResult;
        }
    }
}