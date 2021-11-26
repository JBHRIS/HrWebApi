using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JBTools.IO
{
    public class FormatString
    {
        public FormatString()
        {

        }

        #region Property
        public List<SalaryTransSettings> Settings
        {
            get;
            set;
        }

        public List<Dictionary<string, string>> ContentPair
        {
            get;
            set;
        }
        #endregion

        public string GetRecord()
        {
            if (Settings == null) Settings = new List<SalaryTransSettings>();

            if (ContentPair == null) ContentPair = new List<Dictionary<string, string>>();

            string str = "";

            foreach (var list in ContentPair)
            {
                int i = 0;
                foreach (var setting in Settings)
                {
                    if (list.ContainsKey(setting.Code))
                    {
                        str += GetString(setting, list[setting.Code]);
                        
                    }
                    else
                        str += GetString(setting, "");
                    i++;
                }
                if (i > 0)
                    str += Environment.NewLine;
            }
            return str;
        }

        public string GetString(SalaryTransSettings Settings, string content)
        {
            if (Settings.Type == "Fixed") content = Settings.FixedContent;

            //if (content == "" || content == null) //當內容不輸入 且不是固定值 補空白
            //{
            //    string str = "";
            //    return str.PadRight(Settings.Length, ' ');
            //}

            switch (Settings.Type)
            {
                case "String":
                    {

                        if (content.Length > Settings.Length)
                        {
                            throw new FormatException(Settings.Code + "超過設定範圍!");
                        }                       
                        if (Settings.Side == "LEFT")
                        {
                            if (Settings.Filled == "E")
                                content = content.PadLeft(Settings.Length);
                            else if (Settings.Filled == "0")
                                content = content.PadLeft(Settings.Length, Convert.ToChar(Settings.Filled));
                        }
                        else if (Settings.Side == "RIGHT")
                        {
                            if (Settings.Filled == "E")
                                content = content.PadRight(Settings.Length);
                            else if (Settings.Filled == "0")
                                content = content.PadRight(Settings.Length, Convert.ToChar(Settings.Filled));
                        }
                        else
                        {
                            content = content.PadRight(Settings.Length);
                        }

                        ////20160613中文字字文數修改
                        //int _deduction = 0;
                        //if (System.Text.Encoding.Default.GetBytes(content).Length > content.Length)
                        //    _deduction = System.Text.Encoding.Default.GetBytes(content).Length - content.Length;
                        //return content = content.Substring(0, Settings.Length-_deduction);
                        return content = content.Substring(0, Settings.Length);
                    }
                case "Empty":
                    {
                        return content = content.PadRight(Settings.Length);
                    }
                case "Date":
                    {
                        try
                        {
                            if (Settings.YearType == "民國年")
                                content = ToTaiwanCalendar(Convert.ToDateTime(content), Settings.DateFormat, "00");
                            else
                                content = Convert.ToDateTime(content).ToString(Settings.DateFormat);

                            if (content.Length > Settings.Length)
                            {
                                content = content.Substring((content.Length - Settings.Length), Settings.Length);
                            }
                            else
                            {
                                content = content.PadLeft(Settings.Length);
                            
                            }

                            return content;
                        }
                        catch
                        {
                            throw new FormatException("日期格式錯誤!");
                        }
                    }
                case "Amt":
                    {
                        if (content =="" || content == null )
                        {
                            return content = content.PadLeft(Settings.Length, '0');
                        }
                        try
                        {
                            string str = string.Format("{0:f" + Settings.FixedContent + "}", double.Parse(content));
                            str = str.Replace(".", "");
                            content = str.PadLeft(Settings.Length, '0');

                            if (content.Length > Settings.Length)
                            {
                                throw new FormatException();
                            }
                            return content;
                        }
                        catch 
                        {
                            throw new FormatException(Settings.Code + "輸入格式錯誤或超出設定範圍!");
                        }

                    }
                case "Number":
                    {
                        content = content.PadLeft(Settings.Length, Convert.ToChar(Settings.Filled));
                        return content = content.Substring(0, Settings.Length);
                    }
                case "Memo":
                    {
                        byte[] bTemp = System.Text.Encoding.GetEncoding("Big5").GetBytes(content);
                        content = System.Text.Encoding.GetEncoding("Big5").GetString(bTemp, 0, bTemp.Length <= Settings.Length ? bTemp.Length : Settings.Length);
                        content = content.PadRight(10);
                        return content;
                    }
                case "Fixed":
                    {
                        if (content.Length > Settings.Length)
                        {
                            throw new FormatException("輸入固定值超過設定範圍!");
                        }
                        if (Settings.Side == "LEFT")
                        {
                            if (Settings.Filled == "E")
                                content = content.PadLeft(Settings.Length);
                            else if (Settings.Filled == "0")
                                content = content.PadLeft(Settings.Length, Convert.ToChar(Settings.Filled));
                        }
                        else if (Settings.Side == "RIGHT")
                        {
                            if (Settings.Filled == "E")
                                content = content.PadRight(Settings.Length);
                            else if (Settings.Filled == "0")
                                content = content.PadRight(Settings.Length, Convert.ToChar(Settings.Filled));
                        }
                        else
                        {
                            content = content.PadLeft(Settings.Length);
                        }

                        ////20160613中文字字文數修改
                        //int _deduction = 0;
                        //if (System.Text.Encoding.Default.GetBytes(content).Length > content.Length)
                        //    _deduction = System.Text.Encoding.Default.GetBytes(content).Length - content.Length;
                        //return content = content.Substring(0, Settings.Length - _deduction);
                        return content = content.Substring(0, Settings.Length);
                    }
                default:
                    return "";
            }
        }

        /// <summary>
        /// 轉換為民國年
        /// </summary>
        /// <param name="x">要轉換的日期</param>
        /// <param name="format">標準格式化語法</param>
        /// <returns></returns>
        static public string ToTaiwanCalendar(DateTime x, string format, string yearFormat)
        {
            DateTime now = x;
            TaiwanCalendar tc = new TaiwanCalendar();
            Regex regex = new Regex(@"[yY]+");
            format = regex.Replace(format, tc.GetYear(x).ToString(yearFormat));
            return x.ToString(format);
        }
    }
}