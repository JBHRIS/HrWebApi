using JBHRIS.Api.Dto._System;

namespace JBHRIS.Api.Dal._System
{
    public interface ISystem_UserDal
    {
        HrUserDto GetUserByBindingID(string userId);
    }
}