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
    public partial class ZZ44_Report : JBControls.JBForm
    {
        string yymm_b, yymm_e, otyymm_b, otyymm_e, dept_b, dept_e, comp_b, comp_e, emp_b, emp_e, type_data, comp_name;
        SalDataSet ds = new SalDataSet();
        bool exportexcel;
        public ZZ44_Report(string yymmb, string yymme, string otyymmb, string otyymme, string deptb, string depte, string compb, string compe, string _empb, string _empe, string typedata, bool _exportexcel, string compname)
        {
            InitializeComponent();
            yymm_b = yymmb; yymm_e = yymme; otyymm_b = otyymmb; otyymm_e = otyymme; dept_b = deptb;
            dept_e = depte; comp_b = compb; comp_e = compe; type_data = typedata; exportexcel = _exportexcel;
            comp_name = compname; emp_b = _empb; emp_e = _empe;
        }

        private void ZZ44_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string _date = DateTime.Parse(Convert.ToString(int.Parse(yymm_e.Substring(0, 4))) + "/" + yymm_e.Substring(4, 2) + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                DataTable rq_depts = SqlConn.GetDataTable("select d_no_disp,d_no,d_name from depts order by d_no");
                string sqlCmd1 = "select a.nobr,a.yymm,a.ot_hrs,a.rest_hrs,a.not_exp,a.tot_exp,a.rest_exp,a.salary,a.ot_food,a.ot_car,a.ot_dept";
                sqlCmd1 += string.Format(@" from ot a where  a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                DataTable rq_ot1 = SqlConn.GetDataTable(sqlCmd1);

                string sqlCmd2 = "select b.nobr from basetts b";
                sqlCmd2 += " left outer join dept c on b.dept=c.d_no";
                sqlCmd2 += string.Format(@" where '{0}' between b.adate and b.ddate", DateTime.Now.ToShortDateString());
                sqlCmd2 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd2 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd2 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd2 += type_data;
                DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd2);
                rq_basetts.PrimaryKey = new DataColumn[] { rq_basetts.Columns["nobr"] };

                DataTable rq_ot = new DataTable();
                rq_ot.Columns.Add("dept5", typeof(string));
                rq_ot.Columns.Add("ot_exp", typeof(int));
                rq_ot.Columns.Add("ot_expr", typeof(decimal));
                rq_ot.Columns.Add("rest_exp", typeof(decimal));
                rq_ot.Columns.Add("rest_expr", typeof(decimal));
                rq_ot.Columns.Add("ot_food", typeof(decimal));
                rq_ot.Columns.Add("ot_foodr", typeof(decimal));
                rq_ot.Columns.Add("ot_car", typeof(decimal));
                rq_ot.Columns.Add("ot_carr", typeof(decimal));
                rq_ot.Columns.Add("ot_hrs", typeof(decimal));
                rq_ot.Columns.Add("ot_hrsr", typeof(decimal));
                rq_ot.Columns.Add("rest_hrs", typeof(decimal));
                rq_ot.Columns.Add("rest_hrsr", typeof(decimal));
                rq_ot.Columns.Add("ot_cnt", typeof(decimal));
                rq_ot.Columns.Add("ot_cntr", typeof(decimal));
                rq_ot.Columns.Add("rest_cntr", typeof(decimal));
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["dept5"] };
                int ot_expt = 0; decimal ot_hrst = 0; int ot_cnnt = 0; decimal rest_hrst = 0;
                decimal rest_cntt = 0; decimal rest_expt = 0;

                DataTable rq_pno = new DataTable();
                rq_pno.Columns.Add("dept5", typeof(string));
                rq_pno.Columns.Add("nobr", typeof(string));
                rq_pno.Columns.Add("ot_cnt", typeof(int));
                rq_pno.Columns.Add("rest_cnt", typeof(int));
                rq_pno.PrimaryKey = new DataColumn[] { rq_pno.Columns["dept5"], rq_pno.Columns["nobr"] };
                foreach (DataRow Row in rq_ot1.Rows)
                {                    
                    DataRow rowb = rq_basetts.Rows.Find(Row["nobr"].ToString());                   
                    if (rowb != null)
                    {
                        Row["salary"] = (decimal.Parse(Row["salary"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["salary"].ToString())) : 0;
                        Row["not_exp"] = (decimal.Parse(Row["not_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["not_exp"].ToString())) : 0;
                        Row["tot_exp"] = (decimal.Parse(Row["tot_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["tot_exp"].ToString())) : 0;
                        Row["rest_exp"] = (decimal.Parse(Row["rest_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["rest_exp"].ToString())) : 0;
                        Row["ot_food"] = (decimal.Parse(Row["ot_food"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["ot_food"].ToString())) : 0; 
                        DataRow row = rq_ot.Rows.Find(Row["ot_dept"].ToString());
                        ot_expt = ot_expt + int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                        ot_hrst = ot_hrst + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                        if ((int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString())) != 0) ot_cnnt++;
                        rest_hrst = rest_hrst + decimal.Parse(Row["rest_hrs"].ToString());
                        if (decimal.Parse(Row["rest_exp"].ToString()) != 0) rest_cntt++;
                        rest_expt = rest_expt + decimal.Parse(Row["rest_exp"].ToString());

                        if (row != null)
                        {
                            row["ot_exp"] = int.Parse(row["ot_exp"].ToString()) + int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                            row["rest_exp"] = decimal.Parse(row["rest_exp"].ToString()) + decimal.Parse(Row["rest_exp"].ToString());
                            row["ot_food"] = decimal.Parse(row["ot_food"].ToString()) + decimal.Parse(Row["ot_food"].ToString());
                            row["ot_car"] = decimal.Parse(row["ot_car"].ToString()) + decimal.Parse(Row["ot_car"].ToString());
                            row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                            row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                            if (int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString()) != 0) row["ot_cnt"] = int.Parse(row["ot_cnt"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = rq_ot.NewRow();
                            aRow["dept5"] = Row["ot_dept"].ToString();
                            aRow["ot_exp"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                            aRow["rest_exp"] = decimal.Parse(Row["rest_exp"].ToString());
                            aRow["ot_food"] = decimal.Parse(Row["ot_food"].ToString());
                            aRow["ot_car"] = decimal.Parse(Row["ot_car"].ToString());
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                            aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                            aRow["ot_cnt"] = (int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString()) != 0) ? 1 : 0;
                            aRow["ot_expr"] = 0;
                            aRow["rest_expr"] = 0;
                            aRow["ot_foodr"] = 0;
                            aRow["ot_carr"] = 0;
                            aRow["ot_hrsr"] = 0;
                            aRow["rest_hrsr"] = 0;
                            aRow["ot_cntr"] = 0;
                            aRow["rest_cntr"] = 0;
                            rq_ot.Rows.Add(aRow);
                        }

                        object[] _value = new object[2];
                        _value[0] = Row["ot_dept"].ToString();
                        _value[1] = Row["nobr"].ToString();
                        DataRow row1 = rq_pno.Rows.Find(_value);
                        if (row1 != null)
                        {
                            if ((int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString())) != 0) row1["ot_cnt"] = int.Parse(row1["ot_cnt"].ToString()) + 1;
                            if (decimal.Parse(Row["rest_exp"].ToString()) != 0) row1["rest_cnt"] = decimal.Parse(row1["rest_cnt"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow1 = rq_pno.NewRow();
                            aRow1["dept5"] = Row["ot_dept"].ToString();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["ot_cnt"] = ((int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString())) != 0) ? 1 : 0;
                            aRow1["rest_cnt"] = (decimal.Parse(Row["rest_exp"].ToString()) != 0) ? 1 : 0;
                            rq_pno.Rows.Add(aRow1);
                        }
                    }
                }

                //foreach (DataRow Row in rq_ot.Rows)
                //{
                //    decimal otexp = decimal.Parse(Row["ot_exp"].ToString());
                //    decimal otcar = decimal.Parse(Row["ot_car"].ToString());
                //    decimal otfood = decimal.Parse(Row["ot_food"].ToString());
                //    decimal othrs = decimal.Parse(Row["ot_hrs"].ToString());
                //    decimal resthrs = decimal.Parse(Row["rest_hrs"].ToString());
                //    if (otexp + otcar + otfood != 0 && ot_expt != 0)
                //        Row["ot_expr"] = (otexp + otcar + otfood) / ot_expt;
                //    if (othrs + resthrs != 0 && ot_hrst != 0)
                //        Row["ot_hrsr"] = (othrs + resthrs) / ot_hrst;
                //    if (int.Parse(Row["ot_cnt"].ToString()) != 0 && ot_cnnt != 0)
                //        Row["ot_cntr"] = int.Parse(Row["ot_cnt"].ToString()) / ot_cnnt;
                //    if (decimal.Parse(Row["rest_hrs"].ToString()) != 0 && rest_hrst != 0)
                //        Row["rest_hrsr"] = decimal.Parse(Row["rest_hrs"].ToString()) / rest_hrst;
                //    if (int.Parse(Row["rest_cnt"].ToString()) != 0 && rest_cntt != 0)
                //        Row["rest_cntr"] = int.Parse(Row["rest_cnt"].ToString()) / rest_cntt;
                //    if (int.Parse(Row["rest_exp"].ToString()) != 0 && rest_expt != 0)
                //        Row["rest_expr"] = int.Parse(Row["rest_exp"].ToString()) / rest_expt;
                //}

                string sqlCmd3 = "select a.nobr,a.ot_hrs,a.rest_hrs,a.not_exp,a.tot_exp,a.rest_exp,a.salary,a.ot_food,a.ot_car,a.ot_dept";
                sqlCmd3 += string.Format(@" from ot a where a.yymm between '{0}' and '{1}'", otyymm_b, otyymm_e);
                DataTable rq_ot2 = SqlConn.GetDataTable(sqlCmd3);

                string sqlCmd4 = "select b.nobr from basetts b";
                sqlCmd4 += " left outer join dept c on b.dept=c.d_no";
                sqlCmd4 += string.Format(@" where '{0}' between b.adate and b.ddate", _date);
                sqlCmd4 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd4 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd4 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd4 += type_data;
                DataTable rq_basetts1 = SqlConn.GetDataTable(sqlCmd4);
                rq_basetts1.PrimaryKey = new DataColumn[] { rq_basetts1.Columns["nobr"] };

                DataTable rq_ota = new DataTable();
                rq_ota.Columns.Add("dept5", typeof(string));
                rq_ota.Columns.Add("ot_exp", typeof(int));
                rq_ota.Columns.Add("rest_exp", typeof(decimal));
                rq_ota.Columns.Add("ot_food", typeof(decimal));
                rq_ota.Columns.Add("ot_car", typeof(decimal));
                rq_ota.Columns.Add("ot_hrs", typeof(decimal));
                rq_ota.PrimaryKey = new DataColumn[] { rq_ota.Columns["dept5"] };
                foreach (DataRow Row in rq_ot2.Rows)
                {
                    Row["not_exp"] = (decimal.Parse(Row["not_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["not_exp"].ToString())) : 0;
                    Row["tot_exp"] = (decimal.Parse(Row["tot_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["tot_exp"].ToString())) : 0;
                    Row["rest_exp"] = (decimal.Parse(Row["rest_exp"].ToString()) != 0) ? JBModule.Data.CDecryp.Number(decimal.Parse(Row["rest_exp"].ToString())) : 0; 
                    DataRow row = rq_basetts1.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1 = rq_ota.Rows.Find(Row["ot_dept"].ToString());
                        if (row1 != null)
                        {
                            row1["ot_exp"] = int.Parse(row1["ot_exp"].ToString()) + int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                            row1["rest_exp"] = decimal.Parse(row1["rest_exp"].ToString()) + decimal.Parse(Row["rest_exp"].ToString());
                            row1["ot_food"] = decimal.Parse(row1["ot_food"].ToString()) + decimal.Parse(Row["ot_food"].ToString());
                            row1["ot_car"] = decimal.Parse(row1["ot_car"].ToString()) + decimal.Parse(Row["ot_car"].ToString());
                            row1["ot_hrs"] = decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_ota.NewRow();
                            aRow["dept5"] = Row["ot_dept"].ToString();
                            aRow["ot_exp"] = int.Parse(Row["not_exp"].ToString()) + int.Parse(Row["tot_exp"].ToString());
                            aRow["rest_exp"] = decimal.Parse(Row["rest_exp"].ToString());
                            aRow["ot_food"] = decimal.Parse(Row["ot_food"].ToString());
                            aRow["ot_car"] = decimal.Parse(Row["ot_car"].ToString());
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                            rq_ota.Rows.Add(aRow);
                        }
                    }
                }
                //JBHR.Reports.ReportClass.Export(rq_ot, this.Name);
                //JBHR.Reports.ReportClass.Export(rq_ota, "trq_ota");
                foreach (DataRow Row in rq_depts.Rows)
                {
                    string dddd = Row["d_no"].ToString();
                    if (Row["d_no"].ToString().Trim() == "SAP-11F0H0")
                        dddd = Row["d_no"].ToString();
                    DataRow row = rq_ot.Rows.Find(Row["d_no"].ToString());
                    DataRow row1 = rq_ota.Rows.Find(Row["d_no"].ToString());
                    DataRow aRow = ds.Tables["zz44"].NewRow();
                    aRow["d_no"] = Row["d_no_disp"].ToString();
                    aRow["d_name"]=Row["d_name"].ToString();
                    //aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["ot_exp"] = 0;
                    aRow["ot_hrs"] = 0;
                    aRow["ot_exp1"] = 0;
                    aRow["ot_hrs1"] = 0;
                    aRow["ot_exp2"] = 0;
                    aRow["ot_hrs2"] = 0;
                    aRow["ot_exp3"] = 0;
                    aRow["ot_hrs3"] = 0;
                    if (row != null)
                    {
                        aRow["ot_exp"] = row.IsNull("ot_exp") ? 0 : int.Parse(row["ot_exp"].ToString());
                        aRow["ot_hrs"] = row.IsNull("ot_hrs") ? 0 : decimal.Parse(row["ot_hrs"].ToString());
                    }
                    if (row1 != null)
                    {
                        aRow["ot_exp1"] = row1.IsNull("ot_exp") ? 0 : int.Parse(row1["ot_exp"].ToString());
                        aRow["ot_hrs1"] = row1.IsNull("ot_hrs") ? 0 : decimal.Parse(row1["ot_hrs"].ToString());
                    }                   
                    if (decimal.Parse(aRow["ot_exp"].ToString()) + decimal.Parse(aRow["ot_hrs"].ToString()) + decimal.Parse(aRow["ot_exp1"].ToString()) + decimal.Parse(aRow["ot_hrs1"].ToString()) > 0)
                    {
                        aRow["ot_exp2"] = int.Parse(aRow["ot_exp"].ToString()) - int.Parse(aRow["ot_exp1"].ToString());
                        aRow["ot_hrs2"] = decimal.Parse(aRow["ot_hrs"].ToString()) - decimal.Parse(aRow["ot_hrs1"].ToString());                        
                        if (int.Parse(aRow["ot_exp1"].ToString()) != 0 )
                            aRow["ot_exp3"] = decimal.Round((decimal.Parse(aRow["ot_exp2"].ToString()) / decimal.Parse(aRow["ot_exp1"].ToString())) * 100, 2); ;
                        if (decimal.Parse(aRow["ot_hrs1"].ToString()) != 0)
                            aRow["ot_hrs3"] = decimal.Round((decimal.Parse(aRow["ot_hrs2"].ToString()) / decimal.Parse(aRow["ot_hrs1"].ToString())) * 100, 2);
                        ds.Tables["zz44"].Rows.Add(aRow);
                    }
                }
                rq_basetts = null; rq_basetts1 = null; rq_depts = null; rq_ot = null;
                rq_ot1 = null; rq_ot2 = null; rq_ota = null; rq_pno = null;
                if (ds.Tables["zz44"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz44"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz44.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("OTYYmmb", otyymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("OTYYmme", otyymm_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz44", ds.Tables["zz44"]));
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
            ExporDt.Columns.Add("部門代號", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            //ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("基準年月加班時數", typeof(decimal));
            ExporDt.Columns.Add("基準年月加班費用", typeof(int));
            ExporDt.Columns.Add("比較年月加班時數", typeof(decimal));
            ExporDt.Columns.Add("比較年月加班費用", typeof(int));
            ExporDt.Columns.Add("差異年月加班時數", typeof(decimal));
            ExporDt.Columns.Add("差異年月加班費用", typeof(int));
            ExporDt.Columns.Add("差異時數百分比", typeof(decimal));
            ExporDt.Columns.Add("差異費用百分比", typeof(decimal));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();              
                aRow["部門代號"] = Row01["d_no"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                //aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["基準年月加班時數"] = decimal.Parse(Row01["ot_hrs"].ToString());
                aRow["基準年月加班費用"] = int.Parse(Row01["ot_exp"].ToString());
                aRow["比較年月加班時數"] = decimal.Parse(Row01["ot_hrs1"].ToString());
                aRow["比較年月加班費用"] = int.Parse(Row01["ot_exp1"].ToString());
                aRow["差異年月加班時數"] = decimal.Parse(Row01["ot_hrs2"].ToString());
                aRow["差異年月加班費用"] = int.Parse(Row01["ot_exp2"].ToString());
                aRow["差異時數百分比"] = decimal.Parse(Row01["ot_hrs3"].ToString());
                aRow["差異費用百分比"] = decimal.Parse(Row01["ot_exp3"].ToString());                
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
