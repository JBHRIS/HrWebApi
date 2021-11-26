using Bll;
using Bll.Dept.Vdb;
using Bll.Performance.Vdb;
using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace Dal.Dao
{
    /// <summary>
    /// 
    /// </summary>
    public class PerformanceDao
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime MinDate = new DateTime(1900, 1, 1).Date;
        public DateTime MaxDate = new DateTime(1900, 1, 1).Date;
        public DateTime NowDate = DateTime.Now.Date;

        public string _SystemCode = "Performance";

        /// <summary>
        /// 
        /// </summary>
        public dcShareDataContext dcShare;
        public dcPerformanceDataContext dcPerformance;
        public dcHrDataContext dcHr;

        /// <summary>
        /// 
        /// </summary>
        public PerformanceDao()
        {
            dcShare = new dcShareDataContext();
            dcPerformance = new dcPerformanceDataContext();
            dcHr = new dcHrDataContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public PerformanceDao(IDbConnection connShare, IDbConnection connPerformance, IDbConnection connHr)
        {
            dcShare = new dcShareDataContext(connShare);
            dcPerformance = new dcPerformanceDataContext(connPerformance);
            dcHr = new dcHrDataContext(connHr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public PerformanceDao(string ConnectionStringShare, string ConnectionStringPerformance, string ConnectionStringHr)
        {
            dcShare = new dcShareDataContext(ConnectionStringShare);
            dcPerformance = new dcPerformanceDataContext(ConnectionStringPerformance);
            dcHr = new dcHrDataContext(ConnectionStringHr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcPerformance"></param>
        public PerformanceDao(dcShareDataContext dcShare, dcPerformanceDataContext dcPerformance, dcHrDataContext dcHr)
        {
            this.dcShare = dcShare;
            this.dcPerformance = dcPerformance;
            this.dcHr = dcHr;
        }
        /// <summary>
        /// 取得考核年月
        /// </summary>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetYymm(string TypeCode)
        {
            //var rsView = new List<TextValueRow>();

            //if (TypeCode == "01" || TypeCode == "02")
            //{
            //    var rs = dcPerformance.BONUS.Select(p => p.YYMM).Distinct().ToList();
            //    rsView = (from c in rs
            //              orderby c descending
            //              select new TextValueRow
            //              {
            //                  Text = c,
            //                  Value = c,
            //              }).ToList();
            //}
            //else if (TypeCode == "03")
            //{
            //    var rs = dcPerformance.GETMERTAMT.Select(p => p.YYMM).Distinct().ToList();
            //    rsView = (from c in rs
            //              orderby c descending
            //              select new TextValueRow
            //              {
            //                  Text = c,
            //                  Value = c,
            //              }).ToList();
            //}
            //else if (TypeCode == "04")
            //{
            //    var rs = dcPerformance.EFFAVERAGE.Select(p => p.YEAR).Distinct().ToList();
            //    rsView = (from c in rs
            //              orderby c descending
            //              select new TextValueRow
            //              {
            //                  Text = c.ToString(),
            //                  Value = c.ToString(),
            //              }).ToList();
            //}

            var rsView = new List<TextValueRow>();
            var rView = new TextValueRow();
            rView.Text = "202009";
            rView.Value = "202009";
            rsView.Add(rView);
            rView = new TextValueRow();
            rView.Text = "202010";
            rView.Value = "202010";
            rsView.Add(rView);
            rView = new TextValueRow();
            rView.Text = "202011";
            rView.Value = "202011";
            rsView.Add(rView);

            return rsView;
        }

        /// <summary>
        /// 取得考核的年月期別
        /// </summary>
        /// <param name="TypeCode">考核類別</param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetPerformanceMain(string TypeCode)
        {
            var rs = (from c in dcPerformance.PerformanceMain
                      where c.DateA <= NowDate
                      && NowDate <= c.DateD
                      //&& c.TypeCode == TypeCode
                      orderby c.Yymm descending, c.EmpCategoryCode, c.Seq
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Yymm + "," + c.EmpCategoryCode + ")",
                          Value = c.Code,
                      }).ToList();

            return rs;
        }

        /// <summary>
        /// 取得考核的年月期別
        /// </summary>
        /// <param name="ListTypeCode">考核類別</param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetPerformanceMainCode(List<string> ListTypeCode)
        {
            var rs = (from c in dcPerformance.PerformanceMain
                      where c.DateA <= NowDate
                      && NowDate <= c.DateD
                      && ListTypeCode.Contains(c.TypeCode)
                      orderby c.Yymm descending, c.EmpCategoryCode, c.Seq
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Yymm + "," + c.EmpCategoryCode + ")",
                          Value = c.Code,
                      }).ToList();

            return rs;
        }

        /// <summary>
        /// 取得考核的年月期別
        /// </summary>
        /// <param name="TypeCode">考核類別</param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetPerformanceMain()
        {
            var rs = (from c in dcPerformance.PerformanceMain
                      orderby c.Yymm descending, c.EmpCategoryCode, c.Seq
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Yymm + "," + c.EmpCategoryCode + ")",
                          Value = c.Code,
                      }).ToList();

            return rs;
        }

        /// <summary>
        /// 取得評等代碼資料
        /// </summary>
        /// <param name="EmpCategoryCode">員工類別</param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetPerformanceRating(string EmpCategoryCode)
        {
            var rs = (from c in dcPerformance.PerformanceRating
                      where c.EmpCategoryCode == EmpCategoryCode
                      orderby c.Sort
                      select new TextValueRow
                      {
                          Text = c.Name,
                          Value = c.Code,
                      }).ToList();

            return rs;
        }

        /// <summary>
        /// 計算可扣獎金
        /// </summary>
        /// <param name="BonusCardinal">基底獎金</param>
        /// <param name="BonusPerMin">可扣百分比</param>
        /// <returns>decimal</returns>
        public decimal CalculationBonusDeduct(decimal BonusCardinal, int BonusPerMin)
        {
            //var Vdb = Math.Round(BonusCardinal * BonusPerMin / 100M) - BonusCardinal;
            var Vdb = Math.Round(BonusCardinal * BonusPerMin / 100M);
            return Vdb;
        }

        /// <summary>
        /// 計算最大可發獎金
        /// </summary>
        /// <param name="BonusCardinal">基底獎金</param>
        /// <param name="BonusPerMax">可發百分比</param>
        /// <returns>decimal</returns>
        public decimal CalculationBonusMax(decimal BonusCardinal, int BonusPerMax)
        {
            var Vdb = Math.Round(BonusCardinal * BonusPerMax / 100M);
            return Vdb;
        }


        /// <summary>
        /// 取得部門階層
        /// </summary>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetDeptLevel(int DeptTree = 999)
        {
            var Vdb = (from c in dcHr.ViewDeptTree
                       orderby c.Code 
                       select new TextValueRow
                       {
                           Text = c.Name + "(" + c.Code + ")",
                           Value = c.Code,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得HR系統的編制部門資料
        /// </summary>
        /// <param name="DateBase">產生基準日</param>
        /// <param name="DeptTree">產生部門層級</param>
        /// <returns>List DeptRow</returns>
        public List<DeptRow> GetDept(DateTime DateBase, int DeptTree = 70)
        {
            var Vdb = (from c in dcHr.ViewDept
                       select new DeptRow
                       {
                           Code = c.Code,
                           DisplayCode = c.Code,
                           Name = c.Name,
                           ParentCode = c.ParentCode,
                           DeptTree = Convert.ToInt32(c.DeptTree),
                           ManagerId = c.ManagerEmpId,
                           Mail = "",
                           ParentManagerId = "",
                           PathCode = "",
                           PathName = "",
                       }).ToList();

            var rsBase = (from c in dcHr.ViewEmp
                          select c).ToList();

            //重新填入部門主管
            foreach (var rVdb in Vdb)
            {
                rVdb.Mail = rsBase.FirstOrDefault(p => p.Code == rVdb.ManagerId)?.Email ?? "";

                rVdb.ManagerId = GetManagerId(Vdb, rVdb.Code, "");
                rVdb.ParentManagerId = GetManagerId(Vdb, rVdb.ParentCode, rVdb.ManagerId);
            }

            //填入部門Path
            SetDeptPath(Vdb);

            return Vdb;
        }

        /// <summary>
        /// 取得HR系統的簽核部門資料
        /// </summary>
        /// <param name="DateBase">產生基準日</param>
        /// <param name="DeptTree">產生部門層級</param>
        /// <returns>List DeptRow</returns>
        public List<DeptRow> GetDepta(DateTime DateBase, int DeptTree = 70)
        {
            var Vdb = (from c in dcHr.ViewDepta
                       select new DeptRow
                       {
                           Code = c.Code,
                           DisplayCode = c.Code,
                           Name = c.Name,
                           ParentCode = c.ParentCode,
                           DeptTree = Convert.ToInt32(c.DeptTree),
                           ManagerId = c.ManagerEmpId ?? "",
                           Mail = "",
                           ParentManagerId = "",
                           PathCode = "",
                           PathName = "",
                       }).ToList();

            var rsBase = (from c in dcHr.ViewEmp
                          select c).ToList();

            //重新填入部門主管
            foreach (var rVdb in Vdb)
            {
                rVdb.Mail = rsBase.FirstOrDefault(p => p.Code == rVdb.ManagerId)?.Email ?? "";

                rVdb.ManagerId = GetManagerId(Vdb, rVdb.Code, "");
                rVdb.ParentManagerId = GetManagerId(Vdb, rVdb.ParentCode, rVdb.ManagerId);
            }

            //填入部門Path
            SetDeptPath(Vdb);

            return Vdb;
        }

        /// <summary>
        /// 尋找部門主管
        /// </summary>
        /// <param name="ListDept">編制或簽核部門</param>
        /// <param name="SearchDeptCode">尋找部門</param>
        /// <param name="SearchEmpId">尋找工號(如果不希望本層主管審核 可以填入本層主管自己工號)</param>
        /// <param name="SearchDeptTree">尋找層級</param>
        /// <param name="TopDeptTree">最上層部門</param>
        /// <returns>string</returns>
        public string GetManagerId(List<DeptRow> ListDept, string SearchDeptCode, string SearchEmpId, int SearchDeptTree = 0, int TopDeptTree = 99)
        {
            string Value = "";

            int i = 0;

            do
            {
                i++;

                var rDept = ListDept.FirstOrDefault(p => p.Code == SearchDeptCode);
                if (rDept == null)
                    break;

                //上層部門跟本層相同也直接出去
                if (SearchDeptCode == rDept.ParentCode)
                    break;

                SearchDeptCode = rDept.ParentCode;
                int NowTree = rDept.DeptTree;

                //如果有部門主管 且不是自已 且部門層級大於要尋找的層級
                if (rDept.ManagerId.Length > 0 && rDept.ManagerId != SearchEmpId && NowTree >= SearchDeptTree)
                    Value = rDept.ManagerId;

                //找到了就應該要離開了
                if (Value.Length > 0)
                    break;

                //上層部門空白也不用找了
                if (rDept.ParentCode.Trim().Length == 0)
                    break;

                //超過部門上限也該離開了
                if (NowTree >= TopDeptTree)
                    break;

            } while (true && i < 10);

            return Value;
        }

        /// <summary>
        /// 尋找部門
        /// </summary>
        /// <param name="ListDept">編制或簽核部門</param>
        /// <param name="SearchDeptCode">尋找部門</param>
        /// <param name="SearchEmpId">尋找工號(如果不希望本層主管審核 可以填入本層主管自己工號)</param>
        /// <param name="SearchDeptTree">尋找層級</param>
        /// <param name="TopDeptTree">最上層部門</param>
        /// <returns>string</returns>
        public string GetDeptCode(List<DeptRow> ListDept, string SearchDeptCode, int SearchDeptTree = 0, int TopDeptTree = 99)
        {
            string Value = "";

            int i = 0;

            do
            {
                i++;

                var rDept = ListDept.FirstOrDefault(p => p.Code == SearchDeptCode);
                if (rDept == null)
                    break;

                //上層部門跟本層相同也直接出去
                if (SearchDeptCode == rDept.ParentCode)
                    break;

                SearchDeptCode = rDept.ParentCode;
                int NowTree = rDept.DeptTree;

                //部門層級大於要尋找的層級
                if (NowTree >= SearchDeptTree)
                    Value = rDept.Code;

                //找到了就應該要離開了
                if (Value.Length > 0)
                    break;

                //上層部門空白也不用找了
                if (rDept.ParentCode.Trim().Length == 0)
                    break;

                //超過部門上限也該離開了
                if (NowTree >= TopDeptTree)
                    break;

            } while (true && i < 10);

            return Value;
        }

        /// <summary>
        /// 設定部門組織(僅限Dept,Deptm使用)
        /// </summary>
        /// <param name="ListDept">部門資料表</param>
        public void SetDeptPath(List<DeptRow> ListDept)
        {
            string Dept;
            DeptRow rDept;
            int i;

            foreach (var r in ListDept)
            {
                i = 0;
                Dept = r.Code;

                do
                {
                    rDept = ListDept.Where(p => p.Code == Dept).FirstOrDefault();
                    if (rDept != null)
                    {
                        r.PathCode = "/" + rDept.Code + r.PathCode;
                        r.PathName = "/" + rDept.Name + r.PathName;

                        if (Dept == rDept.ParentCode)
                            break;

                        Dept = rDept.ParentCode;
                    }

                    i++;
                } while (rDept != null && Dept.Trim().Length > 0 && i <= ListDept.Count);

                r.PathCode += "/";
                r.PathName += "/";
            }
        }

        /// <summary>
        /// 輸出郵件主旨及內容
        /// </summary>
        /// <param name="Subject">主旨</param>
        /// <param name="Body">內容</param>
        /// <param name="AutoKey">樣版AutoKey</param>
        /// <param name="RowIndex">顯示第幾列</param>
        /// <param name="Where">需要條件</param>
        /// <param name="dcParameter">參數代碼</param>
        /// <param name="Parm">驗証資訊</param>
        public void OutMailContent(out string Subject, out string Body, int AutoKey, int RowIndex = 0, bool Where = false, Dictionary<string, string> dcParameter = null, string Parm = "")
        {
            var r = dcShare.ShareMailTpl.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (r == null)
            {
                Subject = "";
                Body = "";
                return;
            }

            Subject = r.Subject;
            Body = r.Body;

            var sqlString = r.Statement;

            List<SqlParameter> ListParameter = null;
            if (dcParameter != null)
            {
                ListParameter = new List<SqlParameter>();
                foreach (var dc in dcParameter)
                    ListParameter.Add(new SqlParameter(("@" + dc.Key), dc.Value));
            }

            if (!Where)
                sqlString = sqlString.Substring(0, r.Statement.ToUpper().IndexOf("WHERE 1 = 1"));

            SqlConnection conn = new SqlConnection(dcPerformance.Connection.ConnectionString);
            var dt = SqlTools.GetSqlDataTable(conn, sqlString, ListParameter);

            if (dt.Rows.Count >= (RowIndex + 1))
            {
                var row = dt.Rows[RowIndex];

                foreach (DataColumn dc in dt.Columns)
                {
                    var ColumnName = dc.ColumnName;
                    var Column = "{" + ColumnName + "}";

                    if (Subject.IndexOf(Column) >= 0)
                    {
                        var Value = row[ColumnName].ToString();
                        Subject = Subject.Replace(Column, Value);
                    }

                    if (Body.IndexOf(Column) >= 0)
                    {
                        var Value = row[ColumnName].ToString();
                        Body = Body.Replace(Column, Value);
                    }
                }

                //特別定義的變數
                var oMain = new MainDao(dcShare);
                var rsShareCode = oMain.ShareCodeNameCode("MailVarDefine");

                foreach (var rShareCode in rsShareCode)
                {
                    var ColumnName = rShareCode.Code;
                    var Column = "{" + ColumnName + "}";

                    var Value = GetMailVarDefine(ColumnName, Parm);

                    if (Subject.IndexOf(Column) >= 0)
                        Subject = Subject.Replace(Column, Value);

                    if (Body.IndexOf(Column) >= 0)
                        Body = Body.Replace(Column, Value);
                }
            }
        }

        /// <summary>
        /// 取得系統共用參數
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string GetMailVarDefine(string Code, string Parm = "")
        {
            var Vdb = "";

            switch (Code)
            {
                case "NowDate":
                    Vdb = DateTime.Now.ToShortDateString();
                    break;
                case "NowDateTime":
                    Vdb = DateTime.Now.ToString();
                    break;
                case "LgoinUrl":
                    {
                        var oShareDefault = new ShareDefaultDao(dcShare);
                        var r = oShareDefault.DefaultSystem;
                        var req = HttpContext.Current.Request;
                        var Path = req.Url.Scheme + "://" + req.Url.Host + ":" + req.Url.Port + req.Url.Segments[0] + req.Url.Segments[1];
                        Vdb = Path + r.LoginPage;
                    }
                    break;
                case "MainUrl":
                case "MainValidUrl":
                    {
                        var oShareDefault = new ShareDefaultDao(dcShare);
                        var r = oShareDefault.DefaultSystem;
                        var req = HttpContext.Current.Request;
                        var Path = req.Url.Scheme + "://" + req.Url.Host + ":" + req.Url.Port + req.Url.Segments[0] + req.Url.Segments[1];
                        Vdb = Path + r.MainPage;

                        Parm = "?Parm=" + Parm;
                        //不給驗証
                        if (Code == "ManinUrl")
                            Parm = "";

                        Vdb = Path + r.MainPage + Parm;
                    }
                    break;
            }

            return Vdb;
        }
    }
}