using JBAppService.Api.Dal.Interface._system;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Models.HRContent;
using JBAppService.Api.Dto;

namespace JBAppService.Api.Dal.Implement.HR._system
{
    public class System_View_SysApiVoidWhiteList : ISystem_View_SysApiVoidWhiteList
    {
        private JBHRContext _context;
        public System_View_SysApiVoidWhiteList(JBHRContext context)
        {
            this._context = context;
        }

        public List<SysApiVoidWhiteListDto> GetApiVoidWhiteListView(List<string> nobr)
        {



            List<SysApiVoidWhiteListDto> sysApiVoidWhiteListDtos = new List<SysApiVoidWhiteListDto>();
            //var Repo = _unitOfWork.Repository<SysApiVoidWhiteList>();
            //var data = Repo.Reads().Where(p => nobr.Contains(p.Nobr)).ToList();
            //nobr.ForEach(p => {
            //    SysApiVoidWhiteListDto sysApiVoidWhiteListDto = new SysApiVoidWhiteListDto
            //    {
            //        Nobr = p,
            //        ApiVoidCode = new List<string>()
            //    };
            //    var same = data.FindAll(d => d.Nobr == p);
            //    same.ForEach(s => sysApiVoidWhiteListDto.ApiVoidCode.Add(s.ApiVoidCode));
            //    sysApiVoidWhiteListDtos.Add(sysApiVoidWhiteListDto);
            //});
            return sysApiVoidWhiteListDtos;
        }
    }
}
