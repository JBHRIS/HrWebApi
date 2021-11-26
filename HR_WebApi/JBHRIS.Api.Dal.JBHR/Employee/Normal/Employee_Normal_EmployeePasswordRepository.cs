using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Employee.View;

namespace JBHRIS.Api.Dal.JBHR.Employee.Normal
{
    public class Employee_Normal_EmployeePasswordRepository : IEmployee_Normal_EmployeePasswordRepository
    {
        private IUnitOfWork _unitOfWork;
        public  Employee_Normal_EmployeePasswordRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CheckResetKeySurviveDto CheckResetKeySurvive(string resetkey)
        {
            var resetkeyRepo = _unitOfWork.Repository<ResetPasswordKey>();
            var resetkeyData = resetkeyRepo.Read(p => p.ResetKey == resetkey && p.DeadLineTime > DateTime.Now);
            CheckResetKeySurviveDto checkResetKeySurviveDto = new CheckResetKeySurviveDto() { isSurvive = false, nobr = null };
            if (resetkeyData != null)
            {
                checkResetKeySurviveDto.isSurvive = true;
                checkResetKeySurviveDto.nobr = resetkeyData.Nobr;
            }
            return checkResetKeySurviveDto;
        }

        public bool ChangePassword(string nobr, string NewPWD)
        {
            var baseRepo = _unitOfWork.Repository<Base>();
            var baseData = baseRepo.Read(p => p.Nobr == nobr);
            if(baseData == null)
            {
                return false;
            }
            else
            {
                baseData.Password = NewPWD;
                baseRepo.SaveChanges();
                return true;
            }
        }
        
        public bool UpdatePassword(string nobr, string OldPWD, string NewPWD)
        {
            var baseRepo = _unitOfWork.Repository<Base>();
            var baseData = baseRepo.Read(p => p.Nobr == nobr && p.Password == OldPWD);
            if (baseData == null || baseData.Password != OldPWD)
            {
                return false;
            }
            else
            {
                baseData.Password = NewPWD;
                baseRepo.SaveChanges();
                return true;
            }
        }

        public bool VerifyIdentity(VerifyIdentityEntry verifyIdentityEntry)
        {
            var baseRepo = _unitOfWork.Repository<Base>();
            var baseData_CheckIdNo = baseRepo.Read(p => p.Idno == verifyIdentityEntry.idNo && p.Email == verifyIdentityEntry.email);
            var baseData_CheckMATNO = baseRepo.Read(p => p.Matno == verifyIdentityEntry.idNo && p.Email == verifyIdentityEntry.email);
            if (baseData_CheckIdNo == null && baseData_CheckMATNO == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ApiResult<string> InsertVerifyResetKey(string nobr)
        {
            var resetPasswordKeyRepo = _unitOfWork.Repository<ResetPasswordKey>();
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                ResetPasswordKey ResetPasswordKey = new ResetPasswordKey()
                {
                    Nobr = nobr,
                    ResetKey = Guid.NewGuid().ToString(),
                    DeadLineTime = DateTime.Now.AddMinutes(20),
                    KeyDate = DateTime.Now,
                    KeyMan = nobr
                };
                resetPasswordKeyRepo.Create(ResetPasswordKey);
                resetPasswordKeyRepo.SaveChanges();
                apiResult.State = true;
                apiResult.Result = ResetPasswordKey.ResetKey;

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

    }
}
