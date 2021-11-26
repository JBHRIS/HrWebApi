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
    public partial class FRM74 : JBControls.JBForm
    {
        public FRM74()
        {
            InitializeComponent();
        }

        private void FRM51_Load(object sender, EventArgs e)
        {
            SystemFunction.SetJBComboBoxItems(comboBox9, MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY).ToDictionary(p => p.DATAGROUP, p => p.DATAGROUP1.GROUPNAME));
            this.tBASETableAdapter.Fill(this.medDS.TBASE);
            this.yRHSNTableAdapter.Fill(this.medDS.YRHSN);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.yRERMAKTableAdapter.Fill(this.medDS.YRERMAK);
            this.yRMARKTableAdapter.Fill(this.medDS.YRMARK);
            this.yRIDTableAdapter.Fill(this.medDS.YRID);
            this.yRINATableAdapter.Fill(this.medDS.YRINA);
            this.yRFORSUBTableAdapter.Fill(this.medDS.YRFORSUB);
            this.tYRTAXTableAdapter.FillByInit(this.medDS.TYRTAX);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite("TYRTAX.SALADR");
            fullDataCtrl1.DataAdapter = tYRTAXTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM74A frm51a = new FRM74A();
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
            if (medDS.TYRTAX.Rows.Count == 0)
            {
                MessageBox.Show("請先查詢出指定的年度所得資料(西元年)");
                return;
            }
            string yy = textBox1.Text.Trim().Length == 0 ? "1911" : textBox1.Text;
            string yearString = (int.Parse(yy) - 1911).ToString("000");
            string FileName = @"c:\temp\" + MainForm.CompanyConfig.COMPID + "." + yearString;
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //var sql = (from a in db.TYRTAX
            //           join b in db.TBASE on a.NOBR equals b.NOBR
            //           where a.YEAR == Year.ToString()
            //           select new { a.NOBR,  }).ToList();
            //var BasettsSQL = (from a in db.TYRTAX
            //                  join b in db.BASE on a.NOBR equals b.NOBR
            //                  join c in db.BASETTS on a.NOBR equals c.NOBR
            //                  where a.YEAR == Year.ToString() && b.COUNT_MA//節省效能，只抓外勞
            //                  select c).ToList();

            StreamWriter sw = new StreamWriter(FileName, false, Encoding.Default);
            foreach (MedDS.TYRTAXRow TYRTAXRow in medDS.TYRTAX.Rows)
            {

                string F0103 = TYRTAXRow.F0103.Trim().GetFullLenStr(3);
                string SERIES = TYRTAXRow.SERIES.Trim().GetFullLenStr(8);
                string ID1 = TYRTAXRow.ID1.Trim().GetFullLenStr(8);
                string MARK = TYRTAXRow.MARK.Trim().GetFullLenStr(1);
                string FORMAT = TYRTAXRow.FORMAT.Trim().GetFullLenStr(2);
                string ID = TYRTAXRow.ID.Trim().GetFullLenStr(10);
                string IDCODE = TYRTAXRow.IDCODE.Trim().GetFullLenStr(1);
                string TOT_AMT = Convert.ToInt32(TYRTAXRow.TOT_AMT).ToString().PadLeft(10, '0');
                string TAX_AMT = Convert.ToInt32(TYRTAXRow.TAX_AMT).ToString().PadLeft(10, '0');
                string REL_AMT = Convert.ToInt32(TYRTAXRow.REL_AMT).ToString().PadLeft(10, '0');
                string ACC_NO = TYRTAXRow.ACC_NO.Trim();
                if (FORMAT.Trim() == "9A")
                    ACC_NO = TYRTAXRow.INA_ID.Trim();// + TYRTAXRow.REL_AMT.ToString().PadLeft(10, '0');
                else if (FORMAT.Trim() == "92")
                    ACC_NO = TYRTAXRow.FORSUB.Trim();// +TYRTAXRow.REL_AMT.ToString().PadLeft(10, '0');
                ACC_NO = ACC_NO.ToUpper().GetFullLenStr(12);
                string BLANK_1 = TYRTAXRow.BLANK_1.Trim().GetFullLenStr(1);
                string ERR_MARK = TYRTAXRow.ERR_MARK.Trim().GetFullLenStr(1);
                string YEAR = (Convert.ToInt32(TYRTAXRow.YEAR) - 1911).ToString("000");
                string NAME_C = TYRTAXRow.NAME_C.Trim().GetFullLenStr(40);//所得人姓名/名稱(12->40)
                string ADDR_2 = TYRTAXRow.ADDR_2.Trim().GetFullLenStr(60);
                var Ybs = TYRTAXRow.YEAR_B.Split('/');
                var Yes = TYRTAXRow.YEAR_E.Split('/');
                int YearB = Convert.ToInt32(Ybs[0]) - 1911;
                int MonthB = Convert.ToInt32(Ybs[1]);
                int YearE = Convert.ToInt32(Yes[0]) - 1911;
                int MonthE = Convert.ToInt32(Yes[1]);
                string YYMM = YearB.ToString("000") + MonthB.ToString("00") + YearE.ToString("000") + MonthE.ToString("00");
                string RET_AMT = TYRTAXRow.RET_AMT.ToString().PadLeft(10, '0');
                string Over183 = "".GetFullLenStr(1);
                string Country = "".GetFullLenStr(2);
                DateTime Bdate, Edate;
                Bdate = new DateTime(Year, 1, 1);
                Edate = new DateTime(Year, 12, 31);
                if (TYRTAXRow.IDCODE == "3") Over183 = "Y".GetFullLenStr(1);
                else if (TYRTAXRow.IDCODE == "4") Over183 = "Y".GetFullLenStr(1);
                else if (TYRTAXRow.IDCODE == "7") Over183 = "N".GetFullLenStr(1);
                else Over183 = "".GetFullLenStr(1);

                string SPACE34 = "".GetFullLenStr(38);//(34) 空白(37->49)減掉勞退的10//2013年改成48
                string FormInputType = "3".GetFullLenStr(1);
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
                    MessageBox.Show(Resources.Med.NOBR + TYRTAXRow.ACC_NO + "姓名超過20字", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(Resources.Med.NOBR + TYRTAXRow.ACC_NO + Resources.Med.AddrTooLong, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            sw.Close();

            MessageBox.Show(Resources.All.ExportCompleted + "(" + FileName + ")", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

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
        void Decrypt()
        {
            foreach (var it in medDS.TYRTAX)
            {
                it.REL_AMT = JBModule.Data.CDecryp.Number(it.REL_AMT);
                it.RET_AMT = JBModule.Data.CDecryp.Number(it.RET_AMT);
                it.TAX_AMT = JBModule.Data.CDecryp.Number(it.TAX_AMT);
                it.TOT_AMT = JBModule.Data.CDecryp.Number(it.TOT_AMT);
            }
            medDS.TYRTAX.AcceptChanges();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            /***
             * 新增時，自動顯示目前的最新流水號
             ***/
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.TYRTAX where a.YEAR == textBox1.Text select a.SERIES;
                if (sql.Any())
                {
                    string maxSeries = sql.Max();
                    int iMaxSeries = int.Parse(maxSeries.Substring(1));
                    int newSeries = iMaxSeries + 1;
                    string newSeriesString = maxSeries.Substring(0, 1) + newSeries.ToString();
                    textBox8.Text = newSeriesString;
                }
                else
                {
                    textBox8.Text = "A" + 1.ToString("0000000");
                }
            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                textBox9.Text = e.name;
                comboBox6.SelectedValue = e.dataRowView["NOBR"].ToString();
                comboBox3.SelectedValue = e.dataRowView["IDCODE"].ToString();
                comboBox9.SelectedValue = e.dataRowView["SALADR"].ToString();
            }
        }
    }
}
