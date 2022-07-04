using JBHRIS.Api.Dal.Menu.View;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;

namespace JBHRIS.Api.Dal.JBHR.Menu.View
{
    public class Menu_View_GetMenu : IMenu_View_GetMenu
    {
        private IUnitOfWork _unitOfWork;

        public Menu_View_GetMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<SysMenuDto> GetMenuIncludeRoot(string Code)
        {
            List<SysMenuDto> sysMenuDtos =  GetMenu(Code);
            var m = _unitOfWork.Repository<FileStructure>().Reads().Where(p => p.Code == Code).FirstOrDefault();
            sysMenuDtos.Add(new SysMenuDto()
            {
                Code = m.Code,
                SPath = m.SPath,
                SFileName = m.SFileName,
                SFileTitle = m.SFileTitle,
                SParentKey = m.SParentKey,
                SidePath = "",
                IconName = m.SIconName,
                Tag = m.NoticeContent,
                IOrder = m.IOrder,
                OpenNewWin = m.OpenNewWin,
                KeyMan = m.SKeyMan,
                KeyDate = m.DKeyDate,
            });
            return sysMenuDtos;
        }

        public List<SysMenuDto> GetMenu(string Code)
        {
            List<FileStructure> UnfoldTreeData = UnfoldTree(new List<FileStructure>(), Code);

            List<SysMenuDto> sysMenus = new List<SysMenuDto>();
            UnfoldTreeData.ForEach(m =>
            {
                sysMenus.Add(new SysMenuDto()
                {
                    Code = m.Code,
                    SPath = m.SPath,
                    SFileName = m.SFileName,
                    SFileTitle = m.SFileTitle,
                    SParentKey = m.SParentKey,
                    SidePath = "",
                    IconName = m.SIconName,
                    Tag = m.NoticeContent,
                    IOrder = m.IOrder,
                    OpenNewWin = m.OpenNewWin,
                    KeyMan = m.SKeyMan,
                    KeyDate = m.DKeyDate,
                });
            });
            sysMenus.ForEach(m => {  m.SidePath = repeatSite(sysMenus, m, ""); });
            return sysMenus;
        }

        public List<SysMenuDto> GetAllMenu()
        {
            List<SysMenuDto> sysMenus = _unitOfWork.Repository<FileStructure>().Reads()
                                        .Select(m=> new SysMenuDto()
                                        {
                                            Code = m.Code,
                                            SPath = m.SPath,
                                            SFileName = m.SFileName,
                                            SFileTitle = m.SFileTitle,
                                            SParentKey = m.SParentKey,
                                            SidePath = "",
                                            IconName = m.SIconName,
                                            Tag = m.NoticeContent,
                                            IOrder = m.IOrder,
                                            OpenNewWin = m.OpenNewWin,
                                            KeyMan = m.SKeyMan,
                                            KeyDate = m.DKeyDate,
                                        }).ToList();
            sysMenus.ForEach(m => { m.SidePath = repeatSite(sysMenus, m, ""); });
            return sysMenus;
        }

        private List<FileStructure> UnfoldTree(List<FileStructure> files, string Code)
        {
            var data = _unitOfWork.Repository<FileStructure>().Reads().Where(p => p.SParentKey == Code).ToList();
            data.ForEach(s => {
                files.Add(s);
                UnfoldTree(files, s.Code);
            });
            return files;
        }

        private static string repeatSite(List<SysMenuDto> listMenus, SysMenuDto r, string outPut)
        {
            IEnumerable<SysMenuDto> parentSql;
            parentSql = from listm in listMenus
                        where listm.Code == r.SParentKey
                        select listm;
            List<SysMenuDto> parents = parentSql.ToList();
            if (string.IsNullOrEmpty(outPut))
            {
                outPut = r.Code;
            }
            if (parents.Count > 0)
            {
                SysMenuDto p = parents[0];
                outPut = r.SParentKey + "/" + outPut;
                return repeatSite(listMenus, p, outPut);
            }
            else
            {
                return outPut;
            }
        }

        public bool InsertMenu(SysMenuDto sysMenuDto)
        {
            var menuRepo = _unitOfWork.Repository<FileStructure>();
            try
            {
                FileStructure fileStructure = new FileStructure()
                {
                     Code = sysMenuDto.Code,
                     SPath = sysMenuDto.SPath,
                     SFileName = sysMenuDto.SFileName,
                     SFileTitle = sysMenuDto.SFileTitle,
                     SDescription = sysMenuDto.Tag,
                     SParentKey = sysMenuDto.SParentKey,
                     IOrder = sysMenuDto.IOrder,
                     SKeyMan = sysMenuDto.KeyMan,
                     DKeyDate = DateTime.Now,
                     SIconPath = sysMenuDto.IconPath,
                     SIconName = sysMenuDto.IconName,
                     OpenNewWin = sysMenuDto.OpenNewWin,
                     NoticeContent = sysMenuDto.NoticeContent,
                     NoticeTitle = sysMenuDto.NoticeTitle,
                     DisplayNotice = sysMenuDto.DisplayNotice
                };
                menuRepo.Create(fileStructure);
                menuRepo.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMenu(SysMenuDto sysMenuDto)
        {
            var menuRepo = _unitOfWork.Repository<FileStructure>();
            var menuData = menuRepo.Read(p => p.Code == sysMenuDto.Code);
            if (menuData != null)
            {
                //menuData.Code = sysMenuDto.Code;
                menuData.SPath = sysMenuDto.SPath;
                menuData.SFileName = sysMenuDto.SFileName;
                menuData.SFileTitle = sysMenuDto.SFileTitle;
                menuData.SDescription = sysMenuDto.Tag;
                menuData.SParentKey = sysMenuDto.SParentKey;
                menuData.IOrder = sysMenuDto.IOrder;
                menuData.SKeyMan = sysMenuDto.KeyMan;
                menuData.DKeyDate = DateTime.Now;
                menuData.SIconPath = sysMenuDto.IconPath;
                menuData.SIconName = sysMenuDto.IconName;
                menuData.OpenNewWin = sysMenuDto.OpenNewWin;
                menuData.NoticeContent = sysMenuDto.NoticeContent;
                menuData.NoticeTitle = sysMenuDto.NoticeTitle;
                menuData.DisplayNotice = sysMenuDto.DisplayNotice;
                menuRepo.Update(menuData);
                menuRepo.SaveChanges();
                return true;
            }
            else return false;
        }

        public ApiResult<string> DeleteMenu(string code)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var menuRepo = _unitOfWork.Repository<FileStructure>();
            var haveUnder = menuRepo.Read(p => p.SParentKey == code);
            var menuData = menuRepo.Read(p => p.Code == code);
            if(menuData == null)
            {
                apiResult.Message = "沒有資料可以刪除";
            }else if (haveUnder != null)
            {
                apiResult.Message = "此節點底下有資料無法刪除";
            }
            else
            {
                menuRepo.Delete(menuData);
                menuRepo.SaveChanges();
            }
            if (menuData != null && haveUnder == null)
            {
                apiResult.State = true;
            }

            return apiResult;
        }
    }
}
