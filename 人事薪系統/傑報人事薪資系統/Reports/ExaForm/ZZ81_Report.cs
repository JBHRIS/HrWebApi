/* ======================================================================================================
 * 功能名稱：考核資料明細表
 * 功能代號：ZZ81
 * 功能路徑：報表列印 > 考核 > 考核資料明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\ExaForm\ZZ81_Report.cs
 * 功能用途：
 *  用於產出考核資料明細表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/22    Daniel Chih    Ver 1.0.01     1. 修改資料來源 Table 使功能可以正常撈資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/22
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.ExaForm
{
    public partial class ZZ81_Report : JBControls.JBForm
    {
        ExaDataSet ds = new ExaDataSet();
        string date_b, nobr_b, nobr_e, dept_b, dept_e, effg_b, effg_e, yy_b, yy_e, type_data, reporttype, comp_name;
        bool exportexcel;

        public ZZ81_Report(string dateb, string nobrb, string nobre, string deptb, string depte, string effgb, string effge, string yyb, string yye,string typedata, string _reporttype, string compname, bool _exportexcel)
        {
            InitializeComponent();
            date_b = dateb; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; effg_b = effgb; effg_e = effge;
            yy_b = yyb; yy_e = yye; reporttype = _reporttype; exportexcel = _exportexcel;
            comp_name = compname; type_data = typedata;
        }

        private void ZZ81_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,d.job_disp as job,b.indt,";
                sqlCmd += "d.job_name,e.jobl_disp as jobl,e.job_name as jobl_name,";
                sqlCmd += "c.d_no_disp as dept,c.d_name,";
                sqlCmd += string.Format(@" dbo.gettotalyears(b.nobr, '{0}' ) as wk_yrs,", date_b);
                sqlCmd += string.Format(@"datediff(day,a.birdt, '{0}' )/365.24 as age", date_b);
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " left outer join jobl e on b.jobl=e.jobl";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b,nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += " and b.ttscode in ('1','4','6')";
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr, a.yymm, b.efftype_name, a.effscore, c.efflvl_name from  effemploy a inner join efftype b on a.efftype = b.efftype ";
                sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b,nobr_e);
                sqlCmd1 += string.Format(@" and a.efftype between '{0}' and '{1}'", effg_b, effg_e);
                sqlCmd1 += " inner join efflvl c on a.efflvl = c.efflvl";
                sqlCmd1 += " order by yymm,nobr";
                DataTable rq_eff = SqlConn.GetDataTable(sqlCmd1);
                rq_eff.Columns.Add("dept", typeof(string));
                rq_eff.Columns.Add("d_name", typeof(string));
                rq_eff.Columns.Add("name_c", typeof(string));
                rq_eff.Columns.Add("job", typeof(string));
                rq_eff.Columns.Add("job_name", typeof(string));
                rq_eff.Columns.Add("jobl", typeof(string));
                rq_eff.Columns.Add("jobl_name", typeof(string));
                rq_eff.Columns.Add("wk_yrs", typeof(decimal));
                rq_eff.Columns.Add("age", typeof(decimal));
                rq_eff.Columns.Add("indt", typeof(DateTime));
                //年度表頭
                DataTable rq_title = new DataTable();
                rq_title.Columns.Add("yymm", typeof(string));
                rq_title.PrimaryKey = new DataColumn[] { rq_title.Columns["yymm"] };

                foreach (DataRow Row in rq_eff.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["name_c"] = row["name_c"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["jobl"] = row["jobl"].ToString();
                        Row["jobl_name"] = row["jobl_name"].ToString();
                        Row["wk_yrs"] = decimal.Parse(row["wk_yrs"].ToString());
                        Row["age"] = decimal.Parse(row["age"].ToString());
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        Row["yymm"] = Row["yymm"].ToString() + "年";

                        DataRow row1 = rq_title.Rows.Find(Row["yymm"].ToString());
                        if (row1 == null)
                        {
                            DataRow aRow1 = rq_title.NewRow();
                            aRow1["yymm"] = Row["yymm"].ToString();
                            rq_title.Rows.Add(aRow1);
                        }
                    }
                    else
                        Row.Delete();                   
                }
                rq_eff.AcceptChanges();
                if (rq_eff.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (reporttype == "0")
                {
                    DataRow[] SRow = rq_eff.Select("", "dept,yymm,nobr asc");
                    foreach (DataRow Row in SRow)
                    {
                        DataRow aRow = ds.Tables["zz81"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["job"] = Row["job"].ToString();
                        aRow["job_name"] = Row["job_name"].ToString();
                        aRow["jobl"] = Row["jobl"].ToString();
                        aRow["jobl_name"] = Row["jobl_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["efftype_name"] = Row["efftype_name"].ToString();
                        aRow["effscore"] = decimal.Parse(Row["effscore"].ToString());
                        aRow["efflvl_name"] = Row["efflvl_name"].ToString();
                        ds.Tables["zz81"].Rows.Add(aRow);
                    }
                }
                else
                {
                    string sqlCmd2 = "select a.nobr,a.schl,a.subj_detail,a.educcode,b.name from schl a,mtcode b";
                    sqlCmd2 += " where a.educcode=b.code and b.category like '%edu%'";
                    sqlCmd2 += "  and a.nobr+a.educcode in (select max(a.nobr+a.educcode) from schl a,basetts b ";
                    sqlCmd2 += " where a.nobr=b.nobr";
                    sqlCmd2 += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                    sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd2 += type_data;
                    sqlCmd2 += " and b.ttscode in ('1','4','6') group by a.nobr)";
                    sqlCmd2 += " order by a.nobr";
                    DataTable rq_schla = SqlConn.GetDataTable(sqlCmd2);
                    DataTable rq_schl = new DataTable();
                    rq_schl = rq_schla.Clone();
                    rq_schl.PrimaryKey = new DataColumn[] { rq_schl.Columns["nobr"] };
                    foreach (DataRow Row in rq_schla.Rows)
                    {
                        DataRow row = rq_schl.Rows.Find(Row["nobr"].ToString());
                        if (row == null)
                        {
                            rq_schl.ImportRow(Row);
                        }
                    }
                    ds.Tables["zz81td"].PrimaryKey = new DataColumn[] { ds.Tables["zz81td"].Columns["nobr"] };
                    DataRow[] SRow = rq_eff.Select("", "dept,nobr asc");
                    foreach (DataRow Row in SRow)
                    {
                        DataRow row = ds.Tables["zz81td"].Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            for (int i = 0; i < rq_title.Rows.Count; i++)
                            {
                                if (Row["yymm"].ToString().Trim() == rq_title.Rows[i]["yymm"].ToString().Trim())
                                {
                                    row["Fld" + (i + 1)] = Row["efflvl_name"].ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz81td"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["job"] = Row["job"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            for (int i = 0; i < rq_title.Rows.Count; i++)
                            {
                                aRow["Fld" + (i + 1)] = "";
                                if (Row["yymm"].ToString().Trim()== rq_title.Rows[i]["yymm"].ToString().Trim())
                                    aRow["Fld" + (i + 1)] = Row["efflvl_name"].ToString();
                            }
                            aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                            aRow["age"] = decimal.Round(decimal.Parse(Row["age"].ToString()), 2);
                            aRow["wk_yrs"] = decimal.Parse(Row["wk_yrs"].ToString());
                            DataRow row1 = rq_schl.Rows.Find(Row["nobr"].ToString());
                            if (row1 != null)
                            {
                                aRow["edu"] = row1["name"].ToString();
                                aRow["schl"] = row1["schl"].ToString();
                                aRow["subj_detail"] = row1["subj_detail"].ToString();

                            }
                            ds.Tables["zz81td"].Rows.Add(aRow);
                        }
                    }
                    DataRow aRow1 = ds.Tables["zz81ta"].NewRow();
                    for (int i = 0; i < rq_title.Rows.Count; i++)
                    {
                        aRow1["Fld" + (i + 1)] = rq_title.Rows[i]["yymm"].ToString();
                    }
                    ds.Tables["zz81ta"].Rows.Add(aRow1);
                    rq_schl = null; rq_schla = null; rq_title = null;
                }
                rq_base = null; rq_eff = null;

                if (exportexcel)
                {
                    if (reporttype == "0")
                        Export(ds.Tables["zz81"]);
                    else
                        Export1(ds.Tables["zz81td"], ds.Tables["zz81ta"]);
                    Export(ds.Tables["zz81"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "ExaReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz81.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz81a.rdlc";
                    
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYB", yy_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYE", yy_e) });
                    if (reporttype == "0" )
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("ExaDataSet_zz81", ds.Tables["zz81"]));
                    else if (reporttype == "1")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("ExaDataSet_zz81td", ds.Tables["zz81td"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("ExaDataSet_zz81ta", ds.Tables["zz81ta"]));
                    }
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
            ExporDt.Columns.Add("考核種類", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("職等", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("考核分數", typeof(decimal));
            ExporDt.Columns.Add("等級", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["考核種類"] = Row["efftype_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["職等"] = Row["job_name"].ToString();
                aRow["職稱"] = Row["jobl_name"].ToString();
                aRow["考核分數"] = decimal.Parse(Row["effscore"].ToString());
                aRow["等級"] = Row["efflvl_name"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }


        void Export1(DataTable DT,DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("年齡", typeof(decimal));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));            
            ExporDt.Columns.Add("學歷", typeof(string));
            ExporDt.Columns.Add("學校", typeof(string));
            ExporDt.Columns.Add("科系", typeof(string));
            ExporDt.Columns.Add("在職年資", typeof(decimal));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(string));
                else
                    break;
            }
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["年齡"] = decimal.Parse(Row["age"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["學歷"] = Row["edu"].ToString();
                aRow["學校"] = Row["schl"].ToString();
                aRow["科系"] = Row["subj_detail"].ToString();
                aRow["在職年資"] = decimal.Parse(Row["wk_yrs"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        aRow[DT1.Rows[0][i].ToString()] = Row["Fld" + (i + 1)].ToString();
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
