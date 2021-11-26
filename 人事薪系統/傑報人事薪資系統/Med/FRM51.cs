using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Med
{
    public partial class FRM51 : JBControls.JBForm
    {
        public FRM51()
        {
            InitializeComponent();
        }

        private void FRM51_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mainDS.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.yRMARKTableAdapter.Fill(this.medDS.YRMARK);
            this.yRERMAKTableAdapter.Fill(this.medDS.YRERMAK);
            this.yRIDTableAdapter.Fill(this.medDS.YRID);
            this.cOMPTableAdapter.Fill(this.medDS.COMP);
            this.yRHSNTableAdapter.Fill(this.medDS.YRHSN);
            this.yRINATableAdapter.Fill(this.medDS.YRINA);
            this.yRTAXTableAdapter.FillByInit(this.medDS.YRTAX);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite("YRTAX.SALADR");
            fullDataCtrl1.DataAdapter = yRTAXTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM51A frm51a = new FRM51A();
            frm51a.Owner = this;
            frm51a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("請先查詢出指定的年度所得資料(西元年)");
                return;
            }
            int Year = Convert.ToInt32(textBox1.Text);
            if (Year <= 1911)
            {
                MessageBox.Show("查詢年度請以西元年表示");
                return;
            }
            if (medDS.YRTAX.Rows.Count == 0)
            {
                MessageBox.Show("請先查詢出指定的年度所得資料(西元年)");
                return;
            }
            string yy = textBox1.Text.Trim().Length == 0 ? "1911" : textBox1.Text;
            string yearString = (int.Parse(yy) - 1911).ToString("000");

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.YRTAX
                       join b in db.BASE on a.NOBR equals b.NOBR
                       where a.YEAR == Year.ToString()
                      && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       select new { a.NOBR, b.COUNT_MA, b.COUNTRY, b.IDNO }).ToList();
            var BasettsSQL = (from a in db.YRTAX
                              join b in db.BASE on a.NOBR equals b.NOBR
                              join c in db.BASETTS on a.NOBR equals c.NOBR
                              where a.YEAR == Year.ToString() && b.COUNT_MA//節省效能，只抓外勞
                              && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              select c).ToList();
            var yrtaxGroup = from a in medDS.YRTAX group a by a.COMP;
            foreach (var gpTax in yrtaxGroup)
            {
                string FileName = @"c:\temp\" + gpTax.First().ID1 + "." + yearString;
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.Default);
                foreach (MedDS.YRTAXRow YRTAXRow in gpTax)
                {
                    if (!YRTAXRow.T_OK)
                    {
                        string F0103 = YRTAXRow.F0103.Trim().GetFullLenStr(3);
                        string SERIES = YRTAXRow.SERIES.Trim().GetFullLenStr(8);
                        string ID1 = YRTAXRow.ID1.Trim().GetFullLenStr(8);
                        string MARK = YRTAXRow.MARK.Trim().GetFullLenStr(1);
                        string FORMAT = YRTAXRow.FORMAT.Trim().GetFullLenStr(2);
                        string ID = YRTAXRow.ID.Trim().GetFullLenStr(10);
                        string IDCODE = YRTAXRow.IDCODE.Trim().GetFullLenStr(1);
                        string TOT_AMT = YRTAXRow.TOT_AMT.ToString().PadLeft(10, '0');
                        string TAX_AMT = YRTAXRow.TAX_AMT.ToString().PadLeft(10, '0');
                        string REL_AMT = YRTAXRow.REL_AMT.ToString().PadLeft(10, '0');
                        string ACC_NO = YRTAXRow.ACC_NO.Trim().GetFullLenStr(12);
                        string BLANK_1 = YRTAXRow.BLANK_1.Trim().GetFullLenStr(1);
                        string ERR_MARK = YRTAXRow.ERR_MARK.Trim().GetFullLenStr(1);
                        string YEAR = (Convert.ToInt32(YRTAXRow.YEAR) - 1911).ToString("000");
                        string NAME_C = YRTAXRow.NAME_C.Trim().GetFullLenStr(40);//所得人姓名/名稱(12->40)
                        if (NAME_C.Trim().Length > 20) NAME_C = NAME_C.Substring(20).GetFullLenStr(40);//截斷
                        string ADDR_2 = YRTAXRow.ADDR_2.Trim().GetFullLenStr(60);
                        var Ybs = YRTAXRow.YEAR_B.Split('/');
                        var Yes = YRTAXRow.YEAR_E.Split('/');
                        int YearB = Convert.ToInt32(Ybs[0]) - 1911;
                        int MonthB = Convert.ToInt32(Ybs[1]);
                        int YearE = Convert.ToInt32(Yes[0]) - 1911;
                        int MonthE = Convert.ToInt32(Yes[1]);
                        string YYMM = YearB.ToString("000") + MonthB.ToString("00") + YearE.ToString("000") + MonthE.ToString("00");
                        string RET_AMT = YRTAXRow.RET_AMT.ToString().PadLeft(10, '0');
                        string Over183 = "".GetFullLenStr(1);
                        string Country = "".GetFullLenStr(2);
                        var BaseData = sql.Where(p => p.NOBR == YRTAXRow.NOBR);
                        if (BaseData.Any())
                        {
                            var baseRow = BaseData.First();
                            bool isForeign = false;
                            if (baseRow.IDNO.Trim().Length > 2)
                            {
                                int result = 0;
                                string cc = baseRow.IDNO.Substring(1, 1);
                                if (!int.TryParse(cc, out result))
                                    isForeign = true;
                            }
                            if (baseRow.COUNT_MA || isForeign)
                            {
                                var basettsData = BasettsSQL.Where(p => p.NOBR == YRTAXRow.NOBR);
                                DateTime Bdate, Edate, TaxBdate, TaxEdate;
                                Bdate = new DateTime(Year, 1, 1);
                                Edate = new DateTime(Year, 12, 31);
                                Dictionary<DateTime, DateTime> TaxDateRange = new Dictionary<DateTime, DateTime>();
                                int days = 0;
                                //國家代碼〆證號別為【５】【６】【７】【８】【９】時，本欄應為【２位】
                                //國家代碼（應在本作業要點附伔４１之範圍內，若無法查明所得人之國家代碼
                                //資料，請填報「ＺＺ其他國家」），其他證號別時本欄為空白。 

                                //Country = "".GetFullLenStr(2);
                                foreach (var rr in basettsData)
                                {
                                    if (rr.TAX_DATE != null && rr.TAX_EDATE != null)
                                        if (!TaxDateRange.ContainsKey(rr.TAX_DATE.Value)) //相同的區間不考慮
                                        {
                                            TaxDateRange.Add(rr.TAX_DATE.Value, rr.TAX_EDATE.Value);
                                            TaxBdate = rr.TAX_DATE.Value;
                                            TaxEdate = rr.TAX_EDATE.Value;
                                            days += Sal.Function.RangeMix(Bdate, Edate, TaxBdate, TaxEdate);
                                        }
                                }
                                if (days > MainForm.TaxConfig.ENTRYDAY.Value) Over183 = "Y".GetFullLenStr(1);
                                else Over183 = "N".GetFullLenStr(1);
                            }
                        }

                        string SPACE34 = "".GetFullLenStr(38);//(34) 空白(37->49)減掉勞退的10//2013年改成48
                        string FormInputType = "2".GetFullLenStr(1);
                        string DATE = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        string RENT = "".GetFullLenStr(2);
                        string SPACE = "".GetFullLenStr(2);
                        ADDR_2 = ADDR_2.Replace(" ", "");
                        ADDR_2 = ADDR_2.Replace("(", "");
                        ADDR_2 = ADDR_2.Replace(")", "");
                        ADDR_2 = ADDR_2.Replace("#", "");
                        ADDR_2 = ADDR_2.Replace("@", "");
                        ADDR_2 = ADDR_2.Replace("*", "");
                        ADDR_2 = ADDR_2.Replace("?", "㊣");
                        try
                        {
                            if (NAME_C.Trim().Length > 20)
                                throw new Exception("姓名超過20字");
                        }
                        catch
                        {
                            MessageBox.Show(Resources.Med.NOBR + YRTAXRow.ACC_NO + "姓名超過20字", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sw.Close();
                            return;
                        }
                        try
                        {

                            ADDR_2 = Microsoft.VisualBasic.Strings.StrConv(ADDR_2, Microsoft.VisualBasic.VbStrConv.Wide, System.Globalization.CultureInfo.CurrentUICulture.LCID);
                            ADDR_2 = ADDR_2.GetFullLenStr(60);
                            if (ADDR_2.Trim().Length > 30)
                                throw new Exception("地址超過30字");
                        }
                        catch
                        {
                            MessageBox.Show(Resources.Med.NOBR + YRTAXRow.ACC_NO + Resources.Med.AddrTooLong, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            sw.Close();
                            return;
                        }

                        NAME_C = NAME_C.Replace("(", "");
                        NAME_C = NAME_C.Replace(")", "");
                        NAME_C = NAME_C.Replace("#", "");
                        NAME_C = NAME_C.Replace("@", "");
                        NAME_C = NAME_C.Replace("*", "");
                        NAME_C = NAME_C.Replace("?", "㊣");
                        NAME_C = Microsoft.VisualBasic.Strings.StrConv(NAME_C, Microsoft.VisualBasic.VbStrConv.Wide, System.Globalization.CultureInfo.CurrentUICulture.LCID);
                        NAME_C = NAME_C.GetFullLenStr(40);//所得人姓名/名稱(12->40)

                        string wStr = F0103 + SERIES + ID1 + MARK + FORMAT + ID + IDCODE + TOT_AMT + TAX_AMT + REL_AMT + ACC_NO + BLANK_1 + ERR_MARK +
                            YEAR + NAME_C + ADDR_2 + YYMM + RET_AMT + SPACE34 + FormInputType + Over183 + Country + RENT + SPACE + DATE;
                        sw.WriteLine(wStr);
                    }
                }
                sw.Close();

                MessageBox.Show(Resources.All.ExportCompleted + "(" + FileName + ")", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            foreach (var row in this.medDS.YRTAX)
            {
                row.TOT_AMT = JBModule.Data.CDecryp.Number(row.TOT_AMT);
                row.TAX_AMT = JBModule.Data.CDecryp.Number(row.TAX_AMT);
                row.REL_AMT = JBModule.Data.CDecryp.Number(row.REL_AMT);
                row.RET_AMT = JBModule.Data.CDecryp.Number(row.RET_AMT);
            }

            //filterData();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            foreach (var row in this.medDS.YRTAX)
            {
                row.TOT_AMT = JBModule.Data.CDecryp.Number(row.TOT_AMT);
                row.TAX_AMT = JBModule.Data.CDecryp.Number(row.TAX_AMT);
                row.REL_AMT = JBModule.Data.CDecryp.Number(row.REL_AMT);
                row.RET_AMT = JBModule.Data.CDecryp.Number(row.RET_AMT);
            }

            //filterData();
        }

        //private void filterData()
        //{
        //    if (!MainForm.MANGSUPER)
        //    {
        //        BasDataClassesDataContext db = new BasDataClassesDataContext();

        //        DataTable dt = (yRTAXBindingSource.DataSource as DataSet).Tables[yRTAXBindingSource.DataMember];
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
        //            if (data == null)
        //            {
        //                row.Delete();
        //            }
        //        }

        //        dt.AcceptChanges();

        //        fullDataCtrl1.Init_Ctrls();
        //    }
        //}

        private bool checkSavePower(string nobr)
        {
            return Sal.Function.CanModify(nobr);
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!checkSavePower(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!e.Cancel)
            {
                e.Values["TOT_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["TOT_AMT"]));
                e.Values["TAX_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["TAX_AMT"]));
                e.Values["REL_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["REL_AMT"]));
                e.Values["RET_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["RET_AMT"]));

                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

                e.Values["TOT_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["TOT_AMT"]));
                e.Values["TAX_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["TAX_AMT"]));
                e.Values["REL_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["REL_AMT"]));
                e.Values["RET_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["RET_AMT"]));
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }
    }

    //static class Ext
    //{
    //    public static string GetFullLenStr(this string str, int len)
    //    {
    //        byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());

    //        string emptyStr = "".PadRight(len - bytes.Length, ' ');
    //        string ss = str.Trim() + emptyStr;
    //        return ss;
    //    }
    //}
}
