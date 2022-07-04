using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class EmployeeInfoViewDto
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
        /// 員工中文姓名
        /// </summary>
        public string EmployeeNameC { get; set; }
        /// <summary>
        /// 員工英文姓名
        /// </summary>
        public string EmployeeNameE { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身分證
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
        /// 編制部門
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 編制部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 簽核部門代碼
        /// </summary>
        public string DeptaCode { get; set; }
        /// <summary>
        /// 編制部門名稱
        /// </summary>
        public string DeptCodeName { get; set; }
        /// <summary>
        /// 簽核部門名稱
        /// </summary>
        public string DeptaCodeName { get; set; }
        /// <summary>
        /// 成本部門
        /// </summary>
        public string Depts { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string JobCode { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 職等代碼
        /// </summary>
        public string JoblCode { get; set; }
        /// <summary>
        /// 職等名稱
        /// </summary>
        public string JoblName { get; set; }
        /// <summary>
        /// 職類代碼
        /// </summary>
        public string Jobs { get; set; }
        /// <summary>
        /// 職類代碼名稱
        /// </summary>
        public string JobsName { get; set; }
        /// <summary>
        /// 職級代碼
        /// </summary>
        public string Jobo { get; set; }
        /// <summary>
        /// 職級代碼名稱
        /// </summary>
        public string JoboName { get; set; }
        /// <summary>
        /// 公司別代碼
        /// </summary>
        public string Comp { get; set; }
        /// <summary>
        /// 公司別代碼名稱
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// 薪別代碼
        /// </summary>
        public string Saltp { get; set; }
        /// <summary>
        /// 薪別代碼名稱
        /// </summary>
        public string SaltpName { get; set; }
        /// <summary>
        /// 在職狀態
        /// </summary>
        public string WorkStatus { get; set; }
        /// <summary>
        /// 年資
        /// </summary>
        public decimal Seniority { get; set; }
        /// <summary>
        /// 在職狀態資訊
        /// </summary>
        public List<WorkStatusInfo> WorkStatusInfo { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 戶籍電話
        /// </summary>
        public string ResidencePhone { get; set; }
        /// <summary>
        /// 通訊電話
        /// </summary>
        public string CommunicationPhone { get; set; }
        /// <summary>
        /// 戶籍地址
        /// </summary>
        public string ResidenceAddress { get; set; }
        /// <summary>
        /// 通訊地址
        /// </summary>
        public string CommunicationAddress { get; set; }
        /// <summary>
        /// 眷屬資料
        /// </summary>
        public List<FamilyInfo> FamilyInfo { get; set; }
        /// <summary>
        /// 聯絡人資料
        /// </summary>
        public List<ContactPersonInfo> ContactPersonInfo { get; set; }
        /// <summary>
        /// 學歷資料
        /// </summary>
        public List<SchoolInfo> SchoolInfo { get; set; }
        /// <summary>
        /// 經歷資料
        /// </summary>
        public List<WorksInfo> WorksInfo { get; set; }
    }

    public class WorksInfo
    {
        public string Nobr { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
    }
    public class WorkStatusInfo
    {
        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string ADate { get; set; }
    }

    public class FamilyInfo
    {
        /// <summary>
        /// 關係
        /// </summary>
        public string Relationship { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出生年
        /// </summary>
        public string Birthday { get; set; }
    }

    public class ContactPersonInfo
    {
        /// <summary>
        /// 聯絡人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 聯絡人關係
        /// </summary>
        public string Relationship { get; set; }
        /// <summary>
        /// 聯絡人電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 聯絡人手機
        /// </summary>
        public string Cellphone { get; set; }
    }

    public class SchoolInfo
    {
        /// <summary>
        /// 最高學歷
        /// </summary>
        public bool isEducationLevelTop { get; set; }
        /// <summary>
        /// 教育程度
        /// </summary>
        public string EducationLevel { get; set; }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime Adate { get; set; }
        /// <summary>
        /// 學校名稱
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 科系
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 入學日
        /// </summary>
        public string EnrollmentDate { get; set; }
        /// <summary>
        /// 畢業日
        /// </summary>
        public string GraduationDate { get; set; }
        /// <summary>
        /// 畢業
        /// </summary>
        public bool Graduation { get; set; }
    }
}
