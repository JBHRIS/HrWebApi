using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace JBHR.Reports.AttForm
{
    class ZZ2SAbsAttCard
    {
        public static void DoSend(string nobr_b, string nobr_e, string date_b, string date_e, string TestSubject, string MailFrom, string HRMail, string HRMail1, string HRMail2, bool TestSend, bool person, bool mange)
        {            
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
            //Dt.Columns.Add("加起時間", typeof(string));
            //Dt.Columns.Add("加迄時間", typeof(string));
            //Dt.Columns.Add("加班時數", typeof(decimal));
            //Dt.Columns.Add("補休時數", typeof(decimal));
            //Dt.Columns.Add("忘刷", typeof(decimal));
            //Dt.Columns.Add("遲到(分)", typeof(decimal));
            //Dt.Columns.Add("早退(分)", typeof(decimal));
            //Dt.Columns.Add("曠職", typeof(string));

            DataTable rq_check = new DataTable();
            rq_check.Columns.Add("dept", typeof(string));
            rq_check.Columns.Add("d_name", typeof(string));
            rq_check.Columns.Add("deptm", typeof(string));
            rq_check.Columns.Add("deptmail", typeof(string));
            rq_check.Columns.Add("nobr", typeof(string));
            rq_check.Columns.Add("name_c", typeof(string));
            rq_check.Columns.Add("attdate", typeof(DateTime));
            rq_check.Columns.Add("rote", typeof(string));
            rq_check.Columns.Add("rotename", typeof(string));
            rq_check.Columns.Add("tt1", typeof(string));
            rq_check.Columns.Add("tt2", typeof(string));
            rq_check.Columns.Add("h_name", typeof(string));
            rq_check.Columns.Add("btime", typeof(string));
            rq_check.Columns.Add("etime", typeof(string));
            rq_check.Columns.Add("abshr", typeof(decimal));
            rq_check.Columns.Add("email", typeof(string));

            //個人有mail名單
            DataTable rq_nobr = new DataTable();
            rq_nobr.Columns.Add("nobr", typeof(string));
            rq_nobr.PrimaryKey = new DataColumn[] { rq_nobr.Columns["nobr"] };

            //部門主管名單
            DataTable rq_deptm = new DataTable();
            rq_deptm.Columns.Add("deptm", typeof(string));
            rq_deptm.Columns.Add("da_ename", typeof(string));
            rq_deptm.Columns.Add("mangemail", typeof(string));
            rq_deptm.PrimaryKey = new DataColumn[] { rq_deptm.Columns["deptm"] };

            string CmdBase = "select b.nobr,a.name_c,a.email,c.d_no_disp as dept,c.d_name,b.deptm,d.email as deptmail,d.mangemail,d.d_ename as da_ename";
            CmdBase += " from base a,basetts b";
            CmdBase += " left outer join dept c on b.dept=c.d_no";
            CmdBase += " left outer join depta d on b.deptm=d.d_no";
            CmdBase += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_e);          
            DataTable rq_base = SqlConn.GetDataTable(CmdBase);
            rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

            string CheckAbs = "select a.nobr,a.bdate,a.btime,a.etime,b.t1,b.t2,b.tt1,b.tt2,a.tol_hours,c.h_name";
            CheckAbs += " from  hcode d,abs a ";
            CheckAbs += " left outer join attcard b on a.nobr=b.nobr";
            CheckAbs += " left outer join hcode c on a.h_code=c.h_code";
            CheckAbs += string.Format(@" where a.bdate=b.adate  and a.h_code=d.h_code and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CheckAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
            CheckAbs += " and  d.year_rest not in ('1','3','5','7')";
            CheckAbs += " and exists(select * from attcard where a.nobr=attcard.nobr and a.bdate=attcard.adate";
            CheckAbs += " and attcard.t1<=a.btime and attcard.t2>=a.etime )";
            DataTable rq_checkabs = SqlConn.GetDataTable(CheckAbs);
            foreach (DataRow Row in rq_checkabs.Rows)
            {
                string _btime = Row["btime"].ToString();
                string _etime = Row["etime"].ToString();
                DateTime _bdate = DateTime.Parse(Row["bdate"].ToString());
                DateTime _edate = DateTime.Parse(Row["bdate"].ToString());     
                if (Convert.ToInt32(Row["btime"].ToString()) < Convert.ToInt32(Row["t1"].ToString()))
                    _btime = Row["t1"].ToString();
                if (Convert.ToInt32(Row["etime"].ToString()) > Convert.ToInt32(Row["t2"].ToString()))
                    _etime = Row["t2"].ToString();

                if (Convert.ToInt32(Row["etime"].ToString().Trim()) > 2400)
                {
                    _btime = Convert.ToString(Convert.ToInt32(Row["btime"].ToString()) - 24).PadLeft(4, '0');
                    _bdate = _bdate.AddDays(1).AddHours(Convert.ToInt32(_btime.Substring(0, 2))).AddMinutes(Convert.ToInt32(_btime.Substring(2, 2)));
                }
                else
                    _bdate = _bdate.AddDays(1).AddHours(Convert.ToInt32(_btime.Substring(0, 2))).AddMinutes(Convert.ToInt32(_btime.Substring(2, 2)));

                if (Convert.ToInt32(Row["etime"].ToString().Trim()) > 2400)
                {
                    _etime = Convert.ToString(Convert.ToInt32(Row["etime"].ToString()) - 24).PadLeft(4, '0');
                    _edate = _edate.AddDays(1).AddHours(Convert.ToInt32(_etime.Substring(0, 2))).AddMinutes(Convert.ToInt32(_etime.Substring(2, 2)));
                }
                else
                    _edate = _edate.AddDays(1).AddHours(Convert.ToInt32(_etime.Substring(0, 2))).AddMinutes(Convert.ToInt32(_etime.Substring(2, 2)));

                int diffMin = ((TimeSpan)(_edate - _bdate)).Minutes;
                int diffhours = ((TimeSpan)(_edate - _bdate)).Hours;
                int _tolMin = (diffhours > 0) ? (diffhours * 60) + diffMin : diffMin;

                if (_tolMin > 30)
                {
                    string Cmdattend = "select a.nobr,a.adate,b.rote_disp as rote,b.rotename from attend a";
                    Cmdattend += " left outer join rote b on a.rote=b.rote";
                    Cmdattend += string.Format(@" where a.adate='{0}' and a.nobr='{1}'", _bdate.ToString("yyyy/MM/dd"), Row["nobr"].ToString());
                    DataTable rq_attend = SqlConn.GetDataTable(Cmdattend);

                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (rq_attend.Rows.Count > 0 && row != null)
                    {
                        DataRow aRow = rq_check.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["deptm"] = row["deptm"].ToString();
                        aRow["deptmail"] = row["deptmail"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["attdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["rote"] = rq_attend.Rows[0]["rote"].ToString();
                        aRow["rotename"] = rq_attend.Rows[0]["rotename"].ToString();
                        aRow["tt1"] = Row["tt1"].ToString();
                        aRow["tt2"] = Row["tt2"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        aRow["btime"] = Row["btime"].ToString();
                        aRow["etime"] = Row["etime"].ToString();
                        aRow["abshr"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["email"] = row["email"].ToString();
                        rq_check.Rows.Add(aRow);

                        DataRow row1 = rq_deptm.Rows.Find(row["deptm"].ToString());
                        if (row1 == null)
                        {
                            DataRow aRow1 = rq_deptm.NewRow();
                            aRow1["deptm"] = row["deptm"].ToString();
                            aRow1["mangemail"] = row["mangemail"].ToString();
                            aRow1["da_ename"] = row["da_ename"].ToString();
                            rq_deptm.Rows.Add(aRow1);
                        }
                        if (row["email"].ToString().Trim()!="")
                        {
                            DataRow row2 = rq_nobr.Rows.Find(Row["nobr"].ToString());
                            if (row2 == null)
                            {
                                DataRow aRow2 = rq_nobr.NewRow();
                                aRow2["nobr"] = Row["nobr"].ToString();
                                rq_nobr.Rows.Add(aRow2);
                            }
                        }
                    }
                    rq_attend = null;
                }                   
            }

            //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_check, "C:\\TEMP\\zz2s.xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\zz2s.xls");

            //發送個人有mail
            if (person)
            {
                foreach (DataRow Row1 in rq_nobr.Rows)
                {
                    DataRow[] SRow = rq_check.Select("nobr='" + Row1["nobr"].ToString() + "'", "nobr,attdate asc");
                    string _Email = ""; string _NobrName = "";
                    foreach (DataRow Row in SRow)
                    {
                        _Email = Row["email"].ToString();
                        _NobrName = Row["name_c"].ToString();
                        DataRow aRow = Dt.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["出勤日期"] = DateTime.Parse(Row["attdate"].ToString()).ToString("yyyy/MM/dd");
                        aRow["班別"] = Row["rote"].ToString() + " (" + Row["rotename"].ToString() + ")";
                        aRow["上班時間"] = Row["tt1"].ToString();
                        aRow["下班時間"] = Row["tt2"].ToString();
                        aRow["假別名稱"] = Row["h_name"].ToString();
                        aRow["請起時間"] = Row["btime"].ToString();
                        aRow["請迄時間"] = Row["etime"].ToString();
                        aRow["請假時數"] = decimal.Parse(Row["abshr"].ToString());
                        Dt.Rows.Add(aRow);                        
                    }
                    if (Dt.Rows.Count > 0)
                    {
                        string html = ReportClass.ConvertDataTableToHtml(Dt, Dt.Rows[0]["員工編號"].ToString().Trim(),  date_b, date_e,DateTime.Now.Day.ToString());
                        if (TestSend)
                        {
                            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, date_b + "  - " + date_e + "個人通知請假與刷卡時數超過30分鐘" + TestSubject, html);
                            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, date_b + "  - " + date_e + "個人通知請假與刷卡時數超過30分鐘" + TestSubject, html);
                            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, date_b + "  - " + date_e + "個人通知請假與刷卡時數超過30分鐘" + TestSubject, html);
                        }
                        else
                        {
                            string _Subject = date_b + "  - " + date_e + "個人通知請假與刷卡時數超過30分鐘異常";
                            Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(_Email, _NobrName), _Subject, html);
                            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject, html);
                            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject, html);
                            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject, html);
                        }
                    }
                    Dt.Clear();
                }
            }

            ////發送個人無mail
            //foreach (DataRow Row in rq_deptm.Rows)
            //{
            //    DataRow[] SRow1 = rq_check.Select("email='' and deptm='" + Row["deptm"].ToString() + "'", "deptm,nobr,attdate asc");
            //    foreach (DataRow Row1 in SRow1)
            //    {
            //        DataRow aRow = Dt.NewRow();
            //        aRow["員工編號"] = Row1["nobr"].ToString();
            //        aRow["員工姓名"] = Row1["name_c"].ToString();
            //        aRow["出勤日期"] = DateTime.Parse(Row1["attdate"].ToString()).ToString("yyyy/MM/dd");
            //        aRow["班別"] = Row1["rote"].ToString() + " (" + Row1["rotename"].ToString() + ")";
            //        aRow["上班時間"] = Row1["tt1"].ToString();
            //        aRow["下班時間"] = Row1["tt2"].ToString();
            //        aRow["假別名稱"] = Row1["h_name"].ToString();
            //        aRow["請起時間"] = Row1["btime"].ToString();
            //        aRow["請迄時間"] = Row1["etime"].ToString();
            //        aRow["請假時數"] = decimal.Parse(Row1["abshr"].ToString());
            //        Dt.Rows.Add(aRow);
            //    }
            //    if (Dt.Rows.Count > 0)
            //    {
            //        string html = ReportClass.ConvertDataTableToHtml(Dt);
            //        if (TestSend)
            //        {
            //            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, date_b + "  - " + date_e + "無Mail通知請假與刷卡時數超過30分鐘" + TestSubject, html);
            //            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, date_b + "  - " + date_e + "無Mail通知請假與刷卡時數超過30分鐘" + TestSubject, html);
            //            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, date_b + "  - " + date_e + "無Mail通知請假與刷卡時數超過30分鐘" + TestSubject, html);
            //        }
            //        else
            //        {
            //            string _Subject = date_b + "  - " + date_e + "無Mail通知請假與刷卡時數超過30分鐘異常";

            //            if (Row["deptmail"].ToString().Trim() != "")
            //            {
            //                string[] _deptemail = Row["deptmail"].ToString().Split(';');
            //                foreach (string _emaila in _deptemail)
            //                {
            //                    string mm = _emaila.Trim();
            //                    if (_emaila.IndexOf("@") < 0)
            //                        mm += "@corsair.com";
            //                    Smail.SendMailWithQueue(MailFrom, mm, _Subject, html);
            //                }
            //            }
                       
            //            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, _Subject, html);
            //            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, _Subject, html);
            //            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, _Subject, html);
            //        }
            //    }
            //    Dt.Clear();
            //}

            //發送主管
            if (mange)
            {
                foreach (DataRow Row in rq_deptm.Rows)
                {
                    DataRow[] SRow1 = rq_check.Select("deptm='" + Row["deptm"].ToString() + "'", "nobr,attdate asc");
                    foreach (DataRow Row1 in SRow1)
                    {
                        DataRow aRow = Dt.NewRow();
                        aRow["員工編號"] = Row1["nobr"].ToString();
                        aRow["員工姓名"] = Row1["name_c"].ToString();
                        aRow["出勤日期"] = DateTime.Parse(Row1["attdate"].ToString()).ToString("yyyy/MM/dd");
                        aRow["班別"] = Row1["rote"].ToString() + " (" + Row1["rotename"].ToString() + ")";
                        aRow["上班時間"] = Row1["tt1"].ToString();
                        aRow["下班時間"] = Row1["tt2"].ToString();
                        aRow["假別名稱"] = Row1["h_name"].ToString();
                        aRow["請起時間"] = Row1["btime"].ToString();
                        aRow["請迄時間"] = Row1["etime"].ToString();
                        aRow["請假時數"] = decimal.Parse(Row1["abshr"].ToString());
                        Dt.Rows.Add(aRow);
                    }
                    if (Dt.Rows.Count > 0)
                    {
                        string html = ReportClass.ConvertDataTableToHtml(Dt, Dt.Rows[0]["員工編號"].ToString().Trim(), date_b, date_e, DateTime.Now.Day.ToString());
                        if (TestSend)
                        {
                            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, date_b + "  - " + date_e + "通知主管請假與刷卡時數超過30分鐘" + TestSubject, html);
                            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, date_b + "  - " + date_e + "通知主管請假與刷卡時數超過30分鐘" + TestSubject, html);
                            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, date_b + "  - " + date_e + "通知主管請假與刷卡時數超過30分鐘" + TestSubject, html);
                        }
                        else
                        {
                            string _Subject = date_b + "  - " + date_e + "通知主管請假與刷卡時數超過30分鐘異常";
                            if (Row["mangemail"].ToString().Trim() != "")
                            {
                                string[] _deptemail = Row["mangemail"].ToString().Split(';');
                                foreach (string _emaila in _deptemail)
                                {
                                    string mm = _emaila.Trim();
                                    if (_emaila.IndexOf("@") < 0)
                                        mm += "@corsair.com";
                                    Smail.SendMailWithQueue(MailFrom, mm, "部門:" + Row["da_ename"].ToString() + " " + _Subject, html);
                                }
                            }
                            //Smail.SendMailWithQueue(new System.Net.Mail.MailAddress(MailFrom), new System.Net.Mail.MailAddress(ERow["email"].ToString(), ERow["name_c"].ToString()), _Subject, html);
                            if (HRMail != "") Smail.SendMailWithQueue(MailFrom, HRMail, "部門:" + Row["da_ename"].ToString() + " " + _Subject, html);
                            if (HRMail1 != "") Smail.SendMailWithQueue(MailFrom, HRMail1, "部門:" + Row["da_ename"].ToString() + " " + _Subject, html);
                            if (HRMail2 != "") Smail.SendMailWithQueue(MailFrom, HRMail2, "部門:" + Row["da_ename"].ToString() + " " + _Subject, html);
                        }
                    }
                    Dt.Clear();
                }
            }
            rq_base = null; rq_check = null; rq_checkabs = null; rq_deptm = null; rq_nobr = null;
        }
    }
}
