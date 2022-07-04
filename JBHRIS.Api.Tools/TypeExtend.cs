using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

public static class TypeExtend
{
    public static DateTime AddTime(this DateTime source, string Time)
    {
        int HH, mm;
        if (Time.Trim().Length == 0)
            Time = "0000";
        if (Time.Trim().Length > 4)
        {
            if (Time.Contains(":"))
            {
                HH = Convert.ToInt32(Time.Substring(0, 2));
                mm = Convert.ToInt32(Time.Substring(3, 2));
            }
            else if (Time.Contains("."))
            {
                HH = 0;
                mm = 0;
            }
            else
            {
                HH = Convert.ToInt32(Time.Substring(0, 2));
                mm = Convert.ToInt32(Time.Substring(3, 2));
            }
        }
        else
        {
            HH = Convert.ToInt32(Time.Substring(0, 2));
            mm = Convert.ToInt32(Time.Substring(2, 2));
        }
        source = source.AddHours(HH);
        source = source.AddMinutes(mm);
        return source;
    }
    public static TimeSpan ConvertToTimeSpan(this string TimeString)
    {
        return ConvertToTimeSpan(TimeString, new string[] { "hhmm", "hh\\:mm" });
    }
    //public static T ConvertJsonTo<T>(this string JsonString)
    //{
    //    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JsonString);
    //}
    //public static string ConvertToJson(this object SourceObj)
    //{
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(SourceObj);
    //}
    public static TimeSpan ConvertToTimeSpan(this string TimeString, string[] TimeFormatArray)
    {
        TimeSpan ts = new TimeSpan();
        if (!TimeSpan.TryParseExact(TimeString, TimeFormatArray, null, out ts))
            throw new Exception(string.Format("錯誤的時間格式({0})", TimeString));
        return ts;
    }
    public static string TimeStringBy48HR(this DateTime source, DateTime AttendDate)
    {
        var ts = source.Date - AttendDate.Date;
        return ((ts.Days * 24 + source.Hour) * 100 + source.Minute).ToString("0000");
    }
    public static string ToConstellationString(this DateTime source)
    {
        float fBirthDay = Convert.ToSingle(source.ToString("M.dd"));

        float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };

        string[] atoms = { "水瓶座", "雙魚座", "牡羊座", "金牛座", "雙子座", "巨蟹座", "獅子座", "處女座", "天秤座", "天蠍座", "射手座", "魔羯座" };
        string ret = string.Empty;

        for (int i = 0; i < atomBound.Length - 1; i++)
        {
            if (atomBound[i] <= fBirthDay && atomBound[i + 1] > fBirthDay)
            {
                ret = atoms[i];
                break;
            }
        }
        return ret;

    }
    public static string ToShengXiaoString(this DateTime source)
    {
        System.Globalization.ChineseLunisolarCalendar chinseCaleander = new System.Globalization.ChineseLunisolarCalendar();

        string TreeYear = "鼠牛虎兔龍蛇馬羊猴雞狗豬";

        int intYear = chinseCaleander.GetSexagenaryYear(source);

        string Tree = TreeYear.Substring(chinseCaleander.GetTerrestrialBranch(intYear) - 1, 1);

        return Tree;
    }

    public static string SpanTimeString(this TimeSpan source, string Format)
    {
        string value = Format;

        DateTime baseDate = DateTime.MinValue + source;
        value = value.Replace("y", (baseDate.Year - 1).ToString());
        value = value.Replace("M", (baseDate.Month - 1).ToString());
        value = value.Replace("d", (baseDate.Day - 1).ToString());

        return value;
    }
    public static string ToYearMonthString(this decimal source, string Format = "y年M月")
    {
        string value = Format;

        int yy = Convert.ToInt32(decimal.Floor(source));
        int MM = Convert.ToInt32((source - Convert.ToDecimal(yy)) * 12);

        value = value.Replace("y", (yy).ToString());
        value = value.Replace("M", (MM).ToString());
        //value = value.Replace("d", (baseDate.Day - 1).ToString());

        return value;
    }
    public static int ToInteger(this string Source)
    {
        return Convert.ToInt32(Source);
    }
    public static void Detach(object obj)
    {
        obj.GetType().GetMethod("Finalize", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(obj, null);
    }

}
// Define other methods and classes here
//public static class FileExtension
//{
//    // sqlcmd -iD:\CreateNorthwind.sql  -dNorthwindTest -S127.0.0.1\SQL2012 -Usa -Psapass
//    public static void ExecuteFile(this IDbConnection conn, string path)
//    {
//        var cs = new SqlConnectionStringBuilder(conn.ConnectionString);
//        var cmd = $"-i{path}  -d{cs.InitialCatalog} -S{cs.DataSource}";

//        if (!cs.IntegratedSecurity)
//        {
//            cmd += $" -U{cs.UserID} -P{cs.Password}";
//        }

//        Process p = new Process();
//        p.StartInfo.FileName = @"sqlcmd";
//        p.StartInfo.Arguments = cmd;
//        p.StartInfo.RedirectStandardOutput = true;
//        p.StartInfo.RedirectStandardInput = true;
//        p.StartInfo.CreateNoWindow = true;
//        p.StartInfo.UseShellExecute = false;
//        p.Start();

//        var info = p.StandardOutput.ReadToEnd();

//        p.WaitForExit();

//        if (p.ExitCode != 0)
//        {
//            throw new Exception($"execute faild:{info}");
//        }
//    }
//}

