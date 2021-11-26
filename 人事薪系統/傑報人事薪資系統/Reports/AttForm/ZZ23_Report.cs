/* ======================================================================================================
 * 功能名稱：請假報表
 * 功能代號：ZZ23
 * 功能路徑：報表列印 > 出勤 > 請假報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ23_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/06/07    Daniel Chih    Ver 1.0.01     1. 請假報表中排除得假的資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/06/07
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

namespace JBHR.Reports.AttForm
{
    public partial class ZZ23_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string check_rote, type_data, lcstr, str1;
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, h_codeb, h_codee,username, comp_name;
        string yymm_b, yymm_e, date_b, date_e, reporttype, saladr_b, saladr_e;
        bool exportexcel;
        public ZZ23_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string hcodeb, string hcodee, string saladrb, string saladre, string yymmb, string yymme, string dateb, string datee, string checkrote, string typedata, string _lcstr, string _reporttype, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe;
            h_codeb = hcodeb; h_codee = hcodee; yymm_b = yymmb; yymm_e = yymme; date_b = dateb;
            date_e = datee; reporttype = _reporttype; exportexcel = _exportexcel; check_rote = checkrote;
            type_data = typedata; lcstr = _lcstr; username = _username; saladr_b = saladrb; saladr_e = saladre;
            comp_name=compname;
        }

        private void ZZ23_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += "  from base a,basetts b,dept c where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);               
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //請假
                //string sqlAbs = "select a.nobr,a.bdate,a.btime,a.etime,b.h_code_disp as h_code,b.h_name,b.not_sum,b.unit";
                //sqlAbs += ",a.tol_hours,datename(dw,a.bdate) as dw,d.wk_hrs ";
                //sqlAbs += "  from abs a ";                
                //sqlAbs += " left outer join attend c on a.nobr=c.nobr";
                //sqlAbs += " left outer join rote d on c.rote=d.rote";
                //sqlAbs += " left outer join hcode b on a.h_code=b.h_code";
                //sqlAbs += " where a.bdate=c.adate";
                //sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);
                //if (reporttype == "5")
                //    sqlAbs += "  and b.year_rest not in ('1','3','5')";
                //else
                //    sqlAbs += "  and b.year_rest not in ('1','3','5')";
                //sqlAbs += lcstr;
                //DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                string sqlAbs = "select a.nobr,a.bdate,a.btime,a.etime,b.h_code_disp as h_code,b.h_name,b.not_sum,b.unit";
                sqlAbs += ",a.tol_hours,datename(dw,a.bdate) as dw";
                sqlAbs += "  from abs a ";
                sqlAbs += " left outer join hcode b on a.h_code=b.h_code ";
                sqlAbs += string.Format(@" where a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and b.h_code_disp between '{0}' and '{1}' ", h_codeb, h_codee);
                sqlAbs += " and b.flag = '-' ";
                if (reporttype == "5")
                    sqlAbs += "  and b.flag='-' and b.not_del=0";
                else
                    sqlAbs += "  and b.flag='-' and b.not_del=0";
                sqlAbs += lcstr;
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);                

                DataTable rq_hcode = new DataTable();
                //rq_hcode.Columns.Add("h_code", typeof(string));
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_name"] };
                DataRow[] hrow = rq_abs.Select("", "h_code asc");
                foreach (DataRow Row in hrow)
                {
                    Row["dw"] = JBHR.Reports.ReportClass.GetDayWeek(DateTime.Parse(Row["bdate"].ToString()));
                    DataRow row = rq_hcode.Rows.Find(Row["h_name"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_hcode.NewRow();
                        //aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        rq_hcode.Rows.Add(aRow);
                    }
                }

                DataTable rq_zz23 = new DataTable();
                rq_zz23 = ds.Tables["zz23"].Clone();
                rq_zz23.TableName = "rq_zz23";

                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz23.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["dw"] = Row["dw"].ToString().Substring(2, 1);
                        aRow["btime"] = Row["btime"].ToString();
                        aRow["etime"] = Row["etime"].ToString();
                        aRow["unit"] = Row["unit"].ToString();
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["tola"] = (bool.Parse(Row["not_sum"].ToString())) ? 0 : decimal.Parse(Row["tol_hours"].ToString());
                        aRow["tolb"] = (bool.Parse(Row["not_sum"].ToString())) ? decimal.Parse(Row["tol_hours"].ToString()) : 0;
                        //if (Row["unit"].ToString().Trim() == "天")
                        //    aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(Row["wk_hrs"].ToString());

                        rq_zz23.Rows.Add(aRow);
                    }
                }

                DataRow[] hrowb;
                if (reporttype != "2")
                    hrowb = rq_zz23.Select("", "nobr,h_code,bdate asc");
                else
                    hrowb = rq_zz23.Select("", "dept,nobr,bdate asc");
                foreach (DataRow Row in hrowb)
                {
                    ds.Tables["zz23"].ImportRow(Row);
                }
                //JBHR.Reports.ReportClass.Export(rq_zz23, this.Name);
                if (ds.Tables["zz23"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_base = null; rq_zz23 = null;
                rq_abs = null;

                if (reporttype == "3" || reporttype == "5")
                {
                    DataRow aRow = ds.Tables["Abssumd1"].NewRow();
                    int _i = 1;
                    int _cnt = rq_hcode.Rows.Count + 1;
                    ds.Tables["Abssumd"].PrimaryKey = new DataColumn[] { ds.Tables["Abssumd"].Columns["nobr"] };
                   
                    foreach (DataRow Row in rq_hcode.Rows)
                    {
                        aRow["Fld" + _i] = Row["h_name"].ToString();
                        DataRow[] row2 = ds.Tables["zz23"].Select("h_name='" + Row["h_name"].ToString() + "'");
                        for (int i = 0; i < row2.Length; i++)
                        {
                            DataRow row3 = ds.Tables["Abssumd"].Rows.Find(row2[i]["nobr"].ToString());
                            if (row3 != null)
                                row3["Fld" + _i] = decimal.Parse(row3["Fld" + _i].ToString()) + decimal.Parse(row2[i]["tol_hours"].ToString());
                            else
                            {
                                 string dd = "";
                                 if (row2[i]["nobr"].ToString().Trim() == "10100224")
                                     dd = row2[i]["nobr"].ToString();
                                DataRow aRow2 = ds.Tables["Abssumd"].NewRow();
                                aRow2["nobr"] = row2[i]["nobr"].ToString();
                                aRow2["dept"] = row2[i]["dept"].ToString();
                                aRow2["d_name"] = row2[i]["d_name"].ToString();
                                aRow2["d_ename"] = row2[i]["d_ename"].ToString();
                                aRow2["name_c"] = row2[i]["name_c"].ToString();
                                aRow2["name_e"] = row2[i]["name_e"].ToString();
                                for (int j = 1; j < _cnt; j++)
                                {
                                    aRow2["Fld" + j] = 0;
                                }
                                aRow2["Fld" + _i] = decimal.Parse(row2[i]["tol_hours"].ToString());
                                ds.Tables["Abssumd"].Rows.Add(aRow2);
                            }
                        }
                        _i++;
                    }
                    ds.Tables["Abssumd1"].Rows.Add(aRow);
                    ds.Tables.Remove("zz23");
                }

                if (exportexcel)
                {
                    if (reporttype == "3" || reporttype == "5")
                        Export1(ds.Tables["Abssumd"], ds.Tables["Abssumd1"]);
                    else
                        Export(ds.Tables["zz23"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz231.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz232.rdlc";
                    else if (reporttype == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz233.rdlc";
                    else if (reporttype == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz234.rdlc";
                    else if (reporttype == "5")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz235.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype == "3" || reporttype == "5")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_Abssumd", ds.Tables["Abssumd"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_Abssumd1", ds.Tables["Abssumd1"]));
                    }
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz23", ds.Tables["zz23"]));
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
            ExporDt.Columns.Add("假別", typeof(string));
            ExporDt.Columns.Add("日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("時間起", typeof(string));
            ExporDt.Columns.Add("時間迄", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("應計合計", typeof(decimal));
            ExporDt.Columns.Add("未計合計", typeof(decimal));
            DataRow[] DTrow = DT.Select("", "dept,nobr,bdate,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["假別"] = Row["h_name"].ToString();
                aRow["日期"] = DateTime.Parse(Row["bdate"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["時間起"] = Row["btime"].ToString();
                aRow["時間迄"] = Row["etime"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["單位"] = Row["unit"].ToString();
                aRow["應計合計"] = decimal.Parse(Row["tola"].ToString());
                aRow["未計合計"] = decimal.Parse(Row["tolb"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));           
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(decimal));
                else
                    break;
            }
            
            DataRow[] DTrow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();               
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString()] = decimal.Parse(Row["Fld" + (i+1)].ToString());
                    else
                        break;
                }                
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
