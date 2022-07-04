using JBHRIS.Api.Dal._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto;
using Microsoft.EntityFrameworkCore;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto._System.Entry;

namespace JBHRIS.Api.Dal.JBHR._System
{
    public class System_View_SysRolePage : ISystem_View_SysRolePage
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysRolePage(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> InsertRolePageView(SysRolePageEntry sysRolePageEntry, string KeyMan)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var roleRepo = _unitOfWork.Repository<SysRolePage>();
                var isRepeat = roleRepo.Reads().Where(r => r.RoleCode == sysRolePageEntry.RoleCode && r.PageCode == sysRolePageEntry.PageCode).FirstOrDefault();
                if(isRepeat == null)
                {
                    SysRolePage sysRolePage = new SysRolePage()
                    {
                        RoleCode = sysRolePageEntry.RoleCode,
                        PageCode = sysRolePageEntry.PageCode,
                        KeyDate = DateTime.Now,
                        KeyMan = KeyMan
                    };
                    roleRepo.Create(sysRolePage);
                    roleRepo.SaveChanges();
                    statusResultDto.State = true;
                }
                else
                {
                    statusResultDto.Message = "資料已重複";
                }
                return statusResultDto;
            }
            catch (Exception ex)
            {
                statusResultDto.Message = ex.ToString();
                return statusResultDto;
            }
        }

        public ApiResult<string> DeleteRolePageView(SysRolePageEntry sysRolePageEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var roleRepo = _unitOfWork.Repository<SysRolePage>();
                var data = _unitOfWork.Repository<SysRolePage>().Reads().SingleOrDefault(x => x.RoleCode == sysRolePageEntry.RoleCode  && x.PageCode == sysRolePageEntry.PageCode);
                if (data != null)
                {
                    roleRepo.Delete(data);
                    roleRepo.SaveChanges();
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

        public List<SysRolePageDto> GetPageToRoleView(string PageCode)
        {
            var data = _unitOfWork.Repository<SysRolePage>().Reads().Select(p => new SysRolePageDto
            {
                AutoKey = p.AutoKey,
                RoleCode = p.RoleCode,
                PageCode = p.PageCode,
                KeyDate = p.KeyDate,
                KeyMan = p.RoleCode
            }).Where(p => p.PageCode == PageCode).ToList();
            return data;
        }

        public List<SysRolePageDto> GetRoleToPageView(string RoleCode)
        {
            var data = _unitOfWork.Repository<SysRolePage>().Reads().Select(p => new SysRolePageDto
            {
                AutoKey = p.AutoKey,
                RoleCode = p.RoleCode,
                PageCode = p.PageCode,
                KeyDate = p.KeyDate,
                KeyMan = p.RoleCode
            }).Where(p => p.RoleCode == RoleCode).ToList();
            return data;   
        }

    }
}
