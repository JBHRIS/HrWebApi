using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Menu.View
{
    public interface IMenu_View_GetMenu
    {
        public List<SysMenuDto> GetAllMenu();
        public List<SysMenuDto> GetMenu(string Code);
        public List<SysMenuDto> GetMenuIncludeRoot(string Code);
        public bool InsertMenu(SysMenuDto sysMenuDto);
        public bool UpdateMenu(SysMenuDto sysMenuDto);
        public ApiResult<string> DeleteMenu(string code);
    }
}
