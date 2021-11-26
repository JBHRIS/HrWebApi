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
    public partial class ZZ25A_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, depts_b, depts_e, date_b, date_e, username, type_data;
        bool exportexcel;
        public ZZ25A_Report(string nobrb, string nobre, string deptsb, string deptse, string dateb, string datee, string _username, string typedata, bool _exportexcel)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb; depts_e = deptse;
            date_b = dateb; date_e = datee; depts_e = deptse; username = _username;
            type_data = typedata; exportexcel = _exportexcel;
        }

        private void ZZ25A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,d.jobl,d.job_name,c.d_no_disp as depts,c.d_name,b.indt,b.cindt ";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join depts c on b.depts=c.d_no";
                sqlCmd += " left outer join jobl d on  b.jobl=d.jobl";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);               
                sqlCmd += " and b.ttscode in ('1','4','6')";
                sqlCmd += type_data;
                sqlCmd += " order by b.indt,b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //基本薪資
                string sqlCmd1 = "select nobr,amt from salbasd  ";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and '{0}' between adate and ddate", date_e);
                sqlCmd1 += " and amt!=10 ";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                DataTable rq_sal = new DataTable();
                rq_sal.Columns.Add("nobr", typeof(string));
                rq_sal.Columns.Add("amt", typeof(int));
                rq_sal.PrimaryKey = new DataColumn[] { rq_sal.Columns["nobr"] };
                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    DataRow row = rq_sal.Rows.Find(Row["nobr"].ToString());
                    if (row != null) row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    else
                    {
                        DataRow aRow = rq_sal.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        rq_sal.Rows.Add(aRow);
                    }
                }

                //請假得假資料
                string sqlCmd2 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,a.tol_hours,b.unit,";
                sqlCmd2 += "b.year_rest,DATENAME(month,bdate) as mon,month(bdate) as m";
                sqlCmd2 += " from abs a,hcode b where a.h_code=b.h_code";
                sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd2 += " and b.year_rest in('1','2')";
                sqlCmd2 += " order by a.nobr,a.bdate";
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd2);

                DataTable rq_absnobr = new DataTable();
                rq_absnobr.Columns.Add("nobr", typeof(string));
                rq_absnobr.Columns.Add("mon", typeof(string));
                rq_absnobr.Columns.Add("tol_hours", typeof(decimal));
                rq_absnobr.Columns.Add("get_hrs", typeof(decimal));
                rq_absnobr.PrimaryKey = new DataColumn[] { rq_absnobr.Columns["nobr"], rq_absnobr.Columns["mon"] };

                DataTable rq_mon = new DataTable();
                rq_mon.Columns.Add("mon", typeof(string));
                rq_mon.PrimaryKey = new DataColumn[] { rq_mon.Columns["mon"] };
                DataRow[] MRow = rq_abs.Select("", "m asc");
                foreach (DataRow Row in MRow)
                {                    
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["mon"].ToString();
                    DataRow row = rq_absnobr.Rows.Find(_value);
                    if (row != null)
                    {
                        if (Row["year_rest"].ToString().Trim() == "1") 
                            row["get_hrs"] = decimal.Parse(row["get_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                        else if (Row["year_rest"].ToString().Trim() == "2") 
                            row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_absnobr.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["mon"] = Row["mon"].ToString();
                        aRow["get_hrs"] = 0;
                        aRow["tol_hours"] = 0;
                        if (Row["year_rest"].ToString().Trim() == "1")
                            aRow["get_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                        else if (Row["year_rest"].ToString().Trim() == "2")
                            aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        rq_absnobr.Rows.Add(aRow);
                    }

                    DataRow row1 = rq_mon.Rows.Find(Row["mon"].ToString());
                    if (row1 == null)
                    {
                        DataRow aRow1 = rq_mon.NewRow();
                        aRow1["mon"] = Row["mon"].ToString();
                        rq_mon.Rows.Add(aRow1);
                    }
                }
               
                DataTable rq_zz25a = new DataTable();
                rq_zz25a.Columns.Add("empno", typeof(string));
                rq_zz25a.Columns.Add("name", typeof(string));
                rq_zz25a.Columns.Add("eng_name_e", typeof(string));
                rq_zz25a.Columns.Add("hire_date", typeof(DateTime));
                rq_zz25a.Columns.Add("Dept", typeof(string));
                rq_zz25a.Columns.Add("Basic Salary", typeof(int));
                rq_zz25a.Columns.Add("Remaining", typeof(decimal));
                rq_zz25a.Columns.Add("Grant Vacation", typeof(decimal));
                foreach (DataRow Row in rq_mon.Rows)
                {
                    switch (Row["mon"].ToString())
                    {
                        case "一月":
                            rq_zz25a.Columns.Add("January Taken", typeof(decimal));
                            break;
                        case "二月":
                            rq_zz25a.Columns.Add("February Taken", typeof(decimal));
                            break;
                        case "三月":
                            rq_zz25a.Columns.Add("March Taken", typeof(decimal));
                            break;
                        case "四月":
                            rq_zz25a.Columns.Add("April Taken", typeof(decimal));
                            break;
                        case "五月":
                            rq_zz25a.Columns.Add("May Taken", typeof(decimal));
                            break;
                        case "六月":
                            rq_zz25a.Columns.Add("June Taken", typeof(decimal));
                            break;
                        case "七月":
                            rq_zz25a.Columns.Add("July Taken", typeof(decimal));
                            break;
                        case "八月":
                            rq_zz25a.Columns.Add("August Taken", typeof(decimal));
                            break;
                        case "九月":
                            rq_zz25a.Columns.Add("September Taken", typeof(decimal));
                            break;
                        case "十月":
                            rq_zz25a.Columns.Add("October Taken", typeof(decimal));
                            break;
                        case "十一月":
                            rq_zz25a.Columns.Add("November Taken", typeof(decimal));
                            break;
                        case "十二月":
                            rq_zz25a.Columns.Add("December Taken", typeof(decimal));
                            break;
                        default:
                            break;
                    }
                }
                foreach (DataRow Row in rq_base.Rows)
                {
                    DataRow row = rq_sal.Rows.Find(Row["nobr"].ToString());
                    DataRow [] row1 = rq_absnobr.Select("nobr='" + Row["nobr"].ToString() + "'");
                    DataRow aRow = rq_zz25a.NewRow();
                    aRow["empno"] = Row["nobr"].ToString();
                    aRow["name"] = Row["name_c"].ToString();
                    aRow["eng_name_e"] = Row["name_e"].ToString();
                    aRow["hire_date"] = DateTime.Parse(Row["indt"].ToString());
                    aRow["Dept"] = Row["depts"].ToString();
                    aRow["Basic Salary"] = (row != null) ? int.Parse(row["amt"].ToString()) : 0;
                    aRow["Remaining"] = 0;
                    aRow["Grant Vacation"] =  0;
                    for (int i = 0; i < row1.Length; i++)
                    {
                        if (decimal.Parse(row1[0]["get_hrs"].ToString()) > 0) aRow["Grant Vacation"] = decimal.Parse(row1[0]["get_hrs"].ToString());
                        switch (row1[i]["mon"].ToString())
                        {
                            case "一月":
                                aRow["January Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "二月":
                                aRow["February Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "三月":
                                aRow["March Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "四月":
                                aRow["April Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "五月":
                                aRow["May Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "六月":
                                aRow["June Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "七月":
                                aRow["July Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "八月":
                                aRow["August Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "九月":
                                aRow["September Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "十月":
                                aRow["October Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "十一月":
                                aRow["November Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            case "十二月":
                                aRow["December Taken"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    rq_zz25a.Rows.Add(aRow);
                }
                JBModule.Data.CNPOI.RenderDataTableToExcel(rq_zz25a, "C:\\TEMP\\" + this.Name + ".xls");
                System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                rq_abs = null; rq_absnobr = null; rq_base = null; rq_mon = null;
                rq_sal = null; rq_salbasd = null;
                this.Close();

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
