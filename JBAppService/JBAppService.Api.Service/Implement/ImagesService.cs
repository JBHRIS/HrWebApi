using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto.Images;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class ImagesService : IImagesService
    {

        private ICardAppImagesHandler _ICardAppImagesHandler;

        public ImagesService(ICardAppImagesHandler  cardAppImagesHandler)
        {
            this._ICardAppImagesHandler = cardAppImagesHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool AsyncUploadImages(ImagesFileDto dto, string pathString)
        {
            return this._ICardAppImagesHandler.AsyncUploadImages(dto,  pathString);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public string GetImagePath(string Nobr, string ImageID)
        {
            return this._ICardAppImagesHandler.GetImagePath(Nobr,  ImageID);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public string GetImagesByNobrImageID(string nobr, string ImageID)
        {



            return "";// this._ICardAppImagesHandler
        }
    }
}
