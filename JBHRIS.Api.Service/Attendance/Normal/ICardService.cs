using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.Normal;
using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface ICardService
    {
        List<CardDto> GetCard(AttendanceEntry attendanceEntry);
        List<CardReasonDto> GetCardReason();
        bool Insert(CardDto card, out string msg);
        List<CardApplyDto> GetCardApplys();

        /// <summary>
        /// 忘刷存入後端系統
        /// </summary>
        /// <param name="forgetCardApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> SaveForgetCard(ForgetCardApplyDto forgetCardApplyDto);

        /// <summary>
        /// 忘刷檢核
        /// </summary>
        /// <param name="forgetCardApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> CheckForgetCard(ForgetCardApplyDto forgetCardApplyDto);

    }
}