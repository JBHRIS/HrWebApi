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
    public class System_View_SysApiVoid : ISystem_View_SysApiVoid
    {

        private IUnitOfWork _unitOfWork;

        public System_View_SysApiVoid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> DeleteApiVoidView(string Code)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoid>();
                var data = Repo.Reads().SingleOrDefault(x => x.Code == Code);
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

        public List<SysApiVoidDto> GetApiVoidView()
        {
            var data = _unitOfWork.Repository<SysApiVoid>().Reads().Select(p => new SysApiVoidDto
            {
                Code = p.Code,
                Name = p.Name,
                RoutePath = p.RoutePath

            });
            return data.ToList();
        }

        public ApiResult<string> InsertApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoid>();
                SysApiVoid sysApiVoid = new SysApiVoid() {
                    Code = sysApiVoidDto.Code, 
                    Name = sysApiVoidDto.Name,
                    RoutePath = sysApiVoidDto.RoutePath
                };
                Repo.Create(sysApiVoid);
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

        public ApiResult<string> UpdateApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoid>();
                var data = Repo.Read(x => x.Code == sysApiVoidDto.Code);
                if (data != null)
                {
                    data.Name = sysApiVoidDto.Name;
                    data.RoutePath = sysApiVoidDto.RoutePath;

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
