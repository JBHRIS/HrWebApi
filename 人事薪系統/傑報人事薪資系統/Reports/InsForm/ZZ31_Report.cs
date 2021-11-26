using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ31_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, sno_b, sno_e, insure_type, reporttype, insuername, type_data, comp_name, CompId;
        bool exportexcel, nocompexp;
        public ZZ31_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string snob, string snoe, string insuretype, string _reporttype, string _insuername, string typedata, bool _exportexcel, string compname, string _CompId, bool _nocompexp)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            sno_b = snob; sno_e = snoe; insure_type = insuretype;reporttype = _reporttype;
            exportexcel = _exportexcel; insuername = _insuername; type_data = typedata;
            comp_name = compname; CompId = _CompId; nocompexp = _nocompexp;
        }

        private void ZZ31_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,a.birdt,b.retrate,";
                if (reporttype == "4" || reporttype == "5")
                    sqlCmd += "e.d_no_disp as dept,e.d_name,'' as d_ename";
                else
                    sqlCmd += "c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += " from base a,basetts b";
                if (reporttype == "4" || reporttype == "5")
                    sqlCmd += " left outer join depts e on b.depts=e.d_no";                
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                DataTable rq_family = SqlConn.GetDataTable("select nobr,fa_idno,fa_name,fa_birdt from family");
                rq_family.PrimaryKey = new DataColumn[] { rq_family.Columns["nobr"], rq_family.Columns["fa_idno"] };
                DataTable rq_larcode = SqlConn.GetDataTable("select * from larcode");
                rq_larcode.PrimaryKey = new DataColumn[] { rq_larcode.Columns["rate_code"] };
                DataTable rq_harcode = SqlConn.GetDataTable("select * from harcode");
                rq_harcode.PrimaryKey = new DataColumn[] { rq_harcode.Columns["rate_code"] };
                DataTable rq_inscomp = SqlConn.GetDataTable("select * from inscomp");
                rq_inscomp.PrimaryKey = new DataColumn[] { rq_inscomp.Columns["s_no"] };
                string sqlCmd1 = "";
                switch (insure_type)
                { 
                    case "0":
                        sqlCmd1 = "select a.*,b.jobaccrate from inslab a ";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.in_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " order by a.nobr";
                        break;
                    case "1":
                        sqlCmd1 = "select a.*,b.jobaccrate from inslab a ";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.out_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " order by a.nobr";
                        break;
                    case "2":
                        sqlCmd1 = "select a.*,b.jobaccrate from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.in_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.code='2'";
                        sqlCmd1 += " order by a.nobr";
                        break;
                    case "3":
                        sqlCmd1 = "select a.*,b.jobaccrate from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += "  where nobr+fa_idno+convert(char,in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) ";
                        sqlCmd1 += " from inslab a ,harcode b where a.hrate_code=b.rate_code";
                        sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and a.in_date<='{0}'", date_e);
                        if (nocompexp && reporttype == "3")
                            sqlCmd1 += " and a.fa_idno='' and b.compcharge>0";
                        sqlCmd1 += " group by a.nobr,a.fa_idno)";
                        sqlCmd1 += string.Format(@" and '{0}' between in_date and out_date", date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " order by nobr";
                        break;
                    case "5":
                        sqlCmd1 = "select a.*,b.jobaccrate from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and ('{0}' between a.in_date and a.out_date", date_e);
                        sqlCmd1 += string.Format(@" or '{0}' between a.in_date and a.out_date)", date_b);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " order by a.nobr";
                        break;
                    default:
                        sqlCmd1 = "select a.*,b.jobaccrate,30 as insday,1 as helday,0 as h_exp,convert(bit,0) as zero,0 as h_exp1";
                        sqlCmd1 += " from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";                        
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " order by a.nobr";
                        break;
                }
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd1);                
                rq_inslab.Columns.Add("name_c", typeof(string));
                rq_inslab.Columns.Add("name_e", typeof(string));
                rq_inslab.Columns.Add("dept",typeof(string));
                rq_inslab.Columns.Add("d_name",typeof(string));
                rq_inslab.Columns.Add("d_ename", typeof(string));
                rq_inslab.Columns.Add("idno", typeof(string));
                rq_inslab.Columns.Add("birdt", typeof(DateTime));
                rq_inslab.Columns.Add("eff_rate", typeof(decimal));
                rq_inslab.Columns.Add("retrate", typeof(decimal));
                
                if (insure_type == "5")
                {
                    rq_inslab.Columns.Add("insday", typeof(int));
                    rq_inslab.Columns.Add("helday", typeof(int));
                    foreach (DataRow Row in rq_inslab.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            Row["insday"] = 30;
                            Row["helday"] = 1;
                            DateTime outdate = DateTime.Parse(Row["out_date"].ToString());
                            DateTime indate = DateTime.Parse(Row["in_date"].ToString());
                            DateTime _dateb = DateTime.Parse(date_b);
                            DateTime _datee = DateTime.Parse(date_e);
                            int aa = int.Parse(outdate.ToString("yyyyMMdd"));
                            int bb = int.Parse(_dateb.ToString("yyyyMMdd"));
                            int cc = int.Parse(indate.ToString("yyyyMMdd"));
                            int dd = int.Parse(_datee.ToString("yyyyMMdd"));
                            if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")) && !(Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))))
                                Row["insday"] = outdate.Day;
                            if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")) && (Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))))
                                Row["insday"] = ((TimeSpan)(outdate - indate)).Days + 1;
                            if (!(Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))) && Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] = ((TimeSpan)(_datee - indate)).Days + 1;
                            if (!(Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))) && Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] = 30 - indate.Day + 1;
                            if (Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) == Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] = 30;
                            if (int.Parse(Row["insday"].ToString()) > 30)
                                Row["insday"] = 30;
                            if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) != Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["helday"] = 0;                           
                            Row["name_c"] = row["name_c"].ToString().Trim();
                            Row["name_e"] = row["name_e"].ToString().Trim();
                            Row["dept"] = row["dept"].ToString();
                            Row["d_name"] = row["d_name"].ToString();
                            Row["d_ename"] = row["d_ename"].ToString();
                            Row["idno"] = row["idno"].ToString();
                            Row["birdt"] = DateTime.Parse(row["birdt"].ToString());
                            Row["retrate"] = decimal.Parse(row["retrate"].ToString());
                            Row["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));
                            Row["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                            Row["r_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["r_amt"].ToString()));
                            string sqlCmda = "select amt,eff_rate from insurlv where";
                            //sqlCmda += string.Format(@" '{0}' between  eff_dateh and lff_dateh", DateTime.Parse(Row["in_date"].ToString()).ToString("yyyy/MM/dd"));
                            sqlCmda += string.Format(@" '{0}' between  eff_dateh and lff_dateh", date_e);
                            sqlCmda += string.Format(@" and amt={0}", decimal.Parse(Row["h_amt"].ToString()));
                            DataTable rq_insurlv = SqlConn.GetDataTable(sqlCmda);
                            Row["eff_rate"] = (rq_insurlv.Rows.Count > 0) ? decimal.Parse(rq_insurlv.Rows[0]["eff_rate"].ToString()) : 0;
                            rq_insurlv.Clear();
                        }
                        else
                            Row.Delete();
                    }
                }
                else
                {
                    foreach (DataRow Row in rq_inslab.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            Row["idno"] = row["idno"].ToString().Trim();
                            Row["name_c"] = row["name_c"].ToString().Trim();
                            Row["name_e"] = row["name_e"].ToString().Trim();
                            Row["dept"] = row["dept"].ToString();
                            Row["d_name"] = row["d_name"].ToString();
                            Row["d_ename"] = row["d_ename"].ToString();
                            Row["idno"] = row["idno"].ToString();
                            Row["birdt"] = DateTime.Parse(row["birdt"].ToString());
                            Row["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));
                            Row["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                            Row["r_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["r_amt"].ToString()));
                            string sqlCmdb = "select amt,eff_rate from insurlv where";
                            sqlCmdb += string.Format(@" '{0}' between  eff_dateh and lff_dateh", DateTime.Parse(Row["in_date"].ToString()).ToString("yyyy/MM/dd"));
                            sqlCmdb += string.Format(@" and amt={0}", decimal.Parse(Row["h_amt"].ToString()));
                            DataTable rq_insurlv = SqlConn.GetDataTable(sqlCmdb);
                            Row["eff_rate"] = (rq_insurlv.Rows.Count > 0) ? decimal.Parse(rq_insurlv.Rows[0]["eff_rate"].ToString()) : 0;
                            rq_insurlv.Clear();
                        }
                        else
                            Row.Delete();
                    }
                }
                rq_inslab.AcceptChanges();
                
                if (rq_inslab.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_inslab.Rows)
                {
                    DataRow row = rq_inscomp.Rows.Find(Row["s_no"].ToString());
                    if (row != null)
                        Row["s_no"] = row["s_no_disp"].ToString();
                }
                switch (reporttype)
                { 
                    case "0":
                    case "1":
                        ZZ31Class.Get_ZZ31(ds.Tables["zz31"], rq_inslab, rq_larcode,reporttype);
                        break;
                    case "2":
                    case "3":
                        ZZ31Class.Get_ZZ312(ds.Tables["zz312"], rq_inslab, rq_harcode,rq_family, reporttype);
                        break;
                    case "4":
                        //計算勞保分攤：
                        //1.	勞保個人分攤：勞保投保金額*(勞保普通事故費率＋勞保失業給付費率)*保險天數*勞保員工負擔比率*勞保部分負擔比率/30
                        //2.	勞保公司分攤：勞保投保金額*(勞保普通事故費率＋勞保失業給付費率)*保險天數*勞保公司負擔比率/30
                        //3.	職業災害：勞保投保金額*保險天數*勞保職業災害費率/30
                        //4.	墊償基金：勞保投保金額*0.00025
                        
                        ZZ31Class.Get_ZZ313(ds.Tables["zz313"], rq_inslab, rq_larcode);
                        
                        break;
                    case "5":
                        //計算健保分攤：
                        //1.	健保公司分攤：健保投保金額*公司負擔眷口數*健保費率*健保部分負擔比率，眷屬身份證為空白才計算
                        //2.	健保個人分攤：健保投保金額*健保個人負擔比率*健保部分負擔比率*健保費率，健保固定費用為0才計算
                        //3.	健保被險人滿4人，則第五人起健保費為0
                        DataTable rq_sys5 = SqlConn.GetDataTable("select compersoncnt,heacomprate from u_sys5 where comp='" + CompId + "'");
                        decimal compersoncnt = (rq_sys5.Rows.Count > 0) ? decimal.Parse(rq_sys5.Rows[0]["compersoncnt"].ToString()) : 0;
                        decimal heacomprate = (rq_sys5.Rows.Count > 0) ? decimal.Parse(rq_sys5.Rows[0]["heacomprate"].ToString()) : 0;
                        
                        ZZ31Class.Get_ZZ314(ds.Tables["zz314"], rq_inslab, rq_harcode,rq_family, compersoncnt, heacomprate,date_b);
                        rq_sys5 = null;
                        
                       
                        break;
                    case "6":
                        ZZ31Class.Get_ZZ315(ds.Tables["zz315"], rq_inslab, rq_larcode, rq_harcode);                        
                        break;
                    default :
                        break;
                }
                rq_base = null; rq_family = null; rq_harcode = null; rq_inscomp = null; rq_inslab = null;
                rq_larcode = null;
                if (exportexcel)
                {
                    if (reporttype=="0" ||reporttype=="1")
                        JBHR.Reports.InsForm.ZZ31Class.ExPort1(ds.Tables["zz31"], this.Name, reporttype);
                    else if (reporttype == "2" || reporttype == "3")
                        JBHR.Reports.InsForm.ZZ31Class.ExPort2(ds.Tables["zz312"], this.Name, reporttype);
                    else if (reporttype == "4")
                        JBHR.Reports.InsForm.ZZ31Class.ExPort3(ds.Tables["zz313"], this.Name);
                    else if (reporttype == "5")
                        JBHR.Reports.InsForm.ZZ31Class.ExPort4(ds.Tables["zz314"], this.Name);
                    else if (reporttype == "6")
                        JBHR.Reports.InsForm.ZZ31Class.ExPort5(ds.Tables["zz315"], this.Name);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz31.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz311.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz312.rdlc";
                    else if (reporttype == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz313.rdlc";
                    else if (reporttype == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz314.rdlc";
                    else if (reporttype == "5")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz315.rdlc";
                    else if (reporttype == "6")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz316.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Insname", insuername) });
                    if (reporttype=="0" || reporttype=="1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz31", ds.Tables["zz31"]));
                    else if (reporttype == "2" || reporttype == "3")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz312", ds.Tables["zz312"]));
                    else if (reporttype == "4")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz313", ds.Tables["zz313"]));
                    else if (reporttype == "5")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz314", ds.Tables["zz314"]));
                    else if (reporttype == "6")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz315", ds.Tables["zz315"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    RptViewer.ZoomPercent = 100;
                } 

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
        }
    }
}
