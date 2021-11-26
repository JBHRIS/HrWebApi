using Bll.System.Vdb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dao.System
{
    public class SystemPageDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemPageDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemPageDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemPageDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemPageDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示檔案結構管理
        /// </summary>
        /// <param name = "Cond" ></ param >
        /// < returns > List SystemPageRow</returns>
        public List<SystemPageRow> GetSystemPage(SystemPageConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //主鍵
            var Key = Cond.Key;
            //所屬分類代碼
            var TypeCode = Cond.TypeCode;
            //父層級代碼
            var ParentCode = Cond.ParentCode;

            var VdbSql = (from c in dcShare.SystemPage
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((TypeCode.Length == 0) || (c.TypeCode == TypeCode))
                          && ((ParentCode.Length == 0) || (c.ParentCode == ParentCode))
                          orderby c.Sort
                          select new SystemPageRow
                          {
                              SystemCode = c.SystemCode,
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              TypeCode = c.TypeCode,
                              TypeName = "",
                              FilePath = c.FilePath,
                              FileName = c.FileName,
                              FileTitle = c.FileTitle,
                              RoleKey = c.RoleKey,
                              ParentCode = c.ParentCode,
                              Icon =c.Icon,
                              IsAuth = false,
                              Href = c.Href,
                              OpenWindow = c.OpenWindow,
                              PathCode = "",
                              PathName = "",
                              Sort = c.Sort,
                              Note = c.Note,
                              Status = c.Status,
                              InsertMan = c.InsertMan,
                              InsertDate = c.InsertDate.GetValueOrDefault(_DefDate),
                              UpdateMan = c.UpdateMan,
                              UpdateDate = c.UpdateDate.GetValueOrDefault(_DefDate),
                          });

            var Vdb = VdbSql.ToList();

            //處理代碼資料
            int i = 1;
            var rsColumnType = ShareCodeNameCode("PageType");
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;

                rVdb.TypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.TypeCode)?.Name ?? rVdb.TypeName;
            }

            SetPath(Vdb);

            //處理關聯資料

            return Vdb;
        }

        ///// <summary>
        /// 設定檔案結構管理組織
        /// </summary>
        /// <param name="ListSystemPage">檔案結構管理料表</param>
        public void SetPath(List<SystemPageRow> ListSystemPage)
        {
            string Code;
            SystemPageRow rSystemPage;
            int i;

            foreach (var rowSystemPage in ListSystemPage)
            {
                i = 0;
                Code = rowSystemPage.Code;

                do
                {
                    rSystemPage = ListSystemPage.FirstOrDefault(p => p.Code == Code);
                    if (rSystemPage != null)
                    {
                        rowSystemPage.PathCode = "/" + rSystemPage.Code + rowSystemPage.PathCode;
                        rowSystemPage.PathName = "/" + rSystemPage.Name + rowSystemPage.PathName;

                        if (Code == rSystemPage.ParentCode)
                            break;

                        Code = rSystemPage.ParentCode;
                    }

                    i++;
                } while (rSystemPage != null && Code.Length > 0 && i <= ListSystemPage.Count);

                rowSystemPage.PathCode += "/";
                rowSystemPage.PathName += "/";
            }
        }
    }
}