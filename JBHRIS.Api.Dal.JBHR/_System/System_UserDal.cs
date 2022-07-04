using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto._System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class System_UserDal : ISystem_UserDal
    {
        private IUnitOfWork _unitOfWork;

        public System_UserDal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public HrUserDto GetUserByBindingID(string userId)
        {
            return _unitOfWork.Repository<UUser>().Reads()
                .Where(p => p.UserId == userId).Select(p =>
                new HrUserDto
                {
                    UserId = p.UserId,
                    Admin = p.Admin
                }).FirstOrDefault();
        }
    }
}
