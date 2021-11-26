/* ======================================================================================================
 * 功能名稱：出勤異常通知
 * 功能代號：ZZ2S
 * 功能路徑：報表列印 > 出勤 > 出勤異常通知
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ2SClass_Early_Late.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/20    Daniel Chih    Ver 1.0.01     1. 新增通知選項：早來晚走：個人通知
 * 2021/05/11    Daniel Chih    Ver 1.0.02     1. 修正發送信件的郵件標題日期重複顯示的問題
 * 2021/08/02    Daniel Chih    Ver 1.0.03     1. 修正早來晚走註記的判斷式
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/02
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

namespace JBHR.Reports.AttForm
{
    class ZZ2SClass_Early_Late_Employee
    {
        private static SqlConnection GetConn()
        {
            string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["HRConnectionString"];
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);
            return Con;
        }
        public static void DoSend(string nobr_b, string nobr_e, string date_b, string date_e, string TestSubject, string MailFrom, string HRMail, string HRMail1, string HRMail2, bool TestSend, string type_data, string Dept)
        {
            List<Attachment> listFild = new List<Attachment>();

            //早來晚走 - 個人通知
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
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
                string SenderName = string.Empty;                

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
                DataTable rq_rote = SqlConn.GetDataTable(CmdRote);

                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

                DataTable rq_attend = new DataTable();
                //出勤異常名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,f.rote_disp+' '+f.rotename as rote,a.on_time,a.off_time,a.on_time_actual,a.off_time_actual,a.error_mins,";
                CmdAttend += "(select g.name from mtcode g where a.type=g.code and g.category='ATTEND_ABNORMAL') as typename,";
                CmdAttend += string.Format(@"{0},c.d_no_disp,c.d_name,d.email", Dept);
                CmdAttend += " from base d inner join basetts b ON b.nobr=d.nobr";
                CmdAttend += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAttend += " and d.email<>'' ";
                CmdAttend += string.Format(@" AND D.NOBR BETWEEN '{0}' AND '{1}' ", nobr_b, nobr_e);
                CmdAttend += " INNER JOIN ATTEND_ABNORMAL a ON a.nobr=b.nobr ";
                CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //CmdAttend += " and a.is_error=1 ";
                CmdAttend += " INNER JOIN rote f ON a.rote_code=f.rote ";
                CmdAttend += dept_rela;
                CmdAttend += " where 1 = 1 ";
                //套用排程版檢查註記的語法規則 - Modified By Daniel Chih - 2021/08/02
                CmdAttend += " and exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime ";
                CmdAttend += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);

                rq_attend = SqlConn.GetDataTable(CmdAttend);

                //ErrorUtility.WriteLog("本日出勤早到晚走同仁共有：" + rq_attend.Rows.Count.ToString());

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

                    DataRow[] attendnobr = rq_attend.Select("nobr='" + strnobr + "'");
                    foreach (DataRow Row3 in attendnobr)
                    {

                        DataRow aRow1 = Dt.NewRow();
                        aRow1["員工編號"] = Row3["nobr"].ToString();
                        aRow1["員工姓名"] = Row3["name_c"].ToString();
                        aRow1["部門代碼"] = (Row3.IsNull("d_no_disp")) ? "" : Row3["d_no_disp"].ToString();
                        aRow1["部門名稱"] = (Row3.IsNull("d_name")) ? "" : Row3["d_name"].ToString();
                        aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = Row3["rote"].ToString();
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
                            string _Subject = date_b + " - " + date_e + " 出勤刷卡時間異常通知";

                            //是否為測試
                            if (TestSend)
                            {
                                if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject + TestSubject, html);
                                if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject + TestSubject, html);
                                if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject + TestSubject, html);
                            }
                            else
                            {
                                Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(Row0["email"].ToString(), Row0["name_c"].ToString()), _Subject, html);
                                //if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject, html);
                                //if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject, html);
                                //if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject, html);
                            }
                        }
                        catch (Exception Ex)
                        {
                            continue;
                        }
                    }
                    Dt.Clear();
                }

                rq_attend = null;

            }
            catch (Exception E)
            {
                //ErrorUtility.WriteLog(E, "");
            }

        }

        public static string ConvertDataTableToHtml(DataTable dt, string Nobr)
        {
            int i = 0;
            string body = "<font color=black size=3><BR><B>" + "您(" + Nobr + ")的出勤上下班刷卡時間資料異常，請查照下表" + "</font><BR></B>";
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
