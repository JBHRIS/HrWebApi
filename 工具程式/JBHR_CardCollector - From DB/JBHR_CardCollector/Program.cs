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
using System.Data.SqlClient;

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

        static DataTable data = new DataTable("Card");
        HrDBDataContext db = new HrDBDataContext();
        static DateTime SelectTime;
        static List<CARD> cardList;
        //static int intervals = 0;

        static void Main(string[] args)
        {
            //Dal.Dao.Att.TransCardDao ct = null;
            try
            {
                JBModule.Message.TextLog.WriteLog("開始收卡");
                string keyman, path;
                //int cardno;
                //cardno = Convert.ToInt32(ConfigSetting.AppSettingValue("CardSetting"));

                keyman = ConfigSetting.AppSettingValue("KeyMan");
                path = Directory.GetCurrentDirectory();
                //JBModule.Data.Linq.U_SYS7 CardParms = null;
                HrDBDataContext db1 = new HrDBDataContext();
                dsAtt.CARDDataTable dtCard = new dsAtt.CARDDataTable();
                JBModule.Data.dsAttTableAdapters.CARDTableAdapter adCard = new JBModule.Data.dsAttTableAdapters.CARDTableAdapter();

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
                SourceBlackList = BlackListString.Split(',');

                string FoodCardListString = "";
                try
                {
                    FoodCardListString = Convert.ToString(ConfigSetting.AppSettingValue("SourceFoodCardList"));
                }
                catch
                {

                }
                SourceFoodCardList = FoodCardListString.Split(',');

                string RunAttendGenerateString = "";
                try
                {
                    RunAttendGenerateString = Convert.ToString(ConfigSetting.AppSettingValue("RunAttendGenerate"));
                }
                catch
                {

                }
                RunAttendGenerate = RunAttendGenerateString.ToUpper() != "FALSE" ? true : false;

                DateTime t1, t2;
                t1 = DateTime.Now;

                var sql = from r in db1.U_SYS7A select r;
                foreach (U_SYS7A row in sql)
                {
                    JBModule.Message.TextLog.WriteLog("設定檔：" + row.CARD_NAME);
                    JBModule.Message.TextLog.WriteLog("讀取資料");
                    GetData(row);//取得data
                    JBModule.Message.TextLog.WriteLog("讀取資料完成，共" + data.Rows.Count.ToString());
                    cardList = new List<CARD>();
                    HrDBDataContext db = new HrDBDataContext();
                    //dcBasDataContext dbBase = new dcBasDataContext();                
                    dsAtt.CARDDataTable dt = new dsAtt.CARDDataTable();
                    JBModule.Data.dsAttTableAdapters.CARDTableAdapter ad = new JBModule.Data.dsAttTableAdapters.CARDTableAdapter();

                    var baseList = from r in db.BASE select r.NOBR.Trim();
                    var dataList = data.AsEnumerable();
                    var dataIncludeBase = from d in dataList
                                          join b in baseList on d[0].ToString().Trim() equals b.Trim()
                                          select d;

                    //dsAtt.CARD.Clear();

                    foreach (DataRow itm in dataIncludeBase)
                    {
                        string nobr, adate, ontime, cardno, source, ipaddr, temperature;
                        nobr = itm[0].ToString();
                        adate = itm[1].ToString();
                        ontime = itm[2].ToString();
                        cardno = itm[3].ToString();
                        source = itm[4].ToString();
                        ipaddr = itm[5].ToString();
                        temperature = itm[6].ToString();
                        //if (!baseList.Contains(nobr.Trim())) continue;//如果沒有base資料就略過

                        //CARD card = new CARD();
                        dsAtt.CARDRow card = dt.NewCARDRow();
                        card.SetRowDefaultValue();
                        card.ADATE = Convert.ToDateTime(adate).Date;
                        card.CARDNO = cardno;
                        string time = ontime;
                        if (itm[2].GetType() == typeof(DateTime) || ontime.Length > 4) time = Convert.ToDateTime(ontime).ToString("HHmm");
                        card.CODE = source;
                        card.DAYS = 0;
                        card.IPADD = ipaddr;
                        card.KEY_DATE = DateTime.Now;
                        card.KEY_MAN = keyman;
                        card.LOS = false;
                        card.MENO = "";
                        card.NOBR = nobr;
                        card.NOT_TRAN = false;
                        card.ONTIME = time;
                        card.REASON = "";
                        card.SERNO = "";
                        card.temperature = temperature;
                        //db.CARD.InsertOnSubmit(card);
                        try
                        {
                            db.SubmitChanges();
                            dt.AddCARDRow(card);
                            ad.Update(card);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.IndexOf("插入重複的索引鍵") != -1 || ex.Message.IndexOf("'NOBR, ADATE, ONTIME' 被限制為唯一") != -1)
                                JBModule.Message.TextLog.WriteLog(string.Format("資料重複：{0},{1},{2}", card.NOBR, card.ADATE, card.ONTIME));
                            else
                                JBModule.Message.TextLog.WriteLog(string.Format("{0},{1},{2}：{3}", card.NOBR, card.ADATE, card.ONTIME), ex);
                        }
                    }

                    row.LATEST_CHECK = SelectTime;//因為是離線資料處理，所以應該以讀取資料當時的時間為準
                                                  //dateTimePicker1.Value = SelectTime;
                    db1.SubmitChanges();
                }

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

                System.Threading.Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
            }
        }

        static void GetData(U_SYS7A row)
        {
            HrDBDataContext db = new HrDBDataContext();
            string connectionString =
              string.Format(
              "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
              , row.DATA_SOURCE, row.INITAIL_CATALOG, row.USER_ID, row.PASSWORD);
            //JBModule.Message.TextLog.WriteLog("讀取：" + connectionString);
            DateTime dtNow = DateTime.Now;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                JBModule.Data.CSQL cData = new JBModule.Data.CSQL(conn);
                string nobr, adate, ontime, cardno, checktime, source, ipaddr, temperature;
                nobr = row.COL_NOBR == null ? "''" : row.COL_NOBR;
                adate = row.COL_ADATE == null ? "''" : row.COL_ADATE;
                ontime = row.COL_ONTIME == null ? "''" : row.COL_ONTIME;
                cardno = row.COL_CARDNO == null || row.COL_CARDNO.Trim().Length == 0 ? "''" : row.COL_CARDNO;
                source = row.COL_SOURCE == null || row.COL_SOURCE.Trim().Length == 0 ? "''" : row.COL_SOURCE;
                ipaddr = row.COL_IPADD == null || row.COL_IPADD.Trim().Length == 0 ? "''" : row.COL_IPADD;
                temperature = row.COL_Temperature == null || row.COL_Temperature.Trim().Length == 0 ? "''" : row.COL_Temperature;
                checktime = row.COL_CHECKTIME.Trim().Length == 0 ? adate : row.COL_CHECKTIME;//沒有選擇欄位的話就以adate為準
                object[] parms = new object[] { nobr, adate, ontime, cardno, checktime, row.DATATABLE, row.LATEST_CHECK.Date.AddDays(-1 * CardGetPreDays).ToString("yyyy/MM/dd HH:mm:ss"), dtNow.ToString("yyyy/MM/dd HH:mm:ss"), source.Trim().Length > 0 ? source : @"''", ipaddr.Trim().Length > 0 ? ipaddr : @"''", ontime, temperature };
                //object[] parms = new object[] { nobr, adate, ontime, cardno, checktime, row.DATATABLE, dateTimePicker1.Value, dateTimePicker2.Value, source.Trim().Length > 0 ? source : @"''", ipaddr.Trim().Length > 0 ? ipaddr : @"''", ontime, temperature };
                string cmd = string.Format(row.SQL, parms);
                //JBModule.Message.TextLog.WriteLog("查詢：" + cmd);
                SelectTime = DateTime.Now;
                data = cData.GetDataTable(cmd);
                foreach (DataRow it in data.Rows)
                {
                    if (it[3].ToString().Length > 0)
                    {
                        DateTime dDate = Convert.ToDateTime(it[1].ToString());
                        string sCardno = it[3].ToString();
                        var sql = from a in db.CARDAPP where a.CARDNO == sCardno && dDate >= a.BDATE orderby a.BDATE descending select a.NOBR;
                        if (sql.Any()) it[0] = sql.First();
                    }
                }
                //dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(Resources.All.DBConnectErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                JBModule.Message.TextLog.WriteLog(ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
