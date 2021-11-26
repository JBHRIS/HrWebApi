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
 * 2021/02/20    Daniel Chih    Ver 1.0.01     1. 新增通知選項：早來晚走：主管及HR通知
 * 2021/08/02    Daniel Chih    Ver 1.0.02     1. 修正早來晚走註記的判斷式
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/02
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace JBHR.Reports.AttForm
{
    class ZZ2SClass_Early_Late_Mang
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nobr_b"></param>
        /// <param name="nobr_e"></param>
        /// <param name="date_b"></param>
        /// <param name="date_e"></param>
        /// <param name="TestSubject"></param>
        /// <param name="MailFrom"></param>
        /// <param name="HRMail"></param>
        /// <param name="HRMail1"></param>
        /// <param name="HRMail2"></param>
        /// <param name="TestSend"></param>
        /// <param name="type_data"></param>
        /// <param name="Dept"></param>
        public static void DoSend(string nobr_b, string nobr_e
            , string date_b, string date_e
            , string TestSubject
            , string MailFrom
            , string HRMail
            , string HRMail1
            , string HRMail2
            , bool TestSend
            , string type_data
            , string Dept)
        {
            //早來晚走 - 主管及HR人員
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

            DataTable HRDt = new DataTable();
            DataTable HRDt1 = new DataTable();
            HRDt = Dt.Clone();
            DataTable Dt1 = new DataTable();
            Dt1 = Dt.Clone();
            Dt1.Columns.Add("saladr", typeof(string));
            HRDt1 = Dt1.Clone();

            try
            {
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

                string CmdUserDataId = " SELECT C.D_NO_DISP,C.D_NAME,C.EMAIL, ";
                CmdUserDataId += string.Format(@"{0}", Dept);
                CmdUserDataId += " from ATTEND_ABNORMAL a INNER JOIN basetts b ON a.nobr=b.nobr ";
                CmdUserDataId += string.Format(@" and a.NOBR between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdUserDataId += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //CmdUserDataId += " and a.is_error=1 ";
                CmdUserDataId += " INNER JOIN base d ON b.nobr=d.nobr ";
                CmdUserDataId += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdUserDataId += dept_rela;
                CmdUserDataId += " where 1=1 ";
                //套用排程版檢查註記的語法規則 - Modified By Daniel Chih - 2021/08/02
                CmdUserDataId += " and exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime ";
                CmdUserDataId += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                CmdUserDataId += string.Format(@" and c.d_no_disp is not null group by {0},c.d_no_disp,c.email,c.d_name", dept_query);

                rq_dataid = SqlConn.GetDataTable(CmdUserDataId);


                DataTable rq_attend = new DataTable();
                DataTable rq_attend1 = new DataTable();
                foreach (DataRow Row_dataid in rq_dataid.Rows)
                {
                    //出勤名單
                    string CmdAttend = "select a.nobr,d.name_c,a.adate,f.rote_disp+' '+f.rotename as rote,a.on_time,a.off_time,a.on_time_actual,a.off_time_actual,a.error_mins,b.saladr,";
                    CmdAttend += "(select g.name from mtcode g where a.type=g.code and g.category='ATTEND_ABNORMAL') as typename,";
                    CmdAttend += string.Format(@"{0},c.d_no_disp,c.d_name", Dept);
                    CmdAttend += " from ATTEND_ABNORMAL a INNER JOIN rote f ON a.rote_code=f.rote ";
                    CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                    CmdAttend += " and a.is_error=1  ";
                    CmdAttend += " INNER JOIN basetts b ON a.nobr=b.nobr ";
                    CmdAttend += string.Format(@" and b.NOBR between '{0}' and '{1}'", nobr_b, nobr_e);
                    CmdAttend += " INNER JOIN base d ON b.nobr=d.nobr ";
                    CmdAttend += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    CmdAttend += dept_rela;
                    CmdAttend += " where 1 = 1 ";
                    //套用排程版檢查註記的語法規則 - Modified By Daniel Chih - 2021/08/02
                    CmdAttend += " and exists (select h.EmployeeId from View_ATTEND_ABNORMAL h where a.nobr=h.EmployeeId and a.adate=h.AttendanceDate and a.on_time_actual=h.ActualOnTime ";
                    CmdAttend += " and a.off_time_actual=h.ActualOffTime and h.IsCheck=0)";
                    CmdAttend += string.Format(@" and {0}='{1}'", dept_query, Row_dataid["dept"].ToString());
                    CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);

                    rq_attend = SqlConn.GetDataTable(CmdAttend);

                    foreach (DataRow Row_attend in rq_attend.Rows)
                    {
                        DataRow aRow1 = Dt1.NewRow();
                        aRow1["部門代碼"] = Row_attend["d_no_disp"].ToString();
                        aRow1["部門名稱"] = Row_attend["d_name"].ToString();
                        aRow1["員工編號"] = Row_attend["nobr"].ToString();
                        aRow1["員工姓名"] = Row_attend["name_c"].ToString();
                        aRow1["出勤日期"] = DateTime.Parse(Row_attend["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = Row_attend["rote"].ToString();
                        aRow1["上班時間"] = Row_attend["on_time"].ToString();
                        aRow1["下班時間"] = Row_attend["off_time"].ToString();
                        aRow1["實際上班時間"] = Row_attend["on_time_actual"].ToString();
                        aRow1["實際下班時間"] = Row_attend["off_time_actual"].ToString();
                        aRow1["異常類型"] = Row_attend["typename"].ToString();
                        aRow1["異常分鐘數"] = decimal.Parse(Row_attend["error_mins"].ToString());
                        aRow1["saladr"] = Row_attend["saladr"].ToString();

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
                        string _Subject = date_b + "  - " + date_e + "出勤刷卡時間異常通知";
                        try
                        {
                            if (TestSend)
                            {
                                if (Row_dataid["email"].ToString().Trim() != "")
                                {
                                    string[] _deptemail = Row_dataid["email"].ToString().Split(';');
                                    foreach (string _emaila in _deptemail)
                                    {
                                        string mm = _emaila.Trim();
                                        if (!string.IsNullOrWhiteSpace(mm))
                                        {
                                            Smail.SendMailWithQueue(MailFrom, _emaila, "部門:" + Row_dataid["d_no_disp"].ToString().Trim() + " " + Row_dataid["d_name"].ToString() + " " + _Subject + TestSubject, html);
                                            
                                        }
                                        mm += "";
                                    }
                                }
                            }
                            //else
                            //{
                            //    Smail.AddMailQueueWithFileService(TestAccount, _Subject, html, listFild);                                
                            //    ErrorUtility.WriteLog("刷卡時間異常寄發信件到：主管信箱" + Row0["d_no_disp"].ToString());
                            //}
                        }
                        catch (Exception Ex)
                        {
                            JBModule.Message.TextLog.WriteLog(Ex);
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
                    string Cmddatagroup = "select datagroup,note from datagroup order by datagroup";

                    DataTable rq_datagroup = SqlConn.GetDataTable(Cmddatagroup);

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
                                row["saladr"] = row["saladr"].ToString() + ";" + Row["datagroup"].ToString();
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
                                string html = ConvertDataTableToHtml(HRDt);
                                string _Subject = date_b + " - " + date_e + " 出勤刷卡時間異常通知";

                                if (TestSend)
                                {
                                    if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, "部門:" + Row["d_no_disp"].ToString().Trim() + " " + Row["d_name"].ToString() + " " + _Subject + TestSubject, html);
                                    if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, "部門:" + Row["d_no_disp"].ToString().Trim() + " " + Row["d_name"].ToString() + " " + _Subject + TestSubject, html);
                                    if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, "部門:" + Row["d_no_disp"].ToString().Trim() + " " + Row["d_name"].ToString() + " " + _Subject + TestSubject, html);
                                }
                                else
                                {
                                    if (Row["email"].ToString().Trim() != "")
                                    {
                                        foreach (string _emaila in _mail)
                                        {
                                            string mm = _emaila.Trim();

                                            if (mm != "")
                                            {
                                                Smail.SendMailWithQueue(MailFrom, mm, "部門:" + Row["d_no_disp"].ToString().Trim() + " " + Row["d_name"].ToString() + " " + _Subject, html);
                                            }
                                        }
                                    }

                                }

                            }
                            catch (Exception Ex)
                            {
                                //ErrorUtility.WriteLog(Ex, "");
                                continue;
                            }
                        }
                        HRDt.Clear();
                        HRDt1.Clear();
                    }
                    //Conn.Dispose();
                    //Cmd.Dispose();
                    rq_datagroup = null;
                }

                Dt1 = null;

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ConvertDataTableToHtml(DataTable dt)
        {
            int i = 0;
            string body = "<font color=black size=3><BR><B>" + "出勤上下班刷卡資料時間異常，請查照下表<BR>" + "</font></B>";
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
