using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ48_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, saladr_b, saladr_e,emp_b,emp_e, attdate_b, attdate_e, date_b, yymm, year, month, seq, workadr, type_data, comp_name, CompId;
        bool exportexcel;
        public ZZ48_Report(string nobrb, string nobre, string deptb, string depte, string saladrb, string saladre,string empb,string empe,string attdateb,string attdatee, string dateb, string _year, string _month, string _seq, string _workadr, string typedata, string compname, string _CompId, bool _exportexcel)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; saladr_b = saladrb; saladr_e = saladre;
            date_b = dateb; yymm = _year + _month; seq = _seq; type_data = typedata; attdate_b = attdateb;
            attdate_e = attdatee; comp_name = compname; CompId = _CompId; exportexcel = _exportexcel; workadr = _workadr;
            year = _year; month = _month; emp_b = empb; emp_e = empe;
        }

        private void ZZ48_Report_Load(object sender, EventArgs e)
        {            
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name";
                sqlCmd += " from base a,basetts b ";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate ", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //薪資相關代碼
                string CmdSalcode = "select a.sal_code,a.sal_code_disp,a.sal_name,b.salattr,b.flag,b.type,b.tax,";
                CmdSalcode += "a.retire,a.forbank,a.forcash,a.acccd,c.accname ";
                CmdSalcode += " from salcode a,salattr b,acccd c where a.sal_attr=b.salattr and a.acccd=c.acccd";
                DataTable rq_salcode = SqlConn.GetDataTable(CmdSalcode);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //薪資主檔
                string CmdWage = "select nobr,yymm,seq,saladr,taxrate ";
                CmdWage += string.Format(@" from wage where yymm='{0}' and seq='{1}'", yymm, seq);
                CmdWage += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWage += string.Format(@" and saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                CmdWage += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(CmdWage);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };               

                //薪資明細資料
                string CmdWaged = "select nobr,yymm,seq,sal_code,amt from waged where ";
                CmdWaged += string.Format(@" yymm ='{0}' and seq='{1}'", yymm, seq);
                CmdWaged += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWaged += " and sal_code <> '' and amt <> 10 order by nobr";
                DataTable rq_waged = SqlConn.GetDataTable(CmdWaged);
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("job", typeof(string));
                rq_waged.Columns.Add("job_name", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));

                //出勤曠職、早退、遲到(次)
                DataTable rq_attenda = JBHR.Reports.SalForm.ZZ48Class.Get_Attenda(nobr_b, nobr_e, attdate_b, attdate_e);

                //曠職假資料
                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2G", MainForm.COMPANY);
                var AbsenceCode = AppConfig.GetConfig("AbsenceCode").GetString();
                string CmdAbs2 = "select a.nobr,b.h_code_disp as h_code,b.h_name,sum(a.tol_hours) as abs_hrs";
                CmdAbs2 += " from abs a,hcode b where a.h_code=b.h_code";
                CmdAbs2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdAbs2 += string.Format(@" and a.yymm ='{0}'", yymm);
                CmdAbs2 += string.Format(@" and a.h_code ='{0}'", AbsenceCode);
                CmdAbs2 += " group by a.nobr,b.h_code_disp,b.h_name";
                CmdAbs2 += " order by b.h_code_disp";
                DataTable rq_absa = SqlConn.GetDataTable(CmdAbs2);
                rq_absa.PrimaryKey = new DataColumn[] { rq_absa.Columns["nobr"] };                
               
                DataTable rq_attend = new DataTable();
                rq_attend.Columns.Add("nobr", typeof(string));
                rq_attend.Columns.Add("abs", typeof(int));
                rq_attend.Columns.Add("e_mins", typeof(int));
                rq_attend.Columns.Add("late_mins", typeof(int));
                rq_attend.Columns.Add("abshrs", typeof(decimal));
                JBHR.Reports.SalForm.ZZ48Class.Get_Attend(rq_attend, rq_attenda,rq_absa);
                
                //請假明細資料
                string CmdAbs = "select a.nobr,b.h_code_disp as h_code,b.h_name,sum(a.tol_hours) as abs_hrs";
                CmdAbs += " from abs a,hcode b where a.h_code=b.h_code";
                CmdAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdAbs += string.Format(@" and a.yymm ='{0}'", yymm);
                CmdAbs += " and b.year_rest not in ('1','3','5')";
                CmdAbs += " group by a.nobr,b.h_code_disp,b.h_name";
                CmdAbs += " order by b.h_code_disp";
                DataTable rq_abs = SqlConn.GetDataTable(CmdAbs);

                string absdateb = year + "/01/01";
                string absdatee = year + "/12/31";
                //請假特休得
                string CmdAbs1 = "select a.nobr,sum(a.tol_hours) as abs_hrs";
                CmdAbs1 += " from abs a,hcode b where a.h_code=b.h_code";
                CmdAbs1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdAbs1 += string.Format(@" and a.bdate between '{0}' and '{1}'", absdateb, absdatee);
                CmdAbs1 += " and b.year_rest='1' group by a.nobr";
                DataTable rq_abs1 = SqlConn.GetDataTable(CmdAbs1);
                rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };

                //加班時數明細資料
                DataTable rq_ota = JBHR.Reports.SalForm.ZZ48Class.Get_Ota(nobr_b, nobr_e, yymm);
                DataTable rq_ot = new DataTable();                
                rq_ot.Columns.Add("nobr", typeof(string));
                rq_ot.Columns.Add("ot_100", typeof(decimal));
                rq_ot.Columns.Add("ot_133", typeof(decimal));
                rq_ot.Columns.Add("ot_167", typeof(decimal));
                rq_ot.Columns.Add("ot_200", typeof(decimal));
                rq_ot.Columns.Add("ot_200_h", typeof(decimal));
                rq_ot.Columns.Add("total", typeof(decimal));
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
                JBHR.Reports.SalForm.ZZ48Class.Get_Ot(rq_ot, rq_ota, rq_wage);
                //JBHR.Reports.ReportClass.Export(rq_ot, this.Name);

                //加班費及補休時數
                DataTable rq_ot1 = JBHR.Reports.SalForm.ZZ48Class.Get_Otb(nobr_b, nobr_e, yymm);
                rq_ot1.PrimaryKey = new DataColumn[] { rq_ot1.Columns["nobr"] };                

                //薪資表頭
                DataTable rq_wagetitle = new DataTable();                
                rq_wagetitle.Columns.Add("sal_code", typeof(string));
                rq_wagetitle.Columns.Add("sal_name", typeof(string));
                rq_wagetitle.PrimaryKey = new DataColumn[] { rq_wagetitle.Columns["sal_code"] };
                

                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                    if (row == null || row1 == null)
                        Row.Delete();
                    else
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            if (row2["flag"].ToString() == "-")
                                Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                            else
                                Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        }
                        else
                        {
                            string ErrorSalcode = "無" + Row["sal_code"].ToString() + "薪資代碼或與會計科目未關聯";
                            MessageBox.Show(ErrorSalcode, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorSalcode);
                            this.Close();
                            return;
                        }

                        string str_salcode = Row["salattr"].ToString().Trim() + Row["sal_code"].ToString().Trim();
                        DataRow row3 = rq_wagetitle.Rows.Find(str_salcode);
                        if (row3 == null)
                        {
                            DataRow aRow = rq_wagetitle.NewRow();                            
                            aRow["sal_code"] = str_salcode;
                            aRow["sal_name"] = Row["sal_name"].ToString();
                            rq_wagetitle.Rows.Add(aRow);
                        }
                    }
                }
                rq_waged.AcceptChanges();
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //求得應發合計金額
                DataTable rq_sys41 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                string retsalcode = "";
                if (rq_sys41.Rows.Count > 0)
                {
                    DataRow row1 = rq_salcode.Rows.Find(rq_sys41.Rows[0]["retsalcode"].ToString());
                    if (row1 != null)
                        retsalcode = row1["sal_code_disp"].ToString();
                }
                //應稅合計金額
                DataTable rq_wageds1 = new DataTable();
                rq_wageds1.Columns.Add("nobr", typeof(string));
                rq_wageds1.Columns.Add("tot1", typeof(decimal));
                rq_wageds1.PrimaryKey = new DataColumn[] { rq_wageds1.Columns["nobr"] };
                JBHR.Reports.SalForm.ZZ48Class.Get_wageds1(rq_wageds1,rq_waged, rq_base);

                //求得應發合計金額
                DataTable rq_wageds2 = new DataTable();
                rq_wageds2.Columns.Add("nobr", typeof(string));
                rq_wageds2.Columns.Add("tot2", typeof(decimal));
                rq_wageds2.PrimaryKey = new DataColumn[] { rq_wageds2.Columns["nobr"] };
                JBHR.Reports.SalForm.ZZ48Class.Get_wageds2(rq_wageds2, rq_waged, rq_base, retsalcode);

                //求得實發合計金額
                DataTable rq_wagedsz = new DataTable();
                rq_wagedsz.Columns.Add("nobr", typeof(string));
                rq_wagedsz.Columns.Add("totz", typeof(decimal));
                rq_wagedsz.PrimaryKey = new DataColumn[] { rq_wagedsz.Columns["nobr"] };
                JBHR.Reports.SalForm.ZZ48Class.Get_wagedsz(rq_wagedsz, rq_waged, rq_base);

                //薪資表頭
                DataRow aRow1 = rq_wagetitle.NewRow();
                aRow1["sal_code"] = "F";
                aRow1["sal_name"] = "應稅薪資";
                rq_wagetitle.Rows.Add(aRow1);

                DataRow aRow2 = rq_wagetitle.NewRow();
                aRow2["sal_code"] = "L";
                aRow2["sal_name"] = "應發薪資";
                rq_wagetitle.Rows.Add(aRow2);

                DataRow aRow3 = rq_wagetitle.NewRow();
                aRow3["sal_code"] = "O";
                aRow3["sal_name"] = "實發薪資";
                rq_wagetitle.Rows.Add(aRow3);

                DataTable rq_wagetitlea=new DataTable();
                rq_wagetitlea.Columns.Add("sal_name",typeof(string));
                rq_wagetitlea.PrimaryKey = new DataColumn[] { rq_wagetitlea.Columns["sal_name"] };

                DataRow[] SRow = rq_wagetitle.Select("", "sal_code asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow row = rq_wagetitlea.Rows.Find(Row["sal_name"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_wagetitlea.NewRow();
                        aRow["sal_name"] = Row["sal_name"].ToString();
                        rq_wagetitlea.Rows.Add(aRow);
                    }
                }
                
                //請假資料表頭
                DataTable rq_abstitle = new DataTable();
                rq_abstitle.Columns.Add("h_name", typeof(string));
                rq_abstitle.PrimaryKey = new DataColumn[] { rq_abstitle.Columns["h_name"] };
                foreach(DataRow Row in rq_abs.Rows)
                {
                    string _hcodename = Row["h_code"].ToString().Trim() + Row["h_name"].ToString().Trim();
                    DataRow row = rq_abstitle.Rows.Find(_hcodename);
                    if (row == null)
                    {
                        DataRow aRow = rq_abstitle.NewRow();
                        aRow["h_name"] = _hcodename;
                        rq_abstitle.Rows.Add(aRow);
                    }
                }
                
                DataRow aRowt = ds.Tables["zz48ta"].NewRow();
                for (int i = 0; i < rq_abstitle.Rows.Count; i++)
                {
                    aRowt["Fld" + (i + 1)] = rq_abstitle.Rows[i]["h_name"].ToString();
                }
                aRowt["Fld" + (rq_abstitle.Rows.Count + 1)] = "加班1倍";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 2)] = "加班1.33倍";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 3)] = "加班1.67倍";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 4)] = "加班2倍";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 5)] = "假日加班";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 6)] = "加班總時數";
                aRowt["Fld" + (rq_abstitle.Rows.Count + 7)] = "總計補休";

                int _tilecnt = rq_abstitle.Rows.Count + 8;
                foreach (DataRow Row in rq_wagetitlea.Rows)
                {
                    aRowt["Fld" + _tilecnt] = Row["sal_name"].ToString().Trim();
                    _tilecnt += 1;
                }
                ds.Tables["zz48ta"].Rows.Add(aRowt);

                ds.Tables["zz48td"].PrimaryKey = new DataColumn[] { ds.Tables["zz48td"].Columns["nobr"] };
                JBHR.Reports.SalForm.ZZ48Class.Get_zz48td(ds.Tables["zz48td"], ds.Tables["zz48ta"], rq_waged, rq_wageds1, rq_wageds2, rq_wagedsz, rq_attend, rq_abs,rq_abs1, rq_ot, rq_ot1, rq_abstitle.Rows.Count);
                JBHR.Reports.SalForm.ZZ48Class.ExPort(ds.Tables["zz48td"], ds.Tables["zz48ta"], this.Name);

                rq_abs = null; rq_abs1 = null; rq_abstitle = null; rq_attend = null; rq_attenda = null; rq_base = null; rq_ot = null;
                rq_ot = null; rq_ot1 = null; rq_ota = null;  rq_salcode = null; rq_sys41 = null; rq_wage = null;
                rq_waged = null; rq_wageds1 = null; rq_wageds2 = null; rq_wagedsz = null; rq_wagetitle = null; rq_wagetitlea = null;
                rq_absa = null;
                ds.Tables.Remove("zz48td"); ds.Tables.Remove("zz48ta");
                this.Close();
                
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }
    }
}
