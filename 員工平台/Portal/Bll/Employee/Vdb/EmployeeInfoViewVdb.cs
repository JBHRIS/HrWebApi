using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
  public  class EmployeeInfoViewVdb
    {
    }

    public class EmployeeInfoViewConditions : DataConditions
    {
        public List<string> ListEmpId { get; set; }
    }

    //public class EmployeeViewApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}

    public class EmployeeInfoViewApiRow : StandardDataBaseApiRow
    {
        public class WorkStatusInfo
        {
            public string status { get; set; }
            public string aDate { get; set; }
        }

        public class FamilyInfo
        {
            public string relationship { get; set; }
            public string name { get; set; }
            public string birthday { get; set; }
        }

        public class ContactPersonInfo
        {
            public string name { get; set; }
            public string relationship { get; set; }
            public string phone { get; set; }
            public string cellphone { get; set; }
        }

        public class SchoolInfo
        {
            public bool IsEducationLevelTop { get; set; }
            public string educationLevel { get; set; }
            public DateTime adate { get; set; }
            public string schoolName { get; set; }
            public string department { get; set; }
            public string enrollmentDate { get; set; }
            public string graduationDate { get; set; }
            public bool graduation { get; set; }
        }
        public class WorksInfo
        { 
            public string Nobr { get; set; }
            public string Company { get; set; }
            public string Title { get; set; }
            public DateTime BDate { get; set; }
            public DateTime EDate { get; set; }
            public string Job { get; set; }
            public string Note { get; set; }
        }

        public class Result
        {
            public string photo { get; set; }
            public string employeeId { get; set; }
            public string employeeNameC { get; set; }
            public string employeeNameE { get; set; }
            public string sex { get; set; }
            public DateTime birthday { get; set; }
            public string idNo { get; set; }
            public string blood { get; set; }
            public string marry { get; set; }
            public string deptCode { get; set; }
            public string dept { get; set; }
            public string deptaCode { get; set; }
            public string deptaCodeName { get; set; }
            public string depts { get; set; }
            public string jobCode { get; set; }
            public string job { get; set; }
            public string joblCode { get; set; }
            public string joblName { get; set; }
            public string workStatus { get; set; }
            public string seniority { get; set; }
            public List<WorkStatusInfo> workStatusInfo { get; set; }
            public string cellphone { get; set; }
            public string email { get; set; }
            public string residencePhone { get; set; }
            public string communicationPhone { get; set; }
            public string residenceAddress { get; set; }
            public string communicationAddress { get; set; }
            public List<FamilyInfo> familyInfo { get; set; }
            public List<ContactPersonInfo> contactPersonInfo { get; set; }
            public List<SchoolInfo> schoolInfo { get; set; }
            public List<WorksInfo> worksInfo { get; set; }
        }
        public List<Result> result { get; set; }
        

    }
    public class WorkState
    {
        public string JobState { get; set; }
        public string ADate { get; set; }

    }
    public class FamilyInfo
    {
        public string Relationship { get; set; }
        public string FamilyName { get; set; }
        public string FamilyBirthday { get; set; }
    }
    public class ContactInfo
    {
        public string ContactName { get; set; }
        public string ContactRelationship { get; set; }
        public string ContactPhone { get; set; }
        public string ContactTel { get; set; }
    }
    public class EducationInfo
    {
        public bool IsEducationLevelTop { get; set; }
        public string Education { get; set; }
        public DateTime ADate { get; set; }
        public string SchoolName { get; set; }
        public string ObjectName { get; set; }
        public string EnterDate { get; set; }
        public string GraduateDate { get; set; }
        public string IsGraduated { get; set; }
    }
    public class WorksInfo
    {
        public string EmpId { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public DateTime BDate { get; set; }
        public DateTime EDate { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
    }
    public class EmployeeInfoViewRow : StandardDataRow
    {
        public string Image { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEnglishName { get; set; }
        public string EmpSex { get; set; }
        public DateTime EmpBirthday { get; set; }
        public string EmpIdNumber { get; set; }
        public string EmpBlood { get; set; }
        public string EmpMarried { get; set; }
        public string Salary { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptaCode { get; set; }
        public string DeptaName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string JoblCode { get; set; }
        public string JoblName { get; set; }
        public string CostDept { get; set; }
        
        public List<WorkState> WorkStateList { get; set; }
       
        
        public List<FamilyInfo> FamilyInfoList { get; set; }

        public List<ContactInfo> ContactInfoList { get; set; }

        public string Cellphone { get; set; }
        public string EMail { get; set; }
        public string ResidencePhone { get; set; }
        public string CommunicationPhone { get; set; }
        public string ResidenceAddress { get; set; }
        public string CommunicationAddress { get; set; }
        
        public List<EducationInfo> EducationList { get; set; }
        public List<WorksInfo> WorksInfoList { get; set; }
    }
}
