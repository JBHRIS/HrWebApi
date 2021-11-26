using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.Web;

namespace Bll.Files.Vdb
{
    public  class ExcelSheetNameCoverVdb
    {
    }

    public class ExcelSheetNameCoverConditions : DataConditions
    { 
        public HttpPostedFileBase file { get; set; }
    }
    
    public class ExcelSheetNameCoverApiRow : StandardDataBaseApiRow
    {

        public List<string> Result { get; set; }
    }

    public class ExcelSheetNameCoverRow
    {
        public List<string> Result { get; set; }

    }
}
