/* ======================================================================================================
 * 功能名稱：出勤異常通知 - 個人
 * 功能代號：
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\工具程式\SendAttend\SendAttend.cs
 * 功能用途：
 *  用於發送出勤異常通知到員工個人信箱
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

namespace sendAttendMail
{
    class SendAttend
    {
        private static SqlConnection GetConn()
        {
            //string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["SchmidConnectionString"];
            string SQL_CONNECTION_STRING = ConfigSetting.ConnectionString("JBHR.Properties.Settings.JBHRConnectionString").ToString();
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);
            return Con;
        }

        public static void DoSend(DateTime beginDate, DateTime endDate, bool TestMode, string TestMail)
        {
            List<Attachment> listFild = new List<Attachment>();
            DataTable Dt = new DataTable();
            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
            Dt.Columns.Add("部門代碼", typeof(string));
            Dt.Columns.Add("部門名稱", typeof(string));
            Dt.Columns.Add("員工編號", typeof(string));
            Dt.Columns.Add("員工姓名", typeof(string));
            Dt.Columns.Add("出勤日期", typeof(string));
            Dt.Columns.Add("班別", typeof(string));
            Dt.Columns.Add("上班時間", typeof(string));
            Dt.Columns.Add("下班時間", typeof(string));
            Dt.Columns.Add("假別名稱", typeof(string));
            Dt.Columns.Add("請起時間", typeof(string));
            Dt.Columns.Add("請迄時間", typeof(string));
            Dt.Columns.Add("請假時數", typeof(decimal));
            Dt.Columns.Add("加起時間", typeof(string));
            Dt.Columns.Add("加迄時間", typeof(string));
            Dt.Columns.Add("加班時數", typeof(decimal));
            Dt.Columns.Add("補休時數", typeof(decimal));
            Dt.Columns.Add("忘刷", typeof(decimal));
            Dt.Columns.Add("遲到(分)", typeof(decimal));
            Dt.Columns.Add("早退(分)", typeof(decimal));
            Dt.Columns.Add("異常", typeof(string));

            try
            {
                SqlConnection Conn = null;
                SqlCommand Cmd = null;
                Conn = SendAttend.GetConn();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                string date_e = "";
                string date_b = "";
                string MonthDayB = ConfigurationSettings.AppSettings["MonthDayB"];
                string MonthDayE = ConfigurationSettings.AppSettings["MonthDayE"];
                string AttMonth = ConfigurationSettings.AppSettings["AttMonth"];
                string ExcludeDept = "";
                //排除的編制部門
                if (string.IsNullOrEmpty(ConfigurationSettings.AppSettings["ExcludeDept"].Trim()))
                {
                    ExcludeDept = "";
                }
                else
                {
                    ExcludeDept = "'" + ConfigurationSettings.AppSettings["ExcludeDept"].Trim().Replace(",", "', '") + "'";
                }

                //抓取hr郵件參數設定天數
                string MailFrom = "";
                string TestAccount = "";
                string Dept = "Dept";
                int attinterval = 0; //出勤異常表通知內容間隔區間天數 

                DataTable rq_parameter = new DataTable();
                string Cmdparameter = "select code,value from Parameter where code in ('JbMail.DateInteval','JbMail.sys_mail','JbMail.TestAccount','JbMail.Sender','JbMail.Department','JbMail.AttInteval')";
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
                    else if (Row["code"].ToString().Trim() == "JbMail.AttInteval")
                        attinterval = int.Parse(Row["value"].ToString().Trim());
                }
                int _Day = DateTime.Now.Day;
                int attmonth = 31;
                if (!string.IsNullOrEmpty(AttMonth))
                    attmonth = Convert.ToInt32(AttMonth);
                //_Day = 1;

                //開始日期
                date_b = beginDate.ToString("yyyy/MM/dd");
                //結束日期
                date_e = endDate.ToString("yyyy/MM/dd");

                #region 備註折疊
                //if (attinterval != 0)
                //    date_b = DateTime.Now.AddDays(fewday + attinterval).ToString("yyyy/MM/dd");
                //else
                //{
                //    if (attmonth > 0)
                //    {
                //        if (attmonth == 31)
                //            attmonth = 1;
                //        else
                //            attmonth += 1;
                //        DateTime date_t = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(DateTime.Now.Month) + "/" + attmonth.ToString());
                //        //date_e = date_t.AddDays(-1).ToString("yyyy/MM/dd");
                //        if (_Day <= attmonth) //_Day ==1
                //        {
                //            date_b = date_t.AddMonths(-1).ToString("yyyy/MM/dd");
                //        }
                //        else
                //        {
                //            date_b = date_t.ToString("yyyy/MM/dd");
                //        }
                //    }
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
                string CmdAttend = "select a.nobr,d.name_c,a.adate,a.rote,a.late_mins,a.e_mins,a.abs,a.night_hrs,a.foodamt,a.forget,";
                CmdAttend += string.Format(@"{0},c.d_no_disp,c.d_name,d.email", Dept);
                CmdAttend += " from base d,attend a,basetts b ";
                CmdAttend += dept_rela;
                CmdAttend += " where a.nobr=b.nobr and b.nobr=d.nobr";

                if (!string.IsNullOrEmpty(ExcludeDept))
                {
                    CmdAttend += string.Format(@" and c.d_no_disp not in ({0})", ExcludeDept);
                }

                CmdAttend += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdAttend += " and (a.late_mins!=0 or a.e_mins!=0 or abs=1 )";
                CmdAttend += " and b.card='Y' and d.email<>'' and a.rote not in ('00','0X','0Z')";
                CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);
                Cmd.CommandText = CmdAttend;
                SqlDataAdapter SCmd1 = new SqlDataAdapter(Cmd);
                SCmd1.Fill(rq_attend);
                //ErrorUtility.WriteLog("本日出勤異常同仁共有：" + rq_attend.Rows.Count.ToString());


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
                        aRow["email"] = Row["email"].ToString().Trim();
                        //aRow["deptmail"] = Row["deptmail"].ToString();
                        rq_email.Rows.Add(aRow);
                    }
                }

                foreach (DataRow Row0 in rq_email.Rows)
                {
                    string strnobr = Row0["nobr"].ToString();
                    //卡鐘資料
                    string CmdCard = "select a.nobr,a.adate,a.t1,a.t2,a.tt1,a.tt2 from attcard a,basetts b where a.nobr=b.nobr";
                    CmdCard += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdCard += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                    CmdCard += string.Format(@" and a.nobr='{0}'", strnobr);
                    Cmd.CommandText = CmdCard;
                    SqlDataAdapter SCmd2 = new SqlDataAdapter(Cmd);
                    DataTable rq_card = new DataTable();
                    SCmd2.Fill(rq_card);
                    rq_card.PrimaryKey = new DataColumn[] { rq_card.Columns["nobr"], rq_card.Columns["adate"] };

                    //請假資料
                    string CmdAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,a.h_code,a.tol_hours,c.h_name,c.mang,c.unit,c.not_sum";
                    CmdAbs += " from abs a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code";
                    CmdAbs += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                    CmdAbs += string.Format(@" and a.nobr='{0}'", strnobr);
                    CmdAbs += " and c.mang <> 1";
                    Cmd.CommandText = CmdAbs;
                    SqlDataAdapter SCmd3 = new SqlDataAdapter(Cmd);
                    DataTable rq_abs = new DataTable();
                    SCmd3.Fill(rq_abs);

                    //取得出公差資料
                    string CmdAbs1 = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,a.h_code,a.tol_hours,c.h_name";
                    CmdAbs1 += " from abs1 a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code";
                    CmdAbs1 += " and a.bdate between b.adate and b.ddate";
                    CmdAbs1 += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdAbs1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                    CmdAbs1 += string.Format(@" and a.nobr='{0}'", strnobr);
                    CmdAbs1 += " order by a.nobr,a.bdate,a.etime";
                    Cmd.CommandText = CmdAbs1;
                    SqlDataAdapter SCmd4 = new SqlDataAdapter(Cmd);
                    DataTable rq_abs1 = new DataTable();
                    SCmd4.Fill(rq_abs1);
                    foreach (DataRow Row4 in rq_abs1.Rows)
                    {
                        rq_abs.ImportRow(Row4);
                    }


                    //加班
                    string CmdOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs from ot a,basetts b where a.nobr=b.nobr";
                    CmdOt += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                    CmdOt += string.Format(@" and a.nobr='{0}'", strnobr);
                    Cmd.CommandText = CmdOt;
                    SqlDataAdapter SCmd5 = new SqlDataAdapter(Cmd);
                    DataTable rq_ot = new DataTable();
                    SCmd5.Fill(rq_ot);
                    DataRow[] attendnobr = rq_attend.Select("nobr='" + strnobr + "'");
                    foreach (DataRow Row3 in attendnobr)
                    {
                        string str_bdate = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        DataRow[] row = rq_ot.Select("nobr='" + Row3["nobr"].ToString() + "' and bdate='" + str_bdate + "'");
                        DataRow[] row3 = rq_abs.Select("nobr='" + Row3["nobr"].ToString() + "'  and bdate='" + str_bdate + "'");
                        DataRow row4 = rq_rote.Rows.Find(Row3["rote"].ToString());
                        string rotename = string.Empty;
                        if (row4 != null)
                        {
                            Row3["rote"] = row4["rote_disp"].ToString();
                            rotename = row4["rotename"].ToString();
                        }

                        object[] _value = new object[2];
                        _value[0] = Row3["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        DataRow row2 = rq_card.Rows.Find(_value);
                        string str_btime = "";
                        string str_etime = "";
                        if (row2 != null)
                        {
                            str_btime = row2["t1"].ToString();
                            str_etime = row2["t2"].ToString();
                        }

                        if (row.Length == 0 && row3.Length == 0)
                        {
                            DataRow aRow1 = Dt.NewRow();
                            aRow1["員工編號"] = Row3["nobr"].ToString();
                            aRow1["員工姓名"] = Row3["name_c"].ToString();
                            aRow1["部門代碼"] = Row3["d_no_disp"].ToString();
                            aRow1["部門名稱"] = Row3["d_name"].ToString();
                            aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                            aRow1["班別"] = Row3["rote"].ToString() + " (" + rotename + ")";
                            aRow1["上班時間"] = str_btime;
                            aRow1["下班時間"] = str_etime;
                            //aRow1["假別名稱"] = "";
                            //aRow1["請起時間"] = "";
                            //aRow1["請迄時間"] = "";
                            //aRow1["請假時數"] = 0;
                            //aRow1["單位"] = "";
                            //aRow1["加起時間"] = "";
                            //aRow1["加迄時間"] = "";
                            //aRow1["加班時數"] = 0;
                            //aRow1["補休時數"] = 0;
                            aRow1["忘刷"] = decimal.Round(decimal.Parse(Row3["forget"].ToString()), 0);
                            aRow1["遲到(分)"] = decimal.Parse(Row3["late_mins"].ToString());
                            aRow1["早退(分)"] = decimal.Parse(Row3["e_mins"].ToString());
                            aRow1["異常"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
                            //aRow1["夜班時數"] = decimal.Round(decimal.Parse(Row3["night_hrs"].ToString()), 1);
                            //aRow1["夜班津貼"] = decimal.Round(decimal.Parse(Row3["nigamt"].ToString()),1);
                            //aRow1["夜點費"] = decimal.Parse(Row3["foodamt"].ToString());
                            Dt.Rows.Add(aRow1);
                        }
                        else
                        {
                            if (row.Length > row3.Length)
                            {
                                for (int i = 0; i < row.Length; i++)
                                {
                                    DataRow aRow2 = Dt.NewRow();
                                    aRow2["員工編號"] = Row3["nobr"].ToString();
                                    aRow2["員工姓名"] = Row3["name_c"].ToString();
                                    aRow2["部門代碼"] = Row3["d_no_disp"].ToString();
                                    aRow2["部門名稱"] = Row3["d_name"].ToString();
                                    aRow2["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                    aRow2["班別"] = Row3["rote"].ToString() + " (" + rotename + ")";
                                    aRow2["上班時間"] = str_btime;
                                    aRow2["下班時間"] = str_etime;
                                    aRow2["加起時間"] = row[i]["btime"].ToString(); ;
                                    aRow2["加迄時間"] = row[i]["etime"].ToString();
                                    aRow2["加班時數"] = decimal.Parse(row[i]["ot_hrs"].ToString());
                                    aRow2["補休時數"] = decimal.Parse(row[i]["rest_hrs"].ToString());
                                    if (row3.Length > 0 && i < row3.Length)
                                    {
                                        aRow2["假別名稱"] = row3[i]["h_name"].ToString();
                                        aRow2["請起時間"] = row3[i]["btime"].ToString();
                                        aRow2["請迄時間"] = row3[i]["etime"].ToString();
                                        aRow2["請假時數"] = decimal.Parse(row3[i]["tol_hours"].ToString());
                                        //aRow2["單位"] = row3[i]["unit"].ToString();
                                    }
                                    aRow2["忘刷"] = decimal.Round(decimal.Parse(Row3["forget"].ToString()), 0);
                                    aRow2["遲到(分)"] = decimal.Parse(Row3["late_mins"].ToString());
                                    aRow2["早退(分)"] = decimal.Parse(Row3["e_mins"].ToString());
                                    aRow2["異常"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
                                    //aRow2["夜班時數"] = decimal.Round(decimal.Parse(Row3["night_hrs"].ToString()), 1);
                                    //aRow2["夜班津貼"] = decimal.Round(decimal.Parse(Row3["nigamt"].ToString()),1);
                                    //aRow2["夜點費"] = decimal.Parse(Row3["foodamt"].ToString());
                                    Dt.Rows.Add(aRow2);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < row3.Length; i++)
                                {
                                    DataRow aRow3 = Dt.NewRow();
                                    aRow3["員工編號"] = Row3["nobr"].ToString();
                                    aRow3["員工姓名"] = Row3["name_c"].ToString();
                                    aRow3["部門代碼"] = Row3["d_no_disp"].ToString();
                                    aRow3["部門名稱"] = Row3["d_name"].ToString();
                                    aRow3["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                    aRow3["班別"] = Row3["rote"].ToString() + " (" + rotename + ")";
                                    aRow3["上班時間"] = str_btime;
                                    aRow3["下班時間"] = str_etime;
                                    aRow3["假別名稱"] = row3[i]["h_name"].ToString();
                                    aRow3["請起時間"] = row3[i]["btime"].ToString();
                                    aRow3["請迄時間"] = row3[i]["etime"].ToString();
                                    aRow3["請假時數"] = decimal.Parse(row3[i]["tol_hours"].ToString());
                                    //aRow3["單位"] = row3[i]["unit"].ToString();
                                    if (row.Length > 0 && i < row.Length)
                                    {
                                        aRow3["加起時間"] = row[i]["btime"].ToString();
                                        aRow3["加迄時間"] = row[i]["etime"].ToString();
                                        aRow3["加班時數"] = decimal.Parse(row[i]["ot_hrs"].ToString());
                                        aRow3["補休時數"] = decimal.Parse(row[i]["rest_hrs"].ToString());
                                    }
                                    aRow3["忘刷"] = decimal.Round(decimal.Parse(Row3["forget"].ToString()), 0);
                                    aRow3["遲到(分)"] = decimal.Parse(Row3["late_mins"].ToString());
                                    aRow3["早退(分)"] = decimal.Parse(Row3["e_mins"].ToString());
                                    aRow3["異常"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
                                    //aRow3["夜班時數"] = decimal.Round(decimal.Parse(Row3["night_hrs"].ToString()), 1);                               
                                    //aRow3["夜點費"] = decimal.Parse(Row3["foodamt"].ToString());
                                    Dt.Rows.Add(aRow3);
                                }
                            }
                        }
                    }
                    rq_card = null;
                    //rq_dataid = null;
                    rq_ot = null;
                    rq_abs1 = null;
                    rq_abs = null;
                    if (Dt.Rows.Count > 0)
                    {
                        string html = ConvertDataTableToHtml(Dt, Row0["nobr"].ToString(), date_b, date_e, "");
                        try
                        {
                            string _Email = Row0["email"].ToString();
                            string _NobrName = Row0["name_c"].ToString();
                            string _Subject = date_b + "  - " + date_e + "出勤異常表通知";

                            if (!TestMode)
                            {
                                if (Row0["email"].ToString().Trim() != "")
                                {
                                    //SendMail(Row0["email"].ToString(), date_b + _Subject, html);
                                    //Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(_Email, _NobrName), _Subject, html);
                                    Smail.AddMailQueueWithFileService(_Email, _Subject, html, listFild);
                                    ErrorUtility.WriteLog("寄發信件到員工編號：" + Row0["nobr"].ToString() + "->" + _Email);
                                }
                                else
                                {
                                    ErrorUtility.WriteLog("寄發信件到員工編號" + Row0["nobr"].ToString() + "失敗：未設置信箱地址");
                                }
                            }
                            else
                            {
                                if(TestMail != "")
                                {
                                    //Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(TestAccount, "測試信箱"), _Subject, html);
                                    Smail.AddMailQueueWithFileService(TestMail, _Subject, html, listFild);//     Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(TestAccount, "測試信箱"), _Subject, html);
                                    ErrorUtility.WriteLog("寄發信件到員工編號：" + Row0["nobr"].ToString() + "->" + TestMail);
                                }
                                else
                                {
                                    ErrorUtility.WriteLog("失敗：未設置測試郵件地址");
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

        public static string ConvertDataTableToHtml(DataTable dt, string nobr, string date_b, string date_e, string MonthDayB)
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
                            BodyTop = BodyTop.Replace("{Nobr}", nobr);
                            BodyTop = BodyTop.Replace("{DateB}", DateTime.Parse(date_b).ToString("yyyyMMdd"));
                            BodyTop = BodyTop.Replace("{DateE}", DateTime.Parse(date_e).ToString("yyyyMMdd"));
                        }
                    }

                }
            }
            int i = 0;
            //string body = "<font color=black size=5><BR><B>您(" + nobr + ")" + DateTime.Parse(date_b).ToString("yyyyMMdd") + "~" + DateTime.Parse(date_e).ToString("yyyyMMdd") + "的出勤資料有異常，請查照下表</font><BR></B><BR></BR>";
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
                        //if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                        if (dc.ColumnName.ToString() == "出勤日期")
                            body += "<td width=\"70px\">" + dc.ColumnName + "</td>";
                        else
                            body += "<td><B>" + dc.ColumnName + "</B></td>";
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


        public static void SendMail(string to, string subject, string body)
        {
            string mailServerName = ConfigurationSettings.AppSettings["MailServerName"];
            string from = ConfigurationSettings.AppSettings["MailFrom"];
            bool isUseDefaultCredentials = bool.Parse(ConfigurationSettings.AppSettings["UseCredentials"]);
            string strFrom = ConfigurationSettings.AppSettings["MailUserName"];
            string strFromPass = ConfigurationSettings.AppSettings["MailPassWord"];

            if (!isEmail(to))
            {
                ErrorUtility.WriteLog("非正常email- " + to);
                return;
            }


            try
            {
                using (MailMessage message =
                    new MailMessage(from, to, subject, body))
                {
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.High;
                    message.BodyEncoding = System.Text.Encoding.Default;
                    message.SubjectEncoding = System.Text.Encoding.Default;

                    SmtpClient mailClient = new SmtpClient(mailServerName);
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    if (!isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
                    else
                    {
                        mailClient.Port = 25;
                        mailClient.UseDefaultCredentials = false;
                        mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
                    }

                    mailClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                ErrorUtility.WriteLog(ex, to);
            }
        }

        private static bool isEmail(string email)
        {
            if (Regex.IsMatch(email, RegularExp.Email))
                return true;
            else
                return false;
        }

        public struct RegularExp
        {
            public const string Chinese = @"^[\u4E00-\u9FA5\uF900-\uFA2D]+$";
            public const string Color = "^#[a-fA-F0-9]{6}";
            public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
            public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
            public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            public const string Float = @"^(-?\d+)(\.\d+)?$";
            public const string ImageFormat = @"\.(?i:jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
            public const string Integer = @"^-?\d+$";
            public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            public const string Letter = "^[A-Za-z]+$";
            public const string LowerLetter = "^[a-z]+$";
            public const string MinusFloat = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
            public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";
            public const string Mobile = "^0{0,1}13[0-9]{9}$";
            public const string NumbericOrLetterOrChinese = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$";
            public const string Numeric = "^[0-9]+$";
            public const string NumericOrLetter = "^[A-Za-z0-9]+$";
            public const string NumericOrLetterOrUnderline = @"^\w+$";
            public const string PlusFloat = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
            public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";
            public const string Telephone = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";
            public const string UnMinusFloat = @"^\d+(\.\d+)?$";
            public const string UnMinusInteger = @"\d+$";
            public const string UnPlusFloat = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";
            public const string UnPlusInteger = @"^((-\d+)|(0+))$";
            public const string UpperLetter = "^[A-Z]+$";
            public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
        }
    }
}
