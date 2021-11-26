using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Normal;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JBHRIS.Api.Service.Employee.Normal
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private IMemoryCache _memoryCache;
        private IUnitOfWork _unitOfWork;
        private IEmployee_Normal_GetPeopleByDept _employee_Normal_GetPeopleByDept;
        private IEmployee_Normal_GetPeopleByDepta _employee_Normal_GetPeopleByDepta;

        public EmployeeRoleService(IMemoryCache memoryCache, IUnitOfWork unitOfWork,
            IEmployee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept,
            IEmployee_Normal_GetPeopleByDepta employee_Normal_GetPeopleByDepta)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            _employee_Normal_GetPeopleByDept = employee_Normal_GetPeopleByDept;
            _employee_Normal_GetPeopleByDepta = employee_Normal_GetPeopleByDepta;
        }
        public List<EmployeeRoleDto> GetEmployeeRolesCache(ClaimsPrincipal user)
        {
            var roles = GetRoles(user);
            var empRoles = _memoryCache.Get<List<EmployeeRoleDto>>(CacheEntry.EmployeeRole);
            if (empRoles != null)
                return empRoles.Where(p => roles.Contains(p.Role)).ToList();
            empRoles = GetEmployeeRolesCache();
            _memoryCache.Set(CacheEntry.EmployeeRole, empRoles, DateTime.Now.AddSeconds(30));
            return empRoles.Where(p => roles.Contains(p.Role)).ToList();
        }
        public List<string> GetAllowEmloyeeList(ClaimsPrincipal user)
        {
            var emps = _memoryCache.Get<List<EmlpoyeeDataGroupDto>>(CacheEntry.EmployeeList);
            if (emps == null)
            {
                emps = GetAllowEmloyeeListCache(user);
                _memoryCache.Set(CacheEntry.EmployeeRole, emps, DateTime.Now.AddSeconds(30));
            }
            List<string> empList = new List<string>();
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            empList.Add(userInfo.UserId);
            if (userInfo != null)
            {
                if(userInfo.DepartmentExtra != null)
                {
                    empList.AddRange(emps.Where(p => userInfo.DepartmentExtra.Contains(p.Department)).Select(p => p.EmployeeId).ToList());
                }
                bool hasManger = _unitOfWork.Repository<Dept>().Reads().Where(p => p.Nobr == userInfo.UserId).FirstOrDefault() == null ? false : true;
                bool hasAdmin = (from us in _unitOfWork.Repository<UUser>().Reads()
                                 join b in _unitOfWork.Repository<Base>().Reads() on us.Nobr equals b.Nobr
                                 where us.Nobr == userInfo.UserId && us.Admin == true
                                 select us).FirstOrDefault() == null ? false : true;
                if (hasManger || hasAdmin)
                {
                    empList.AddRange(emps.Where(p => userInfo.Department.Contains(p.Department)).Select(p => p.EmployeeId).ToList());
                }
                if (userInfo.DataGroups != null)
                {
                    empList.AddRange(emps.Where(p => userInfo.DataGroups.Contains(p.DataGroup)).Select(p => p.EmployeeId).ToList());
                }
            }
            return empList.Distinct().ToList();
        }
        List<EmlpoyeeDataGroupDto> GetAllowEmloyeeListCache(ClaimsPrincipal user)
        {
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => DateTime.Today >= p.Adate && DateTime.Today <= p.Ddate.Value
                      && new string[] { "1", "4", "6" }.Contains(p.Ttscode)).Select(p => new EmlpoyeeDataGroupDto
            {
                DataGroup = p.Saladr,
                EmployeeId = p.Nobr,
                Department = p.Dept
            }).ToList();
        }


        public string[] GetRoles(ClaimsPrincipal user)
        {
            var userData = user.Claims.FirstOrDefault(p => p.Type.Contains("userdata"));
            if (userData != null)
            {
                var users = JsonConvert.DeserializeObject<UserInfo>(userData.Value);
                if (users != null)
                {
                    return users.DataGroups.ToArray();
                }
            }
            return new string[] { };
        }

        private List<EmployeeRoleDto> GetEmployeeRolesCache()
        {
            //return new List<EmployeeRoleDto> {
            //new EmployeeRoleDto{EmployeeId="111111",Role="A" },
            //new EmployeeRoleDto{EmployeeId="222222",Role="A" },
            //new EmployeeRoleDto{EmployeeId="333333",Role="B" },
            //new EmployeeRoleDto{EmployeeId="444444",Role="C" },
            //};
            return _unitOfWork.Repository<Basetts>().Reads().Where(p => DateTime.Today >= p.Adate && DateTime.Today <= p.Ddate.Value
                      && new string[] { "1", "4", "6" }.Contains(p.Ttscode)).Select(p => new EmployeeRoleDto { EmployeeId = p.Nobr, Role = p.Saladr, Dept = p.Dept }).ToList();
        }

        public List<string> GetAllowEmloyeeDeptTreeList(ClaimsPrincipal user)
        {
            List<string> empList = new List<string>();
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            empList.AddRange(_employee_Normal_GetPeopleByDept.GetPeopleByDeptTree(userInfo.Department));
            return empList.Distinct().ToList();
        }

        public List<string> GetAllowEmloyeeDeptaTreeList(ClaimsPrincipal user)
        {
            List<string> empList = new List<string>();
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            empList.AddRange(_employee_Normal_GetPeopleByDepta.GetPeopleByDeptaTree(userInfo.DeptA));
            return empList.Distinct().ToList();
        }

        public List<string> GetAllowEmloyeeDeptExtraTreeList(ClaimsPrincipal user)
        {
            List<string> empList = new List<string>();
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(user);
            userInfo.DepartmentExtra.ForEach(d =>
            {
                empList.AddRange(_employee_Normal_GetPeopleByDept.GetPeopleByDeptTree(d));
            });
            return empList.Distinct().ToList();
        }
    }
}
