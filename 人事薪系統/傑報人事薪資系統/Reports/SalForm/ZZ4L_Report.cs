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
    public partial class ZZ4L_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e,emp_b,emp_e, date_b, date_e, yymm_b, yymm_e, type_data, reporttype, comp_name, CompId;
        bool exportexcel,mangsuper;
        public ZZ4L_Report(string nobrb, string nobre, string deptb, string depte,string empb,string empe, string dateb, string datee, string yymmb, string yymme, string typedata, string _reporttype, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            type_data = typedata; reporttype = _reporttype; exportexcel = _exportexcel;
            yymm_b = yymmb; yymm_e = yymme; comp_name = compname; CompId = _CompId;
            emp_b = empb; emp_e = empe;
        }

        private void ZZ4L_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.sex,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += ",d.amt";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join station d on b.station=d.code";               
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += type_data;
                //if (!mangsuper) sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //DataTable rq_sys3 = SqlConn.GetDataTable("select malemaxhrs,femalemaxhrs from u_sys3 ");
                //decimal malemaxhrs = (rq_sys3.Rows.Count > 0) ? decimal.Parse(rq_sys3.Rows[0]["malemaxhrs"].ToString()) : 0;
                //decimal femalemaxhrs = (rq_sys3.Rows.Count > 0) ? decimal.Parse(rq_sys3.Rows[0]["femalemaxhrs"].ToString()) : 0;
                string sqlCmd1 = "select a.nobr,a.adate,right(datename(dw, adate),1) as dw,b.rote_disp as rote,b.rotename";
                sqlCmd1 += ",a.nigamt as foodamt,a.stationamt";
                //sqlCmd1 += " from attend a,rote b where a.rote=b.rote and b.night=1";
                sqlCmd1 += " from attend a,rote b where a.rote=b.rote";
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += " order by a.nobr,a.adate";
                DataTable rq_attend = SqlConn.GetDataTable(sqlCmd1);
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"], rq_attend.Columns["adate"] };
                
                if (rq_attend.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataTable rq_AppConfig = SqlConn.GetDataTable("SELECT a.code,a.Value,b.sal_code_disp,b.sal_name FROM AppConfig a left outer join salcode b on a.Value=b.sal_code WHERE a.Category='ZZ2Z' and a.COMP='" + MainForm.COMPANY + "' ");

                DataTable rq_saltitle = new DataTable();
                rq_saltitle.Columns.Add("sal_name", typeof(string));
                rq_saltitle.PrimaryKey = new DataColumn[] { rq_saltitle.Columns["sal_name"] };
                foreach (DataRow Row in rq_AppConfig.Rows)
                {
                    if (!Row.IsNull("sal_name"))
                    {
                        DataRow row = rq_saltitle.Rows.Find(Row["sal_name"].ToString());
                        if (row == null)
                        {
                            DataRow aRow = rq_saltitle.NewRow();
                            aRow["sal_name"] = Row["sal_name"].ToString();
                            rq_saltitle.Rows.Add(aRow);
                        }

                    }
                }

                //津貼顯示
                string sqlAalatt = "select a.nobr,a.adate,b.sal_name,sum(a.amt) as amt";
                sqlAalatt += " from salatt a,salcode b";
                sqlAalatt += " where a.sal_code=b.sal_code";
                sqlAalatt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAalatt += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                //sqlAalatt += string.Format(" and a.sal_code in ('{0}','{1}','{2}','{3}','{4}')", AttSalCode1, AttSalCode2, AttSalCode3, AttSalCode4, AttSalCode5);
                sqlAalatt += " group by a.nobr,a.adate,b.sal_name";
                sqlAalatt += " order by a.nobr,a.adate";
                DataTable rq_salatt1 = SqlConn.GetDataTable(sqlAalatt);
                DataTable rq_salatt = new DataTable();
                rq_salatt.Columns.Add("nobr", typeof(string));
                rq_salatt.Columns.Add("adate", typeof(DateTime));
                rq_salatt.PrimaryKey = new DataColumn[] { rq_salatt.Columns["nobr"], rq_salatt.Columns["adate"] };

                //津貼表頭
                DataRow aRowta = ds.Tables["zz4l_ta"].NewRow();
                for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                {
                    aRowta["Fldt" + (i + 1)] = rq_saltitle.Rows[i]["sal_name"].ToString();
                    rq_salatt.Columns.Add(rq_saltitle.Rows[i]["sal_name"].ToString(), typeof(int));
                }
                ds.Tables["zz4l_ta"].Rows.Add(aRowta);

                foreach (DataRow Row in rq_salatt1.Rows)
                {
                    string salname = Row["sal_name"].ToString();
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    
                    DataRow row = rq_salatt.Rows.Find(_value);
                    if (row != null)
                    {
                        for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                        {
                            if (salname == rq_saltitle.Rows[i]["sal_name"].ToString())
                            {
                                row[rq_saltitle.Rows[i]["sal_name"].ToString()] = decimal.Parse(row[rq_saltitle.Rows[i]["sal_name"].ToString()].ToString()) + decimal.Parse(Row["amt"].ToString());
                                break;
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow = rq_salatt.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                        {
                            aRow[rq_saltitle.Rows[i]["sal_name"].ToString()] = 0;
                            if (salname == rq_saltitle.Rows[i]["sal_name"].ToString())
                            {
                                aRow[rq_saltitle.Rows[i]["sal_name"].ToString()] = decimal.Parse(Row["amt"].ToString());
                            }
                        }
                        rq_salatt.Rows.Add(aRow);
                    }
                }
               
                string sqlUsys3 = "select otfoodsalcode from u_sys3 where comp='" + CompId + "'";
                DataTable rq_usys3 = SqlConn.GetDataTable(sqlUsys3);
                string otfoodsalcode = (rq_usys3.Rows.Count > 0) ? rq_usys3.Rows[0]["otfoodsalcode"].ToString().Trim() : "";

                DataTable rq_sys2 = SqlConn.GetDataTable("select empsalcode from u_sys2 where comp='" + CompId + "'");
                string empsalcode = (rq_sys2.Rows.Count > 0) ? rq_sys2.Rows[0]["empsalcode"].ToString().Trim() : "";

                string sqlCmd6 = "select yymm,nobr,adate,mlssalcode,amt from salabs";
                sqlCmd6 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd6 += string.Format(@" and (yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd6 += string.Format(@" or adate between '{0}' and '{1}')", date_b, date_e);
                sqlCmd6 += string.Format(@" and (mlssalcode ='{0}' or mlssalcode ='{1}')", otfoodsalcode,empsalcode);
                DataTable rq_salabs = SqlConn.GetDataTable(sqlCmd6);
                DataTable rq_salabs1 = new DataTable();
                rq_salabs1.Columns.Add("nobr", typeof(string));
                rq_salabs1.Columns.Add("adate", typeof(DateTime));
                rq_salabs1.Columns.Add("mlssalcode", typeof(string));
                rq_salabs1.Columns.Add("amt", typeof(int));
                rq_salabs1.PrimaryKey = new DataColumn[] { rq_salabs1.Columns["nobr"], rq_salabs1.Columns["adate"], rq_salabs1.Columns["mlssalcode"] };
                foreach (DataRow Row in rq_salabs.Rows)
                {
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    _value[2] = Row["mlssalcode"].ToString();
                    DataRow row = rq_salabs1.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    else
                    {
                        DataRow aRow = rq_salabs1.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["mlssalcode"] = Row["mlssalcode"].ToString();
                        aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        rq_salabs1.Rows.Add(aRow);
                    }                   
                }
                rq_salabs = null;                 
                string sqlCmd2 = "select nobr,adate,dd1,dd2,tt1,tt2 from attcard";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_attcard = SqlConn.GetDataTable(sqlCmd2);
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };

                
                foreach (DataRow Row in rq_salabs1.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_attend.Rows.Find(_value);
                    if (row == null)
                    {                     
                        string sqlCmd7 = "select a.nobr,a.adate,right(datename(dw, adate),1) as dw,b.rote_disp as rote,b.rotename";
                        sqlCmd7 += ",0.00  as foodamt, 0.00 as stationamt";
                        sqlCmd7 += " from attend a,rote b where a.rote=b.rote ";
                        sqlCmd7 += string.Format(@" and a.nobr='{0}'", Row["nobr"].ToString());
                        sqlCmd7 += string.Format(@" and a.adate= '{0}' ", DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd"));
                        sqlCmd7 += " order by a.nobr,a.adate";
                        DataTable rq_attenda = SqlConn.GetDataTable(sqlCmd7);
                        if (rq_attenda.Rows.Count > 0)
                        {
                            if (Row["mlssalcode"].ToString().Trim() == otfoodsalcode)
                                rq_attenda.Rows[0]["foodamt"] = int.Parse(Row["amt"].ToString()) * (-1);
                            else if (Row["mlssalcode"].ToString().Trim() == empsalcode)
                                rq_attenda.Rows[0]["stationamt"] = int.Parse(Row["amt"].ToString()) * (-1);
                            rq_attend.Merge(rq_attenda);
                        }
                        rq_attenda.Clear();
                        string sqlCmd8 = "select nobr,adate,dd1,dd2,tt1,tt2 from attcard";
                        sqlCmd8 += string.Format(@" where nobr = '{0}'", Row["nobr"].ToString());
                        sqlCmd8 += string.Format(@" and adate ='{0}' ", DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd"));
                        DataTable rq_attcarda = SqlConn.GetDataTable(sqlCmd8);
                        if (rq_attcarda.Rows.Count > 0)
                            rq_attcard.Merge(rq_attcarda);
                        rq_attcarda.Clear();

                    }
                    else
                    {
                        if (Row["mlssalcode"].ToString().Trim() == otfoodsalcode)
                            row["foodamt"] = decimal.Parse(row["foodamt"].ToString()) - decimal.Parse(Row["amt"].ToString());
                        else if (Row["mlssalcode"].ToString().Trim() == empsalcode)
                            row["stationamt"] = (row.IsNull("stationamt")) ? 0 - decimal.Parse(Row["amt"].ToString()) : decimal.Parse(row["stationamt"].ToString()) - decimal.Parse(Row["amt"].ToString());
                    }
                }

                string sqlCmd3 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,a.btime,a.etime,a.tol_hours,b.not_sum";
                sqlCmd3 += " from abs a,hcode b where a.h_code=b.h_code";
                sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd3 += string.Format(@" and (bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd3 += string.Format(@" or a.yymm between '{0}' and '{1}')", yymm_b, yymm_e);
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd3);

                string sqlCmd4 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,a.btime,a.etime,a.tol_hours,b.not_sum";
                sqlCmd4 += " from abs1 a,hcode b where a.h_code=b.h_code";
                sqlCmd4 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and ( bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd4 += string.Format(@" or a.yymm between '{0}' and '{1}')", yymm_b, yymm_e);
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlCmd4);
                foreach (DataRow Row in rq_abs1.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        rq_abs.ImportRow(Row);
                }

                string sqlCmd5 = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs,ot_food from ot a";
                sqlCmd5 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@" and ( a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd5 += string.Format(@" or a.yymm between '{0}' and '{1}')", yymm_b, yymm_e);
                DataTable rq_ot = SqlConn.GetDataTable(sqlCmd5);
                DataRow[] SRow = rq_attend.Select("", "nobr,adate asc");
                DataTable rq_zz4l = new DataTable();
                rq_zz4l = ds.Tables["zz4l"].Clone();
                rq_zz4l.TableName = "rq_zz4l";
                rq_zz4l.Columns.Add("chkatt", typeof(string));

                foreach (DataRow Row in SRow)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        string str_adate=DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row["adate"].ToString());
                        DataRow row1 = rq_attcard.Rows.Find(_value);
                        DataRow[] row2 = rq_abs.Select("nobr='" + Row["nobr"].ToString() + "' and bdate='" + str_adate + "'");
                        DataRow[] row3 = rq_ot.Select("nobr='" + Row["nobr"].ToString() + "' and bdate='" + str_adate + "'");
                        DataRow row4 = rq_salatt.Rows.Find(_value);
                        if (row2.Length >= row3.Length && row2.Length >0)
                        {
                            for (int i = 0; i < row2.Length; i++)
                            {
                                DataRow aRow = rq_zz4l.NewRow();
                                aRow["dept"] = row["dept"].ToString();
                                aRow["d_name"] = row["d_name"].ToString();
                                aRow["d_ename"] = row["d_ename"].ToString();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = row["name_c"].ToString();
                                aRow["name_e"] = row["name_e"].ToString();
                                aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                                aRow["dw"] = Row["dw"].ToString();
                                aRow["rote"] = Row["rote"].ToString();
                                aRow["rotename"] = Row["rotename"].ToString();
                                //aRow["basestationamt"] = (row.IsNull("amt")) ? 0 : Math.Round(decimal.Parse(row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                //aRow["stationamt"] = (Row.IsNull("stationamt")) ? 0 : Math.Round(decimal.Parse(Row["stationamt"].ToString()), MidpointRounding.AwayFromZero);
                                if (row1 != null)
                                {
                                    aRow["dd1"] = row1["dd1"].ToString();
                                    aRow["dd2"] = row1["dd2"].ToString();
                                    aRow["tt1"] = row1["tt1"].ToString();
                                    aRow["tt2"] = row1["tt2"].ToString();
                                }
                                aRow["absbtime"] = row2[i]["btime"].ToString();
                                aRow["absetime"] = row2[i]["etime"].ToString();
                                aRow["h_code"] = row2[i]["h_code"].ToString();
                                aRow["h_name"] = row2[i]["h_name"].ToString();
                                aRow["tol_hours"] = decimal.Parse(row2[i]["tol_hours"].ToString());
                                if (row3.Length > i)
                                {
                                    aRow["otbtime"] = row3[i]["btime"].ToString();
                                    aRow["otetime"] = row3[i]["etime"].ToString();
                                    aRow["ot_hrs"] = decimal.Parse(row3[i]["ot_hrs"].ToString());
                                    aRow["rest_hrs"] = decimal.Parse(row3[i]["rest_hrs"].ToString());
                                    aRow["otfoodamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row3[i]["ot_food"].ToString()));
                                }
                                if (i == 0)
                                {
                                    aRow["chkatt"] = "0";
                                    aRow["basestationamt"] = (row.IsNull("amt")) ? 0 : Math.Round(decimal.Parse(row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                    aRow["stationamt"] = (Row.IsNull("stationamt")) ? 0 : Math.Round(decimal.Parse(Row["stationamt"].ToString()), MidpointRounding.AwayFromZero);
                                    aRow["foodamt"] = Math.Round(decimal.Parse(Row["foodamt"].ToString()), MidpointRounding.AwayFromZero);
                                    if (row4 != null)
                                    {
                                        for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                                        {
                                            aRow["Fld" + (k + 1)] = int.Parse(row4[rq_saltitle.Rows[k]["sal_name"].ToString()].ToString());
                                            aRow["chkatt"] = "1";
                                        }
                                    }
                                }
                                rq_zz4l.Rows.Add(aRow);
                            }
                        }
                        else if (row3.Length > row2.Length)
                        {
                            for (int i = 0; i < row3.Length; i++)
                            {
                                DataRow aRow1 = rq_zz4l.NewRow();
                                aRow1["dept"] = row["dept"].ToString();
                                aRow1["d_name"] = row["d_name"].ToString();
                                aRow1["d_ename"] = row["d_ename"].ToString();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["name_c"] = row["name_c"].ToString();
                                aRow1["name_e"] = row["name_e"].ToString();
                                aRow1["adate"] = DateTime.Parse(Row["adate"].ToString());
                                aRow1["dw"] = Row["dw"].ToString();
                                aRow1["rote"] = Row["rote"].ToString();
                                aRow1["rotename"] = Row["rotename"].ToString();
                                //aRow1["basestationamt"] = (row.IsNull("amt")) ? 0 : Math.Round(decimal.Parse(row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                //aRow1["stationamt"] = (Row.IsNull("stationamt")) ? 0 : Math.Round(decimal.Parse(Row["stationamt"].ToString()), MidpointRounding.AwayFromZero);                          
                                if (row1 != null)
                                {
                                    aRow1["dd1"] = row1["dd1"].ToString();
                                    aRow1["dd2"] = row1["dd2"].ToString();
                                    aRow1["tt1"] = row1["tt1"].ToString();
                                    aRow1["tt2"] = row1["tt2"].ToString();
                                }
                                aRow1["otbtime"] = row3[i]["btime"].ToString();
                                aRow1["otetime"] = row3[i]["etime"].ToString();
                                aRow1["ot_hrs"] = decimal.Parse(row3[i]["ot_hrs"].ToString());
                                aRow1["rest_hrs"] = decimal.Parse(row3[i]["rest_hrs"].ToString());
                                aRow1["otfoodamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row3[i]["ot_food"].ToString()));
                                if (row2.Length > i)
                                {
                                    aRow1["absbtime"] = row2[i]["btime"].ToString();
                                    aRow1["absetime"] = row2[i]["etime"].ToString();
                                    aRow1["h_code"] = row2[i]["h_code"].ToString();
                                    aRow1["h_name"] = row2[i]["h_name"].ToString();
                                    aRow1["tol_hours"] = decimal.Parse(row2[i]["tol_hours"].ToString());
                                }
                                if (i == 0)
                                {
                                    aRow1["chkatt"] = "0";
                                    aRow1["foodamt"] = Math.Round(decimal.Parse(Row["foodamt"].ToString()), MidpointRounding.AwayFromZero);
                                    aRow1["basestationamt"] = (row.IsNull("amt")) ? 0 : Math.Round(decimal.Parse(row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                    aRow1["stationamt"] = (Row.IsNull("stationamt")) ? 0 : Math.Round(decimal.Parse(Row["stationamt"].ToString()), MidpointRounding.AwayFromZero);
                                    if (row4 != null)
                                    {
                                        for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                                        {                                            
                                            aRow1["Fld" + (k + 1)] = int.Parse(row4[rq_saltitle.Rows[k]["sal_name"].ToString()].ToString());
                                            aRow1["chkatt"] = "1";
                                        }
                                    }
                                }
                                rq_zz4l.Rows.Add(aRow1);
                            }
                        }
                        else
                        {
                            DataRow aRow2 = rq_zz4l.NewRow();
                            aRow2["dept"] = row["dept"].ToString();
                            aRow2["d_name"] = row["d_name"].ToString();
                            aRow2["d_ename"] = row["d_ename"].ToString();
                            aRow2["nobr"] = Row["nobr"].ToString();
                            aRow2["name_c"] = row["name_c"].ToString();
                            aRow2["name_e"] = row["name_e"].ToString();
                            aRow2["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow2["dw"] = Row["dw"].ToString();
                            aRow2["rote"] = Row["rote"].ToString();
                            aRow2["rotename"] = Row["rotename"].ToString();
                            aRow2["basestationamt"] = (row.IsNull("amt")) ? 0 : Math.Round(decimal.Parse(row["amt"].ToString()), MidpointRounding.AwayFromZero);
                            aRow2["stationamt"] = (Row.IsNull("stationamt")) ? 0 : Math.Round(decimal.Parse(Row["stationamt"].ToString()), MidpointRounding.AwayFromZero);
                            if (row1 != null)
                            {
                                aRow2["dd1"] = row1["dd1"].ToString();
                                aRow2["dd2"] = row1["dd2"].ToString();
                                aRow2["tt1"] = row1["tt1"].ToString();
                                aRow2["tt2"] = row1["tt2"].ToString();
                            }
                            aRow2["foodamt"] = Math.Round(decimal.Parse(Row["foodamt"].ToString()), MidpointRounding.AwayFromZero);
                            aRow2["chkatt"] = "0";
                            if (row4 != null)
                            {
                                for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                                {
                                    if (k == 0)
                                        aRow2["chkatt"] = "1";
                                    aRow2["Fld" + (k + 1)] = int.Parse(row4[rq_saltitle.Rows[k]["sal_name"].ToString()].ToString());
                                }
                            }
                            rq_zz4l.Rows.Add(aRow2);
                        }
                    }
                }
                foreach (DataRow Row in rq_zz4l.Rows) //.Select("chkatt='1'")
                {
                    ////if (Row["tt1"].ToString().Trim() != "" || Row["absbtime"].ToString().Trim() != "" || Row["otbtime"].ToString().Trim() != "")
                    ////    ds.Tables["zz4l"].ImportRow(Row);
                    //int _stationamt = (Row.IsNull("stationamt")) ? 0 : int.Parse(Row["stationamt"].ToString());
                    //int _foodamt = (Row.IsNull("foodamt")) ? 0 : int.Parse(Row["foodamt"].ToString());
                    //if (_stationamt != 0 || _foodamt != 0)
                    //    ds.Tables["zz4l"].ImportRow(Row);

                    bool chekadd = false;
                    for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                    {
                        decimal allowance = (Row.IsNull("Fld" + (k + 1))) ? 0 : decimal.Parse(Row["Fld" + (k + 1)].ToString());
                        if (!chekadd && allowance > 0)
                            chekadd = true;
                    }
                    if (chekadd)
                        ds.Tables["zz4l"].ImportRow(Row);
                }
                rq_abs = null;rq_abs1 = null; rq_attcard = null; rq_attend = null; rq_base = null;
                rq_ot = null; rq_zz4l = null; rq_sys2 = null;

                if (ds.Tables["zz4l"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (reporttype == "1")
                {
                    ds.Tables["zz4la"].PrimaryKey = new DataColumn[] { ds.Tables["zz4la"].Columns["nobr"], ds.Tables["zz4la"].Columns["rote"] };
                    DataRow[] Orow = ds.Tables["zz4l"].Select("", "nobr,rote asc");
                    foreach (DataRow Row in Orow)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["rote"].ToString();
                        DataRow row = ds.Tables["zz4la"].Rows.Find(_value);
                        if (row != null)
                        {
                            if (!Row.IsNull("foodamt")) row["foodamt"] = int.Parse(row["foodamt"].ToString()) + int.Parse(Row["foodamt"].ToString());
                            if (!Row.IsNull("otfoodamt")) row["otfoodamt"] = int.Parse(row["otfoodamt"].ToString()) + int.Parse(Row["otfoodamt"].ToString());
                            if (!Row.IsNull("basestationamt")) row["basestationamt"] = int.Parse(row["basestationamt"].ToString()) + int.Parse(Row["basestationamt"].ToString());
                            if (!Row.IsNull("stationamt")) row["stationamt"] = int.Parse(row["stationamt"].ToString()) + int.Parse(Row["stationamt"].ToString());
                            for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                            {
                                row["Fld" + (k + 1)] = int.Parse(row["Fld" + (k + 1)].ToString()) + int.Parse(Row["Fld" + (k + 1)].ToString());
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz4la"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["rote"] = Row["rote"].ToString();
                            aRow["rotename"] = Row["rotename"].ToString();
                            aRow["foodamt"] = (Row.IsNull("foodamt")) ? 0 : int.Parse(Row["foodamt"].ToString());
                            aRow["otfoodamt"] = (Row.IsNull("otfoodamt")) ? 0 : int.Parse(Row["otfoodamt"].ToString());
                            aRow["basestationamt"] = (Row.IsNull("basestationamt")) ? 0 : int.Parse(Row["basestationamt"].ToString());
                            aRow["stationamt"] = (Row.IsNull("stationamt")) ? 0 : int.Parse(Row["stationamt"].ToString());
                            for (int k = 0; k < rq_saltitle.Rows.Count; k++)
                            {
                                aRow["Fld" + (k + 1)] = int.Parse(Row["Fld" + (k + 1)].ToString());
                            }
                            ds.Tables["zz4la"].Rows.Add(aRow);
                        }
                    }
                    ds.Tables.Remove("zz4l");
                }                
                
                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz4l"], ds.Tables["zz4l_ta"]);
                    else
                        Export2(ds.Tables["zz4la"], ds.Tables["zz4l_ta"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4l.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4la.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype=="0")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4l", ds.Tables["zz4l"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4la", ds.Tables["zz4la"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4lta", ds.Tables["zz4l_ta"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("班別", typeof(string));
            ExporDt.Columns.Add("班別名稱", typeof(string));
            //ExporDt.Columns.Add("環境津貼(原)", typeof(int));
            ExporDt.Columns.Add("上班時間", typeof(string));
            ExporDt.Columns.Add("下班時間", typeof(string));            
            ExporDt.Columns.Add("假別", typeof(string));
            ExporDt.Columns.Add("請起時間", typeof(string));
            ExporDt.Columns.Add("請迄時間", typeof(string));
            ExporDt.Columns.Add("請得假時數", typeof(decimal));
            ExporDt.Columns.Add("加起時間", typeof(string));
            ExporDt.Columns.Add("加迄時間", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            //ExporDt.Columns.Add("中夜津貼", typeof(int));
            //ExporDt.Columns.Add("環境津貼", typeof(int));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(int));
                else
                    break;
            }
            DataRow[] Srow = DT.Select("", "dept,nobr,adate asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["出勤日期"] = DateTime.Parse(Row01["adate"].ToString());
                aRow["星期"] = Row01["dw"].ToString();
                aRow["班別"] = Row01["rote"].ToString();
                aRow["班別名稱"] = Row01["rotename"].ToString();
                //aRow["環境津貼(原)"] = (Row01.IsNull("basestationamt")) ? 0 : int.Parse(Row01["basestationamt"].ToString());  
                aRow["上班時間"] = Row01["tt1"].ToString();
                aRow["下班時間"] = Row01["tt2"].ToString();
                aRow["假別"] = Row01["h_name"].ToString();
                aRow["請起時間"] = Row01["absbtime"].ToString();
                aRow["請迄時間"] = Row01["absetime"].ToString();
                aRow["請得假時數"] = (Row01.IsNull("tol_hours")) ? 0 : decimal.Parse(Row01["tol_hours"].ToString());
                aRow["加起時間"] = Row01["otbtime"].ToString();
                aRow["加迄時間"] = Row01["otetime"].ToString();
                aRow["加班時數"] = (Row01.IsNull("ot_hrs")) ? 0 : decimal.Parse(Row01["ot_hrs"].ToString());
                aRow["補休時數"] = (Row01.IsNull("rest_hrs")) ? 0 : decimal.Parse(Row01["rest_hrs"].ToString());
                //aRow["中夜津貼"] = (Row01.IsNull("foodamt")) ? 0 : int.Parse(Row01["foodamt"].ToString());
                //aRow["環境津貼"] = (Row01.IsNull("stationamt")) ? 0 : int.Parse(Row01["stationamt"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        aRow[DT1.Rows[0][i].ToString()] = (Row01.IsNull("Fld" + (i + 1))) ? 0 : int.Parse(Row01["Fld" + (i + 1)].ToString());

                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }


        void Export2(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("班別", typeof(string));
            ExporDt.Columns.Add("班別名稱", typeof(string));
            //ExporDt.Columns.Add("中夜津貼", typeof(int));
            //ExporDt.Columns.Add("環境津貼", typeof(int));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(int));
                else
                    break;
            }
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["班別"] = Row01["rote"].ToString();
                aRow["班別名稱"] = Row01["rotename"].ToString();
                //aRow["中夜津貼"] = (Row01.IsNull("foodamt")) ? 0 : int.Parse(Row01["foodamt"].ToString());
                //aRow["環境津貼"] = (Row01.IsNull("stationamt")) ? 0 : int.Parse(Row01["stationamt"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        aRow[DT1.Rows[0][i].ToString()] = (Row01.IsNull("Fld" + (i + 1))) ? 0 : int.Parse(Row01["Fld" + (i + 1)].ToString());

                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
