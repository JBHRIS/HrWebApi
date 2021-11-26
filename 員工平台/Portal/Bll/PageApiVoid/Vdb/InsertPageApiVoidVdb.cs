using System.Collections.Generic;

namespace Bll.PageApiVoid.Vdb
{
    public  class InsertPageApiVoidVdb
    {
    }

    public class InsertPageApiVoidConditions : DataConditions
    {
        public string pageCode { get; set; }
        public string apiVoidCode { get; set; }
    }

    public class InsertPageApiVoidApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class InsertPageApiVoidRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
