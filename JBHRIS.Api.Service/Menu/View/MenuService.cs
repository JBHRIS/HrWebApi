using JBHRIS.Api.Dal.Menu.View;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;

namespace JBHRIS.Api.Service.Menu.View
{
    public class MenuService : IMenuService
    {
        IMenu_View_GetMenu _Menu_View_GetMenu;
        private ISystem_View_SysUserRole _system_View_SysUserRole;
        private ISystem_View_SysRolePage _system_View_SysRolePage;
        private ISystem_View_SysRole _system_View_SysRole;

        public MenuService(IMenu_View_GetMenu Menu_View_GetMenu,
            ISystem_View_SysUserRole system_View_SysUserRole,
            ISystem_View_SysRolePage system_View_SysRolePage,
            ISystem_View_SysRole system_View_SysRole) 
        {
            _Menu_View_GetMenu = Menu_View_GetMenu;
            _system_View_SysUserRole = system_View_SysUserRole;
            _system_View_SysRolePage = system_View_SysRolePage;
            _system_View_SysRole = system_View_SysRole;
        }

        public List<SysMenuDto> GetFeatures(string code, string keyword, string Nobr)
        {
            var menu = _Menu_View_GetMenu.GetMenu(code);
            List<SysMenuDto> Features = new List<SysMenuDto>();
            if (!string.IsNullOrEmpty(keyword)) 
            {
                menu.ForEach(m => {
                    if (IsIncludeKeyword(new List<string>() { "SFileTitle", "Tag" }, m, keyword))
                    {
                        Features.Add(m);
                    }
                });
            }

            List<string> nobr = new List<string>() { Nobr };
            List<SysMenuDto> outputMenu = new List<SysMenuDto>();
            List<SysUserRoleDto> roleList = _system_View_SysUserRole.GetUserRoleView(nobr);
            List<SysRolePageDto> pageList = new List<SysRolePageDto>();
            roleList[0].RoleCode.ForEach(r => {
                _system_View_SysRolePage.GetRoleToPageView(r).ForEach(p => {
                    pageList.Add(p);
                });
            });
            Features.ForEach(m => {
                bool check = pageList.Exists(p => p.PageCode == m.Code);
                if (check) outputMenu.Add(m);
            });
            return outputMenu;
        }

        /// <summary>
        /// 物件中的屬性值是否包含keyword
        /// </summary>
        /// <param name="listVal">物件屬性</param>
        /// <param name="keyValue">物件</param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private bool IsIncludeKeyword(List<string> listVal, object keyValue,string keyword)
        {
            bool addtrue = false;

            listVal.ForEach(v => {
                Dictionary<string, object> dict = keyValue.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(keyValue, null));

                foreach (var p in dict)
                {
                    if (p.Key == v)
                    {
                        if (p.Value != null)
                        {
                            if (p.Value.ToString().Contains(keyword))
                            {
                                addtrue = true;
                            }
                        }
                    }
                }
            });
            return addtrue;
        }

        public List<SysMenuDto> GetMenu(string Code, string Nobr)
        {
            List<string> nobr = new List<string>() { Nobr };
            List<SysMenuDto> outputMenu = new List<SysMenuDto>();
            List<SysMenuDto> menu = _Menu_View_GetMenu.GetMenu(Code);
            List<SysUserRoleDto> roleList = _system_View_SysUserRole.GetUserRoleView(nobr);
            List<SysRolePageDto> pageList = new List<SysRolePageDto>();
            roleList[0].RoleCode.ForEach(r => {
                _system_View_SysRolePage.GetRoleToPageView(r).ForEach(p => {
                    pageList.Add(p);
                });
            });
            menu.ForEach(m => { 
                bool check = pageList.Exists(p => p.PageCode == m.Code);
                if (check) outputMenu.Add(m);
            });
            return outputMenu;
        }

        public bool InsertMenu(SysMenuDto sysMenuDto)
        {
            return _Menu_View_GetMenu.InsertMenu(sysMenuDto);
        }

        public bool UpdateMenu(SysMenuDto sysMenuDto)
        {
            return _Menu_View_GetMenu.UpdateMenu(sysMenuDto);
        }

        public ApiResult<string> DeleteMenu(string code)
        {
            List<SysRoleDto> allRole = _system_View_SysRole.GetRoleView();
            allRole.ForEach(r =>
            {
                SysRolePageEntry sysRolePageEntry = new SysRolePageEntry()
                {
                    RoleCode = r.Code,
                    PageCode = code,
                };
                _system_View_SysRolePage.DeleteRolePageView(sysRolePageEntry);
            });
            return _Menu_View_GetMenu.DeleteMenu(code);
        }

        public List<SysMenuDto> GetAllMenu(string Code)
        {
            return _Menu_View_GetMenu.GetMenuIncludeRoot(Code);
        }

        public List<SysMenuDto> GetIndexFeatures(string Nobr)
        {
            List<SysUserRoleDto>  sysUserRoleDtos =_system_View_SysUserRole.GetUserRoleView(new List<string>() { Nobr });
            SysUserRoleDto sysUserRoleDto = sysUserRoleDtos.Where(p => p.Nobr == Nobr).FirstOrDefault();
            List<SysMenuDto> sysMenuDtos = new List<SysMenuDto>();
            sysUserRoleDto.RoleCode.ForEach(r => {
                sysMenuDtos.AddRange(_Menu_View_GetMenu.GetMenu(r));
            });

            var filter = sysMenuDtos.GroupBy(o => o.SFileName).ToDictionary(o => o.Key, o => o.ToList());
            List<SysMenuDto> filterMenu = filter.Select(d => d.Value.FirstOrDefault()).ToList();

            return filterMenu;
        }
    }
}
