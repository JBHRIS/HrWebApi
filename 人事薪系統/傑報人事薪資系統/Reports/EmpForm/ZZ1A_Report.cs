using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ1A_Report : JBControls.JBForm
    {
        string type_data, str_comp, str_desc;
        empdata ds = new empdata();
        string date_b, nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, username, comp_name;
        bool exportexcel;
        public ZZ1A_Report(string dateb, string nobrb, string nobre, string deptb, string depte, string compb, string compe, string typedata, string strcomp, string strdesc, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe; type_data = typedata; str_comp = strcomp; str_desc = strdesc;
            exportexcel = _exportexcel; username = _username; comp_name = compname;
        }

        private void ZZ1A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "SELECT B.*,A.NAME_C,A.NAME_E,A.NOBR,E.D_NO_DISP AS DEPT,E.D_NAME FROM BASE A,LICAN B,BASETTS D" +
                        " LEFT OUTER JOIN DEPT E ON d.DEPT=E.D_NO" +
                        " WHERE D.NOBR+CONVERT(CHAR,D.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                        " WHERE ADATE<'" + date_b + "'" +
                        " AND NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " GROUP BY NOBR)" +
                        " AND A.NOBR=B.NOBR" +
                        " AND A.NOBR = D.NOBR " +
                        " AND '" + date_b + "' BETWEEN D.ADATE AND D.DDATE" +
                        " AND D.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND E.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND D.TTSCODE IN ('1','4','6') " +
                        " " + type_data + "" +
                        " " + str_comp + "" +
                        " " + str_desc + "" +
                        " ORDER BY E.D_NO_DISP,B.NOBR";
                DataTable rq_zz1as1 = SqlConn.GetDataTable(sqlCmd);

                if (rq_zz1as1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_zz1as1.Rows)
                {
                    ds.Tables["rq_zz1as1"].ImportRow(Row);
                }
                rq_zz1as1 = null;

                if (exportexcel)
                {
                    Export(ds.Tables["rq_zz1as1"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1A.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1as1", ds.Tables["rq_zz1as1"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("證照內容", typeof(string));
            ExporDt.Columns.Add("發照單位", typeof(string));
            ExporDt.Columns.Add("有效日期", typeof(DateTime));
            ExporDt.Columns.Add("國家考試", typeof(string));
            ExporDt.Columns.Add("證照號碼", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["證照內容"] = Row["descs"].ToString();
                aRow["發照單位"] = Row["comp"].ToString();
                aRow["有效日期"] = DateTime.Parse(Row["mdate"].ToString());
                aRow["國家考試"] = (bool.Parse(Row["lic_pass"].ToString())) ? "V" : "";
                aRow["證照號碼"] = Row["lic_no"].ToString();
                aRow["備註"] = Row["lic_note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
