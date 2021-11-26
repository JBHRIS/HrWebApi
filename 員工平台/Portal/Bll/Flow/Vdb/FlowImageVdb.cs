using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    public class FlowImageVdb
    {
    }
    public class FlowImageConditions : DataConditions
    {
        public int idProcess { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int iWidth { get; set; }
        public int iHeight { get; set; }
        public bool bHeader { get; set; }
    }
    public class FlowImageApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }
    public class FlowImageRow
    {
        public string result { get; set; }
    }
   
}
