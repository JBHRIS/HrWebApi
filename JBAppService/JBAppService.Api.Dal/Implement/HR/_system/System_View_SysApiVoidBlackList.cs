using JBAppService.Api.Dal.Interface._system;
using JBAppService.Api.Dal.Models.HRContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto;

namespace JBAppService.Api.Dal.Implement.HR._system
{
    public class System_View_SysApiVoidBlackList : ISystem_View_SysApiVoidBlackList
    {
        private JBHRContext _context;
        public System_View_SysApiVoidBlackList(JBHRContext context)
        {
            this._context = context;
        }

        public List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr)
        {
            List<SysApiVoidBlackListDto> sysApiVoidBlackListDtos = new List<SysApiVoidBlackListDto>();


            //sysApiVoidBlackListDtos = from sys this._context.syyapi
            //var Repo = _unitOfWork.Repository<SysApiVoidBlackList>();
            //var data = Repo.Reads().Where(p => nobr.Contains(p.Nobr)).ToList();
            //nobr.ForEach(p => {
            //    SysApiVoidBlackListDto sysApiVoidBlackListDto = new SysApiVoidBlackListDto
            //    {
            //        Nobr = p,
            //        ApiVoidCode = new List<string>()
            //    };
            //    var same = data.FindAll(d => d.Nobr == p);
            //    same.ForEach(s => sysApiVoidBlackListDto.ApiVoidCode.Add(s.ApiVoidCode));
            //    sysApiVoidBlackListDtos.Add(sysApiVoidBlackListDto);
            //});
            return sysApiVoidBlackListDtos;
        }
    }
}
