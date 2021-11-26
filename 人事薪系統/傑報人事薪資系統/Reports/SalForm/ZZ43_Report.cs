/* ======================================================================================================
 * 功能名稱：加班費用報表
 * 功能代號：ZZ43
 * 功能路徑：報表列印 > 薪資 > 加班費用報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ43_Report.cs
 * 功能用途：
 *  用於產出加班費用報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/24    Daniel Chih    Ver 1.0.01     1. 修改條件判斷規則，讓成本部門和編制部門在任何一種報表種類中都會作為篩選條件判斷
 * 2021/08/19    Daniel Chih    Ver 1.0.02     1. 修改加班條件篩選 ot_dept 改成 display code 作條件篩選
 * 2021/09/08    Daniel Chih    Ver 1.0.03     1. 修改成本部門欄位都顯示加班部門
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/09/08
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
    public partial class ZZ43_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, emp_b, emp_e, yymm_b, yymm_e, date_b, date_e, meno, reporttype, date_t, type_data, daop, username, workadr, comp_name, CompId;
        bool exportexcel, no_disp, pr_rest, ot_sum, ot_21, labchedk;
        string ErrorMessage = string.Empty;
        public ZZ43_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _deptsb, string _deptse, string _empb, string _empe, string _yymmb, string _yymme, string _dateb, string _datee, string datet, string _reporttype, string _daop, string _typedata, bool _exportexcel, bool nodisp, bool prrest, bool otsum, bool ot21, bool _labchedk, string _username, string _workadr, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; dept_b = _deptb; dept_e = _depte; depts_b = _deptsb; depts_e = _deptse;
            emp_b = _empb; emp_e = _empe; yymm_b = _yymmb; yymm_e = _yymme; date_b = _dateb; date_e = _datee;
            reporttype = _reporttype; type_data = _typedata; no_disp = nodisp; pr_rest = prrest; ot_sum = otsum;
            ot_21 = ot21; exportexcel = _exportexcel; date_t = datet; daop = _daop; username = _username;
            workadr = _workadr; comp_name = compname; CompId = _CompId; labchedk = _labchedk;
        }

        private void ZZ43_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.count_ma,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += ",d.d_no_disp as depts,d.d_name as ds_name,e.job_disp as job,e.job_name,b.comp";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_t);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);

                //if (reporttype!="2" && reporttype!="13")  //移除特定報表種類的判斷 - Modified By Daniel Chih - 2021/03/24
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);

                sqlCmd += type_data;
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                //加班

                //舊寫法：
                //string sqlCmd1 = "select a.*,right(datename(dw, a.bdate),1) as dw";
                //竟敢在SQL用*來Select，太狂了吧，這樣維護超麻煩的還要另外撈出來去對欄位，而且還沒撈ot_dname，只有撈ot_dept，我還不改一波~~
                //Modified By Daniel Chih - 2021/09/08
                string sqlCmd1 = " select a.NOBR, a.BDATE, a.BTIME, a.ETIME, a.TOT_HOURS, a.OT_HRS, a.REST_HRS, a.OT_CAR" +
                    ", a.OT_DEPT, a.OT_FOOD, a.NOTE, a.FOOD_PRI, a.FOOD_CNT, a.YYMM, a.SER" +
                    ", a.NOT_W_100, a.NOT_W_133, a.NOT_W_167, a.NOT_W_200" +
                    ", a.TOT_W_100, a.TOT_W_133, a.TOT_W_167, a.TOT_W_200" +
                    ", a.TOT_H_200" +
                    ", a.NOT_EXP, a.TOT_EXP, a.REST_EXP, a.FST_HOURS, a.SALARY, a.NOTMODI, a.OTRCD, a.NOFOOD, a.FIX_AMT, a.REC, a.CANT_ADJ" +
                    ", a.OT_EDATE, a.OTNO, a.OT_ROTE, a.OT_FOOD1, a.OT_FOODH, a.OT_FOODH1" +
                    ", a.NOP_W_100, a.NOP_W_133, a.NOP_W_167, a.NOP_W_200" +
                    ", a.NOP_H_100, a.NOP_H_133, a.NOP_H_167, a.NOP_H_200" +
                    ", a.TOP_W_100, a.TOP_W_133, a.TOP_W_167, a.TOP_W_200" +
                    ", a.TOP_H_200" +
                    ", a.NOT_H_133, a.NOT_H_167, a.NOT_H_200" +
                    ", a.HOT_133, a.HOT_166, a.HOT_200" +
                    ", a.WOT_133, a.WOT_166, a.WOT_200" +
                    ", a.[SUM], a.SYSCREAT, a.OTRATE_CODE, a.SYSCREAT1, a.SYS_OT, a.SERNO, a.DIFF, a.EAT, a.RES, a.NOFOOD1, a.ALL_HRS";
                sqlCmd1 += ", right(datename(dw, a.bdate),1) as dw, b.d_name as ot_dname";
                if (labchedk)
                    sqlCmd1 += " from ot_b a";
                else
                    sqlCmd1 += " from ot a";
                sqlCmd1 += string.Format(@" inner join depts b on a.ot_dept = b.d_no where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (daop=="1") sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (daop == "2") sqlCmd1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                if (ot_sum) sqlCmd1 += " and a.sum=1";
                if (ot_21)
                {
                    sqlCmd1 += " and a.syscreat1=1 and a.nobr+(convert(char,a.bdate,112)) in (select nobr+convert(char,bdate,112) ";
                    sqlCmd1 += string.Format(@" from abs where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    if (daop == "1") sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}')", yymm_b, yymm_e);
                    if (daop == "2") sqlCmd1 += string.Format(@" and bdate between '{0}' and '{1}')", date_b, date_e);
                }
                //if (reporttype == "2" || reporttype == "13")  //移除特定報表種類的判斷 - Modified By Daniel Chih - 2021/03/24
                sqlCmd1 += string.Format(@" and b.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);

                sqlCmd1 += " order by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(sqlCmd1);
                if (rq_ot.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_ot.Columns.Add("comp", typeof(string));
                rq_ot.Columns.Add("dept", typeof(string));
                rq_ot.Columns.Add("d_name", typeof(string));
                rq_ot.Columns.Add("d_ename", typeof(string));
                rq_ot.Columns.Add("name_c", typeof(string));
                rq_ot.Columns.Add("name_e", typeof(string));
                rq_ot.Columns.Add("rote", typeof(string));
                //rq_ot.Columns.Add("ot_dname", typeof(string));
                rq_ot.Columns.Add("job", typeof(string));
                rq_ot.Columns.Add("job_name", typeof(string));
                rq_ot.Columns.Add("count_ma", typeof(bool));

                DataTable rq_zz431 = new DataTable();
                rq_zz431 = ds.Tables["zz431"].Clone();
                foreach (DataRow Row in rq_ot.Rows)
                {
                    if (!pr_rest && decimal.Parse(Row["ot_hrs"].ToString()) == 0)
                        Row.Delete();
                    else
                    {
                        Row["dw"] = JBHR.Reports.ReportClass.GetDayWeek(DateTime.Parse(Row["bdate"].ToString()));
                        Row["dw"] = Row["dw"].ToString().Substring(2, 1);
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            if (decimal.Parse(Row["salary"].ToString()) != 0)
                                Row["salary"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["salary"].ToString()));
                            if (decimal.Parse(Row["not_exp"].ToString()) != 0)
                                Row["not_exp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["not_exp"].ToString()));
                            if (decimal.Parse(Row["tot_exp"].ToString()) != 0)
                                Row["tot_exp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["tot_exp"].ToString()));
                            if (decimal.Parse(Row["ot_food"].ToString()) != 0)
                                Row["ot_food"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["ot_food"].ToString()));
                            Row["comp"] = row["comp"].ToString();
                            if (reporttype == "0" || reporttype == "1" || reporttype == "3" || reporttype == "4" || reporttype == "5" || reporttype == "6" || reporttype == "7")
                            {
                                Row["dept"] = row["dept"].ToString();
                                Row["d_name"] = row["d_name"].ToString();
                                Row["d_ename"] = row["d_ename"].ToString();
                            }
                            else if (reporttype == "0")
                            {
                                string sqlCmd3 = "select d_no,d_name from depts ";
                                DataTable rq_depts = SqlConn.GetDataTable(sqlCmd3);
                                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"] };
                                DataRow otRow = rq_depts.Rows.Find(Row["ot_dept"].ToString());
                                if (otRow!=null)
                                    Row["ot_dname"] = otRow["d_name"].ToString();
                            }
                            else
                            {
                                Row["dept"] = row["depts"].ToString();
                                Row["d_name"] = row["ds_name"].ToString();
                                Row["d_ename"] = "";
                            }
                            Row["job"] = row["job"].ToString();
                            Row["name_c"] = row["name_c"].ToString();
                            Row["name_e"] = row["name_e"].ToString();
                            Row["job_name"] = row["job_name"].ToString();
                            Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                            if (reporttype == "0" || reporttype == "1" || reporttype == "3")
                            {
                                string sqlCmd2 = "select a.nobr,b.rote_disp as rote from attend a,rote b where a.rote=b.rote";
                                sqlCmd2 += string.Format(@" and a.nobr='{0}' and a.adate='{1}'", Row["nobr"].ToString(), DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd"));
                                DataTable rq_attend = SqlConn.GetDataTable(sqlCmd2);
                                if (rq_attend.Rows.Count > 0)
                                {
                                    Row["rote"] = rq_attend.Rows[0]["rote"].ToString();
                                    rq_attend.Clear();
                                }
                            }
                            if (no_disp)
                                Row["salary"] = 0;
                            ds.Tables["zz431"].ImportRow(Row);
                        }
                    }
                }
                //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz431"], "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                
                if (ds.Tables["zz431"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                switch (reporttype)
                {
                    case "0":
                        break;
                    case "1":                        
                        DataColumn[] _key = new DataColumn[3];
                        _key[0] = ds.Tables["zz432"].Columns["comp"];
                        _key[1] = ds.Tables["zz432"].Columns["dept"];
                        _key[2] = ds.Tables["zz432"].Columns["nobr"];
                        ds.Tables["zz432"].PrimaryKey = _key;
                        DataRow[] Row432 = ds.Tables["zz431"].Select("", "comp,dept,nobr asc");
                        foreach (DataRow Row1 in Row432)
                        {
                            object[] _value = new object[3];
                            _value[0] = Row1["comp"].ToString();
                            _value[1] = Row1["dept"].ToString();
                            _value[2] = Row1["nobr"].ToString();
                            DataRow row = ds.Tables["zz432"].Rows.Find(_value);
                            if (row != null)
                            {
                                row["ot_hrs"] =decimal.Parse(row["ot_hrs"].ToString())+ decimal.Parse(Row1["ot_hrs"].ToString());
                                row["not_exp"] = int.Parse(row["not_exp"].ToString()) + int.Parse(Row1["not_exp"].ToString());
                                row["tot_exp"] =int.Parse(row["tot_exp"].ToString())+ int.Parse(Row1["tot_exp"].ToString());
                                row["ot_food"] =int.Parse(row["ot_food"].ToString())+ int.Parse(Row1["ot_food"].ToString());
                                row["ot_food1"] =decimal.Parse(row["ot_food1"].ToString())+ decimal.Parse(Row1["ot_food1"].ToString());
                                row["rest_hrs"] =decimal.Parse(row["rest_hrs"].ToString())+ decimal.Parse(Row1["rest_hrs"].ToString());
                                if (Row1["rote"].ToString().Trim()=="00")
                                    row["not_h_133"] = decimal.Parse(row["not_h_133"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                else
                                    row["not_w_133"] = decimal.Parse(row["not_w_133"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz432"].NewRow();
                                aRow["comp"] = Row1["comp"].ToString();
                                aRow["dept"] = Row1["dept"].ToString();
                                aRow["d_name"] = Row1["d_name"].ToString();
                                aRow["d_ename"] = Row1["d_ename"].ToString();
                                aRow["nobr"] = Row1["nobr"].ToString();
                                aRow["name_c"] = Row1["name_c"].ToString();
                                aRow["name_e"] = Row1["name_e"].ToString();
                                aRow["ot_hrs"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                aRow["not_exp"] = int.Parse(Row1["not_exp"].ToString());
                                aRow["tot_exp"] = int.Parse(Row1["tot_exp"].ToString());
                                aRow["ot_food"] = int.Parse(Row1["ot_food"].ToString());
                                aRow["ot_food1"] = decimal.Parse(Row1["ot_food1"].ToString());
                                aRow["rest_hrs"] = decimal.Parse(Row1["rest_hrs"].ToString());
                                if (Row1["rote"].ToString().Trim() == "00")
                                {
                                    aRow["not_h_133"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                    aRow["not_w_133"] = 0;
                                }
                                else
                                {
                                    aRow["not_w_133"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                    aRow["not_h_133"] = 0;
                                }
                                ds.Tables["zz432"].Rows.Add(aRow);
                            }                            
                        }
                        ds.Tables.Remove("zz431");
                        break;                    
                    case "3":
                        DataColumn[] _key1 = new DataColumn[2];
                        _key1[0] = ds.Tables["zz433"].Columns["comp"];
                        _key1[1] = ds.Tables["zz433"].Columns["dept"];
                        ds.Tables["zz433"].PrimaryKey = _key1;
                        DataRow[] Row433 = ds.Tables["zz431"].Select("", "comp,dept asc");
                        foreach (DataRow Row1 in Row433)
                        {
                            object[] _value = new object[2];
                            _value[0] = Row1["comp"].ToString();
                            _value[1] = Row1["dept"].ToString();                            
                            DataRow row = ds.Tables["zz433"].Rows.Find(_value);
                            if (row != null)
                            {
                                row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                row["not_exp"] = int.Parse(row["not_exp"].ToString()) + int.Parse(Row1["not_exp"].ToString());
                                row["tot_exp"] = int.Parse(row["tot_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                                row["ot_food"] = int.Parse(row["ot_food"].ToString()) + int.Parse(Row1["ot_food"].ToString());
                                row["ot_food1"] = decimal.Parse(row["ot_food1"].ToString()) + decimal.Parse(Row1["ot_food1"].ToString());
                                row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row1["rest_hrs"].ToString());
                                if (Row1["rote"].ToString().Trim() == "00")
                                    row["noth"] = decimal.Parse(row["noth"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                else
                                    row["notw"] = decimal.Parse(row["notw"].ToString())  + decimal.Parse(Row1["ot_hrs"].ToString());
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz433"].NewRow();
                                aRow["comp"] = Row1["comp"].ToString();
                                aRow["dept"] = Row1["dept"].ToString();
                                aRow["d_name"] = Row1["d_name"].ToString();
                                aRow["d_ename"] = Row1["d_ename"].ToString();
                                aRow["ot_dept"] = Row1["ot_dept"].ToString();
                                aRow["ot_dname"] = Row1["ot_dname"].ToString();
                                aRow["ot_hrs"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                aRow["not_exp"] = int.Parse(Row1["not_exp"].ToString());
                                aRow["tot_exp"] = int.Parse(Row1["tot_exp"].ToString());
                                aRow["ot_food"] = int.Parse(Row1["ot_food"].ToString());
                                aRow["ot_food1"] = decimal.Parse(Row1["ot_food1"].ToString());
                                aRow["rest_hrs"] = decimal.Parse(Row1["rest_hrs"].ToString());
                                if (Row1["rote"].ToString().Trim() == "00")
                                {
                                    aRow["noth"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                    aRow["notw"] = 0;
                                }
                                else
                                {
                                    aRow["noth"] = 0;
                                    aRow["notw"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                }
                                ds.Tables["zz433"].Rows.Add(aRow);
                            }
                        }
                        ds.Tables.Remove("zz431");
                        break;

                    case "4":
                    case "5": 
                        DataColumn[] _key2 = new DataColumn[3];
                        _key2[0] = ds.Tables["zz434"].Columns["comp"];
                        _key2[1] = ds.Tables["zz434"].Columns["dept"];
                        _key2[2] = ds.Tables["zz434"].Columns["nobr"];
                        ds.Tables["zz434"].PrimaryKey = _key2;
                        DataRow[] Row434 = ds.Tables["zz431"].Select("", "comp,dept,nobr asc");
                        foreach (DataRow Row1 in Row434)
                        {
                            object[] _value = new object[3];
                            _value[0] = Row1["comp"].ToString();
                            _value[1] = Row1["dept"].ToString();
                            _value[2] = Row1["nobr"].ToString();
                            DataRow row = ds.Tables["zz434"].Rows.Find(_value);
                            if (row != null)
                            {
                                row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                row["not_w_133"] = decimal.Parse(row["not_w_133"].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                                row["not_w_167"] = decimal.Parse(row["not_w_167"].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                                row["not_w_200"] = decimal.Parse(row["not_w_200"].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                                row["not_h_133"] = decimal.Parse(row["not_h_133"].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                                row["not_h_167"] = decimal.Parse(row["not_h_167"].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                                row["not_h_200"] = decimal.Parse(row["not_h_200"].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                                row["tot_w_133"] = decimal.Parse(row["tot_w_133"].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                                row["tot_w_167"] = decimal.Parse(row["tot_w_167"].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                                row["tot_w_200"] = decimal.Parse(row["tot_w_200"].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz434"].NewRow();
                                aRow["comp"] = Row1["comp"].ToString();
                                aRow["dept"] = Row1["dept"].ToString();
                                aRow["d_name"] = Row1["d_name"].ToString();
                                aRow["d_ename"] = Row1["d_ename"].ToString();
                                aRow["nobr"] = Row1["nobr"].ToString();
                                aRow["name_c"] = Row1["name_c"].ToString();
                                aRow["name_e"] = Row1["name_e"].ToString();
                                aRow["yymm"] = Row1["yymm"].ToString();
                                aRow["ot_dept"] = Row1["ot_dept"].ToString();
                                aRow["ot_dname"] = Row1["ot_dname"].ToString();
                                aRow["ot_hrs"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                aRow["not_w_133"] = decimal.Parse(Row1["not_w_133"].ToString());
                                aRow["not_w_167"] = decimal.Parse(Row1["not_w_167"].ToString());
                                aRow["not_w_200"] = decimal.Parse(Row1["not_w_200"].ToString());
                                aRow["not_h_133"] = decimal.Parse(Row1["not_h_133"].ToString());
                                aRow["not_h_167"] = decimal.Parse(Row1["not_h_167"].ToString());
                                aRow["not_h_200"] = decimal.Parse(Row1["not_h_200"].ToString());
                                aRow["tot_w_133"] = decimal.Parse(Row1["tot_w_133"].ToString());
                                aRow["tot_w_167"] = decimal.Parse(Row1["tot_w_167"].ToString());
                                aRow["tot_w_200"] = decimal.Parse(Row1["tot_w_200"].ToString());
                                ds.Tables["zz434"].Rows.Add(aRow);
                            }
                        }
                        ds.Tables.Remove("zz431");
                        break;                
                    case "6":
                        ds.Tables["zz436"].PrimaryKey = new DataColumn[] { ds.Tables["zz436"].Columns["dept"],ds.Tables["zz436"].Columns["yymm"] };
                        DataRow[] Row436 = ds.Tables["zz431"].Select("", "dept,yymm asc");
                        foreach (DataRow Row1 in Row436)
                        {
                            object[] _value = new object[2];
                            _value[0] = Row1["dept"].ToString();
                            _value[1] = Row1["yymm"].ToString();
                            DataRow row = ds.Tables["zz436"].Rows.Find(_value);
                            if (row != null)
                            {
                                row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                row["not_w_133"] = decimal.Parse(row["not_w_133"].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                                row["not_w_167"] = decimal.Parse(row["not_w_167"].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                                row["not_w_200"] = decimal.Parse(row["not_w_200"].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                                row["not_h_133"] = decimal.Parse(row["not_h_133"].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                                row["not_h_167"] = decimal.Parse(row["not_h_167"].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                                row["not_h_200"] = decimal.Parse(row["not_h_200"].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                                row["tot_w_133"] = decimal.Parse(row["tot_w_133"].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                                row["tot_w_167"] = decimal.Parse(row["tot_w_167"].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                                row["tot_w_200"] = decimal.Parse(row["tot_w_200"].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                                row["exp"] = int.Parse(row["exp"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz436"].NewRow();                               
                                aRow["dept"] = Row1["dept"].ToString();
                                aRow["d_name"] = Row1["d_name"].ToString();
                                aRow["d_ename"] = Row1["d_ename"].ToString();
                                aRow["yymm"] = Row1["yymm"].ToString();                               
                                aRow["ot_hrs"] = decimal.Parse(Row1["ot_hrs"].ToString());
                                aRow["not_w_133"] = decimal.Parse(Row1["not_w_133"].ToString());
                                aRow["not_w_167"] = decimal.Parse(Row1["not_w_167"].ToString());
                                aRow["not_w_200"] = decimal.Parse(Row1["not_w_200"].ToString());
                                aRow["not_h_133"] = decimal.Parse(Row1["not_h_133"].ToString());
                                aRow["not_h_167"] = decimal.Parse(Row1["not_h_167"].ToString());
                                aRow["not_h_200"] = decimal.Parse(Row1["not_h_200"].ToString());
                                aRow["tot_w_133"] = decimal.Parse(Row1["tot_w_133"].ToString());
                                aRow["tot_w_167"] = decimal.Parse(Row1["tot_w_167"].ToString());
                                aRow["tot_w_200"] = decimal.Parse(Row1["tot_w_200"].ToString());
                                aRow["exp"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                                ds.Tables["zz436"].Rows.Add(aRow);
                            }
                        }
                        ds.Tables.Remove("zz431");
                        break;
                    case "7":                        
                        ds.Tables["zz437"].PrimaryKey = new DataColumn[] { ds.Tables["zz437"].Columns["dept"]};
                        DataRow[] Row437 = ds.Tables["zz431"].Select("", "dept asc");
                        foreach (DataRow Row1 in Row437)
                        {
                            decimal dhours = 0;
                            int dexp = 0;
                            DataRow row = ds.Tables["zz437"].Rows.Find(Row1["dept"].ToString());                            
                            DataRow [] row1 = ds.Tables["zz431"].Select("dept='" + Row1["dept"].ToString() + "' and bdate='" + date_e + "'");

                            for (int i = 0; i < row1.Length; i++)
                            {
                                dhours = dhours  + decimal.Parse(row1[i]["ot_hrs"].ToString());
                                dexp = dexp +  int.Parse(row1[i]["not_exp"].ToString()) + int.Parse(row1[i]["tot_exp"].ToString());
                            }
                            if (row != null)
                            {
                                row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());                                
                                row["exp"] = int.Parse(row["exp"].ToString()) + int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                                //row["dot_hrs"] = decimal.Parse(row["dot_hrs"].ToString()) + dhours;
                                //row["dexp"] = decimal.Parse(row["dexp"].ToString()) + dexp;
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz437"].NewRow();
                                aRow["dept"] = Row1["dept"].ToString();
                                aRow["d_name"] = Row1["d_name"].ToString();
                                aRow["d_ename"] = Row1["d_ename"].ToString();
                                aRow["ot_hrs"] = decimal.Parse(Row1["ot_hrs"].ToString());                                
                                aRow["exp"] = int.Parse(Row1["not_exp"].ToString()) + int.Parse(Row1["tot_exp"].ToString());
                                aRow["dot_hrs"] = dhours;
                                aRow["dexp"] = dexp;
                                ds.Tables["zz437"].Rows.Add(aRow);
                            }
                        }
                        ds.Tables.Remove("zz431");
                        break;
                    case "8":
                    case "11":
                    case "12":
                        //JBHR.Reports.SalForm.ZZ43Class.GetDataZZ438(ds.Tables["zz438"], ds.Tables["zz431"], reporttype);
                        JBHR.Reports.SalForm.ZZ43Class.GetDataZZ438(ds.Tables["zz438"], ds.Tables["zz438t"], ds.Tables["zz431"], reporttype); 
                        ds.Tables.Remove("zz431");
                        break;  
                    case "9":
                    case "10":
                        JBHR.Reports.SalForm.ZZ43Class.GetDataZZ439(ds.Tables["zz439"], ds.Tables["zz439t"], ds.Tables["zz431"],reporttype);
                        ds.Tables.Remove("zz431");
                        break;
                    case "13":                        
                        if (daop == "1")
                            date_e = DateTime.Parse(Convert.ToString(int.Parse(yymm_e.Substring(0, 4))) + "/" + yymm_e.Substring(4, 2) + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                        //抓取勞健保勞退
                        string sqlCmd3 = "select a.nobr,a.yymm,a.comp,c.d_no_disp as depts,c.d_name from explab a,basetts b";
                        sqlCmd3 += " left outer join depts c on b.depts=c.d_no";                        
                        sqlCmd3 += string.Format(@" where a.fa_idno='' and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                        sqlCmd3 += string.Format(@" and a.nobr =b.nobr and '{0}' between b.adate and b.ddate", date_e);                        
                        sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);                        
                        sqlCmd3 += workadr;
                        DataTable rq_explab = SqlConn.GetDataTable(sqlCmd3);
                        foreach (DataRow Row in rq_explab.Rows)
                        {
                            Row["comp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["comp"].ToString()));
                        }
                        DataTable rq_welamt = new DataTable();
                        rq_welamt.Columns.Add("depts", typeof(string));
                        rq_welamt.Columns.Add("d_name", typeof(string));
                        rq_welamt.Columns.Add("comp", typeof(int));
                        rq_welamt.PrimaryKey = new DataColumn[] { rq_welamt.Columns["d_name"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetWelamt(rq_explab, rq_welamt);

                         string sqlCmd7 = "select b.nobr,c.d_no_disp as depts,c.d_name from base a, basetts b,depts c";
                        sqlCmd7 += string.Format(@" where '{0}' between b.adate and b.ddate", date_e);
                        sqlCmd7 += " and a.nobr=b.nobr and b.depts=c.d_no ";
                        sqlCmd7 += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd7 += type_data;
                        sqlCmd7 += workadr;
                        DataTable rq_basett1 = SqlConn.GetDataTable(sqlCmd7);
                        rq_basett1.PrimaryKey = new DataColumn[] { rq_basett1.Columns["nobr"] };

                        //發薪主檔資料
                        string sqlCmd4 = "select b.nobr from wage b";
                        sqlCmd4 += string.Format(@" where b.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                        sqlCmd4 += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd4 += " and b.seq='2' ";
                        sqlCmd4 += workadr;
                        DataTable rq_wage = SqlConn.GetDataTable(sqlCmd4);
                        rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };

                        //發薪明細資料
                        string sqlCmd5 = "select nobr,sal_code,amt from waged";
                        sqlCmd5 += string.Format(@" where yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                        sqlCmd5 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd5 += " and seq='2' and sal_code <>'D01'";
                        DataTable rq_waged = SqlConn.GetDataTable(sqlCmd5);
                        rq_waged.Columns.Add("salattr", typeof(string));
                        rq_waged.Columns.Add("depts", typeof(string));
                        rq_waged.Columns.Add("d_name", typeof(string));

                        //薪資屬性
                        string sqlCmd6 = "select a.sal_code,b.flag,b.salattr from salcode a,salattr b ";
                        sqlCmd6 += " where a.sal_attr=b.salattr";
                        DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd6);
                        rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                        foreach (DataRow Row in rq_waged.Rows)
                        {
                            DataRow row = rq_wage.Rows.Find(Row["nobr"].ToString());
                            DataRow row2 = rq_basett1.Rows.Find(Row["nobr"].ToString());
                            if (row == null || row2==null)
                                Row.Delete();
                            else
                            {
                                DataRow row1 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                                if (row1 != null)
                                {
                                    Row["salattr"] = row1["salattr"].ToString();
                                    if (row1["flag"].ToString().Trim() == "-")
                                        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                                    else
                                        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                                }
                                if (row2 != null)
                                {
                                    Row["depts"] = row2["depts"].ToString();
                                    Row["d_name"] = row2["d_name"].ToString();
                                }
                                if (decimal.Parse(Row["amt"].ToString()) == 0)
                                    Row.Delete();
                            }
                        }
                        rq_waged.AcceptChanges();

                        //發薪人數
                        DataTable rq_cnt = new DataTable();
                        rq_cnt.Columns.Add("depts", typeof(string));
                        rq_cnt.Columns.Add("d_name", typeof(string));
                        rq_cnt.Columns.Add("nobr", typeof(string));
                        rq_cnt.PrimaryKey = new DataColumn[] { rq_cnt.Columns["nobr"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetCnt(rq_waged, rq_cnt);
                        
                        //固定薪資
                        DataTable rq_fixamt = new DataTable();
                        rq_fixamt.Columns.Add("depts", typeof(string));
                        rq_fixamt.Columns.Add("d_name", typeof(string));
                        rq_fixamt.Columns.Add("amt", typeof(int));
                        rq_fixamt.PrimaryKey = new DataColumn[] { rq_fixamt.Columns["d_name"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetFixamt(rq_waged, rq_fixamt);
                        
                        //應發薪資料
                        string retsalcode = "";
                        DataTable rq_usys4 = SqlConn.GetDataTable("select * from u_sys4  where comp='" + CompId + "'");
                        if (rq_usys4.Rows.Count > 0) retsalcode = rq_usys4.Rows[0]["retsalcode"].ToString().Trim();
                        DataTable rq_allamt = new DataTable();
                        rq_allamt.Columns.Add("depts", typeof(string));
                        rq_allamt.Columns.Add("d_name", typeof(string));
                        rq_allamt.Columns.Add("amt", typeof(int));
                        rq_allamt.PrimaryKey = new DataColumn[] { rq_allamt.Columns["d_name"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetAllamt(rq_waged, rq_allamt,retsalcode);

                        //加班費
                        DataTable rq_otamt = new DataTable();                       
                        rq_otamt.Columns.Add("depts", typeof(string));
                        rq_otamt.Columns.Add("d_name", typeof(string));
                        rq_otamt.Columns.Add("ot_dept", typeof(string));
                        rq_otamt.Columns.Add("ot_dname", typeof(string));
                        rq_otamt.Columns.Add("tol_hrs", typeof(decimal));
                        rq_otamt.Columns.Add("ot_hrs", typeof(decimal));
                        rq_otamt.Columns.Add("ex_hrs", typeof(decimal));
                        rq_otamt.Columns.Add("otamt", typeof(int));
                        rq_otamt.Columns.Add("examt", typeof(int));
                        rq_otamt.Columns.Add("pn", typeof(string));
                        rq_otamt.PrimaryKey = new DataColumn[] { rq_otamt.Columns["d_name"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetOtamt(ds.Tables["zz431"], rq_otamt);
                        
                        ds.Tables["zz43e"].PrimaryKey = new DataColumn[] { ds.Tables["zz43e"].Columns["d_name"] };
                        JBHR.Reports.SalForm.ZZ43Class.GetZz43e(ds.Tables["zz43e"], rq_otamt, rq_cnt, rq_fixamt, rq_allamt, rq_welamt);

                        rq_allamt = null;
                        rq_basett1 = null;
                        rq_cnt = null;
                        rq_explab = null;
                        rq_fixamt = null;
                        rq_otamt = null;
                        rq_salcode = null;
                        rq_usys4 = null;
                        rq_wage = null;
                        rq_waged = null;
                        rq_welamt = null;
                        break;

                    default:
                        break;
                }
                rq_base = null;
                rq_ot = null;

                if (exportexcel)
                {
                    switch (reporttype)
                    {
                        case "0":
                            JBHR.Reports.SalForm.ZZ43Class.Export1(ds.Tables["zz431"], this.Name, pr_rest);
                            break;
                        case "1":
                            JBHR.Reports.SalForm.ZZ43Class.Export2(ds.Tables["zz432"], this.Name);
                            break;
                        case "2":
                            JBHR.Reports.SalForm.ZZ43Class.Export3(ds.Tables["zz431"], this.Name);
                            break;
                        case "3":
                            JBHR.Reports.SalForm.ZZ43Class.Export4(ds.Tables["zz433"], this.Name);
                            break;
                        case "4":
                            JBHR.Reports.SalForm.ZZ43Class.Export5(ds.Tables["zz434"], this.Name,reporttype);
                            break;
                        case "5":
                            JBHR.Reports.SalForm.ZZ43Class.Export5(ds.Tables["zz434"], this.Name,reporttype);
                            break;
                        case "6":
                            JBHR.Reports.SalForm.ZZ43Class.Export6(ds.Tables["zz436"], this.Name);
                            break;
                        case "7":
                            JBHR.Reports.SalForm.ZZ43Class.Export7(ds.Tables["zz437"], this.Name);
                            break;
                        case "8":
                        case "11":
                        case "12":
                            //JBHR.Reports.SalForm.ZZ43Class.Export8(ds.Tables["zz438"], this.Name,reporttype);
                            JBHR.Reports.SalForm.ZZ43Class.Export8(ds.Tables["zz438"], ds.Tables["zz438t"], this.Name, reporttype);
                            break;
                        case "9":
                        case "10":
                            JBHR.Reports.SalForm.ZZ43Class.Export9(ds.Tables["zz439"],ds.Tables["zz439t"], this.Name,reporttype);
                            break;
                        case "13":
                            JBHR.Reports.SalForm.ZZ43Class.Export13(ds.Tables["zz43e"], this.Name);
                            break;
                        default:
                            break;
                    }
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    switch (reporttype)
                    { 
                        case "0":
                            if (ot_sum)
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz431b.rdlc";
                            else
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz431a.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz431", ds.Tables["zz431"]));
                            break;
                        case "1":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz432.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz432", ds.Tables["zz432"]));
                            break;
                        case "2":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz433.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz431", ds.Tables["zz431"]));
                            break;
                        case "3":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz434.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz433", ds.Tables["zz433"]));
                            break;
                        case "4":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz435.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz434", ds.Tables["zz434"]));
                            break;
                        case "5":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz436.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz434", ds.Tables["zz434"]));
                            break;
                        case "6":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz437.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz436", ds.Tables["zz436"]));
                            break;
                        case "7":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz438.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz437", ds.Tables["zz437"]));
                            break;
                        case "8":
                        case "11":
                        case "12":
                            if (reporttype=="8")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz439.rdlc";
                            else if (reporttype == "11")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz439c.rdlc";
                            else if (reporttype == "12")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz439d.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz438t", ds.Tables["zz438t"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz438", ds.Tables["zz438"]));
                            break;
                        case "9":
                        case "10":
                            if (reporttype=="9")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz43a.rdlc";
                            else
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz43b.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz439", ds.Tables["zz439"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz439t", ds.Tables["zz439t"]));
                            break;   
                        case "13":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz43e.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz43e", ds.Tables["zz43e"]));
                            break;
                        default:
                            break;
                    }                    
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }
                
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message +  ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}

