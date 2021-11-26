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
    public class System_View_SysApiVoidWhiteList : ISystem_View_SysApiVoidWhiteList
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysApiVoidWhiteList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> DeleteApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoidWhiteList>();
                var data = Repo.Read(x => x.Nobr == sysApiVoidWhiteListEntry.Nobr && x.ApiVoidCode == sysApiVoidWhiteListEntry.ApiVoidCode);
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

        public List<SysApiVoidWhiteListDto> GetApiVoidWhiteListView(List<string> nobr)
        {
            List<SysApiVoidWhiteListDto> sysApiVoidWhiteListDtos = new List<SysApiVoidWhiteListDto>();
            var Repo = _unitOfWork.Repository<SysApiVoidWhiteList>();
            var data = Repo.Reads().Where(p => nobr.Contains(p.Nobr)).ToList();
            nobr.ForEach(p => {
                SysApiVoidWhiteListDto sysApiVoidWhiteListDto = new SysApiVoidWhiteListDto
                {
                    Nobr = p,
                    ApiVoidCode = new List<string>()
                };
                var same =  data.FindAll(d => d.Nobr == p);
                same.ForEach(s => sysApiVoidWhiteListDto.ApiVoidCode.Add(s.ApiVoidCode));
                sysApiVoidWhiteListDtos.Add(sysApiVoidWhiteListDto);
            });
            return sysApiVoidWhiteListDtos;
        }

        public ApiResult<string> InsertApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry,string KeyMan)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoidWhiteList>();
                var isRepeat = Repo.Reads().Where(r => r.ApiVoidCode == sysApiVoidWhiteListEntry.ApiVoidCode && r.Nobr == sysApiVoidWhiteListEntry.Nobr).FirstOrDefault();
                if (isRepeat == null)
                {
                    SysApiVoidWhiteList sysApiVoidWhiteList = new SysApiVoidWhiteList()
                    {
                        Nobr = sysApiVoidWhiteListEntry.Nobr,
                        ApiVoidCode = sysApiVoidWhiteListEntry.ApiVoidCode,
                        KeyMan = KeyMan,
                        KeyDate = DateTime.Now
                    };
                    Repo.Create(sysApiVoidWhiteList);
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
