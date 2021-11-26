using JBHRIS.Api.Dal._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto;
using Microsoft.EntityFrameworkCore;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dal.JBHR.Repository;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class System_View_SysUserRole : ISystem_View_SysUserRole
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysUserRole(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> DeleteUserRoleView(SysUserRoleEntry sysUserRoleEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysUserRole>();
                var data = Repo.Read(x => x.Nobr == sysUserRoleEntry.Nobr && x.RoleCode == sysUserRoleEntry.RoleCode);
                if (data != null)
                {
                    Repo.Delete(data);
                    Repo.SaveChanges();
                    statusResultDto.State = true;
                }
                return statusResultDto;
            }
            catch (Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }

        }

        public List<string> GetUserDepartmentExtra(string nobr)
        {
            var sql = from ud in _unitOfWork.Repository<UDataid>().Reads()
                      where nobr == ud.UserId
                      select ud.Dept;
            return sql.ToList();
        }

        public List<SysUserRoleDto> GetUserRoleView(List<string> nobr)
        {
            List<SysUserRoleDto> sysUserRoleDtos = new List<SysUserRoleDto>();
            var Repo = _unitOfWork.Repository<SysUserRole>();
            var data = Repo.Reads().Where(p => nobr.Contains(p.Nobr)).ToList();
            nobr.ForEach(p => {
                SysUserRoleDto sysUserRoleDto = new SysUserRoleDto
                {
                    Nobr = p,
                    RoleCode = new List<string>()
                };
                var same =  data.FindAll(d => d.Nobr == p);
                same.ForEach(s => sysUserRoleDto.RoleCode.Add(s.RoleCode));
                sysUserRoleDtos.Add(sysUserRoleDto);
            });
            return sysUserRoleDtos;
        }

        public ApiResult<string> InsertUserRoleView(SysUserRoleEntry sysUserRoleEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysUserRole>();
                var isRepeat = Repo.Reads().Where(r => r.RoleCode == sysUserRoleEntry.RoleCode && r.Nobr == sysUserRoleEntry.Nobr).FirstOrDefault();
                if (isRepeat == null)
                {
                    SysUserRole sysUserRole = new SysUserRole()
                    {
                        Nobr = sysUserRoleEntry.Nobr,
                        RoleCode = sysUserRoleEntry.RoleCode
                    };
                    Repo.Create(sysUserRole);
                    Repo.SaveChanges();
                    statusResultDto.State = true;
                }
                else
                {
                    statusResultDto.Message = "資料已重複";
                }
                return statusResultDto;
            }
            catch(Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }
        }
    }
}
