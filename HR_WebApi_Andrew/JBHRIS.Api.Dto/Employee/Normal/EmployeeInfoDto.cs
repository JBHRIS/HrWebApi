using System;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    /// <summary>
    /// 員工編號、身分證號、性別、生日、地址、電話、居留證號、護照號碼
    /// </summary>
    public class EmployeeInfoDto
    {
        public string EmployeeId { get; set; }
        public string IdNo { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TelphoneNo { get; set; }
        public string ResidentCertificateId { get; set; }
        public string PassportId { get; set; }
    }
}