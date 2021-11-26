using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Menu.Vdb
{
  public  class InsertMenuVdb
    {
    }

    public class InsertMenuConditions : DataConditions
    {
        public string sPath { get; set; }
        public string sFileName { get; set; }
        public string sFileTitle { get; set; }
        public string sParentKey { get; set; }
        public string sidePath { get; set; }
        public string iconPath { get; set; }
        public string iconName { get; set; }
        public string tag { get; set; }
        public int iOrder { get; set; }
        public string keyMan { get; set; }
        public DateTime keyDate { get; set; }
        public string noticeContent { get; set; }
        public string noticeTtile { get; set; }
        public bool displayNotice { get; set; }
        public bool openNewWin { get; set; }
    }
    
    public class InsertMenuApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class InsertMenuRow : StandardDataRow
    {
        public bool Result { get; set; }
        
    }
}
