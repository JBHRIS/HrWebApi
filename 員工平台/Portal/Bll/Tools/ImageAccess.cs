using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageAccess
    {
        #region 取得網路上的圖片
        /// <summary>
        /// 取得網路上的圖片
        /// </summary>
        /// <param name="strUrl">圖片的Url路徑</param>
        /// <returns>回傳 System.Drawing.Image物件</returns>
        public Image getImageFromURL(string strUrl)
        {
            Image MyImage = null;

            try
            {
                //建立一個 Web Request
                WebRequest MyWebRequest = WebRequest.Create(strUrl);
                //由 Web Request 取得 Web Response
                WebResponse MyWebResponse = MyWebRequest.GetResponse();
                //由 Web Response 取得 Stream
                Stream MyStream = MyWebResponse.GetResponseStream();
                //由 Stream 取得 Image
                MyImage = Image.FromStream(MyStream);

                //該關的關一關, 該放的放一放
                MyStream.Close();
                MyStream.Dispose();
                MyWebResponse.Close();
                MyWebResponse = null;
                MyWebRequest = null;
            }
            catch (Exception ex)
            {
                throw new Exception("getImageFromURL(string strUrl)發生例外，可能抓不到網路上的圖片" + strUrl + "｜錯誤訊息：" + ex.ToString());
            }

            //回傳 Image
            return MyImage;
        }
        #endregion

        #region [ASP.net程式使用]圖片等比例縮圖後的寬和高像素
        /// <summary>
        /// [ASP.net程式使用]取得圖片等比例縮圖後的寬和高像素
        /// </summary>
        /// <param name="image">System.Drawing.Image 的物件</param>
        /// <param name="maxPx">寬或高超過多少像素就要縮圖</param>
        /// <returns>回傳int陣列，索引0為縮圖後的寬度、索引1為縮圖後的高度</returns>
        public int[] getThumbPic_WidthAndHeight(Image image, int maxPx)
        {
            int fixWidth = 0;
            int fixHeight = 0;

            if (image.Width > maxPx || image.Height > maxPx)
            //如果圖片的寬大於最大值或高大於最大值就往下執行  
            {
                if (image.Width >= image.Height)
                //圖片的寬大於圖片的高  
                {
                    fixHeight = Convert.ToInt32((Convert.ToDouble(maxPx) / Convert.ToDouble(image.Width)) * Convert.ToDouble(image.Height));
                    //設定修改後的圖高  
                    fixWidth = maxPx;
                }
                else
                {
                    fixWidth = Convert.ToInt32((Convert.ToDouble(maxPx) / Convert.ToDouble(image.Height)) * Convert.ToDouble(image.Width));
                    //設定修改後的圖寬  
                    fixHeight = maxPx;
                }
            }
            else
            {//圖片沒有超過設定值，不執行縮圖  
                fixHeight = image.Height;
                fixWidth = image.Width;
            }

            int[] fixWidthAndfixHeight = { fixWidth, fixHeight };

            return fixWidthAndfixHeight;
        }
        #endregion

        #region 產生縮圖並儲存
        /// <summary>
        /// 產生縮圖並儲存
        /// </summary>
        /// <param name="srcImageUrl">來源圖片的Url</param>
        /// <param name="maxPix">超過多少像素就要等比例縮圖</param>
        /// <param name="saveThumbFilePath">縮圖的儲存檔案路徑</param>
        public void saveThumbPic(string srcImageUrl, int maxPix, string saveThumbFilePath)
        {
            //為了callBack而callBack的寫法
            Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            //取得原始圖片
            Image image = this.getImageFromURL(srcImageUrl);
            // 計算維持比例的縮圖大小
            int[] thumbnailScale = this.getThumbPic_WidthAndHeight(image, maxPix);
            // 產生縮圖
            Image smallImage = image.GetThumbnailImage(thumbnailScale[0], thumbnailScale[1], callBack, IntPtr.Zero);
            // 將縮圖存檔
            smallImage.Save(saveThumbFilePath);
            // 釋放
            image.Dispose();
        }

        /// <summary>
        /// 產生縮圖
        /// </summary>
        /// <param name="srcImageUrl">來源圖片的Url</param>
        /// <param name="maxPix">超過多少像素就要等比例縮圖</param>
        public Image GetThumbPic(string srcImageUrl, int maxPix)
        {
            //為了callBack而callBack的寫法
            Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            //取得原始圖片
            Image image = this.getImageFromURL(srcImageUrl);
            // 計算維持比例的縮圖大小
            int[] thumbnailScale = this.getThumbPic_WidthAndHeight(image, maxPix);
            // 產生縮圖
            image = image.GetThumbnailImage(thumbnailScale[0], thumbnailScale[1], callBack, IntPtr.Zero);

            return image;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
        #endregion

        /// <summary>
        /// 將圖片Image轉換成Byte[]
        /// </summary>
        /// <param name="Image">image物件</param>
        /// <param name="imageFormat">字尾名</param>
        /// <returns>byte[]</returns>
        public static byte[] ImageToBytes(Image Image, ImageFormat imageFormat)
        {
            if (Image == null) { return null; }
            byte[] data = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap Bitmap = new Bitmap(Image))
                {
                    Bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    data = new byte[ms.Length];
                    ms.Read(data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }

            return data;
        }

        /// <summary>
        /// 將 Image 轉換為 Byte 陣列。
        /// </summary>
        /// <param name="Image">Image 。</param>
        /// <param name="imageFormat">指定影像格式。</param>        
        public static byte[] ImageToBuffer(Image Image, ImageFormat imageFormat)
        {
            if (Image == null) { return null; }
            byte[] data = null;
            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                //建立副本
                using (Bitmap oBitmap = new Bitmap(Image))
                {
                    //儲存圖片到 MemoryStream 物件，並且指定儲存影像之格式
                    oBitmap.Save(oMemoryStream, imageFormat);
                    //設定資料流位置
                    oMemoryStream.Position = 0;
                    //設定 buffer 長度
                    data = new byte[oMemoryStream.Length];
                    //將資料寫入 buffer
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                    //將所有緩衝區的資料寫入資料流
                    oMemoryStream.Flush();
                }
            }
            return data;
        }

        /// <summary>
        /// byte[]轉換成Image
        /// </summary>
        /// <param name="byteArrayIn">二進位制圖片流</param>
        /// <returns>Image</returns>
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                ms.Flush();
                return returnImage;
            }
        }

        /// <summary>
        /// 將 Byte 陣列轉換為 Image。
        /// </summary>
        /// <param name="Buffer">Byte 陣列。</param>        
        public static Image BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            //return oImage;
            return oBitmap;
        }
    }
}