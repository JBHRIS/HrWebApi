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
    public class System_View_SysApiVoidBlackList : ISystem_View_SysApiVoidBlackList
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysApiVoidBlackList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> DeleteApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoidBlackList>();
                var data = Repo.Read(x => x.Nobr == sysApiVoidBlackListEntry.Nobr && x.ApiVoidCode == sysApiVoidBlackListEntry.ApiVoidCode);
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

        public List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr)
        {
            List<SysApiVoidBlackListDto> sysApiVoidBlackListDtos = new List<SysApiVoidBlackListDto>();
            var Repo = _unitOfWork.Repository<SysApiVoidBlackList>();
            var data = Repo.Reads().Where(p => nobr.Contains(p.Nobr)).ToList();
            nobr.ForEach(p => {
                SysApiVoidBlackListDto sysApiVoidBlackListDto = new SysApiVoidBlackListDto
                {
                    Nobr = p,
                    ApiVoidCode = new List<string>()
                };
                var same =  data.FindAll(d => d.Nobr == p);
                same.ForEach(s => sysApiVoidBlackListDto.ApiVoidCode.Add(s.ApiVoidCode));
                sysApiVoidBlackListDtos.Add(sysApiVoidBlackListDto);
            });
            return sysApiVoidBlackListDtos;
        }

        public ApiResult<string> InsertApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry,string KeyMan)
        {
            ApiResult<string> statusResultDto = new ApiResult<string>()
            {
                State = false
            };
            try
            {
                var Repo = _unitOfWork.Repository<SysApiVoidBlackList>();
                var isRepeat = Repo.Reads().Where(r => r.ApiVoidCode == sysApiVoidBlackListEntry.ApiVoidCode && r.Nobr == sysApiVoidBlackListEntry.Nobr).FirstOrDefault();
                if (isRepeat == null)
                {
                    SysApiVoidBlackList sysApiVoidBlackList = new SysApiVoidBlackList()
                    {
                        Nobr = sysApiVoidBlackListEntry.Nobr,
                        ApiVoidCode = sysApiVoidBlackListEntry.ApiVoidCode,
                        KeyMan = KeyMan,
                        KeyDate = DateTime.Now
                    };
                    Repo.Create(sysApiVoidBlackList);
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
