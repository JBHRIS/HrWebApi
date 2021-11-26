using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.Menu.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysApiVoidService : ISysApiVoidService
    {
        private ISystem_View_SysApiVoid _system_View_SysApiVoid;
        private ISystem_View_SysPageApiVoid _system_View_SysPageApiVoid;
        private IMenu_View_GetMenu _Menu_View_GetMenu;

        public SysApiVoidService(ISystem_View_SysApiVoid system_View_SysApiVoid,
            ISystem_View_SysPageApiVoid system_View_SysPageApiVoid,
            IMenu_View_GetMenu Menu_View_GetMenu
            )
        {
            _system_View_SysPageApiVoid = system_View_SysPageApiVoid;
            _system_View_SysApiVoid = system_View_SysApiVoid;
            _Menu_View_GetMenu = Menu_View_GetMenu;
        }

        public ApiResult<string> DeleteApiVoidView(string Code)
        {
            _Menu_View_GetMenu.GetAllMenu().ForEach(m => 
            {
                SysPageApiVoidEntry sysPageApiVoidEntry = new SysPageApiVoidEntry()
                {
                    ApiVoidCode = Code,
                    PageCode = m.Code
                };
                _system_View_SysPageApiVoid.DeletePageApiVoidView(sysPageApiVoidEntry);
            });
            return _system_View_SysApiVoid.DeleteApiVoidView(Code);
        }

        public List<SysApiVoidDto> GetApiVoidView()
        {
            return _system_View_SysApiVoid.GetApiVoidView();
        }

        public ApiResult<string> InsertApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            return _system_View_SysApiVoid.InsertApiVoidView(sysApiVoidDto);
        }

        public ApiResult<string> UpdateApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            return _system_View_SysApiVoid.UpdateApiVoidView(sysApiVoidDto);
        }
    }
}
