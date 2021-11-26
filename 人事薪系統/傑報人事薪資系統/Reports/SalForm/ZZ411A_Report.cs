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
    public partial class ZZ411A_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, date_b,date_e, dept_b, dept_e, sno_b, sno_e, emp_b, emp_e,yy_b, type_datat, CompId; //yymm_b, yymm_e, seq_b, seq_e,
        bool exportexcel;
        public ZZ411A_Report(string nobrb, string nobre, string dateb,string datee, string deptb, string depte, string snob, string snoe, string empb, string empe, string yyb, string typedatat, bool _exportexcel, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; sno_b = snob; sno_e = snoe;
            yy_b = yyb; type_datat = typedatat; exportexcel = _exportexcel; emp_b = empb; emp_e = empe; CompId = _CompId;
        }

        private void ZZ411A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_sys5 = SqlConn.GetDataTable("select supplehinslabsalcode,suppleinslabrate,bonusyearratemax,supplehinslabsalcode from u_sys5 where Comp='" + CompId + "'");
                //補充保費費率
                decimal suppleinslabrate = 0;
                //補充保費超過投保幾倍
                decimal bonusyearratemax = 0;
                //補充保費代碼
                string supplehinslabsalcode = string.Empty;
                if (rq_sys5.Rows.Count > 0)
                {
                    suppleinslabrate = decimal.Parse(rq_sys5.Rows[0]["suppleinslabrate"].ToString());
                    bonusyearratemax = decimal.Parse(rq_sys5.Rows[0]["bonusyearratemax"].ToString());
                    supplehinslabsalcode = rq_sys5.Rows[0]["supplehinslabsalcode"].ToString();
                }
                string sqlCmd = "select b.nobr,a.name_c,name_e,a.idno,c.d_no_disp as dept,c.d_name,d_ename";
                sqlCmd += ",matno,count_ma";
                sqlCmd += " from base a,basetts b ";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += type_datat;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //發放薪資二代補充保費
                string sqlCmd0 = "select b.nobr,b.yymm,b.seq,b.sal_code,b.amt,a.comp,c.compname";
                sqlCmd0 += " from waged b,wage a";
                sqlCmd0 += " left outer join comp c on a.comp=c.comp";
                sqlCmd0 += string.Format(@" where b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd0 += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //sqlCmd0 += string.Format(@" and b.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                //sqlCmd0 += string.Format(@" and b.seq between '{0}' and '{1}'", seq_b, seq_e);
                //sqlCmd0 += string.Format(@" and b.sal_code='{0}'", supplehinslabsalcode);
                sqlCmd0 += " and a.yymm=b.yymm and a.nobr=b.nobr and a.seq=b.seq ";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd0);
                DataTable rq_waged1 = new DataTable();
                rq_waged1.Columns.Add("nobr", typeof(string));
                rq_waged1.Columns.Add("yymm", typeof(string));
                rq_waged1.Columns.Add("seq", typeof(string));
                rq_waged1.Columns.Add("comp", typeof(string));
                rq_waged1.Columns.Add("compname", typeof(string));
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_waged1.Columns["nobr"];
                _key[1] = rq_waged1.Columns["yymm"];
                _key[2] = rq_waged1.Columns["seq"];
                rq_waged1.PrimaryKey = _key;

                DataTable rq_expamt = new DataTable();
                rq_expamt.Columns.Add("nobr", typeof(string));
                rq_expamt.Columns.Add("yymm", typeof(string));
                rq_expamt.Columns.Add("seq", typeof(string));
                rq_expamt.Columns.Add("amt", typeof(string));
                DataColumn[] _key1 = new DataColumn[3];
                _key1[0] = rq_expamt.Columns["nobr"];
                _key1[1] = rq_expamt.Columns["yymm"];
                _key1[2] = rq_expamt.Columns["seq"];
                rq_expamt.PrimaryKey = _key1;
                //DataRow[] SRow0 = rq_waged.Select("sal_code='" + supplehinslabsalcode + "'");
                foreach (DataRow Row in rq_waged.Rows)
                {
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row1 = rq_waged1.Rows.Find(_value);
                    if (row1==null)
                    {
                        DataRow aRow = rq_waged1.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["seq"] = Row["seq"].ToString();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        rq_waged1.Rows.Add(aRow);
                    }
                    DataRow row2 = rq_expamt.Rows.Find(_value);
                    Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    if (Row["sal_code"].ToString() == supplehinslabsalcode)
                    {
                        if (row2 != null)
                            row2["amt"] = int.Parse(row2["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = rq_expamt.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["yymm"] = Row["yymm"].ToString();
                            aRow["seq"] = Row["seq"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            rq_expamt.Rows.Add(aRow);
                        }
                    }
                    
                }
                rq_waged = null;

                string sqlCmd1 = "select a.nobr,a.yymm,a.seq,a.sal_code,a.pay_date,a.adate,a.ddate";
                sqlCmd1 += ",a.format,a.pay_amt,a.sup_amt,a.ins_hamt,a.total_amt,a.s_no,b.insname";
                sqlCmd1 += " from expsup a";
                sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no ";                
                sqlCmd1+=string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (sno_b==string.Empty)
                    sqlCmd1 += string.Format(@" and (a.s_no='' or  b.s_no_disp between '{0}' and '{1}')", sno_b, sno_e);
                else
                    sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd1 += string.Format(@" and a.pay_date between '{0}' and '{1}'", date_b, date_e);
                //sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                //sqlCmd1 += string.Format(@" and a.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += " order by a.nobr,a.pay_date";
                DataTable rq_expsup = SqlConn.GetDataTable(sqlCmd1);
                rq_expsup.Columns.Add("dept", typeof(string));
                rq_expsup.Columns.Add("d_name", typeof(string));
                rq_expsup.Columns.Add("d_ename", typeof(string));
                rq_expsup.Columns.Add("name_c", typeof(string));
                rq_expsup.Columns.Add("name_e", typeof(string));
                rq_expsup.Columns.Add("idno", typeof(string));                

                string strnobr = string.Empty; int tolamt = 0;
                foreach (DataRow Row in rq_expsup.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (bool.Parse(row["count_ma"].ToString()))
                            row["idno"] = row["matno"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["name_c"] = row["name_c"].ToString();                        
                        Row["idno"] = row["idno"].ToString();
                        Row["pay_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["pay_amt"].ToString()));
                        Row["sup_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["sup_amt"].ToString()));
                        Row["ins_hamt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["ins_hamt"].ToString()));
                        //Row["total_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["total_amt"].ToString()));
                        Row["total_amt"] = 0;
                        if (int.Parse(Row["ins_hamt"].ToString()) > 0)
                        {
                            if (Row["nobr"].ToString() == strnobr)
                            {
                                tolamt += int.Parse(Row["pay_amt"].ToString());
                                Row["total_amt"] = tolamt;
                            }
                            else
                            {
                                Row["total_amt"] = int.Parse(Row["pay_amt"].ToString());
                                tolamt = int.Parse(Row["pay_amt"].ToString());
                            }
                            strnobr = Row["nobr"].ToString();
                        }        
                    }
                    else
                        Row.Delete();
                }
                rq_expsup.AcceptChanges();

                if (rq_expsup.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataRow[] SRow = rq_expsup.Select("", "s_no,idno asc");
                foreach (DataRow Row in SRow)
                {                    
                    DataRow aRow = ds.Tables["zz411a"].NewRow();
                    aRow["s_no"] = Row["s_no"].ToString();
                    aRow["insname"] = Row["insname"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();                                  
                    aRow["pay_date"] = DateTime.Parse(Row["pay_date"].ToString());
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["ddate"] = DateTime.Parse(Row["ddate"].ToString());
                    aRow["format"] = Row["format"].ToString();
                    aRow["pay_amt"] = int.Parse(Row["pay_amt"].ToString());
                    aRow["sup_amt"] = int.Parse(Row["sup_amt"].ToString());
                    aRow["ins_hamt"] = int.Parse(Row["ins_hamt"].ToString());
                    aRow["total_amt"] = int.Parse(Row["total_amt"].ToString());
                    aRow["bonuamt"] = int.Parse(Row["ins_hamt"].ToString()) * bonusyearratemax;
                    aRow["baseamt"] = 0;
                    if (int.Parse(Row["total_amt"].ToString()) - int.Parse(aRow["bonuamt"].ToString()) > 0)
                        aRow["exceeamt"] = int.Parse(Row["total_amt"].ToString()) - int.Parse(aRow["bonuamt"].ToString());
                    else
                        aRow["exceeamt"] = 0;
                    if (int.Parse(aRow["pay_amt"].ToString()) > int.Parse(aRow["exceeamt"].ToString()))
                        aRow["baseamt"] = int.Parse(aRow["exceeamt"].ToString());
                    else
                        aRow["baseamt"] = int.Parse(aRow["pay_amt"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row2 = rq_waged1.Rows.Find(_value);
                    DataRow row3 = rq_expamt.Rows.Find(_value);
                    if (row2 != null)
                    {
                        //aRow["salamt"] = JBModule.Data.CDecryp.Number(decimal.Parse(row2["amt"].ToString()));
                        aRow["comp"] = row2["comp"].ToString();
                        aRow["compname"] = row2["compname"].ToString();
                    }
                    if (row3 != null)
                    {
                        aRow["salamt"] = int.Parse(row3["amt"].ToString());
                    }
                        
                    ds.Tables["zz411a"].Rows.Add(aRow);
                }
                rq_base = null; rq_expamt = null; rq_expsup = null; rq_sys5 = null; rq_waged1 = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz411a"], bonusyearratemax, suppleinslabrate * 100);
                        
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
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz411a.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", yy_b) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMM_B", yymm_b) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMM_E", yymm_e) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQ_B", seq_b) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQ_E", seq_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("suppleinslabrate", Convert.ToString(decimal.Round(suppleinslabrate * 100, 2))) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("bonusyearratemax", Convert.ToString(bonusyearratemax)) }); 
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz411a", ds.Tables["zz411a"]));                   
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

        void Export(DataTable DT,decimal bonusyearratemax,decimal suppleinslabrate)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("薪資扣繳公司別", typeof(string));
            ExporDt.Columns.Add("薪資扣繳公司名稱", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("計薪年月", typeof(string));
            ExporDt.Columns.Add("期", typeof(string));            
            //ExporDt.Columns.Add("部門代號", typeof(string));
            //ExporDt.Columns.Add("部門名稱", typeof(string));
            //ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("給付日期", typeof(DateTime));
            ExporDt.Columns.Add("所得類別", typeof(string));
            ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add(Convert.ToString(bonusyearratemax)+"倍投保金額", typeof(int));
            ExporDt.Columns.Add("單次獎金", typeof(int));
            ExporDt.Columns.Add("累計獎金", typeof(int));  
            ExporDt.Columns.Add("累計超過保費"+Convert.ToString(bonusyearratemax)+"倍獎金", typeof(int));
            ExporDt.Columns.Add("補充保費費基", typeof(int));
            ExporDt.Columns.Add("補充保費", typeof(int));
            ExporDt.Columns.Add("薪資扣繳", typeof(int));
            ExporDt.Columns.Add("投保單位", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["薪資扣繳公司別"] = Row01["comp"].ToString();
                aRow["薪資扣繳公司名稱"] = Row01["compname"].ToString();
                aRow["身分證號"] = Row01["idno"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["計薪年月"] = Row01["yymm"].ToString();
                aRow["期"] = Row01["seq"].ToString();
                aRow["給付日期"] = DateTime.Parse(Row01["pay_date"].ToString());
                aRow["所得類別"] = Row01["sal_code"].ToString();
                aRow["投保金額"] = int.Parse(Row01["ins_hamt"].ToString());
                aRow[Convert.ToString(bonusyearratemax) + "倍投保金額"] = int.Parse(Row01["bonuamt"].ToString());
                aRow["單次獎金"] = int.Parse(Row01["pay_amt"].ToString());
                aRow["累計獎金"] = int.Parse(Row01["total_amt"].ToString());
                aRow["累計超過保費" + Convert.ToString(bonusyearratemax) + "倍獎金"] = int.Parse(Row01["exceeamt"].ToString());
                aRow["補充保費費基"] = int.Parse(Row01["baseamt"].ToString());
                aRow["補充保費"] = int.Parse(Row01["sup_amt"].ToString());
                aRow["薪資扣繳"] = (Row01.IsNull("salamt")) ? 0 : int.Parse(Row01["salamt"].ToString());
                aRow["投保單位"] = Row01["insname"].ToString();
                ExporDt.Rows.Add(aRow);
            }

            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
