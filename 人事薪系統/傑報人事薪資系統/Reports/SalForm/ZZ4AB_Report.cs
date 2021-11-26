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
    public partial class ZZ4AB_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, dept_type, nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, year_b, month_b, seq_b, date_b;
        string username, workadr, yymm_b, yymm_e, year_e, month_e, seq_e, radate, reporttype, CompId;
        bool exportexcel, excel_en, mangsuper;
        public ZZ4AB_Report(string typedata, string nobrb, string nobre, string deptb, string depte, string _yearb, string _yeare, string _monthb, string _monthe, string _seqb, string _seqe, string dateb, string report_type, string _username, string _workadr, bool _exportexcel, bool excelen, bool _mangsuper,string _CompId)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            year_b = _yearb; month_b = _monthb; seq_b = _seqb; date_b = dateb;
            username = _username; workadr = _workadr; exportexcel = _exportexcel; mangsuper = _mangsuper;
            yymm_b = year_b + month_b; year_e = _yeare; month_e = _monthe; seq_e = _seqe;
            excel_en = excelen; yymm_e = year_e + month_e; reporttype = report_type;
            CompId = _CompId;
        }

        private void ZZ4AB_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.di,b.comp,e.compname,b.adate,a.count_ma,e.account";
                sqlCmd += ",b.dept,c.d_name,b.depts,d.d_name as ds_name";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join comp e on b.comp=e.comp";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += type_data;
                if (!mangsuper) sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //勞退提撥公司負擔
                string sqlCmd0 = "select nobr,comp from explab";
                sqlCmd0 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd0 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b,yymm_e);
                sqlCmd0 += " and insur_type='4' and comp <> 10";
                DataTable rq_explab = SqlConn.GetDataTable(sqlCmd0);
                
                DataTable rq_ret = new DataTable();
                rq_ret.Columns.Add("dept", typeof(string));
                rq_ret.Columns.Add("depts", typeof(string));
                rq_ret.Columns.Add("comp", typeof(int));
                rq_ret.PrimaryKey = new DataColumn[] { rq_ret.Columns["dept"], rq_ret.Columns["depts"] };
                foreach (DataRow Row in rq_explab.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        object[] _value = new object[2];
                        _value[0] = row["dept"].ToString();
                        _value[1] = row["depts"].ToString();
                        DataRow row1 = rq_ret.Rows.Find(_value);
                        if (row1 != null)
                            row1["comp"] = int.Parse(row1["comp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                        else
                        {
                            DataRow aRow = rq_ret.NewRow();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["depts"] = row["depts"].ToString();
                            aRow["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                            rq_ret.Rows.Add(aRow);
                        }
                    }
                }

                //發薪主檔
                string sqlCmd1 = "select nobr,cash,adate,yymm,seq from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;
                

                //發薪明細檔
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd2 += " and sal_code!='R01' and sal_code<> ''";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("adate", typeof(DateTime));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("depts", typeof(string));
                rq_waged.Columns.Add("ds_name", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("cash", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("sal_namee", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("acc_tr", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("acccd", typeof(string));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("pno", typeof(int));

                //會計科目
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,b.flag,b.salattr,c.acc_tr,a.acccd,";
                //if (excel_en)
                //    sqlCmd3 += "c.accname_e as sal_name";
                //else
                //    sqlCmd3 += "c.accname as sal_name";
                if (excel_en)
                    sqlCmd3 += "a.sal_ename as sal_name";
                else
                    sqlCmd3 += "a.sal_name";
                sqlCmd3 += " from salcode a,salattr b,acccd c";
                sqlCmd3 += " where a.sal_attr=b.salattr and a.acccd=c.acccd";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();

                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null)
                    {
                        Row["cash"] = bool.Parse(row1["cash"].ToString());
                        Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["di"] = row["di"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["ds_name"].ToString();
                        Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString().Trim();
                            Row["flag"] = row2["flag"].ToString();
                            Row["acc_tr"] = row2["acc_tr"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["acccd"] = row2["acccd"].ToString();
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        //Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    }
                    else
                        Row.Delete();
                }
                rq_waged.AcceptChanges();

                //應稅薪資
                DataTable wageds1 = new DataTable();
                wageds1.Columns.Add("dept", typeof(string));
                wageds1.Columns.Add("depts", typeof(string));
                wageds1.Columns.Add("amt", typeof(int));
                wageds1.PrimaryKey = new DataColumn[] { wageds1.Columns["dept"], wageds1.Columns["depts"] };
                DataRow[] SRow = rq_waged.Select(" salattr < 'F'", "");
                foreach (DataRow Row in SRow)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["depts"].ToString();
                    DataRow row = wageds1.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = wageds1.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        wageds1.Rows.Add(aRow);
                    }
                }

                //應付薪資
                DataTable wageds2 = new DataTable();
                wageds2.Columns.Add("dept", typeof(string));
                wageds2.Columns.Add("depts", typeof(string));
                wageds2.Columns.Add("amt", typeof(int));
                wageds2.PrimaryKey = new DataColumn[] { wageds2.Columns["dept"], wageds2.Columns["depts"] };
                DataTable rq_usys4 = SqlConn.GetDataTable("select retirerate,retsalcode,nretirerate,retirerate1,lsalcode from u_sys4  where comp='" + CompId + "'");
                string retsalcode2 = "";
                if (rq_usys4.Rows.Count > 0)
                {
                    DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                    if (row1 != null)
                        retsalcode2 = row1["sal_code_disp"].ToString();
                }
                DataRow[] SRow1 = rq_waged.Select(" salattr < 'L' and sal_code <> '" + retsalcode2 + "'", "");
                foreach (DataRow Row in SRow1)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["depts"].ToString();
                    DataRow row = wageds2.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = wageds2.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        wageds2.Rows.Add(aRow);
                    }
                }

                //代扣合計
                DataTable wageds3 = new DataTable();
                wageds3.Columns.Add("dept", typeof(string));
                wageds3.Columns.Add("depts", typeof(string));
                wageds3.Columns.Add("amt", typeof(int));
                wageds3.PrimaryKey = new DataColumn[] { wageds3.Columns["dept"], wageds3.Columns["depts"] };
                DataRow[] SRow2 = rq_waged.Select(" salattr > 'L'", "");
                foreach (DataRow Row in SRow2)
                {
                    int _amt = 0;
                    if (Row["flag"].ToString().Trim() == "-")
                        _amt = int.Parse(Row["amt"].ToString()) * (-1);
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["depts"].ToString();
                    DataRow row = wageds3.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + _amt;
                    else
                    {
                        DataRow aRow = wageds3.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["amt"] = _amt;
                        wageds3.Rows.Add(aRow);
                    }
                }

                //產生橫向表頭
                DataTable rq_zz4ata = new DataTable();
                rq_zz4ata.Columns.Add("salattr", typeof(string));
                rq_zz4ata.Columns.Add("sal_name", typeof(string));
                rq_zz4ata.PrimaryKey = new DataColumn[] { rq_zz4ata.Columns["salattr"] };

                DataTable rq_zz4at = new DataTable();
                rq_zz4at.Columns.Add("salattr", typeof(string));
                rq_zz4at.Columns.Add("sal_name", typeof(string));
                rq_zz4at.PrimaryKey = new DataColumn[] { rq_zz4at.Columns["salattr"] };

                //實發薪資
                DataTable wagedsz = new DataTable();
                wagedsz.Columns.Add("dept", typeof(string));
                wagedsz.Columns.Add("depts", typeof(string));
                wagedsz.Columns.Add("amt", typeof(int));
                wagedsz.PrimaryKey = new DataColumn[] { wagedsz.Columns["dept"], wagedsz.Columns["depts"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["depts"].ToString();
                    DataRow row = wagedsz.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = wagedsz.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        wagedsz.Rows.Add(aRow);
                    }
                    

                    string str_salattr = Row["salattr"].ToString().Trim() + Row["sal_code"].ToString().Trim();
                    DataRow row1 = rq_zz4ata.Rows.Find(str_salattr);
                    if (row1 == null)
                    {
                        DataRow aRow = rq_zz4ata.NewRow();
                        aRow["salattr"] = str_salattr;
                        aRow["sal_name"] = Row["sal_name"].ToString().Trim();
                        rq_zz4ata.Rows.Add(aRow);
                    }
                }

                DataRow aRow1 = rq_zz4ata.NewRow();
                aRow1["salattr"] = "FZZZZ";
                aRow1["sal_name"] = (excel_en) ? "Dutiable Salary" : "應稅薪資";
                rq_zz4ata.Rows.Add(aRow1);

                DataRow aRow2 = rq_zz4ata.NewRow();
                aRow2["salattr"] = "LZZZZ";
                aRow2["sal_name"] = (excel_en) ? "Total Payable" : "應發薪資";
                rq_zz4ata.Rows.Add(aRow2);

                DataRow aRow3 = rq_zz4ata.NewRow();
                aRow3["salattr"] = "RZZZZ";
                aRow3["sal_name"] = (excel_en) ? "Total Withholding" : "代扣合計";
                rq_zz4ata.Rows.Add(aRow3);

                DataRow aRow5 = rq_zz4ata.NewRow();
                aRow5["salattr"] = "ZZZZ";
                aRow5["sal_name"] = (excel_en) ? "Actual Payment" : "實發金額";
                rq_zz4ata.Rows.Add(aRow5);

                DataRow[] Orow = rq_zz4ata.Select("", "salattr asc");
                foreach (DataRow Row1 in Orow)
                {
                    DataRow aRow6 = rq_zz4at.NewRow();
                    aRow6["salattr"] = Row1["salattr"].ToString();
                    aRow6["sal_name"] = Row1["sal_name"].ToString().Trim();
                    rq_zz4at.Rows.Add(aRow6);
                }

                DataRow aRow7 = ds.Tables["zz4abta"].NewRow();
                for (int i = 0; i < rq_zz4at.Rows.Count; i++)
                {
                    aRow7["Fld" + (i + 1)] = rq_zz4at.Rows[i]["sal_name"].ToString();
                }
                ds.Tables["zz4abta"].Rows.Add(aRow7);
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_waged, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");

                ds.Tables["zz4abtd"].PrimaryKey = new DataColumn[] { ds.Tables["zz4abtd"].Columns["dept"], ds.Tables["zz4abtd"].Columns["depts"] };
                DataRow[] SRow4 = rq_waged.Select("", "dept,depts,nobr asc");
                string _strnobr1 = "";
                foreach (DataRow Row in SRow4)
                {
                    if (Row["flag"].ToString().Trim() == "-")
                        Row["amt"] = int.Parse(Row["amt"].ToString()) * (-1);

                    string _strnobr = Row["nobr"].ToString();
                    object[] _value = new object[2];
                    _value[0] = Row["dept"];
                    _value[1] = Row["depts"];
                    DataRow row = ds.Tables["zz4abtd"].Rows.Find(_value);
                    if (row != null)
                    {
                        for (int i = 0; i < rq_zz4at.Rows.Count; i++)
                        {
                            if (rq_zz4at.Rows[i]["sal_name"].ToString().Trim() == Row["sal_name"].ToString().Trim())
                            {
                                row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());
                                break;
                            }
                        }
                        if (_strnobr != _strnobr1)
                            row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz4abtd"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["ds_name"] = Row["ds_name"].ToString();
                        DataRow row1 = wageds1.Rows.Find(_value);
                        DataRow row2 = wageds2.Rows.Find(_value);
                        DataRow row3 = wageds3.Rows.Find(_value);
                        DataRow row4 = wagedsz.Rows.Find(_value);
                        DataRow row5 = rq_ret.Rows.Find(_value);
                        for (int i = 0; i < rq_zz4at.Rows.Count; i++)
                        {
                            aRow["Fld" + (i + 1)] = 0;
                            if (rq_zz4at.Rows[i]["salattr"].ToString().Trim() == "FZZZZ")
                                aRow["Fld" + (i + 1)] = (row1 != null) ? int.Parse(row1["amt"].ToString()) : 0;
                            if (rq_zz4at.Rows[i]["salattr"].ToString().Trim() == "LZZZZ")
                                aRow["Fld" + (i + 1)] = (row2 != null) ? int.Parse(row2["amt"].ToString()) : 0;
                            if (rq_zz4at.Rows[i]["salattr"].ToString().Trim() == "RZZZZ")
                                aRow["Fld" + (i + 1)] = (row3 != null) ? int.Parse(row3["amt"].ToString()) : 0;
                            if (rq_zz4at.Rows[i]["salattr"].ToString().Trim() == "ZZZZ")
                                aRow["Fld" + (i + 1)] = (row4 != null) ? int.Parse(row4["amt"].ToString()) : 0;
                            if (rq_zz4at.Rows[i]["sal_name"].ToString().Trim() == Row["sal_name"].ToString().Trim())
                                aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                        }
                        if (row5 != null) aRow["compexp"] = int.Parse(row5["comp"].ToString());
                        aRow["cnt"] = 1;
                        ds.Tables["zz4abtd"].Rows.Add(aRow);
                    }
                    _strnobr1 = Row["nobr"].ToString();
                }
                if (ds.Tables["zz4abtd"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (reporttype == "1")
                {
                    ds.Tables["zz4abtd1"].PrimaryKey = new DataColumn[] { ds.Tables["zz4abtd1"].Columns["depts"] };
                    DataRow[] SRow5 = ds.Tables["zz4abtd"].Select("", "depts asc");
                    foreach (DataRow Row in SRow5)
                    {
                        DataRow row = ds.Tables["zz4abtd1"].Rows.Find(Row["depts"].ToString());
                        if (row != null)
                        {
                            row["cnt"] = int.Parse(row["cnt"].ToString()) + int.Parse(Row["cnt"].ToString());
                            if (!Row.IsNull("compexp")) row["compexp"] = int.Parse(row["compexp"].ToString()) + int.Parse(Row["compexp"].ToString());
                            for (int i = 0; i < rq_zz4at.Rows.Count; i++)
                            {
                                row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());                                
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz4abtd1"].NewRow();
                            aRow["depts"] = Row["depts"].ToString();
                            aRow["ds_name"] = Row["ds_name"].ToString();
                            aRow["compexp"] = (Row.IsNull("compexp")) ? 0 : int.Parse(Row["compexp"].ToString());
                            aRow["cnt"] = int.Parse(Row["cnt"].ToString());
                            for (int i = 0; i < rq_zz4at.Rows.Count; i++)
                            {
                                aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                            }
                            ds.Tables["zz4abtd1"].Rows.Add(aRow);
                        }
                    }
                    ds.Tables.Remove("zz4abtd");
                }
                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz4abtd"], ds.Tables["zz4abta"]);
                    else
                        Export1(ds.Tables["zz4abtd1"], ds.Tables["zz4abta"]);
                    this.Close();
                }
                else
                {
                    string company = ""; string JBVersion = "";
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        JBVersion += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4ab.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4ab1.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY_B", year_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY_E", year_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM_B", month_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM_E", month_e) });
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4abta", ds.Tables["zz4abta"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4abtd", ds.Tables["zz4abtd"]));
                    }
                    else
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4abta", ds.Tables["zz4abta"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4abtd1", ds.Tables["zz4abtd1"]));
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

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代號", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("成本代碼", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("勞退提撥公司", typeof(string));            

            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }
            //DataRow[] OrderRow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代號"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["成本代碼"] = Row01["depts"].ToString();
                aRow["成本名稱"] = Row01["ds_name"].ToString();
                aRow["勞退提撥公司"] = Row01["compexp"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row01["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            DataSet Rds = new DataSet();
            Rds.Tables.Add(ExporDt);          
            
            //JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            JBModule.Data.CNPOI.SaveDataSetToExcel(Rds, "C:\\TEMP\\" + this.Name + ".xls", true);
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        void Export1(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();           
            ExporDt.Columns.Add("成本代碼", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("勞退提撥公司", typeof(string));

            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }
            //DataRow[] OrderRow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();                
                aRow["成本代碼"] = Row01["depts"].ToString();
                aRow["成本名稱"] = Row01["ds_name"].ToString();
                aRow["勞退提撥公司"] = Row01["compexp"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row01["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            
            //JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            DataSet Rds = new DataSet();
            Rds.Tables.Add(ExporDt);
            JBModule.Data.CNPOI.SaveDataSetToExcel(Rds, "C:\\TEMP\\" + this.Name + ".xls", true);
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
