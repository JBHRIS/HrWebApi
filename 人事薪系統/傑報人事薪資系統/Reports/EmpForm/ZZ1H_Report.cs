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
    public partial class ZZ1H_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b,date_e, nobr_b, nobr_e, dept_b, dept_e, work_b, work_e, contract_b, contract_e, data_type, username, comp_name,ttstype;
        bool exportexcel;
        public ZZ1H_Report(string dateb,string datee, string nobrb, string nobre, string deptb, string depte, string workb, string worke, string contractb, string contracte, string datatype,string _ttstype, string _username, bool _exportexcel, string compname)
        {
            InitializeComponent();
            date_b = dateb; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            work_b = workb; work_e = worke; data_type = datatype; username = _username;
            exportexcel = _exportexcel; ttstype = _ttstype; contract_b = contractb;
            contract_e = contracte; comp_name = compname; date_e = datee;
        }

        private void ZZ1H_Report_Load(object sender, EventArgs e)
        {            
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select c.*,a.name_c,d.d_no_disp as dept,d.d_name from contract c, base a,basetts b";
                sqlCmd += " left outer join dept d on b.dept=d.d_no";
                sqlCmd += " where c.nobr=a.nobr and c.nobr =b.nobr";
                sqlCmd += " and c.adate between b.adate and b.ddate ";
                sqlCmd += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.workadr between '{0}' and '{1}'", work_b, work_e);
                sqlCmd += string.Format(@" and c.contracttype between '{0}' and '{1}'", contract_b, contract_e);
                if (ttstype=="0") 
                    sqlCmd += string.Format(@" and '{0}' between c.adate and c.ddate", date_b);
                else if (ttstype == "2")
                    sqlCmd += string.Format(@" and c.ddate between '{0}' and '{1}'", date_b,date_e);
                sqlCmd += data_type;
                sqlCmd += " and b.ttscode in ('1','4','6')";
                sqlCmd += " order by d.d_no_disp,c.nobr";
                DataTable rq_contract = SqlConn.GetDataTable(sqlCmd);

                DataTable rq_workcd = SqlConn.GetDataTable("select work_code,work_addr from workcd");
                rq_workcd.PrimaryKey = new DataColumn[] { rq_workcd.Columns["work_code"] };

                DataTable rq_contracttype = SqlConn.GetDataTable("select code,displayname from contracttype");
                rq_contracttype.PrimaryKey = new DataColumn[] { rq_contracttype.Columns["code"] };
                foreach (DataRow Row in rq_contract.Rows)
                {
                    DataRow row = rq_contracttype.Rows.Find(Row["contracttype"].ToString());
                    DataRow row1 = rq_workcd.Rows.Find(Row["workadr"].ToString());
                    DataRow aRow = ds.Tables["zz1h"].NewRow();
                    var yymm= (TimeSpan)(DateTime.Parse(Row["ddate"].ToString()) - DateTime.Parse(Row["adate"].ToString()));
                    string _yymm = yymm.SpanTimeString("y年M月");
                    string _yymm1 = _yymm.Substring(0, _yymm.IndexOf("年")) + "." + _yymm.Substring(_yymm.IndexOf("年")+1, _yymm.Length - _yymm.IndexOf("年") - 2);
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["ddate"] = DateTime.Parse(Row["ddate"].ToString());
                    aRow["contracttype"] = Row["contracttype"].ToString();
                    aRow["contractname"] = (row != null) ? row["displayname"].ToString() : "";
                    aRow["years"] =yymm.SpanTimeString("y年M月") ;
                    aRow["workadr"] = Row["workadr"].ToString();
                    aRow["workname"] = (row1 != null) ? row1["work_addr"].ToString() : "";
                    aRow["yeard"] = decimal.Parse(_yymm1);
                    ds.Tables["zz1h"].Rows.Add(aRow);
                }
                if (ds.Tables["zz1h"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz1h"]);
                    this.Close();
                }
                else
                {
                    string RptName = "";
                    RptName = (ttstype=="0") ? "合同異動記錄表" : "合同明細表";
                    
                    RptViewer.Reset();                   
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");

                    if (ttstype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1h1.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1h.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("RptName", RptName) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_zz1h", ds.Tables["zz1h"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    RptViewer.ZoomPercent = 35;
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
            ExporDt.Columns.Add("合同類別", typeof(string));
            ExporDt.Columns.Add("起始日期", typeof(DateTime));
            ExporDt.Columns.Add("到期日期", typeof(DateTime));
            ExporDt.Columns.Add("年限", typeof(decimal));
            if (ttstype == "0") ExporDt.Columns.Add("派駐地區", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["合同類別"] = Row["contractname"].ToString();
                aRow["起始日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["到期日期"] = DateTime.Parse(Row["ddate"].ToString());
                aRow["年限"] = decimal.Parse(Row["yeard"].ToString());
                if (ttstype == "0") aRow["派駐地區"] = Row["workname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}

