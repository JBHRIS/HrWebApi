using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class UpdateEmployeeInfoViewDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string Gsm { get; set; }
        /// <summary>
        /// 戶籍電話
        /// </summary>
        public string ResidencePhone { get; set; }
        /// <summary>
        /// 通訊電話
        /// </summary>
        public string CommunicationPhone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 戶籍地址
        /// </summary>
        public string ResidenceAddress { get; set; }
        /// <summary>
        /// 通訊地址
        /// </summary>
        public string CommunicationAddress { get; set; }
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        public string ContMan { get; set; }
        /// <summary>
        /// 聯絡人電話1
        /// </summary>
        public string ContTel { get; set; }
        /// <summary>
        /// 聯絡人手機1
        /// </summary>
        public string ContGsm { get; set; }
        /// <summary>
        /// 聯絡人關係代碼1
        /// </summary>
        public string ContRel { get; set; }
        /// <summary>
        /// 聯絡人姓名2
        /// </summary>
        public string ContMan2 { get; set; }
        /// <summary>
        /// 聯絡人電話2
        /// </summary>
        public string ContTel2 { get; set; }
        /// <summary>
        /// 聯絡人手機2
        /// </summary>
        public string ContGsm2 { get; set; }
        /// <summary>
        /// 聯絡人關係代碼2
        /// </summary>
        public string ContRel2 { get; set; }
    }
}
