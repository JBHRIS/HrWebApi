using JBHRIS.Api.Dal._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto;
using Microsoft.EntityFrameworkCore;
using JBHRIS.Api.Dal.JBHR.Repository;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class System_View_SysRole : ISystem_View_SysRole
    {
        private ApiResult<List<SysRoleDto>> statusResultDto = new ApiResult<List<SysRoleDto>>()
        {
            State = false
        };

        private IUnitOfWork _unitOfWork;

        public System_View_SysRole(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ApiResult<List<SysRoleDto>> DeleteRoleView(string Code)
        {
            try
            {
                var Repo = _unitOfWork.Repository<SysRole>();
                var data = Repo.Read(x => x.Code == Code);
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

        public List<SysRoleDto> GetRoleView()
        {
            var Repo = _unitOfWork.Repository<SysRole>();
            var data = Repo.Reads().Select(p => new SysRoleDto
            {
                Code = p.Code,
                Name = p.Name,
                IsAdminRole = p.IsAdminRole,
                IsVisible = p.IsVisible

            }).ToList();
            return data;
        }

        public ApiResult<List<SysRoleDto>> InsertRoleView(SysRoleDto sysRoleDto)
        {
            try
            {
                var Repo = _unitOfWork.Repository<SysRole>();
                SysRole sysRole = new SysRole() {
                    Code = sysRoleDto.Code,
                    Name = sysRoleDto.Name,
                    IsAdminRole = sysRoleDto.IsAdminRole,
                    IsVisible = sysRoleDto.IsVisible
                };
                Repo.Create(sysRole);
                Repo.SaveChanges();
                statusResultDto.State = true;
                return statusResultDto;
            }
            catch(Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }
        }

        public ApiResult<List<SysRoleDto>> UpdateRoleView(SysRoleDto sysRoleDto)
        {
            try
            {
                var Repo = _unitOfWork.Repository<SysRole>();
                var data = Repo.Read(x => x.Code == sysRoleDto.Code);
                if (data != null)
                {
                    data.IsAdminRole = sysRoleDto.IsAdminRole;
                    data.IsVisible = sysRoleDto.IsVisible;
                    data.Name = sysRoleDto.Name;

                    Repo.Update(data);
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
    }
}
