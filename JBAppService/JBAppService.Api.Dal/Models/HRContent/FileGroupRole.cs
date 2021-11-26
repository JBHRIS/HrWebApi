using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FileGroupRole
    {
        public int Id { get; set; }
        public int FileGroupId { get; set; }
        public string Role { get; set; }
    }
}
