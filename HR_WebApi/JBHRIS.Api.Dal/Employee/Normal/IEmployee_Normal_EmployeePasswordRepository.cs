using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.View;

namespace JBHRIS.Api.Dal.Employee.Normal
{
    public interface IEmployee_Normal_EmployeePasswordRepository
    {
        public bool UpdatePassword(string nobr,string OldPWD, string NewPWD);
        public bool ChangePassword(string nobr, string NewPWD);
        public bool VerifyIdentity(VerifyIdentityEntry verifyIdentityEntry);
        public ApiResult<string> InsertVerifyResetKey(string nobr);
        public CheckResetKeySurviveDto CheckResetKeySurvive(string resetkey);
    }
}