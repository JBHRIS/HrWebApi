/* ======================================================================================================
 * 功能名稱：早來晚走通知 - 個人
 * 功能代號：
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\工具程式\SendEarlyLate\Employee.cs
 * 功能用途：
 *  用於發送早來晚走通知到員工個人信箱
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
    class Employee
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
            try
            {
                ErrorUtility.WriteLog(DateTime.Now.ToString("yyyy/MM/dd hh:mm") + ":開始發送個人通知早來晚走");
                SqlConnection Conn = null;
                SqlCommand Cmd = null;
                Conn = Employee.GetConn();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                JBModule.Message.Mail Smail = new JBModule.Message.Mail();
                string date_e = "";
                string date_b = "";
                string MonthDayB = ConfigurationSettings.AppSettings["AttDay"];
                string DayInteval = ConfigurationSettings.AppSettings["DayInteval"];
                string Job = ConfigurationSettings.AppSettings["Job"];
                string MailFrom = "";
                string SenderName = string.Empty;
                string TestAccount = "";
                string Dept = "Dept";
                DataTable rq_parameter = new DataTable();
                string Cmdparameter = "select code,value from Parameter where code in ('JbMail.DateInteval','JbMail.sys_mail','JbMail.TestAccount','JbMail.Department','JbMail.HRAccount','JbMail.SenderName','JbMail.Sender')";
                Cmd.CommandText = Cmdparameter;
                SqlDataAdapter SCmd0 = new SqlDataAdapter(Cmd);
                SCmd0.Fill(rq_parameter);
                int fewday = -1;
                foreach (DataRow Row in rq_parameter.Rows)
                {
                    if (Row["code"].ToString().Trim() == "JbMail.DateInteval")
                        fewday = int.Parse(Row["value"].ToString());
                    else if (Row["code"].ToString().Trim() == "JbMail.Sender")
                        MailFrom = Row["value"].ToString();
                    else if (Row["code"].ToString().Trim() == "JbMail.TestAccount")
                        TestAccount = Row["value"].ToString();
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


                string CmdRote = "select rote,rote_disp,rotename from rote";
                Cmd.CommandText = CmdRote;
                SqlDataAdapter SCmdr = new SqlDataAdapter(Cmd);
                DataTable rq_rote = new DataTable();
                SCmdr.Fill(rq_rote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

                DataTable rq_attend = new DataTable();
                //出勤異常名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,f.rote_disp+' '+f.rotename as rote,a.on_time,a.off_time,a.on_time_actual,a.off_time_actual,a.error_mins,";
                CmdAttend += "(select g.name from mtcode g where a.type=g.code and g.category='ATTEND_ABNORMAL') as typename,";
                CmdAttend += string.Format(@"{0},c.d_no_disp,c.d_name,d.email", Dept);
                CmdAttend += " from base d,ATTEND_ABNORMAL a,rote f,basetts b ";
                CmdAttend += dept_rela;
                CmdAttend += " left outer join job g on b.job=g.job";
                CmdAttend += " where a.nobr=b.nobr and a.rote_code=f.rote and b.nobr=d.nobr";
                CmdAttend += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //CmdAttend += string.Format(@" and a.adate <= '{0}' ", date_e);
                CmdAttend += "  and d.email<>''"; //and a.is_error=1
                CmdAttend += " and  exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime ";
                CmdAttend += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                CmdAttend += string.Format(@" and g.job_disp not in  ({0})", Job);
                CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);
                Cmd.CommandText = CmdAttend;
                SqlDataAdapter SCmd1 = new SqlDataAdapter(Cmd);
                SCmd1.Fill(rq_attend);
                ErrorUtility.WriteLog("本日出勤早到晚走同仁共有：" + rq_attend.Rows.Count.ToString());

                DataTable rq_email = new DataTable();
                rq_email.Columns.Add("nobr", typeof(string));
                rq_email.Columns.Add("name_c", typeof(string));
                rq_email.Columns.Add("email", typeof(string));
                rq_email.Columns.Add("deptmail", typeof(string));
                rq_email.PrimaryKey = new DataColumn[] { rq_email.Columns["nobr"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_email.Rows.Find(Row["nobr"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_email.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["email"] = Row["email"].ToString().Trim();
                        //aRow["deptmail"] = Row["deptmail"].ToString();
                        rq_email.Rows.Add(aRow);
                    }
                }
                
                foreach (DataRow Row0 in rq_email.Rows)
                {
                    string strnobr = Row0["nobr"].ToString();

                    DataRow[] attendnobr = rq_attend.Select("nobr='" + strnobr + "'", "adate desc");
                    foreach (DataRow Row3 in attendnobr)
                    {
                        DataRow aRow1 = Dt.NewRow();
                        aRow1["員工編號"] = Row3["nobr"].ToString();
                        aRow1["員工姓名"] = Row3["name_c"].ToString();
                        aRow1["部門代碼"] = (Row3.IsNull("d_no_disp")) ? "" : Row3["d_no_disp"].ToString();
                        aRow1["部門名稱"] = (Row3.IsNull("d_name")) ? "" : Row3["d_name"].ToString();
                        aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = Row3["rote"].ToString() ;
                        aRow1["上班時間"] = Row3["on_time"].ToString();
                        aRow1["下班時間"] = Row3["off_time"].ToString();
                        aRow1["實際上班時間"] = Row3["on_time_actual"].ToString();
                        aRow1["實際下班時間"] = Row3["off_time_actual"].ToString();
                        aRow1["異常類型"] = Row3["typename"].ToString();
                        aRow1["異常分鐘數"] = decimal.Parse(Row3["error_mins"].ToString());
                        Dt.Rows.Add(aRow1);
                    }                   
                    if (Dt.Rows.Count > 0)
                    {
                        string html = ConvertDataTableToHtml(Dt, Row0["nobr"].ToString());
                        try
                        {
                            string _Email = Row0["email"].ToString();
                            string _NobrName = Row0["name_c"].ToString();
                            //string _Subject = date_b + "  - " + date_e + "出勤刷卡時間異常通知";
                            string _Subject = date_e + "截止" + "出勤刷卡時間異常通知";

                            //判斷是否為測試模式
                            if (!TestMode)
                            {
                                if (Row0["email"].ToString().Trim() != "")
                                {
                                    Smail.AddMailQueueWithFileService(_Email, _Subject, html, listFild);
                                    ErrorUtility.WriteLog("刷卡時間異常寄發信件到員工編號：" + Row0["nobr"].ToString() + "->" + _Email);
                                }
                                else
                                {
                                    ErrorUtility.WriteLog("刷卡時間異常寄發信件到員工編號：" + Row0["nobr"].ToString() + "失敗：未設置信箱地址");
                                }
                            }
                            //若為測試模式則將郵件寄送到測試郵件地址
                            else
                            {
                                if(TestMail != "")
                                {
                                    Smail.AddMailQueueWithFileService(TestMail, _Subject, html, listFild);
                                    ErrorUtility.WriteLog("刷卡時間異常寄發信件到員工編號：" + Row0["nobr"].ToString() + "->" + TestMail);
                                }
                                else
                                {
                                    ErrorUtility.WriteLog("失敗：未設置測試信箱地址");
                                }
                            }
                        }
                        catch (Exception Ex)
                        {
                            ErrorUtility.WriteLog(Ex, "");
                            continue;
                        }
                    }
                    Dt.Clear();
                }
                Conn.Dispose();
                Cmd.Dispose();
                rq_attend = null;
            }
            catch (Exception E)
            {
                ErrorUtility.WriteLog(E, "");
            }
        }

        public static string ConvertDataTableToHtml(DataTable dt,string Nobr)
        {
            string BodyTop = string.Empty;
            //通知內容頁首/頁尾
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\Body.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("AttTopA"))
                    {
                        string[] _body = line.Split('#');
                        if (_body.Length > 1)
                        {
                            BodyTop = _body[1];
                            BodyTop = BodyTop.Replace("{NOBR}", Nobr);
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
