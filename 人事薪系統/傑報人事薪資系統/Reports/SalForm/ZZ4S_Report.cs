using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4S_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, dept_b, dept_e, comp_b, comp_e, date_b, comp_name, CompId;
        string reporttype, yymm_b, yymm_e, work_b, work_e, emp_b, emp_e, workadr, workadr1, username, MedianMon;
        bool exportexcel;
        string ErrorMessage = string.Empty;
        public ZZ4S_Report(string nobrb, string nobre, string yearb, string yeare, string _mb, string _me, string _seb, string _see, string deptb, string depte, string _typedata, bool _excelexport, string dateb, string _workadr)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year_b = yearb; year_e = yeare; month_b = _mb;
            month_e = _me; seq_b = _seb; seq_e = _see; dept_b = deptb; dept_e = depte;
            yymm_b = year_b + month_b; yymm_e = year_e + month_e; type_data = _typedata; 
            exportexcel = _excelexport; date_b = dateb; workadr = _workadr;
        }

        private void ZZ4S_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_e = JBHR.Reports.ReportClass.GetSalEDate(year_e, month_e);
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.oudt,a.idno";
                sqlCmd += ",e.job_disp as job ,e.job_name,b.retchoo";
                sqlCmd += "  from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);                
                //if (workadr != "") sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                //發薪主檔
                string sqlCmd1 = "select nobr,yymm,seq,adate,bankno,account_no,cash,comp,wk_days,note,format from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                //sqlCmd1 += string.Format(@" and adate<='{0}' ", date_b);
                sqlCmd1 += workadr;
                sqlCmd1 += " and format <> space(2)";
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _kye = new DataColumn[3];
                _kye[0] = rq_wage.Columns["nobr"];
                _kye[1] = rq_wage.Columns["yymm"];
                _kye[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _kye;

                //勞健保費用
                string sqlCmd5 = "select nobr,yymm,comp from explab ";
                sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd5 += " and insur_type='4'";
                DataTable rq_explab1 = SqlConn.GetDataTable(sqlCmd5);
                DataTable rq_explab = new DataTable();                
                rq_explab.Columns.Add("nobr", typeof(string));
                rq_explab.Columns.Add("yymm", typeof(string));
                rq_explab.Columns.Add("comp", typeof(int));                
                rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"], rq_explab.Columns["yymm"] };
                foreach(DataRow Row in rq_explab1.Rows)
                {
                    DataRow[] SRow = rq_wage.Select("nobr='" + Row["nobr"].ToString() + "' and yymm='" + Row["yymm"].ToString() + "' and seq='2'");
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null && SRow.Length>0)
                    {
                        Row["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));

                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["yymm"].ToString();
                        DataRow row1 = rq_explab.Rows.Find(_value);
                        if (row1!=null)
                        {
                            row1["comp"] = int.Parse(row1["comp"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_explab.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["yymm"] = Row["yymm"].ToString();
                            aRow["comp"] = int.Parse(Row["comp"].ToString());                           
                            rq_explab.Rows.Add(aRow);
                        }
                    }
                }
                rq_explab1 = null;

                //發薪明細
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd2 += " and sal_code <> '' ";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("d_ename", typeof(string));
                rq_waged.Columns.Add("job", typeof(string));
                rq_waged.Columns.Add("job_name", typeof(string));
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("note", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("tax", typeof(bool));
                rq_waged.Columns.Add("format", typeof(string));
                rq_waged.Columns.Add("indt", typeof(DateTime));
                rq_waged.Columns.Add("retchoo", typeof(string));

                DataTable rq_zz4s = new DataTable();
                rq_zz4s.Columns.Add("nobr", typeof(string));
                rq_zz4s.Columns.Add("yymm", typeof(string));
                rq_zz4s.Columns.Add("indt", typeof(DateTime));
                rq_zz4s.Columns.Add("retchoo", typeof(string));
                rq_zz4s.Columns.Add("amt",typeof(int));
                rq_zz4s.Columns.Add("both", typeof(string));
                rq_zz4s.PrimaryKey = new DataColumn[] { rq_zz4s.Columns["nobr"], rq_zz4s.Columns["yymm"] };
               
                //薪資代碼
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,a.sal_name,a.forcash,a.notfreq,b.salattr,b.flag,b.tax";
                sqlCmd3 += " from salcode a,salattr b";
                sqlCmd3 += " where a.sal_attr=b.salattr ";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["d_ename"] = row["d_ename"].ToString();
                        Row["comp"] = row1["comp"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        Row["retchoo"] = (row.IsNull("retchoo")) ? "" : row["retchoo"].ToString();
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["flag"] = row2["flag"].ToString();
                            Row["tax"] = bool.Parse(row2["tax"].ToString());                            
                        }
                        else
                        {
                            string ErrorSalcode = "無" + Row["sal_code"].ToString() + "薪資代碼或與會計科目未關聯";
                            MessageBox.Show(ErrorSalcode, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorSalcode);
                            this.Close();
                            return;
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));

                        string ErrorAmt = Row["nobr"].ToString() + " " + Row["name_c"].ToString() + " " + Row["sal_name"].ToString() + " " + Row["amt"].ToString() + " 金額有小數點";
                        int value = 0;
                        if (!int.TryParse(Row["amt"].ToString(), out value))
                        {
                            MessageBox.Show(ErrorAmt, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorAmt);
                            this.Close();
                            return;
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_waged.AcceptChanges();

                foreach (DataRow Row in rq_waged.Select("salattr<='F'"))
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();
                    DataRow row3 = rq_zz4s.Rows.Find(_value1);
                    if (row3 != null)
                    {
                        row3["amt"] = int.Parse(row3["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_zz4s.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["retchoo"] = Row["retchoo"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        rq_zz4s.Rows.Add(aRow);
                    }
                }
                if (rq_zz4s.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                ds.Tables["zz4s"].PrimaryKey = new DataColumn[] { ds.Tables["zz4s"].Columns["yymm"] };
                foreach(DataRow Row in rq_zz4s.Rows)
                {
                    Row["both"] = "0";
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();
                    DataRow row1 = rq_explab.Rows.Find(_value1);
                    int retcomp = (row1 == null) ? 0 : int.Parse(row1["comp"].ToString());
                    DataRow row = ds.Tables["zz4s"].Rows.Find(Row["yymm"].ToString());
                    if (row!=null)
                    {
                        if (Row["retchoo"].ToString() == "0") //暫不選擇
                        {
                            row["amt_nochoo"] = int.Parse(row["amt_nochoo"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["pno_nochoo"] = int.Parse(row["pno_nochoo"].ToString()) + 1;
                        }
                        else if (Row["retchoo"].ToString() == "1") //舊製
                        {
                            row["amt_old"] = int.Parse(row["amt_old"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["pno_old"] = int.Parse(row["pno_old"].ToString()) + 1;
                        }
                        else if (Row["retchoo"].ToString() == "2") //新製
                        {
                            row["amt_new"] = int.Parse(row["amt_new"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["pno_new"] = int.Parse(row["pno_new"].ToString()) + 1;
                            row["retcomp_new"] = int.Parse(row["retcomp_new"].ToString()) + retcomp;
                        }
                        else
                        {
                            row["amt_blank"] = int.Parse(row["amt_blank"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["pno_blank"] = int.Parse(row["pno_blank"].ToString()) + 1;
                        }
                        if (Row["retchoo"].ToString() == "2" && Convert.ToDecimal(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd")) < 20050701)
                        {
                            row["amt_both"] = int.Parse(row["amt_both"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["pno_both"] = int.Parse(row["pno_both"].ToString()) + 1;
                            row["retcomp_both"] = int.Parse(row["retcomp_both"].ToString()) + retcomp;
                            Row["both"] = "1";
                        }
                        row["amt_all"] = int.Parse(row["amt_all"].ToString()) + int.Parse(Row["amt"].ToString());
                        row["pno_all"] = int.Parse(row["pno_all"].ToString()) + 1;
                    }
                    else
                    { 
                        DataRow aRow = ds.Tables["zz4s"].NewRow();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["amt_nochoo"] = 0;
                        aRow["pno_nochoo"] = 0;
                        aRow["amt_blank"] = 0;
                        aRow["pno_blank"] = 0;
                        aRow["amt_old"] = 0;
                        aRow["pno_old"] = 0;
                        aRow["amt_new"] = 0;
                        aRow["pno_new"] = 0;
                        aRow["amt_all"] = 0;
                        aRow["pno_all"] = 0;
                        aRow["amt_both"] = 0;
                        aRow["pno_both"] = 0;
                        aRow["retcomp_both"] = 0;
                        aRow["retcomp_new"] = 0;
                        aRow["retcomp_both"] = 0;
                        if (Row["retchoo"].ToString() == "0") //暫不選擇
                        {
                            aRow["amt_nochoo"] = int.Parse(Row["amt"].ToString());
                            aRow["pno_nochoo"] = 1;
                        }
                        else if (Row["retchoo"].ToString()=="1") //舊製
                        {
                            aRow["amt_old"] = int.Parse(Row["amt"].ToString());
                            aRow["pno_old"] = 1;
                        }
                        else if (Row["retchoo"].ToString()=="2") //新製
                        {
                            aRow["amt_new"] = int.Parse(Row["amt"].ToString());
                            aRow["pno_new"] = 1;
                            aRow["retcomp_new"] = retcomp;
                        }
                        else 
                        {
                            aRow["amt_blank"] = int.Parse(Row["amt"].ToString());
                            aRow["pno_blank"] = 1;
                        }
                        if (Row["retchoo"].ToString() == "2" && Convert.ToDecimal( DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd"))<20050701)
                        {
                            aRow["amt_both"] = int.Parse(Row["amt"].ToString());
                            aRow["pno_both"] = 1;
                            aRow["retcomp_both"] = retcomp;
                        }
                        aRow["amt_all"] = int.Parse(Row["amt"].ToString());
                        aRow["pno_all"] = 1;
                        ds.Tables["zz4s"].Rows.Add(aRow);
                        Row["both"] = "1";
                    }
                }
                //JBHR.Reports.ReportClass.Export(rq_zz4s, "rq_zz4s");
                rq_base = null; rq_explab = null; rq_explab1 = null; rq_salcode = null; rq_wage = null; rq_waged = null; rq_zz4s = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz4s"]);
                    this.Close();
                }
                else
                {
                    //string company = "";
                    //DataTable rq_sys = ReportClass.GetU_Sys();
                    //if (rq_sys.Rows.Count > 0)
                    //    company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4s.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", MainForm.COMPANY_NAME) });                    
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4s", ds.Tables["zz4s"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                } 
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();

            ExporDt.Columns.Add("計算年月", typeof(string));
            ExporDt.Columns.Add("舊制薪資", typeof(int));
            ExporDt.Columns.Add("舊制人數", typeof(int));
            ExporDt.Columns.Add("新制薪資", typeof(int));
            ExporDt.Columns.Add("新制人數", typeof(int));
            ExporDt.Columns.Add("新制退休提撥金額", typeof(int));
            ExporDt.Columns.Add("暫不選擇薪資", typeof(int));
            ExporDt.Columns.Add("暫不選擇人數", typeof(int));
            ExporDt.Columns.Add("無法選擇薪資", typeof(int));
            ExporDt.Columns.Add("無法選擇人數", typeof(int));
            ExporDt.Columns.Add("總薪資", typeof(int));
            ExporDt.Columns.Add("總人數", typeof(int));
            ExporDt.Columns.Add("新制有舊年資金額", typeof(int));
            ExporDt.Columns.Add("新制有舊年資人數", typeof(int));
            ExporDt.Columns.Add("新制有舊年資提撥", typeof(int));
            
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["計算年月"] = Row01["yymm"].ToString();
                aRow["舊制薪資"] = int.Parse(Row01["amt_old"].ToString());
                aRow["舊制人數"] = int.Parse(Row01["pno_old"].ToString());
                aRow["新制薪資"] = int.Parse(Row01["amt_new"].ToString());
                aRow["新制人數"] =  int.Parse(Row01["pno_new"].ToString());
                aRow["新制退休提撥金額"] = int.Parse(Row01["retcomp_new"].ToString());
                aRow["暫不選擇薪資"] = int.Parse(Row01["amt_nochoo"].ToString());
                aRow["暫不選擇人數"] = int.Parse(Row01["pno_nochoo"].ToString());
                aRow["無法選擇薪資"] = int.Parse(Row01["amt_blank"].ToString());
                aRow["無法選擇人數"] = int.Parse(Row01["pno_blank"].ToString());
                aRow["總薪資"] = int.Parse(Row01["amt_all"].ToString());
                aRow["總人數"] = int.Parse(Row01["pno_all"].ToString());
                aRow["新制有舊年資金額"] = int.Parse(Row01["amt_both"].ToString());
                aRow["新制有舊年資人數"] = int.Parse(Row01["pno_both"].ToString());
                aRow["新制有舊年資提撥"] = int.Parse(Row01["retcomp_both"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
