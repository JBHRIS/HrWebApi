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
    public partial class ZZ34_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, comp_b, comp_e, reporttype, insuername, insure_type, type_data, report_type, comp_name,compid;
        bool exportexcel;
        public ZZ34_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string compb, string compe, string insuretype, string typedata, string _insuername, string reporttype, bool _exportexcel, string compname,string _compid)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            comp_b = compb; comp_e = compe; insure_type = insuretype; type_data = typedata;
            exportexcel = _exportexcel; insuername = _insuername; comp_name = compname;
            report_type = reporttype; compid = _compid;
        }

        private void ZZ34_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += " from base a,basetts b,dept c where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                DataTable rq_family = SqlConn.GetDataTable("select nobr,fa_idno,fa_name,fa_birdt from family");
                rq_family.PrimaryKey = new DataColumn[] { rq_family.Columns["nobr"], rq_family.Columns["fa_idno"] };
                string sqlCmd1 = "";
                switch (insure_type)
                {
                    case "0":
                        sqlCmd1 = "select * from insgrp where nobr+fa_idno+convert(char,in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from insgrp  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and in_date between '{0}' and '{1}'", date_b, date_e);                        
                        sqlCmd1 += " order by nobr";
                        break;
                    case "1":
                        sqlCmd1 = "select * from insgrp where nobr+fa_idno+convert(char,in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from insgrp  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and out_date between '{0}' and '{1}'", date_b, date_e);                        
                        sqlCmd1 += " order by nobr";
                        break;                  
                    case "3":
                        sqlCmd1 = "select * from insgrp where nobr+fa_idno+convert(char,in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from insgrp  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and '{0}' between in_date and out_date", date_e);                        
                        sqlCmd1 += " order by nobr";
                        break;
                    default:
                        sqlCmd1 = "select * from insgrp where nobr+fa_idno+convert(char,in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from insgrp  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";                       
                        sqlCmd1 += " order by nobr";
                        break;
                }
                DataTable  rq_insgrp = SqlConn.GetDataTable(sqlCmd1);
                if (rq_insgrp.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_insgrp.Columns.Add("name_c", typeof(string));
                rq_insgrp.Columns.Add("name_e", typeof(string));
                rq_insgrp.Columns.Add("dept", typeof(string));
                rq_insgrp.Columns.Add("d_name", typeof(string));
                rq_insgrp.Columns.Add("d_ename", typeof(string));
                rq_insgrp.Columns.Add("idno", typeof(string));
                rq_insgrp.Columns.Add("fa_name", typeof(string));
                foreach (DataRow Row in rq_insgrp.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["d_ename"] = row["d_ename"].ToString();
                        Row["idno"] = row["idno"].ToString();
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["fa_idno"].ToString();
                        DataRow row1 = rq_family.Rows.Find(_value);
                        Row["fa_name"] = (row1 != null) ? row1["fa_name"].ToString() : "";
                    }
                    else
                        Row.Delete();
                }
                rq_insgrp.AcceptChanges();
                DataRow[] SRow = rq_insgrp.Select("", "dept,nobr,grp_type asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow aRow = ds.Tables["zz34"].NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["fa_idno"] = (Row["fa_idno"].ToString().Trim() == "") ? Row["idno"].ToString() : Row["fa_idno"].ToString();
                    aRow["fa_name"] = Row["fa_name"].ToString();
                    aRow["grp_type"] = Row["grp_type"].ToString();
                    //if (Row["grp_type"].ToString().Trim() == "A")
                    //    aRow["grp_type"] = "本人";
                    //else if (Row["grp_type"].ToString().Trim() == "B")
                    //    aRow["grp_type"] = "配偶";
                    //else if (Row["grp_type"].ToString().Trim() == "C")
                    //    aRow["grp_type"] = "子女";
                    //else if (Row["grp_type"].ToString().Trim() == "D")
                    //    aRow["grp_type"] = "父母";
                    aRow["pan"] = Row["pan"].ToString();
                    aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                    aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                    aRow["amt1"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt1"].ToString()));
                    aRow["cop1"] = decimal.Parse(Row["cop1"].ToString());
                    aRow["exp1"] = decimal.Round(decimal.Parse(Row["exp1"].ToString()), 0);
                    aRow["amt2"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt2"].ToString()));
                    aRow["cop2"] = decimal.Parse(Row["cop2"].ToString());
                    aRow["exp2"] =decimal.Round(decimal.Parse(Row["exp2"].ToString()),0);
                    aRow["amt3"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt3"].ToString()));
                    aRow["cop3"] = decimal.Parse(Row["cop3"].ToString());
                    aRow["exp3"] = decimal.Round(decimal.Parse(Row["exp3"].ToString()),0);
                    aRow["amt4"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt4"].ToString()));
                    aRow["cop4"] = decimal.Parse(Row["cop4"].ToString());
                    aRow["exp4"] = decimal.Round(decimal.Parse(Row["exp4"].ToString()),0);
                    aRow["amt5"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt5"].ToString()));
                    aRow["cop5"] = decimal.Parse(Row["cop5"].ToString());
                    aRow["exp5"] = decimal.Round(decimal.Parse(Row["exp5"].ToString()),0);
                    aRow["lamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt6"].ToString()));
                    aRow["totcop"] = decimal.Round(decimal.Parse(Row["copexp"].ToString()),0);
                    aRow["totexp"] = decimal.Round(decimal.Parse(Row["totexp"].ToString()),0);
                    ds.Tables["zz34"].Rows.Add(aRow);
                }

                if (ds.Tables["zz34"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (report_type == "1")
                {
                    //定期壽險
                    DataTable rq_grp1 = new DataTable();
                    rq_grp1 = ds.Tables["zz341"].Clone();
                    rq_grp1.TableName = "rq_grp1";
                    rq_grp1.PrimaryKey = new DataColumn[] { rq_grp1.Columns["insureamt"] };

                    //意外保險
                    DataTable rq_grp2 = new DataTable();
                    rq_grp2 = ds.Tables["zz341"].Clone();
                    rq_grp2.TableName = "rq_grp2";
                    rq_grp2.PrimaryKey = new DataColumn[] { rq_grp2.Columns["insureamt"] };
                    
                    //職業災害
                    DataTable rq_grp3 = new DataTable();
                    rq_grp3 = ds.Tables["zz341"].Clone();
                    rq_grp3.TableName = "rq_grp3";
                    rq_grp3.PrimaryKey = new DataColumn[] { rq_grp3.Columns["item"] };

                    //職業災害
                    DataTable rq_grp4 = new DataTable();
                    rq_grp4 = ds.Tables["zz341"].Clone();
                    rq_grp4.TableName = "rq_grp4";
                    rq_grp4.PrimaryKey = new DataColumn[] { rq_grp4.Columns["item"] };

                    //住院醫療
                    DataTable rq_grp5 = new DataTable();
                    rq_grp5 = ds.Tables["zz341"].Clone();
                    rq_grp5.TableName = "rq_grp5";
                    rq_grp5.PrimaryKey = new DataColumn[] { rq_grp5.Columns["insureamt"], rq_grp5.Columns["grp_type"] };

                    //意外醫療
                    DataTable rq_grp6 = new DataTable();
                    rq_grp6 = ds.Tables["zz341"].Clone();
                    rq_grp6.TableName = "rq_grp6";
                    rq_grp6.PrimaryKey = new DataColumn[] { rq_grp6.Columns["insureamt"], rq_grp6.Columns["grp_type"] };

                    //團保參數設定
                    DataTable rq_sys6 = SqlConn.GetDataTable("select groupexp1,groupexp2,groupexp51,groupexp52 from u_sys6");
                    decimal groupexp1 = 0; decimal groupexp2 = 0; decimal groupexp51 = 0; decimal groupexp52 = 0;

                    if (rq_sys6.Rows.Count > 0)
                    {
                        groupexp1 = decimal.Parse(rq_sys6.Rows[0]["groupexp1"].ToString())/10;
                        groupexp2 = decimal.Parse(rq_sys6.Rows[0]["groupexp2"].ToString()) / 10;
                        groupexp51 = decimal.Parse(rq_sys6.Rows[0]["groupexp51"].ToString()) / 10;
                        groupexp52 = decimal.Parse(rq_sys6.Rows[0]["groupexp52"].ToString()) / 10;
                    }
                  
                    foreach (DataRow Row in ds.Tables["zz34"].Rows)
                    {
                        //定期壽險
                        if (int.Parse(Row["amt1"].ToString()) > 0)
                        {
                            DataRow row = rq_grp1.Rows.Find(int.Parse(Row["amt1"].ToString()));
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["amt1"].ToString());
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp1"].ToString()) + Math.Round(decimal.Parse(Row["cop1"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp1.NewRow();
                                aRow["item"] = "定期壽險";
                                aRow["grp_type"] = "";
                                aRow["insureamt"] = int.Parse(Row["amt1"].ToString());
                                aRow["rate"] = groupexp1;
                                aRow["cnt"] =  1;
                                aRow["totinsure"] = int.Parse(Row["amt1"].ToString()) ;
                                aRow["fee"] = int.Parse(Row["exp1"].ToString()) + Math.Round(decimal.Parse(Row["cop1"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp1.Rows.Add(aRow);
                            }
                        }

                        //意外保險
                        if (int.Parse(Row["amt2"].ToString()) > 0)
                        {
                            DataRow row = rq_grp2.Rows.Find(int.Parse(Row["amt2"].ToString()));
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["amt2"].ToString());
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp2.NewRow();
                                aRow["item"] = "意外保險";
                                aRow["grp_type"] = "";
                                aRow["insureamt"] = int.Parse(Row["amt2"].ToString());
                                aRow["rate"] = groupexp2;
                                aRow["cnt"] = 1;
                                aRow["totinsure"] = int.Parse(Row["amt2"].ToString());
                                aRow["fee"] = int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp2.Rows.Add(aRow);
                            }
                        }

                        //職業災害
                        if (int.Parse(Row["amt5"].ToString()) > 0)
                        {
                            DataRow row = rq_grp3.Rows.Find("職業災害");
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["lamt"].ToString());
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp3.NewRow();
                                aRow["item"] = "職業災害";
                                aRow["grp_type"] = "";
                                aRow["insureamt"] = 0;
                                aRow["rate"] = groupexp51;
                                aRow["cnt"] = 1;
                                aRow["totinsure"] = int.Parse(Row["lamt"].ToString());
                                aRow["fee"] = int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp3.Rows.Add(aRow);
                            }
                        }

                        //職業災害
                        if (int.Parse(Row["lamt"].ToString()) > 0)
                        {
                            DataRow row = rq_grp4.Rows.Find("職業災害");
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["amt5"].ToString()) - int.Parse(Row["lamt"].ToString());
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp4.NewRow();
                                aRow["item"] = "職業災害";
                                aRow["grp_type"] = "";
                                aRow["insureamt"] = 0;
                                aRow["rate"] = groupexp52;
                                aRow["cnt"] = 1;
                                aRow["totinsure"] = int.Parse(Row["amt5"].ToString()) - int.Parse(Row["lamt"].ToString());
                                aRow["fee"] = int.Parse(Row["exp2"].ToString()) + Math.Round(decimal.Parse(Row["cop2"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp4.Rows.Add(aRow);
                            }
                        }

                        //住院醫療
                        if (int.Parse(Row["amt3"].ToString()) > 0)
                        {
                            object[] _value = new object[2];
                            _value[0] = int.Parse(Row["amt3"].ToString());
                            _value[1] = Row["grp_type"].ToString();
                            DataRow row = rq_grp5.Rows.Find(_value);
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["amt3"].ToString()) ;
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp3"].ToString()) + Math.Round(decimal.Parse(Row["cop3"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp5.NewRow();
                                aRow["item"] = "住院醫療";
                                aRow["grp_type"] = Row["grp_type"].ToString();
                                aRow["insureamt"] = int.Parse(Row["amt3"].ToString());
                                aRow["rate"] = groupexp51;
                                aRow["cnt"] = 1;
                                aRow["totinsure"] = int.Parse(Row["amt3"].ToString()) ;
                                aRow["fee"] = int.Parse(Row["exp3"].ToString()) + Math.Round(decimal.Parse(Row["cop3"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp5.Rows.Add(aRow);
                            }
                        }

                        //意外醫療
                        if (int.Parse(Row["amt4"].ToString()) > 0)
                        {
                            object[] _value = new object[2];
                            _value[0] = int.Parse(Row["amt4"].ToString());
                            _value[1] = Row["grp_type"].ToString();
                            DataRow row = rq_grp6.Rows.Find(_value);
                            if (row != null)
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totinsure"] = int.Parse(row["totinsure"].ToString()) + int.Parse(Row["amt4"].ToString());
                                row["fee"] = int.Parse(row["fee"].ToString()) + int.Parse(Row["exp4"].ToString()) + Math.Round(decimal.Parse(Row["cop4"].ToString()), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                DataRow aRow = rq_grp6.NewRow();
                                aRow["item"] = "意外醫療";
                                aRow["grp_type"] = Row["grp_type"].ToString();
                                aRow["insureamt"] = int.Parse(Row["amt4"].ToString());
                                aRow["rate"] = groupexp51;
                                aRow["cnt"] = 1;
                                aRow["totinsure"] = int.Parse(Row["amt4"].ToString());
                                aRow["fee"] = int.Parse(Row["exp4"].ToString()) + Math.Round(decimal.Parse(Row["cop4"].ToString()), MidpointRounding.AwayFromZero);
                                rq_grp6.Rows.Add(aRow);
                            }
                        }
                    }

                    DataRow [] SRow1 = rq_grp1.Select("", "insureamt asc");
                    foreach (DataRow Row in SRow1)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }

                    DataRow[] SRow2 = rq_grp2.Select("", "insureamt asc");
                    foreach (DataRow Row in SRow2)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }

                    foreach (DataRow Row in rq_grp3.Rows)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }

                    foreach (DataRow Row in rq_grp4.Rows)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }

                    DataRow[] SRow3 = rq_grp5.Select("", "insureamt,grp_type asc");
                    foreach (DataRow Row in SRow3)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }

                    DataRow[] SRow4 = rq_grp6.Select("", "insureamt,grp_type asc");
                    foreach (DataRow Row in SRow4)
                    {
                        ds.Tables["zz341"].ImportRow(Row);
                    }                    

                    rq_grp1 = null; rq_grp2 = null; rq_grp3 = null; rq_grp4 = null; rq_grp5 = null;
                    rq_grp6 = null; rq_sys6 = null; ds.Tables.Remove("zz34");
                    if (ds.Tables["zz341"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }

                rq_base = null; rq_family = null; rq_insgrp = null;

                if (exportexcel)
                {
                    if (report_type=="0")
                        Export(ds.Tables["zz34"]);
                    else
                        Export1(ds.Tables["zz341"]);
                    this.Close();
                }
                else
                {                  
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (report_type=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz34.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz341.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("InsuerName", insuername) });
                    if (report_type=="0")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz34", ds.Tables["zz34"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz341", ds.Tables["zz341"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));           
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));        
            ExporDt.Columns.Add("身分證號", typeof(string));            
            ExporDt.Columns.Add("眷屬姓名", typeof(string));
            ExporDt.Columns.Add("類別", typeof(string));           
            ExporDt.Columns.Add("加保日期",typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("壽險金額", typeof(int));
            ExporDt.Columns.Add("壽險公司負擔", typeof(decimal));
            ExporDt.Columns.Add("意外金額", typeof(int));
            ExporDt.Columns.Add("意外公司負擔", typeof(decimal));
            ExporDt.Columns.Add("住院金額", typeof(int));
            ExporDt.Columns.Add("住院公司負擔", typeof(decimal));
            ExporDt.Columns.Add("意外醫療金額", typeof(int));
            ExporDt.Columns.Add("意外醫療公司負擔", typeof(decimal));
            ExporDt.Columns.Add("住院員工負擔", typeof(int));
            ExporDt.Columns.Add("意外員工負擔", typeof(int));
            ExporDt.Columns.Add("職災保額", typeof(int));
            ExporDt.Columns.Add("職災公司負擔", typeof(decimal));
            ExporDt.Columns.Add("勞保保額", typeof(int));
            ExporDt.Columns.Add("員工負擔", typeof(int));
            ExporDt.Columns.Add("公司負擔", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();                
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();                
                aRow["身分證號"] = Row01["fa_idno"].ToString();
                aRow["眷屬姓名"] = Row01["fa_name"].ToString();
                aRow["類別"] = Row01["grp_type"].ToString();                
                aRow["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow["壽險金額"] = int.Parse(Row01["amt1"].ToString());
                aRow["壽險公司負擔"] = decimal.Parse(Row01["cop1"].ToString());
                aRow["意外金額"] = int.Parse(Row01["amt2"].ToString());
                aRow["意外公司負擔"] = decimal.Parse(Row01["cop2"].ToString());
                aRow["住院金額"] = int.Parse(Row01["amt3"].ToString());
                aRow["住院公司負擔"] = decimal.Parse(Row01["cop3"].ToString());
                aRow["意外醫療金額"] = int.Parse(Row01["amt4"].ToString());
                aRow["意外醫療公司負擔"] = decimal.Parse(Row01["cop4"].ToString());
                aRow["住院員工負擔"] = int.Parse(Row01["exp3"].ToString());
                aRow["意外員工負擔"] = int.Parse(Row01["exp4"].ToString());
                aRow["職災保額"] = int.Parse(Row01["amt5"].ToString());
                aRow["職災公司負擔"] = decimal.Parse(Row01["cop5"].ToString());
                aRow["勞保保額"] = int.Parse(Row01["lamt"].ToString());
                aRow["員工負擔"] = int.Parse(Row01["totexp"].ToString());
                aRow["公司負擔"] = int.Parse(Row01["totcop"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("險種", typeof(string));
            ExporDt.Columns.Add("投保金額/險種", typeof(int));
            ExporDt.Columns.Add("投保總額", typeof(int));
            ExporDt.Columns.Add("類別", typeof(string));
            ExporDt.Columns.Add("費率", typeof(decimal));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("保費", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["險種"] = Row01["item"].ToString();
                aRow["投保金額/險種"] = int.Parse(Row01["insureamt"].ToString());
                aRow["投保總額"] = int.Parse(Row01["totinsure"].ToString());
                aRow["類別"] = Row01["grp_type"].ToString();
                aRow["費率"] = decimal.Parse(Row01["rate"].ToString());
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                aRow["保費"] = int.Parse(Row01["fee"].ToString());
                ExporDt.Rows.Add(aRow);
            }           
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }


    }
}
