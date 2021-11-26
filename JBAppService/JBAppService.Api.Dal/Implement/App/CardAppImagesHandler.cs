using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.AppDBContext;
using JBAppService.Api.Dto.Images;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace JBAppService.Api.Dal.Implement.App
{
    public class CardAppImagesHandler : ICardAppImagesHandler
    {

        private AppDBContext _AppDBContext;

        public string ErrorMessage { get; set; }


        public CardAppImagesHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }


        /// <summary>
        /// 上傳照片
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        public bool AsyncUploadImages(ImagesFileDto Dto ,string pathString)
        {
			//2 peers	 9168690 blocks	 3286779 BNBs	 1273852 funded
            bool result = false;
            List<ImagesFileDto> Images = new List<ImagesFileDto>();
            var newFileName = string.Empty;
            //限制檔案格式
            List<string> validExts = new List<string> { ".jpeg", ".png", ".jpg" };

            var fileName = string.Empty;
            string PathDB = string.Empty;
            int Count = 0;
            long size = 0; // Images.Sum(f => f.Length);

            try
            {

                //檢查路徑是否存在
                if (!System.IO.Directory.Exists(string.Format("C:\\{0}",pathString)))
                {
                    System.IO.Directory.CreateDirectory(string.Format("C:\\{0}", pathString));
                }

                if (Dto.Remarks != "")
                {
                    CardAppDetails rd = new CardAppDetails();
                    rd = (from Detail in this._AppDBContext.CardAppDetails
                          where Detail.AutoKey == Dto.GUID
                          select Detail
                         ).FirstOrDefault();

                    rd.Remarks = Dto.Remarks;
                    this._AppDBContext.CardAppDetails.Update(rd);
                    this._AppDBContext.SaveChanges();
                }

                //var files = Microsoft.AspNetCore.Mvc.HttpContext.Request.Form.Files;
                if (Dto.Images != null && Dto.Images.Count > 0)
                {
                    foreach (var formFile in Dto.Images)
                    {
                        if (formFile.Length > 0)
                        {

                            fileName = formFile.FileName;
                            //fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim().ToString();

                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                            //Getting file Extension
                            var FileExtension = Path.GetExtension(fileName);

                            //檢查副檔名
                            if (validExts.Contains(FileExtension))
                            {

                                Count++;
                                size += formFile.Length;

                                // concating  FileName + FileExtension
                                newFileName = myUniqueFileName + FileExtension;


                                


                                // Combines two strings into a path.
                                fileName = Path.Combine(string.Format("C:\\{0}", pathString)) + $@"\{newFileName}";

                                // if you want to store path of folder in database
                                PathDB = string.Format("{0}/{1}", pathString, newFileName);

                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    formFile.CopyTo(fs);
                                    fs.Flush();
                                }
                                var filePath = Path.GetTempFileName();


                                CardAppImages cardAppImages = new CardAppImages();
                                cardAppImages.Path = PathDB;
                                cardAppImages.CardAppDetailsID = Dto.GUID;
                                cardAppImages.UploadDate = DateTime.Now;
                                this._AppDBContext.CardAppImages.Add(cardAppImages);
                                this._AppDBContext.SaveChanges();
                            }
                        }
                    }
                    result = true;
                }
                else
                {
                    ErrorMessage = "未選擇上傳檔案!";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return result;
        }


        /// <summary>
        /// 顯示照片
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public string GetImagePath(string Nobr, string ImageID)
        {            
            string path = (from details in this._AppDBContext.CardAppDetails
                           join image in this._AppDBContext.CardAppImages on details.AutoKey equals image.CardAppDetailsID
                           where details.Nobr == Nobr && image.AutoKey.ToString() == ImageID
                           select image.Path).FirstOrDefault();
            if (path == null)
            {
                path = @"demoImages\404.png";
            }
			//MetaMask  http://academy.binance.com/zt/articles/connecting-metamask-to-binance-smart-chain
            return string.Format(@"C:\{0}", path);
        }
    }
}
