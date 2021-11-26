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
    public partial class ZZ4R_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, dept_b, dept_e, date_b, comp_name;
        string yymm_b, yymm_e, username, workadr, CompId,emp_b,emp_e;
        bool exportexcel;
        public ZZ4R_Report(string typedata, string nobrb, string nobre, string yearb, string yeare, string monthb, string monthe, string seqb, string seqe, string deptb, string depte,string empb,string empe, string dateb, string _workadr, string _username, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; yymm_b = yearb + monthb;
            yymm_e = yeare + monthe; seq_b = seqb; seq_e = seqe; dept_b = deptb; dept_e = depte;
            date_b = dateb; username = _username; exportexcel = _exportexcel; workadr = _workadr;
            comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
        }

        private void ZZ4R_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";               
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,yymm,seq,cash,account_no from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += " and format!=''";
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                DataTable rq_sys2 = SqlConn.GetDataTable("select welsalcode from u_sys2 where comp='" + CompId + "'");
                string welsalcode = (rq_sys2.Rows.Count > 0) ? rq_sys2.Rows[0]["welsalcode"].ToString() : "";

                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd2 += string.Format(@" and sal_code='{0}'", welsalcode);
                sqlCmd2 += " and amt<>10 order by yymm,nobr";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                ds.Tables["zz4r"].PrimaryKey = new DataColumn[] { ds.Tables["zz4r"].Columns["nobr"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = ds.Tables["zz4r"].Rows.Find(Row["nobr"].ToString());
                    if (row != null && row1!=null)
                    {
                        if (row2 != null)
                        {
                            for (int i = 1; i < 13; i++)
                            {
                                if (Row["yymm"].ToString().Substring(4, 2) == i.ToString().PadLeft(2, '0'))
                                {
                                    if (row2.IsNull("m" + i.ToString().PadLeft(2, '0')))
                                        row2["m" + i.ToString().PadLeft(2, '0')] = int.Parse(Row["amt"].ToString());
                                    else
                                        row2["m" + i.ToString().PadLeft(2, '0')] = int.Parse(row2["m" + i.ToString().PadLeft(2, '0')].ToString()) + int.Parse(Row["amt"].ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz4r"].NewRow();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["d_ename"] = row["d_ename"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            for (int i = 1; i < 13; i++)
                            {
                                if (Row["yymm"].ToString().Substring(4, 2) == i.ToString().PadLeft(2, '0'))
                                {
                                    aRow["m" + i.ToString().PadLeft(2, '0')] = int.Parse(Row["amt"].ToString());
                                    break;
                                }
                            }
                            ds.Tables["zz4r"].Rows.Add(aRow);
                        }
                    }
                }


                if (ds.Tables["zz4r"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4r"]);
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
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4r.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4r", ds.Tables["zz4r"]));
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
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("十二月", typeof(int));
            ExporDt.Columns.Add("一月", typeof(int));
            ExporDt.Columns.Add("二月", typeof(int));
            ExporDt.Columns.Add("三月", typeof(int));
            ExporDt.Columns.Add("四月", typeof(int));
            ExporDt.Columns.Add("五月", typeof(int));
            ExporDt.Columns.Add("六月", typeof(int));
            ExporDt.Columns.Add("七月", typeof(int));
            ExporDt.Columns.Add("八月", typeof(int));
            ExporDt.Columns.Add("九月", typeof(int));
            ExporDt.Columns.Add("十月", typeof(int));
            ExporDt.Columns.Add("十一月", typeof(int));
            DataRow[] SRow = DT.Select("", "dept asc");
            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["十二月"] = (Row01.IsNull("m12")) ? 0 : int.Parse(Row01["m12"].ToString());
                aRow["一月"] = (Row01.IsNull("m01")) ? 0 : int.Parse(Row01["m01"].ToString());
                aRow["二月"] = (Row01.IsNull("m02")) ? 0 : int.Parse(Row01["m02"].ToString());
                aRow["三月"] = (Row01.IsNull("m03")) ? 0 : int.Parse(Row01["m03"].ToString());
                aRow["四月"] = (Row01.IsNull("m04")) ? 0 : int.Parse(Row01["m04"].ToString());
                aRow["五月"] = (Row01.IsNull("m05")) ? 0 : int.Parse(Row01["m05"].ToString());
                aRow["六月"] = (Row01.IsNull("m06")) ? 0 : int.Parse(Row01["m06"].ToString());
                aRow["七月"] = (Row01.IsNull("m07")) ? 0 : int.Parse(Row01["m07"].ToString());
                aRow["八月"] = (Row01.IsNull("m08")) ? 0 : int.Parse(Row01["m08"].ToString());
                aRow["九月"] = (Row01.IsNull("m09")) ? 0 : int.Parse(Row01["m09"].ToString());
                aRow["十月"] = (Row01.IsNull("m10")) ? 0 : int.Parse(Row01["m10"].ToString());
                aRow["十一月"] = (Row01.IsNull("m11")) ? 0 : int.Parse(Row01["m11"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
