﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Bll.Files.Vdb
{
    public  class UploadMultipleInPostedFileBaseVdb
    {
    }

    public class UploadMultipleInPostedFileBaseConditions : DataConditions
    { 
        public string FileTicket { get; set; }
        public HttpPostedFileBase files { get; set; }
    }
    
    //public class UploadMultipleInPostedFileBaseApiRow : StandardDataBaseApiRow
    //{
    //    public class Result
    //    {
    //        public string fileGuid { get; set; }
    //        public string fileName { get; set; }
    //        public string contentType { get; set; }
    //        public string fileSize { get; set; }
    //        public string fileTicket { get; set; }
    //        public List<UploadSingleFileApiRow> files { get; set; }
    //    }
       
    //    public Result result { get; set; }
        
    //}

    //public class UploadMultipleInPostedFileBaseRow
    //{
    //    public string FileType { get; set; }
    //    public string FileName { get; set; }
    //    public string FileTicket { get; set; }
    //    public int FileSize { get; set; }
    //    public string FileId { get; set; }
    //    public string CompanyId { get; set; }
    //    public string AccessToken { get; set; }
    //}
}
