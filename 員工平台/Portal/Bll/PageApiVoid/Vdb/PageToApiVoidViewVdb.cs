using System.Collections.Generic;

namespace Bll.PageApiVoid.Vdb
{
    public  class PageToApiVoidViewVdb
    {
    }

    public class PageToApiVoidViewConditions : DataConditions
    {

    }

    public class PageToApiVoidViewApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string pageCode { get; set; }
            public string pageName { get; set; }
            public class HaveApiVoid
            { 
                public string code { get; set; }
                public string name { get; set; }
                public string routePath { get; set; }
            }
            public List<HaveApiVoid> haveApiVoid { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class PageToApiVoidViewRow : StandardDataRow
    {
        public string PageCode { get; set; }
        public string PageName { get; set; }
        public List<string> HaveApi { get; set; }
    }
}
