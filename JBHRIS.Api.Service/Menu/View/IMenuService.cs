using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Menu.View
{
    public interface IMenuService
    {
        public List<SysMenuDto> GetMenu(string Code,string Nobr);
        public List<SysMenuDto> GetAllMenu(string Code);
        public List<SysMenuDto> GetFeatures(string Code,string keyword, string Nobr);
        public List<SysMenuDto> GetIndexFeatures(string Nobr);
        public bool InsertMenu(SysMenuDto sysMenuDto);
        public bool UpdateMenu(SysMenuDto sysMenuDto);
        public ApiResult<string> DeleteMenu(string code);
    }
}
