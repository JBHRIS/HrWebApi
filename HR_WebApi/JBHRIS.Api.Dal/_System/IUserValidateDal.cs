using JBHRIS.Api.Dto._System;

namespace JBHRIS.Api.Dal._System
{
    public interface IUserValidateDal
    {
        UserValidateDto GetUserValidate(string userId);
        UserValidateDto GetUserAdValidate(string AdName);
    }
}