using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_EmployeeInfoRepository
    {
        bool Update(UpdateEmployeeInfoViewDto empInfo);
    }
}