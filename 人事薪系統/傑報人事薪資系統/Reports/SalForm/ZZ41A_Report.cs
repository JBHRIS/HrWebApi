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
    public partial class ZZ41A_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();       
        string nobr_b, nobr_e, dept_b, dept_e, date_b,emp_b,emp_e, date_e,type_data;
        bool exportexcel, floating;
        public ZZ41A_Report(string nobrb, string nobre, string deptb, string depte,string empb,string empe, string dateb, string datee, string typedata,string ttstype, bool _exportexcel,bool _floating)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; type_data = typedata;
            exportexcel = _exportexcel; floating = _floating; emp_b = empb; emp_e = empe;
            date_b = dateb; date_e = datee;
        }

        private void ZZ41A_Report_Load(object sender, EventArgs e)
        {           
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,b.dept,c.d_name,c.d_ename,b.depts,d.d_name as ds_name,b.job,e.job_name,a.name_c,a.name_e,";
                sqlCmd += "b.indt,b.oudt";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and b.indt between '{0}' and '{1}'", date_b, date_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.*,b.sal_ename from salbasd a,salcode b";
                sqlCmd1 += " where a.sal_code=b.sal_code";
                sqlCmd1 += string.Format(@" and '{0}' between a.adate and a.ddate", date_e);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                DataTable rq_salbasd1 = new DataTable();
                rq_salbasd1.Columns.Add("sal_code", typeof(string));
                rq_salbasd1.Columns.Add("sal_name", typeof(string));
                rq_salbasd1.PrimaryKey = new DataColumn[] { rq_salbasd1.Columns["sal_code"] };
                DataRow[] Orow = rq_salbasd.Select("", "sal_code");
                foreach (DataRow Row in Orow)
                {
                    Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    DataRow row = rq_salbasd1.Rows.Find(Row["sal_code"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_salbasd1.NewRow();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["sal_name"] = Row["sal_ename"].ToString();
                        rq_salbasd1.Rows.Add(aRow);
                    }
                }

                if (floating)
                {
                    string sqlCmd2 = "select a.*,b.sal_ename,c.attr_name,c.flag";
                    sqlCmd2 += " from salbastd a,salcode b,salattr c";
                    sqlCmd2 += " where a.sal_code=b.sal_code and b.sal_attr=c.salattr";
                    sqlCmd2 += string.Format(@" and '{0}' between a.adate and a.ddate", date_e);
                    sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd2 += " order by a.sal_code";
                    DataTable rq_salbastd = SqlConn.GetDataTable(sqlCmd2);
                    foreach (DataRow Row in rq_salbastd.Rows)
                    {
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            DataRow row1 = rq_salbasd1.Rows.Find(Row["sal_code"].ToString());
                            if (row1 == null)
                            {
                                DataRow aRow = rq_salbasd1.NewRow();
                                aRow["sal_code"] = Row["sal_code"].ToString();
                                aRow["sal_name"] = Row["sal_ename"].ToString();
                                rq_salbasd1.Rows.Add(aRow);
                            }
                            rq_salbasd.ImportRow(Row);
                        }
                    }
                }

                //string sqlCmd1 = "SELECT A.*,B.SAL_NAME,C.ATTR_NAME FROM SALBASD A,SALCODE B,SALATTR C" +
                //    " WHERE A.SAL_CODE=B.SAL_CODE" +
                //    " AND '" + date_e + "' BETWEEN A.ADATE AND A.DDATE" +
                //    " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //    " AND B.SAL_ATTR=C.SALATTR" +
                //    " AND B.CAL_FREQ IN ('1','3')" +
                //    " AND B.SAL_ATTR IN ('A','G')" +
                //    " ORDER BY A.NOBR,A.SAL_CODE";
                //DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                //DataTable rq_salbasd1 = new DataTable();
                //rq_salbasd1.Columns.Add("sal_code", typeof(string));
                //rq_salbasd1.Columns.Add("sal_name", typeof(string));
                //rq_salbasd1.PrimaryKey = new DataColumn[] { rq_salbasd1.Columns["sal_code"] };
                //DataRow[] Orow = rq_salbasd.Select("", "sal_code");
                //foreach (DataRow Row in Orow)
                //{
                //    Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                //    DataRow row = rq_salbasd1.Rows.Find(Row["sal_code"].ToString());
                //    if (row == null)
                //    {
                //        DataRow aRow = rq_salbasd1.NewRow();
                //        aRow["sal_code"] = Row["sal_code"].ToString();
                //        aRow["sal_name"] = Row["sal_name"].ToString();
                //        rq_salbasd1.Rows.Add(aRow);
                //    }
                //}
                //DataRow newRow = rq_zz41.NewRow();
                //        newRow["Nobr"] = row8["nobr"].ToString();
                //        newRow["Name_c"] = row8["name_c"].ToString();
                //        newRow["Name_e"] = row8["name_e"].ToString();
                //        if (dept_type=="dept")
                //            newRow["Dept"] = row8["dept"].ToString();
                //        else
                //            newRow["Dept"] = row8["depts"].ToString();
                //        newRow["D_name"] = row8["d_name"].ToString();
                //        newRow["D_ename"] = row8["d_ename"].ToString();
                //        newRow["Job"] = row8["job"].ToString();
                //        newRow["Jobl"] = row8["jobl"].ToString();
                //        if (ttstype == "3")
                //            newRow["Indt"] = DateTime.Parse(row8["oudt"].ToString());
                //        else
                //            newRow["Indt"] = DateTime.Parse(row8["indt"].ToString());
                //        newRow["wk_yrs"] = decimal.Parse(row8["wk_yrs6"].ToString());
                //        newRow["Job_name"] = row8["job_name"].ToString();                        
                //        //newRow["depttype"] = dept_type;
                //        newRow["comp"] = row8["comp"].ToString();
                //        newRow["rotet"] = row8["rotet"].ToString();
                //        newRow["Fld" + (ht.Count+1)] = 0;
                //        for (int j = 1; j < zz41d.Columns.Count; j++)
                //        {
                //            //							newRow["Fld"+j] =ds.Tables["zz23d"].Rows[i][ds.Tables["zz23d"].Columns[j].ColumnName].ToString();
                //            if (zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString().Length == 0)
                //            {
                //                newRow["Fld" + j] = 0;                                
                //            }
                //            else
                //            {
                //                newRow["Fld" + j] = decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                //                //str_sum = str_sum + decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                //                newRow["Fld" + (ht.Count + 1)] = decimal.Parse(newRow["Fld" + (ht.Count + 1)].ToString()) + decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                //            }
                //        }

                //        //newRow["Fld" + rq_salbasd1.Rows.Count] = str_sum;
                //        rq_zz41.Rows.Add(newRow);
                //    }
                //}

                //DataRow[] row10 =rq_zz41.Select("", "dept,nobr asc")
                

                //foreach (DataRow Row in row10)
                //{
                //    ds.Tables["zz41"].ImportRow(Row);
                //}
                //rq_zz41 = null;
                //rq_base = null;
                //zz41d = null;
                //rq_salbasd1 = null;        

                //if (ds.Tables["zz41"].Rows.Count < 1)
                //{
                //    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                //    this.Close();
                //    return;
                //}
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
