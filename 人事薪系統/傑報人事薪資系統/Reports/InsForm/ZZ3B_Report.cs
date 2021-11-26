using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ3B_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, date_k, sno_b, sno_e, net_txt, net_no, insure_type, type_data, CompId;
        bool exportexcel, out_text;
        public ZZ3B_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datek, string datee, string snob, string snoe, string nettxt, string netno, string insuretype, string typedata, bool _exportexcel, bool outtext, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            sno_b = snob; sno_e = snoe; insure_type = insuretype; net_no = netno; net_txt = nettxt;
            exportexcel = _exportexcel; out_text = outtext; type_data = typedata;
            date_k = datek; CompId = _CompId;
        }

        private void ZZ3B_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.idno,a.birdt,b.retchoo,b.retrate,b.noret,a.count_ma,";
                sqlCmd += "b.retdate,c.d_no_disp as dept,c.d_name from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                DataTable rq_inscomp = SqlConn.GetDataTable("select * from inscomp");
                rq_inscomp.PrimaryKey = new DataColumn[] { rq_inscomp.Columns["s_no"] };
                string sqlCmd1 = "";
                switch (insure_type)
                {
                    case "0":
                        sqlCmd1 = "select a.* from inslab a ";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.in_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                    case "1":
                        sqlCmd1 = "select a.* from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.out_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                    case "2":
                        sqlCmd1 = "select a.* from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and a.in_date between '{0}' and '{1}'", date_b, date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.code='2'";
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                    case "3":
                        sqlCmd1 = "select a.* from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and '{0}' between a.in_date and a.out_date", date_e);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                    case "5":
                        sqlCmd1 = "select a.* from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and ('{0}' between a.in_date and a.out_date", date_e);
                        sqlCmd1 += string.Format(@" and '{0}' between a.in_date and a.out_date)", date_b);
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                    default:
                        sqlCmd1 = "select a.*,30 as insday,1 as helday,0 as h_exp,convert(bit,0) as zero,0 as h_exp1";
                        sqlCmd1 += " from inslab a";
                        sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                        sqlCmd1 += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                        sqlCmd1 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                        sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd1 += string.Format(@" and in_date<='{0}'", date_e);
                        sqlCmd1 += " group by nobr,fa_idno)";
                        sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                        sqlCmd1 += " and a.fa_idno='' order by a.nobr";
                        break;
                }
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd1);
                if (rq_inslab.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataTable rq_sys4 = SqlConn.GetDataTable("select nretirerate from u_sys4 where comp='" + CompId + "'");
                decimal nretirerate = (rq_sys4.Rows.Count > 0) ? decimal.Parse(rq_sys4.Rows[0]["nretirerate"].ToString()) : 0;
                if (out_text)
                {
                    net_txt = "C:\\TEMP\\" + net_txt + ".Txt";
                    File.Delete(net_txt);
                }
                foreach (DataRow Row in rq_inslab.Rows)
                {
                    Row["r_amt"] = (decimal.Parse(Row["r_amt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["r_amt"].ToString()));
                    Row["l_amt"] = (decimal.Parse(Row["l_amt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1 = rq_inscomp.Rows.Find(Row["s_no"].ToString());
                        DataRow aRow = ds.Tables["zz3b"].NewRow();
                        aRow["s_no"] = Row["s_no"];
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                        aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                        aRow["idno"] = row["idno"].ToString();
                        aRow["birdt"] = DateTime.Parse(row["birdt"].ToString());
                        DateTime _birdt = DateTime.Parse(row["birdt"].ToString());
                        aRow["birdts"] = "民國 " + Convert.ToString(_birdt.Year - 1911) + "年 " + Convert.ToString(_birdt.Month).PadLeft(2, '0') + "月 " + Convert.ToString(_birdt.Day).PadLeft(2, '0') + "日";
                        aRow["retchoo"] = row["retchoo"].ToString();
                        aRow["insno"] = (row1 != null) ? row1["insno"].ToString() : "";
                        aRow["insname"] = (row1 != null) ? row1["insname"].ToString() : "";
                        if (aRow["name_c"].ToString().Trim() != "" && row["retchoo"].ToString().Trim() == "2")
                            aRow["nretirerate"] = decimal.Round(nretirerate * 100, 2);
                        if (bool.Parse(row["count_ma"].ToString()) || bool.Parse(row["noret"].ToString()))
                            aRow["noret"] = "V";
                        else
                            aRow["noret"] = "";
                        aRow["r_amt"] = decimal.Round(decimal.Parse(Row["r_amt"].ToString()));
                        aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()));
                        if (decimal.Parse(row["retrate"].ToString())!=0)
                            aRow["retrate"] = decimal.Parse(row["retrate"].ToString());
                        ds.Tables["zz3b"].Rows.Add(aRow);
                        if (out_text)
                        {                           
                            string _YYMMDD = "";
                            string _retrate = "";
                            string _retratea = Convert.ToString(decimal.Round(nretirerate * 100, 0));
                            string _retrateb = "";
                            string _retratec = "";                           
                            string str1 = "";
                            string _name = "";
                            _name = row["name_c"].ToString().Trim();
                            DateTime _Y = DateTime.Parse(row["birdt"].ToString());
                            _YYMMDD = _Y.Year - 1911 + _Y.Month.ToString().PadLeft(2, '0') + "00";
                            string _retchoo = "";
                            if (row["retchoo"].ToString().Trim() == "0")
                                _retchoo = "3";
                            if (row["retchoo"].ToString().Trim() == "1")
                                _retchoo = "2";
                            if (row["retchoo"].ToString().Trim() == "2")
                                _retchoo = "1";
                            if  (decimal.Parse(row["retrate"].ToString()) != 0)
                                _retrate = row["retrate"].ToString();
                            else
                                _retrate = "0";
                            if (decimal.Parse(row["retrate"].ToString().Trim()) != 0)
                                _retrateb = "Y";
                            //else
                            //    _retratec = "";

                            if (bool.Parse(row["count_ma"].ToString().Trim()))
                                _retratec = "Y";
                            else
                            {
                                if (bool.Parse(row["noret"].ToString().Trim()))
                                    _retratec = "Y";
                                else
                                    _retratec = "";
                            }
                            str1 = net_no.Trim() + "," + _name + "," + row["idno"].ToString().Trim() + "," + _YYMMDD + "," + Row["l_amt"].ToString().Trim() + "," + _retchoo + "," + Row["r_amt"].ToString().Trim() + "," + _retrate + "," + _retratea + "," + _retrateb + "," + _retratec + ',';
                            StreamWriter sw = new StreamWriter(net_txt, true, Encoding.Default);
                            sw.WriteLine("" + str1 + ",");
                            sw.Close();
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_inslab = null;

                if (out_text)
                {
                    MessageBox.Show("網路申報轉檔資料,產生完畢!", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                }
                else if (exportexcel)
                {
                    Export(ds.Tables["zz3b"]);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz3b.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateK", date_k) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz3b", ds.Tables["zz3b"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("勞保投保金額", typeof(int));
            ExporDt.Columns.Add("勞退制度", typeof(string));
            ExporDt.Columns.Add("勞退提繳工資", typeof(int));
            ExporDt.Columns.Add("雇主提繳", typeof(string));
            ExporDt.Columns.Add("勞工自願提繳", typeof(string));
            ExporDt.Columns.Add("勞工自提率", typeof(int));
            ExporDt.Columns.Add("不適用勞基法", typeof(string));            
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow["勞保投保金額"] = int.Parse(Row01["l_amt"].ToString());
                if (Row01["retchoo"].ToString().Trim() == "2")
                    aRow["勞退制度"] = "勞退新制";
                else if (Row01["retchoo"].ToString().Trim() == "1")
                    aRow["勞退制度"] = "勞基法舊制";
                else
                    aRow["勞退制度"] = "暫不選擇";
                aRow["勞退提繳工資"] = int.Parse(Row01["r_amt"].ToString());
                aRow["雇主提繳"] = (Row01.IsNull("nretirerate")) ? 0 : decimal.Parse(Row01["nretirerate"].ToString());
                if (!Row01.IsNull("retrate"))
                    aRow["勞工自願提繳"] = (decimal.Parse(Row01["retrate"].ToString()) != 0) ? "是" : "否";
                aRow["勞工自提率"] = (Row01.IsNull("retrate")) ? 0 : decimal.Parse(Row01["retrate"].ToString());
                aRow["不適用勞基法"] = Row01["noret"].ToString();               
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
