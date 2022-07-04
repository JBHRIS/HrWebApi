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
    public class SysPageApiVoidService : ISysPageApiVoidService
    {
        private ISystem_View_SysPageApiVoid _system_View_SysPageApiVoid;
        private IMenu_View_GetMenu _menu_View_GetMenu;
        private ISystem_View_SysApiVoid _system_View_SysApiVoid;

        public SysPageApiVoidService(ISystem_View_SysPageApiVoid system_View_SysPageApiVoid,
            IMenu_View_GetMenu menu_View_GetMenu, 
            ISystem_View_SysApiVoid system_View_SysApiVoid
            )
        {
            _system_View_SysPageApiVoid = system_View_SysPageApiVoid;
            _menu_View_GetMenu = menu_View_GetMenu;
            _system_View_SysApiVoid = system_View_SysApiVoid;
        }

        public ApiResult<string> InsertPageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry, string KeyMan)
        {
            return _system_View_SysPageApiVoid.InsertPageApiVoidView(sysPageApiVoidEntry,KeyMan);
        }

        public ApiResult<string> DeletePageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry)
        {
            return _system_View_SysPageApiVoid.DeletePageApiVoidView(sysPageApiVoidEntry);
        }


        public List<SysPageToApiVoidDto> GetPageToApiVoidView()
        {
            var AllPage = _menu_View_GetMenu.GetAllMenu();
            List<SysPageToApiVoidDto> sysPageToApiVoidDtos = new List<SysPageToApiVoidDto>();
            AllPage.ForEach(p =>
            {
                var HaveApiVoid = new List<SysApiVoidDto>();
                var PageToRole = _system_View_SysPageApiVoid.GetPageApiVoidView(p.Code);
                var AllApiVoid = _system_View_SysApiVoid.GetApiVoidView();
                PageToRole.ForEach(pr =>
                {
                    var apivoid = AllApiVoid.FindIndex(v => v.Code == pr.ApiVoidCode);
                    if(apivoid >= 0)
                    {
                        HaveApiVoid.Add(AllApiVoid[apivoid]);
                    }
                });
                SysPageToApiVoidDto sysPageToApiVoidDto = new SysPageToApiVoidDto() { PageCode = p.Code, PageName = p.SFileTitle, HaveApiVoid = HaveApiVoid };
                sysPageToApiVoidDtos.Add(sysPageToApiVoidDto);
            });
            return sysPageToApiVoidDtos;
        }

    }
}
