using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Token.View
{
    public class sysMoudlesDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
