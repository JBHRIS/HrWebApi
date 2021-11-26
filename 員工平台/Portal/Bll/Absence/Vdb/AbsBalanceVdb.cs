using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
    public class AbsBalanceVdb
    {
    }
    public class AbsBalanceConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public List<string> hcodeList { get; set; }
        public DateTime effectDate { get; set; }
    }

    public class AbsBalanceApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string employeeId { get; set; }
            public DateTime bdate { get; set; }
            public DateTime edate { get; set; }
            public string btime { get; set; }
            public string etime { get; set; }
            public string hcode { get; set; }
            public Decimal tolhours { get; set; }
            public Decimal balance { get; set; }
            public Decimal leaveHours { get; set; }
            public string yymm { get; set; }
        }
        public List<Result> result { get; set; }

    }
    public class AbsBalanceRow : StandardDataRow
    {
        public string EmployeeId { get; set; }
        public DateTime Edate { get; set; }
        public string Hcode { get; set; }
        public Decimal Tolhours { get; set; }
        public Decimal Balance { get; set; }
        public Decimal LeaveHours { get; set; }
    }
}
