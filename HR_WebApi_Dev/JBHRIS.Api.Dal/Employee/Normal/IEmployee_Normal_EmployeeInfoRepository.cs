using JBHRIS.Api.Dto.Employee.Normal;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_EmployeeInfoRepository
    {
        bool Update(EmployeeInfoDto empInfo);
    }
}