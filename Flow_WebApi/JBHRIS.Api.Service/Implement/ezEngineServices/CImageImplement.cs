using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace JBHRIS.Api.Service.Implement.ezEngineServices
{
    public class CImageImplement : ICImageInterface
    {
        private ICImage_Dal _ICImage_Dal;
        public CImageImplement(ICImage_Dal cImage_Dal)
        {
            this._ICImage_Dal = cImage_Dal;
        }


        public Image FlowImageByID(int idProcess)
        {
            return this._ICImage_Dal.FlowImageByID(idProcess);
        }

        public Image FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true)
        {
            return this._ICImage_Dal.FlowImage(idProcess,x,y,iWidth,iHeight,bHeader);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public byte[] ImageToBuffer(Image image, ImageFormat imageFormat)
        {
            return this._ICImage_Dal.ImageToBuffer(image, imageFormat);
        }

    }
}
