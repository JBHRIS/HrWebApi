using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections;
//using JBHR.BLL.Repo;
using JBModule.Data.Linq;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ12_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, birtd_b, birtd_e, username, locals, data_report, comp_name;
        bool exportexcel;

        public ZZ12_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string birtdb, string birtde, bool _exportexcel, string _username, string _locals, string datareport, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; locals = _locals;
            exportexcel = _exportexcel; birtd_b = birtdb; birtd_e = birtde;
            data_report = datareport; comp_name = compname; username = _username;
        }       

        private void ZZ12_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "SELECT B.NOBR,B.INDT,A.NAME_C,A.NAME_E,C.d_no_disp AS DEPT,C.D_NAME,A.BIRDT," +
                        "D.D_NO_DISP AS DEPTS,D.D_NAME AS DS_NAME,B.EMPCD,E.EMPDESCR,B.WORKCD,F.WORK_ADDR," +
                        "DATEDIFF(DAY,B.INDT,GETDATE()) AS BIR_DAY,A.GIFT" +                       
                        " FROM BASE A,BASETTS B"+
                        " LEFT OUTER JOIN DEPT C ON  B.DEPT=C.D_NO"+
                        " LEFT OUTER JOIN DEPTS D ON  B.DEPTS=D.D_NO" +
                        " LEFT OUTER JOIN EMPCD E ON  B.EMPCD=E.EMPCD" +
                        " LEFT OUTER JOIN WORKCD F ON  B.WORKCD=F.WORK_CODE" +
                        " WHERE A.NOBR=B.NOBR" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +                       
                        " AND B.TTSCODE IN('1','4','6')" +
                        " AND B.INDT<='" + date_e + "'" +
                        " " + locals + "" +
                        " " + data_report + "" +
                        " AND  MONTH(A.BIRDT) BETWEEN '" + birtd_b + "' AND '" + birtd_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "' ORDER BY B.DEPT,MONTH(A.BIRDT),B.NOBR";
                DataTable rq_zz12s2 = SqlConn.GetDataTable(sqlCmd);
                rq_zz12s2.Columns.Add("giftname", typeof(string));

                DataTable rq_gift = SqlConn.GetDataTable("select code,giftname from GiftVoucher");
                rq_gift.PrimaryKey = new DataColumn[] { rq_gift.Columns["code"] };

                //DataTable rq_test = new DataTable();
                //BaseRepo baseRepo = new BaseRepo();
                //List<BASE> baseList = baseRepo.GetHoldEmpByDateTime_DLO(DateTime.Parse(date_b));
                //var dt = (from c in baseList
                //          where c.BASETTS[0].INDT <= Convert.ToDateTime(date_e)
                //          && c.BASETTS[0].COMP.CompareTo(comp_b) >= 0
                //          && c.BASETTS[0].COMP.CompareTo(comp_e) <= 0
                //          && c.BASETTS[0].DEPT.CompareTo(dept_b) >= 0
                //          && c.BASETTS[0].DEPT.CompareTo(dept_e) <= 0
                //          && c.BASETTS[0].EMPCD.CompareTo(emp_b) >= 0
                //          && c.BASETTS[0].EMPCD.CompareTo(emp_e) <= 0
                //          && c.BIRDT.Value.Month.CompareTo(int.Parse(birtd)) == 0                          
                //          orderby c.BASETTS[0].DEPT, c.NOBR
                //          select new { c.NOBR, c.BASETTS[0].INDT, c.NAME_C, c.NAME_E, DEPT = c.BASETTS[0].DEPT1.D_NO_DISP, c.BASETTS[0].DEPT1.D_NAME, c.BIRDT, c.COUNT_MA, year = baseRepo.GetTotalYears(c.NOBR, DateTime.Now)});

                //if (locals != "") dt = from q4 in dt where q4.COUNT_MA == false select q4; ;

                //DataTable rq_zz12s2 = dt.CopyToDataTable();           
               
                if (rq_zz12s2.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                foreach (DataRow Row in rq_zz12s2.Rows)
                {
                    DataRow row = rq_gift.Rows.Find(Row["gift"].ToString());
                    Row["giftname"] = (row != null) ? row["giftname"].ToString() : "";
                    ds.Tables["rq_zz12s1"].ImportRow(Row);
                }
                rq_zz12s2 = null;

                if (exportexcel)
                {                    
                    Export(ds.Tables["rq_zz12s1"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz12.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company",comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Montht_B", birtd_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Montht_E", birtd_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz12s1", ds.Tables["rq_zz12s1"]));
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
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(string));
            ExporDt.Columns.Add("員別代碼", typeof(string));
            ExporDt.Columns.Add("員別名稱", typeof(string));
            ExporDt.Columns.Add("工作地代碼", typeof(string));
            ExporDt.Columns.Add("工作地", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));           
            ExporDt.Columns.Add("禮卷", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row["depts"].ToString();
                aRow["成本名稱"] = Row["ds_name"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["出生日期"] = Convert.ToString(DateTime.Parse(Row["birdt"].ToString()).Month).PadLeft(2, '0') + "/" + Convert.ToString(DateTime.Parse(Row["birdt"].ToString()).Day).PadLeft(2, '0');
                aRow["員別代碼"] = Row["empcd"].ToString();
                aRow["員別名稱"] = Row["empdescr"].ToString();
                aRow["工作地代碼"] = Row["workcd"].ToString();
                aRow["工作地"] = Row["work_addr"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["禮卷"] = Row["giftname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
