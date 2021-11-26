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
    public partial class ZZ3U_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, yymm_b, yymm_e, type_data, saladr, report_type, comp_name, CompId;
        bool exportexcel,prn_tts;
        public ZZ3U_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string yyb, string yye, string typedata, string _saladr, string reporttype, bool _exportexcel, bool prntts, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb;
            yymm_b = yyb; yymm_e = yye; exportexcel = _exportexcel; type_data = typedata;
            saladr = _saladr; prn_tts = prntts; report_type = reporttype; comp_name = compname;
            CompId = _CompId;
        }

        private void ZZ3U_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_usys4 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                string retsalcode = (rq_usys4.Rows.Count > 0) ? rq_usys4.Rows[0]["retsalcode"].ToString() : "";
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,a.idno,a.count_ma,di,matno";
                sqlCmd += ",d.d_no_disp as depts,d.d_name as ds_name";
                sqlCmd += " from base a,basetts b left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += saladr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.amt from waged a";
                sqlCmd1 += string.Format(@" where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.sal_code='{0}' and a.seq='2'", retsalcode);

                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd1);
                rq_waged.PrimaryKey = new DataColumn[] { rq_waged.Columns["nobr"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                }

                string sqlCmd2 = "select a.nobr,a.insur_type,a.fa_idno,a.exp,a.comp,a.fundamt from explab a";
                sqlCmd2 += string.Format(@" where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += type_data;
                DataTable rq_explab = SqlConn.GetDataTable(sqlCmd2);
                rq_explab.Columns.Add("dept", typeof(string));
                rq_explab.Columns.Add("d_name", typeof(string));
                rq_explab.Columns.Add("d_ename", typeof(string));
                rq_explab.Columns.Add("depts", typeof(string));
                rq_explab.Columns.Add("ds_name", typeof(string));
                rq_explab.Columns.Add("name_c", typeof(string));
                rq_explab.Columns.Add("name_e", typeof(string));
                rq_explab.Columns.Add("i_exp", typeof(int));
                rq_explab.Columns.Add("i_comp", typeof(int));
                rq_explab.Columns.Add("di", typeof(string));
                rq_explab.Columns.Add("del", typeof(string));
                foreach (DataRow Row in rq_explab.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_waged.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["i_exp"] = 0;
                        Row["i_comp"] = 0;
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["d_ename"] = row["d_ename"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["ds_name"].ToString();
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["di"] = row["di"].ToString();
                        Row["exp"] = (Convert.ToDecimal(Row["exp"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["exp"].ToString()));
                        Row["comp"] = (Convert.ToDecimal(Row["comp"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                        Row["fundamt"] = (Convert.ToDecimal(Row["fundamt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["fundamt"].ToString()));
                        Row["comp"] = decimal.Round(decimal.Parse(Row["comp"].ToString()) - decimal.Parse(Row["fundamt"].ToString()), 0);
                        Row["del"] = "0";
                        if (Row["fa_idno"].ToString().Trim() == "")
                            Row["fa_idno"] = (bool.Parse(row["count_ma"].ToString())) ? row["matno"].ToString() : row["idno"].ToString();
                        if (row1 != null)
                        {
                            if (Row["insur_type"].ToString().Trim() == "4") Row["exp"] = decimal.Round(decimal.Parse(row1["amt"].ToString()), 0);
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_explab.AcceptChanges();

                string sqlCmd3 = "select a.nobr,a.insur_type,a.fa_idno,a.exp as i_exp,a.comp as i_comp,b.count_ma,b.matno from inpolab a,base b ";
                sqlCmd3 += string.Format(@" where a.nobr= b.nobr and  a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd3 += type_data;
                DataTable rq_inpolab = SqlConn.GetDataTable(sqlCmd3);
                foreach (DataRow Row in rq_inpolab.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        //if (bool.Parse(row["count_ma"].ToString())) Row["fa_idno"] = row["idno"].ToString();
                        DataRow aRow = rq_explab.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["depts"] = row["depts"].ToString();
                        aRow["ds_name"] = row["ds_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["di"] = row["di"].ToString();
                        aRow["insur_type"] = Row["insur_type"].ToString();
                        aRow["fa_idno"] = Row["fa_idno"].ToString();
                        if (bool.Parse(row["count_ma"].ToString()))
                            aRow["fa_idno"] = row["matno"].ToString();
                        aRow["exp"] = 0;
                        aRow["comp"] = 0;
                        aRow["i_exp"] = decimal.Round(decimal.Parse(Row["i_exp"].ToString()), 0);
                        aRow["i_comp"] = decimal.Round(decimal.Parse(Row["i_comp"].ToString()), 0);
                        aRow["del"] = "0";
                        rq_explab.Rows.Add(aRow);
                    }
                }
                rq_inpolab = null;
                DataTable rq_family = SqlConn.GetDataTable("select nobr,fa_idno,fa_name from family");
                rq_family.PrimaryKey = new DataColumn[] { rq_family.Columns["nobr"], rq_family.Columns["fa_idno"] };
                DataColumn[] _key = new DataColumn[3];
                _key[0] = ds.Tables["zz3u"].Columns["nobr"];
                _key[1] = ds.Tables["zz3u"].Columns["fa_idno"];
                _key[2] = ds.Tables["zz3u"].Columns["insur_type"];
                ds.Tables["zz3u"].PrimaryKey = _key;

                if (prn_tts)
                {
                    foreach (DataRow Row in rq_explab.Rows)
                    {
                        if (int.Parse(Row["comp"].ToString()) == int.Parse(Row["i_comp"].ToString()) && int.Parse(Row["exp"].ToString()) == int.Parse(Row["i_exp"].ToString()))
                            Row["del"] = "1";
                    }
                }
                rq_explab.AcceptChanges();
                DataRow[] SRow = rq_explab.Select("del='0'", "dept,nobr asc");

                DataTable rq_zz3u = new DataTable();
                rq_zz3u = ds.Tables["zz3u"].Clone();
                rq_zz3u.TableName = "rq_zz3u";
                foreach (DataRow Row in SRow)
                {

                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["fa_idno"].ToString();
                    _value[2] = Row["insur_type"].ToString();
                    DataRow row = rq_zz3u.Rows.Find(_value);
                    if (row != null)
                    {
                        row["comp"] = int.Parse(row["comp"].ToString()) + decimal.Round(decimal.Parse(Row["comp"].ToString()), 0);
                        row["i_comp"] = int.Parse(row["i_comp"].ToString()) + decimal.Round(decimal.Parse(Row["i_comp"].ToString()), 0);
                        row["exp"] = int.Parse(row["exp"].ToString()) + decimal.Round(decimal.Parse(Row["exp"].ToString()), 0);
                        row["i_exp"] = int.Parse(row["i_exp"].ToString()) + decimal.Round(decimal.Parse(Row["i_exp"].ToString()), 0);
                    }
                    else
                    {
                        object[] _value1 = new object[2];
                        _value1[0] = Row["nobr"].ToString();
                        _value1[1] = Row["fa_idno"].ToString();
                        DataRow row1 = rq_family.Rows.Find(_value1);
                        DataRow aRow = rq_zz3u.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["di"] = Row["di"].ToString();
                        if (row1 != null) aRow["fa_name"] = row1["fa_name"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["d_ename"] = Row["d_ename"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["ds_name"] = Row["ds_name"].ToString();
                        aRow["fa_idno"] = Row["fa_idno"].ToString();
                        aRow["insur_type"] = Row["insur_type"].ToString();
                        if (Row["insur_type"].ToString().Trim() == "1") aRow["insur_name"] = "勞保";
                        if (Row["insur_type"].ToString().Trim() == "2") aRow["insur_name"] = "健保";
                        if (Row["insur_type"].ToString().Trim() == "4") aRow["insur_name"] = "勞退";
                        aRow["comp"] = decimal.Round(decimal.Parse(Row["comp"].ToString()), 0);
                        aRow["i_comp"] = decimal.Round(decimal.Parse(Row["i_comp"].ToString()), 0);
                        aRow["exp"] = decimal.Round(decimal.Parse(Row["exp"].ToString()), 0);
                        aRow["i_exp"] = decimal.Round(decimal.Parse(Row["i_exp"].ToString()), 0);
                        rq_zz3u.Rows.Add(aRow);
                    }
                }
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_zz3u, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                foreach (DataRow Row in rq_zz3u.Rows)
                {
                    if (prn_tts)
                    {
                        if (int.Parse(Row["exp"].ToString()) != int.Parse(Row["i_exp"].ToString()) || int.Parse(Row["comp"].ToString()) != int.Parse(Row["i_comp"].ToString()))
                            ds.Tables["zz3u"].ImportRow(Row);
                    }
                    else
                        ds.Tables["zz3u"].ImportRow(Row);
                }
                rq_base = null; rq_family = null; rq_usys4 = null; rq_waged = null; rq_zz3u = null;
                if (ds.Tables["zz3u"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    if (report_type == "0")
                        Export(ds.Tables["zz3u"]);
                    else
                        Export1(ds.Tables["zz3u"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz3u.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmE", yymm_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz3u", ds.Tables["zz3u"]));
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
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("眷屬姓名", typeof(string));
            ExporDt.Columns.Add("類別", typeof(string));
            ExporDt.Columns.Add("個人系統計算", typeof(int));
            ExporDt.Columns.Add("個人匯入", typeof(int));
            ExporDt.Columns.Add("公司系統計算", typeof(int));
            ExporDt.Columns.Add("公司匯入", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["身分證號"] = Row01["fa_idno"].ToString();
                aRow["眷屬姓名"] = Row01["fa_name"].ToString();
                aRow["類別"] = Row01["insur_name"].ToString();
                aRow["個人系統計算"] = int.Parse(Row01["exp"].ToString());
                aRow["個人匯入"] = int.Parse(Row01["i_exp"].ToString());
                aRow["公司系統計算"] = int.Parse(Row01["comp"].ToString());
                aRow["公司匯入"] = int.Parse(Row01["i_comp"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            string _monb = yymm_b.Substring(4, 2);
            string _mone = yymm_e.Substring(4, 2);
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add(_monb + "預估個人負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "預估個人負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "預估個人負擔勞退", typeof(int));
            ExporDt.Columns.Add(_monb + "預估公司負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "預估公司負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "預估公司負擔勞退", typeof(int));
            ExporDt.Columns.Add(_monb + "實際個人負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "實際個人負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "實際個人負擔勞退", typeof(int));
            ExporDt.Columns.Add(_monb + "實際公司負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "實際公司負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "實際公司負擔勞退", typeof(int));
            ExporDt.Columns.Add(_monb + "差異個人負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "差異個人負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "差異個人負擔勞退", typeof(int));
            ExporDt.Columns.Add(_monb + "差異公司負擔勞保", typeof(int));
            ExporDt.Columns.Add(_monb + "差異公司負擔健保", typeof(int));
            ExporDt.Columns.Add(_monb + "差異公司負擔勞退", typeof(int));
            ExporDt.PrimaryKey = new DataColumn[] { ExporDt.Columns["成本部門"], ExporDt.Columns["直間接"] };
            string str_nobr1 = "";
            foreach (DataRow Row01 in DT.Rows)
            {
                string str_nobr = Row01["nobr"].ToString();
                object[] _value = new object[2];
                _value[0] = Row01["depts"].ToString();
                _value[1] = Row01["di"].ToString();
                DataRow row = ExporDt.Rows.Find(_value);
                if (row != null)
                {
                    if (Row01["insur_name"].ToString() == "勞保")
                    {
                        row[_monb + "預估個人負擔勞保"] = int.Parse(row[_monb + "預估個人負擔勞保"].ToString()) + int.Parse(Row01["exp"].ToString());
                        row[_monb + "預估公司負擔勞保"] = int.Parse(row[_monb + "預估公司負擔勞保"].ToString()) + int.Parse(Row01["comp"].ToString());
                        row[_monb + "實際個人負擔勞保"] = int.Parse(row[_monb + "實際個人負擔勞保"].ToString()) + int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "實際公司負擔勞保"] = int.Parse(row[_monb + "實際公司負擔勞保"].ToString()) + int.Parse(Row01["i_comp"].ToString());
                        row[_monb + "差異個人負擔勞保"] = int.Parse(row[_monb + "差異個人負擔勞保"].ToString()) + int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "差異公司負擔勞保"] = int.Parse(row[_monb + "差異公司負擔勞保"].ToString()) + int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    else if (Row01["insur_name"].ToString() == "健保")
                    {
                        row[_monb + "預估個人負擔健保"] = int.Parse(row[_monb + "預估個人負擔健保"].ToString()) + int.Parse(Row01["exp"].ToString());
                        row[_monb + "預估公司負擔健保"] = int.Parse(row[_monb + "預估公司負擔健保"].ToString()) + int.Parse(Row01["comp"].ToString());
                        row[_monb + "實際個人負擔健保"] = int.Parse(row[_monb + "實際個人負擔健保"].ToString()) + int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "實際公司負擔健保"] = int.Parse(row[_monb + "實際公司負擔健保"].ToString()) + int.Parse(Row01["i_comp"].ToString());
                        row[_monb + "差異個人負擔健保"] = int.Parse(row[_monb + "差異個人負擔健保"].ToString()) + int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "差異公司負擔健保"] = int.Parse(row[_monb + "差異公司負擔健保"].ToString()) + int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    else if (Row01["insur_name"].ToString() == "勞退")
                    {
                        row[_monb + "預估個人負擔勞退"] = int.Parse(row[_monb + "預估個人負擔勞退"].ToString()) + int.Parse(Row01["exp"].ToString());
                        row[_monb + "預估公司負擔勞退"] = int.Parse(row[_monb + "預估公司負擔勞退"].ToString()) + int.Parse(Row01["comp"].ToString());
                        row[_monb + "實際個人負擔勞退"] = int.Parse(row[_monb + "實際個人負擔勞退"].ToString()) + int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "實際公司負擔勞退"] = int.Parse(row[_monb + "實際公司負擔勞退"].ToString()) + int.Parse(Row01["i_comp"].ToString());
                        //row[_monb + "差異個人負擔勞退"] = int.Parse(row[_monb + "差異個人負擔勞退"].ToString()) + int.Parse(row[_monb + "預估個人負擔勞退"].ToString()) - int.Parse(row[_monb + "實際個人負擔勞退"].ToString());
                        //row[_monb + "差異公司負擔勞退"] = int.Parse(row[_monb + "差異公司負擔勞退"].ToString()) + int.Parse(row[_monb + "預估公司負擔勞退"].ToString()) - int.Parse(row[_monb + "實際公司負擔勞退"].ToString());
                        row[_monb + "差異個人負擔勞退"] = int.Parse(row[_monb + "差異個人負擔勞退"].ToString()) + int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        row[_monb + "差異公司負擔勞退"] = int.Parse(row[_monb + "差異公司負擔勞退"].ToString()) + int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    if (str_nobr != str_nobr1) row["人數"] = int.Parse(row["人數"].ToString()) + 1;
                }
                else
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["成本部門"] = Row01["depts"].ToString();
                    aRow["成本名稱"] = Row01["ds_name"].ToString();
                    aRow["直間接"] = Row01["di"].ToString();
                    aRow["人數"] = 1;
                    aRow[_monb + "預估個人負擔勞保"] = 0;
                    aRow[_monb + "預估個人負擔健保"] = 0;
                    aRow[_monb + "預估個人負擔勞退"] = 0;
                    aRow[_monb + "預估公司負擔勞保"] = 0;
                    aRow[_monb + "預估公司負擔健保"] = 0;
                    aRow[_monb + "預估公司負擔勞退"] = 0;
                    aRow[_monb + "實際個人負擔勞保"] = 0;
                    aRow[_monb + "實際個人負擔健保"] = 0;
                    aRow[_monb + "實際個人負擔勞退"] = 0;
                    aRow[_monb + "實際公司負擔勞保"] = 0;
                    aRow[_monb + "實際公司負擔健保"] = 0;
                    aRow[_monb + "實際公司負擔勞退"] = 0;
                    aRow[_monb + "差異個人負擔勞保"] = 0;
                    aRow[_monb + "差異個人負擔健保"] = 0;
                    aRow[_monb + "差異個人負擔勞退"] = 0;
                    aRow[_monb + "差異公司負擔勞保"] = 0;
                    aRow[_monb + "差異公司負擔健保"] = 0;
                    aRow[_monb + "差異公司負擔勞退"] = 0;
                    if (Row01["insur_name"].ToString() == "勞保")
                    {
                        aRow[_monb + "預估個人負擔勞保"] = int.Parse(Row01["exp"].ToString());
                        aRow[_monb + "預估公司負擔勞保"] = int.Parse(Row01["comp"].ToString());
                        aRow[_monb + "實際個人負擔勞保"] = int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "實際公司負擔勞保"] = int.Parse(Row01["i_comp"].ToString());
                        aRow[_monb + "差異個人負擔勞保"] = int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "差異公司負擔勞保"] = int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    else if (Row01["insur_name"].ToString() == "健保")
                    {
                        aRow[_monb + "預估個人負擔健保"] = int.Parse(Row01["exp"].ToString());
                        aRow[_monb + "預估公司負擔健保"] = int.Parse(Row01["comp"].ToString());
                        aRow[_monb + "實際個人負擔健保"] = int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "實際公司負擔健保"] = int.Parse(Row01["i_comp"].ToString());
                        aRow[_monb + "差異個人負擔健保"] = int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "差異公司負擔健保"] = int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    else if (Row01["insur_name"].ToString() == "勞退")
                    {
                        aRow[_monb + "預估個人負擔勞退"] = int.Parse(Row01["exp"].ToString());
                        aRow[_monb + "預估公司負擔勞退"] = int.Parse(Row01["comp"].ToString());
                        aRow[_monb + "實際個人負擔勞退"] = int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "實際公司負擔勞退"] = int.Parse(Row01["i_comp"].ToString());
                        aRow[_monb + "差異個人負擔勞退"] = int.Parse(Row01["exp"].ToString()) - int.Parse(Row01["i_exp"].ToString());
                        aRow[_monb + "差異公司負擔勞退"] = int.Parse(Row01["comp"].ToString()) - int.Parse(Row01["i_comp"].ToString());
                    }
                    ExporDt.Rows.Add(aRow);
                }
                str_nobr1 = Row01["nobr"].ToString();
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
