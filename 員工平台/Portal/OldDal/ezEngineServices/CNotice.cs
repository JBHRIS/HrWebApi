using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ezEngineServices
{
    public class CNotice
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public CNotice()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// CNotice
        /// </summary>
        /// <param name="conn"></param>
        public CNotice(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// CNotice
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CNotice(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CNotice(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="dDate">預設帶入今天所有生效的資料</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeData(DateTime? dDate = null)
        {
            dDate = dDate.GetValueOrDefault(DateTime.Now.Date);

            var rsNoticeSql = from c in dcFlow.Notice
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

            var rsFormUploadFile = (from c in dcFlow.wfFormUploadFile
                                    where (from n in rsNoticeSql where n.Guid == c.sKey select 1).Any()
                                    select new FileRow
                                    {
                                        Key = c.sKey,
                                        Name = c.sUpName,
                                        Size = c.iSize,
                                        Type = c.sType,
                                        Desc = c.sDescription,
                                        File = c.oBlob != null ? c.oBlob: null,
                                    }).ToList();

            var Vdb = rsNoticeSql.ToList();

            foreach (var rVdb in Vdb)
                rVdb.Files = rsFormUploadFile.Where(p => p.Key == rVdb.Guid).ToList();

            return Vdb;
        }

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeRow(string Guid)
        {
            var rsNoticeSql = from c in dcFlow.Notice
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

            var rsFormUploadFile = (from c in dcFlow.wfFormUploadFile
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
                rVdb.Files = rsFormUploadFile.Where(p => p.Key == rVdb.Guid).ToList();

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
                var rNotice = (from c in dcFlow.Notice
                               where c.sGuid == Row.Guid
                               select c).FirstOrDefault();

                if (rNotice == null)
                {
                    rNotice = new Notice();
                    rNotice.sGuid = Guid.NewGuid().ToString();
                    dcFlow.Notice.InsertOnSubmit(rNotice);
                }

                rNotice.sTitle = Row.Title;
                rNotice.sContent = Row.Content;
                rNotice.dDateA = Row.DateA;
                rNotice.dDateD = Row.DateD;
                rNotice.iSort = Row.Sort;
                rNotice.sKeyMan = Row.KeyMan;
                rNotice.dKeyDate = Row.KeyDate;

                dcFlow.SubmitChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>bool</returns>
        public bool Delete(string Guid)
        {
            var rNotice = (from c in dcFlow.Notice
                           where c.sGuid == Guid
                           select c).FirstOrDefault();

            dcFlow.Notice.DeleteOnSubmit(rNotice);
            dcFlow.SubmitChanges();

            return true;
        }
    }
}