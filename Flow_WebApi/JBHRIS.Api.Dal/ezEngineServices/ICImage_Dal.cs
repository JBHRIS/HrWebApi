using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices
{
    public interface ICImage_Dal
    {

        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns>Image</returns>
        public Image FlowImageByID(int idProcess);


        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="x">水平起始位置</param>
        /// <param name="y">垂直起始位置</param>
        /// <param name="iWidth">圖片寬度</param>
        /// <param name="iHeight">圖片高度</param>
        /// <param name="bHeader">是否要表頭</param>
        /// <returns>Image</returns>
        public Image FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true);

        /// <summary>
        /// 將 Image 轉換為 Byte 陣列。
        /// </summary>
        /// <param name="image">Image 。</param>
        /// <param name="imageFormat">指定影像格式。</param> 
        public byte[] ImageToBuffer(Image image, ImageFormat imageFormat);
    }
}
