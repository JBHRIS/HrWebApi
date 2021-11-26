using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using JBAppService.Api.Dto.Images;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Net.Http.Headers;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class CardAppImagesHandler : ICardAppImagesHandler
    {
        private JBEEPContext _context;

        public string ErrorMessage { get; set; }

        public CardAppImagesHandler(JBEEPContext context)
        {
            this._context = context;
        }

        public bool AsyncUploadImages(ImagesFileDto Dto, string pathString)
        {
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

                if (Dto.Remarks != "")
                {
                    CardAppDetails rd = new CardAppDetails();
                    rd = (from Detail in _context.CardAppDetails
                          where Detail.AutoKey == Dto.GUID
                          select Detail
                         ).FirstOrDefault();

                    rd.Remarks = Dto.Remarks;
                    _context.CardAppDetails.Update(rd);
                    _context.SaveChanges();
                }
                //var files = Microsoft.AspNetCore.Mvc.HttpContext.Request.Form.Files;
                if (Dto.Images != null && Dto.Images.Count > 0)
                {
                    foreach (var formFile in Dto.Images)
                    {
                        if (formFile.Length > 0)
                        {

                            fileName = formFile.FileName;
                            //string ext = Path.GetExtension(fileName);
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
                                fileName = Path.Combine(@"C:\demoImages") + $@"\{newFileName}";

                                // if you want to store path of folder in database
                                PathDB = "demoImages/" + newFileName;

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
                                _context.CardAppImages.Add(cardAppImages);
                                _context.SaveChanges();
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
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public string GetImagePath(string Nobr, string ImageID)
        {

            string NobrID = (from b in _context.HRM_BASE_BASE
                             where b.EMPLOYEE_CODE == Nobr
                             select b.EMPLOYEE_ID).FirstOrDefault();

            string path = (from details in _context.CardAppDetails
                           join image in _context.CardAppImages on details.AutoKey equals image.CardAppDetailsID
                           where details.Nobr == NobrID && image.AutoKey.ToString() == ImageID
                           select image.Path).FirstOrDefault();

            if (path == null)
            {
                path = @"demoImages\404.png";
            }

            return string.Format(@"C:\{0}", path);
        }
    }
}
