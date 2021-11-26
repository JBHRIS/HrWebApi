/* ======================================================================================================
 * 功能名稱：早來晚走通知 - 主管
 * 功能代號：
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\工具程式\SendEarlyLate\Mang.cs
 * 功能用途：
 *  用於發送早來晚走通知到主管信箱和HR信箱
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/20    Daniel Chih    Ver 1.0.01     1. 將測試模式等AppConfig參數寫在ZZ2S內
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/20
 */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SendEarlyLate
{
    class Mang
    {
        private static SqlConnection GetConn()
        {
            //string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["HRConnectionString"];
            string SQL_CONNECTION_STRING = ConfigSetting.ConnectionString("JBHR.Properties.Settings.JBHRConnectionString").ToString();
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);
            return Con;
        }

        public static void DoSend(DateTime beginDate, DateTime endDate, bool TestMode, string TestMail)
        {
            List<Attachment> listFild = new List<Attachment>();
            DataTable Dt = new DataTable();

            Dt.Columns.Add("部門代碼", typeof(string));
            Dt.Columns.Add("部門名稱", typeof(string));
            Dt.Columns.Add("員工編號", typeof(string));
            Dt.Columns.Add("員工姓名", typeof(string));
            Dt.Columns.Add("出勤日期", typeof(string));
            Dt.Columns.Add("班別", typeof(string));
            Dt.Columns.Add("上班時間", typeof(string));
            Dt.Columns.Add("下班時間", typeof(string));
            Dt.Columns.Add("實際上班時間", typeof(string));
            Dt.Columns.Add("實際下班時間", typeof(string));
            Dt.Columns.Add("異常類型", typeof(string));
            Dt.Columns.Add("異常分鐘數", typeof(decimal));
            DataTable HRDt = new DataTable();
            DataTable HRDt1 = new DataTable();
            HRDt = Dt.Clone();
            DataTable Dt1 = new DataTable();
            Dt1 = Dt.Clone();
            Dt1.Columns.Add("saladr", typeof(string));
            HRDt1 = Dt1.Clone();
            try
            {
                ErrorUtility.WriteLog(DateTime.Now.ToString("yyyy/MM/dd hh:mm") + ":開始發送主管通知早來晚走");
                SqlConnection Conn = null;
                SqlCommand Cmd = null;
                Conn = Mang.GetConn();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                JBModule.Message.Mail Smail = new JBModule.Message.Mail();
                string date_e = "";
                string date_b = "";
                string DayInteval = ConfigurationSettings.AppSettings["DayInteval"];
                string MonthDayB = ConfigurationSettings.AppSettings["AttDay"];
                string Job = ConfigurationSettings.AppSettings["Job"];

                //抓取hr郵件參數設定天數及mail
                string MailFrom = "";
                string SenderName = string.Empty;
                string TestAccount = "";
                string Dept = "Dept";
                DataTable rq_parameter = new DataTable();
                string Cmdparameter = "select code,value from Parameter where code in ('JbMail.DateInteval','JbMail.sys_mail','JbMail.TestAccount','JbMail.Department','JbMail.HRAccount','JbMail.SenderName','JbMail.Sender')";
                Cmd.CommandText = Cmdparameter;
                SqlDataAdapter SCmd0 = new SqlDataAdapter(Cmd);
                SCmd0.Fill(rq_parameter);
                int fewday = -3;
                foreach (DataRow Row in rq_parameter.Rows)
                {
                    if (Row["code"].ToString().Trim() == "JbMail.DateInteval")
                        fewday = int.Parse(Row["value"].ToString());
                    else if (Row["code"].ToString().Trim() == "JbMail.Sender")
                        MailFrom = Row["value"].ToString().Trim();
                    else if (Row["code"].ToString().Trim() == "JbMail.TestAccount")
                        TestAccount = Row["value"].ToString().Trim();
                    else if (Row["code"].ToString().Trim() == "JbMail.Department")
                        Dept = Row["value"].ToString().Trim();
                    else if (Row["code"].ToString().Trim() == "JbMail.SenderName")
                        SenderName = Row["value"].ToString().Trim();
                }


                //開始日期
                date_b = beginDate.ToString("yyyy/MM/dd");
                //結束日期
                date_e = endDate.ToString("yyyy/MM/dd");

                #region 備註折疊
                //if (DayInteval != "0")
                //    fewday = Convert.ToInt32(DayInteval);

                //int _Day = DateTime.Now.Day;
                //int attmonth = 31;
                //if (!string.IsNullOrEmpty(MonthDayB))
                //    attmonth = Convert.ToInt32(MonthDayB);
                //date_e = DateTime.Now.AddDays(fewday).ToString("yyyy/MM/dd");
                //if (int.Parse(MonthDayB) > 0) //_Day == int.Parse(MonthDayB)
                //{
                //    if (attmonth == 31)
                //        attmonth = 1;
                //    else
                //        attmonth += 1;

                //    DateTime date_t = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(DateTime.Now.Month) + "/" + attmonth.ToString());
                //    //date_e = date_t.AddDays(-1).ToString("yyyy/MM/dd");                    
                //    if (_Day <= attmonth) //_Day ==1
                //    {
                //        date_b = date_t.AddMonths(-1).ToString("yyyy/MM/dd");
                //    }
                //    else
                //    {
                //        date_b = date_t.ToString("yyyy/MM/dd");
                //    }
                //}
                //else
                //{
                //    date_e = Convert.ToDateTime(DateTime.Now.AddDays(fewday)).ToString("yyyy/MM/dd");
                //    date_b = Convert.ToDateTime(DateTime.Now.AddDays(fewday)).ToString("yyyy/MM/dd");
                //}    

                //if (DateTime.Now.DayOfWeek.ToString().Trim() == "Monday")
                //{
                //    date_b = Convert.ToDateTime(DateTime.Now.AddDays(-3)).ToString("yyyy/MM/dd");
                //    date_e = Convert.ToDateTime(DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");
                //}
                #endregion 

                string dept_rela = " left outer join dept c on b.dept=c.d_no";
                string dept_query = "b.dept";
                if (Dept == "Depta")
                {
                    Dept = "b.deptm as dept";
                    dept_rela = " left outer join depta c on b.deptm=c.d_no ";
                    dept_query = "b.deptm";
                }
                else
                {
                    Dept = "b.dept";
                }

                //出勤異常名單
                DataTable rq_dataid = new DataTable();
                string CmdUdataid = "select c.d_no_disp,c.d_name,c.email,";
                CmdUdataid += string.Format(@"{0}", Dept);
                CmdUdataid += " from ATTEND_ABNORMAL a,base d,basetts b";
                CmdUdataid += dept_rela;
                CmdUdataid += " left outer join job g on b.job=g.job";
                CmdUdataid += " where a.nobr=b.nobr ";
                CmdUdataid += string.Format(@" and b.nobr=d.nobr and '{0}' between b.adate and b.ddate", date_e);
                CmdUdataid += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //CmdUdataid += string.Format(@" and a.adate <= '{0}'",  date_e);
                //CmdUdataid += " and a.is_error=1 ";
                CmdUdataid += " and exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime";
                CmdUdataid += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                CmdUdataid += string.Format(@" and g.job_disp not in  ({0})", Job);
                CmdUdataid += string.Format(@" and c.d_no_disp is not null group by {0},c.d_no_disp,c.email,c.d_name", dept_query);
                Cmd.CommandText = CmdUdataid;
                SqlDataAdapter SCmd = new SqlDataAdapter(Cmd);
                SCmd.Fill(rq_dataid);
                rq_dataid.PrimaryKey = new DataColumn[] { rq_dataid.Columns["d_no_disp"] };
               

                DataTable rq_attend = new DataTable();
                DataTable rq_attend1 = new DataTable();
                foreach (DataRow Row0 in rq_dataid.Rows)
                {
                    //出勤名單
                    string CmdAttend = "select a.nobr,d.name_c,a.adate,f.rote_disp+' '+f.rotename as rote,a.on_time,a.off_time,a.on_time_actual,a.off_time_actual,a.error_mins,b.saladr,";
                    CmdAttend += "(select g.name from mtcode g where a.type=g.code and g.category='ATTEND_ABNORMAL') as typename,";
                    CmdAttend += string.Format(@"{0},c.d_no_disp,c.d_name", Dept);
                    CmdAttend += " from ATTEND_ABNORMAL a,rote f,base d,basetts b";
                    CmdAttend += dept_rela;
                    CmdAttend += " left outer join job g on b.job=g.job";
                    CmdAttend += " where a.nobr=b.nobr and a.rote_code=f.rote and b.nobr=d.nobr ";
                    CmdAttend += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                    //CmdAttend += string.Format(@" and a.adate <= '{0}' ", date_e);
                    CmdAttend += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                    //CmdAttend += " and a.is_error=1  ";
                    CmdAttend += string.Format(@" and g.job_disp not in  ({0})", Job);
                    CmdAttend += " and  exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime";
                    CmdAttend += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                    CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);
                    Cmd.CommandText = CmdAttend;
                    SqlDataAdapter SCmd1 = new SqlDataAdapter(Cmd);
                    SCmd1.Fill(rq_attend);                    

                    foreach (DataRow Row3 in rq_attend.Select("","adate desc"))
                    {
                        DataRow aRow1 = Dt1.NewRow();
                        aRow1["部門代碼"] = Row3["d_no_disp"].ToString();
                        aRow1["部門名稱"] = Row3["d_name"].ToString();
                        aRow1["員工編號"] = Row3["nobr"].ToString();
                        aRow1["員工姓名"] = Row3["name_c"].ToString();                        
                        aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = Row3["rote"].ToString();
                        aRow1["上班時間"] = Row3["on_time"].ToString();
                        aRow1["下班時間"] = Row3["off_time"].ToString();
                        aRow1["實際上班時間"] = Row3["on_time_actual"].ToString();
                        aRow1["實際下班時間"] = Row3["off_time_actual"].ToString();
                        aRow1["異常類型"] = Row3["typename"].ToString();
                        aRow1["異常分鐘數"] = decimal.Parse(Row3["error_mins"].ToString());
                        aRow1["saladr"] = Row3["saladr"].ToString();
                        Dt1.Rows.Add(aRow1);                        
                    }
                    foreach (DataRow Rowdt in Dt1.Rows)
                    {
                        Dt.ImportRow(Rowdt);
                    }
                    HRDt1.Merge(Dt1);
                    rq_attend.Clear();

                    if (Dt.Rows.Count > 0)
                    {
                        string html = ConvertDataTableToHtml(Dt);
                        //string _Subject = date_b + "  - " + date_e + "出勤刷卡時間異常通知";
                        string _Subject = date_e + "截止" + "出勤刷卡時間異常通知";
                        try
                        {
                            if (Row0["email"].ToString().Trim() != "")
                            {
                                string[] _deptemail = Row0["email"].ToString().Split(';');
                                foreach (string _emaila in _deptemail)
                                {
                                    string mm = _emaila.Trim();

                                    //若不為測試模式
                                    if (!TestMode)
                                    {

                                        if (!string.IsNullOrWhiteSpace(mm))
                                        {
                                            Smail.AddMailQueueWithFileService(mm, _Subject, html, listFild);
                                            ErrorUtility.WriteLog("刷卡時間異常寄發信件到：主管信箱" + Row0["d_no_disp"].ToString() + "-> " + mm);
                                        }
                                        else
                                        {
                                            ErrorUtility.WriteLog("刷卡時間異常寄發信件到：主管信箱" + Row0["d_no_disp"].ToString() + "失敗：未設置信箱地址");
                                        }
                                    mm += "";
                                    }
                                    //若為測試模式則寄送到測試郵件地址
                                    else
                                    {
                                        if(TestMail != "")
                                        {
                                            Smail.AddMailQueueWithFileService(TestMail, _Subject, html, listFild);
                                            ErrorUtility.WriteLog("刷卡時間異常寄發信件到：主管信箱" + Row0["d_no_disp"].ToString() + "-> " + TestMail);
                                        }
                                        else
                                        {
                                            ErrorUtility.WriteLog("失敗：未設置測試信箱地址");
                                        }
                                    }
                                }
                            }
                            //若沒有郵件地址則寄送到測試郵件地址
                            else
                            {
                                Smail.AddMailQueueWithFileService(TestMail, _Subject, html, listFild);
                                ErrorUtility.WriteLog("刷卡時間異常寄發信件到：主管信箱" + Row0["d_no_disp"].ToString());
                            }
                        }
                        catch (Exception Ex)
                        {
                            ErrorUtility.WriteLog(Ex, "");
                            continue;
                        }
                    }
                    Dt.Clear();
                    Dt1.Clear();
                }                
                rq_dataid = null;
                rq_attend = null;

                if (HRDt1.Rows.Count > 0) //string.IsNullOrEmpty(TestAccount)
                {
                    //HR發送
                    //資枓群組HREMail
                    string Cmddatagroup = "select datagroup,note from datagroup where  note!='' order by datagroup";

                    //若為測試模式，則將HR發送也發送到測試郵件地址
                    if (TestMode)
                        Cmddatagroup = "select datagroup,'" + TestMail + "' as note from datagroup  order by datagroup";

                    Cmd.CommandText = Cmddatagroup;
                    SqlDataAdapter SCmdg = new SqlDataAdapter(Cmd);
                    DataTable rq_datagroup = new DataTable();
                    SCmdg.Fill(rq_datagroup);

                    DataTable rq_groupmail = new DataTable();
                    rq_groupmail.Columns.Add("email", typeof(string));
                    rq_groupmail.Columns.Add("saladr", typeof(string));
                    rq_groupmail.PrimaryKey = new DataColumn[] { rq_groupmail.Columns["email"] };
                    foreach (DataRow Row in rq_datagroup.Rows)
                    {
                        string[] _eamil = Row["note"].ToString().Split(';');
                        foreach (string MailRow in _eamil)
                        {
                            DataRow row = rq_groupmail.Rows.Find(MailRow);
                            if (row != null) 
                            { 
                                row["saladr"] = row["saladr"].ToString() + ";" + Row["datagroup"].ToString();
                            }
                            else
                            {
                                DataRow aRow = rq_groupmail.NewRow();
                                aRow["email"] = MailRow;
                                aRow["saladr"] = Row["datagroup"].ToString();
                                rq_groupmail.Rows.Add(aRow);
                            }
                        }
                    }
                    rq_datagroup = null;

                    foreach (DataRow Row in rq_groupmail.Rows)
                    {
                        string[] _saladr = Row["saladr"].ToString().Split(';');
                        foreach (string _saladra in _saladr)
                        {
                            foreach (DataRow Row1 in HRDt1.Select("saladr='" + _saladra + "'"))
                            {
                                HRDt.ImportRow(Row1);
                            }
                        }

                        string[] _mail = Row["email"].ToString().Split(';');

                        if (HRDt.Rows.Count > 0)
                        {
                            try
                            {
                                foreach (string _emaila in _mail)
                                {
                                    string mm = _emaila.Trim();
                                    string _Subject = date_e + "截止" + "出勤刷卡時間異常通知";

                                    string html = ConvertDataTableToHtml(HRDt);

                                    //判斷是否為測試模式
                                    if (!TestMode)
                                    {
                                        if (!string.IsNullOrWhiteSpace(mm))
                                        {
                                            Smail.AddMailQueueWithFileService(mm, _Subject, html, listFild);
                                            ErrorUtility.WriteLog("刷卡時間異常寄發信件到：HR人員" + mm);
                                        }
                                    }
                                    //若為測試模式則寄送到測試郵件地址
                                    else
                                    {
                                        Smail.AddMailQueueWithFileService(TestMail, _Subject, html, listFild);
                                        ErrorUtility.WriteLog("刷卡時間異常寄發信件到：測試人員" + TestMail);
                                    }
                                }
                            }
                            catch (Exception Ex)
                            {
                                ErrorUtility.WriteLog(Ex, "");
                                continue;
                            }
                        }
                        HRDt.Clear();
                    }
                    Conn.Dispose();
                    Cmd.Dispose();
                    rq_datagroup = null;
                }

                Dt1 = null;
            }
            catch (Exception E)
            {
                ErrorUtility.WriteLog(E, "");
            }
        }

        public static string ConvertDataTableToHtml(DataTable dt)
        {
            string BodyTop = string.Empty;
            //通知內容頁首/頁尾
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\Body.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("AttDeptTopA"))
                    {
                        string[] _body = line.Split('#');
                        if (_body.Length > 1)
                        {
                            BodyTop = _body[1];
                            //BodyTop = BodyTop.Replace("{Nobr}", nobr);
                            //BodyTop = BodyTop.Replace("{DateB}", DateTime.Parse(date_b).ToString("yyyyMMdd"));
                            //BodyTop = BodyTop.Replace("{DateE}", DateTime.Parse(date_e).ToString("yyyyMMdd"));
                        }
                    }

                }
            }


            int i = 0;
            string body = string.Empty;
            body += BodyTop;
            body += "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";
            
            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                            body += "<td  width=\"70px\">" + dc.ColumnName + "</td>";
                        else
                            body += "<td>" + dc.ColumnName + "</td>";
                        //body += "<td>" + dc.ColumnName + "</td>";
                    }

                    body += "</tr>";
                }

                body += "<tr>";
                foreach (DataColumn dc in dt.Columns)
                    body += "<td> " + r[dc].ToString().Trim() + "  &nbsp; </td>";

                body += "</tr>";
                i++;
            }
            body += "</table>";
            //body += "<BR><B><font color=red>本通知僅供參考，請各位仍需養成自行查看出勤的好習慣（關帳日若為月底時，更需要留意）。<BR>本筆異常通知為系統自動寄出，請勿直接回覆，若有任何出勤問題請洽分機1324淑芬</font></B>";
            return body;
        }
    }
}
