using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Login
{
    public class RefreshTokenDto
    {
        public string RefreshToken1 { get; set; }
        public string Nobr { get; set; }
        public DateTime DueDate { get; set; }
        public int Lock { get; set; }
        public string Valid { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
