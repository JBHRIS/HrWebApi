using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Token.View
{
    public class SysClientsDto
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
