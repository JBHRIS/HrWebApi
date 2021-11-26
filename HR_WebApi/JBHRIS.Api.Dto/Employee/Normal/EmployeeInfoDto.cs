using System;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class EmployeeInfoDto
    {
        /// <summary>
        /// 個人照片
        /// </summary>
        public byte[] Photo { get; set; }
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文姓名
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份證號
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string Blood { get; set; }
        /// <summary>
        /// 婚姻狀態
        /// </summary>
        public string Marry { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 連絡地址1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// 連絡地址2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// 護照號碼
        /// </summary>
        public string PassportId { get; set; }
        /// <summary>
        /// 居留證號
        /// </summary>
        public string ResidentCertificateId { get; set; }
        /// <summary>
        /// 電話1
        /// </summary>
        public string TelphoneNo1 { get; set; }
        /// <summary>
        /// 電話2
        /// </summary>
        public string TelphoneNo2 { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string Gsm { get; set; }
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
        /// 聯絡人關係名稱1
        /// </summary>
        public string ContRelName { get; set; }
        /// <summary>
        /// 聯絡人姓名2
        /// </summary>
        public string ContMan2{ get; set; }
        /// <summary>
        /// 聯絡人電話2
        /// </summary>
        public string ContTel2{ get; set; }
        /// <summary>
        /// 聯絡人手機2
        /// </summary>
        public string ContGsm2 { get; set; }
        /// <summary>
        /// 聯絡人關係代碼2
        /// </summary>
        public string ContRel2 { get; set; }
        /// <summary>
        /// 聯絡人關係名稱2
        /// </summary>
        public string ContRel2Name { get; set; }
        /// <summary>
        /// 年資
        /// </summary>
        public decimal Seniority { get; set; }
        /// <summary>
        /// 性別名稱
        /// </summary>
        public string SexName { get; set; }
    }
}