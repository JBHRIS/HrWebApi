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
    public partial class ZZ4U_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_t, yymm_b, yymm_e, seq_b, seq_e, emp_b, emp_e, workadr, reporttype, comp_name;
        bool exportexcel;
        public ZZ4U_Report(string nobrb, string nobre, string deptb, string depte, string datet, string _yyb, string _yye, string _mmb, string _mme, string _seqb, string _seqe, string empb, string empe, string _workadr, string _reporttype, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; emp_b = empb; emp_e = empe;
            workadr = _workadr; exportexcel = _exportexcel;  date_t = datet;
            yymm_b = _yyb + _mmb; seq_b = _seqb; reporttype = _reporttype; comp_name = compname;
            yymm_e = _yye + _mme; seq_e = _seqe;
        }

        private void ZZ4U_Report_Load(object sender, EventArgs e)
        {
            try 
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_t);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);               
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select * from salbasnd";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);               
                DataTable rq_salbasnd = SqlConn.GetDataTable(sqlCmd1);
                if (rq_salbasnd.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                string sqlCmd2 = "select nobr,acno,yymm,amt from wagedd";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (reporttype == "0")
                    sqlCmd2 += string.Format(@" and yymm between'{0}'  and '{1}'", yymm_b, yymm_e);
                else
                    sqlCmd2 += string.Format(@" and yymm <='{0}'", yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}' ", seq_b, seq_e);
                sqlCmd2 += " order by nobr,acno,yymm";
                //if (reporttype == "1")
                //{
                //    sqlCmd2 = "select nobr,acno,sum(amt) as amt from wagedd";
                //    sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);                    
                //    sqlCmd2 += " group by nobr,acno";
                //}
                //else
                //{
                //    sqlCmd2 = "select nobr,acno,amt from wagedd";
                //    sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //    sqlCmd2 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm_b, seq_b);                    
                //}
                DataTable rq_wagedda = SqlConn.GetDataTable(sqlCmd2);

                DataTable rq_wagedd = new DataTable();
                rq_wagedd.Columns.Add("nobr", typeof(string));
                rq_wagedd.Columns.Add("yymm", typeof(string));
                rq_wagedd.Columns.Add("acno", typeof(string));               
                rq_wagedd.Columns.Add("amt", typeof(int));
                if (reporttype == "2")
                {
                    rq_wagedd.PrimaryKey = new DataColumn[] { rq_wagedd.Columns["nobr"], rq_wagedd.Columns["yymm"], rq_wagedd.Columns["acno"] };
                    foreach (DataRow Row in rq_wagedda.Rows)
                    {
                        object[] _value = new object[3];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["yymm"].ToString();
                        _value[2] = Row["acno"].ToString();
                        DataRow row = rq_wagedd.Rows.Find(_value);
                        if (row != null)
                            row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        else
                        {
                            DataRow aRow = rq_wagedd.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["yymm"] = Row["yymm"].ToString();
                            aRow["acno"] = Row["acno"].ToString();
                            aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                            rq_wagedd.Rows.Add(aRow);
                        }
                    }
                    rq_salbasnd.PrimaryKey = new DataColumn[] { rq_salbasnd.Columns["acno"] };
                    string nobracno = ""; int accumulative = 0; int accumulative1 = 0;
                    foreach (DataRow Row in rq_wagedd.Rows)
                    {
                        string nobracno1 = Row["nobr"].ToString() + Row["acno"].ToString();
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        DataRow row1 = rq_salbasnd.Rows.Find(Row["acno"].ToString());
                        if (nobracno == nobracno1)
                        {
                            accumulative += int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            accumulative = int.Parse(Row["amt"].ToString());
                        }
                        if (row != null && row1 != null)
                        {
                            DataRow aRow = ds.Tables["zz4u1"].NewRow();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["t_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(row1["t_amt"].ToString()));
                            aRow["payable"] = (nobracno == nobracno1) ? accumulative1 : int.Parse(aRow["t_amt"].ToString()) ;
                            aRow["yymm"] = Row["yymm"].ToString();
                            aRow["damt"] = int.Parse(Row["amt"].ToString());
                            aRow["accumulative"] = accumulative;
                            aRow["balance"] =int.Parse(aRow["t_amt"].ToString()) - accumulative;
                            aRow["de_dept"] = row1["de_dept"].ToString();
                            ds.Tables["zz4u1"].Rows.Add(aRow);
                            accumulative1 = int.Parse(aRow["t_amt"].ToString()) - accumulative;                                
                            nobracno = Row["nobr"].ToString() + Row["acno"].ToString();
                        }
                       
                    }

                }
                else
                {
                    rq_wagedd.PrimaryKey = new DataColumn[] { rq_wagedd.Columns["nobr"], rq_wagedd.Columns["acno"] };
                    foreach (DataRow Row in rq_wagedda.Rows)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["acno"].ToString();
                        DataRow row = rq_wagedd.Rows.Find(_value);
                        if (row != null)
                            row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        else
                        {
                            DataRow aRow = rq_wagedd.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["acno"] = Row["acno"].ToString();
                            aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                            rq_wagedd.Rows.Add(aRow);
                        }
                    }
                    foreach (DataRow Row in rq_salbasnd.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["acno"].ToString();
                        DataRow row1 = rq_wagedd.Rows.Find(_value);
                        if (row != null)
                        {
                            DataRow aRow = ds.Tables["zz4u"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            aRow["t_amt"] = decimal.Round(JBModule.Data.CDecryp.Number(decimal.Parse(Row["t_amt"].ToString())), 0);
                            aRow["damt"] = (row1 != null) ? decimal.Round(decimal.Parse(row1["amt"].ToString()), 0) : 0;
                            aRow["dispatch"] = Row["dispatch"].ToString();
                            aRow["de_dept"] = Row["de_dept"].ToString();
                            aRow["de_man"] = Row["de_man"].ToString();
                            aRow["de_tel"] = Row["de_tel"].ToString();
                            aRow["de_add"] = Row["de_add"].ToString();
                            aRow["law_dept"] = Row["law_dept"].ToString();
                            aRow["law_tel"] = Row["law_tel"].ToString();
                            aRow["p_date"] = DateTime.Parse(Row["p_date"].ToString());
                            aRow["f_date"] = DateTime.Parse(Row["f_date"].ToString());
                            aRow["t_date"] = DateTime.Parse(Row["t_date"].ToString());
                            aRow["c_date"] = DateTime.Parse(Row["c_date"].ToString());
                            aRow["memo"] = Row["memo"].ToString();
                            ds.Tables["zz4u"].Rows.Add(aRow);
                        }
                    }
                    if (ds.Tables["zz4u"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                //if (reporttype == "1")
                //{
                //    foreach (DataRow Row in rq_wagedda.Rows)
                //    {
                //        object[] _value = new object[2];
                //        _value[0] = Row["nobr"].ToString();
                //        _value[1] = Row["acno"].ToString();                       
                //        DataRow row = rq_wagedd.Rows.Find(_value);
                //        if (row != null)
                //            row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                //        else
                //        {
                //            DataRow aRow = rq_wagedd.NewRow();
                //            aRow["nobr"] = Row["nobr"].ToString();
                //            aRow["acno"] = Row["acno"].ToString();                            
                //            aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                //            rq_wagedd.Rows.Add(aRow);
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (DataRow Row in rq_wagedda.Rows)
                //    {
                //        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                //        rq_wagedd.ImportRow(Row);
                //    }
                //}
                
                rq_base = null; rq_salbasnd = null; rq_wagedd = null; rq_wagedda = null;
               

                if (exportexcel)
                {
                    if (reporttype=="2")
                        Export1(ds.Tables["zz4u1"]);
                    else
                        Export(ds.Tables["zz4u"]);
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
                    if (reporttype=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4u1.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4u.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4u2.rdlc";
                   
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    if (reporttype == "2")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMMB", yymm_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMME", yymm_e) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4u1", ds.Tables["zz4u1"]));
                    }
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4u", ds.Tables["zz4u"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                } 

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
        }

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();

            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("應繳金額", typeof(int));
            if (reporttype == "1")
                ExporDt.Columns.Add("已繳金額", typeof(int));
            else
                ExporDt.Columns.Add("當期已繳金額", typeof(int));
            ExporDt.Columns.Add("發文字號", typeof(string));
            ExporDt.Columns.Add("債權單位", typeof(string));
            if (reporttype == "1")
                ExporDt.Columns.Add("代收人", typeof(string));
            else
                ExporDt.Columns.Add("戶名", typeof(string));
            ExporDt.Columns.Add("聯絡電話", typeof(string));
            ExporDt.Columns.Add("地址", typeof(string));
            ExporDt.Columns.Add("承辦單位", typeof(string));
            ExporDt.Columns.Add("承辦人", typeof(string));
            ExporDt.Columns.Add("聯絡電話1", typeof(string));
            ExporDt.Columns.Add("發文日期", typeof(DateTime));
            ExporDt.Columns.Add("收件日期", typeof(DateTime));
            ExporDt.Columns.Add("聲明日期", typeof(DateTime));
            ExporDt.Columns.Add("結案日期", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["應繳金額"] = int.Parse(Row01["t_amt"].ToString());
                if (reporttype=="1")
                    aRow["已繳金額"] = int.Parse(Row01["damt"].ToString());
                else
                    aRow["當期已繳金額"] = int.Parse(Row01["damt"].ToString());
                aRow["發文字號"] = Row01["dispatch"].ToString();
                aRow["債權單位"] = Row01["de_dept"].ToString();
                if (reporttype=="1")
                    aRow["代收人"] = Row01["de_man"].ToString();
                else
                    aRow["戶名"] = Row01["de_man"].ToString();
                aRow["聯絡電話"] = Row01["de_tel"].ToString();
                aRow["地址"] = Row01["de_add"].ToString();
                aRow["承辦單位"] = Row01["law_dept"].ToString();
                aRow["承辦人"] = Row01["law_man"].ToString();
                aRow["聯絡電話1"] = Row01["law_tel"].ToString();
                aRow["發文日期"] = DateTime.Parse(Row01["p_date"].ToString());
                aRow["收件日期"] = DateTime.Parse(Row01["f_date"].ToString());
                aRow["聲明日期"] = DateTime.Parse(Row01["t_date"].ToString());
                aRow["結案日期"] = DateTime.Parse(Row01["c_date"].ToString());
                aRow["備註"] = Row01["memo"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("總額", typeof(int));
            ExporDt.Columns.Add("應繳金額", typeof(int));
            ExporDt.Columns.Add("薪資年月", typeof(string));
            ExporDt.Columns.Add("扣繳金額", typeof(int));
            ExporDt.Columns.Add("扣繳金額累計", typeof(int));
            ExporDt.Columns.Add("餘款", typeof(int));
            ExporDt.Columns.Add("債權單位", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["總額"] = int.Parse(Row01["t_amt"].ToString());   
                aRow["應繳金額"] = int.Parse(Row01["payable"].ToString());
                aRow["薪資年月"] = Row01["yymm"].ToString();
                aRow["扣繳金額"] = int.Parse(Row01["damt"].ToString());
                aRow["扣繳金額累計"] = int.Parse(Row01["accumulative"].ToString());
                aRow["餘款"] = int.Parse(Row01["balance"].ToString());
                aRow["債權單位"] = Row01["de_dept"].ToString();          
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
