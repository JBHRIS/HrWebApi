using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
    public class AbsenceDataDetailVdb
    {
    }
    public class AbsenceDataDetailConditions : DataConditions
    {
        public string nobr { get; set; }
        public string hcode { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }

    }

    public class AbsenceDataDetailApiRow : StandardDataBaseApiRow
    {
        public List<AbsenceDataDto> result { get; set; }

    }
    public class AbsenceDataDetailRow : StandardDataRow
    {
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        public DateTime DateB { get; set; }
        public string TimeB { get; set; }
        public DateTime DateE { get; set; }
        public string TimeE { get; set; }
        public string HolidayName { get; set; }
        public string AgentEmpName { get; set; }
        public string Hcode { get; set; }
        public Decimal Use { get; set; }
        public string UnitCode { get; set; }
        public string AgentNote { get; set; }
    }
}
