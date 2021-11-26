using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bll.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataTrans
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sQueryString"></param>
        /// <returns></returns>
        public static Dictionary<string, string> QueryStringToDictionary(string sQueryString)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            string[] querySegments = sQueryString.Split('&');
            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');
                if (parts.Length > 0)
                {
                    try
                    {
                        string key = parts[0].Trim(new char[] { '?', ' ' });
                        string val = parts[1].Trim();

                        dc.Add(key, val);
                    }
                    catch { }
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
                    htmlBuilder.Append("</tr><tr align='left' valign='top'>");

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
                throw new ArgumentNullException("targetTable");

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

        //方法一List<T>/IEnumerable轉換到DataTable/DataView
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        //方法二List<T>/IEnumerable轉換到DataTable/DataView
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType)).ToArray());
            //dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        //DataTable轉換到List
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {  //You can log something here     
                       //throw;    
                    }
                }
            }

            return obj;
        }
    }

    /// <summary>    
    /// 實體轉換輔助類    
    /// </summary>    
    public class ModelConvertHelper<T> where T : new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ConvertToModel(DataTable dt)
        {
            // 定義集合    
            IList<T> ts = new List<T>();

            // 獲得此模型的類型   
            Type type = typeof(T);
            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 獲得此模型的公共屬性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;  // 檢查DataTable是否包含此列    

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判斷此屬性是否有Setter      
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
    }
}
