using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Tools.Tool
{
    public static class DefaultData
    {
        /// <summary>
        /// 填入所有預設資料
        /// </summary>
        /// <param name="row">Row</param>
        public static void SetRowDefaultValue(DataRow row)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0;
                if (t == typeof(double)) row[dc] = 0;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }

        /// <summary>
        /// 資料複制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        public static void CloneProperties<T>(this T origin, T destination)
        {
            // Instantiate if necessary
            if (destination == null) throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
            // Loop through each property in the destination
            foreach (var destinationProperty in destination.GetType().GetProperties())
            {
                // find and set val if we can find a matching property name and matching type in the origin with the origin's value
                if (origin != null && destinationProperty.CanWrite)
                {
                    origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                        .ToList()
                        .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Clone<T>(this T source)
        {
            var dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
            using (var ms = new System.IO.MemoryStream())
            {
                dcs.WriteObject(ms, source);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)dcs.ReadObject(ms);
            }
        }

        /// <summary>
        /// 取得物件某欄位的值
        /// </summary>
        /// <typeparam name="T">自訂型別</typeparam>
        /// <param name="o">物件來源</param>
        /// <param name="propertyName">屬性名稱</param>
        /// <returns>自訂型別</returns>
        public static T GetProperty<T>(object o, string propertyName)
        {
            var theProperty = o.GetType().GetProperties().FirstOrDefault(p => p.Name == propertyName);

            if (theProperty == null)
                throw new ArgumentException("object does not have an " + propertyName + " property", "o");

            if (theProperty.PropertyType.FullName != typeof(T).FullName)
                throw new ArgumentException("object has an Id property, but it is not of type " + typeof(T).FullName, "o");

            return (T)theProperty.GetValue(o, new object[] { });
        }

        /// <summary>
        /// 取代文字內的屬性值
        /// </summary>
        /// <param name="sContent">要取代的文字內容</param>
        /// <param name="oSourceS">次要資料表</param>
        /// <param name="oSourceM">主要資料表</param>
        /// <returns>string</returns>
        public static string SetReplaceProperty(string sContent, object oSourceS, object oSourceM = null)
        {
            if (oSourceS != null)
            {
                var pi = oSourceS.GetType().GetProperties();
                foreach (var p in pi)
                    if (p.GetValue(oSourceS, null) != null)
                    {
                        try
                        {
                            if (sContent.IndexOf("{" + p.Name + "}") != -1 && p.Name.IndexOf("Date") >= 0 && p.Name.IndexOf("Time") == -1) //有日期沒有時間的欄位 把時間去掉 
                            {
                                sContent = sContent.Replace("{" + p.Name + "}", ConvertValue(p.PropertyType.ToString(), Convert.ToDateTime(p.GetValue(oSourceS, null)).ToShortDateString()));

                                continue;
                            }
                        }
                        catch { }

                        if (sContent.IndexOf("{" + p.Name + "}") != -1 && p.Name == "idProcess")
                            sContent = sContent.Replace("{" + p.Name + "}", ConvertValue(p.PropertyType.ToString(), p.GetValue(oSourceS, null).ToString()).PadLeft(10, '0'));
                        else if (sContent.IndexOf("{" + p.Name + "}") != -1)
                            sContent = sContent.Replace("{" + p.Name + "}", ConvertValue(p.PropertyType.ToString(), p.GetValue(oSourceS, null).ToString()));
                        else if (sContent.IndexOf("{GetDate()}") != -1)
                            sContent = sContent.Replace("{GetDate()}", DateTime.Now.ToShortDateString());
                        else if (sContent.IndexOf("{GetDateTime()}") != -1)
                            sContent = sContent.Replace("{GetDateTime()}", DateTime.Now.ToString());
                    }
            }

            if (oSourceM != null)
            {
                var pi = oSourceM.GetType().GetProperties();
                foreach (var p in pi)
                    if (p.GetValue(oSourceM, null) != null)
                        if (sContent.IndexOf("{M." + p.Name + "}") != -1 && p.Name == "idProcess")
                            sContent = sContent.Replace("{M." + p.Name + "}", ConvertValue(p.PropertyType.ToString(), p.GetValue(oSourceM, null).ToString()).PadLeft(10, '0'));
                        else if (sContent.IndexOf("{M." + p.Name + "}") != -1)
                            sContent = sContent.Replace("{M." + p.Name + "}", ConvertValue(p.PropertyType.ToString(), p.GetValue(oSourceM, null).ToString()));
                        else if (sContent.IndexOf("{GetDate()}") != -1)
                            sContent = sContent.Replace("{GetDate()}", DateTime.Now.ToShortDateString());
                        else if (sContent.IndexOf("{GetDateTime()}") != -1)
                            sContent = sContent.Replace("{GetDateTime()}", DateTime.Now.ToString());
            }

            return sContent;
        }

        /// <summary>
        /// 轉換值的格式
        /// </summary>
        /// <param name="sType">型態</param>
        /// <param name="sValue">原始的值</param>
        /// <returns>string</returns>
        private static string ConvertValue(string sType, string sValue)
        {
            switch (sType)
            {
                case "System.String":
                    break;
                case "System.Boolean":
                    break;
                case "System.Nullable`1[System.Decimal]":
                case "System.Decimal":
                    break;
                case "System.Nullable`1[System.Int32]":
                case "System.Int32":
                case "System.Int64":
                case "System.Int16":
                    break;
                case "System.DateTime":
                    sValue = Convert.ToDateTime(sValue).ToShortDateString();
                    break;
            }

            return sValue;
        }
    }
}
