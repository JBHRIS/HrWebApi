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
    public partial class ZZ39_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, work_b, work_e, type_data, comp_name;
        bool exportexcel;
        public ZZ39_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string workb, string worke, string typedata, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            date_b = dateb; date_e = datee; work_b = workb; work_e = worke;
            exportexcel = _exportexcel; type_data = typedata; comp_name = compname;
        }

        private void ZZ39_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.birdt,a.idno from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", DateTime.Now.ToShortDateString());               
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //string sqlCmd3 = "select nobr,l_amt from inslab";
                //sqlCmd3 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd3 += string.Format(@" and '{0}' between in_date and out_date", date_e);
                //sqlCmd3 += " and fa_idno='' ";
                //DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd3);
                //rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.fa_idno,a.grp_type,a.code,a.pan,b.plan_no_disp,a.amt1,a.amt2,a.amt3,a.amt4,a.amt5";
                sqlCmd1 += ",a.amt6,a.in_date,a.out_date";
                sqlCmd1 += " from insgrp a left outer join insgrlv b on a.pan=b.plan_no";
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and (a.in_date between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" or a.out_date between '{0}' and '{1}' )", date_b, date_e);
                DataTable rq_insgrp = SqlConn.GetDataTable(sqlCmd1);
                rq_insgrp.Columns.Add("idno", typeof(string));
                rq_insgrp.Columns.Add("name_c", typeof(string));
                rq_insgrp.Columns.Add("birdt", typeof(DateTime));
                Int32 _dateb = Convert.ToInt32(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                Int32 _datee = Convert.ToInt32(DateTime.Parse(date_e).ToString("yyyyMMdd"));
                foreach (DataRow Row in rq_insgrp.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        //DataRow row1 = rq_inslab.Rows.Find(Row["nobr"].ToString());
                        Row["idno"] = row["idno"].ToString();
                        Row["name_c"] = row["name_c"].ToString();
                        Row["birdt"] = DateTime.Parse(row["birdt"].ToString());                       
                        Row["amt1"] = (decimal.Parse(Row["amt1"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt1"].ToString()));
                        Row["amt2"] = (decimal.Parse(Row["amt2"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt2"].ToString()));
                        Row["amt3"] = (decimal.Parse(Row["amt3"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt3"].ToString()));
                        Row["amt4"] = (decimal.Parse(Row["amt4"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt4"].ToString()));
                        Row["amt5"] = (decimal.Parse(Row["amt5"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt5"].ToString()));
                        Row["amt6"] = (decimal.Parse(Row["amt6"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt6"].ToString()));
                        Int32 _indate = Convert.ToInt32(DateTime.Parse(Row["in_date"].ToString()).ToString("yyyyMMdd"));
                        Int32 _outdate = Convert.ToInt32(DateTime.Parse(Row["out_date"].ToString()).ToString("yyyyMMdd"));
                        if (_indate >= _dateb && _indate <= _datee)
                            Row["code"] = "加保";
                        if (_outdate >= _dateb && _outdate <= _datee)
                            Row["code"] = "退保";
                    }
                    else
                        Row.Delete();
                }
                rq_insgrp.AcceptChanges();
                if (rq_insgrp.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataRow [] SRow = rq_insgrp.Select("", "nobr,idno asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow aRow = ds.Tables["zz39"].NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    //aRow["name_e"] = Row["name_e"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                    aRow["pan"] = Row["pan"].ToString();
                    aRow["code"] = Row["code"].ToString();
                    aRow["amt1"] = int.Parse(Row["amt1"].ToString());
                    aRow["amt2"] = int.Parse(Row["amt2"].ToString());
                    aRow["amt3"] = int.Parse(Row["amt3"].ToString());
                    aRow["amt4"] = int.Parse(Row["amt4"].ToString());
                    aRow["amt5"] = int.Parse(Row["amt5"].ToString());
                    aRow["amt6"] = int.Parse(Row["amt6"].ToString());
                    aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                    aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                    aRow["plan_no_disp"] = Row["plan_no_disp"].ToString();
                    ds.Tables["zz39"].Rows.Add(aRow);
                }
                rq_base = null; rq_insgrp = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz39"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz391.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz39", ds.Tables["zz39"]));
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

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("計畫", typeof(string));
            ExporDt.Columns.Add("職災薪資", typeof(int));
            ExporDt.Columns.Add("勞保投保薪資", typeof(int));
            ExporDt.Columns.Add("異動別", typeof(string));
            ExporDt.Columns.Add("異動日期", typeof(DateTime));
            ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["身分證號"] = Row01["idno"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["計畫"] = Row01["plan_no_disp"].ToString();
                aRow["職災薪資"] = int.Parse(Row01["amt5"].ToString());
                aRow["勞保投保薪資"] = int.Parse(Row01["amt6"].ToString());
                aRow["異動別"] =Row01["code"].ToString();
                aRow["異動日期"] = (Row01["code"].ToString().Trim() == "加保") ? DateTime.Parse(Row01["in_date"].ToString()) : DateTime.Parse(Row01["out_date"].ToString());
                aRow["備註"] = "";
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
