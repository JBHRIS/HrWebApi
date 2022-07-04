using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Service.Mail.View;
using System.Security.Claims;

namespace JBHRIS.Api.Service.Employee.View
{
    public class UserPasswordService : IUserPasswordService
    {
        IEmployee_Normal_EmployeePasswordRepository _employeePasswordRepository;
        IMailService _mailService;
        public UserPasswordService(IEmployee_Normal_EmployeePasswordRepository employeePasswordRepository,
            IMailService mailService)
        {
            _employeePasswordRepository = employeePasswordRepository;
            _mailService = mailService;
        }

        public bool ChangePassword(ChangePasswordEntry changePasswordEntry)
        {
            CheckResetKeySurviveDto checkResetKeySurviveDto = _employeePasswordRepository.CheckResetKeySurvive(changePasswordEntry.resetkey);
            if (checkResetKeySurviveDto.isSurvive)
            {
                return _employeePasswordRepository.ChangePassword(checkResetKeySurviveDto.nobr, changePasswordEntry.newPw);
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePassword(string Nobr,UpdatePasswordEntry updatePasswordEntry)
        {
            return _employeePasswordRepository.UpdatePassword(Nobr, updatePasswordEntry.oldPw,updatePasswordEntry.newPw);
        }

        public ApiResult<string> VerifyIdentity(VerifyIdentityEntry verifyIdentityEntry)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            bool veriftyIdendtity = _employeePasswordRepository.VerifyIdentity(verifyIdentityEntry);
            if (veriftyIdendtity)
            {
                var InsertVerifyResetKey = _employeePasswordRepository.InsertVerifyResetKey(verifyIdentityEntry.nobr);
                if (InsertVerifyResetKey.State)
                {
                    string redirectQueryString = verifyIdentityEntry.redirectQueryString == null ? "": verifyIdentityEntry.redirectQueryString.Trim();
                    var body = "Portal登入網址修改密碼：<BR>" + verifyIdentityEntry.redirectUrl + "?key=" + InsertVerifyResetKey.Result+redirectQueryString+ "<BR>此信件為系統自動寄送，請勿直接回信，若有疑問請洽HR，謝謝您";
                    var subject = $"【通知】({verifyIdentityEntry.nobr}) 忘記密碼通知信";
                    apiResult = _mailService.SendMailWithQueue(verifyIdentityEntry.email, subject, body);
                }
            }
            else
            {
                apiResult.State = false;
                apiResult.Message = "身分驗證失敗";
            }

            return apiResult;
        }
    }
}
