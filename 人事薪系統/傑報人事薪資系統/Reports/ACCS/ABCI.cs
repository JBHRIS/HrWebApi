using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHR.Reports.AttForm.ACCS;

namespace JBHR.Reports.AttForm.ACCS
{
    public interface ABCI
    {
        Dictionary<string, List<rq_OTDto>> FilterByMaxHrs(List<rq_OTDto> allrq_OTDtoList, decimal MaxHrs);

        Dictionary<string, List<rq_OTDto>> FilterByMaxHrs(List<rq_OTDto> allrq_OTDtoList);

        List<rq_OTDto> Filterzz2zDataTableByMonthOT(List<rq_OTDto> ACC, int MINHRS, int MAXHRS);

        List<rq_OTDto> Filterzz2zDataTableByMonthOT(List<rq_OTDto> ACC);
    }
}
