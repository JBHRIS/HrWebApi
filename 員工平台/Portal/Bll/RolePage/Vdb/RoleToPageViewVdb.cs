using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.RolePage.Vdb
{
    public  class RoleToPageViewVdb
    {
    }

    public class RoleToPageViewConditions : DataConditions
    {

    }

    public class RoleToPageViewApiRow : StandardDataBaseApiRow
    {
        public class HavePage
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
            public DateTime keyDate { get; set; }
        }
        public class Result
        {
            public string roleCode { get; set; }
            public string roleName { get; set; }
            public List<HavePage> havePage { get; set; }
        }
        
        public List<Result> result { get; set; }
    }

    public class RoleToPageViewRow : StandardDataRow
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public List<string> HavePage { get; set; }
    }
}
