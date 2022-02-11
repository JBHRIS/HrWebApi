using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;
using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal.Dao.Share;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using Bll.Tools;

namespace Dal.Dao.Share
{
    public class ShareMailDao
    {

        public dcShareDataContext dcShare;

        public ShareMailDao()
        {
            dcShare = new dcShareDataContext();
           
        }
        /// <summary>
        /// 輸出郵件主旨及內容
        /// </summary>
        /// <param name="Subject">主旨</param>
        /// <param name="Body">內容</param>
        /// <param name="Code">樣版AutoKey</param>
        /// <param name="RowIndex">顯示第幾列</param>
        /// <param name="Where">需要條件</param>
        /// <param name="dcParameter">參數代碼</param>
        /// <param name="Parm">驗証資訊</param>
        public void OutMailContent(out string Subject, out string Body, string Code, int RowIndex = 0, bool Where = false, Dictionary<string, string> dcParameter = null, string Parm = "")
        {

            var rsMailTpl = dcShare.ShareMailTpl.Where(p => p.Key1=="Reply").ToList();
            var r = rsMailTpl.FirstOrDefault(p => p.Code == Code);
          
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

            //if (!Where)
            //    sqlString = sqlString.Substring(0, r.Statement.ToUpper().IndexOf("WHERE 1 = 1"));

            SqlConnection conn = new SqlConnection(dcShare.Connection.ConnectionString);
            var dt = SqlTools.GetSqlDataTable(conn, sqlString, ListParameter);
            string QuestionCode = "";
            string InsertManAccountCode="";
            if (dt.Rows.Count >= (RowIndex + 1))
            {
                var row = dt.Rows[RowIndex];

                foreach (DataColumn dc in dt.Columns)
                {
                    var ColumnName = dc.ColumnName;
                    var Column = "{" + ColumnName + "}";
                    if (ColumnName == "回報單編碼")
                    {
                        QuestionCode = row[ColumnName].ToString();
                    }
                    else if (ColumnName == "回報者帳號")
                    {
                        InsertManAccountCode = row[ColumnName].ToString();
                    }
                    else if (ColumnName == "轉呈者帳號")
                    {
                        InsertManAccountCode = row[ColumnName].ToString();
                    }
                    if (Subject.IndexOf(Column) >= 0)
                    {
                        var Value = row[ColumnName].ToString();
                        Subject = Subject.Replace(Column, Value);
                    }

                    if (Body.IndexOf(Column) >= 0)
                    {
                        
                        var Value = row[ColumnName].ToString();
                        if (ColumnName=="超連結字串")
                        {
                            Value = "http://192.168.1.46/Reply/LoginBind.aspx?Param=" + Security.Encrypt("AccountCode="+InsertManAccountCode+"&&Code=" + QuestionCode);
                        }
                        Body = Body.Replace(Column, Value);
                    }
                }

                ////特別定義的變數
                //var oMain = new MainDao(dcShare);
                //var rsShareCode = oMain.ShareCodeNameCode("MailVarDefine");

                //foreach (var rShareCode in rsShareCode)
                //{
                //    var ColumnName = rShareCode.Code;
                //    var Column = "{" + ColumnName + "}";

                //    var Value = GetMailVarDefine(ColumnName, Parm);

                //    if (Subject.IndexOf(Column) >= 0)
                //        Subject = Subject.Replace(Column, Value);

                //    if (Body.IndexOf(Column) >= 0)
                //        Body = Body.Replace(Column, Value);
                //}
            }
        }
    }
}
