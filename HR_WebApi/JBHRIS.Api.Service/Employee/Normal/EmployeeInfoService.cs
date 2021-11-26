using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.Normal;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo;
        private IEmployee_Normal_GetPeopleByDept _employee_Normal_GetPeopleByDept;
        private IEmployee_Normal_EmployeeInfoRepository _employee_Normal_EmployeeInfoRepository;
        private IEmployee_Normal_EmployeePasswordRepository _employee_Normal_EmployeePasswordRepository;
        private ISystem_View_SysRelcode _system_View_SysRelcode;

        public EmployeeInfoService(IEmployee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo
            , IEmployee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept
            , IEmployee_Normal_EmployeeInfoRepository employee_Normal_EmployeeInfoRepository
            , IEmployee_Normal_EmployeePasswordRepository employee_Normal_EmployeePasswordRepository
            , ISystem_View_SysRelcode system_View_SysRelcode)
        {
            _employee_Normal_GetEmployeeInfo = employee_Normal_GetEmployeeInfo;
            _employee_Normal_GetPeopleByDept = employee_Normal_GetPeopleByDept;
            _employee_Normal_EmployeeInfoRepository = employee_Normal_EmployeeInfoRepository;
            _employee_Normal_EmployeePasswordRepository = employee_Normal_EmployeePasswordRepository;
            _system_View_SysRelcode = system_View_SysRelcode;
        }

        public List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList)
        {
            return _employee_Normal_GetEmployeeInfo.GetEmployeeInfo(employeeList);
        }


        public List<string> GetPeopleByDept(List<string> employeeList, List<string> DeptList, DateTime CheckDate)
        {
            return _employee_Normal_GetPeopleByDept.GetPeopleByDept(employeeList, DeptList, CheckDate);
        }

        public bool UpdateEmployeeInfo(UpdateEmployeeInfoViewDto empInfo)
        {
            return _employee_Normal_EmployeeInfoRepository.Update(empInfo);
        }


        public List<EmployeeInfoViewDto> GetEmployeeInfoView(List<string> employeeList)
        {
            List<EmployeeInfoDto> employeeInfos = _employee_Normal_GetEmployeeInfo.GetEmployeeInfo(employeeList);
            List<EmployeeWorkDto> employeeWorks = _employee_Normal_GetEmployeeInfo.GetEmployeeWork(employeeList);
            List<EmployeeSchoolDto> employeeSchools = _employee_Normal_GetEmployeeInfo.GetEmployeeSchool(employeeList);
            List<EmployeeFamilyDto> employeeFamilys = _employee_Normal_GetEmployeeInfo.GetEmployeeFamily(employeeList);
            List<WorksInfoDto> employeeWorksInfos = _employee_Normal_GetEmployeeInfo.GetEmployeeWorksInfo(employeeList);
            List<EmployeeInfoViewDto> employeeInfoViews = new List<EmployeeInfoViewDto>();
            employeeInfos.ForEach(b =>
            {
                var WorksInfo = employeeWorksInfos.Where(btts => btts.Nobr == b.EmployeeId).Select(p => new WorksInfo()
                {
                    Nobr = p.Nobr,
                    Company = p.Company,
                    Title = p.Title,
                    Bdate = p.Bdate,
                    Edate = p.Edate,
                    Job = p.Job,
                    Note = p.Note
                }).ToList();
                var WorkStatusInfo = employeeWorks.Where(btts => btts.Nobr == b.EmployeeId).Select(btts => new WorkStatusInfo() { Status = btts.TtscodeName, ADate = btts.Adate.ToString() }).ToList();
                var FamilyInfo = employeeFamilys.Where(fam => fam.Nobr == b.EmployeeId).Select(f => new FamilyInfo() { Name = f.FaName, Birthday = f.FaBirdt.ToString(), Relationship = f.RelCodeName }).ToList();
                var nowBasetts = employeeWorks.Where(btts => btts.Nobr == b.EmployeeId && DateTime.Now > btts.Adate && DateTime.Now < btts.Ddate).FirstOrDefault();
                var SchoolInfo = employeeSchools.Where(sch => sch.Nobr == b.EmployeeId).OrderByDescending(p => p.EduccodeSort).ToList();
                List<SchoolInfo> schoolInfos = new List<SchoolInfo>();
                for (int i = 0; i < SchoolInfo.Count; i++)
                {
                    //依照EDUCODE sort最大的為最高學歷
                    bool isEducationLevelTop = false;
                    if (i == 0) isEducationLevelTop = true;
                    var s = SchoolInfo[i];
                    schoolInfos.Add(new SchoolInfo()
                    {
                        Department = s.Subj,
                        EnrollmentDate = s.DateB,
                        GraduationDate = s.DateE,
                        Adate = s.Adate,
                        EducationLevel = s.EduccodeName,
                        Graduation = s.Ok,
                        SchoolName = s.Schl1,
                        isEducationLevelTop = isEducationLevelTop
                    });
                };

                List<ContactPersonInfo> ContactPersonInfo = new List<ContactPersonInfo>();
                if (!String.IsNullOrWhiteSpace(b.ContMan))
                {
                    ContactPersonInfo.Add(
                        new ContactPersonInfo()
                        {
                            Name = b.ContMan,
                            Cellphone = b.ContGsm,
                            Phone = b.ContTel,
                            Relationship = b.ContRelName
                        });
                }
                if (!String.IsNullOrWhiteSpace(b.ContMan2))
                {
                    ContactPersonInfo.Add(
                        new ContactPersonInfo()
                        {
                            Name = b.ContMan2,
                            Cellphone = b.ContGsm2,
                            Phone = b.ContTel2,
                            Relationship = b.ContRel2Name
                        });
                }

                employeeInfoViews.Add(
                    new EmployeeInfoViewDto()
                    {
                        EmployeeId = b.EmployeeId,
                        EmployeeNameC = b.NameC,
                        EmployeeNameE = b.NameE,
                        Birthday = b.Birthday,
                        Sex = b.SexName,
                        Blood = b.Blood,
                        Marry = b.Marry,
                        IdNo = b.IdNo,
                        Email = b.Email,
                        Cellphone = b.Gsm,
                        CommunicationAddress = b.Address1,
                        CommunicationPhone = b.TelphoneNo1,
                        ResidenceAddress = b.Address2,
                        ResidencePhone = b.TelphoneNo2,
                        Dept = nowBasetts.DeptName,
                        Job = nowBasetts.JobName,
                        Depts = nowBasetts.DeptsName,
                        DeptaCode = nowBasetts.Depta,
                        DeptaCodeName = nowBasetts.DeptaName,
                        DeptCode = nowBasetts.Dept,
                        DeptCodeName = nowBasetts.DeptName,
                        JobCode = nowBasetts.Job,
                        JobName = nowBasetts.JobName,
                        JoblCode = nowBasetts.Jobl,
                        JoblName = nowBasetts.JoblName,
                        WorkStatus = WorkStatusInfo.Count() > 0 ? WorkStatusInfo[0].Status : null,
                        WorkStatusInfo = WorkStatusInfo,
                        FamilyInfo = FamilyInfo,
                        SchoolInfo = schoolInfos,
                        ContactPersonInfo = ContactPersonInfo,
                        Seniority = b.Seniority,
                        Photo = b.Photo,
                        WorksInfo = WorksInfo,
                        Comp = nowBasetts.Comp,
                        CompName = nowBasetts.CompName,
                        Jobs = nowBasetts.Jobs,
                        JobsName = nowBasetts.JobsName,
                        Jobo = nowBasetts.Jobo,
                        JoboName = nowBasetts.JoboName,
                        Saltp = nowBasetts.Saltp,
                        SaltpName = nowBasetts.SaltpName
                    });
            });


            return employeeInfoViews;
        }

        public List<RelcodeDto> GetRelcodeView()
        {
            return _system_View_SysRelcode.GetRelcodeView();
        }

        public List<TtscodeDto> GetTtscode()
        {
            return _employee_Normal_GetEmployeeInfo.GetTtscode();
        }

        public List<CompDto> GetComp()
        {
            return _employee_Normal_GetEmployeeInfo.GetComp();
        }

        public List<OutcdDto> GetOutReason()
        {
            return _employee_Normal_GetEmployeeInfo.GetOutReason();
        }

        public List<TtscdDto> GetTtscd()
        {
            return _employee_Normal_GetEmployeeInfo.GetTtscd();
        }
        public List<EmployeeRuleDto> GetEmployeeRule(EmployeeRuleEntry employeeRuleEntry)
        {
            return _employee_Normal_GetEmployeeInfo.GetEmployeeRule(employeeRuleEntry);
        }
    }
}
