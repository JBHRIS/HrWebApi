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
    public class SysRolePageService : ISysRolePageService
    {
        private ISystem_View_SysRolePage _system_View_SysRolePage;
        private ISystem_View_SysRole _system_View_SysRole;
        private IMenu_View_GetMenu _menu_View_GetMenu;
        public SysRolePageService(ISystem_View_SysRolePage system_View_SysRolePage,
            ISystem_View_SysRole system_View_SysRole,
            IMenu_View_GetMenu menu_View_GetMenu
            )
        {
            _system_View_SysRolePage = system_View_SysRolePage;
            _system_View_SysRole = system_View_SysRole;
            _menu_View_GetMenu = menu_View_GetMenu;
        }

        public ApiResult<string> InsertRolePageView(SysRolePageEntry sysRolePageEntry, string KeyMan)
        {
            return _system_View_SysRolePage.InsertRolePageView(sysRolePageEntry, KeyMan);
        }

        public ApiResult<string> DeleteRolePageView(SysRolePageEntry sysRolePageEntry)
        {
            return _system_View_SysRolePage.DeleteRolePageView(sysRolePageEntry);
        }

        public List<SysPageToRoleDto> GetPageToRoleView()
        {
            var AllPage = _menu_View_GetMenu.GetAllMenu();
            List<SysPageToRoleDto> sysPageToRoleDtos = new List<SysPageToRoleDto>();
            var AllRole = _system_View_SysRole.GetRoleView();
            AllPage.ForEach(p =>
            {
                var HaveRole = new List<SysRoleDto>();
                var PageToRole = _system_View_SysRolePage.GetPageToRoleView(p.Code);
                PageToRole.ForEach(pr =>
                {
                    var role = AllRole.FindIndex(r => r.Code == pr.RoleCode);
                    HaveRole.Add(AllRole[role]);
                });
                SysPageToRoleDto sysPageToRoleDto = new SysPageToRoleDto() {PageCode = p.Code, PageName = p.SFileTitle,HaveRole = HaveRole };
                sysPageToRoleDtos.Add(sysPageToRoleDto);
            });
            return sysPageToRoleDtos;
        }

        public List<SysRoleToPageDto> GetRoleToPageView()
        {
            var AllPage = _menu_View_GetMenu.GetAllMenu();
            List<SysRoleToPageDto> sysRoleToPageDtos = new List<SysRoleToPageDto>();
            var AllRole = _system_View_SysRole.GetRoleView();
            AllRole.ForEach(r =>
            {
                var HavePage = new List<SysMenuDto>();
                var RoleToPage = _system_View_SysRolePage.GetRoleToPageView(r.Code);
                RoleToPage.ForEach(
                    rp => 
                    { 
                        var page = AllPage.FindIndex(p => p.Code == rp.PageCode);
                        HavePage.Add(AllPage[page]);
                    });

                SysRoleToPageDto sysRoleToPageDto = new SysRoleToPageDto() { RoleCode = r.Code, RoleName = r.Name ,HavePage = HavePage };
                sysRoleToPageDtos.Add(sysRoleToPageDto);
            });
            return sysRoleToPageDtos;
        }

    }
}
