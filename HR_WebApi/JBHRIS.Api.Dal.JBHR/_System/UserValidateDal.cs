using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto._System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class UserValidateDal : IUserValidateDal
    {
        private IUnitOfWork _unitOfWork;

        public UserValidateDal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserValidateDto GetUserAdValidate(string AdName)
        {
            var emp = _unitOfWork.Repository<Base>().Read(p => p.NameAd == AdName);
            if (emp != null)
                return new UserValidateDto { Password = emp.Password, UserId = emp.Nobr };
            return null;
        }

        public UserValidateDto GetUserValidate(string userId)
        {
            var emp = _unitOfWork.Repository<Base>().Read(p => p.Nobr == userId);
            if (emp != null)
                return new UserValidateDto { Password = emp.Password, UserId = emp.Nobr };
            return null;
        }
    }
}
