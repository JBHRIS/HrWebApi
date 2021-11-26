using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.AttForm
{
    class ZZ2SClass_Person1
    {
        public static void DoSend(string nobr_b, string nobr_e, string date_b, string date_e, string TestSubject, string MailFrom, string HRMail, string HRMail1, string HRMail2, bool TestSend)
        {
            //發送未有mail出勤異常給指定人員
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

            string CmdUdataid = "select b.deptm,c.email as deptmail from attend a,base d,basetts b  ";
            CmdUdataid += " left outer join depta c on b.deptm=c.d_no";
            CmdUdataid += " where a.nobr=b.nobr ";
            CmdUdataid += string.Format(@" and b.nobr=d.nobr and '{0}' between b.adate and b.ddate", date_e);
            CmdUdataid += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
            CmdUdataid += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CmdUdataid += " and b.card='Y' and (a.late_mins!=0 or a.e_mins!=0 or abs=1 or forget > 2)";
            CmdUdataid += " and d.email='' ";
            CmdUdataid += " group by b.deptm,c.email";
            DataTable rq_dataid = SqlConn.GetDataTable(CmdUdataid);

            DataTable rq_rote = SqlConn.GetDataTable("select rote,rote_disp,rotename from rote");
            rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

            foreach (DataRow Row0 in rq_dataid.Rows)
            {
                //出勤名單
                string CmdAttend = "select a.nobr,d.name_c,a.adate,a.rote,a.late_mins,a.e_mins,a.abs,a.night_hrs,a.foodamt,a.forget,";
                CmdAttend += "b.deptm,c.d_name from attend a,base d,basetts b";
                CmdAttend += " left outer join depta c on b.deptm=c.d_no";
                CmdAttend += string.Format(@" where a.nobr=b.nobr and b.nobr=d.nobr and '{0}' between b.adate and b.ddate", date_e);
                CmdAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdAttend += " and b.card='Y' and (a.late_mins!=0 or a.e_mins!=0 or abs=1 or forget > 2)";
                CmdAttend += string.Format(@" and b.deptm='{0}'", Row0["deptm"].ToString());
                CmdAttend += " and d.email='' ";
                CmdAttend += " order by b.dept,a.nobr,a.adate";
                DataTable rq_attend = SqlConn.GetDataTable(CmdAttend);

                //卡鐘資料
                string CmdCard = "select a.nobr,a.adate,a.tt1,a.tt2 from attcard a,basetts b where a.nobr=b.nobr";
                CmdCard += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdCard += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdCard += string.Format(@" and b.deptm='{0}'", Row0["deptm"].ToString());
                DataTable rq_card = SqlConn.GetDataTable(CmdCard);                
                rq_card.PrimaryKey = new DataColumn[] { rq_card.Columns["nobr"], rq_card.Columns["adate"] };

                //請假資料
                string CmdAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,c.h_code_disp as h_code,a.tol_hours,c.h_name,c.mang,c.unit,c.not_sum";
                CmdAbs += " from abs a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code";
                CmdAbs += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdAbs += string.Format(@" and b.deptm='{0}'", Row0["deptm"].ToString());
                CmdAbs += " and c.mang <> 1";
                DataTable rq_abs = SqlConn.GetDataTable(CmdAbs);

                //取得出公差資料
                string CmdAbs1 = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,c.h_code_disp as h_code,a.tol_hours,c.h_name";
                CmdAbs1 += " from abs1 a,basetts b,hcode c where a.nobr=b.nobr and a.h_code=c.h_code" ;
                CmdAbs1 += " and a.bdate between b.adate and b.ddate";
                CmdAbs1 += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdAbs1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdAbs1 += string.Format(@" and b.deptm='{0}'", Row0["deptm"].ToString());
                CmdAbs1 += " order by a.nobr,a.bdate,a.etime";
                DataTable rq_abs1 = SqlConn.GetDataTable(CmdAbs1);
                foreach (DataRow Row4 in rq_abs1.Rows)
                {
                    rq_abs.ImportRow(Row4);
                }

                //加班
                string CmdOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs from ot a,basetts b where a.nobr=b.nobr";
                CmdOt += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                CmdOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdOt += string.Format(@" and b.deptm='{0}'", Row0["deptm"].ToString());
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
                rq_ot = null;
                rq_abs1 = null;
                rq_abs = null;
                rq_attend.Clear();
                if (Dt.Rows.Count > 0)
                {
                    string html = ReportClass.ConvertDataTableToHtml(Dt, Dt.Rows[0]["員工編號"].ToString().Trim(), date_b, date_e, DateTime.Now.Day.ToString());
                    if (TestSend)
                    {
                        if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, date_b + "  - " + date_e + TestSubject, html);
                        if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, date_b + "  - " + date_e + TestSubject, html);
                        if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, date_b + "  - " + date_e + TestSubject, html);
                    }
                    else
                    {
                        string _Subject = date_b + "  - " + date_e + "出勤異常表通知無Mail";
                        
                        if (Row0["deptmail"].ToString().Trim() != "")
                        {
                            string[] _deptemail = Row0["deptmail"].ToString().Split(';');
                            foreach (string _emaila in _deptemail)
                            {
                                string mm = _emaila.Trim();
                                if (_emaila.IndexOf("@") < 0)
                                    mm += "@corsair.com";
                                Smail.SendMailWithQueue(MailFrom, mm, _Subject, html);
                            }
                        }
                        //Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(Row0["email"].ToString(), Row0["name_c"].ToString()), _Subject, html);
                        if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject, html);
                        if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject, html);
                        if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject, html);
                    }                   
                }
                Dt.Clear();
            }
            rq_dataid = null;
            rq_rote = null;
            
        }
    }
}
