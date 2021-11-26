using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using JBAppService.Api.Dto;

using System.IO;
using System.Net.Http.Headers;
using JBAppService.Api.Dto.Images;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class CardAppImagesHandler : ICardAppImagesHandler
    {

		/*切開db之後沒再用*/
        private JBHRContext _context;


        public string ErrorMessage { get; set; }

        public CardAppImagesHandler( JBHRContext context)
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
                //檢查路徑是否存在
                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.File.Create(pathString);
                }


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
                                cardAppImages.CardAppDetailsId = Dto.GUID;
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




        public List<string> GetCardAppImages_by_CardAppDetailsID(string path , int CardAppDetailsID)
        {
            var result = (from img in _context.CardAppImages
                          where img.CardAppDetailsId == CardAppDetailsID
                          select img).OrderByDescending(m => m.AutoKey).ToList();

            return new List<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public string GetImagePath(string Nobr, string ImageID)
        {
            string path = (from details in _context.CardAppDetails
                           join image in _context.CardAppImages on details.AutoKey equals image.CardAppDetailsId
                           where details.Nobr == Nobr && image.AutoKey.ToString() == ImageID
                           select image.Path).FirstOrDefault();
            if (path == null)
            {
                path = @"demoImages\404.png";
            }

            return string.Format(@"C:\{0}", path);
        }







        //public bool AsyncUploadImages(FileImagesDto FileImagesDto)
        //{

        //    List<IFormFile> Images = new List<IFormFile>();
        //    var newFileName = string.Empty;
        //    //限制檔案格式
        //    List<string> validExts = new List<string> { ".jpeg", ".png", ".jpg" };

        //    //StandardFoodsHRContext dcHr = new StandardFoodsHRContext();
        //    string message = "";
        //    int Count = 0;
        //    long size = 0; // Images.Sum(f => f.Length);

        //    var fileName = string.Empty;
        //    string PathDB = string.Empty;


        //    try
        //    {

        //        if (FileImagesDto.Remarks != "")
        //        {
        //            CardAppDetails rd = new CardAppDetails();
        //            rd = (from Detail in _context.CardAppDetails
        //                  where Detail.AutoKey == FileImagesDto.GUID
        //                  select Detail
        //                 ).FirstOrDefault();

        //            rd.Remarks = FileImagesDto.Remarks;
        //            _context.CardAppDetails.Update(rd);
        //            _context.SaveChanges();
        //            //_context.CardAppImagess(rd).State = System.Data.Entity.EntityState.Modified;
        //            //_context.SaveChanges();

        //        }


        //        //var files = HttpContext.Request.Form.Files;

        //        if (FileImagesDto.Images != null && FileImagesDto.Images.Count > 0)
        //        {
        //            foreach (var formFile in FileImagesDto.Images)
        //            {
        //                if (formFile.Length > 0)
        //                {


        //                    fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim().ToString();

        //                    //Assigning Unique Filename (Guid)
        //                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

        //                    //Getting file Extension
        //                    var FileExtension = Path.GetExtension(fileName);

        //                    //檢查副檔名
        //                    if (validExts.Contains(FileExtension))
        //                    {

        //                        Count++;
        //                        size += formFile.Length;

        //                        // concating  FileName + FileExtension
        //                        newFileName = myUniqueFileName + FileExtension;

        //                        // Combines two strings into a path.
        //                        fileName = Path.Combine(@"C:\demoImages") + $@"\{newFileName}";

        //                        // if you want to store path of folder in database
        //                        PathDB = "demoImages/" + newFileName;

        //                        using (FileStream fs = System.IO.File.Create(fileName))
        //                        {
        //                            formFile.CopyTo(fs);
        //                            fs.Flush();
        //                        }
        //                        var filePath = Path.GetTempFileName();


        //                        CardAppImages cardAppImages = new CardAppImages();
        //                        cardAppImages.Path = PathDB;
        //                        cardAppImages.CardAppDetailsId = FileImagesDto.GUID;
        //                        cardAppImages.UploadDate = DateTime.Now;
        //                        _context.CardAppImages.Add(cardAppImages);
        //                        _context.SaveChanges();





        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            message = "未選擇上傳檔案!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;


        //    }


        //}

		//Dapp https://steemit.com/

    }
}
