using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ26_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string comp_b, comp_e, dept_b, dept_e, h_codeb, h_codee, saladr_b, saladr_e, date_b, date_e, type_data, username, comp_name;
        bool exportexcel;
        public ZZ26_Report(string compb, string compe, string deptb, string depte, string hcodeb, string hcodee, string saladrb, string saladre, string dateb, string datee, bool _exportexcel, string typedata, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; h_codeb = hcodeb;
            h_codee = hcodee; date_b = dateb; date_e = datee; exportexcel = _exportexcel;
            type_data = typedata; username = _username; comp_b = compb; comp_e = compe;
            saladr_b = saladrb; saladr_e = saladre; comp_name = compname;
        }

        private void ZZ26_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                string CmdBasetts = "select b.nobr,c.d_no_disp as dept,c.d_name from basetts b,dept c";
                CmdBasetts += " where b.dept=c.d_no";
                CmdBasetts += string.Format(@" and '{0}' between b.adate and b.ddate",DateTime.Now.ToShortDateString());
                CmdBasetts += string.Format(@" and b.comp between '{0}' and '{1}' ", comp_b, comp_e);
                CmdBasetts += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                CmdBasetts += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                CmdBasetts += type_data;
                DataTable rq_basetts = SqlConn.GetDataTable(CmdBasetts);
                rq_basetts.PrimaryKey = new DataColumn[] { rq_basetts.Columns["nobr"] };

                string sqlCmd = "SELECT C.d_no_disp AS OT_DEPT,A.OTRCD,A.NOBR,SUM(OT_HRS+REST_HRS) AS TOL_HOURS,C.D_NAME" +
                          " FROM DEPTS C,OT A" +
                         " LEFT OUTER JOIN OTRCD D ON A.OTRCD=D.OTRCD" +
                         " WHERE A.OT_DEPT=C.D_NO AND  A.BDATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                          " AND  D.OTRCD_DISP BETWEEN '" + h_codeb + "' AND '" + h_codee + "'" +
                    //" AND A.OTRCD BETWEEN '" + h_codeb + "' AND '" + h_codee + "'" +                         
                    //" AND A.OT_DEPT=SUBSTRING(C.D_NO,1,6)" +
                         " GROUP BY C.d_no_disp,A.OTRCD,A.NOBR,C.D_NAME" +
                         " ORDER BY C.d_no_disp,A.OTRCD";
                DataTable rq_ota = SqlConn.GetDataTable(sqlCmd);
                rq_ota.Columns.Add("otrname", typeof(string));
                

                DataTable rq_otrcd = SqlConn.GetDataTable("select otrcd,otrname from otrcd");
                rq_otrcd.PrimaryKey = new DataColumn[] { rq_otrcd.Columns["otrcd"] };

                DataTable rq_ot = new DataTable();
                rq_ot.Columns.Add("ot_dept", typeof(string));
                rq_ot.Columns.Add("otrcd", typeof(string));
                rq_ot.Columns.Add("tol_hours", typeof(decimal));
                rq_ot.Columns.Add("d_name", typeof(string));                
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["ot_dept"], rq_ot.Columns["otrcd"] };

                DataTable rq_ot1 = new DataTable();
                rq_ot1.Columns.Add("otrcd", typeof(string));
                rq_ot1.Columns.Add("otrname", typeof(string));
                rq_ot1.PrimaryKey = new DataColumn[] { rq_ot1.Columns["otrcd"]};
                foreach (DataRow Row in rq_ota.Rows)
                {
                    DataRow row = rq_basetts.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_otrcd.Rows.Find(Row["otrcd"].ToString());
                    Row["otrname"] = (row2 != null) ? row2["otrname"].ToString() : "";
                    if (row != null)
                    {
                        Row["ot_dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        object[] _value = new object[2];
                        _value[0] = Row["ot_dept"].ToString();
                        _value[1] = Row["otrcd"].ToString();
                        DataRow row1 = rq_ot.Rows.Find(_value);
                        if (row1 != null)
                            row1["tol_hours"] = decimal.Parse(row1["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                        else
                        {
                            DataRow aRow = rq_ot.NewRow();
                            aRow["ot_dept"] = Row["ot_dept"].ToString();
                            aRow["otrcd"] = Row["otrcd"].ToString();
                            aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                            aRow["d_name"] = Row["d_name"].ToString();                           
                            rq_ot.Rows.Add(aRow);
                        }
                    }
                }

                DataRow[] ORow = rq_ota.Select("", "otrcd asc");
                foreach(DataRow  Row in ORow)
                {
                    DataRow row = rq_basetts.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1 = rq_ot1.Rows.Find(Row["otrcd"].ToString());                        
                        if (row1 == null)
                        {
                            DataRow aRow = rq_ot1.NewRow();
                            aRow["otrcd"] = Row["otrcd"].ToString();
                            DataRow row2=rq_otrcd.Rows.Find(Row["otrcd"].ToString());
                            aRow["otrname"] = (!Row.IsNull("otrname")) ? Row["otrname"].ToString() : "";
                            rq_ot1.Rows.Add(aRow);
                        }
                    }
                }
                rq_basetts = null; rq_ota = null; rq_otrcd = null;
                Hashtable ht = new Hashtable();

                DataTable zz26d = new DataTable("zz26d");
                zz26d.Columns.Add("ot_dept", typeof(string));
                zz26d.Columns.Add("d_name", typeof(string));
                int ste = rq_ot1.Rows.Count;

                CultureInfo MyCultureInfo = new CultureInfo("en-GB");
                double result;
                for (int i = 0; i < rq_ot1.Rows.Count; i++)
                {
                    if (!Double.TryParse(rq_ot1.Rows[i][0].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                        zz26d.Columns.Add(rq_ot1.Rows[i][0].ToString().Trim(), typeof(decimal));
                    else
                        zz26d.Columns.Add("C_" + rq_ot1.Rows[i][0].ToString().Trim(), typeof(decimal));
                    ht.Add("Fld" + (i + 1), rq_ot1.Rows[i][1].ToString());
                }
                rq_ot1 = null;

                zz26d.PrimaryKey = new DataColumn[2] { zz26d.Columns["ot_dept"], zz26d.Columns["d_name"] };
                for (int j = 0; j < rq_ot.Rows.Count; j++)
                {
                    object[] _value = new object[2];
                    _value[0] = rq_ot.Rows[j]["ot_dept"].ToString();
                    _value[1] = rq_ot.Rows[j]["d_name"].ToString();
                    DataRow row1 = zz26d.Rows.Find(_value);
                    if (row1 == null)
                    {
                        DataRow aRow = zz26d.NewRow();
                        aRow["ot_dept"] = rq_ot.Rows[j]["ot_dept"].ToString();
                        aRow["d_name"] = rq_ot.Rows[j]["d_name"].ToString();
                        if (!Double.TryParse(rq_ot.Rows[j]["otrcd"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                            aRow[rq_ot.Rows[j]["otrcd"].ToString()] = rq_ot.Rows[j]["tol_hours"].ToString();
                        else
                            aRow["C_" + rq_ot.Rows[j]["otrcd"].ToString()] = rq_ot.Rows[j]["tol_hours"].ToString();
                        zz26d.Rows.Add(aRow);

                    }
                    else
                    {
                        DataRow aRow = row1;
                        if (!Double.TryParse(rq_ot.Rows[j]["otrcd"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                            aRow[rq_ot.Rows[j]["otrcd"].ToString()] = rq_ot.Rows[j]["tol_hours"].ToString();
                        else
                            aRow["C_" + rq_ot.Rows[j]["otrcd"].ToString()] = rq_ot.Rows[j]["tol_hours"].ToString();
                    }
                }
                rq_ot = null;

                DataRow aRow1 = ds.Tables["zz261"].NewRow();
                for (int i = 0; i < ht.Count; i++)
                {
                    string ss = ht["Fld" + (i + 1)].ToString();
                    aRow1["Fld" + (i + 1)] = ht["Fld" + (i + 1)].ToString();
                }

                ds.Tables["zz261"].Rows.Add(aRow1);

                for (int i = 0; i < zz26d.Rows.Count; i++)
                {
                    DataRow aRow2 = ds.Tables["zz26"].NewRow();
                    aRow2["ot_dept"] = zz26d.Rows[i]["ot_dept"].ToString();
                    aRow2["d_name"] = zz26d.Rows[i]["d_name"].ToString();
                    for (int j = 2; j < zz26d.Columns.Count; j++)
                    {
                        if (zz26d.Rows[i][zz26d.Columns[j].ColumnName].ToString().Length == 0)
                            aRow2["Fld" + (j - 1)] = 0;
                        else
                            aRow2["Fld" + (j - 1)] = Decimal.Parse(zz26d.Rows[i][zz26d.Columns[j].ColumnName].ToString());
                    }
                    ds.Tables["zz26"].Rows.Add(aRow2);
                }
                zz26d = null;
                if (ds.Tables["zz26"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {                    
                    Export(ds.Tables["zz26"], ds.Tables["zz261"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz26.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz26", ds.Tables["zz26"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz261", ds.Tables["zz261"]));
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
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(decimal));
                else
                    break;
            }
            

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["ot_dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString()] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            DT = null;
            DT1 = null;
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
