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
    class SendAttend4
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
            DataTable Dt = new DataTable();           
            Dt.Columns.Add("員工編號", typeof(string));
            Dt.Columns.Add("員工姓名", typeof(string));
            Dt.Columns.Add("日期", typeof(string));
            Dt.Columns.Add("班別", typeof(string));
            Dt.Columns.Add("進卡", typeof(string));
            Dt.Columns.Add("出卡", typeof(string));
            Dt.Columns.Add("異常", typeof(string));
            Dt.Columns.Add("請假", typeof(string));
            try
            {
                SqlConnection Conn = null;
                SqlCommand Cmd = null;
                Conn = SendAttend4.GetConn();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                string date_e = "";
                string date_b = "";
                string MonthDayB = ConfigurationSettings.AppSettings["MonthDayB"];
                string MonthDayE = ConfigurationSettings.AppSettings["MonthDayE"];

                //抓取hr郵件參數設定天數
                DataTable rq_parameter = new DataTable();
                string Cmdparameter = "select value from Parameter where code='JbMail.DateInteval' ";
                Cmd.CommandText = Cmdparameter;
                SqlDataAdapter SCmd0 = new SqlDataAdapter(Cmd);
                SCmd0.Fill(rq_parameter);
                int fewday = -3;
                if (rq_parameter.Rows.Count > 0)
                    fewday = int.Parse(rq_parameter.Rows[0]["value"].ToString());

                int _Day = DateTime.Now.Day;
                //if (_Day >= int.Parse(MonthDayE) && _Day <= int.Parse(MonthDayB))
                if (_Day == int.Parse(MonthDayB))
                {
                    DateTime date_t = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "/" + Convert.ToString(DateTime.Now.Month) + "/" + MonthDayB);
                    date_e = date_t.AddDays(-1).ToString("yyyy/MM/dd");
                    date_b = date_t.AddMonths(-1).ToString("yyyy/MM/dd");

                    if (_Day != int.Parse(MonthDayB))
                    {
                        date_e = Convert.ToDateTime(DateTime.Now.AddDays(fewday)).ToString("yyyy/MM/dd");
                        //date_b = Convert.ToDateTime(Convert.ToDateTime(date_b).AddDays(-1)).ToString("yyyy/MM/dd");
                    }
                }
                else
                {
                    date_e = Convert.ToDateTime(DateTime.Now.AddDays(fewday)).ToString("yyyy/MM/dd");
                    date_b = Convert.ToDateTime(DateTime.Now.AddDays(fewday)).ToString("yyyy/MM/dd");
                }
               
                DataTable rq_attend = new DataTable();
                //出勤名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,a.rote,a.late_mins,a.e_mins,a.abs,a.forget," +
                    "b.dept,c.d_name,d.email" +
                    " from attend a,basetts b,dept c,base d where " +
                    " a.nobr=b.nobr and b.nobr=d.nobr and b.dept=c.d_no and '" + date_e + "' between b.adate and b.ddate" +
                    " and a.adate between '" + date_b + "' and '" + date_e + "'" +
                    " and (a.late_mins!=0 or a.e_mins!=0 or abs=1)" +
                    " and b.card='Y' and d.email<>''" +
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

                DataTable rq_rote = new DataTable();
                string CmdRote = "select rote,rote_disp,rotename,wk_hrs from rote";
                Cmd.CommandText = CmdRote;
                SqlDataAdapter SCmd10 = new SqlDataAdapter(Cmd);
                SCmd10.Fill(rq_rote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };
                foreach (DataRow Row0 in rq_email.Rows)
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
                        " and a.nobr='" + strnobr + "'"+
                        " and c.mang <> 1";
                    Cmd.CommandText = CmdAbs;
                    SqlDataAdapter SCmd3 = new SqlDataAdapter(Cmd);
                    DataTable rq_abs = new DataTable();
                    SCmd3.Fill(rq_abs);

                    //取得出公差資料
                    string CmdAbs1 = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,a.h_code,a.tol_hours,c.h_name,c.unit" +
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

                    DataRow[] attendnobr = rq_attend.Select("nobr='" + strnobr + "'");
                    foreach (DataRow Row3 in attendnobr)
                    {
                        string str_bdate = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");                       
                        DataRow[] row3 = rq_abs.Select("nobr='" + Row3["nobr"].ToString() + "'  and bdate='" + str_bdate + "'");
                        object[] _value = new object[2];
                        _value[0] = Row3["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        DataRow row4 = rq_rote.Rows.Find(Row3["rote"].ToString());
                        decimal _wk_hrs = 0;
                        string str_rotename = "";
                        if (row4 != null) 
                        {
                            str_rotename =row4["rote_disp"].ToString().Trim() + row4["rotename"].ToString().Trim();
                            _wk_hrs = decimal.Parse(row4["wk_hrs"].ToString());
                        }
                        DataRow row2 = rq_card.Rows.Find(_value);
                        string str_btime = "";
                        string str_etime = "";
                        if (row2 != null)
                        {
                            str_btime = row2["tt1"].ToString();
                            str_etime = row2["tt2"].ToString();
                        }
                        DataRow aRow1 = Dt.NewRow();
                        aRow1["員工編號"] = Row3["nobr"].ToString();
                        aRow1["員工姓名"] = Row3["name_c"].ToString();
                        aRow1["日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = str_rotename;
                        aRow1["進卡"] = str_btime;
                        aRow1["出卡"] = str_etime;
                        //late_mins,a.e_mins,a.abs,a.forget
                        string unusual = "";
                        if (decimal.Parse(Row3["late_mins"].ToString()) > 0)
                            unusual += "遲到 ";
                        else if (decimal.Parse(Row3["e_mins"].ToString()) > 0)
                            unusual += "早退 ";
                        else if (bool.Parse(Row3["abs"].ToString()))
                            unusual += (_wk_hrs > 0) ? "曠職 " + _wk_hrs.ToString() +"小時": "曠職 ";
                        aRow1["異常"] = unusual;
                        string absReason = "";
                        for (int i = 0; i < row3.Length; i++)
                        {
                            absReason += row3[i]["h_name"].ToString().Trim() + row3[i]["btime"].ToString().Trim() + " - " + row3[i]["etime"].ToString().Trim() + " " + row3[i]["tol_hours"].ToString() + row3[i]["unit"].ToString();
                            if (i > 0)
                                absReason += ";";
                        }
                        aRow1["請假"] = absReason;
                        Dt.Rows.Add(aRow1);                       
                    }
                    rq_card = null; 
                    //rq_dataid = null;
                  
                    rq_abs1 = null;
                    rq_abs = null;
                    if (Dt.Rows.Count > 0)
                    {
                        string html = ConvertDataTableToHtml(Dt, Dt.Rows[0]["員工編號"].ToString().Trim(), date_b, MonthDayB);
                        try
                        {
                            string _Subject = "出勤異常通知" + Dt.Rows[0]["員工編號"].ToString().Trim();
                            if (ConfigurationSettings.AppSettings["TestSubject"] != "")
                                _Subject += ConfigurationSettings.AppSettings["TestSubject"];

                            if (ConfigurationSettings.AppSettings["TestMail"] == "")
                            {
                                if (Row0["email"].ToString().Trim() != "")
                                {
                                    SendMail(Row0["email"].ToString(), DateTime.Parse(date_b).ToString("yyyyMMdd") + _Subject, html);
                                }
                                //SendMail(ConfigurationSettings.AppSettings["HRMail"], date_b + "個人" + _Subject, html);
                                //SendMail(ConfigurationSettings.AppSettings["HRMail1"], date_b + "個人" + _Subject, html);
                                //SendMail(ConfigurationSettings.AppSettings["HRMail2"], date_b + "個人" + _Subject, html);
                            }
                            else
                                SendMail(ConfigurationSettings.AppSettings["TestMail"], DateTime.Parse(date_b).ToString("yyyyMMdd") + _Subject, html);

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
                Conn.Dispose();
                Cmd.Dispose();
                rq_attend = null; rq_rote = null;

            }
            catch (Exception E)
            {
                ErrorUtility.WriteLog(E, "");
            }
        }

        public static string ConvertDataTableToHtml(DataTable dt,string nobr, string date_b, string MonthDayB)
        {
            int i = 0;
            string body = "<font color=black size=5><BR><B>您(" + nobr + ")" + DateTime.Parse(date_b).ToString("yyyyMMdd") + "的出勤資料有異常，請查照下表</font><BR></B><BR></BR>";
            if (DateTime.Now.Day == int.Parse(MonthDayB))
                body = "<font color=blue><BR>請再次確認本月出勤是否有異常，若有異常請立即補單，TKS!</font><BR>";
            //body += "<BR>2、本郵件由系統發送，請勿直接回覆，如有任何問題請洽管理部HR人員。</font><BR>";
            body += "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";
            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        //if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                        if (dc.ColumnName.ToString() == "出勤日期" )
                            body += "<td width=\"70px\">"+ dc.ColumnName + "</td>";
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
