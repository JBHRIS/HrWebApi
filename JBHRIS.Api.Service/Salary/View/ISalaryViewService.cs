using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Entry;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Salary.View
{
    public interface ISalaryViewService
    {
        string GetSalaryYymm(DateTime date, string Nobr);
        bool IsAttendLock(DateTime date, string Nobr);
        GetSalDateCycleDto GetSalDateCycle(DateTime date, string Nobr);
        GetAttDateCycleDto GetAttDateCycle(DateTime date, string Nobr);
        List<GetSalaryWageLockDto> GetSalaryWageLock(string Nobr);
        List<GetSalaryWageLockDto> GetSalaryWageLockByEmpList(List<string> EmpList);
        ApiResult<string> SetSalaryPassWord(string Nobr,string Password);
        ApiResult<string> DeleteSalaryPassWord(string Nobr);
        ApiResult<string> CheckSalaryPassWord(string Nobr, string Password);

        decimal GetAnnualLeave(string Nobr, string YYMM, string Seq);//取得特休剩餘時數
        decimal GetCompensatoryLeave(string Nobr, string YYMM, string Seq);//取得補休剩餘時數

        GetPayslipTitleDto GetPayslipTitle(string Nobr, string YYMM, string Seq);//薪資單主檔
        List<BlockDetailDto> GetAbsThisMonth(string Nobr, string YYMM);//本月請假
        List<BlockDetailDto> GetOtThisMonth(string Nobr, string YYMM);//本月加班
        List<BlockDetailDto> GetEarningsThisMonth(string Nobr,string YYMM,string Seq);//本月所得
        List<BlockDetailDto> GetDeductionThisMonth(string Nobr, string YYMM, string Seq);//本月扣款
        List<BlockDetailDto> GetSalaryThisMonth(string Nobr, string YYMM, string Seq);//本月實發薪資
        List<BlockDetailDto> GetRetirementThisMonth(string Nobr, string YYMM);//本月勞退新制

        ApiResult<List<GetSalaryChangeDto>> GetSalaryChange(string Nobr, DateTime CheckDate);//取得薪資異動資料
        ApiResult<string> AddSalaryChange(SalaryChangeInfoDto salaryInfo);//薪資異動
        List<GetSalaryCodeDto> GetSalaryCode();//薪資代碼

    }
}
