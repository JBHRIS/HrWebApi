using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Salary.View
{
    public interface ISalary_View_SalaryChangeView
    {
        ApiResult<List<GetSalaryChangeDto>> GetSalaryChange(string Nobr, DateTime CheckDate);//取得薪資異動資料
        ApiResult<string> AddSalaryChange(SalaryChangeInfoDto salaryInfo);
        ApiResult<string> CheckSalaryChangeAvailable(SalaryChangeInfoDto salaryInfo);
    }
}
