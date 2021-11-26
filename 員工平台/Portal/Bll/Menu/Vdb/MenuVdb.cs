using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Menu.Vdb
{
  public  class MenuVdb
    {
    }

    public class MenuConditions : DataConditions
    { 
        public string code { get; set; }
    }
    
    public class MenuApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string code { get; set; }
            public string sPath { get; set; }
            public string sFileName { get; set; }
            public string sFileTitle { get; set; }
            public string sParentKey { get; set; }
            public string sidePath { get; set; }
            public string iconName { get; set; }
            public string tag { get; set; }
            public int iOrder { get; set; }
            public bool openNewWin { get; set; }
            public string keyMan { get; set; }
            public string keyDate { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class MenuRow
    {
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public int RoleKey { get; set; }
        public string ParentCode { get; set; }
        public string PathCode { get; set; }
        public int Order { get; set; }
        public string PathName { get; set; }
        public string Tag { get; set; }
        public bool IsAuth { get; set; }
        public bool OpenNewWin { get; set; }
    }
}
