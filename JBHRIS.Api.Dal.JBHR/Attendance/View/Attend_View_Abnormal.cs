using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_Abnormal : IAttend_View_Abnormal
    {
        private IUnitOfWork _unitOfWork;
        public Attend_View_Abnormal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AbnormalViewDto> GetAbnormalViewDtos(AttendanceEntry attendanceEntry)
        {

            var abnormalsSql = from aa in _unitOfWork.Repository<AttendAbnormal>().Reads()
                               join mt in _unitOfWork.Repository<Mtcode>().Reads() on new { X1 = aa.Type, X2 = "ATTEND_ABNORMAL" } equals new { X1 = mt.Code, X2 = mt.Category }
                               join bs in _unitOfWork.Repository<Base>().Reads() on aa.Nobr equals bs.Nobr
                               join rt in _unitOfWork.Repository<Rote>().Reads() on aa.RoteCode equals rt.Rote1
                               join aac in _unitOfWork.Repository<AttendAbnormalCheck>().Reads() on new { X1 = aa.Nobr, X2 = aa.Adate, X3 = aa.Type } equals new { X1 = aac.Nobr, X2 = aac.Adate, X3 = aac.Type }
                               into accGrp
                               from acg in accGrp.DefaultIfEmpty()
                               join mt1 in _unitOfWork.Repository<Mtcode>().Reads() on new { X1 = "ATTEND_ABNORMAL_CHECK", X2 = acg.RemarkType } equals new { X1 = mt1.Category, X2 = mt1.Code }
                               into mt1Grp
                               from dmt1 in mt1Grp.DefaultIfEmpty()
                               where attendanceEntry.EmployeeList.Contains(aa.Nobr)
                               && attendanceEntry.DateBegin <= aa.Adate
                               && aa.Adate <= attendanceEntry.DateEnd
                               select new AbnormalViewDto()
                               {
                                   EmployeeId = aa.Nobr,
                                   EmployeeName = bs.NameC,
                                   AttendanceDate = aa.Adate,
                                   Type = aa.Type,
                                   State = mt.Name,
                                   ErrorMins = aa.ErrorMins,
                                   OnTime = aa.OnTime,
                                   OffTime = aa.OffTime,
                                   ActualOnTime = aa.OnTimeActual,
                                   ActualOffTime = aa.OffTimeActual,
                                   RoteName = rt.Rotename,
                                   IsCheck = false,
                                   Remark = dmt1.Name,
                                   Serno = acg.Serno,
                                   RemarkType = acg.RemarkType
                               };

            List<AbnormalViewDto> listAbnormals = new List<AbnormalViewDto>();
            listAbnormals = abnormalsSql.ToList();
            listAbnormals.ForEach(a =>
            {
                if (!String.IsNullOrEmpty(a.Remark))
                {
                    a.IsCheck = true;
                }
            });

            return listAbnormals;
        }

        public ApiResult<string> SaveAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos, string KeyMan)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<AttendAbnormalCheck>();
                foreach (var a in abnormalViewDtos)
                {
                    AttendAbnormalCheck attendAbnormalCheck = new AttendAbnormalCheck()
                    {
                        Nobr = a.EmployeeId,
                        Adate = a.AttendanceDate.Date,
                        Type = a.Type,
                        RemarkType = a.RemarkType,
                        Remark = a.Remark,
                        Serno = a.Serno,
                        CreateDate = DateTime.Now,
                        CreateMan = KeyMan,
                        UpdateDate = DateTime.Now,
                        UpdateMan = KeyMan
                    };
                    Repo.Create(attendAbnormalCheck);
                }
                Repo.SaveChanges();
                statusResultDto.State = true;
            }
            catch (Exception ex)
            {
                statusResultDto.Message = ex.Message;
                statusResultDto.StackTrace = ex.StackTrace;
            }
            return statusResultDto;
        }
    }
}
