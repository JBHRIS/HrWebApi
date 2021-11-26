using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Salary.Vdb
{
  public  class PayslipTitleVdb
    {
    }

    public class PayslipTitleConditions : DataConditions
    { 
        public string yymm { get; set; }
        public string seq { get; set; }
        public string password { get; set; }
    }
    
    public class PayslipTitleApiRow : StandardDataBaseApiRow
    {
        public class Result 
        {
            public DateTime adate { get; set; }
            public DateTime dateB { get; set; }
            public DateTime dateE { get; set; }
            public DateTime salDateB { get; set; }
            public DateTime salDateE { get; set; }
            public DateTime attDateB { get; set; }
            public DateTime attDateE { get; set; }
            public string note { get; set; }
        }
        public Result result { get; set; }
    }

    public class PayslipTitleRow
    {
        /// <summary>
        /// 發薪日期
        /// </summary>
        public DateTime ADate { get; set; }
        public DateTime SalDateB { get; set; }
        public DateTime SalDateE { get; set; }
        /// <summary>
        /// 出勤區間
        /// </summary>
        public DateTime AttDateB { get; set; }
        public DateTime AttDateE { get; set; }
        public string Note { get; set; }
    }
}
