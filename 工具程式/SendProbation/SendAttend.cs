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

namespace waferattend
{
    class SendAttend
    {
        private static SqlConnection GetConn()
        {
            string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["SchmidConnectionString"];
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);
            return Con;
        }

        public static void DoSend()
        {
            List<Attachment> listFild = new List<Attachment>();
            DataTable HRDt = new DataTable();
            DataTable Dt = new DataTable();
            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
            Dt.Columns.Add("公司名稱", typeof(string));
            Dt.Columns.Add("部門代碼", typeof(string));
            Dt.Columns.Add("部門名稱", typeof(string));
            Dt.Columns.Add("員工編號", typeof(string));
            Dt.Columns.Add("員工姓名", typeof(string));
            Dt.Columns.Add("到職日期", typeof(string));
            Dt.Columns.Add("試用期滿日", typeof(string));
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
                int NoticeDays = 30;
                //抓取hr郵件參數設定天數
                string SenderName = string.Empty;
                string MailFrom = "";
                string TestAccount = ConfigurationSettings.AppSettings["TestMail"];
                string HRAccount = string.Empty;
                string Dept = "Dept";
                DataTable rq_parameter = new DataTable();
                string Cmdparameter = "select code,value from Parameter where code in ('JbMail.DateInteval','JbMail.Sender','JbMail.TestAccount','JbMail.SenderName','JbMail.Department','JbMail.HRAccount','JbMail.ExpirationDays')";
                Cmd.CommandText = Cmdparameter;
                SqlDataAdapter SCmd0 = new SqlDataAdapter(Cmd);
                SCmd0.Fill(rq_parameter);
                int fewday = -3;
                foreach (DataRow Row in rq_parameter.Rows)
                {
                    if (Row["code"].ToString().Trim() == "JbMail.DateInteval")
                        fewday = int.Parse(Row["value"].ToString());
                    else if (Row["code"].ToString().Trim() == "JbMail.Sender")
                        MailFrom = Row["value"].ToString();
                    //else if (Row["code"].ToString().Trim() == "JbMail.TestAccount")
                    //    TestAccount = Row["value"].ToString();
                    else if (Row["code"].ToString().Trim() == "JbMail.SenderName")
                        SenderName = Row["value"].ToString().Trim();
                    //else if (Row["code"].ToString().Trim() == "JbMail.Department")
                    //    Dept = Row["value"].ToString().Trim();
                    else if (Row["code"].ToString().Trim() == "JbMail.HRAccount")
                        HRAccount = Row["value"].ToString().Trim();
                    else if (Row["code"].ToString().Trim() == "JbMail.ExpirationDays")
                        NoticeDays = int.Parse(Row["value"].ToString());
                    else if (Row["code"].ToString().Trim() == "JbMail.TestAccount")
                        TestAccount = Row["value"].ToString();
                }
                if (NoticeDays == 0)
                    return;
                date_b = DateTime.Now.ToString("yyyy/MM/dd");
                date_e = DateTime.Now.ToString("yyyy/MM/dd");
                string apdate = DateTime.Now.AddDays(NoticeDays).ToString("yyyy/MM/dd");
               
                string Cmddatagroup = "select datagroup,note from datagroup where note!=''";
                Cmd.CommandText = Cmddatagroup;
                SqlDataAdapter SCmdr = new SqlDataAdapter(Cmd);
                DataTable rq_datagroup = new DataTable();
                SCmdr.Fill(rq_datagroup);
                DataTable rq_base = new DataTable();
                foreach (DataRow Row in rq_datagroup.Rows)
                {                   
                    //產生試用期滿通知
                    string CmdBase = "select c.compname,b.nobr,a.name_c,a.name_e,b.indt,b.ap_date,d.d_no_disp as dept,d.d_name";
                    CmdBase += " from base a,basetts b";
                    CmdBase += " left outer join comp c on b.comp=c.comp";
                    CmdBase += " left outer join dept d on b.dept=d.d_no";                   
                    CmdBase += " where a.nobr =b.nobr";
                    CmdBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdBase += string.Format(@" and b.saladr='{0}'", Row["datagroup"].ToString());
                    CmdBase += string.Format(@" and b.ap_date='{0}'", apdate);
                    CmdBase += " and b.ttscode in ('1','4','6')";
                    Cmd.CommandText = CmdBase;
                    SqlDataAdapter SCmd1 = new SqlDataAdapter(Cmd);
                    SCmd1.Fill(rq_base);
                    foreach(DataRow Row1 in rq_base.Rows)
                    {
                        DataRow aRow = Dt.NewRow();
                        aRow["公司名稱"] = Row1["compname"].ToString();
                        aRow["部門代碼"] = Row1["dept"].ToString();
                        aRow["部門名稱"] = Row1["d_name"].ToString();
                        aRow["員工編號"] = Row1["nobr"].ToString();
                        aRow["員工姓名"] = Row1["name_c"].ToString();                       
                        aRow["到職日期"] = DateTime.Parse(Row1["indt"].ToString()).ToString("yyyy/MM/dd");
                        if (!Row1.IsNull("ap_date")) aRow["試用期滿日"] = DateTime.Parse(Row1["ap_date"].ToString()).ToString("yyyy/MM/dd");                        
                        Dt.Rows.Add(aRow);
                    }
                    
                    if (Dt.Rows.Count>0)
                    {
                        try
                        {
                            string _Subject = "試用期滿通知";
                            string html = ConvertDataTableToHtml(Dt, "", date_b, date_e, "");
                            if (TestAccount == "")
                            {
                                string[] _Email = Row["note"].ToString().Split(';');
                                //string _Subject = DateTime.Parse(apdate).ToString("MM/dd") + " SPJ Probation Notice";
                                
                                if (ConfigurationSettings.AppSettings["TestSubject"] != "")
                                    _Subject += ConfigurationSettings.AppSettings["TestSubject"];
                                foreach (string _emaila in _Email)
                                {
                                    string mm = _emaila.Trim();
                                    //if (mm != "")
                                    if (!string.IsNullOrWhiteSpace(mm))
                                    {
                                        Smail.AddMailQueueWithFileService(mm, _Subject, html, listFild);
                                        
                                        ErrorUtility.WriteLog("寄發信件到：HR信箱資料群組:" + Row["datagroup"].ToString() + "-> " + mm);
                                    }
                                    mm += "";
                                }
                            }
                            else
                            {
                                Smail.AddMailQueueWithFileService(TestAccount, _Subject, html, listFild);
                                ErrorUtility.WriteLog("寄發信件到：HR信箱資料群組:" + Row["datagroup"].ToString());
                            }

                        }
                        catch (Exception Ex)
                        {
                            ErrorUtility.WriteLog(Ex, "");
                            continue;
                        }
                    }
                    
                    rq_base.Clear();
                    Dt.Clear();
                }
                
                Conn.Dispose();
                Cmd.Dispose();
                rq_datagroup = null; rq_parameter = null;               

            }
            catch (Exception E)
            {
                ErrorUtility.WriteLog(E, "");
            }

        }

        public static string ConvertDataTableToHtml(DataTable dt, string nobr, string date_b, string date_e, string MonthDayB)
        {
            int i = 0;
            string body = string.Empty;
            body += "<font color=black size=3><BR>提醒您，人員試用期相關訊息如下，請留意人員狀態，謝謝</font><BR>";
            //body += "<font color=black size=2><B>Remind you that Probation information as below ,Please prepare the file and notify</B></font><BR><BR>";
            
            body += "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:12pt;border-collapse:collapse;\">";
            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        //if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                        if (dc.ColumnName.ToString() == "到職日期")
                            body += "<td><B>" + dc.ColumnName + "</B></td>";  //"<td width=\"70px\"><B>" + dc.ColumnName + "</B></td>";
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
            //body += "<BR><BR><font color=black><B>You might need some document as below</B></font><BR><BR>";
            //body += "<font color=black size=3>一試用期滿考核表 &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;Probation  Form<BR>";
            //body += "二出勤相關資料 &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Attendance record<BR>";
            //body += "三新人周報 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Weekly Report<BR>";
            //body += "四其他表單同步作業 &nbsp; &nbsp;Other<BR></font>";           
            //body += "<BR><B><font color=red>本通知僅供參考，請各位仍需養成自行查看出勤的好習慣（關帳日若為月底時，更需要留意）。<BR>本筆異常通知為系統自動寄出，請勿直接回覆，若有任何出勤問題請洽分機1324淑芬</font></B>";
            return body;
        }

        public static string ConvertDataTableToHtmlA(DataTable dt)
        {
            int i = 0;
            //string body = "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";
            string body = string.Empty;
            body += "<font color=blue>*請務必在</font><input type=button style=color:red disabled=disabled value=收到此通知後三天>";
            body += "<font color=blue>內完成請假手續，三日後若未完成請假手續，系統將制本人再補請假</font><BR>";
            //body += "<font color=blue>*</font><font color=red>薪資結算期間每月20-25</font>  <font color=blue>，請務於</font><font color=red>『當日』</font> <font color=blue>，請務於</font><font color=blue>完成請假手冊，超過時間者視同</font><table style=border:3px border='1'><td><font color=red>曠職處理</font></td></table><font color=blue>;除非由主管代辦申請作業</font><BR>";
            body += "<font color=blue>*</font><font color=red>薪資結算期間每月20-25</font>  <font color=blue>，請務於</font><font color=red>『當日』</font> <font color=blue>，請務於</font><font color=blue>完成請假手冊，超過時間者視同</font><input type=button style=color:red disabled=disabled value=曠職處理><font color=blue>;除非由主管代辦申請作業</font><BR>";
            //body += "<font color=blue>*遲到超過16分鐘以上，</font><font color=red>最少請補0.5小時的假單</font><font color=blue>!</font><BR><BR>";
            body += "<font color=blue>*每日工作必須滿8小時 !!</font>><BR><BR>";
            body += "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";

            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.ColumnName.ToString() == "日期" || dc.ColumnName.ToString() == "員工姓名")
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
            body += "<B><font color=blue>1. 請假手續程序：至EIP系統登打「請假單」→「代理人簽核」→「主管簽核」<BR>";
            body += "2. 忘帶卡同仁可至人資處借用臨時卡刷上、下班，隔日送還。<BR>";
            body += "3. 員工因未刷卡產生出勤異常者，需自行請假(申請休假或事假由主管核准)，未辦理請假手續之異常處理如下： <BR>";
            body += "&nbsp; &nbsp;．當日一次未刷卡者：以曠職1小時計。 <BR>";
            body += "&nbsp; &nbsp;．當日二次未刷卡者：以曠職1日計。  <BR>";
            body += "4. 請假注意事項: <BR>";
            body += "&nbsp; &nbsp;．病假一日(不含)以上須附醫師診斷書或就醫證明。<BR>";
            body += "&nbsp; &nbsp;．婚喪假以1日為單位。 <BR>";
            body += "&nbsp; &nbsp;．員工請假後三日內系統會主動提醒請假，三日後若未完成請假手續，系統將限制本人再補請假，並視同曠職處理；除非由主管代辦申請作業。<BR>";
            body += "</font>";
            body += "<BR><BR>";
            body += "<font color= #FF00FF>敬請配合作業，謝謝<BR>";
            body += "張美珠:分機11180</font></B>";
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
