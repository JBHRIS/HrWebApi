/* ======================================================================================================
 * 功能名稱：舊制勞退金提撥明細表
 * 功能代號：ZZ4BA
 * 功能路徑：報表列印 > 薪資 > 舊制勞退金提撥明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4BA.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/17    Daniel Chih    Ver 1.0.01     1. 將到職日期從集團到職日改成公司到職日
 * 2021/03/24    Daniel Chih    Ver 1.0.02     1. 增加選擇到職日類型的條件判斷
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/24
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

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4BA_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, depts_b, depts_e, date_b, seq_b, yymm_b, comp_b, comp_e, workadr, comp_name, check_indt_type;
        bool exportexcel;
        public ZZ4BA_Report(string nobrb, string nobre, string deptsb, string deptse, string dateb, string _yyb, string _mmb, string _seqb, string compb, string compe, string _workadr, bool _exportexcel, string compname, string indt_type)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb; depts_e = deptse; comp_b = compb; comp_e = compe;
            workadr = _workadr; exportexcel = _exportexcel; date_b = dateb;
            yymm_b = _yyb + _mmb; seq_b = _seqb; comp_name = compname; check_indt_type = indt_type;
        }

        private void ZZ4BA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,a.sex,a.birdt, b.indt, b.cindt, b.retdate, ";

                //若選擇公司到職日
                if (check_indt_type == "INDT")
                {
                    sqlCmd += string.Format(@"datediff(day,b.indt,'{0}') as inyear", date_b);
                }
                //若選擇集團到職日
                else if (check_indt_type == "CINDT")
                {
                    sqlCmd += string.Format(@"datediff(day,b.cindt,'{0}') as inyear", date_b);
                }

                sqlCmd += " from base a inner join basetts b on a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += " and a.count_ma='0' and b.noret='0' ";

                //若選擇公司到職日
                if (check_indt_type == "INDT")
                {
                    sqlCmd += "and b.indt < '2005/07/01'";
                }
                //若選擇集團到職日
                else if (check_indt_type == "CINDT")
                {
                    sqlCmd += "and b.cindt < '2005/07/01'";
                }

                sqlCmd += " and b.nobr not in (select distinct nobr from basetts where ttscode='2' and adate >= '2005/07/01')";
                sqlCmd += " left outer join depts c on b.depts=c.d_no";
                sqlCmd += " where 1 = 1";
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);             
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,yymm,seq from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm= '{0}' and seq = '{1}'", yymm_b, seq_b);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,b.flag from salcode a inner join salattr b on a.sal_attr=b.salattr ";
                sqlCmd3 += " and a.retire='1'";
                sqlCmd3 += " where 1 = 1";            
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
               
                string sqlCmd2 = "select w.nobr,w.yymm,w.seq,w.sal_code,st.flag,w.amt from waged w";
                sqlCmd2 += " join salcode s on w.sal_code  = s.sal_code";
                sqlCmd2 += " join salattr st on s.sal_attr  = st.salattr";
                sqlCmd2 += string.Format(@" where w.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and w.yymm ='{0}'  and w.seq ='{1}' ", yymm_b, seq_b);
                sqlCmd2 += "  order by w.nobr";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);

                //計算停薪留職
                string sqlCmd4 = "select nobr,sum(datediff(day,stdt,stindt)) as day from basetts";
                sqlCmd4 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and depts between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd4 += " and stdt is not null and stindt is not null and ttscode='4'";
                sqlCmd4 += " group by nobr";
                DataTable rq_day = SqlConn.GetDataTable(sqlCmd4);
                rq_day.PrimaryKey = new DataColumn[] { rq_day.Columns["nobr"] };
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                ds.Tables["zz4ba"].PrimaryKey = new DataColumn[] { ds.Tables["zz4ba"].Columns["nobr"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    DataRow row3 = rq_day.Rows.Find(Row["nobr"].ToString());
                    if (row != null && row1 != null && row2!=null)
                    {
                        if (row2 != null)
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                        DataRow row4 = ds.Tables["zz4ba"].Rows.Find(Row["nobr"].ToString());
                        if (row4 != null)
                        {
                            if (Row["flag"].ToString().Trim() == "-")
                                row4["amt"] = int.Parse(row4["amt"].ToString()) - JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            else
                                row4["amt"] = int.Parse(row4["amt"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        }    
                        else
                        {
                            DataRow aRow = ds.Tables["zz4ba"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString().Trim();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            aRow["sex"] = (row["sex"].ToString().Trim() == "M") ? "男" : "女";
                            aRow["birdt"] = DateTime.Parse(row["birdt"].ToString());

                            //若選擇公司到職日
                            if (check_indt_type == "INDT")
                            {
                                aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                            }
                            //若選擇集團到職日
                            else if (check_indt_type == "CINDT")
                            {
                                aRow["indt"] = DateTime.Parse(row["cindt"].ToString());
                            }

                            if (row3 != null)
                                aRow["inyear"] = decimal.Round((decimal.Parse(row["inyear"].ToString()) - decimal.Parse(row3["day"].ToString())) / Convert.ToDecimal(365.24), 2);
                            else
                                aRow["inyear"] = decimal.Round(decimal.Parse(row["inyear"].ToString()) / Convert.ToDecimal(365.24), 2);
                            if (!row.IsNull("retdate")) aRow["retdate"] = DateTime.Parse(row["retdate"].ToString());
                            aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            ds.Tables["zz4ba"].Rows.Add(aRow);
                        }
                    }
                }
                rq_base = null; rq_day = null; rq_salcode = null;
                rq_wage = null; rq_waged = null;
                if (ds.Tables["zz4ba"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4ba"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4ba.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ba", ds.Tables["zz4ba"]));
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
            
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("性別", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("年資", typeof(decimal));
            ExporDt.Columns.Add("新制起始日期", typeof(DateTime));
            ExporDt.Columns.Add("工資", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();               
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["性別"] = Row01["sex"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                aRow["年資"] = decimal.Parse(Row01["inyear"].ToString());
                if (!Row01.IsNull("retdate")) aRow["新制起始日期"] = DateTime.Parse(Row01["retdate"].ToString());
                aRow["工資"] = int.Parse(Row01["amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
