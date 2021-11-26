using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Employee
{
    public class Employee_View_GetEmployee : IEmployee_View_GetEmployee
    {
        private IUnitOfWork _unitOfWork;
        public Employee_View_GetEmployee(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApiRolesDto> GetApiRoles(List<string> Nobr)
        {
            var data = from ur in _unitOfWork.Repository<SysUserRole>().Reads()
                       join r in _unitOfWork.Repository<SysRole>().Reads() on ur.RoleCode equals r.Code
                       into rgrp
                       from rg in rgrp.DefaultIfEmpty()
                       join rp in _unitOfWork.Repository<SysRolePage>().Reads() on rg.Code equals rp.RoleCode
                       into rpgrp
                       from rpg in rpgrp.DefaultIfEmpty()
                       join f in _unitOfWork.Repository<FileStructure>().Reads() on rpg.PageCode equals f.Code
                       into fgrp
                       from fg in fgrp.DefaultIfEmpty()
                       join pa in _unitOfWork.Repository<SysPageApiVoid>().Reads() on fg.Code equals pa.PageCode
                       into pagrp
                       from pag in pagrp.DefaultIfEmpty()
                       join v in _unitOfWork.Repository<SysApiVoid>().Reads() on pag.ApiVoidCode equals v.Code
                       into vgrp
                       from vg in vgrp.DefaultIfEmpty()
                       where Nobr.Contains(ur.Nobr)
                       select new ApiRolesDto
                       {
                           Nobr = ur.Nobr,
                           RoleCode = rg.Code,
                           RoleName = rg.Name,
                           IsAdminRole = rg.IsAdminRole,
                           PageCode = fg.Code,
                           PageName = fg.SFileTitle,
                           ApiVoidCode = vg.Code,
                           ApiVoidName = vg.Name
                       };
            return data.ToList();
        }

        public List<EmployeeViewDto> GetEmployeeView(List<string> employeeList)
        {
            var data = from b in _unitOfWork.Repository<Base>().Reads()
                       join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                       into btgrp
                       from btg in btgrp.DefaultIfEmpty()
                       where DateTime.Today >= btg.Adate && DateTime.Today <= btg.Ddate.Value && employeeList.Contains(b.Nobr)
                       && new string[] { "1", "4", "6" }.Contains(btg.Ttscode)
                       select new EmployeeViewDto
                       {
                           EmployeeId = b.Nobr,
                           EmployeeName = b.NameC
                       };
            return data.ToList();
        }

        public List<EmployeeViewDto> GetEmployee()
        {
            var data = from b in _unitOfWork.Repository<Base>().Reads()
                       join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                       into btgrp
                       from btg in btgrp.DefaultIfEmpty()
                       where DateTime.Today >= btg.Adate && DateTime.Today <= btg.Ddate.Value
                       && new string[] { "1", "4", "6" }.Contains(btg.Ttscode)
                       select new EmployeeViewDto
                       {
                           EmployeeId = b.Nobr,
                           EmployeeName = b.NameC
                       };
            return data.ToList();
        }
        public GetEmployeSalAttEndDayDto GetEmployeSalAttEndDay(string Nobr, DateTime date)
        {
            var data = from b in _unitOfWork.Repository<Base>().Reads()
                       join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                       into btgrp
                       from btg in btgrp.DefaultIfEmpty()
                       join d in _unitOfWork.Repository<Datagroup>().Reads() on btg.Saladr equals d.Datagroup1
                       into btgdgrp
                       from btgdg in btgdgrp.DefaultIfEmpty()
                       join us2 in _unitOfWork.Repository<USys2>().Reads() on btg.Comp equals us2.Comp
                       into btgdgus2grp
                       from btgdgus2 in btgdgus2grp.DefaultIfEmpty()
                       where date >= btg.Adate && date <= btg.Ddate.Value && b.Nobr == Nobr
                       && new string[] { "1", "4", "6" }.Contains(btg.Ttscode)
                       select new GetEmployeSalAttEndDayDto
                       {
                           EmployeeId = b.Nobr,
                           EmployeeName = b.NameC,
                           Saladr = btg.Saladr,
                           Comp = btg.Comp,
                           AttEndDay = btgdgus2.Attmonth.GetValueOrDefault(),
                           SalEndDay = btgdgus2.Salmonth.GetValueOrDefault(),
                           GroupName = btgdg.Groupname
                       };
            return data.FirstOrDefault();
        }

        public List<string> GetAllDeptManger()
        {
            var deptMan = from d in _unitOfWork.Repository<Dept>().Reads()
                          select d.Nobr;
            return deptMan.ToList();
        }

        public List<string> GetPeopleByDeptTree(List<string> employeeList, DateTime CheckDate)
        {
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => employeeList.Contains(p.Nobr) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }

        public List<string> GetAllDeptaManger()
        {
            var deptaMan = from d in _unitOfWork.Repository<Depta>().Reads()
                           select d.Nobr;
            return deptaMan.ToList();
        }

        public List<string> GetPeopleByDeptaTree(List<string> employeeList, DateTime CheckDate)
        {
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => employeeList.Contains(p.Nobr) && CheckDate >= p.Adate && CheckDate <= p.Ddate.Value).Select(p => p.Nobr).Distinct().ToList();
        }

        public decimal GetEmployeeOtMin(string employeeId)
        {
            var data = from btts in _unitOfWork.Repository<Basetts>().Reads()
                       join otr in _unitOfWork.Repository<Otratecd>().Reads() on btts.Calot equals otr.OtrateCode
                       where
                       DateTime.Today >= btts.Adate && DateTime.Today <= btts.Ddate.Value
                       && employeeId == btts.Nobr
                       && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                       select otr;
            return data.FirstOrDefault().MinHours;
        }

        public List<PeopleApDateViewDto> GetPeopleApDate(DateTime BeginDate, DateTime EndDate)
        {
            var newDate = new DateTime(9999, 12, 31, 0, 0, 0, 0);
            var data = from btts in _unitOfWork.Repository<Basetts>().Reads()
                       where newDate >= btts.Adate && newDate <= btts.Ddate
                       where btts.ApDate >= BeginDate && btts.ApDate <= EndDate
                       && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                       && new string[] { "", "03" }.Contains(btts.PassType.Trim())
                       select new PeopleApDateViewDto
                       {
                           EmpId = btts.Nobr,
                           ApDate = btts.ApDate,
                           IndtDate = btts.Indt
                       };

            return data.ToList();
        }
        public List<AllPassTypeDto> GetAllPassType()
        {
            var data = from m in _unitOfWork.Repository<Mtcode>().Reads()
                       where m.Category == "PASS_TYPE"
                       select new AllPassTypeDto
                       {
                           Code = m.Code,
                           Name = m.Name,
                           Sort = m.Sort,
                           Display = m.Display
                       };

            return data.ToList();
        }

        public List<EffemployViewDto> GetEffemployView(EffemployEntryDto effemployEntryDto)
        {
            var data = from e in _unitOfWork.Repository<Effemploy>().Reads()
                       join lvl in _unitOfWork.Repository<Efflvl>().Reads() on e.Efflvl equals lvl.Efflvl1
                       into elvlGrp
                       from elvl in elvlGrp.DefaultIfEmpty()
                       join t in _unitOfWork.Repository<Efftype>().Reads() on e.Efftype equals t.Efftype1
                       into etGrp
                       from et in etGrp.DefaultIfEmpty()
                       where e.Nobr == effemployEntryDto.EmpId &&
                       effemployEntryDto.Yymm.Contains(e.Yymm)
                       select new EffemployViewDto
                       {
                           EmpId = e.Nobr,
                           Yymm = e.Yymm,
                           EfflvlCode = e.Efflvl,
                           EfflvlName = elvl.EfflvlName,
                           EffScore = e.Effscore,
                           EfftypeCode = e.Efftype,
                           EfftypeName = et.EfftypeName,
                           Import = e.Import,
                           KeyMan = e.KeyMan,
                           KeyDate = e.KeyDate
                       };
            return data.ToList();
        }
    }
}
