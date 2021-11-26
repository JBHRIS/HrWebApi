/* ======================================================================================================
 * 功能名稱：所得人所得資料表
 * 功能代號：ZZ52
 * 功能路徑：報表列印 > 媒體申報 > 所得人資料明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ52_Report.cs
 * 功能用途：
 *  用於產出所得人資料明細表、所得人資料匯總表、所得人所得格式資料匯總表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/06/23    Daniel Chih    Ver 1.0.00     1. Create
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/06/23
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
    public partial class ZZ52_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e
            //, dept_b, dept_e
            , year_b, year_e, month_b, month_e
            , yymm_b, yymm_e
            , format_b, format_e
            , tcode_b, tcode_e
            , seq_b, seq_e, ser_nob, ser_noe, type_data, ordertype, reporttype, username, comp_name, CompId;
        bool exportexcel;
        public ZZ52_Report(string nobrb, string nobre
            //, string deptb, string depte
            , string yearb, string yeare
            , string monthb, string monthe
            , string seqb, string seqe
            , string formatb, string formate
            , string tcodeb, string tcodee
            , string typedata, string _ordertype, string _reporttype, string _username, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; 
            //dept_b = deptb; dept_e = depte;
            year_b = yearb; year_e = yeare; 
            month_b = monthb; month_e = monthe;
            seq_b = seqb; seq_e = seqe;
            format_b = formatb; format_e = formate;
            tcode_b = tcodeb; tcode_e = tcodee;
            type_data = typedata; ordertype = _ordertype; reporttype = _reporttype;
            username = _username; comp_name = compname; CompId = _CompId;
            yymm_b = year_b.ToString().Trim() + month_b.ToString().Trim();
            yymm_e = year_e.ToString().Trim() + month_e.ToString().Trim();
        }

        private void ZZ52_Report_Load(object sender, EventArgs e)
        {
            try
            {


//AND D.NOBR BETWEEN 'AC04016004' AND 'AG20785013'
//AND D.YYMM BETWEEN '201802' AND '201809'
//AND D.SEQ BETWEEN '2' AND '3'
//--AND D.FORMAT BETWEEN '' AND ''
//--AND D.

//ORDER BY D.YYMM,D.SAL_CODE,A.NOBR

                //string date_b =year+ "/12/31";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = " SELECT D.AUTO, D.PID, D.NOBR, D.YYMM, D.SEQ, D.SAL_CODE, D.AMT";
                sqlCmd += ", D.D_AMT, D.TR_TYPE, D.FORMAT, D.MEMO, D.INA_ID, D.TAXNO, D.SUBCODE";
                sqlCmd += ", D.FORSUB, D.COMP, D.SUP_AMT, D.IMPORT, D.RET_AMT, D.IS_FILE, D.Note1, D.Note2";
                sqlCmd += ", A.NAME_C, E.NAME, G.T_NAME, F.M_SUB_NAME ";

                sqlCmd += " FROM TBASE A INNER JOIN TW_TAX_ITEM D ON A.NOBR = D.NOBR ";

                //sqlCmd += string.Format(@" AND D.NOBR BETWEEN '{0}' AND '{1}' ", nobr_b, nobr_e);
                sqlCmd += string.Format(@" AND D.YYMM BETWEEN '{0}' AND '{1}' ", yymm_b, yymm_e);
                sqlCmd += string.Format(@" AND D.SEQ BETWEEN '{0}' AND '{1}' ", seq_b, seq_e);
                sqlCmd += string.Format(@" AND D.FORMAT BETWEEN '{0}' AND '{1}' ", format_b, format_e);
                sqlCmd += string.Format(@" AND D.SAL_CODE BETWEEN '{0}' AND '{1}' ", tcode_b, tcode_e);

                sqlCmd += " INNER JOIN YRFOMAT E ON D.FORMAT = E.CODE ";
                sqlCmd += " INNER JOIN TW_TAX_SUBCODE F ON E.CODE = F.M_FORMAT ";
                sqlCmd += " INNER JOIN TCODE G ON D.SAL_CODE = G.T_CODE ";

                sqlCmd += " WHERE 1 = 1 ";
                sqlCmd += " AND E.CATEGORY = 'YRFOMAT' ";

                //sqlCmd += type_data;

                sqlCmd += " ORDER BY D.YYMM,D.SAL_CODE,A.NOBR ";

                DataTable rq_tax_item = SqlConn.GetDataTable(sqlCmd);

                if (rq_tax_item.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_tax_item.Rows)
                {
                    Row["NOBR"] = Row["NOBR"].ToString().Trim();
                    //decimal tot_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tot_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal rel_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal tax_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tax_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal ret_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["ret_amt"].ToString())), MidpointRounding.AwayFromZero);

                    //所得金額
                    Row["AMT"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["AMT"].ToString())), MidpointRounding.AwayFromZero);
                    //代扣稅額
                    Row["D_AMT"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["D_AMT"].ToString())), MidpointRounding.AwayFromZero);
                    //補充保費
                    Row["SUP_AMT"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["SUP_AMT"].ToString())), MidpointRounding.AwayFromZero);
                    //勞退自提
                    Row["RET_AMT"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["RET_AMT"].ToString())), MidpointRounding.AwayFromZero);
                    
                    //DataRow aRow = ds.Tables["zz52"].NewRow();
                    //aRow["nobr"] = Row["nobr"].ToString();
                    //aRow["id"] = Row["id"].ToString();
                    //aRow["id1"] = Row["id1"].ToString();
                    //ds.Tables["zz52"].Rows.Add(aRow);
                    ds.Tables["zz52"].ImportRow(Row);
                }
                rq_tax_item = null;

                //所得人資料匯總表
                if (reporttype == "1")
                {
                    DataTable rq_zz52_sum = new DataTable();
                    rq_zz52_sum = ds.Tables["zz52_sum"].Clone();
                    rq_zz52_sum.PrimaryKey=new DataColumn[] { rq_zz52_sum.Columns["YYMM"], rq_zz52_sum.Columns["SAL_CODE"] };

                    foreach (DataRow zz52_row in ds.Tables["zz52"].Rows)
                    {
                        object[] sum_value = new object[2];
                        sum_value[0] = zz52_row["YYMM"].ToString().Trim();
                        sum_value[1] = zz52_row["SAL_CODE"].ToString().Trim();

                        DataRow row_zz52_sum = rq_zz52_sum.Rows.Find(sum_value);

                        //判斷是否要加總
                        if (row_zz52_sum != null)
                        {
                            row_zz52_sum["AMT"] = decimal.Parse(row_zz52_sum["AMT"].ToString().Trim()) + decimal.Parse(zz52_row["AMT"].ToString().Trim());
                            row_zz52_sum["D_AMT"] = decimal.Parse(row_zz52_sum["D_AMT"].ToString().Trim()) + decimal.Parse(zz52_row["D_AMT"].ToString().Trim());
                            row_zz52_sum["SUP_AMT"] = decimal.Parse(row_zz52_sum["SUP_AMT"].ToString().Trim()) + decimal.Parse(zz52_row["SUP_AMT"].ToString().Trim());
                        }
                        //若尚無資料則建新的
                        else
                        {
                            DataRow aRow_zz52_sum = rq_zz52_sum.NewRow();

                            aRow_zz52_sum["YYMM"] = zz52_row["YYMM"].ToString();
                            aRow_zz52_sum["SAL_CODE"] = zz52_row["SAL_CODE"].ToString();
                            aRow_zz52_sum["T_NAME"] = zz52_row["T_NAME"].ToString().Trim();

                            aRow_zz52_sum["AMT"] = decimal.Parse(zz52_row["AMT"].ToString().Trim());
                            aRow_zz52_sum["D_AMT"] = decimal.Parse(zz52_row["D_AMT"].ToString().Trim());
                            aRow_zz52_sum["SUP_AMT"] = decimal.Parse(zz52_row["SUP_AMT"].ToString().Trim());

                            rq_zz52_sum.Rows.Add(aRow_zz52_sum);
                        }
                    }
                    ds.Tables["zz52_sum"].Merge(rq_zz52_sum);
                }

                //所得人所得格式資料匯總表
                if (reporttype == "2")
                {
                    DataTable rq_zz52_sum_format = new DataTable();
                    rq_zz52_sum_format = ds.Tables["zz52_sum"].Clone();
                    rq_zz52_sum_format.PrimaryKey = new DataColumn[] { rq_zz52_sum_format.Columns["SAL_CODE"] };

                    foreach (DataRow zz52_row in ds.Tables["zz52"].Rows)
                    {
                        DataRow row_zz52_sum_format = rq_zz52_sum_format.Rows.Find(zz52_row["SAL_CODE"].ToString().Trim());

                        //判斷是否要加總
                        if (row_zz52_sum_format != null)
                        {
                            row_zz52_sum_format["AMT"] = decimal.Parse(row_zz52_sum_format["AMT"].ToString().Trim()) + decimal.Parse(zz52_row["AMT"].ToString().Trim());
                            row_zz52_sum_format["D_AMT"] = decimal.Parse(row_zz52_sum_format["D_AMT"].ToString().Trim()) + decimal.Parse(zz52_row["D_AMT"].ToString().Trim());
                            row_zz52_sum_format["SUP_AMT"] = decimal.Parse(row_zz52_sum_format["SUP_AMT"].ToString().Trim()) + decimal.Parse(zz52_row["SUP_AMT"].ToString().Trim());
                        }
                        //若尚無資料則建新的
                        else
                        {
                            DataRow aRow_zz52_sum_format = rq_zz52_sum_format.NewRow();

                            aRow_zz52_sum_format["SAL_CODE"] = zz52_row["SAL_CODE"].ToString();
                            aRow_zz52_sum_format["T_NAME"] = zz52_row["T_NAME"].ToString().Trim();

                            aRow_zz52_sum_format["AMT"] = decimal.Parse(zz52_row["AMT"].ToString().Trim());
                            aRow_zz52_sum_format["D_AMT"] = decimal.Parse(zz52_row["D_AMT"].ToString().Trim());
                            aRow_zz52_sum_format["SUP_AMT"] = decimal.Parse(zz52_row["SUP_AMT"].ToString().Trim());

                            rq_zz52_sum_format.Rows.Add(aRow_zz52_sum_format);
                        }
                    }
                    ds.Tables["zz52_sum"].Merge(rq_zz52_sum_format);
                }

                RptViewer.Reset();

                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");

                switch (reporttype)
                {
                    case "0":
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz52.rdlc";

                        break;
                    case "1":
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz52_sum.rdlc";

                        break;
                    case "2":
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz52_sum_format.rdlc";

                        break;
                }
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year_e) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });

                if (reporttype == "0")
                {
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz52", ds.Tables["zz52"]));
                }
                else
                {
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz52", ds.Tables["zz52_sum"]));
                }
                RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                RptViewer.ZoomMode = ZoomMode.FullPage;
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
        }
    }
}
