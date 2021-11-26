using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections;


namespace JBHR.Reports.InsForm
{
    public partial class ZZ32_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string date_b, date_e, date_t, reporttype, workadr, comp_name, CompId;

        public ZZ32_Report(string dateb, string datee, string datet, string _reporttype, string _workadr, string compname, string _CompId)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; date_t = datet; reporttype = _reporttype;
            workadr = _workadr; comp_name = compname; CompId = _CompId;
        }

        private void ZZ32_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.idno,a.birdt from base a,basetts b";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", DateTime.Now.ToShortDateString());
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                DataTable rq_family = SqlConn.GetDataTable("select nobr,fa_idno,fa_name,fa_birdt,rel_code from family");
                rq_family.PrimaryKey = new DataColumn[] { rq_family.Columns["nobr"], rq_family.Columns["fa_idno"] };

                DataTable rq_inscomp = SqlConn.GetDataTable("select s_no,insno,inspo,insidno,insname,instel,insaddr,inssub from inscomp");
                rq_inscomp.PrimaryKey = new DataColumn[] { rq_inscomp.Columns["s_no"] };

                DataTable rq_insname = SqlConn.GetDataTable("select no,name from insname");
                rq_insname.PrimaryKey = new DataColumn[] { rq_insname.Columns["no"] };

                DataTable rq_usys1 = SqlConn.GetDataTable("select company,compaddr,comptel,helorgname from u_sys1 where comp='" + CompId + "'");
                string company = ""; string compaddr = ""; string comptel = "";
                string helorgname = "";
                if (rq_usys1.Rows.Count > 0)
                {
                    helorgname = rq_usys1.Rows[0]["helorgname"].ToString();
                    company = rq_usys1.Rows[0]["company"].ToString();
                    compaddr = rq_usys1.Rows[0]["compaddr"].ToString();
                    comptel = rq_usys1.Rows[0]["comptel"].ToString();
                }
                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "PDF", "*.pdf");
                string sqlCmd1 = "select * from inslab ";
                if (reporttype=="0")
                    sqlCmd1 += string.Format(@" where in_date='{0}' and code='1'", date_b);
                else if (reporttype == "1")
                    sqlCmd1 += string.Format(@" where out_date='{0}' and code='3'", date_b);
                else if (reporttype == "2")
                    sqlCmd1 += string.Format(@" where in_date='{0}' and fa_idno='' and code='2'", date_b);
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd1);
                rq_inslab.Columns.Add("name_c", typeof(string));
                rq_inslab.Columns.Add("idno", typeof(string));
                rq_inslab.Columns.Add("birdt", typeof(DateTime));
                rq_inslab.Columns.Add("fa_name", typeof(string));
                rq_inslab.Columns.Add("fa_birdt", typeof(DateTime));
                rq_inslab.Columns.Add("rel_code", typeof(string));
                
                foreach (DataRow Row in rq_inslab.Rows)
                {
                    
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["idno"] = row["idno"].ToString();
                        Row["birdt"] = DateTime.Parse(row["birdt"].ToString());

                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["fa_idno"].ToString();
                        DataRow row1 = rq_family.Rows.Find(_value);
                        if (row1 != null)
                        {
                            Row["fa_name"] = row1["fa_name"].ToString();
                            Row["fa_birdt"] = DateTime.Parse(row1["fa_birdt"].ToString());
                            Row["rel_code"] = row1["rel_code"].ToString();
                        }
                        if (DateTime.Parse(Row["birdt"].ToString()).ToString("yyyyMMdd") == "19110101" || Row.IsNull("birdt"))
                            throw new Exception("工號:" + Row["nobr"].ToString() + " " + Row["name_c"].ToString() + " 出生日期有誤或空白");
                    }
                    else
                        Row.Delete();
                   
                }
                rq_inslab.AcceptChanges();

                DataRow[] SRow = rq_inslab.Select("", "idno,fa_idno asc");
                if (reporttype != "2")
                {
                    foreach (DataRow Row in SRow)
                    {
                        DataRow row = rq_inscomp.Rows.Find(Row["s_no"].ToString());
                        DataRow row1 = rq_insname.Rows.Find(Row["code1"].ToString());
                        DataRow aRow = ds.Tables["zz32"].NewRow();
                        aRow["s_no"] = Row["s_no"].ToString();
                        if (row != null)
                        {
                            aRow["insno"] = row["insno"].ToString();
                            aRow["inspo"] = row["inspo"].ToString();
                            aRow["insidno"] = row["insidno"].ToString();
                            aRow["company"] = row["insname"].ToString();
                            aRow["tel"] = row["instel"].ToString();
                            aRow["addr"] = row["insaddr"].ToString();
                            aRow["inssub"] = row["inssub"].ToString();
                        }
                        else
                        {
                            aRow["insno"] = "";
                            aRow["inspo"] = "";
                            aRow["insidno"] = "";
                            aRow["company"] = "";
                            aRow["tel"] = "";
                            aRow["addr"] = "";
                        }
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["idno"] = Row["idno"].ToString();
                        if (!Row.IsNull("birdt")) aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                        aRow["fa_idno"] = Row["fa_idno"].ToString();
                        aRow["fa_name"] = Row["fa_name"].ToString();
                        if (!Row.IsNull("fa_birdt")) aRow["fa_birdt"] = DateTime.Parse(Row["fa_birdt"].ToString());
                        aRow["rel_code"] = Row["rel_code"].ToString();
                        aRow["insname"] = (row1 != null) ? row1["name"].ToString() : "";
                        aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                        aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                        aRow["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                        ds.Tables["zz32"].Rows.Add(aRow);
                    }
                }
                else
                {
                    foreach (DataRow Row in SRow)
                    {
                        DataRow row = rq_inscomp.Rows.Find(Row["s_no"].ToString());
                        DataRow row1 = rq_insname.Rows.Find(Row["code1"].ToString());
                        DataRow aRow = ds.Tables["zz32"].NewRow();
                        aRow["s_no"] = Row["s_no"].ToString();
                        if (row != null)
                        {
                            aRow["insno"] = row["insno"].ToString();
                            aRow["inspo"] = row["inspo"].ToString();
                            aRow["insidno"] = row["insidno"].ToString();
                            aRow["company"] = row["insname"].ToString();
                            aRow["tel"] = row["instel"].ToString();
                            aRow["addr"] = row["insaddr"].ToString();
                            aRow["inssub"] = row["inssub"].ToString();
                        }
                        else
                        {
                            aRow["insno"] = "";
                            aRow["inspo"] = "";
                            aRow["insidno"] = "";
                            aRow["company"] = "";
                            aRow["tel"] = "";
                            aRow["addr"] = "";
                        }
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["idno"] = Row["idno"].ToString();
                        if (!Row.IsNull("birdt")) aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                        aRow["fa_idno"] = Row["fa_idno"].ToString();
                        aRow["fa_name"] = Row["fa_name"].ToString();
                        if (!Row.IsNull("fa_birdt")) aRow["fa_birdt"] = DateTime.Parse(Row["fa_birdt"].ToString());
                        aRow["rel_code"] = Row["rel_code"].ToString();
                        aRow["insname"] = (row1 != null) ? row1["name"].ToString() : "";
                        aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                        aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                        aRow["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                        aRow["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));
                        string sqlCmd2 = "select nobr,h_amt,l_amt from inslab";
                        sqlCmd2 += string.Format(@" where nobr ='{0}'", Row["nobr"].ToString());
                        sqlCmd2 += string.Format(@" and s_no='{0}'", Row["s_no"].ToString());
                        sqlCmd2 += string.Format(@" and in_date <>'{0}'", date_b);
                        sqlCmd2 += " and fa_idno='' order by in_date desc ";
                        DataTable rq_inslaba = SqlConn.GetDataTable(sqlCmd2);
                        if (rq_inslaba != null)
                        {
                            aRow["h_amt1"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(rq_inslaba.Rows[0]["h_amt"].ToString()));
                            aRow["l_amt1"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(rq_inslaba.Rows[0]["l_amt"].ToString()));
                        }
                        else
                        {
                            aRow["h_amt1"] = 0;
                            aRow["l_amt1"] = 0;
                        }
                        ds.Tables["zz32"].Rows.Add(aRow);
                    }
                }
                if (ds.Tables["zz32"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (reporttype == "0")
                    JBHR.Reports.InsForm.ZZ32Class.Get_ZZ32(ds.Tables["zz32"], _rptpath, DateTime.Parse(date_e));
                else if (reporttype == "1")
                    JBHR.Reports.InsForm.ZZ32Class.Get_ZZ321(ds.Tables["zz32"], _rptpath, DateTime.Parse(date_e));
                else if (reporttype == "2")
                    JBHR.Reports.InsForm.ZZ32Class.Get_ZZ322(ds.Tables["zz32"], _rptpath, DateTime.Parse(date_e));
               
                this.Close();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

           
        }

        
        private void FillForm()
        {
            

        }
    }
}
