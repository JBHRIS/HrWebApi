using JBHRIS.Api.Dal._System;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class System_UserDataRole : ISystem_UserDataRole
    {
        private IUnitOfWork _unitOfWork;

        public System_UserDataRole(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<HrDataRoleDto> GetDataRolesById(string userId)
        {
            if (_unitOfWork.Repository<UUser>().Read(p => p.UserId == userId).Admin)
            {
                return _unitOfWork.Repository<Datagroup>().Reads().Select(p => new HrDataRoleDto { DataGroup = p.Datagroup1, ReadRule = true, WriteRule = true }).ToList();
            }
            else
                return _unitOfWork.Repository<UDatagroup>().Reads().Where(p => p.UserId == userId).Select(p => new HrDataRoleDto { DataGroup = p.Datagroup, ReadRule = p.Readrule, WriteRule = p.Writerule }).ToList();
        }
        /// <summary>
        /// 沒有預設角色存在就刪除，有預設角色新增
        /// </summary>
        /// <typeparam name="T">要操作的資料表</typeparam>
        /// <param name="hasRole"></param>
        /// <param name="sUserRoleList">現有資料表內的資料</param>
        /// <param name="repo">要新增或刪除的資料表</param>
        /// <param name="entity">要新增或刪除的資料</param>
        private void SetRole<T>(bool hasRole, List<T> sUserRoleList, IRepository<T> repo, T entity)
        {
            if (!hasRole)
            {
                if (sUserRoleList != null && sUserRoleList.Count>0)
                {
                    sUserRoleList.ForEach(r =>
                    {
                        repo.Delete(r);
                    });
                }
            }
            else
            {
                if (sUserRoleList == null || sUserRoleList.Count == 0)
                {
                    repo.Create(entity);
                }
            }
            repo.SaveChanges();
        }
        /// <summary>
        /// 參考別的資料表在登入時判斷新增或刪除角色
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public ApiResult<string> SetPresetRole(string Nobr)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            string AdminCode = "Admin";
            string HrCode = "Hr";
            string EmpCode = "Emp";
            string ManagerCode = "Manager";
            bool hasEmp = _unitOfWork.Repository<Base>().Reads().Where(p => p.Nobr == Nobr).FirstOrDefault() == null ? false : true;
            bool hasManger = _unitOfWork.Repository<Dept>().Reads().Where(p => p.Nobr == Nobr).FirstOrDefault() == null ? false : true;
            bool hasHr = (from us in _unitOfWork.Repository<UUser>().Reads()
                             join b in _unitOfWork.Repository<Base>().Reads() on us.Nobr equals b.Nobr
                             where us.Nobr == Nobr
                             select us).FirstOrDefault() == null ? false : true;
            bool hasAdmin = (from us in _unitOfWork.Repository<UUser>().Reads()
                                join b in _unitOfWork.Repository<Base>().Reads() on us.Nobr equals b.Nobr
                                    where us.Nobr == Nobr && us.Admin == true
                                        select us).FirstOrDefault() == null ? false : true;
            var repo = _unitOfWork.Repository<SysUserRole>();
            var RoleEmpData = _unitOfWork.Repository<SysUserRole>().Reads().Where(p => p.Nobr == Nobr && p.RoleCode == EmpCode).ToList();
            var RoleManagerData = _unitOfWork.Repository<SysUserRole>().Reads().Where(p => p.Nobr == Nobr && p.RoleCode == ManagerCode).ToList();
            var RoleHrData = _unitOfWork.Repository<SysUserRole>().Reads().Where(p => p.Nobr == Nobr && p.RoleCode == HrCode).ToList();
            var RoleAdminData = _unitOfWork.Repository<SysUserRole>().Reads().Where(p => p.Nobr == Nobr && p.RoleCode == AdminCode).ToList();
            try
            {
                SetRole<SysUserRole>(hasEmp, RoleEmpData, repo, new SysUserRole { Nobr = Nobr, RoleCode = EmpCode });
                SetRole<SysUserRole>(hasManger, RoleManagerData, repo, new SysUserRole { Nobr = Nobr, RoleCode = ManagerCode });
                SetRole<SysUserRole>(hasHr, RoleHrData, repo, new SysUserRole { Nobr = Nobr, RoleCode = HrCode });
                SetRole<SysUserRole>(hasAdmin, RoleAdminData, repo, new SysUserRole { Nobr = Nobr, RoleCode = AdminCode });
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public List<string> GetDataGroup()
        {
            var sql = from d in _unitOfWork.Repository<Datagroup>().Reads()
                      select d.Datagroup1;
            return sql.ToList();
        }
    }
}
