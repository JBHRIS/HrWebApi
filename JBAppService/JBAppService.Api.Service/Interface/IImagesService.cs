using JBAppService.Api.Dto.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IImagesService 
    {

        string GetImagesByNobrImageID(string nobr ,string ImageID);



        bool AsyncUploadImages(ImagesFileDto dto, string pathString);


        string  GetImagePath( string Nobr, string ImageID);
    }
}
