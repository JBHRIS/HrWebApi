using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Bll.Flow.Vdb
{
    public  class SaveInPostedFileBaseVdb
    {
    }

    public class SaveInPostedFileBaseConditions : DataConditions
    { 
        public string Company { get; set; }
        public string InsertMan { get; set; }
        public HttpPostedFileBase files { get; set; }
    }

    public class SaveInPostedFileBaseApiRow : StandardDataBaseApiRow
    {
        

        public bool Result { get; set; }

    }

    public class SaveInPostedFileBaseRow
    {
        public bool Result { get; set; }

    }
}
