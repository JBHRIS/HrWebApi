using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Token.View
{
    public class sysMoudleByApiVoidDto
    {
        public string MoudleId { get; set; }
        public string ApiId { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
