using System.Collections.Generic;

namespace JBHRIS.Api.Dto
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public List<string> DataGroups { get; set; }
    }
}