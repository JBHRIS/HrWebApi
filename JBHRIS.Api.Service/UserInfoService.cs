using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service._System.View;
using JBHRIS.Api.Service.Employee.View;
using NLog.Internal;
using System.Collections.Generic;
using System.Linq;

namespace JBHRIS.Api.Service
{
    public class UserInfoService
    {
        private ISystem_UserDal _system_UserDal;
        private ISystem_UserDataRole _system_UserDataRole;
        private IEmployeeViewService _employeeViewService;
        private IEmployee_View_GetEmployee _employee_View_GetEmployee;
        private ISysApiVoidWhiteListService _sysApiVoidWhiteListService;
        private ISysApiVoidBlackListService _sysApiVoidBlackListService;
        private ISystem_View_SysUserRole _system_View_SysUserRole;

        /// <summary>
        /// 取得使用者資訊的服務
        /// </summary>
        public UserInfoService(ISystem_UserDal system_UserDal,
            ISystem_UserDataRole system_UserDataRole,
            Employee.View.IEmployeeViewService employeeViewService,
            IEmployee_View_GetEmployee employee_View_GetEmployee,
            ISysApiVoidWhiteListService sysApiVoidWhiteListService,
            ISysApiVoidBlackListService sysApiVoidBlackListService,
            ISystem_View_SysUserRole system_View_SysUserRole)
        {
            _system_UserDal = system_UserDal;
            _system_UserDataRole = system_UserDataRole;
            _employeeViewService = employeeViewService;
            _employee_View_GetEmployee = employee_View_GetEmployee;
            _sysApiVoidWhiteListService = sysApiVoidWhiteListService;
            _sysApiVoidBlackListService = sysApiVoidBlackListService;
            _system_View_SysUserRole = system_View_SysUserRole;
        }
        /// <summary>
        /// 取得api的權限
        /// </summary>
        /// <param name="UserId">使用者編號</param>
        /// <returns></returns>
        public string[] GetApiRoles(string UserId)
        {
            var data =  _employee_View_GetEmployee.GetApiRoles(new List<string>() {UserId});
            List<string> Roles = new List<string>();
            var isAdminRole = data.Where(p => p.IsAdminRole == true).FirstOrDefault();
            if (isAdminRole != null)
            {
                Roles.Add("Admin");
            }
            else
            {
                data.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.ApiVoidCode) && p.Nobr == UserId)
                    {
                        Roles.Add(p.ApiVoidCode);
                    }
                });
                var whiteList = _sysApiVoidWhiteListService.GetApiVoidWhiteListView(new List<string> { UserId });
                SysApiVoidWhiteListDto whiteListUserId = whiteList.Where(p => p.Nobr == UserId).FirstOrDefault();
                if (whiteListUserId.ApiVoidCode.Count > 0)
                {
                    whiteListUserId.ApiVoidCode.ForEach(a => {
                        if (!(Roles.Where(r => a == r).Count() > 0))
                        {
                            Roles.Add(a);
                        }
                    });
                }
                var blackList = _sysApiVoidBlackListService.GetApiVoidBlackListView(new List<string> { UserId });
                SysApiVoidBlackListDto blackListUserId = blackList.Where(p => p.Nobr == UserId).FirstOrDefault();
                if (blackListUserId.ApiVoidCode.Count > 0)
                {
                    blackListUserId.ApiVoidCode.ForEach(a =>
                    {
                        if (Roles.Where(r => a == r).Count() > 0)
                        {
                            Roles.Remove(a);
                        }
                    });
                }
            }
            return Roles.Distinct().ToArray();
        }
        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="UserId">使用者編號</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string UserId, UserInfo userInfo)
        {
            UserInfo user = new UserInfo();
            user.UserId = UserId;
            var emp = _employeeViewService.GetEmployeeJobView(new List<string> { UserId }).FirstOrDefault();
            if (emp != null)
                user.UserName = emp.EmployeeName;
            var hrUser = _system_UserDal.GetUserByBindingID(UserId);
            if (hrUser != null)
            {
                var hrUserDataRoles = _system_UserDataRole.GetDataRolesById(hrUser.UserId);
                user.DataGroups = hrUserDataRoles.Select((p => p.DataGroup)).ToList();
                if (hrUser.Admin)
                {
                    user.DataGroups.AddRange(_system_UserDataRole.GetDataGroup());
                }
                user.DataGroups = user.DataGroups.Distinct().ToList();
            }
            user.Company = emp.Company;
            user.Department = emp.Department;
            user.DepartmentName = emp.DepartmentName;
            user.DeptA = emp.DeptA;
            user.DeptAName = emp.DeptAName;
            user.Job = emp.Job;
            user.JobName = emp.JobName;
            user.Role = _system_View_SysUserRole.GetUserRoleView(new List<string>() { UserId }).FirstOrDefault().RoleCode;
            user.DepartmentExtra = _system_View_SysUserRole.GetUserDepartmentExtra(UserId);
            user.Connection = userInfo.Connection;
            return user;
        }

        public ApiResult<string> SetPresetRole(string Nobr)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult = _system_UserDataRole.SetPresetRole(Nobr);
            return apiResult;
        }
    }
}
