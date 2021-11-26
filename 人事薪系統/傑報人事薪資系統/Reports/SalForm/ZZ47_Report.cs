/* ======================================================================================================
 * 功能名稱：薪資異動表
 * 功能代號：ZZ47
 * 功能路徑：報表列印 > 薪資 > 薪資異動表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ47_Report.cs
 * 功能用途：
 *  用於產出薪資異動表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/20    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：公司
 * 2021/05/07    Daniel Chih    Ver 1.0.02     1. 修復判斷篩選模式對資料結果的影響
 * 2021/05/13    Daniel Chih    Ver 1.0.03     1. 修復匯出Excel時欄位不正確的問題
 * 2021/06/15    Daniel Chih    Ver 1.0.04     1. 更新撈取前一筆資料的語法
 * 2021/07/02    Daniel Chih    Ver 1.0.05     1. 移除 amt = 0 的判斷
 * 2021/07/21    Daniel Chih    Ver 1.0.06     1. 將包含前一筆資料改成CheckBox
 *                                             2. 增加Radio Button選項：只列印超過（含）特定天數未調薪人員
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/07/21
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
    public partial class ZZ47_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, comp_b, comp_e, dept_b, dept_e, depts_b, depts_e, date_b, date_e, salcode_b, salcode_e, work_b, work_e, reporttype;
        string type_data, ttstype, depttype, workadr,emp_b,emp_e, comp_name;
        double year_no_adjust;
        bool tts_none, tts_salary, tts_no_adjust, tts_include_before, exportexcel, mangsuper;
        public ZZ47_Report(string nobrb, string nobre, string compb, string compe, string deptb, string depte, string deptsb, string deptse, string dateb, string datee, string salcodeb, string salcodee, string workb, string worke,string empb,string empe, string typedata, string _ttstype, string _depttype, bool ttsnone, bool ttssalary, bool _tts_no_adjust, double _year_no_adjust, bool _tts_include_before, bool _exportexcel, string _reporttype,string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; comp_b = compb; comp_e = compe ; dept_b = deptb; dept_e = depte; depts_b = deptsb; depts_e = deptse; date_b = dateb;
            date_e = datee; salcode_b = salcodeb; salcode_e = salcodee; work_b = workb; work_e = worke; type_data = typedata;
            ttstype = _ttstype; depttype = _depttype; tts_none = ttsnone; tts_salary = ttssalary; tts_no_adjust = _tts_no_adjust;
            year_no_adjust = _year_no_adjust; tts_include_before = _tts_include_before;
            exportexcel = _exportexcel; reporttype = _reporttype; comp_name = compname; emp_b = empb; emp_e = empe;
        }

        private void ZZ47_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,d.job_disp as job,d.job_name,e.jobl_disp as jobl,e.job_name as jobl_name";
                if (depttype == "1") sqlCmd += ",c.d_no_disp as dept,c.d_name";
                if (depttype == "2") sqlCmd += ",c.d_no_disp as dept,c.d_name";
                sqlCmd += " from base a,basetts b ";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " left outer join jobl e on b.jobl=e.jobl";
                if (depttype == "1") sqlCmd += " left outer join dept c on b.dept =c.d_no";
                if (depttype == "2") sqlCmd += " left outer join depts c on b.depts =c.d_no";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", work_b, work_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                if (depttype == "1") sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                if (depttype == "2") sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += type_data;
                if (ttstype == "0") sqlCmd += " and b.ttscode in ('1','4','6')";
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "";
                if (tts_salary)
                {
                    sqlCmd1 = "select a.nobr,a.adate,b.sal_code_disp as sal_code,b.sal_name from salbasd a,salcode b";
                    sqlCmd1 += " where a.sal_code=b.sal_code";
                    //sqlCmd1 += " and b.sal_attr in ('A','G')";
                    sqlCmd1 += string.Format(@" and a.adate <='{0}' ", date_e);
                    sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd1 += string.Format(@" and  b.sal_code_disp between '{0}' and '{1}'", salcode_b, salcode_e);
                    sqlCmd1 += " and a.nobr in (select distinct a.nobr from  salbasd a where";
                    sqlCmd1 += string.Format(@" a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd1 += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                    sqlCmd1 += string.Format(@" and b.sal_code_disp between '{0}' and '{1}')", salcode_b, salcode_e);
                    //sqlCmd1 += " and a.amt<>10 order by a.nobr,a.adate,b.sal_code_disp";
                    sqlCmd1 += " order by a.nobr,a.adate,b.sal_code_disp";
                }
                else
                {
                    sqlCmd1 = "select a.nobr,a.adate,b.sal_code_disp as sal_code,b.sal_name from salbasd a,salcode b";
                    sqlCmd1 += " where a.sal_code=b.sal_code";
                    //sqlCmd1 += " and b.sal_attr in ('A','G')";                   
                    sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd1 += string.Format(@" and b.sal_code_disp between '{0}' and '{1}'", salcode_b, salcode_e);
                    sqlCmd1 += string.Format(@" and a.adate <= '{0}' ", date_e);
                    //sqlCmd1 += " and a.amt<>10 order by a.nobr,a.adate,b.sal_code_disp";
                    sqlCmd1 += " order by a.nobr,a.adate,b.sal_code_disp";
                }
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                rq_salbasd.Columns.Add("name_c", typeof(string));
                if (rq_salbasd.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataTable rq_salt = new DataTable();
                rq_salt.Columns.Add("sal_code", typeof(string));
                rq_salt.Columns.Add("sal_name", typeof(string));
                rq_salt.PrimaryKey = new DataColumn[] { rq_salt.Columns["sal_code"] };

                DataTable rq_adate = new DataTable();
                rq_adate.Columns.Add("nobr", typeof(string));
                rq_adate.Columns.Add("name_c", typeof(string));
                rq_adate.Columns.Add("name_e", typeof(string));
                rq_adate.Columns.Add("adate", typeof(DateTime));
                rq_adate.Columns.Add("no", typeof(int));
                rq_adate.PrimaryKey = new DataColumn[] { rq_adate.Columns["nobr"], rq_adate.Columns["adate"] };
                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row["adate"].ToString());
                        DataRow row1 = rq_adate.Rows.Find(_value);
                        string aaa = DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd");
                        string bbb = DateTime.Parse(date_b).ToString("yyyyMMdd");
                        if (!tts_salary && !tts_include_before)
                        {
                            //if (row1 == null && DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd") != DateTime.Parse(date_b).ToString("yyyyMMdd"))
                            if (row1 == null)
                            {
                                DataRow aRow1 = rq_adate.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["name_c"] = row["name_c"].ToString();
                                aRow1["name_e"] = row["name_e"].ToString();
                                aRow1["adate"] = DateTime.Parse(Row["adate"].ToString());
                                rq_adate.Rows.Add(aRow1);
                            }
                        }
                        else
                        {
                            if (row1 == null)
                            {
                                DataRow aRow2 = rq_adate.NewRow();
                                aRow2["nobr"] = Row["nobr"].ToString();
                                aRow2["name_c"] = row["name_c"].ToString();
                                aRow2["name_e"] = row["name_e"].ToString();
                                aRow2["adate"] = DateTime.Parse(Row["adate"].ToString());
                                rq_adate.Rows.Add(aRow2);
                            }
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_salbasd.AcceptChanges();

                //列印最後一筆 or 列印滿特定時間未調薪
                if (tts_none || tts_no_adjust)
                {
                    string str_nobr1 = "";
                    int _no = 0;
                    bool delete = false;
                    DataRow[] Srow = rq_adate.Select("", "nobr,adate desc");
                    foreach (DataRow Row in Srow)
                    {
                        string str_nobr = Row["nobr"].ToString();
                        if (str_nobr == str_nobr1)
                            _no++;
                        else
                            _no = 0;
                        str_nobr1 = Row["nobr"].ToString();
                        //是否顯示上一筆異動 - Modified By Daniel Chih - 2021/05/07
                        if (tts_include_before)
                        {
                            //判斷是否未調薪
                            if (tts_no_adjust)
                            {
                                if(_no == 0)
                                {
                                    if (DateTime.Compare(DateTime.Parse(Row["adate"].ToString()).AddDays(year_no_adjust), DateTime.Parse(date_e)) > 0)
                                    {
                                        delete = true;
                                        Row.Delete();
                                    }
                                }
                                else
                                {
                                    if (delete)
                                    {
                                        Row.Delete();
                                        delete = false;
                                    }
                                    else if (_no > 1)
                                    {
                                        Row.Delete();
                                    }
                                }
                            }
                            else if (_no > 1)
                            {
                                Row.Delete();
                            }
                        }
                        else
                        {
                            if (_no > 0)
                            {
                                Row.Delete();
                            }
                            //判斷是否未調薪
                            else if (tts_no_adjust)
                            {
                                if (DateTime.Compare(DateTime.Parse(Row["adate"].ToString()).AddDays(year_no_adjust) , DateTime.Parse(date_e)) > 0)
                                    Row.Delete();
                            }
                        }
                    }
                    rq_adate.AcceptChanges();
                }
                if (tts_salary)
                {
                    string str_nobr1 = "";
                    int _no = 0;
                    DataRow[] Srow = rq_adate.Select("", "nobr,adate desc");
                    foreach (DataRow Row in Srow)
                    {
                        //查詢期間以外的全部刪除 - Modified By Daniel Chih - 2021/05/07
                        if (DateTime.Parse(Row["ADATE"].ToString()) < DateTime.Parse(date_b) 
                            || DateTime.Parse(Row["ADATE"].ToString()) > DateTime.Parse(date_e))
                        {
                            string str_nobr = Row["nobr"].ToString();
                            if (str_nobr == str_nobr1)
                                _no++;
                            else
                                _no = 0;
                            str_nobr1 = Row["nobr"].ToString();
                            if (tts_include_before)
                            {
                                if (_no > 0)
                                {
                                    Row.Delete();
                                }
                            }
                            else
                            {
                                Row.Delete();
                            }
                        }
                    }
                    rq_adate.AcceptChanges();
                }
               
                foreach (DataRow Row in rq_adate.Rows)
                {
                    string sqlCmd2 = "select a.nobr,c.job_disp as job,c.job_name,d.jobl_disp as jobl,d.job_name as jobl_name";
                    if (depttype == "1") sqlCmd2 += ",b.d_no_disp as dept,b.d_name";
                    if (depttype == "2") sqlCmd2 += ",b.d_no_disp as dept,b.d_name";
                    sqlCmd2 += " from basetts a";
                    if (depttype == "1") sqlCmd2 += " left outer join dept b on a.dept=b.d_no";
                    if (depttype == "2") sqlCmd2 += " left outer join depts b on a.depts=b.d_no";
                    sqlCmd2 += " left outer join job c on a.job=c.job";
                    sqlCmd2 += " left outer join jobl d on a.jobl=d.jobl";
                    sqlCmd2 += string.Format(@" where a.nobr='{0}' ", Row["nobr"].ToString());
                    sqlCmd2 += string.Format(@" and '{0}' between a.adate and a.ddate", DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd"));
                    DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd2);
                    
                    if (rq_basetts.Rows.Count> 0)
                    {
                        string sqlCmd3 = "select a.nobr,a.sal_code,b.sal_name,a.adate,a.amt from salbasd a,salcode b";
                        sqlCmd3 += " where a.sal_code=b.sal_code";
                        sqlCmd3 += string.Format(@" and '{0}' between a.adate and a.ddate", DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd"));
                        sqlCmd3 += string.Format(@" and b.sal_code_disp between '{0}' and '{1}'", salcode_b, salcode_e);
                        sqlCmd3 += string.Format(@" and a.nobr='{0}'", Row["nobr"].ToString());
                        sqlCmd3 += "  and a.amt<>10 order by b.sal_code_disp";
                        DataTable rq_salbasda = SqlConn.GetDataTable(sqlCmd3);
                        if (rq_salbasda.Rows.Count > 0)
                        {
                                
                            DataRow aRow = ds.Tables["zz47td"].NewRow();
                            aRow["dept"] = rq_basetts.Rows[0]["dept"].ToString();
                            aRow["d_name"] = rq_basetts.Rows[0]["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["job"] = rq_basetts.Rows[0]["job"].ToString();
                            aRow["job_name"] = rq_basetts.Rows[0]["job_name"].ToString();
                            aRow["jobl"] = rq_basetts.Rows[0]["jobl"].ToString();
                            aRow["jobl_name"] = rq_basetts.Rows[0]["jobl_name"].ToString();
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());                           
                            //for (int i = 0; i < rq_salt.Rows.Count; i++)
                            //{
                            //    aRow["Fld" + (i + 1)] = 0;
                            //}
                            //aRow["Fld" + (rq_salt.Rows.Count + 1)] = 0;
                            for (int j = 0; j < rq_salbasda.Rows.Count; j++)
                            {
                                DataRow row = rq_salt.Rows.Find(rq_salbasda.Rows[j]["sal_code"].ToString());
                                if (row == null)
                                {
                                    DataRow aRow1 = rq_salt.NewRow();
                                    aRow1["sal_code"] = rq_salbasda.Rows[j]["sal_code"].ToString();
                                    aRow1["sal_name"] = rq_salbasda.Rows[j]["sal_name"].ToString();
                                    rq_salt.Rows.Add(aRow1);
                                }
                                for (int i = 0; i < rq_salt.Rows.Count; i++)
                                {                                    
                                    if (rq_salt.Rows[i]["sal_code"].ToString().Trim() == rq_salbasda.Rows[j]["sal_code"].ToString().Trim())
                                    {
                                        aRow["Fld" + (i + 1)] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(rq_salbasda.Rows[j]["amt"].ToString()));
                                        break;
                                        //aRow["Fld" + (rq_salt.Rows.Count+1)] = int.Parse(aRow["Fld"+(rq_salt.Rows.Count+1)].ToString()) + int.Parse(aRow["Fld" + (i + 1)].ToString());
                                    }
                                }                                
                            }
                            ds.Tables["zz47td"].Rows.Add(aRow);
                        }
                        rq_salbasda.Clear();
                    }
                    rq_basetts.Clear();                    
                }

                DataRow aRow0 = ds.Tables["zz47ta"].NewRow();
                for (int i = 0; i < rq_salt.Rows.Count; i++)
                {
                    aRow0["Fld" + (i + 1)] = rq_salt.Rows[i]["sal_name"].ToString();
                }
                aRow0["Fld" + (rq_salt.Rows.Count + 1)] = "合計";
                ds.Tables["zz47ta"].Rows.Add(aRow0);

                foreach (DataRow Row in ds.Tables["zz47td"].Rows)
                {
                    Row["Fld" + (rq_salt.Rows.Count + 1)] = 0;
                    for (int i = 0; i < rq_salt.Rows.Count; i++)
                    {
                        if (!Row.IsNull("Fld" + (i + 1)))
                            Row["Fld" + (rq_salt.Rows.Count + 1)] = int.Parse(Row["Fld" + (rq_salt.Rows.Count + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                        else
                            Row["Fld" + (i + 1)] = 0;
                    }
                }
               
                if (ds.Tables["zz47td"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }               
                if (reporttype == "1")
                {
                    ds.Tables["zz47td2"].PrimaryKey = new DataColumn[] { ds.Tables["zz47td2"].Columns["nobr"] };                    
                    int _diff = 0;
                    DataRow[] Srow3 = ds.Tables["zz47td"].Select("", "nobr,adate asc");

                    foreach (DataRow Row in Srow3)
                    {
                        DataRow row = ds.Tables["zz47td2"].Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["amt"] = int.Parse(Row["Fld" + (rq_salt.Rows.Count + 1)].ToString());
                            row["diffamt"] = int.Parse(row["amt"].ToString()) - int.Parse(row["bamt"].ToString());
                            _diff += int.Parse(row["diffamt"].ToString());
                            row["per"] = decimal.Round((decimal.Parse(row["diffamt"].ToString()) / decimal.Parse(row["bamt"].ToString())) * 100, 2);
                            row["dept"] = Row["dept"].ToString();
                            row["d_name"] = Row["d_name"].ToString();
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz47td2"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["bamt"] = int.Parse(Row["Fld" + (rq_salt.Rows.Count + 1)].ToString());                            
                            ds.Tables["zz47td2"].Rows.Add(aRow);
                        }
                    }
                    //foreach (DataRow Row in ds.Tables["zz47td2"].Rows)
                    //{
                    //    if (!Row.IsNull("diffamt")) Row["per"] = decimal.Round(int.Parse(Row["diffamt"].ToString()) / _diff, 2);
                    //}
                    ds.Tables.Remove("zz47td");
                    ds.Tables.Remove("zz47ta");                   
                }
                

                rq_base = null;
                rq_salbasd = null;  
                rq_adate = null;               
                rq_salt = null;
                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz47td"], ds.Tables["zz47ta"]);
                    else                     
                        Export2(ds.Tables["zz47td2"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();                    
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz47.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz47a.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz47td", ds.Tables["zz47td"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz47ta", ds.Tables["zz47ta"]));
                    }
                    else
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz47td2", ds.Tables["zz47td2"]));
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

        void Export(DataTable DT,DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("異動日期", typeof(DateTime));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("職等", typeof(string));
            for (int i = 0; i < DT1.Columns.Count;i++ )
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(int));
                else
                    break;
            }
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"]=Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["異動日期"] = DateTime.Parse(Row01["adate"].ToString());
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["職等"] = Row01["jobl_name"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }


        void Export2(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("調整前薪本薪資", typeof(int));
            ExporDt.Columns.Add("調整後薪本薪資", typeof(int));
            ExporDt.Columns.Add("差異金額", typeof(int));
            ExporDt.Columns.Add("調整百分比", typeof(decimal));
            DataRow[] SRow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["調整前薪本薪資"] = int.Parse(Row01["bamt"].ToString());
                if (!Row01.IsNull("amt")) aRow["調整後薪本薪資"] = int.Parse(Row01["amt"].ToString());
                if (!Row01.IsNull("diffamt")) aRow["差異金額"] = int.Parse(Row01["diffamt"].ToString());
                if (!Row01.IsNull("per")) aRow["調整百分比"] = decimal.Parse(Row01["per"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
