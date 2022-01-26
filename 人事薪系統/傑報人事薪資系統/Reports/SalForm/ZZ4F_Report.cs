/* ======================================================================================================
 * 功能名稱：薪資異動通知單
 * 功能代號：ZZ4F
 * 功能路徑：報表列印 > 薪資 > 薪資異動通知單
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4F.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/05/10    Daniel Chih    Ver 1.0.01     1. 增加預約發送通知的功能
 * 2021/06/24    Daniel Chih    Ver 1.0.02     1. 修正正式信件發送不出去的問題
 * 2021/08/05    Daniel Chih    Ver 1.0.03     1. 將附件從 zip 改成 pdf 格式並加密
 * 2021/08/09    Daniel Chih    Ver 1.0.04     1. 修改薪資異動通知單寄送 Mail 模式改成 SendMailWithQueueAndFileService
 * 2021/08/11    Daniel Chih    Ver 1.0.05     1. 修正附件失效的問題
 * 2021/08/13    Daniel Chih    Ver 1.0.06     1. 修改薪資異動通知單中Mail Body部分的文字內容
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/13
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
using System.Drawing.Imaging;
using System.IO;
using Ionic.Zip;
using System.Net.Mail;
using iTextSharp.text.pdf;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4F_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, reporttype, workadr, comp_name;
        string note1, note2, note3, note4, note5, emp_b, emp_e, test_email, test_pwd;
        bool exportexcel, mangsuper, sendmail, ck_dispatch, ck_file;
        DateTime Send_Date_Time;

        public ZZ4F_Report(string nobrb, string nobre, string deptb, string depte,string empb,string empe, string dateb, string datee, string _reporttype, string _workadr, string _note1, string _note2, string _note3, string _note4, string _note5, string testemail, string testpwd, bool _exportexcel, string compname, bool _sendmail, bool ckdispatch, bool ckfile, DateTime _send_date_time)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            reporttype = _reporttype; workadr = _workadr; exportexcel = _exportexcel; 
            note1 = _note1; note2 = _note2; note3 = _note3; note4 = _note4; note5 = _note5; sendmail = _sendmail;
            comp_name = compname; emp_b = empb; emp_e = empe; ck_dispatch = ckdispatch; ck_file = ckfile; test_email = testemail; test_pwd = testpwd; Send_Date_Time = _send_date_time;
        }

        private void ZZ4F_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string _datebb = DateTime.Parse(date_b).AddDays(-1).ToString("yyyy/MM/dd");
                string sqlCmd = "select b.nobr,a.name_c,b.adate,c.d_no_disp as dept,c.d_name,e.job_disp as job";
                sqlCmd += ",e.job_name,f.jobl_disp as jobl,g.compname,a.email,a.password";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " left outer join jobl f on b.jobl=f.jobl";
                sqlCmd += " left outer join comp g on b.comp=g.comp";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };                

                //薪資異動後
                //string sqlCmd2 = "select a.nobr,b.sal_code_disp as sal_code,b.sal_name,a.amt,a.meno from salbasd a,salcode b";
                //sqlCmd2 += " where a.sal_code=b.sal_code";
                //sqlCmd2 += string.Format(@" and a.adate='{0}'", date_e);
                //sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                ////sqlCmd2 += " and b.sal_attr = 'A'";
                //sqlCmd2 += " order by a.nobr,b.sal_code_disp,a.adate";
                //DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd2);
                string sqlCmd2 = "select distinct a.nobr from salbasd a,salcode b";
                sqlCmd2 += " where a.sal_code=b.sal_code";
                sqlCmd2 += string.Format(@" and a.adate='{0}'", date_e);
                sqlCmd2 += " and b.sal_attr in ('A', 'G')";
                sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += " and a.amt<> 10";
                //sqlCmd2 += " order by a.nobr,a.sal_code,a.adate";
                DataTable rq_salbasd1 = SqlConn.GetDataTable(sqlCmd2);
                DataTable rq_salbasd = new DataTable();
                rq_salbasd.Columns.Add("nobr", typeof(string));
                rq_salbasd.Columns.Add("sal_code", typeof(string));
                rq_salbasd.Columns.Add("sal_name", typeof(string));
                rq_salbasd.Columns.Add("amt", typeof(decimal));
                rq_salbasd.Columns.Add("meno", typeof(string));
                foreach (DataRow Row in rq_salbasd1.Rows)
                {
                    string sqlCmd2a = "select a.nobr,b.sal_code_disp as sal_code,b.sal_name,a.amt,a.meno from salbasd a,salcode b";
                    sqlCmd2a += " where a.sal_code=b.sal_code";
                    sqlCmd2a += string.Format(@" and '{0}' between a.adate and a.ddate", date_e);
                    sqlCmd2a += " and b.sal_attr in ('A', 'G')";
                    sqlCmd2a += string.Format(@" and a.nobr = '{0}'", Row["nobr"].ToString());
                    //sqlCmd2a += " and b.sal_attr in ('A','G') and a.amt<> 10";
                    sqlCmd2a += " order by a.nobr,a.sal_code,a.adate";
                    DataTable rq_salbasd2 = SqlConn.GetDataTable(sqlCmd2a);
                    rq_salbasd.Merge(rq_salbasd2);
                    rq_salbasd2.Clear();
                }
                rq_salbasd1 = null;
                rq_salbasd.PrimaryKey = new DataColumn[] { rq_salbasd.Columns["nobr"], rq_salbasd.Columns["sal_code"] };

                //薪資異動前
                string sqlCmd3 = "select a.nobr,b.sal_code_disp as sal_code,b.sal_name,a.amt from salbasd a,salcode b";
                sqlCmd3 += " where a.sal_code=b.sal_code";
                //sqlCmd3 += string.Format(@" and a.adate<'{0}'", date_e);
                sqlCmd3 += string.Format(@" and '{0}' between a.adate and a.ddate", DateTime.Parse(date_e).AddDays(-1).ToString("yyyy/MM/dd"));
                sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd3 += " and b.sal_attr in ('A', 'G')";
                sqlCmd3 += " order by a.nobr,b.sal_code_disp,a.adate desc";
                DataTable rq_salbasda = SqlConn.GetDataTable(sqlCmd3);
                DataTable rq_salbasdb = new DataTable();
                rq_salbasdb.Columns.Add("nobr", typeof(string));
                rq_salbasdb.Columns.Add("sal_code", typeof(string));
                rq_salbasdb.Columns.Add("sal_name", typeof(string));
                rq_salbasdb.Columns.Add("amt", typeof(int));
                rq_salbasdb.PrimaryKey = new DataColumn[] { rq_salbasdb.Columns["nobr"], rq_salbasdb.Columns["sal_code"] };

                foreach (DataRow Row in rq_salbasda.Rows)
                {
                    DataRow[] row1 = rq_salbasd.Select("nobr='" + Row["nobr"].ToString() + "'");                    
                    if (row1.Length > 0)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["sal_code"].ToString();
                        DataRow row = rq_salbasdb.Rows.Find(_value);
                        if (row == null)
                        {
                            DataRow aRow = rq_salbasdb.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["sal_code"] = Row["sal_code"].ToString();
                            aRow["sal_name"] = Row["sal_name"].ToString();
                            aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            rq_salbasdb.Rows.Add(aRow);
                        }
                        else
                            row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        for (int i = 0; i < row1.Length; i++)
                        {
                            _value[1] = row1[i]["sal_code"].ToString();
                            DataRow row2 = rq_salbasdb.Rows.Find(_value);
                            if (row2 == null)
                            {
                                DataRow aRow1 = rq_salbasdb.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["sal_code"] = row1[i]["sal_code"].ToString();
                                aRow1["sal_name"] = row1[i]["sal_name"].ToString();
                                rq_salbasdb.Rows.Add(aRow1);
                            }
                            
                        }
                    }
                }
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_salbasdb, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                
                DataColumn[] _key = new DataColumn[2];
                _key[0] = ds.Tables["zz4f"].Columns["nobr"];
                _key[1] = ds.Tables["zz4f"].Columns["sal_code"];
                ds.Tables["zz4f"].PrimaryKey = _key;
                foreach (DataRow Row in rq_salbasdb.Rows)
                {
                    //Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());                    
                    if (row != null)
                    {
                        //string _date = DateTime.Parse(row["adate"].ToString()).AddDays(-1).ToString("yyyy/MM/dd");
                        string _date = DateTime.Parse(date_b).AddDays(-1).ToString("yyyy/MM/dd");
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["sal_code"].ToString();                      
                        DataRow row3= ds.Tables["zz4f"].Rows.Find(_value);
                        if (row3 == null)
                        {                            
                            //異動前人事
                            string sqlCmd1 = "select b.nobr,b.adate,c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name";
                            sqlCmd1 += ",f.jobl_disp as jobl";
                            sqlCmd1 += " from basetts b";
                            sqlCmd1 += " left outer join dept c on b.dept=c.d_no";
                            sqlCmd1 += " left outer join job d on b.job=d.job";
                            sqlCmd1 += " left outer join jobl f on b.jobl=f.jobl";
                            sqlCmd1 += string.Format(@" where '{0}' between b.adate and b.ddate", _date);
                            sqlCmd1 += string.Format(@" and b.nobr ='{0}'", Row["nobr"].ToString());
                            DataTable rq_basea = SqlConn.GetDataTable(sqlCmd1);

                            DataRow aRow = ds.Tables["zz4f"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["job"] = row["job"].ToString();
                            aRow["job_name"] = row["job_name"].ToString();
                            aRow["jobl"] = row["jobl"].ToString();
                            aRow["email"] = row["email"].ToString();
                            aRow["password"] = row["password"].ToString();
                            if (rq_basea.Rows.Count > 0)
                            {
                                aRow["bdept"] = rq_basea.Rows[0]["dept"].ToString();
                                aRow["bd_name"] = rq_basea.Rows[0]["d_name"].ToString();
                                aRow["bjob"] = rq_basea.Rows[0]["job"].ToString();
                                aRow["bjob_name"] = rq_basea.Rows[0]["job_name"].ToString();
                                aRow["bjobl"] = rq_basea.Rows[0]["jobl"].ToString();
                            }
                            else
                            {
                                aRow["bdept"] = row["dept"].ToString();
                                aRow["bd_name"] = row["d_name"].ToString();
                                aRow["bjob"] = row["job"].ToString();
                                aRow["bjob_name"] = row["job_name"].ToString();
                                aRow["bjobl"] = row["jobl"].ToString();
                            }
                            rq_basea.Clear();
                            aRow["sal_code"] = Row["sal_code"].ToString();
                            aRow["sal_name"] = Row["sal_name"].ToString();   
                            aRow["bsal_code"] = Row["sal_code"].ToString();
                            aRow["bsal_name"] = Row["sal_name"].ToString();
                            aRow["bamt"] = (Row.IsNull("amt")) ? 0 : int.Parse(Row["amt"].ToString());                            
                            ds.Tables["zz4f"].Rows.Add(aRow);                           
                        }
                    }
                }

                string sqlCmd4 = "select a.nobr,b.sal_code_disp as sal_code,b.sal_name,a.amt,a.meno from salbasd a,salcode b";
                sqlCmd4 += " where a.sal_code=b.sal_code";
                sqlCmd4 += string.Format(@" and '{0}' between a.adate and a.ddate", date_e);
                sqlCmd4 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += " and b.sal_attr in ('A', 'G')";
                sqlCmd4 += " order by a.nobr,b.sal_code_disp,a.adate";
                DataTable rq_salbasde = SqlConn.GetDataTable(sqlCmd4);
                foreach (DataRow Row in rq_salbasde.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["sal_code"].ToString();
                    DataRow row = rq_salbasd.Rows.Find(_value);
                    if (row == null)
                        rq_salbasd.ImportRow(Row);
                }
                rq_salbasde = null;
                foreach(DataRow Row in ds.Tables["zz4f"].Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["sal_code"].ToString();
                    DataRow row = ds.Tables["zz4f"].Rows.Find(_value);
                    DataRow row1 = rq_salbasd.Rows.Find(_value);
                    if (row != null)
                    {
                        if (row1 != null)
                        {
                            row["sal_code"] = row1["sal_code"].ToString();
                            row["sal_name"] = row1["sal_name"].ToString();
                            row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["amt"].ToString()));
                            row["meno"] = row1["meno"].ToString();
                        }  
                    }
                }
                if (ds.Tables["zz4f"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (reporttype == "1")
                {
                    ds.Tables["zz4fa"].PrimaryKey = new DataColumn[] { ds.Tables["zz4fa"].Columns["nobr"] };
                    DataRow[] Srow = ds.Tables["zz4f"].Select("","dept,nobr asc");
                    string nobr_prev = "";
                    int i = 1;
                    foreach (DataRow Row in Srow)
                    {
                        DataRow row = ds.Tables["zz4fa"].Rows.Find(Row["nobr"].ToString());
                        int _amt = (Row.IsNull("amt")) ? 0 : int.Parse(Row["amt"].ToString());
                        int _bamt = (Row.IsNull("bamt")) ? 0 : int.Parse(Row["bamt"].ToString());
                        if (row != null)
                        {
                            i = i + 1;


                            if (Row["sal_code"].ToString().Trim() == row["bA" + (i - 1) + "_t"].ToString().Trim())
                            {
                                row["A01"] = _amt;
                                row["BA01"] = _bamt;
                            }
                            else
                            {
                                row["A" + i + "_t"] = Row["sal_name"].ToString().Trim();
                                row["bA" + i + "_t"] = Row["sal_code"].ToString().Trim();
                                row["A" + i] = _amt;
                                row["bA" + i] = _bamt;
                            }

                            //if (Row["sal_code"].ToString().Trim() == row[""])
                            //{
                            //    row["A01"] = _amt;
                            //    row["BA01"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A01P")
                            //{
                            //    row["A02"] = _amt;
                            //    row["BA02"] = _bamt;
                            //}

                            //else if (Row["sal_code"].ToString().Trim() == "A11")
                            //{
                            //    row["A03"] = _amt;
                            //    row["BA03"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A11P")
                            //{
                            //    row["A04"] = _amt;
                            //    row["BA04"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A13")
                            //{
                            //    row["A05"] = _amt;
                            //    row["BA05"] = _bamt;
                            //}
                            row["sumamt"] = int.Parse(row["sumamt"].ToString()) + _amt;
                            row["bsumamt"] = int.Parse(row["bsumamt"].ToString()) + _bamt;
                        }
                        else
                        {
                            i = 1;

                            DataRow aRow = ds.Tables["zz4fa"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["job"] = Row["job"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                            aRow["jobl"] = Row["jobl"].ToString();
                            aRow["bdept"] = Row["bdept"].ToString();
                            aRow["bd_name"] = Row["bd_name"].ToString();
                            aRow["bjob"] = Row["bjob"].ToString();
                            aRow["bjob_name"] = Row["bjob_name"].ToString();
                            aRow["bjobl"] = Row["bjobl"].ToString();
                            aRow["meno"] = Row["meno"].ToString();

                            aRow["A" + i + "_t"] = Row["sal_name"].ToString().Trim();
                            aRow["bA" + i + "_t"] = Row["sal_code"].ToString().Trim();
                            aRow["A" + i] = _amt;
                            aRow["bA" + i] = _bamt;

                            //if (Row["sal_code"].ToString().Trim() == "A01")
                            //{
                            //    aRow["A01"] = _amt;
                            //    aRow["BA01"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A01P")
                            //{
                            //    aRow["A02"] = _amt;
                            //    aRow["BA02"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A11")
                            //{
                            //    aRow["A03"] = _amt;
                            //    aRow["BA03"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A11P")
                            //{
                            //    aRow["A04"] = _amt;
                            //    aRow["BA04"] = _bamt;
                            //}
                            //else if (Row["sal_code"].ToString().Trim() == "A13")
                            //{
                            //    aRow["A05"] = _amt;
                            //    aRow["BA05"] = _bamt;
                            //}

                            aRow["sumamt"] = _amt;
                            aRow["bsumamt"] = _bamt;
                            ds.Tables["zz4fa"].Rows.Add(aRow);
                        }                        
                    }
                    ds.Tables.Remove("zz4f");
                }
                rq_base = null;                
                rq_salbasd = null;
                rq_salbasda = null;
                rq_salbasdb = null;                

                if (exportexcel)
                {
                    //Export(ds.Tables["zz4e"]);
                    this.Close();
                }
                else if ((sendmail || ck_file) && reporttype == "0")
                {
                    Get_SendMail(ds.Tables["zz4f"], note3);
                    string messagetext = "薪資異動通知單發送完畢";
                    if (ck_file) messagetext = "薪資異動通知單測試發送完畢";
                    MessageBox.Show(messagetext, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                else
                {
                    string str_image = "";                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _floor1 = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "Reports", "*.gif");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4f.rdlc";
                        RptViewer.LocalReport.DataSources.Clear();
                        //Bitmap objBitmap = new Bitmap(_floor1 + "PPSCS.gif");
                        //MemoryStream MyMS = new MemoryStream();
                        //objBitmap.Save(MyMS, System.Drawing.Imaging.ImageFormat.Gif);
                        //str_image = Convert.ToBase64String(MyMS.ToArray());
                        //MyMS.Close();
                    }
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4f1.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("ImageP", str_image) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno1", note3) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno2", note4) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno3", note5) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4f", ds.Tables["zz4f"]));
                    }
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno1", note1) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno2", note2) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno3", note3) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno4", note4) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno5", note5) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4fa", ds.Tables["zz4fa"]));
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


        void Get_SendMail(DataTable DT_4219, string note3)
        {
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            DataTable rqparameter = SqlConn.GetDataTable("select code,value from Parameter where code in ('JbMail.sys_mail','JbMail.TestAccount','JbMail.Sender','JbMail.SenderName')");
            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
            DataTable dt4219 = new DataTable();
            dt4219 = DT_4219.Clone();
            dt4219.TableName = "dt4219";
            string MailFrom = string.Empty;
            string SenderName = string.Empty;
            foreach (DataRow Row1 in rqparameter.Rows)
            {
                if (Row1["code"].ToString().Trim() == "JbMail.Sender")
                    MailFrom = Row1["value"].ToString();
                else if (Row1["code"].ToString().Trim() == "JbMail.SenderName")
                    SenderName = Row1["value"].ToString();
            }

            string mailtitle = (ck_file) ? "測試薪資異動通知" : "薪資異動通知";
            //if (ck_file) mailtitle += "測試員工編號=>";
            string _filename = DateTime.Parse(date_e).ToString("yyyyMMdd") + "薪資異動通知";
            if (!System.IO.Directory.Exists(JBControls.ControlConfig.GetExportPath() + _filename))//檢查目錄是否存在，不存在就建立新目錄
                System.IO.Directory.CreateDirectory(JBControls.ControlConfig.GetExportPath() + _filename);
            string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
            _rptpath += "Rpt_zz4f.rdlc";
            string str_image = "";
            DataTable rq_nobr = new DataTable();
            rq_nobr.Columns.Add("nobr", typeof(string));
            rq_nobr.Columns.Add("email", typeof(string));
            rq_nobr.Columns.Add("password", typeof(string));
            rq_nobr.PrimaryKey = new DataColumn[] { rq_nobr.Columns["nobr"] };

            foreach (DataRow Row in DT_4219.Rows)
            {
                if (Row["email"].ToString().Trim() != "")
                {
                    DataRow row = rq_nobr.Rows.Find(Row["nobr"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_nobr.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        if (ck_file)
                        {
                            aRow["email"] = test_email;
                            aRow["password"] = test_pwd;
                        }
                        else
                        {
                            aRow["email"] = Row["email"].ToString();
                            aRow["password"] = Row["password"].ToString();
                        }
                        rq_nobr.Rows.Add(aRow);
                    }
                }
            }
            string dda = JBControls.ControlConfig.GetExportPath();


            foreach (DataRow Row in rq_nobr.Rows)
            {
                foreach (DataRow Row1 in DT_4219.Select("nobr='" + Row["nobr"].ToString() + "'"))
                {
                    dt4219.ImportRow(Row1);
                }

                ReportViewer RptViewer = new ReportViewer();
                RptViewer.ProcessingMode = ProcessingMode.Local;
                RptViewer.LocalReport.ReportPath = _rptpath;
                RptViewer.LocalReport.DataSources.Clear();
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("ImageP", str_image) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno1", note3) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno2", note4) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Meno3", note5) });
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4f", dt4219));
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                //成功加密發送檔案
                //string TempFile = JBControls.ControlConfig.GetExportPath() + @"Salary\output.pdf";
                string TranFile = JBControls.ControlConfig.GetExportPath() + _filename + @"\" + Row["nobr"].ToString().Trim() + "_Out.pdf";

                string TranFile_Final = JBControls.ControlConfig.GetExportPath() + _filename + @"\" + Row["nobr"].ToString().Trim() + ".pdf";

                byte[] bytes = RptViewer.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding, out extension,
                   out streamids, out warnings);
                using (FileStream fs = new FileStream(TranFile, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                RptViewer.Dispose();

                PdfReader reader = new PdfReader(TranFile);
                //iTextSharp.text.pdf加密程式
                Stream os = (Stream)(new FileStream(TranFile_Final, FileMode.Create));
                PdfEncryptor.Encrypt(reader, os, true, Row["password"].ToString().Trim(), Row["password"].ToString().Trim(), PdfWriter.ALLOW_PRINTING);
                reader.Dispose();
                string[] txtList = Directory.GetFiles(JBControls.ControlConfig.GetExportPath() + _filename, Row["nobr"].ToString().Trim() + "_Out.pdf");
                foreach (string f in txtList)
                {
                    File.Delete(f);
                }

                ////Ionic.Zip加密
                //string ZipFild = JBControls.ControlConfig.GetExportPath() + _filename + @"\" + Row["nobr"].ToString().Trim() + ".zip";
                //using (var zip = new ZipFile())
                //{
                //    //zip.Password = Row["idno"].ToString().Trim().ToUpper();
                //    zip.Password = Row["password"].ToString().Trim();
                //    zip.AddFile(TranFile, "");
                //    zip.Save(ZipFild);
                //    //zip.Dispose();
                //}

                Attachment AttFild = new Attachment(TranFile_Final, System.Net.Mime.MediaTypeNames.Application.Octet);
                List<Attachment> listFild = new List<Attachment>();
          
                    listFild.Add(AttFild);
                //if (!ck_file)
                //    Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), mailtitle, mailtitle, listFild);
                //if (ck_file)
                //    Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), mailtitle + Row["nobr"].ToString(), mailtitle, listFild);
                //else
                //    Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), "【" + Row["nobr"].ToString() + "】" + mailtitle, mailtitle, listFild);
                try
                {
                    if (ck_file)
                    {
                        JBModule.Message.TextLog.WriteLog("測試薪資異動通知至員工編號：" + Row["nobr"].ToString() + "->" + Row["email"].ToString());
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("薪資異動通知至員工編號：" + Row["nobr"].ToString() + "->" + Row["email"].ToString());
                    }

                    Smail.SendMailWithQueueAndFileService(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), "【" + Row["nobr"].ToString() + "】" + mailtitle, note3, listFild, Send_Date_Time);

                    ////改成 AddMailQueueWithFileService
                    //Smail.AddMailQueueWithFileService(Row["email"].ToString().Trim(), "【" + Row["nobr"].ToString() + "】" + mailtitle, mailtitle, listFild, Send_Date_Time);
                }
                catch (Exception Ex)
                {
                    JBModule.Message.TextLog.WriteLog(Ex);
                    continue;
                }


                File.Delete(TranFile);

                dt4219.Clear();
                listFild.Clear();
                AttFild.Dispose();
            }
            //Directory.Delete(JBControls.ControlConfig.GetExportPath() + @"Salary", true);
        }
    }
}
