using System;
using System.Collections.Generic;
using System.Linq;

namespace JBHRIS.Api.Tools
{
    public static class DataProcess
    {
        /// <summary>
        /// 切割資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">來源集合</param>
        /// <param name="step">切割大小</param>
        /// <returns></returns>
        public static List<List<T>> Split<T>(this List<T> source, int step)
        {
            List<List<T>> result = new List<List<T>>();
            int current = 0;
            int total = source.Count();
            while (current < total)
            {
                result.Add(source.Skip(current).Take(step).ToList());
                current += step;
            }
            return result;
        }

        public static Dictionary<decimal, decimal> AddOtDictionary(this Dictionary<decimal, decimal> dictionary, decimal key, decimal val)
        {
            if(key > 0 && val > 0)
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] += val;
                }
                else
                {
                    dictionary.Add(key, val);
                }
            }
            return dictionary;
        }

        public static Dictionary<string, decimal> AddAbsDictionary(this Dictionary<string, decimal> dictionary, string key, decimal val)
        {
            if (!string.IsNullOrEmpty(key) && val > 0)
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] += val;
                }
                else
                {
                    dictionary.Add(key, val);
                }
            }
            return dictionary;
        }
    }
}
