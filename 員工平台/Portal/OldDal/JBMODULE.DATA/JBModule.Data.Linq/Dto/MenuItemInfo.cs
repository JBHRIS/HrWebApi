using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class MenuItemInfo
    {
        public Guid MenuGroupID { set; get; }
        public Guid MenuStripID { set; get; }
        public Guid ParentID { set; get; }
        public int Index { set; get; }
        public string AssemblyName { set; get; }
        public bool Enable { set; get; }
        public bool CommonItem { set; get; }
    }
}
