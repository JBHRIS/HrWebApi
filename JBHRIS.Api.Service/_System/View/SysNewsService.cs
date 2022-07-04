using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Home;
using JBHRIS.Api.Home;
using JBHRIS.Api.Service.Employee.Normal;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysNewsService : ISysNewsService
    {
        private ISystem_View_SysNews _system_View_SysNews;
        private IEmployeeInfoService _employeeService;

        public SysNewsService(ISystem_View_SysNews system_View_SysNews, IEmployeeInfoService employeeService)
        {
            _system_View_SysNews = system_View_SysNews;
            _employeeService = employeeService;
        }

        public List<BillboardDto> GetBillboards()
        {
            var data = _system_View_SysNews.GetNews();
            List<BillboardDto> billboardDtos = new List<BillboardDto>();
            data.ForEach(p=> {
                DateTime today = DateTime.Today;
                if (p.PostDeadline.Date >= today && p.PostDate.Date <= today && p.IsOn)
                {
                    List<string> employeeList = new List<string>() { p.KeyMan };
                    billboardDtos.Add(
                        new BillboardDto()
                        {
                            IAutoKey = p.IAutoKey,
                            NewsId = p.NewsId,
                            NewsHead = p.NewsHead,
                            NewsBody = p.NewsBody,
                            PostDate = p.PostDate,
                            BrowseCount = 0,
                            FileCount = 0,
                            Sort = p.Sort,
                            KeyMan = _employeeService.GetEmployeeInfo(employeeList)[0].NameC
                        }
                    );
                }
            });
            return billboardDtos;
        }

        public BillboardDetailDto GetBillboardsById(string id)
        {
            var data = _system_View_SysNews.GetNewsById(id);
            List<string> employeeList = new List<string>() { data.KeyMan };
            NewsBrowsingDto newsBrowsingDto = new NewsBrowsingDto()
            {
                NewsId = id,
                BrowsingTime = DateTime.Now,
                Nobr = ""
            };
            _system_View_SysNews.InsertNewsBrowsing(newsBrowsingDto);

            int BrowseCount = 0;
            BrowseCount = _system_View_SysNews.GetNewsBrowsing(id).Count;

            BillboardDetailDto billboardDetailDto = new BillboardDetailDto() 
            {
                IAutoKey = data.IAutoKey,
                NewsId = data.NewsId,
                NewsHead = data.NewsHead,
                NewsBody = data.NewsBody,
                PostDate = data.PostDate,
                BrowseCount = BrowseCount,
                FileCount = 0,
                Newsfileid = data.Newsfileid,
                KeyMan = _employeeService.GetEmployeeInfo(employeeList)[0].NameC
            };
            return billboardDetailDto;
        }

        public List<NewsDto> GetNews()
        {
            return _system_View_SysNews.GetNews();
        }

        public NewsDto GetNewsById(string id)
        {
            return _system_View_SysNews.GetNewsById(id);
        }

        public bool InsertNews(NewsDto newsDto, string KeyMan)
        {
            return _system_View_SysNews.InsertNews(newsDto, KeyMan);
        }

        public bool UpdateNews(NewsDto newsDto,string KeyMan)
        {
            return _system_View_SysNews.UpdateNews(newsDto, KeyMan);
        }

        public bool DeleteNewsById(string id)
        {
            return _system_View_SysNews.DeleteNewsById(id);
        }
    }
}
