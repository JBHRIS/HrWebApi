using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class FileGroupRole
    {
        public int Id { get; set; }
        public int FileGroupId { get; set; }
        public string Role { get; set; }
    }
}
