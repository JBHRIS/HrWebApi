using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Absence.Vdb
{
    public class CheckAbsenceDataDetailVdb
    {
    }
    public class CheckAbsenceDataDetailConditions : DataConditions
    {
        public List<AbsenceDataDto> root { get; set; }
    }

    public class CheckAbsenceDataDetailApiRow : StandardDataBaseApiRow
    {
        public List<string> result { get; set; }

    }
    public class CheckAbsenceDataDetailRow : StandardDataRow
    {
        public string result { get; set; }
    }
}
