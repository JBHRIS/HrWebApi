using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class CardAppImageDto
    {

    }


    public class FileImagesDto
    {
        public int GUID { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Remarks { get; set; }
    }

}
