using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace ezEngineServices.Vdb
{
    public class UploadFileVdb
    {
    }

    public class UploadFileRow
    {
        public int AutoKey { get; set; }
        public string FormCode { get; set; }
        public string FormName { get; set; }
        public string ProcessID { get; set; }
        public int idProcess { get; set; }
        public string Nobr { get; set; }
        public string Key { get; set; }
        public string Key2 { get; set; }
        public string UpName { get; set; }
        public string ServerName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public DateTime KeyDate { get; set; }
        public Binary Blob { get; set; }
    }
}