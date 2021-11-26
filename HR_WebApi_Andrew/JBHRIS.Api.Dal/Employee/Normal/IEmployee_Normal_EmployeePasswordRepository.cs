namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_EmployeePasswordRepository
    {
        bool Update(string OldPWD, string NewPWD);
    }
}