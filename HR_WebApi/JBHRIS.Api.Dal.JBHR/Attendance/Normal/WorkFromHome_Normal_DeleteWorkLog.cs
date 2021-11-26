using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dal.JBHR.Repository;
using HR_WebApi.Dto.Attendance;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class WorkFromHome_Normal_DeleteWorkLog : IWorkFromHome_Normal_DeleteWorkLog
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_DeleteWorkLog(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 刪除工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> DeleteWorkLog(WorkLogDto workLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<WorkLog>();

                var WorkdLogDelete = Repo.Read(x => x.AutoKey == workLogDto.AutoKey);

                if (WorkdLogDelete != null)
                {
                    Repo.Delete(WorkdLogDelete);

                    Repo.SaveChanges();

                    apiResult.State = true;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }
    }
}
