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
    public partial class ZZ31A_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, yy_b, mm_b,date_b,date_e, sno_b, sno_e, emp_b, emp_e, reporttype, type_data,note;
        bool exportexcel;
        public ZZ31A_Report(string nobrb, string nobre, string deptb, string depte, string yyb, string mmb, string snob, string snoe, string empb, string empe, string _reporttype, string typedata,string _note, bool _exportexcel)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; yy_b = yyb; mm_b = mmb;
            sno_b = snob; sno_e = snoe; reporttype = _reporttype; emp_b = empb; emp_e = empe;
            exportexcel = _exportexcel; type_data = typedata; note = _note;
        }

        private void ZZ31A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                date_b = JBHR.Reports.ReportClass.GetSalBDate(yy_b, mm_b);
                date_e = JBHR.Reports.ReportClass.GetSalEDate(yy_b, mm_b);
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,a.birdt,b.retrate,";
                sqlCmd += "b.dept,c.d_name,c.d_ename,b.depts,d.d_name as ds_name";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);              
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,fa_idno,in_date,out_date,l_amt,h_amt,r_amt";
                sqlCmd1 += "  from inslab where nobr+fa_idno+convert(char,in_date,112) in";
                sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and fa_idno='' and in_date<='{0}'", date_e);
                sqlCmd1 += " group by nobr,fa_idno)";
                sqlCmd1 += string.Format(@" and ('{0}' between in_date and out_date", date_e);
                sqlCmd1 += string.Format(@" or '{0}' between in_date and out_date)", date_b);
                sqlCmd1 += string.Format(@" and s_no between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd1 += " and fa_idno=''  order by nobr";
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd1);
                rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };
                //rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"], rq_inslab.Columns["fa_idno"] };

                DataTable rq_usys5 = SqlConn.GetDataTable("select hsalcode from u_sys5");
                DataTable rq_usys4 = SqlConn.GetDataTable("select lsalcode,retsalcode,nretirerate from u_sys4");
                string hsalcode = ""; string lsalcode = ""; string retsalcode = "";
                if (rq_usys5.Rows.Count > 0)
                    hsalcode = rq_usys5.Rows[0]["hsalcode"].ToString();

                if (rq_usys4.Rows.Count > 0)
                {
                    lsalcode = rq_usys4.Rows[0]["lsalcode"].ToString();
                    retsalcode = rq_usys4.Rows[0]["retsalcode"].ToString();
                }


                string sqlCmd2 = "select b.nobr,b.s_no,b.fa_idno,b.exp,b.comp, b.insur_type ";
                sqlCmd2 += "from explab b";
                sqlCmd2 += string.Format(@" where b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and b.yymm = '{0}' ", yy_b+mm_b);                
                if (reporttype == "0" || reporttype == "1") sqlCmd2 += " and b.insur_type='1'";
                else if (reporttype == "2" || reporttype == "3") sqlCmd2 += " and b.insur_type='2'";
                else if (reporttype == "4" || reporttype == "5") sqlCmd2 += " and b.insur_type='4'";
                sqlCmd2 += " order by b.nobr,b.fa_idno";
                DataTable rq_explab = SqlConn.GetDataTable(sqlCmd2);

                DataTable rq_explab1 = new DataTable();
                rq_explab1.Columns.Add("nobr", typeof(string));
                rq_explab1.Columns.Add("comp", typeof(int));
                rq_explab1.Columns.Add("fa_cnt", typeof(int));
                rq_explab1.PrimaryKey = new DataColumn[] { rq_explab1.Columns["nobr"] };
                foreach (DataRow Row in rq_explab.Rows)
                {
                    DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        DataRow row = rq_explab1.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["comp"] = int.Parse(row["comp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                            row["fa_cnt"] = int.Parse(row["fa_cnt"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = rq_explab1.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                            aRow["fa_cnt"] = 0;
                            rq_explab1.Rows.Add(aRow);
                        }
                    }
                }

                string sqlCmd6 = "select a.nobr,b.amt from wage a, waged b";
                sqlCmd6 += " where a.nobr=b.nobr and  a.yymm=b.yymm  and a.seq=b.seq";
                sqlCmd6 += string.Format(@" and a.yymm='{0}' and a.seq='2'", yy_b + mm_b);
                sqlCmd6 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (reporttype == "0" || reporttype == "1") sqlCmd6 += string.Format(@" and b.sal_code='{0}'", lsalcode);
                else if (reporttype == "2" || reporttype == "3") sqlCmd6 += string.Format(@" and b.sal_code='{0}'", hsalcode);
                else if (reporttype == "4" || reporttype == "5") sqlCmd6 += string.Format(@" and b.sal_code='{0}'", retsalcode);
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd6);
                rq_waged.PrimaryKey = new DataColumn[] { rq_waged.Columns["nobr"] };

                //當月加退人員名單
                string sqlCmd5 = "select nobr,fa_idno,in_date,out_date,l_amt,h_amt,r_amt from inslab ";
                sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@"  and in_date between '{0}' and '{1}'", date_b, date_e);
                sqlCmd5 += string.Format(@" and s_no between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd5 += " and code='3' and not exists(select * from inslab a where inslab.nobr=a.nobr ";
                sqlCmd5 += " and dateadd(d,-1,inslab.in_date) between  a.in_date and a.out_date )";
                sqlCmd5 += " and fa_idno=''";
                DataTable rq_inslaba = SqlConn.GetDataTable(sqlCmd5);
                foreach (DataRow Row in rq_inslaba.Rows)
                {
                    DataRow row = rq_inslab.Rows.Find(Row["nobr"].ToString());
                    if (row == null) rq_inslab.ImportRow(Row);                    
                }

                decimal _nretirerate = (rq_usys4.Rows.Count > 0) ? decimal.Parse(rq_usys4.Rows[0]["nretirerate"].ToString()) * 100 : 0;
                ds.Tables["zz31a"].PrimaryKey = new DataColumn[] { ds.Tables["zz31a"].Columns["nobr"] };
                DataTable rq_zz31a = new DataTable();
                rq_zz31a = ds.Tables["zz31a"].Clone();
                rq_zz31a.TableName = "rq_zz31a";

                if (Convert.ToInt32(reporttype) < 4)
                {
                    foreach (DataRow Row in rq_waged.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        DataRow row1 = rq_inslab.Rows.Find(Row["nobr"].ToString());
                        DataRow row3 = rq_explab1.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            DataRow row2 = rq_zz31a.Rows.Find(Row["nobr"].ToString());
                            if (row2 != null)
                            {
                                row2["exp"] = int.Parse(row2["exp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                //if (row3 != null) row2["comp"] = int.Parse(row2["comp"].ToString()) + int.Parse(row3["comp"].ToString());
                                row2["total"] = int.Parse(row2["exp"].ToString()) + int.Parse(row2["comp"].ToString());
                                //row2["fa_cnt"] = int.Parse(row2["fa_cnt"].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow = rq_zz31a.NewRow();
                                aRow["dept"] = row["dept"].ToString();
                                aRow["d_name"] = row["d_name"].ToString();
                                aRow["d_ename"] = row["d_ename"].ToString();
                                aRow["depts"] = (!row.IsNull("depts")) ? row["depts"].ToString() : "";
                                aRow["ds_name"] = (!row.IsNull("ds_name")) ? row["ds_name"].ToString() : "";
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = row["name_c"].ToString();
                                aRow["name_e"] = row["name_e"].ToString();
                                aRow["idno"] = (!row.IsNull("idno")) ? row["idno"].ToString() : "";
                                if (row1 != null)
                                {
                                    aRow["in_date"] = DateTime.Parse(row1["in_date"].ToString());
                                    aRow["out_date"] = DateTime.Parse(row1["out_date"].ToString());
                                    aRow["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["l_amt"].ToString()));
                                    aRow["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["h_amt"].ToString()));
                                    aRow["r_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["r_amt"].ToString()));
                                }
                                else
                                {
                                    aRow["l_amt"] = 0;
                                    aRow["h_amt"] = 0;
                                    aRow["r_amt"] = 0;
                                }

                                aRow["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                aRow["comp"] = (row3 != null) ? int.Parse(row3["comp"].ToString()) : 0;
                                aRow["total"] = int.Parse(aRow["exp"].ToString()) + int.Parse(aRow["comp"].ToString());
                                aRow["comppretrate"] = _nretirerate;
                                aRow["fa_cnt"] = (row3 != null) ? int.Parse(row3["fa_cnt"].ToString()) : 0;
                                aRow["exppretrate"] = decimal.Parse(row["retrate"].ToString()) ;
                                rq_zz31a.Rows.Add(aRow);
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataRow Row in rq_explab.Rows)
                    {

                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        DataRow row1 = rq_inslab.Rows.Find(Row["nobr"].ToString());
                        DataRow row3 = rq_waged.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            DataRow row2 = rq_zz31a.Rows.Find(Row["nobr"].ToString());
                            if (row2 != null)
                            {
                                //row2["exp"] = int.Parse(row2["exp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                row2["comp"] = int.Parse(row2["comp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                                row2["total"] = int.Parse(row2["exp"].ToString()) + int.Parse(row2["comp"].ToString());
                                row2["fa_cnt"] = int.Parse(row2["fa_cnt"].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow = rq_zz31a.NewRow();
                                aRow["dept"] = row["dept"].ToString();
                                aRow["d_name"] = row["d_name"].ToString();
                                aRow["d_ename"] = row["d_ename"].ToString();
                                aRow["depts"] = (!row.IsNull("depts")) ? row["depts"].ToString() : "";
                                aRow["ds_name"] = (!row.IsNull("ds_name")) ? row["ds_name"].ToString() : "";
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = row["name_c"].ToString();
                                aRow["name_e"] = row["name_e"].ToString();
                                aRow["idno"] = (!row.IsNull("idno")) ? row["idno"].ToString() : "";
                                if (row1 != null)
                                {
                                    aRow["in_date"] = DateTime.Parse(row1["in_date"].ToString());
                                    aRow["out_date"] = DateTime.Parse(row1["out_date"].ToString());
                                    aRow["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["l_amt"].ToString()));
                                    aRow["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["h_amt"].ToString()));
                                    aRow["r_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["r_amt"].ToString()));
                                }
                                else
                                {
                                    aRow["l_amt"] = 0;
                                    aRow["h_amt"] = 0;
                                    aRow["r_amt"] = 0;
                                }
                                aRow["exp"] = (row3 != null) ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(row3["amt"].ToString())) : 0;
                                aRow["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                                aRow["total"] = int.Parse(aRow["exp"].ToString()) + int.Parse(aRow["comp"].ToString());
                                aRow["comppretrate"] = _nretirerate;
                                aRow["fa_cnt"] = 0;
                                aRow["exppretrate"] = decimal.Parse(row["retrate"].ToString());
                                rq_zz31a.Rows.Add(aRow);
                            }
                        }
                    }
                }

                if (rq_zz31a.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //累計勞退
                DataTable rq_totalexplab = new DataTable();
                rq_totalexplab.Columns.Add("nobr", typeof(string));
                rq_totalexplab.Columns.Add("comp", typeof(int));
                rq_totalexplab.Columns.Add("exp", typeof(int));
                rq_totalexplab.PrimaryKey = new DataColumn[] { rq_totalexplab.Columns["nobr"] };
                if (reporttype == "4")
                {                    
                    string sqlCmd3 = "select a.nobr,a.comp,a.exp from explab a,basetts b";
                    sqlCmd3 += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                    sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd3 += " and a.insur_type='4' and b.ttscode in ('1','4','6') ";
                    DataTable rq_explaba = SqlConn.GetDataTable(sqlCmd3);
                   
                    foreach (DataRow Row in rq_explaba.Rows)
                    {
                        DataRow row = rq_totalexplab.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["exp"] = int.Parse(row["exp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["exp"].ToString()));
                            row["comp"] = int.Parse(row["comp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                        }
                        else
                        {
                            DataRow aRow = rq_totalexplab.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["exp"].ToString()));
                            aRow["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                            rq_totalexplab.Rows.Add(aRow);
                        }
                    }
                    rq_explaba = null;

                }

                if (reporttype == "1" || reporttype == "3" || reporttype == "5")
                {
                    DataRow[] SRow1 = rq_zz31a.Select("", "depts asc");
                    ds.Tables["zz31a1"].PrimaryKey = new DataColumn[] { ds.Tables["zz31a1"].Columns["depts"] };
                    foreach (DataRow Row in SRow1)
                    {
                        DataRow row = ds.Tables["zz31a1"].Rows.Find(Row["depts"].ToString());
                        if (row != null)
                        {
                            row["exp"] = int.Parse(row["exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row["comp"] = int.Parse(row["comp"].ToString()) + int.Parse(Row["comp"].ToString());
                            row["total"] = int.Parse(row["total"].ToString()) + int.Parse(Row["exp"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz31a1"].NewRow();
                            aRow["depts"] = Row["depts"].ToString();
                            aRow["ds_name"] = Row["ds_name"].ToString();
                            aRow["exp"] = int.Parse(Row["exp"].ToString());
                            aRow["comp"] = int.Parse(Row["comp"].ToString());
                            aRow["total"] = int.Parse(Row["exp"].ToString()) + int.Parse(Row["comp"].ToString());
                            ds.Tables["zz31a1"].Rows.Add(aRow);
                        }
                    }
                }
                else
                {
                    DataRow[] SRow = rq_zz31a.Select("", "dept,depts,nobr asc");
                    foreach (DataRow Row in SRow)
                    {
                        if (reporttype == "4")
                        {
                            DataRow row = rq_totalexplab.Rows.Find(Row["nobr"].ToString());
                            if (row != null)
                            {
                                Row["totalexp"] = int.Parse(Row["exp"].ToString());
                                Row["totalcomp"] = int.Parse(Row["comp"].ToString());
                            }
                        }
                        ds.Tables["zz31a"].ImportRow(Row);
                    }
                }
                
                rq_base = null; rq_explab = null; rq_inslab = null; rq_usys4 = null; rq_zz31a = null;
                rq_totalexplab = null; rq_explab1 = null; rq_waged = null;

                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz31a"]);
                    else if (reporttype == "2")
                        Export1(ds.Tables["zz31a"]);
                    else if (reporttype == "4")
                        Export2(ds.Tables["zz31a"]);
                    else 
                        Export3(ds.Tables["zz31a1"]);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "", "*.rdlc");
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz31a.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz31a1.rdlc";
                    else if (reporttype == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz31a2.rdlc";
                    else 
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz31a3.rdlc";
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", yy_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", mm_b) });
                    if (reporttype == "1" || reporttype == "3" || reporttype == "5")
                    {
                        string _reportname = "";
                        if (reporttype == "1")
                            _reportname = "勞保";
                        else if (reporttype == "3")
                            _reportname = "健保";
                        else
                            _reportname = "勞退";
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("ReportName", _reportname) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz31a1", ds.Tables["zz31a1"]));
                    }
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz31a", ds.Tables["zz31a"]));
                    }
                   
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

        //勞保
        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("Dept", typeof(string));
            ExporDt.Columns.Add("Empl.ID", typeof(string));
            ExporDt.Columns.Add("Oracle#", typeof(string));
            ExporDt.Columns.Add("Oracl Name", typeof(string));
            ExporDt.Columns.Add("Name_C", typeof(string));
            ExporDt.Columns.Add("Name_E", typeof(string));
            ExporDt.Columns.Add("ID", typeof(string));
            ExporDt.Columns.Add("Insurance Ｇrade", typeof(int));
            ExporDt.Columns.Add("Labor Insurance", typeof(int));
            ExporDt.Columns.Add("Employer", typeof(int));
            ExporDt.Columns.Add("Employees", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Dept"] = Row01["d_ename"].ToString();
                aRow["Empl.ID"] = Row01["nobr"].ToString();
                aRow["Oracle#"] = Row01["depts"].ToString();
                aRow["Oracl Name"] = Row01["ds_name"].ToString();
                aRow["Name_C"] = Row01["name_c"].ToString();
                aRow["ID"] = Row01["idno"].ToString();
                aRow["Name_E"] = Row01["name_e"].ToString();
                aRow["Insurance Ｇrade"] = int.Parse(Row01["l_amt"].ToString());
                aRow["Labor Insurance"] = int.Parse(Row01["total"].ToString());
                aRow["Employer"] = int.Parse(Row01["comp"].ToString());
                aRow["Employees"] = int.Parse(Row01["exp"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        //健保
        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("Dept", typeof(string));
            ExporDt.Columns.Add("Empl.ID", typeof(string));
            ExporDt.Columns.Add("Oracle#", typeof(string));
            ExporDt.Columns.Add("Oracl Name", typeof(string));
            ExporDt.Columns.Add("Name_C", typeof(string));
            ExporDt.Columns.Add("Name_E", typeof(string));
            ExporDt.Columns.Add("ID", typeof(string));
            ExporDt.Columns.Add("Insurance Ｇrade", typeof(int));
            ExporDt.Columns.Add("Family Member", typeof(int));
            ExporDt.Columns.Add("Total Insurance Fee", typeof(int));
            ExporDt.Columns.Add("Employer", typeof(int));
            ExporDt.Columns.Add("Employees", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Dept"] = Row01["d_ename"].ToString();
                aRow["Empl.ID"] = Row01["nobr"].ToString();
                aRow["Oracle#"] = Row01["depts"].ToString();
                aRow["Oracl Name"] = Row01["ds_name"].ToString();
                aRow["Name_C"] = Row01["name_c"].ToString();
                aRow["ID"] = Row01["idno"].ToString();
                aRow["Name_E"] = Row01["name_e"].ToString();
                aRow["Insurance Ｇrade"] = int.Parse(Row01["h_amt"].ToString());
                aRow["Family Member"] = int.Parse(Row01["fa_cnt"].ToString());
                aRow["Total Insurance Fee"] = int.Parse(Row01["total"].ToString());
                aRow["Employer"] = int.Parse(Row01["comp"].ToString());
                aRow["Employees"] = int.Parse(Row01["exp"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        //勞退
        void Export2(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("Dept", typeof(string));
            ExporDt.Columns.Add("Empl.ID", typeof(string));
            ExporDt.Columns.Add("Oracle#", typeof(string));
            ExporDt.Columns.Add("Oracl Dept", typeof(string));
            ExporDt.Columns.Add("Name_C", typeof(string));
            ExporDt.Columns.Add("Name_E", typeof(string));
            ExporDt.Columns.Add("Personal ID", typeof(string));
            ExporDt.Columns.Add("Pension Ｇrade", typeof(int));
            ExporDt.Columns.Add("Compnay(%)", typeof(decimal));
            ExporDt.Columns.Add("Personal(%)", typeof(decimal));
            ExporDt.Columns.Add("Employer", typeof(int));
            ExporDt.Columns.Add("Employee", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Dept"] = Row01["d_ename"].ToString();
                aRow["Empl.ID"] = Row01["nobr"].ToString();
                aRow["Oracle#"] = Row01["depts"].ToString();
                aRow["Oracl Dept"] = Row01["ds_name"].ToString();
                aRow["Name_C"] = Row01["name_c"].ToString();
                aRow["Name_E"] = Row01["name_e"].ToString();
                aRow["Personal ID"] = Row01["idno"].ToString();
                aRow["Pension Ｇrade"] = int.Parse(Row01["r_amt"].ToString());
                aRow["Compnay(%)"] =decimal.Parse(Row01["comppretrate"].ToString());
                aRow["Personal(%)"] = (Row01.IsNull("exppretrate")) ? 0 : decimal.Parse(Row01["exppretrate"].ToString());
                aRow["Employer"] = int.Parse(Row01["comp"].ToString());
                aRow["Employee"] = int.Parse(Row01["exp"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        void Export3(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本部門名稱", typeof(string));
            ExporDt.Columns.Add("公司負擔金額", typeof(int));
            ExporDt.Columns.Add("個人負擔金額", typeof(int));
            ExporDt.Columns.Add("合計", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["成本部門名稱"] = Row01["ds_name"].ToString();
                aRow["公司負擔金額"] = int.Parse(Row01["comp"].ToString());
                aRow["個人負擔金額"] = int.Parse(Row01["exp"].ToString());
                aRow["合計"] = int.Parse(Row01["total"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
