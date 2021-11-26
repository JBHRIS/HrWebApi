using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Menu.Vdb
{
  public  class IndexFeaturesVdb
    {
    }

    public class IndexFeaturesConditions : DataConditions
    { 
        public string EmpId { get; set; }
    }
    
    public class IndexFeaturesApiRow : StandardDataBaseApiRow
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
            public string keyMan { get; set; }
            public string keyDate { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class IndexFeaturesRow : StandardDataRow
    {
        public string FileName { get; set; }
    }
}
