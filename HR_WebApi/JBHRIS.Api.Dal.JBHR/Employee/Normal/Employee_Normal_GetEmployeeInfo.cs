using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_Normal_GetEmployeeInfo : IEmployee_Normal_GetEmployeeInfo
    {
        private IUnitOfWork _unitOfWork;
        public Employee_Normal_GetEmployeeInfo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<EmployeeFamilyDto> GetEmployeeFamily(List<string> employeeList)
        {
            List<EmployeeFamilyDto> employeeFamilyDtos = new List<EmployeeFamilyDto>();

            foreach (var item in employeeList.Split(2100))
            {
                var data = _unitOfWork.Repository<Family>().Reads()
                           .Where(p => item.Contains(p.Nobr))
                           .GroupJoin(
                               _unitOfWork.Repository<Relcode>().Reads(),
                               f1 => f1.RelCode,
                               r1 => r1.RelCode1,
                               (f1, r1) => new { f1, r1 }
                            )
                           .SelectMany(p => p.r1.DefaultIfEmpty(), (p, r1) => new EmployeeFamilyDto
                           {
                               Nobr = p.f1.Nobr,
                               FaBirdt = p.f1.FaBirdt.Value,
                               FaIdno = p.f1.FaIdno,
                               FaName = p.f1.FaName,
                               RelCode = p.f1.RelCode,
                               RelCodeName = r1.RelName
                           });
                employeeFamilyDtos.AddRange(data);
            }
            return employeeFamilyDtos.ToList();
        }

        public List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList)
        {
            List<EmployeeInfoDto> employeeInfoDtos = new List<EmployeeInfoDto>();

            foreach (var item in employeeList.Split(2100))
            {
                var data = _unitOfWork.Repository<Base>().Reads()
                           .Where(p => item.Contains(p.Nobr))
                           .GroupJoin(
                               _unitOfWork.Repository<Sex>().Reads(),
                               b1 => b1.Sex,
                               s1 => s1.Code,
                               (b1, s1) => new { b1, s1 }
                            )
                           .SelectMany(c => c.s1.DefaultIfEmpty(), (p, s1) => new EmployeeInfoDto
                           {
                               EmployeeId = p.b1.Nobr,
                               NameC = p.b1.NameC,
                               NameE = p.b1.NameE,
                               Sex = p.b1.Sex,
                               SexName = s1.Name,
                               Birthday = p.b1.Birdt.Value,
                               IdNo = p.b1.Idno,
                               Blood = p.b1.Blood,
                               Marry = p.b1.Marry,
                               Email = p.b1.Email,
                               Address1 = p.b1.Addr1,
                               Address2 = p.b1.Addr2,
                               PassportId = "",
                               ResidentCertificateId = p.b1.Matno,
                               TelphoneNo1 = p.b1.Tel1,
                               TelphoneNo2 = p.b1.Tel2,
                               Gsm = p.b1.Gsm,
                               ContMan = p.b1.ContMan,
                               ContTel = p.b1.ContTel,
                               ContGsm = p.b1.ContGsm,
                               ContRel = p.b1.ContRel1,
                               ContRelName = null,
                               ContMan2 = p.b1.ContMan2,
                               ContTel2 = p.b1.ContTel2,
                               ContGsm2 = p.b1.ContGsm2,
                               ContRel2 = p.b1.ContRel2,
                               ContRel2Name = null,
                               Seniority = JBHRContext.GetTotalYears(p.b1.Nobr, DateTime.Now),
                               Photo = p.b1.Photo
                           });

                var data2 = data
                            .GroupJoin(
                               _unitOfWork.Repository<Relcode>().Reads(),
                               b1 => b1.ContRel,
                               r1 => r1.RelCode1,
                               (b1, r1) => new { b1, r1 }
                            )
                            .SelectMany(c => c.r1.DefaultIfEmpty(), (b1, r1) => new { b1 = b1.b1, r1 }).ToList()
                            .GroupJoin(
                               _unitOfWork.Repository<Relcode>().Reads(),
                               b2 => b2.b1.ContRel2,
                               r2 => r2.RelCode1,
                               (b2, r2) => new { b2, r2 }
                            )
                           .SelectMany(c => c.r2.DefaultIfEmpty(), (p, r2) => new EmployeeInfoDto
                           {
                               EmployeeId = p.b2.b1.EmployeeId,
                               NameC = p.b2.b1.NameC,
                               NameE = p.b2.b1.NameE,
                               Sex = p.b2.b1.Sex,
                               SexName = p.b2.b1.SexName,
                               Birthday = p.b2.b1.Birthday,
                               IdNo = p.b2.b1.IdNo,
                               Blood = p.b2.b1.Blood,
                               Marry = p.b2.b1.Marry,
                               Email = p.b2.b1.Email,
                               Address1 = p.b2.b1.Address1,
                               Address2 = p.b2.b1.Address2,
                               PassportId = p.b2.b1.PassportId,
                               ResidentCertificateId = p.b2.b1.ResidentCertificateId,
                               TelphoneNo1 = p.b2.b1.TelphoneNo1,
                               TelphoneNo2 = p.b2.b1.TelphoneNo2,
                               Gsm = p.b2.b1.Gsm,
                               ContMan = p.b2.b1.ContMan,
                               ContTel = p.b2.b1.ContTel,
                               ContGsm = p.b2.b1.ContGsm,
                               ContRel = p.b2.r1?.RelCode1,
                               ContRelName = p.b2.r1?.RelName,
                               ContMan2 = p.b2.b1.ContMan2,
                               ContTel2 = p.b2.b1.ContTel2,
                               ContGsm2 = p.b2.b1.ContGsm2,
                               ContRel2 = r2?.RelCode1,
                               ContRel2Name = r2?.RelName,
                               Seniority = p.b2.b1.Seniority,
                               Photo = p.b2.b1.Photo
                           });

                employeeInfoDtos.AddRange(data2);
            }
            return employeeInfoDtos.ToList();
        }

        public List<EmployeeSchoolDto> GetEmployeeSchool(List<string> employeeList)
        {
            List<EmployeeSchoolDto> employeeSchoolDtos = new List<EmployeeSchoolDto>();

            foreach (var item in employeeList.Split(2100))
            {
                var data = from s in _unitOfWork.Repository<Schl>().Reads()
                           join ed in _unitOfWork.Repository<Educode>().Reads() on s.Educcode equals ed.Code
                           join sub in _unitOfWork.Repository<Subcode>().Reads() on s.Subj equals sub.Subcode1 into groupjoin
                           from a in groupjoin.DefaultIfEmpty()
                           where item.Contains(s.Nobr)
                           select new EmployeeSchoolDto
                           {
                               Nobr = s.Nobr,
                               Ok = s.Ok,
                               Educcode = s.Educcode,
                               Adate = s.Adate,
                               DateB = s.DateB,
                               DateE = s.DateE,
                               DayOrNight = s.DayOrNight,
                               SubjDetail = s.SubjDetail,
                               Graduated = s.Graduated,
                               Schl1 = s.Schl1,
                               Subj = a.Subdesc,
                               EduccodeName = ed.Name,
                               EduccodeSort = ed.Sort
                           };

                employeeSchoolDtos.AddRange(data.ToList());
            }
            return employeeSchoolDtos.ToList();
        }

        public List<EmployeeWorkDto> GetEmployeeWork(List<string> employeeList)
        {
            List<EmployeeWorkDto> employeeWorkDtos = new List<EmployeeWorkDto>();

            foreach (var item in employeeList.Split(2100))
            {
                var data = from b in _unitOfWork.Repository<Basetts>().Reads()
                           join d in _unitOfWork.Repository<Dept>().Reads() on b.Dept equals d.DNo
                           join da in _unitOfWork.Repository<Depta>().Reads() on b.Deptm equals da.DNo
                           join j in _unitOfWork.Repository<Job>().Reads() on b.Job equals j.Job1
                           join jl in _unitOfWork.Repository<Jobl>().Reads() on b.Jobl equals jl.Jobl1
                           join js in _unitOfWork.Repository<Jobs>().Reads() on b.Jobs equals js.Jobs1
                           join jo in _unitOfWork.Repository<Jobo>().Reads() on b.Jobo equals jo.Jobo1
                           join tts in _unitOfWork.Repository<Ttscode>().Reads() on b.Ttscode equals tts.Code
                           join dps in _unitOfWork.Repository<Depts>().Reads() on b.Depts equals dps.DNo
                           join empcd in _unitOfWork.Repository<Empcd>().Reads() on b.Empcd equals empcd.Empcd1
                           join comp in _unitOfWork.Repository<Comp>().Reads() on b.Comp equals comp.Comp1
                           join saltycd in _unitOfWork.Repository<Saltycd>().Reads() on b.Saltp equals saltycd.Saltycd1
                           where item.Contains(b.Nobr)
                           select new EmployeeWorkDto
                           {
                               Nobr = b.Nobr,
                               Adate = b.Adate,
                               Ddate = b.Ddate,
                               Dept = b.Dept,
                               Depta = b.Deptm,
                               Depts = b.Depts,
                               Empcd = b.Empcd,
                               Job = b.Job,
                               Jobl = b.Jobl,
                               Jobs = b.Jobs,
                               Jobo = b.Jobo,
                               Comp = b.Comp,
                               Ttscode = b.Ttscode,
                               DeptName = d.DName,
                               DeptaName = da.DName,
                               DeptsName = dps.DName,
                               EmpcdName = empcd.Empdescr,
                               JobName = j.JobName,
                               JoblName = jl.JobName,
                               JobsName = js.JobName,
                               JoboName = jo.JobName,
                               CompName = comp.Compname,
                               TtscodeName = tts.Name,
                               Saltp = b.Saltp,
                               SaltpName = saltycd.Saltyname
                           };
                employeeWorkDtos.AddRange(data.ToList());
            }
            return employeeWorkDtos.ToList();
        }

        public List<WorksInfoDto> GetEmployeeWorksInfo(List<string> employeeList)
        {
            List<WorksInfoDto> worksInfoDtos = new List<WorksInfoDto>();

            foreach (var item in employeeList.Split(2100))
            {
                var data = _unitOfWork.Repository<Works>().Reads()
                           .Where(p => item.Contains(p.Nobr))
                           .Select(p => new WorksInfoDto()
                           {
                               Nobr = p.Nobr,
                               Company = p.Company,
                               Title = p.Title,
                               Bdate = p.Bdate,
                               Edate = p.Edate,
                               Job = p.Job,
                               Note = p.Note,
                               KeyMan = p.KeyMan,
                               KeyDate = p.KeyDate,
                               TradeCode = p.TradeCode,
                               InMark = p.InMark,
                               InCabinet = p.InCabinet,
                               Volume = p.Volume,
                               DirTitle = p.DirTitle,
                               SecTitle = p.SecTitle,
                               People = p.People,
                               TelNo = p.TelNo,
                               Addr = p.Addr,
                               WorkId = p.WorkId
                           });
                worksInfoDtos.AddRange(data);
            }
            return worksInfoDtos.ToList();
        }

        public List<TtscodeDto> GetTtscode()
        {
            var data = _unitOfWork.Repository<Ttscode>().Reads()
                       .Select(p => new TtscodeDto()
                       {
                            Category = p.Category,
                            Code = p.Code,
                            Name = p.Name,
                            Sort = p.Sort,
                            Display = p.Display,
                       });
            return data.ToList();
        }
        public List<CompDto> GetComp()
        {
            var data = _unitOfWork.Repository<Comp>().Reads()
                       .Select(p => new CompDto()
                       {
                           Comp = p.Comp1,
                           Compname = p.Compname,
                           Sort = p.Sort
                       });
            return data.ToList();
        }
        public List<OutcdDto> GetOutReason()
        {
            var data = _unitOfWork.Repository<Outcd>().Reads()
                       .Select(p => new OutcdDto()
                       {
                           Outcd = p.Outcd1,
                           Outname = p.Outname
                       });
            return data.ToList();
        }

        public List<TtscdDto> GetTtscd()
        {
            var data = _unitOfWork.Repository<Ttscd>().Reads()
                       .Select(p => new TtscdDto()
                       {
                            Ttscd =p.Ttscd1,
                            Ttsname =p.Ttsname,
                            TtscdDisp = p.TtscdDisp
                       });
            return data.ToList();
        }
        public List<EmployeeRuleDto> GetEmployeeRule(EmployeeRuleEntry employeeRuleEntry)
        {
            var data = _unitOfWork.Repository<EmployeeRule>().Reads()
                       .Where(p => p.Nobr == employeeRuleEntry.EmployeeId &&
                       p.RuleType == employeeRuleEntry.RuleType &&
                       employeeRuleEntry.CheckDate.Date >= p.BeginDate && employeeRuleEntry.CheckDate.Date <= p.EndDate)
                       .Select(p => new EmployeeRuleDto()
                       {
                           Auto = p.Auto,
                           Nobr = p.Nobr,
                           RuleType = p.RuleType,
                           BeginDate = p.BeginDate,
                           EndDate = p.EndDate,
                           Value = p.Value,
                           Remark = p.Remark,
                           KeyDate = p.KeyDate,
                           KeyMan = p.KeyMan
                       });
            return data.ToList();
        }
    }
}
