using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using JBModule.Data;
using JBModule.Data.Linq;
using JBModule.Message;
using System.IO;
using JBTools.Extend;
using JBHR.BLL.Att;

namespace JBHR_CardTextCollector
{
    class Program
    {
        //JBModule.Data.Linq.U_SYS7 CardParms = null;
        public static string CardDatePattern = "";
        public static string CardTimePattern = "";
        public static int CardGetPreDays = 2;
        public static string[] SourceBlackList = new string[] { };
        public static string[] SourceFoodCardList = new string[] { };
        public static bool RunAttendGenerate = true;
        static void Main(string[] args)
        {
            Dal.Dao.Att.TransCardDao ct = null;
            try
            {
                JBModule.Message.TextLog.WriteLog("開始收卡");
                string keyman, path;
                int cardno;
                cardno = Convert.ToInt32(ConfigSetting.AppSettingValue("CardSetting"));

                keyman = ConfigSetting.AppSettingValue("KeyMan");
                path = Directory.GetCurrentDirectory();
                JBModule.Data.Linq.U_SYS7 CardParms = null;
                HrDBDataContext db1 = new HrDBDataContext();
                dsAtt.CARDDataTable dtCard = new dsAtt.CARDDataTable();
                JBModule.Data.dsAttTableAdapters.CARDTableAdapter adCard = new JBModule.Data.dsAttTableAdapters.CARDTableAdapter();

                try
                {
                    path = ConfigSetting.AppSettingValue("Path");
                }
                catch
                {

                }
                try
                {
                    CardDatePattern = ConfigSetting.AppSettingValue("CardDate_Pattern");
                }
                catch
                {

                }
                try
                {
                    CardTimePattern = ConfigSetting.AppSettingValue("CardTime_Pattern");
                }
                catch
                {

                }

                try
                {
                    CardGetPreDays = Convert.ToInt32(ConfigSetting.AppSettingValue("CardGetPreDays"));
                }
                catch
                {

                }
                string BlackListString = "";
                try
                {
                    BlackListString = Convert.ToString(ConfigSetting.AppSettingValue("SourceBlackList"));
                }
                catch
                {

                }
                SourceBlackList = BlackListString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string FoodCardListString = "";
                try
                {
                    FoodCardListString = Convert.ToString(ConfigSetting.AppSettingValue("SourceFoodCardList"));
                }
                catch
                {

                }
                SourceFoodCardList = FoodCardListString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string RunAttendGenerateString = "";
                try
                {
                    RunAttendGenerateString = Convert.ToString(ConfigSetting.AppSettingValue("RunAttendGenerate"));
                }
                catch
                {

                }
                RunAttendGenerate = RunAttendGenerateString.ToUpper() != "FALSE" ? true : false;

                var parms = from a in db1.U_SYS7 where a.AUTO == cardno select a;
                CardParms = parms.First();

                DateTime t1, t2;
                t1 = DateTime.Now;


                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    var TextFiles = from a in files where a.Substring(a.LastIndexOf('.')).ToLower() == ".txt" select a;
                    foreach (var file in TextFiles)
                    {
                        HrDBDataContext db = new HrDBDataContext();
                        try//處理每個檔案，若是發生錯誤就往下一筆跑
                        {
                            JBModule.Message.TextLog.WriteLog("開啟檔案：" + file);
                            int row_count = 0;
                            int error = 0;
                            int success = 0;
                            int repeat = 0;
                            int counts = 0;
                            List<CARD> InsertData = new List<CARD>();
                            StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Big5"));
                            List<CardRead> cardList = new List<CardRead>();
                            while (sr.Peek() > 0)
                            {
                                row_count++;
                                try
                                {
                                    CardRead cr = new CardRead(sr.ReadLine(), CardParms);
                                    cardList.Add(cr);
                                }
                                catch (Exception ex)
                                {
                                    error++;
                                    JBModule.Message.TextLog.WriteLog(ex);
                                }
                            }
                            sr.Close();
                            sr.Dispose();

                            CARD cd = null;
                            FOOD_CARD fcd = null;
                            foreach (var itm in cardList)
                            {
                                try
                                {
                                    if (SourceFoodCardList.Contains(itm.code))
                                    {
                                        counts++;
                                        fcd = new FOOD_CARD();
                                        fcd.ADATE = itm.Adate;
                                        fcd.CARDNO = itm.cardno;
                                        fcd.CODE = itm.code;
                                        fcd.DAYS = 0;
                                        fcd.IPADD = "";
                                        fcd.KEY_DATE = DateTime.Now;
                                        fcd.KEY_MAN = keyman;
                                        fcd.LOS = false;
                                        fcd.MENO = "";
                                        fcd.NOBR = itm.nobr;
                                        fcd.NOT_TRAN = false;
                                        fcd.ONTIME = itm.Atime;
                                        fcd.REASON = "";
                                        fcd.SERNO = itm.serno;
                                        fcd.FULLTIME = DateTime.Now;
                                        fcd.Temperature = itm.Temperature;
                                        if (SourceBlackList.Contains(fcd.CODE))
                                            fcd.NOT_TRAN = true;

                                        var sql = from cc in db.FOOD_CARD where cc.NOBR == itm.nobr && cc.ADATE == itm.Adate && cc.ONTIME == itm.Atime select cc;
                                        if (sql.Any())//資料已存在就略過，並記錄重複次數
                                        {
                                            repeat++;
                                            continue;
                                        }
                                        db.FOOD_CARD.InsertOnSubmit(fcd);
                                    }
                                    else
                                    {
                                        counts++;
                                        cd = new CARD();
                                        cd.ADATE = itm.Adate;
                                        cd.CARDNO = itm.cardno;
                                        cd.CODE = itm.code;
                                        cd.DAYS = 0;
                                        cd.IPADD = "";
                                        cd.KEY_DATE = DateTime.Now;
                                        cd.KEY_MAN = keyman;
                                        cd.LOS = false;
                                        cd.MENO = "";
                                        cd.NOBR = itm.nobr;
                                        cd.NOT_TRAN = false;
                                        cd.ONTIME = itm.Atime;
                                        cd.REASON = "";
                                        cd.SERNO = itm.serno;
                                        //cd.FULLTIME = itm.Adate.AddTime(itm.Atime);
                                        cd.Temperature = itm.Temperature;
                                        if (SourceBlackList.Contains(cd.CODE))
                                            cd.NOT_TRAN = true;

                                        var sql = from cc in db.CARD where cc.NOBR == itm.nobr && cc.ADATE == itm.Adate && cc.ONTIME == itm.Atime select cc;
                                        if (sql.Any())//資料已存在就略過，並記錄重複次數
                                        {
                                            repeat++;

                                            continue;
                                        }
                                        //var insert = from cc in InsertData where cc.NOBR == itm.nobr && cc.ADATE == itm.Adate && cc.ONTIME == itm.Atime select cc;
                                        //if (sql.Any())//資料已存在就略過，並記錄重複次數
                                        //{
                                        //    repeat++;
                                        //    continue;
                                        //}
                                        if (!SourceBlackList.Contains(cd.CODE))
                                        {
                                            db.CARD.InsertOnSubmit(cd);
                                            //InsertData.Add(cd);
                                        }
                                    }
                                    db.SubmitChanges();//每個檔案更新
                                    success++;

                                    //JBModule.Data.Linq.HrDBDataContext HRdb = new JBModule.Data.Linq.HrDBDataContext();

                                    decimal temp = 0;
                                    if (!string.IsNullOrWhiteSpace(itm.Temperature) && decimal.TryParse(itm.Temperature, out temp))
                                    {
                                        int hours = int.Parse(itm.Atime.Substring(0, 2));
                                        int mins = int.Parse(itm.Atime.Substring(2, 2));
                                        JBModule.Data.Linq.TemperoturyReport temperoturyReport = new JBModule.Data.Linq.TemperoturyReport()
                                        {
                                            EmployeeId = itm.nobr,
                                            AttendDate = itm.Adate.AddHours(hours).AddMinutes(mins),
                                            Description = "JB-TRANSCARD",
                                            Guid = Guid.NewGuid(),
                                            KeyMan = "JB",
                                            KeyDate = DateTime.Now,
                                            ReportType = string.Empty,
                                            Temperotury = temp,
                                        };
                                        db.TemperoturyReport.InsertOnSubmit(temperoturyReport);
                                        db.SubmitChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    error++;
                                    TextLog.WriteLog(ex, "寫入到資料物件時發生錯誤");
                                }
                            }
                            //db.CARD.InsertAllOnSubmit(InsertData);
                            //db.SubmitChanges();//每個檔案更新

                            //更新成功才更名更名
                            string new_name = "";
                            int idx = file.LastIndexOf('.');
                            int sub_name = 1;
                            if (idx != -1)
                            {
                                new_name = file.Substring(0, idx) + "." + sub_name.ToString("00");
                                while (File.Exists(new_name))
                                {
                                    sub_name++;
                                    new_name = file.Substring(0, idx) + "." + sub_name.ToString("00");
                                }
                            }
                            else new_name = file + ".01";
                            if (file != new_name)
                            {
                                if (File.Exists(new_name))
                                    File.Delete(new_name);//如果目標檔案存在，就刪除他
                                File.Move(file, new_name);
                                File.Delete(file);
                            }
                            //顯示結果

                            TextLog.WriteLog("資料共有：" + row_count.ToString());
                            TextLog.WriteLog("成功共有：" + success.ToString());
                            TextLog.WriteLog("錯誤共有：" + error.ToString());
                            TextLog.WriteLog("重複共有：" + repeat.ToString());


                            if (dtCard.Rows.Count > 0)
                            {
                                string pathXml = System.IO.Directory.GetCurrentDirectory();
                                TextLog.WriteLog("發生" + dtCard.Rows.Count.ToString() + "Error");
                                dtCard.WriteXml(pathXml + "\\err" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                            }
                        }
                        catch (Exception ex)
                        {
                            TextLog.WriteLog(ex);
                            TextLog.WriteLog("發生錯誤，此檔案資料將全數取消寫入");
                        }
                    }

                }

                //var cardSQL = from a in db1.CARD where a.KEY_DATE >= t1 && a.KEY_DATE <= DateTime.Now select a;
                //if (cardSQL.Any())
                //{
                //DateTime d1 = cardSQL.Min(p => p.ADATE);
                //DateTime d2 = cardSQL.Max(p => p.ADATE);
                HrDBDataContext dbHR = new HrDBDataContext();
                string[] TTSCODE = new string[] { "1", "4", "6" };
                DateTime d1 = DateTime.Today.AddDays(1 - CardGetPreDays);
                DateTime d2 = DateTime.Today;
                if (RunAttendGenerate)
                {
                    var basettsList = from bts in dbHR.BASETTS
                                          //where bts.NOBR.CompareTo("0") >= 0 && bts.NOBR.CompareTo("ZZZZZZZZZZZZZ") <= 0
                                          //&& bts.DEPT.CompareTo("0") >= 0 && bts.DEPT.CompareTo("ZZZZZZZZZZZZZ") <= 0
                                          //&& bts.ADATE <= d2 && bts.DDATE.Value >= d1
                                      where bts.ADATE <= d2 && bts.DDATE.Value >= d1
                                      && TTSCODE.Contains(bts.TTSCODE)
                                      //&& db.GetFilterByNobr(bts.NOBR, "JB-TRANSCARD", MainForm.COMPANY, MainForm.ADMIN).Value
                                      select new
                                      {
                                          bts.NOBR,
                                          adate = bts.ADATE > d1 ? bts.ADATE : d1,
                                          ddate = bts.DDATE.Value <= d2 ? bts.DDATE.Value : d2,
                                          bts.DEPTS,
                                          bts.CALOT
                                      };
                    var empList = basettsList.Select(p => p.NOBR).Distinct().ToList();
                    string SessionId = "JB-TRANSCARD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    JBModule.Message.TextLog.WriteLog("正在产生出勤数据：" + SessionId);
                    try
                    {
                        foreach (var item in empList.Split(1000))
                        {
                            AttendanceGenerator generator = new AttendanceGenerator(item, d1, d2);
                            generator.KeyMan = "JB-TRANSCARD";
                            generator.Generate();
                        }
                    }
                    catch
                    {
                    }
                    JBModule.Message.TextLog.WriteLog("产生出勤数据完成：" + SessionId);
                }
                //var dateList = (from a in db1.CARD where a.KEY_DATE >= d1 && a.KEY_DATE <= d2 select a.ADATE).Distinct();
                //foreach (var itm in dateList)
                //{
                //只跑刷卡檔前一天到當天，避免遇到跨天問題，會抓取所有刷卡檔的日期集合
                TextLog.WriteLog("執行刷卡轉出勤：" + d1.ToString("yyyy/MM/dd") + "~" + d2.ToString("yyyy/MM/dd"));
                //ct = new Dal.Dao.Att.TransCardDao(db1.Connection);
                //ct.TransCard("0", "zzzzzzzzzzzzzzz", "0", "zzzzzzzzzzzzzzzz", d1, d2, "JB", true, true, true, "", "JB-TRANSCARD", true);

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db1.Connection);
                //tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                tc.TransCard("0", "ZZZZZZZZZZZZZ", "0", "ZZZZZZZZZZZZZ", d1, d2, "JB", true, true, true, "", "JB-TRANSCARD", true);
                //}
                //}
                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string msg = "完成，共耗時" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒";
                TextLog.WriteLog(msg);
                //if (ct != null && ct.errorCount > 0)
                //{
                //    msg = "收集刷卡資料時發生錯誤" + "<br/>";
                //    foreach (var itm in ct.ErrorQueue)
                //        msg += itm.ToString() + "<br/>";
                //    //var From = new System.Net.Mail.MailAddress
                //    //     (ConfigSetting.AppSettingValue("SendMail.FromAddress"), ConfigSetting.AppSettingValue("SendMail.FromName"));
                //    //var To = new System.Net.Mail.MailAddress
                //    //    (ConfigSetting.AppSettingValue("SendMail.ToAddress"), ConfigSetting.AppSettingValue("SendMail.ToName"));
                //    msg += "請修正問題後重新執行刷卡轉出勤";
                //    //Mail.SendMail(From, To, "收集刷卡資料錯誤通知", msg);
                //    JBModule.Message.TextLog.WriteLog(msg);
                //}
                System.Threading.Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
            }
        }

    }
    public class CardRead
    {
        public string cardno, serno, date, time, timeformat, nobr, code, temperature;
        public JBModule.Data.Linq.U_SYS7 _CardParms = null;
        public CardRead(string record, JBModule.Data.Linq.U_SYS7 CardParms)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            _CardParms = CardParms;
            //if (CardParms==null)
            //    CardParms = SysVar.GetCardVar(CardReader);
            if (CardParms.TEXT_TYPE == "Position")
            {
                if (record.Substring(CardParms.SER_POS.Value).Length >= CardParms.SER_LEN.Value)
                {
                    cardno = record.Substring(CardParms.NOBR_POS.Value, CardParms.NOBR_LEN.Value);
                }
                else
                {
                    cardno = record.Substring(CardParms.NOBR_POS.Value);
                }
                nobr = cardno;

                if (record.Substring(CardParms.SER_POS.Value).Length >= CardParms.SER_LEN.Value)
                {
                    serno = record.Substring(CardParms.SER_POS.Value, CardParms.SER_LEN.Value);
                }
                else
                {
                    serno = record.Substring(CardParms.SER_POS.Value);
                }
                date = record.Substring(CardParms.DATE_POS.Value, CardParms.DATE_LEN.Value).Trim();
                time = record.Substring(CardParms.TIME_POS.Value, CardParms.TIME_LEN.Value).Trim();
                code = record.Substring(CardParms.CODE_POS.Value, CardParms.CODE_LEN.Value).Trim();
                if (CardParms.Temperature_LEN.Value != 0)
                    temperature = record.Substring(CardParms.Temperature_POS.Value, CardParms.Temperature_LEN.Value).Trim();
                timeformat = CardParms.CARDDATEFORMAT.Trim();
                if (!CardParms.CARDNOEUQALNOBR.Value)
                {
                    var sql = from r in db.CARDAPP where r.CARDNO == cardno && Adate.Date >= r.BDATE && Adate.Date <= r.EDATE orderby r.BDATE descending select r;
                    if (sql.Any()) nobr = sql.First().NOBR.Trim();
                }
            }
            else
            {
                var signals = CardParms.SPILT_SIGNAL.ToString();
                var ignore_signal = CardParms.IGNORE_SIGNAL;
                string data = record.Replace(ignore_signal, "");
                var dataArray = data.Split(signals.ToCharArray());
                cardno = dataArray[CardParms.NOBR_POS.Value];
                nobr = cardno;
                serno = dataArray[CardParms.SER_POS.Value].Trim();
                date = dataArray[CardParms.DATE_POS.Value].Trim();
                time = dataArray[CardParms.TIME_POS.Value].Trim();
                code = dataArray[CardParms.CODE_POS.Value].Trim();
                if (CardParms.Temperature_LEN.Value != 0)
                    temperature = dataArray[CardParms.Temperature_POS.Value].Trim();
                timeformat = CardParms.CARDDATEFORMAT.Trim();
                if (!CardParms.CARDNOEUQALNOBR.Value)
                {
                    var sql = from r in db.CARDAPP where r.CARDNO == cardno && r.BDATE <= Adate.Date orderby r.BDATE descending select r;
                    if (sql.Any()) nobr = sql.First().NOBR.Trim();
                }
            }
        }
        public DateTime Adate
        {
            get
            {
                //if (this.timeformat.Trim() != "International")
                if (_CardParms.DATE_FORMAT.Trim().Length == 0)
                {
                    try
                    {
                        return new DateTime(Year, Month, Day);
                    }
                    catch (Exception ex)
                    {
                        return Convert.ToDateTime(date.Trim());
                    }
                }
                else
                {
                    DateTime dd = new DateTime();
                    if (DateTime.TryParseExact(date.Trim(), _CardParms.DATE_FORMAT, null, System.Globalization.DateTimeStyles.None, out dd))
                        return dd.Date;
                    else
                        throw new Exception("無法將" + date + "轉換成日期");
                }
            }
        }
        public int Year
        {
            get
            {
                if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(0, 4));
                else return Convert.ToInt32(date.Substring(0, 3)) + 1911;
            }
        }
        public int Month
        {
            get
            {
                if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(4, 2));
                else return Convert.ToInt32(date.Substring(3, 2));
            }
        }
        public int Day
        {
            get
            {
                if (this.timeformat.Trim() == "International") return Convert.ToInt32(date.Substring(6, 2));
                else return Convert.ToInt32(date.Substring(5, 2));
            }
        }
        public string Atime
        {
            get
            {
                string tt = this.time.Trim();
                if (_CardParms.TIME_FORMAT.Trim().Length == 0)
                {
                    if (tt.Length == 4)
                    {
                        int i = 0;
                        if (int.TryParse(tt, out i))
                            return tt;
                        else throw new Exception("轉換時間格式時發生錯誤(" + tt + ")");
                    }
                    else if (tt.Length == 5 || tt.Length == 8)//00:00 or 00:00:00
                    {
                        string dt = "1900/01/01 " + tt;
                        DateTime date = Convert.ToDateTime(dt);
                        return date.ToString("HHmm");
                    }
                    else if (tt.Length == 6)//時分秒
                    {
                        DateTime date = new DateTime(1900, 1, 1);
                        date = date.AddTime(tt.Substring(0, 4));
                        return date.ToString("HHmm");
                    }
                    else if (tt.IndexOf('午') != -1)
                    {
                        string time = tt.Replace("上午", "am");
                        time = time.Replace("下午", "pm");
                        string dt = time;
                        DateTime date = Convert.ToDateTime(dt);
                        return date.ToString("HHmm");
                    }
                    else
                    {
                        DateTime date = Convert.ToDateTime(tt);
                        return date.ToString("HHmm");
                    }
                }
                else
                {
                    DateTime dd = new DateTime();
                    if (DateTime.TryParseExact(tt, _CardParms.TIME_FORMAT, null, System.Globalization.DateTimeStyles.None, out dd))
                        return dd.ToString("HHmm");
                    else
                        throw new Exception("無法將" + tt + "轉換成時間");
                }
            }
        }
        public string Temperature
        {
            get
            {
                if (_CardParms.Temperature_LEN.Value != 0)
                {
                    string result = this.temperature;
                    decimal x = 0;
                    if (decimal.TryParse(result, out x))
                    {
                        if (x > 100)
                            x = x / 10;
                    }
                    else
                        throw new Exception("無法將" + result + "轉換成體溫數值");
                    return x.ToString();
                }
                else
                    return string.Empty;
            }
        }
    }
}
