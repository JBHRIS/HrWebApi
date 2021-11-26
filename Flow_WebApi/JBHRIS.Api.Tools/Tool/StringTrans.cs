using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JBHRIS.Api.Tools.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public class StringTrans
    {
        /// <summary>
        /// 移除html tag
        /// </summary>
        /// <param name="htmlSource"></param>
        /// <returns></returns>
        public static string RemoveHTMLTag(string htmlSource)
        {
            //移除  javascript code.
            htmlSource = Regex.Replace(htmlSource, @"<script[\d\D]*?>[\d\D]*?</script>", String.Empty);

            //移除html tag.
            htmlSource = Regex.Replace(htmlSource, @"<[^>]*>", String.Empty);

            //html的空白變實際的空白
            htmlSource = Regex.Replace(htmlSource, @"&nbsp;", " ");

            return htmlSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public static string ParseText(string text, bool allow)
        {
            //Create a StringBuilder object from the string input
            //parameter
            StringBuilder sb = new StringBuilder(text);
            //Replace all double white spaces with a single white space
            //and &nbsp;
            sb.Replace("  ", " &nbsp;");
            //Check if HTML tags are not allowed
            if (!allow)
            {
                //Convert the brackets into HTML equivalents
                sb.Replace("<", "&lt;");
                sb.Replace(">", "&gt;");
                //Convert the double quote
                sb.Replace("\"", "&quot;");
            }
            //Create a StringReader from the processed string of
            //the StringBuilder
            StringReader sr = new StringReader(sb.ToString());
            StringWriter sw = new StringWriter();
            //Loop while next character exists
            while (sr.Peek() > -1)
            {
                //Read a line from the string and store it to a temp
                //variable
                string temp = sr.ReadLine();
                //write the string with the HTML break tag
                //Note here write method writes to a Internal StringBuilder
                //object created automatically
                sw.Write(temp + "<br>");
            }
            //Return the final processed text
            return sw.GetStringBuilder().ToString();
        }

        /// <summary>
        /// 將字串加某個特定的符號
        /// </summary>
        /// <param name="Str">原始字串</param>
        /// <param name="Symbol">符號</param>
        /// <param name="Start">開始加位置 0 為起始值</param>
        /// <param name="Count">取代幾個字</param>
        /// <returns>string</returns>
        public static string StringReplaceSymbol(string Str, string Symbol = "*", int Start = 1, int Count = 3)
        {
            var Vdb = "";

            int j = 1;

            var arrStr = Str.ToArray();
            for (int i = 0; i < arrStr.Length; i++)
            {
                string Char = arrStr[i].ToString();

                if (i >= Start && j <= Count)
                {
                    Char = Symbol;

                    j++;
                }

                Vdb += Char;
            }

            return Vdb;
        }
    }
}
