using JBAppService.Api.Dto.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface ICardAppImagesHandler
    {

        

        string GetImagePath(string Nobr, string ImageID);

        bool AsyncUploadImages(ImagesFileDto Dto, string pathString);

    }
}
