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

    class SendAttend3
    {
        private static SqlConnection GetConn()
        {
            string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["ArborConnectionString"];
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);
            return Con;
        }

        public static void DoSend()
        {            
            DataTable HRDt = new DataTable();
            DataTable Dt = new DataTable();
            //Dt.Columns.Add("部門代碼", typeof(string));
            //Dt.Columns.Add("部門名稱", typeof(string));
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
            //Dt.Columns.Add("單位", typeof(string));
            Dt.Columns.Add("加起時間", typeof(string));
            Dt.Columns.Add("加迄時間", typeof(string));
            Dt.Columns.Add("加班時數", typeof(decimal));
            Dt.Columns.Add("補休時數", typeof(decimal));
            Dt.Columns.Add("忘刷", typeof(decimal));
            Dt.Columns.Add("遲到(分)", typeof(decimal));
            Dt.Columns.Add("早退(分)", typeof(decimal));
            Dt.Columns.Add("曠職", typeof(string));
            //Dt.Columns.Add("夜班時數", typeof(decimal));
            //Dt.Columns.Add("夜班津貼", typeof(decimal));
            //Dt.Columns.Add("夜點費", typeof(decimal));           
            try
            {
                SqlConnection Conn = null;
                SqlCommand Cmd = null;
                Conn = SendAttend3.GetConn();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                string date_e = "";
                string date_b = "";
                string MonthDayB = ConfigurationSettings.AppSettings["MonthDayB"];
                string MonthDayE = ConfigurationSettings.AppSettings["MonthDayE"];
                int _Day = DateTime.Now.Day;
                //if (_Day >= int.Parse(MonthDayE) && _Day <= int.Parse(MonthDayB))
                if (_Day == int.Parse(MonthDayB))
                {
                    DateTime date_t = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(DateTime.Now.Month) + "/" + MonthDayB);
                    date_e = date_t.AddDays(-1).ToString("yyyy/MM/dd");
                    date_b = date_t.AddMonths(-1).ToString("yyyy/MM/dd");

                    if (_Day != int.Parse(MonthDayB))
                    {
                        date_e = Convert.ToDateTime(DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");
                        //date_b = Convert.ToDateTime(Convert.ToDateTime(date_b).AddDays(-1)).ToString("yyyy/MM/dd");
                    }
                }
                else
                {
                    date_e = Convert.ToDateTime(DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");
                    date_b = Convert.ToDateTime(DateTime.Now.AddDays(-1)).ToString("yyyy/MM/dd");
                }


                DataTable rq_attend = new DataTable();
                //出勤名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,a.rote,a.late_mins,a.e_mins,a.abs,a.night_hrs,a.foodamt,a.forget," +
                    "b.dept,c.d_name,d.email1 as email" +
                    " from attend a,basetts b,dept c,base d where " +
                    " a.nobr=b.nobr and b.nobr=d.nobr and b.dept=c.d_no and '" + date_e + "' between b.adate and b.ddate" +
                    " and a.adate between '" + date_b + "' and '" + date_e + "'" +
                    " and b.card='Y' and d.email1<>'' and a.rote<>'00'" +
                    " order by b.dept,a.nobr,a.adate";
                Cmd.CommandText = CmdAttend;
                SqlDataAdapter SCmd1 = new SqlDataAdapter(Cmd);
                SCmd1.Fill(rq_attend);
                //ErrorUtility.WriteLog("本日出勤異常同仁共有：" + rq_attend.Rows.Count.ToString());

                DataTable rq_email = new DataTable();
                rq_email.Columns.Add("nobr", typeof(string));
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
                    try
                    {
                        string strnobr = Row0["nobr"].ToString();
                        //卡鐘資料
                        string CmdCard = "select a.nobr,a.adate,a.tt1,a.tt2 from attcard a,basetts b where a.nobr=b.nobr" +
                            " and '" + date_e + "' between b.adate and b.ddate" +
                            " and a.adate between '" + date_b + "' and '" + date_e + "'" +
                            " and a.nobr='" + strnobr + "'";
                        Cmd.CommandText = CmdCard;
                        SqlDataAdapter SCmd2 = new SqlDataAdapter(Cmd);
                        DataTable rq_card = new DataTable();
                        SCmd2.Fill(rq_card);
                        rq_card.PrimaryKey = new DataColumn[] { rq_card.Columns["nobr"], rq_card.Columns["adate"] };

                        //請假資料
                        string CmdAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,a.h_code,a.tol_hours,c.h_name,c.mang,c.unit,c.not_sum" +
                            " from abs a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code" +
                            " and '" + date_e + "' between b.adate and b.ddate" +
                            " and a.bdate between '" + date_b + "' and '" + date_e + "'" +
                            " and a.nobr='" + strnobr + "'" +
                            " and c.mang <> 1";
                        Cmd.CommandText = CmdAbs;
                        SqlDataAdapter SCmd3 = new SqlDataAdapter(Cmd);
                        DataTable rq_abs = new DataTable();
                        SCmd3.Fill(rq_abs);

                        //取得出公差資料
                        string CmdAbs1 = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,a.h_code,a.tol_hours,c.h_name" +
                            " from abs1 a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code" +
                            " and a.bdate between b.adate and b.ddate" +
                            " and '" + date_e + "' between b.adate and b.ddate" +
                            " and a.bdate between '" + date_b + "' and '" + date_e + "'" +
                            " and a.nobr='" + strnobr + "'" +
                            " order by a.nobr,a.bdate,a.etime";
                        Cmd.CommandText = CmdAbs1;
                        SqlDataAdapter SCmd4 = new SqlDataAdapter(Cmd);
                        DataTable rq_abs1 = new DataTable();
                        SCmd4.Fill(rq_abs1);
                        foreach (DataRow Row4 in rq_abs1.Rows)
                        {
                            rq_abs.ImportRow(Row4);
                        }

                        //DataTable rq_absj = new DataTable();
                        //rq_absj = rq_abs.Clone();
                        //rq_absj.TableName = "rq_absj";
                        //DataRow [] row1 = rq_abs.Select("h_code in ('J1','J2','J3')");
                        //foreach (DataRow Row5 in row1)
                        //{
                        //    rq_absj.ImportRow(Row5);
                        //}

                        //加班
                        string CmdOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs from ot a,basetts b where a.nobr=b.nobr" +
                            " and '" + date_e + "' between b.adate and b.ddate" +
                            " and a.bdate between '" + date_b + "' and '" + date_e + "'" +
                            " and a.nobr='" + strnobr + "'";
                        Cmd.CommandText = CmdOt;
                        SqlDataAdapter SCmd5 = new SqlDataAdapter(Cmd);
                        DataTable rq_ot = new DataTable();
                        SCmd5.Fill(rq_ot);

                        //DataTable rq_zz21t = new DataTable();
                        //rq_zz21t.Columns.Add("nobr", typeof(string));
                        //rq_zz21t.Columns.Add("night_hrs", typeof(decimal));
                        //rq_zz21t.Columns.Add("foodamt", typeof(decimal));
                        //rq_zz21t.Columns.Add("nigamt", typeof(decimal));
                        //rq_zz21t.PrimaryKey = new DataColumn[] { rq_zz21t.Columns["nobr"] };
                        //foreach (DataRow Row6 in rq_attend.Rows)
                        //{
                        //    DataRow row = rq_zz21t.Rows.Find(Row6["nobr"].ToString());
                        //    if (row != null)
                        //    {
                        //        row["night_hrs"] = decimal.Parse(row["night_hrs"].ToString()) + decimal.Parse(Row6["night_hrs"].ToString());
                        //        row["foodamt"] = decimal.Parse(row["foodamt"].ToString()) + decimal.Parse(Row6["foodamt"].ToString());
                        //        row["nigamt"] = decimal.Parse(row["nigamt"].ToString()) + decimal.Parse(Row6["nigamt"].ToString());
                        //    }
                        //    else
                        //    {
                        //        DataRow aRow = rq_zz21t.NewRow();
                        //        aRow["nobr"] = Row6["nobr"].ToString();
                        //        aRow["night_hrs"] = decimal.Parse(Row6["night_hrs"].ToString());
                        //        aRow["foodamt"] = decimal.Parse(Row6["foodamt"].ToString());
                        //        aRow["nigamt"] = decimal.Parse(Row6["nigamt"].ToString());
                        //        rq_zz21t.Rows.Add(aRow);
                        //    }
                        //}

                        DataRow[] attendnobr = rq_attend.Select("nobr='" + strnobr + "'");
                        foreach (DataRow Row3 in attendnobr)
                        {
                            string str_bdate = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                            DataRow[] row = rq_ot.Select("nobr='" + Row3["nobr"].ToString() + "' and bdate='" + str_bdate + "'");
                            DataRow[] row3 = rq_abs.Select("nobr='" + Row3["nobr"].ToString() + "'  and bdate='" + str_bdate + "'");
                            object[] _value = new object[2];
                            _value[0] = Row3["nobr"].ToString();
                            _value[1] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                            DataRow row2 = rq_card.Rows.Find(_value);
                            string str_btime = "";
                            string str_etime = "";
                            if (row2 != null)
                            {
                                str_btime = row2["tt1"].ToString();
                                str_etime = row2["tt2"].ToString();
                            }

                            if (row.Length == 0 && row3.Length == 0)
                            {
                                DataRow aRow1 = Dt.NewRow();
                                aRow1["員工編號"] = Row3["nobr"].ToString();
                                aRow1["員工姓名"] = Row3["name_c"].ToString();
                                //aRow1["部門代碼"] = Row3["dept"].ToString();
                                //aRow1["部門名稱"] = Row3["d_name"].ToString();
                                aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                aRow1["班別"] = Row3["rote"].ToString();
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
                                aRow1["曠職"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
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
                                        //aRow2["部門代碼"] = Row3["dept"].ToString();
                                        //aRow2["部門名稱"] = Row3["d_name"].ToString();
                                        aRow2["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                        aRow2["班別"] = Row3["rote"].ToString();
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
                                        aRow2["曠職"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
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
                                        //aRow3["部門代碼"] = Row3["dept"].ToString();
                                        //aRow3["部門名稱"] = Row3["d_name"].ToString();
                                        aRow3["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                        aRow3["班別"] = Row3["rote"].ToString();
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
                                        aRow3["曠職"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
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
                            HRDt.Merge(Dt);
                            string html = ConvertDataTableToHtml(Dt, date_b, MonthDayB);
                            try
                            {
                                string _Subject = date_b + "個人" + "個人出勤明細表";
                                if (_Day == int.Parse(MonthDayB))
                                    _Subject = DateTime.Parse(date_b).ToString("yyyy/MM") + "個人" + "個人出勤明細表";
                                if (ConfigurationSettings.AppSettings["TestSubject"] != "")
                                    _Subject += ConfigurationSettings.AppSettings["TestSubject"];

                                if (ConfigurationSettings.AppSettings["TestMail"] == "")
                                {
                                    if (Row0["email"].ToString().Trim() != "")
                                    {
                                        SendMail(Row0["email"].ToString(), _Subject, html);
                                    }
                                    //SendMail(ConfigurationSettings.AppSettings["HRMail"],  _Subject, html);
                                    //SendMail(ConfigurationSettings.AppSettings["HRMail1"],  _Subject, html);
                                    //SendMail(ConfigurationSettings.AppSettings["HRMail2"],  _Subject, html);
                                }
                                else
                                    SendMail(ConfigurationSettings.AppSettings["TestMail"], _Subject, html);

                                ErrorUtility.WriteLog("寄發信件到員工編號：" + Row0["nobr"].ToString() + "->" + Row0["email"].ToString());

                            }
                            catch (Exception Ex)
                            {
                                ErrorUtility.WriteLog(Ex, "");
                                continue;
                            }
                        }
                        Dt.Clear();
                    }
                    catch (Exception Ex)
                    {
                        ErrorUtility.WriteLog(Ex, "");
                        continue;
                    }
                }

                //HR人員只發一封信
                if (HRDt.Rows.Count > 0 && ConfigurationSettings.AppSettings["TestMail"] == "")
                {
                    string _Subject = date_b + "個人" + "個人出勤明細表";
                    if (_Day == int.Parse(MonthDayB))
                        _Subject = DateTime.Parse(date_b).ToString("yyyy/MM") + "個人" + "個人出勤明細表";
                    if (ConfigurationSettings.AppSettings["TestSubject"] != "")
                        _Subject += ConfigurationSettings.AppSettings["TestSubject"];
                    string html = ConvertDataTableToHtml(HRDt, date_b, MonthDayB);
                    HRDt.Clear();
                    SendMail(ConfigurationSettings.AppSettings["TestMail"], _Subject, html);
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

        public static string ConvertDataTableToHtml(DataTable dt, string date_b, string MonthDayB)
        {
            int i = 0;
            string body = "<font color=blue><BR>若有出勤異常的同仁請立即補單!</font><BR>";
            if (DateTime.Now.Day == int.Parse(MonthDayB))
                body = "<font color=blue><BR>請再次確認本月出勤是否有異常，若有異常請立即補單，TKS!</font><BR>";
            //string body = "<BR><font color=blue>Dears,<BR>1、下表為 " + date_b + "  出勤異常表，請同仁上GP系統提出假單申請，若已發送相關表單者，請忽略此郵件。";
            //body += "<BR>2、本郵件由系統發送，請勿直接回覆，如有任何問題請洽管理部HR人員。</font><BR>";
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
