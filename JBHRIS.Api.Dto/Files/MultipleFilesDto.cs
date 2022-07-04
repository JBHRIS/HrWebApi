using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Files
{
    public class MultipleFilesDto
    {
        public string FileTicket { get; set; }
        public List<ApiResult<SingleFileDto>> Files { get; set; }
    }
}
