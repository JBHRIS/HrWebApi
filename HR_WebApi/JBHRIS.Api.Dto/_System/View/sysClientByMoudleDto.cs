using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Token.View
{
    public class sysClientByMoudleDto
    {
        public string ClientId { get; set; }
        public string MoudleId { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpadateDate { get; set; }
        public string Note { get; set; }
    }
}
