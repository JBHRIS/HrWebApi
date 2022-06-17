using System;

namespace JBHRIS.Api.Dto._System
{
    public class UserValidateDto
    {
        public string UserId { get;  set; }
        public string Password { get;  set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }
}