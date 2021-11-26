using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto.Images
{
    public class ImagesFileDto
    {
        public int GUID { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Remarks { get; set; }
    }
}
