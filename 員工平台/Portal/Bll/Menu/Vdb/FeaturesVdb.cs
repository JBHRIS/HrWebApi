using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Menu.Vdb
{
  public  class FeaturesVdb
    {
    }

    public class FeaturesConditions : DataConditions
    { 
        public string code { get; set; }
        public string keyword { get; set; }
    }
    
    public class FeaturesApiRow : StandardDataBaseApiRow
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

    public class FeaturesRow : StandardDataRow
    {
        public string SearchTitle { get; set; }
        public string Page { get; set; }
        public string Content { get; set; }
        public string ParentKey { get; set; }
    }
}
