using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetAbnormalSearch : IAttend_View_GetAbnormalSearch
    {
        private IUnitOfWork _unitOfWork;
        public Attend_View_GetAbnormalSearch(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<AbnormalSearchViewDto>> GetAbnormalSearchView(AbnormalSearchViewEntry abnormalSearchViewEntry)
        {
            ApiResult<List<AbnormalSearchViewDto>> apiResult = new ApiResult<List<AbnormalSearchViewDto>>();
            apiResult.State = false;
            try
            {
                var result = new List<AbnormalSearchViewDto>();
                foreach (var item in abnormalSearchViewEntry.EmployeeList.Split(2100))
                {
                    DateTime today = DateTime.Today;
                    var AbnormalsByEntry = from aa in _unitOfWork.Repository<AttendAbnormal>().Reads()
                                           join atc in _unitOfWork.Repository<Attcard>().Reads() on new { X1= aa.Adate, X2 = aa.Nobr} equals new { X1 = atc.Adate, X2 = atc.Nobr }
                                           into atcgrp
                                           from atcg in atcgrp.DefaultIfEmpty()
                                           join mt in _unitOfWork.Repository<Mtcode>().Reads() on new { X1 = aa.Type, X2 = "ATTEND_ABNORMAL" } equals new { X1 = mt.Code, X2 = mt.Category }
                                           join b in _unitOfWork.Repository<Base>().Reads() on aa.Nobr equals b.Nobr
                                           join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                                           join r in _unitOfWork.Repository<Rote>().Reads() on aa.RoteCode equals r.Rote1
                                           join d in _unitOfWork.Repository<Dept>().Reads() on btts.Dept equals d.DNo
                                           join aac in _unitOfWork.Repository<AttendAbnormalCheck>().Reads() on new { X1 = aa.Nobr, X2 = aa.Adate, X3 = aa.Type } equals new { X1 = aac.Nobr, X2 = aac.Adate, X3 = aac.Type }
                                           into accGrp
                                           from acg in accGrp.DefaultIfEmpty()
                                           join mt1 in _unitOfWork.Repository<Mtcode>().Reads() on new { X1 = "ATTEND_ABNORMAL_CHECK", X2 = acg.RemarkType } equals new { X1 = mt1.Category, X2 = mt1.Code }
                                           into mt1Grp
                                           from dmt1 in mt1Grp.DefaultIfEmpty()
                                           where item.Contains(aa.Nobr)
                                           && abnormalSearchViewEntry.DateBegin <= aa.Adate && aa.Adate <= abnormalSearchViewEntry.DateEnd
                                           && (btts.Ddate >= today && btts.Adate <= today)
                                           && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                                           select new AbnormalSearchViewDto
                                           {
                                               EmployeeID = b.Nobr,
                                               EmployeeName = b.NameC,
                                               DeptCode = d.DNo,
                                               DeptName = d.DName,
                                               IsCheck = false,
                                               AttendDate = aa.Adate,
                                               CardOnTime = atcg.T1,
                                               CardOffTime = atcg.T2,
                                               RoteName = r.Rotename,
                                               RoteOnTime = r.OnTime,
                                               RoteOffTime = r.OffTime,
                                               AbnormalErrorMins = aa.ErrorMins,
                                               AbnormalType = mt.Code,
                                               AbnormalName = mt.Name,
                                               RemarkType = dmt1.Code,
                                               RemarkTypeName = dmt1.Name,
                                               Serno = acg.Serno
                                           };

                    if (abnormalSearchViewEntry.IsNoCheck)
                    {
                        AbnormalsByEntry = from a in AbnormalsByEntry
                                           where String.IsNullOrEmpty(a.RemarkType)
                                           select a;
                    }

                    result.AddRange(AbnormalsByEntry);
                }
                result.ForEach(r => { if (!String.IsNullOrEmpty(r.RemarkType)){ r.IsCheck = true; } });

                apiResult.State = true;
                apiResult.Result = result.ToList();

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;
        }
    }
}
