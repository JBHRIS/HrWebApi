using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Entry;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.Salary.View
{
    public interface ISalary_View_SalaryView
    {
        string GetUnLockYYMM(DateTime date, string Saladr,int AttEndDay);
        bool IsLockedYYMM(DateTime date, string Saladr,int AttEndDay);
        bool CheckAttendLock(DateTime date, string Saladr);
        decimal GetAnnualLeave(string Nobr, DateTime dateTime);//取得特休剩餘時數
        decimal GetCompensatoryLeave(string Nobr, DateTime dateTime);//取得補休剩餘時數
        IQueryable<GetSalaryDto> GetSalary(string Nobr, string YYMM, string Seq);
        IQueryable<GetPayslipTitleDto> GetPayslipTitle(string Nobr, string YYMM, string Seq);
        IQueryable<GetRetirementDto> GetRetirement(string Nobr, string YYMM);
        IQueryable<GetAbsDto> GetAbs(string Nobr, string YYMM);
        IQueryable<GetOtDto> GetOt(string Nobr, string YYMM);
        List<GetSalaryWageLockDto> GetSalaryWageLock(string Nobr);
        List<GetSalaryWageLockDto> GetSalaryWageLockByEmpList(List<string> EmpList);
        ApiResult<string> CheckSalaryPassWord(string Nobr, string Password);
        ApiResult<string> SetSalaryPassWord(string Nobr, string Password);
        ApiResult<string> DeleteSalaryPassWord(string Nobr);
        /// <summary>
        /// 取得員工出勤鎖檔日期
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<DateTime> GetDataPassList(string Nobr,DateTime beginDate,DateTime endDate);

        List<GetSalaryCodeDto> GetSalaryCode();

        /// <summary>
        /// 取得不扣應發的薪資代碼
        /// </summary>
        /// <returns></returns>
        List<GetSalaryCodeDto> GetRetSalaryCode(string saladr);
    }
}
