using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class PeopleApDateViewDto
    {
        public string EmpId { get; set; }
        /// <summary>
        /// 到職日
        /// </summary>
        public DateTime? IndtDate { get; set; }
        /// <summary>
        /// 試用期滿日
        /// </summary>
        public DateTime? ApDate { get; set; }
    }
}
