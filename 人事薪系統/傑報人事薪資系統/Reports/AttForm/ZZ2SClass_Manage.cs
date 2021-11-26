using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.AttForm
{
    class ZZ2SClass_Manage
    {
        public static void DoSend(string nobr_b, string nobr_e, string date_b, string date_e, string TestSubject, string MailFrom, string HRMail, string HRMail1, string HRMail2, bool TestSend, string type_data,string Dept)
        {
            //發送所有出勤異常mail給編制主管
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
            DataTable Dt = new DataTable();
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
            Dt.Columns.Add("曠職", typeof(string));
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
                

            string CmdUdataid = "select c.email,c.d_name,c.d_no_disp,";
            CmdUdataid += string.Format(@"{0}", Dept);
            CmdUdataid += " from attend a,base d,basetts b";
            //CmdUdataid += " left outer join dept c on b.dept=c.d_no ";
            CmdUdataid += dept_rela;
            CmdUdataid += " where a.nobr=b.nobr";
            CmdUdataid += string.Format(@" and b.nobr=d.nobr and '{0}' between b.adate and b.ddate", date_e);
            CmdUdataid += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
            CmdUdataid += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CmdUdataid += " and b.card='Y' and (a.late_mins!=0 or a.e_mins!=0 or abs=1 )";//or forget > 0
            CmdUdataid += string.Format(@" group by {0},c.d_no_disp,c.email,c.d_name", dept_query);
            DataTable rq_dataid = SqlConn.GetDataTable(CmdUdataid);

            DataTable rq_rote = SqlConn.GetDataTable("select rote,rote_disp,rotename from rote");
            rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };
            DataTable HrDT = new DataTable();//發送通知HR人員
            string _Subject = date_b + "  - " + date_e + "出勤異常表通知主管";
            foreach (DataRow Row0 in rq_dataid.Rows)
            {
                //出勤名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,a.rote,a.late_mins,a.e_mins,a.abs,a.night_hrs,a.foodamt,a.forget,";
                CmdAttend += string.Format(@"{0}", Dept);
                CmdAttend += ",c.d_name from attend a,base d,basetts b";
                CmdAttend += dept_rela;
                CmdAttend += string.Format(@" where a.nobr=b.nobr and b.nobr=d.nobr and '{0}' between b.adate and b.ddate", date_e);
                CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdAttend += " and b.card='Y' and (a.late_mins!=0 or a.e_mins!=0 or abs=1 )";//or forget > 0
                CmdAttend += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                CmdAttend += string.Format(@" order by {0},a.nobr,a.adate", dept_query);                
                DataTable rq_attend = SqlConn.GetDataTable(CmdAttend);

                //卡鐘資料
                string CmdCard = "select a.nobr,a.adate,a.tt1,a.tt2 from attcard a,basetts b where a.nobr=b.nobr";
                CmdCard += " and '" + date_e + "' between b.adate and b.ddate";
                CmdCard += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdCard += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                DataTable rq_card = SqlConn.GetDataTable(CmdCard);
                rq_card.PrimaryKey = new DataColumn[] { rq_card.Columns["nobr"], rq_card.Columns["adate"] };

                //請假資料
                string CmdAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,c.h_code_disp as h_code,a.tol_hours,c.h_name,c.mang,c.unit,c.not_sum";
                CmdAbs += " from abs a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code";
                CmdAbs += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdAbs += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                CmdAbs += " and c.mang <> 1";
                DataTable rq_abs = SqlConn.GetDataTable(CmdAbs);

                //取得出公差資料
                string CmdAbs1 = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,c.h_code_disp as h_code,a.tol_hours,c.h_name";
                CmdAbs1 += " from abs1 a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code";
                CmdAbs1 += " and a.bdate between b.adate and b.ddate";
                CmdAbs1 += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAbs1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdAbs1 += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                CmdAbs1 += " order by a.nobr,a.bdate,a.etime";
                DataTable rq_abs1 = SqlConn.GetDataTable(CmdAbs1);

                foreach (DataRow Row4 in rq_abs1.Rows)
                {
                    rq_abs.ImportRow(Row4);
                }

                //加班
                string CmdOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs from ot a,basetts b where a.nobr=b.nobr";
                CmdOt += " and '" + date_e + "' between b.adate and b.ddate";
                CmdOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdOt += string.Format(@" and {0}='{1}'", dept_query, Row0["dept"].ToString());
                DataTable rq_ot = SqlConn.GetDataTable(CmdOt);

                foreach (DataRow Row3 in rq_attend.Rows)
                {
                    string str_bdate = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                    DataRow[] row = rq_ot.Select("nobr='" + Row3["nobr"].ToString() + "' and bdate='" + str_bdate + "'");
                    DataRow[] row3 = rq_abs.Select("nobr='" + Row3["nobr"].ToString() + "'  and bdate='" + str_bdate + "'");
                    DataRow row4 = rq_rote.Rows.Find(Row3["rote"].ToString());
                    string rotename = "";
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
                        str_btime = row2["tt1"].ToString();
                        str_etime = row2["tt2"].ToString();
                    }

                    if (row.Length == 0 && row3.Length == 0)
                    {
                        DataRow aRow1 = Dt.NewRow();
                        aRow1["員工編號"] = Row3["nobr"].ToString();
                        aRow1["員工姓名"] = Row3["name_c"].ToString();
                        aRow1["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                        aRow1["班別"] = Row3["rote"].ToString() + " (" + rotename + ")";
                        aRow1["上班時間"] = str_btime;
                        aRow1["下班時間"] = str_etime;
                        aRow1["忘刷"] = decimal.Round(decimal.Parse(Row3["forget"].ToString()), 0);
                        aRow1["遲到(分)"] = decimal.Parse(Row3["late_mins"].ToString());
                        aRow1["早退(分)"] = decimal.Parse(Row3["e_mins"].ToString());
                        aRow1["曠職"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
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
                                }
                                aRow2["忘刷"] = decimal.Round(decimal.Parse(Row3["forget"].ToString()), 0);
                                aRow2["遲到(分)"] = decimal.Parse(Row3["late_mins"].ToString());
                                aRow2["早退(分)"] = decimal.Parse(Row3["e_mins"].ToString());
                                aRow2["曠職"] = (bool.Parse(Row3["abs"].ToString())) ? "V" : "";
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
                                aRow3["出勤日期"] = DateTime.Parse(Row3["adate"].ToString()).ToString("yyyy/MM/dd");
                                aRow3["班別"] = Row3["rote"].ToString() + " (" + rotename + ")";
                                aRow3["上班時間"] = str_btime;
                                aRow3["下班時間"] = str_etime;
                                aRow3["假別名稱"] = row3[i]["h_name"].ToString();
                                aRow3["請起時間"] = row3[i]["btime"].ToString();
                                aRow3["請迄時間"] = row3[i]["etime"].ToString();
                                aRow3["請假時數"] = decimal.Parse(row3[i]["tol_hours"].ToString());
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
                                Dt.Rows.Add(aRow3);
                            }
                        }
                    }
                }
                rq_card = null;
                rq_abs1 = null;
                rq_abs = null;
                rq_attend.Clear();
                if (Dt.Rows.Count > 0)
                {
                    HrDT.Merge(Dt);
                    string html = ReportClass.ConvertDataTableToHtmlDept(Dt, Row0["d_no_disp"].ToString().Trim() + " " + Row0["d_name"].ToString().Trim(), date_b, date_e, DateTime.Now.Day.ToString());                   
                    if (TestSend)
                    {
                        if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, "部門:" + Row0["d_no_disp"].ToString().Trim() + " " + Row0["d_name"].ToString() + " " + _Subject + TestSubject, html);
                        if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, "部門:" + Row0["d_no_disp"].ToString().Trim() + " " + Row0["d_name"].ToString() + " " + _Subject + TestSubject, html);
                        if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, "部門:" + Row0["d_no_disp"].ToString().Trim() + " " + Row0["d_name"].ToString() + " " + _Subject + TestSubject, html);
                    }
                    else
                    {
                        if (Row0["email"].ToString().Trim() != "")
                        {
                            string[] _deptemail = Row0["email"].ToString().Split(';');
                            foreach (string _emaila in _deptemail)
                            {
                                string mm = _emaila.Trim();
                                if (mm!="")
                                   Smail.SendMailWithQueue(MailFrom, mm, "部門:" + Row0["d_no_disp"].ToString().Trim() + " " + Row0["d_name"].ToString() + " " + _Subject, html);
                            }
                        }
                        
                    }
                }
                Dt.Clear();
            }
            //發送通知HR人員
            if (!TestSend && HrDT.Rows.Count > 0)
            {
                string HRhtml = ReportClass.ConvertDataTableToHRHtml(HrDT);
                //string _Subject = date_b + "  - " + date_e + "出勤異常表通知主管";
                if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject, HRhtml);
                if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject, HRhtml);
                if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject, HRhtml);
            }
            rq_dataid = null; rq_rote = null;
        }
    }
}
