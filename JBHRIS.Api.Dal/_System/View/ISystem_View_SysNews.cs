using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Home;
using JBHRIS.Api.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysNews
    {
        public List<NewsDto> GetNews();
        public NewsDto GetNewsById(string id);
        public bool InsertNews(NewsDto newsDto,string KeyMan);
        public List<NewsBrowsingDto> GetNewsBrowsing(string id);
        public bool InsertNewsBrowsing(NewsBrowsingDto newsBrowsingDto);
        public bool UpdateNews(NewsDto newsDto,string KeyMan);
        public bool DeleteNewsById(string NewsId);
    }
}
