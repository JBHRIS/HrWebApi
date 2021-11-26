using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Tools
{
    public static class ObjectFunction
    {
        /// <summary>
        /// 物件屬性型別為string而且值為Null時將值轉成Empty
        /// </summary>
        /// <typeparam name="T">任意物件</typeparam>
        /// <param name="sourse"></param>
        /// <param name="Include">納入此規則的屬性</param>
        /// <returns></returns>
        public static List<T> ObjectStringNullToEmptyInclude<T>(this List<T> sourse, List<string> Include) where T : class
        {
            foreach (var import in sourse)
            {
                foreach (var x in import.GetType().GetProperties())
                {
                    bool isInclude = Include.Contains(x.Name);
                    if (x.GetValue(import) == null && x.PropertyType.FullName is string && isInclude)
                    {
                        x.SetValue(import, "");
                    }
                }
            }

            return sourse;
        }

        /// <summary>
        /// 物件屬性型別為string而且值為Null時將值轉成Empty
        /// </summary>
        /// <typeparam name="T">任意物件</typeparam>
        /// <param name="sourse"></param>
        /// <param name="notInclude">不納入此規則的屬性</param>
        /// <returns></returns>
        public static List<T> ObjectStringNullToEmptyNotInclude<T>(this List<T> sourse, List<string> notInclude = null) where T : class
        {
            foreach (var import in sourse)
            {
                foreach (var x in import.GetType().GetProperties())
                {
                    bool isNotInclude = notInclude == null ? true : false;
                    if (!isNotInclude)
                    {
                        isNotInclude = !(notInclude.Contains(x.Name));
                    }
                    if (x.GetValue(import) == null && x.PropertyType.FullName is string && isNotInclude)
                    {
                        x.SetValue(import, "");
                    }
                }
            }

            return sourse;
        }
    }
}
