using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JBHRIS.Api.Tools.Tool
{
    public class DataTrans
    {
        /// <summary>
        /// 將有特殊的字串轉成Dictionary
        /// </summary>
        /// <param name="sQueryString"></param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, string> QueryStringToDictionary(string sQueryString)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            string[] querySegments = sQueryString.Split('&');
            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');
                if (parts.Length > 0)
                {
                    string key = parts[0].Trim(new char[] { '?', ' ' });
                    string val = parts[1].Trim();

                    dc.Add(key, val);
                }
            }

            return dc;
        }

        /// <summary>
        /// 傳回DataTable的結構
        /// </summary>
        /// <param name="dt">資料表</param>
        /// <returns>DataTable</returns>
        public static DataTable DataStructure(DataTable dt)
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("欄位名稱").DefaultValue = "";
            dtTemp.Columns.Add("中文對照").DefaultValue = "";
            dtTemp.Columns.Add("型態").DefaultValue = "";
            dtTemp.Columns.Add("長度").DefaultValue = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                DataRow r = dtTemp.NewRow();
                r["欄位名稱"] = dc.ColumnName;
                r["中文對照"] = "";
                r["型態"] = dc.DataType.ToString();
                r["長度"] = dc.MaxLength;
                dtTemp.Rows.Add(r);
            }

            return dtTemp;
        }

        /// <summary>
        /// 轉換DataTable為Html(單欄)
        /// </summary>
        /// <param name="dt">資料表</param>
        /// <param name="dc">欄位名稱</param>
        /// <param name="ColumnNum">每欄幾列</param>
        /// <returns>string</returns>
        public static string ConvertDataTableToHtml(DataTable dt, string dc, int ColumnNum = 4)
        {
            string htmlString = "";

            if (dt == null || dt.Rows.Count == 0) return htmlString;

            ColumnNum = ColumnNum > dt.Rows.Count ? dt.Rows.Count : ColumnNum;

            StringBuilder htmlBuilder = new StringBuilder();

            //Create Top Portion of HTML Document
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Page-");
            htmlBuilder.Append(Guid.NewGuid().ToString());
            htmlBuilder.Append("</title>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");
            htmlBuilder.Append("<tr align='left' valign='top'>");

            int j = dt.Rows.Count + ((dt.Rows.Count % ColumnNum == 0) ? 0 : (ColumnNum - (dt.Rows.Count % ColumnNum)));
            for (int i = 0; i < j; i++)
            {
                if (i != 0 && i % ColumnNum == 0)
                {
                    htmlBuilder.Append("</tr><tr align='left' valign='top'>");
                }

                htmlBuilder.Append("<td align='left' valign='top'>");
                htmlBuilder.Append(dt.Rows.Count <= i || dt.Rows[i][dc].ToString().Length == 0 ? "&nbsp;" : dt.Rows[i][dc].ToString());
                htmlBuilder.Append("</td>");
            }

            htmlBuilder.Append("</tr>");

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            //Create String to be Returned
            htmlString = htmlBuilder.ToString();

            return htmlString;
        }

        /// <summary>
        /// 轉換DataTable為Html
        /// </summary>
        /// <param name="targetTable">DataTable</param>
        /// <returns>static</returns>
        public static string ConvertToHtmlFile(DataTable targetTable)
        {
            string htmlString = "";
            if (targetTable == null)
            {
                throw new System.ArgumentNullException("targetTable");
            }

            StringBuilder htmlBuilder = new StringBuilder();

            //Create Top Portion of HTML Document
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Page-");
            htmlBuilder.Append(Guid.NewGuid().ToString());
            htmlBuilder.Append("</title>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");

            //Create Header Row
            htmlBuilder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn targetColumn in targetTable.Columns)
            {
                htmlBuilder.Append("<td align='left' valign='top'>");
                htmlBuilder.Append(targetColumn.ColumnName);
                htmlBuilder.Append("</td>");
            }
            htmlBuilder.Append("</tr>");

            //Create Data Rows
            foreach (DataRow myRow in targetTable.Rows)
            {
                htmlBuilder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn targetColumn in targetTable.Columns)
                {
                    htmlBuilder.Append("<td align='left' valign='top'>");
                    htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString().Length == 0 ? "&nbsp;" : myRow[targetColumn.ColumnName].ToString());
                    htmlBuilder.Append("</td>");
                }
                htmlBuilder.Append("</tr>");
            }

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            //Create String to be Returned
            htmlString = htmlBuilder.ToString();

            return htmlString;
        }

        /// <summary>
        /// List 轉為 TableHtml
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="list">list</param>
        /// <param name="fxns">params</param>
        /// <returns>string</returns>
        public static string ConvertListToTableHtml<T>(IEnumerable<T> list, params Func<T, object>[] fxns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE  border='2px' width='100%'>\n");
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD>");
                    sb.Append(fxn(item));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }

        /// <summary>
        /// List 轉為 TableHtml
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="list">list</param>
        /// <param name="fxns">params</param>
        /// <returns>string</returns>
        public static string ConvertListToTableHtmlByAssess<T>(IEnumerable<T> list, params Func<T, object>[] fxns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE  border='2px' width='100%'>\n");
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                int i = 0;
                foreach (var fxn in fxns)
                {
                    if (i == 0)
                    {
                        sb.Append("<TD>");
                    }
                    else
                    {
                        sb.Append("<TD align='right'>");
                    }
                    sb.Append(fxn(item));
                    sb.Append("</TD>");

                    i++;
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }
    }
}
