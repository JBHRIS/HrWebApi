using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Home;

namespace JBHRIS.Api.Dal.JBHR._System.View
{
    public class System_View_SysNews : ISystem_View_SysNews
    {
        private IUnitOfWork _unitOfWork;

        public System_View_SysNews(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<NewsDto> GetNews()
        {
            var data = _unitOfWork.Repository<News>().Reads()
                       .Select(p =>new NewsDto
                       {
                            IAutoKey = p.IAutoKey,
                            NewsId = p.NewsId,
                            NewsHead = p.NewsHead,
                            NewsBody = p.NewsBody,
                            PostDate = p.PostDate,
                            PostDeadline = p.PostDeadline,
                            IsOn = p.IsOn,
                            Newsfileid = p.Newsfileid,
                            Sort = p.Sort,
                            KeyMan = p.KeyMan
                       });

            return data.ToList();
        }

        public NewsDto GetNewsById(string id)
        {
            var data = _unitOfWork.Repository<News>().Reads()
                       .Where(p => p.IAutoKey.ToString() == id)
                       .Select(p => new NewsDto
                       {
                           IAutoKey = p.IAutoKey,
                           NewsId = p.NewsId,
                           NewsHead = p.NewsHead,
                           NewsBody = p.NewsBody,
                           PostDate = p.PostDate,
                           PostDeadline = p.PostDeadline,
                           IsOn = p.IsOn,
                           Newsfileid = p.Newsfileid,
                           Sort = p.Sort,
                           KeyMan = p.KeyMan
                       });

            return data.FirstOrDefault();
        }

        public bool InsertNewsBrowsing(NewsBrowsingDto newsBrowsingDto)
        {
            var newsBrowsingRepo = _unitOfWork.Repository<NewsBrowsing>();
            try
            {
                NewsBrowsing newsBrowsing = new NewsBrowsing()
                {
                    NewsId = newsBrowsingDto.NewsId,
                    BrowsingTime = newsBrowsingDto.BrowsingTime,
                    Nobr = newsBrowsingDto.Nobr
                };
                newsBrowsingRepo.Create(newsBrowsing);
                newsBrowsingRepo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertNews(NewsDto newsDto, string KeyMan)
        {
            var newsRepo = _unitOfWork.Repository<News>();
            try
            {
                News news = new News()
                {
                    NewsId  = newsDto.NewsId,
                    NewsHead =  newsDto.NewsHead,
                    NewsBody =  newsDto.NewsBody,
                    PostDate =  newsDto.PostDate,
                    PostDeadline =newsDto.PostDeadline,
                    IsOn = newsDto.IsOn,
                    Newsfileid =newsDto.Newsfileid,
                    Sort = newsDto.Sort,
                    LatestSendMailDate = null,
                    KeyDate = DateTime.Now,
                    KeyMan = KeyMan
                };
                newsRepo.Create(news);
                newsRepo.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateNews(NewsDto newsDto,string KeyMan)
        {
            var newsRepo = _unitOfWork.Repository<News>();
            var newsData = newsRepo.Read(p => p.IAutoKey == newsDto.IAutoKey);
            if (newsData != null)
            {
                newsData.NewsId = newsDto.NewsId;
                newsData.NewsHead = newsDto.NewsHead;
                newsData.NewsBody = newsDto.NewsBody;
                newsData.PostDate = newsDto.PostDate;
                newsData.PostDeadline = newsDto.PostDeadline;
                newsData.IsOn = newsDto.IsOn;
                newsData.Newsfileid = newsDto.Newsfileid;
                newsData.Sort = newsDto.Sort;
                newsData.KeyDate = DateTime.Now;
                newsData.KeyMan = KeyMan;

                newsRepo.Update(newsData);
                newsRepo.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool DeleteNewsById(string id)
        {
            var newsRepo = _unitOfWork.Repository<News>();
            var newsData = newsRepo.Read(p => p.IAutoKey.ToString() == id);
            if (newsData != null)
            {
                newsRepo.Delete(newsData);
                newsRepo.SaveChanges();
                return true;
            }
            else return false;
        }

        public List<NewsBrowsingDto> GetNewsBrowsing(string id)
        {
            var data = _unitOfWork.Repository<NewsBrowsing>().Reads()
                       .Where(p => p.NewsId == id)
                       .Select(p => new NewsBrowsingDto
                       {
                           NewsId = p.NewsId,
                           BrowsingTime = p.BrowsingTime,
                           Nobr = p.Nobr
                       });

            return data.ToList();
        }
    }
}
