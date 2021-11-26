using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dto.Vdb;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezFlow.ezEngineServicesImplement
{
    /// <summary>
    /// 2021/02/03 這已完成 沒有重複注入
    /// </summary>
    public class CNotice : ICNoticeInterface
    {

        private ezFlowContext _context;

        public CNotice(ezFlowContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>bool</returns>
        public bool DeleteNotice(string Guid)
        {
            var rNotice = (from c in this._context.Notices
                           where c.sGuid == Guid
                           select c).FirstOrDefault();

            this._context.Notices.Remove(rNotice);
            this._context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="dDate">預設帶入今天所有生效的資料</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeData(DateTime? dDate = null)
        {
            dDate = dDate.GetValueOrDefault(DateTime.Now.Date);

            var rsNoticeSql = from c in this._context.Notices
                              where c.dDateA.Date <= dDate.Value && dDate.Value <= c.dDateD.Date
                              orderby c.iSort, c.dKeyDate
                              select new NoticeRow
                              {
                                  Guid = c.sGuid,
                                  Title = c.sTitle,
                                  Content = c.sContent,
                                  DateA = c.dDateA,
                                  DateD = c.dDateD,
                                  Sort = c.iSort,
                                  KeyMan = c.sKeyMan,
                                  KeyDate = c.dKeyDate,
                              };
            var rsFormUploadFile = (from c in this._context.wfFormUploadFiles
                                    where (from n in rsNoticeSql where n.Guid == c.sKey select 1).Any()
                                    select new FileRow
                                    {
                                        Key = c.sKey,
                                        Name = c.sUpName,
                                        Size = c.iSize,
                                        Type = c.sType,
                                        Desc = c.sDescription,
                                        File = c.oBlob != null ? c.oBlob : null,
                                    }).ToList();
            var Vdb = rsNoticeSql.ToList();
            foreach (var rVdb in Vdb)
            {

                rVdb.Files = rsFormUploadFile.Where(p => p.Key == rVdb.Guid).ToList();
            }
            return Vdb;
        }

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeRow(string Guid)
        {
            var rsNoticeSql = from c in this._context.Notices
                              where c.sGuid == Guid
                              orderby c.iSort, c.dKeyDate
                              select new NoticeRow
                              {
                                  Guid = c.sGuid,
                                  Title = c.sTitle,
                                  Content = c.sContent,
                                  DateA = c.dDateA,
                                  DateD = c.dDateD,
                                  Sort = c.iSort,
                                  KeyMan = c.sKeyMan,
                                  KeyDate = c.dKeyDate,
                              };

            var rsFormUploadFile = (from c in this._context.wfFormUploadFiles
                                    where (from n in rsNoticeSql where n.Guid == c.sKey select 1).Any()
                                    select new FileRow
                                    {
                                        Key = c.sKey,
                                        Name = c.sUpName,
                                        Size = c.iSize,
                                        Type = c.sType,
                                        Desc = c.sDescription,
                                        File = c.oBlob ?? null,
                                    }).ToList();

            var Vdb = rsNoticeSql.ToList();

            foreach (var rVdb in Vdb)
            {
                rVdb.Files = rsFormUploadFile.Where(p => p.Key == rVdb.Guid).ToList();
            }
            return Vdb;
        }


        /// <summary>
        /// 存入公告
        /// </summary>
        /// <param name="Row">NoticeRow資料列</param>
        /// <returns>bool</returns>
        public bool Save(NoticeRow Row)
        {
            if (Row != null)
            {
                var rNotice = (from c in this._context.Notices
                               where c.sGuid == Row.Guid
                               select c).FirstOrDefault();

                if (rNotice == null)
                {
                    rNotice = new Notice();
                    rNotice.sGuid = Guid.NewGuid().ToString();
                    this._context.Notices.Add(rNotice);
                }

                rNotice.sTitle = Row.Title;
                rNotice.sContent = Row.Content;
                rNotice.dDateA = Row.DateA;
                rNotice.dDateD = Row.DateD;
                rNotice.iSort = Row.Sort;
                rNotice.sKeyMan = Row.KeyMan;
                rNotice.dKeyDate = Row.KeyDate;

                this._context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
