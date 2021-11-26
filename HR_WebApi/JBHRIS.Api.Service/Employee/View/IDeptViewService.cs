using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Employee.View;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Employee.View
{
    public interface IDeptViewService
    {
        /// <summary>
        /// 取得編制部門代碼
        /// </summary>
        /// <returns></returns>
        List<DeptDto> GetDeptView();

        List<DeptDto> GetDeptaView();
        List<DeptDto> GetDeptsView();
    }
}