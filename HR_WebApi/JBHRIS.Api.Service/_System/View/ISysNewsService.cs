using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Home;
using JBHRIS.Api.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysNewsService
    {
        public List<BillboardDto> GetBillboards();
        public BillboardDetailDto GetBillboardsById(string id);
        public List<NewsDto> GetNews();
        public NewsDto GetNewsById(string id);
        public bool InsertNews(NewsDto newsDto, string KeyMan);
        public bool UpdateNews(NewsDto newsDto, string KeyMan);
        public bool DeleteNewsById(string id);
    }
}
