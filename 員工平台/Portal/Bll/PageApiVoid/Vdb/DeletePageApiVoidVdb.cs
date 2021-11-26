using System.Collections.Generic;

namespace Bll.PageApiVoid.Vdb
{
    public  class DeletePageApiVoidVdb
    {
    }

    public class DeletePageApiVoidConditions : DataConditions
    {
        public string pageCode { get; set; }
        public string apiVoidCode { get; set; }
    }

    public class DeletePageApiVoidApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class DeletePageApiVoidRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
