using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    class ShareGetShareCompanyIdAndNameVdb
    {
    }
    public class ShareGetShareCompanyIdAndNameConditions : DataConditions
    {

       
    }

    public class ShareGetShareCompanyIdAndNameApiRow : StandardDataBaseApiRow
    {
        public string GroupCode { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<ShareGetShareCompanyIdAndNameApiRow> result { get; set; }

    }
    public class ShareGetShareCompanyIdAndNameRow
    {
        public string GroupCode { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
