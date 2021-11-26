using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
    public class AbsenceDataSaveVdb
    {
    }
    public class AbsenceDataDto
    {
        public class CalAbsHoursDetail
        {
            public string Nobr { get; set; }
            public DateTime ADate { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            public string HCode { get; set; }
            public string HType { get; set; }
            public Decimal Total { get; set; }
            public bool Che { get; set; }
            public Decimal AbsUnit { get; set; }
            public Decimal Minnum { get; set; }
            public Decimal WorkHours { get; set; }
            public string Unit { get; set; }
        }
        public DateTime AtteendDate { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string Nobr { get; set; }
        public Decimal TotHours { get; set; }
        public Decimal RealTotHours { get; set; }
        public string Unit { get; set; }
        public Decimal WorkHours { get; set; }
        public string HCode { get; set; }
        public string HType { get; set; }
        public string Serno { get; set; }
        public bool Syscreate { get; set; }
        public string AName { get; set; }
        public List<CalAbsHoursDetail> CalAbsHoursDetails { get; set; }

    }
    public class AbsenceDataSaveConditions : DataConditions
    {
        public List<AbsenceDataDto> root { get; set; }
    }

    public class AbsenceDataSaveApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }

    }
    public class AbsenceDataSaveRow : StandardDataRow
    {
        public string result { get; set; }
    }
}
