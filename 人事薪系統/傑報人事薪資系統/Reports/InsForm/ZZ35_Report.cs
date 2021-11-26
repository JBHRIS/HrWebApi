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
    public partial class ZZ35_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, dept_type, reporttype, typedata, year_b, comp_name, saladr;
        bool exportexcel;
        string char1 = "元拾佰仟萬拾佰仟億拾佰仟兆拾佰仟";
        string[] _no = new string[] { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
        public ZZ35_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string yearb, string depttype, string _reporttype, string _typedata, string _saladr, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            dept_type = depttype; reporttype = _reporttype; typedata = _typedata;
            exportexcel = _exportexcel; year_b = yearb; comp_b = compb; comp_e = compe;
            comp_name = compname; saladr = _saladr;
        }

        private void ZZ35_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.idno,a.birdt,c.d_no_disp as dept,c.d_name,b.comp,d.compname,d.chairman";
                sqlCmd += " from base a,basetts b left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join comp d on b.comp=d.comp";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", DateTime.Now.ToShortDateString());
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += dept_type;
                sqlCmd += typedata;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.fa_idno,b.fa_birdt,b.fa_name,a.rel_lab,a.rel_hel,a.rel_grp,a.rel_sup from yrinsur a";
                sqlCmd1 += " left outer join family b on a.fa_idno=b.fa_idno and a.nobr=b.nobr";
                sqlCmd1 += string.Format(@" where year='{0}'", year_b);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += saladr;
                DataTable rq_yrinsur=SqlConn.GetDataTable(sqlCmd1);
                rq_yrinsur.Columns.Add("idno", typeof(string));
                rq_yrinsur.Columns.Add("name_c", typeof(string));
                rq_yrinsur.Columns.Add("dept", typeof(string));
                rq_yrinsur.Columns.Add("d_name", typeof(string));
                rq_yrinsur.Columns.Add("compname", typeof(string));
                rq_yrinsur.Columns.Add("chairman", typeof(string));
                rq_yrinsur.Columns.Add("birdt", typeof(DateTime));
                foreach (DataRow Row in rq_yrinsur.Rows)
                {
                    Row["rel_lab"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_lab"].ToString()));
                    Row["rel_hel"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_hel"].ToString()));
                    Row["rel_grp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_grp"].ToString()));
                    Row["rel_sup"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_sup"].ToString()));
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["idno"] = row["idno"].ToString();
                        Row["name_c"] = row["name_c"].ToString();                        
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["compname"] = row["compname"].ToString();
                        Row["chairman"] = row["chairman"].ToString();
                        Row["birdt"] = DateTime.Parse(row["birdt"].ToString());
                    }
                    else
                        Row.Delete();
                }
                rq_yrinsur.AcceptChanges();
                if (rq_yrinsur.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataRow[] SRow = rq_yrinsur.Select("", "dept,nobr,fa_idno asc");
                if (reporttype == "0")
                {
                    foreach (DataRow Row in SRow)
                    {
                        DataRow aRow = ds.Tables["zz35"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["fa_idno"] = Row["fa_idno"].ToString().Trim();
                        aRow["fa_name"] = Row["fa_name"].ToString().Trim();
                        aRow["rel_lab"] = int.Parse(Row["rel_lab"].ToString());
                        aRow["rel_hel"] = int.Parse(Row["rel_hel"].ToString());
                        aRow["rel_grp"] = int.Parse(Row["rel_grp"].ToString());
                        aRow["rel_sup"] = int.Parse(Row["rel_sup"].ToString());
                        ds.Tables["zz35"].Rows.Add(aRow);
                    }
                }
                else if (reporttype == "1")
                {
                    ds.Tables["zz351"].PrimaryKey = new DataColumn[] { ds.Tables["zz351"].Columns["nobr"] };
                    foreach (DataRow Row in SRow)
                    {
                        DataRow row = ds.Tables["zz351"].Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            for (int i = 2; i < 9; i++)
                            {
                                if (row.IsNull("idno" + i))
                                {
                                    row["rel_lab" + i] = int.Parse(Row["rel_lab"].ToString());
                                    row["rel_hel" + i] = int.Parse(Row["rel_hel"].ToString());
                                    row["rel_grp" + i] = int.Parse(Row["rel_grp"].ToString());
                                    row["rel_sup" + i] = int.Parse(Row["rel_sup"].ToString());
                                    row["grp" + i] = int.Parse(row["rel_lab" + i].ToString()) + int.Parse(row["rel_hel" + i].ToString()) + int.Parse(row["rel_grp" + i].ToString()) + int.Parse(row["rel_sup" + i].ToString());
                                    row["rel_lab"] = int.Parse(row["rel_lab"].ToString()) + int.Parse(Row["rel_lab"].ToString());
                                    row["rel_hel"] = int.Parse(row["rel_hel"].ToString()) + int.Parse(Row["rel_hel"].ToString());
                                    row["rel_grp"] = int.Parse(row["rel_grp"].ToString()) + int.Parse(Row["rel_grp"].ToString());
                                    row["rel_sup"] = int.Parse(row["rel_sup"].ToString()) + int.Parse(Row["rel_sup"].ToString());
                                    row["sum1"] = int.Parse(row["sum1"].ToString()) + int.Parse(row["grp" + i].ToString());
                                    string aa = Row["fa_idno"].ToString();
                                    if (Row["fa_idno"].ToString().Trim() != "")
                                    {
                                        row["idno" + i] = Row["fa_idno"].ToString().Trim();
                                        row["name" + i] = Row["fa_name"].ToString().Trim();
                                        if (!Row.IsNull("fa_birdt")) row["birdt" + i] = DateTime.Parse(Row["fa_birdt"].ToString());
                                        break;
                                    }                                    
                                }
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz351"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["idno1"] = Row["idno"].ToString().Trim();
                            aRow["name1"] = Row["name_c"].ToString().Trim();
                            aRow["birdt1"] = DateTime.Parse(Row["birdt"].ToString());
                            aRow["rel_lab1"] = int.Parse(Row["rel_lab"].ToString());
                            aRow["rel_hel1"] = int.Parse(Row["rel_hel"].ToString());
                            aRow["rel_grp1"] = int.Parse(Row["rel_grp"].ToString());
                            aRow["rel_sup1"] = int.Parse(Row["rel_sup"].ToString());
                            aRow["grp1"] = int.Parse(Row["rel_lab"].ToString()) + int.Parse(Row["rel_hel"].ToString()) + int.Parse(Row["rel_grp"].ToString()) + int.Parse(Row["rel_sup"].ToString());
                            aRow["compname"] = Row["compname"].ToString();
                            aRow["chairman"] = Row["chairman"].ToString();
                            aRow["rel_lab"] = int.Parse(Row["rel_lab"].ToString());
                            aRow["rel_hel"] = int.Parse(Row["rel_hel"].ToString());
                            aRow["rel_grp"] = int.Parse(Row["rel_grp"].ToString());
                            aRow["rel_sup"] = int.Parse(Row["rel_sup"].ToString());
                            aRow["sum1"] = int.Parse(aRow["grp1"].ToString());
                            ds.Tables["zz351"].Rows.Add(aRow);
                        }
                    }
                    
                    foreach (DataRow Row in ds.Tables["zz351"].Rows)
                    {
                        string str1 = "";
                        string str2 = "";
                        int _len = Row["sum1"].ToString().Length;
                        for (int i = 0; i < _len ; i++)
                        {
                            int _sum1 = int.Parse(Row["sum1"].ToString().Substring(_len - (i + 1),1));
                            string sdad = _no[_sum1].ToString();
                            str1 = _no[_sum1].ToString() + char1.Substring(i, 1);
                            str2 = str1 + str2;
                        }
                        Row["sum2"] = str2 + "整";
                    }
                    if (ds.Tables["zz351"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (reporttype == "2")
                { 
                    foreach (DataRow Row in SRow)
                    {
                        DataRow aRow = ds.Tables["zz352"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        if (Row["fa_idno"].ToString().Trim() == "")
                        {
                            aRow["idno"] = Row["idno"].ToString();
                            aRow["name1"] = Row["name_c"].ToString();
                            aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                        }
                        else
                        {
                            aRow["idno"] = Row["fa_idno"].ToString();
                            aRow["name1"] = Row["fa_name"].ToString();
                            if (!Row.IsNull("fa_birdt")) aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                        }
                        aRow["rel_lab"] = int.Parse(Row["rel_lab"].ToString());
                        aRow["rel_hel"] = int.Parse(Row["rel_hel"].ToString());
                        aRow["rel_grp"] = int.Parse(Row["rel_grp"].ToString());
                        aRow["rel_sup"] = int.Parse(Row["rel_sup"].ToString());
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["chairman"] = Row["chairman"].ToString();
                        aRow["sum1"] = int.Parse(Row["rel_lab"].ToString()) + int.Parse(Row["rel_hel"].ToString()) + int.Parse(Row["rel_grp"].ToString()) + int.Parse(Row["rel_sup"].ToString());
                        string _str1 = "";
                        string _str2 = "";
                        int _len1 = aRow["sum1"].ToString().Length;
                        for (int i = 0; i < _len1; i++)
                        {
                            int _sum1 = int.Parse(aRow["sum1"].ToString().Substring(_len1 - (i + 1), 1));                            
                            _str1 = _no[_sum1].ToString() + char1.Substring(i, 1);
                            _str2 = _str1 + _str2;
                        }
                        aRow["sum2"] = _str2 + "整";
                        ds.Tables["zz352"].Rows.Add(aRow);                       
                    }                    
                    if (ds.Tables["zz352"].Rows.Count < 1)
                    {
                        
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }               
                rq_yrinsur = null; rq_base = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz35"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz35.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz351.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz352.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year_b) });
                    if (reporttype == "0" )
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz35", ds.Tables["zz35"]));
                    else if (reporttype == "1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz351", ds.Tables["zz351"]));
                    else if (reporttype == "2")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz352", ds.Tables["zz352"]));  
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("眷屬姓名", typeof(string));
            ExporDt.Columns.Add("勞保金額", typeof(int));
            ExporDt.Columns.Add("健保金額", typeof(int));
            ExporDt.Columns.Add("補充保費金額", typeof(int));
            ExporDt.Columns.Add("團保金額", typeof(int));            
            ExporDt.Columns.Add("合計金額", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["眷屬姓名"] = Row01["fa_name"].ToString();
                aRow["勞保金額"] = int.Parse(Row01["rel_lab"].ToString());
                aRow["健保金額"] = int.Parse(Row01["rel_hel"].ToString());
                aRow["補充保費金額"] = int.Parse(Row01["rel_sup"].ToString());
                aRow["團保金額"] = int.Parse(Row01["rel_grp"].ToString());               
                aRow["合計金額"] = int.Parse(Row01["rel_lab"].ToString()) + int.Parse(Row01["rel_hel"].ToString()) + int.Parse(Row01["rel_grp"].ToString()) + int.Parse(Row01["rel_sup"].ToString());                
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
