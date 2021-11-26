using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace JBHRIS.BLL.Service
{
    public interface IReportService
    {
        DataTable GetReportData(JBHRIS.BLL.Dto.ReportCondition condition);
        //string CustomizeSettings { get; set; }

    }
}
