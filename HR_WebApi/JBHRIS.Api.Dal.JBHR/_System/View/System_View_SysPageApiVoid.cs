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
    public class System_View_SysPageApiVoid : ISystem_View_SysPageApiVoid
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysPageApiVoid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> InsertPageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry,string KeyMan)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysPageApiVoid>();
                var isRepeat = Repo.Reads().Where(r => r.ApiVoidCode == sysPageApiVoidEntry.ApiVoidCode && r.PageCode == sysPageApiVoidEntry.PageCode).FirstOrDefault();
                if (isRepeat == null)
                {
                    SysPageApiVoid sysPageApiVoid = new SysPageApiVoid()
                    {
                        PageCode = sysPageApiVoidEntry.PageCode,
                        ApiVoidCode = sysPageApiVoidEntry.ApiVoidCode,
                        KeyDate = DateTime.Now,
                        KeyName = KeyMan
                    };
                    Repo.Create(sysPageApiVoid);
                    Repo.SaveChanges();
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

        public ApiResult<string> DeletePageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysPageApiVoid>();
                var data = _unitOfWork.Repository<SysPageApiVoid>().Reads().SingleOrDefault(x => x.ApiVoidCode == sysPageApiVoidEntry.ApiVoidCode && x.PageCode == sysPageApiVoidEntry.PageCode);
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

        public List<SysPageApiVoidDto> GetPageApiVoidView(string PageCode)
        {
            var data = _unitOfWork.Repository<SysPageApiVoid>().Reads().Select(p => new SysPageApiVoidDto
            {
                AutoKey = p.AutoKey,
                PageCode = p.PageCode,
                ApiVoidCode = p.ApiVoidCode,
                KeyDate = p.KeyDate,
                KeyName = p.KeyName
            }).Where(p => p.PageCode == PageCode);
         
            return data.ToList();
        }

    }
}
