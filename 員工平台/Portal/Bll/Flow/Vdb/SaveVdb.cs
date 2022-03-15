using System.Web;

namespace Bll.Flow.Vdb
{
    public  class SaveVdb
    {
    }

    public class SaveConditions : DataConditions
    {
        public string Company { get; set; }
        public string InsertMan { get; set; }
        public HttpFileCollection files { get; set; }
    }
    
    public class SaveApiRow : StandardDataBaseApiRow
    {
        public bool Result { get; set; }

    }

    public class SaveRow
    {
        public bool Result { get; set; }
    }
}
