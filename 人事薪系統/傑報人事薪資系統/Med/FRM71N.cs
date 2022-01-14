using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JBControls.Forms;

namespace JBHR.Med
{
    public partial class FRM71N : JBControls.JBForm
    {
        public FRM71N()
        {
            InitializeComponent();
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey == null)
            {
                MessageBox.Show("請先選擇主檔資料");
                return;
            }
            FRM71N1 frm = new FRM71N1();
            frm.TW_TAX_Auto = Convert.ToInt32(jbQuery1.SelectedKey);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey == null)
            {
                MessageBox.Show("請先選擇主檔資料");
                return;
            }
            FRM71N2 frm = new FRM71N2();
            frm.TW_TAX_Auto = Convert.ToInt32(jbQuery1.SelectedKey);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var TaxDataMain = db.TW_TAX.SingleOrDefault(a => a.AUTO == Convert.ToInt32(jbQuery1.SelectedKey));
            var TaxData1 = (from a in db.TW_TAX_SUMMARY
                           join b in db.BASE on a.NOBR equals b.NOBR into _base
                           from bas in _base.DefaultIfEmpty()
                               //join country in db.COUNTCD on bas.COUNTRY equals country.CODE into _ct
                               //from ct in _ct.DefaultIfEmpty()
                           where a.PID == Convert.ToInt32(jbQuery1.SelectedKey) && !a.IS_FILE
                           select new
                           {
                               a.COMP,
                               a.ADDR2,
                               a.AMT,
                               a.ID,
                               a.ID1,
                               a.IDCODE,
                               a.IS_FILE,
                               a.NAME_C,
                               a.NOBR,
                               a.POST2,
                               a.F0103,
                               a.F0407,
                               a.FORMAT,
                               a.SERIES,
                               a.D_AMT,
                               a.SUBCODE,
                               a.TAXNO,
                               a.RET_AMT,

                               Country = bas != null ? bas.COUNTRY : ""
                           });
            var TaxData = (from a in db.TW_TAX_SUMMARY
                           join b in db.BASE on a.NOBR equals b.NOBR into _base
                           from bas in _base.DefaultIfEmpty()
                               //join country in db.COUNTCD on bas.COUNTRY equals country.CODE into _ct
                               //from ct in _ct.DefaultIfEmpty()
                           where a.PID == Convert.ToInt32(jbQuery1.SelectedKey) && !a.IS_FILE
                           select new
                           {
                               a.COMP,
                               a.ADDR2,
                               a.AMT,
                               a.ID,
                               a.ID1,
                               a.IDCODE,
                               a.IS_FILE,
                               a.NAME_C,
                               a.NOBR,
                               a.POST2,
                               a.F0103,
                               a.F0407,
                               a.FORMAT,
                               a.SERIES,
                               a.D_AMT,
                               a.SUBCODE,
                               a.TAXNO,
                               a.RET_AMT,

                               Country = bas != null ? bas.COUNTRY : ""
                           }).ToList();
            var SubCodeData = db.TW_TAX_SUBCODE.ToList();
            if (TaxDataMain == null)
            {
                MessageBox.Show("請先選擇指定的年度所得資料");
                return;
            }
            string yy = TaxDataMain.YearMonth;
            string yearString = (int.Parse(yy) - 1911).ToString("000");
            string applyType = "";
            FormTool.InputBox("憑單填發方式", "請輸入憑單填發方式：(1)免填發(2)電子憑單(3)紙本憑單", ref applyType);
            if (!new string[] { "1", "2", "3" }.Contains(applyType))
            {
                MessageBox.Show("憑單填發方式輸入錯誤，請輸入1-3的數字");
                return;
            }

            var yrtaxGroup = from a in TaxData group a by a.COMP;
            foreach (var gpTax in yrtaxGroup)
            {
                StringBuilder builder = new StringBuilder();
                string FileName = @"c:\temp\" + gpTax.First().ID1 + "." + yearString + ".U8";
                StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
                decimal TotalAmt = 0; //gpTax.Sum(p => p.AMT);
                decimal TotalTax = 0; //gpTax.Sum(p => p.D_AMT);
                decimal TotalAmt1 = 0; //TotalAmt - TotalTax;
                decimal TotalRetAmt = 0;// gpTax.Sum(p => p.RET_AMT);
                int TotalCount = 0;// gpTax.Count();
                foreach (var TYRTAXRow in gpTax)
                {
                    string F0103 = TYRTAXRow.F0103.Trim().GetFullLenStr(3);
                    string SERIES = TYRTAXRow.SERIES.Trim().GetFullLenStr(8);
                    string ID1 = TYRTAXRow.ID1.Trim().GetFullLenStr(8);
                    string MARK = "".GetFullLenStr(1);
                    string FORMAT = TYRTAXRow.FORMAT.Trim().GetFullLenStr(2);
                    string ID = TYRTAXRow.ID.Trim().GetFullLenStr(10);
                    string IDCODE = TYRTAXRow.IDCODE.Trim().GetFullLenStr(1);
                    string TOT_AMT = Convert.ToInt32(JBModule.Data.CDecryp.Number(TYRTAXRow.AMT)).ToString().PadLeft(10, '0');
                    string TAX_AMT = Convert.ToInt32(JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT)).ToString().PadLeft(10, '0');
                    string REL_AMT = Convert.ToInt32(JBModule.Data.CDecryp.Number(TYRTAXRow.AMT) - JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT)).ToString().PadLeft(10, '0');

                    var subcode = SubCodeData.Where(P => P.M_FORMAT.Trim() == TYRTAXRow.FORMAT.Trim() && P.AUTO == TYRTAXRow.SUBCODE).FirstOrDefault();
                    if (TYRTAXRow.FORMAT.Trim() == "92" && subcode.M_FORSUB.Trim() == "8A" && (JBModule.Data.CDecryp.Number(TYRTAXRow.AMT) - JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT)) < 1000M)//低於一千部申報
                    {
                        continue;
                    }
                    TotalCount++;
                    TotalAmt += JBModule.Data.CDecryp.Number(TYRTAXRow.AMT);
                    TotalTax += JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT);
                    TotalAmt1 += JBModule.Data.CDecryp.Number(TYRTAXRow.AMT) - JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT);
                    TotalRetAmt += JBModule.Data.CDecryp.Number(TYRTAXRow.RET_AMT);
                    string ACC_NO = TYRTAXRow.NOBR.Trim();
                    var Subcode = SubCodeData.SingleOrDefault(p => p.AUTO == TYRTAXRow.SUBCODE);
                    if (Subcode != null)
                        ACC_NO = Subcode.M_FORSUB;// + TYRTAXRow.REL_AMT.ToString().PadLeft(10, '0');
                    else ACC_NO = "";

                    ACC_NO = ACC_NO.ToUpper().GetFullLenStr(12);
                    if (FORMAT.Trim() == "51")
                        ACC_NO = TYRTAXRow.TAXNO.ToUpper().GetFullLenStr(12);
                    string BLANK_1 = "".GetFullLenStr(1);
                    string ERR_MARK = "".GetFullLenStr(1);
                    string YEAR = (Convert.ToInt32(TaxDataMain.YearMonth.Substring(0, 4)) - 1911).ToString("000");
                    string NAME_C = TYRTAXRow.NAME_C.Trim().GetFullLenStr(40);//所得人姓名/名稱(12->40)
                    string ADDR_2 = TYRTAXRow.ADDR2.Trim().GetFullLenStr(60);
                    //var Ybs = TYRTAXRow.YEAR_B.Split('/');
                    //var Yes = TYRTAXRow.YEAR_E.Split('/');
                    int YearB = Convert.ToInt32(TaxDataMain.DateBegin.Year) - 1911;
                    int MonthB = Convert.ToInt32(TaxDataMain.DateBegin.Month);
                    int YearE = Convert.ToInt32(TaxDataMain.DateEnd.Year) - 1911;
                    int MonthE = Convert.ToInt32(TaxDataMain.DateEnd.Month);
                    string YYMM = YearB.ToString("000") + MonthB.ToString("00") + YearE.ToString("000") + MonthE.ToString("00");
                    string RET_AMT = Convert.ToInt32(JBModule.Data.CDecryp.Number(TYRTAXRow.RET_AMT)).ToString().PadLeft(10, '0');
                    string Over183 = "".GetFullLenStr(1);
                    string Country = TYRTAXRow.Country.GetFullLenStr(2);
                    DateTime Bdate, Edate;
                    Bdate = new DateTime(Convert.ToInt32(TaxDataMain.DateBegin.Year), 1, 1);
                    Edate = new DateTime(Convert.ToInt32(TaxDataMain.DateBegin.Year), 12, 31);
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
                    //try
                    //{
                    //    if (NAME_C.Trim().Length > 20)
                    //        throw new Exception("姓名超過20字");
                    //}
                    //catch
                    //{
                    //    MessageBox.Show(Resources.Med.NOBR + TYRTAXRow.NOBR + "(" + TYRTAXRow.NAME_C + ")" + "姓名超過20字", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    sw.Close();
                    //    return;
                    //}
                    try
                    {

                        ADDR_2 = Microsoft.VisualBasic.Strings.StrConv(ADDR_2, Microsoft.VisualBasic.VbStrConv.Wide, System.Globalization.CultureInfo.CurrentUICulture.LCID);
                        ADDR_2 = ADDR_2.GetFullLenStr(60);
                        //if (ADDR_2.Trim().Length > 30)
                        //    throw new Exception("地址超過30字");
                    }
                    catch
                    {
                        MessageBox.Show(Resources.Med.NOBR + TYRTAXRow.NOBR + Resources.Med.AddrTooLong, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sw.Close();
                        return;
                    }

                    NAME_C = NAME_C.Replace("(", "");
                    NAME_C = NAME_C.Replace(")", "");
                    NAME_C = NAME_C.Replace("#", "");
                    NAME_C = NAME_C.Replace("@", "");
                    NAME_C = NAME_C.Replace("*", "");
                    NAME_C = NAME_C.Replace("?", "㊣");
                    //NAME_C = Microsoft.VisualBasic.Strings.StrConv(NAME_C, Microsoft.VisualBasic.VbStrConv.Wide, System.Globalization.CultureInfo.CurrentUICulture.LCID);
                    NAME_C = NAME_C.GetFullLenStr(40);//所得人姓名/名稱(12->40)

                    string wStr = F0103 + SERIES + ID1 + MARK + FORMAT + ID + IDCODE + TOT_AMT + TAX_AMT + REL_AMT + ACC_NO + BLANK_1 + ERR_MARK +
                             YEAR + NAME_C + ADDR_2 + YYMM + RET_AMT + SPACE34 + FormInputType + Over183 + Country + RENT + SPACE + DATE;
                    JBHRIS.BLL.Media.Dto.IncomeApplyFormatDto applyFormatDto = new JBHRIS.BLL.Media.Dto.IncomeApplyFormatDto
                    {
                        ApplyType = applyType,
                        CompanyId = ID1,
                        Country = Country,
                        EarnerAddress = ADDR_2,
                        EarnerId = ID,
                        EarnerName = NAME_C,
                        FileDate = DATE,
                        IdType = IDCODE,
                        IncomeFormat = FORMAT,
                        IncomeInterval = YYMM,
                        IncomeNet = JBModule.Data.CDecryp.Number(TYRTAXRow.AMT) - JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT),
                        IncomePayment = JBModule.Data.CDecryp.Number(TYRTAXRow.AMT),
                        IncomeTax = JBModule.Data.CDecryp.Number(TYRTAXRow.D_AMT),
                        IsOver183 = Over183,
                        IncomeYear = YEAR,
                        PensionProvision = JBModule.Data.CDecryp.Number(TYRTAXRow.RET_AMT),
                        SeriesNo = SERIES,
                        TaxAgreement = "",
                        TaxUnit = F0103,
                        TIN = "",
                        UserId = ACC_NO
                    };
                    //sw.WriteLine(wStr);
                    JBHRIS.BLL.Media.IncomeApplyConverter applyConverter = new JBHRIS.BLL.Media.IncomeApplyConverter();
                    var array = applyConverter.ConvertToMedia(applyFormatDto);
                    builder.AppendLine(string.Join("|", array));
                }
                sw.Write(builder.ToString());
                sw.Close();
                MessageBox.Show(string.Format("申報件數{0}，給付總額{1}，扣繳稅額{2}", TotalCount, TotalAmt, TotalTax) + Environment.NewLine + Resources.All.ExportCompleted + "(" + FileName + ")", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM71N_ADD frm = new FRM71N_ADD();
            frm.ShowDialog();
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM71N_ADD frm = new FRM71N_ADD();
            frm.TW_TAX_AUTO = Convert.ToInt32(jbQuery1.SelectedKey);
            frm.ShowDialog();
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var instance = db.TW_TAX.SingleOrDefault(p => p.AUTO == Convert.ToInt32(e.PrimaryKey));
            if (instance.IsLock)
            {
                MessageBox.Show("所得資料：" + instance.Subject + " 已被鎖檔，無法刪除，請先進行解鎖");
                return;
            }
            else
            {
                db.TW_TAX.DeleteOnSubmit(instance);
                db.SubmitChanges();
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (db.Connection.State != ConnectionState.Open)
                db.Connection.Open();
            var trans = db.Connection.BeginTransaction();
            db.Transaction = trans;
            using (trans)
            {
                var instance = db.TW_TAX.SingleOrDefault(p => p.AUTO == Convert.ToInt32(jbQuery1.SelectedKey));

                var data = (from _tw_tax_summary in db.TW_TAX_SUMMARY
                            join _basetts in db.BASETTS on _tw_tax_summary.NOBR equals _basetts.NOBR
                            where _tw_tax_summary.PID == Convert.ToInt32(jbQuery1.SelectedKey)
                            && instance.DateEnd >= _basetts.ADATE && instance.DateEnd <= _basetts.DDATE.Value
                            select new { _tw_tax_summary, _basetts.SALADR }).ToList();
                var compList = data.Select(p => p._tw_tax_summary.COMP).Distinct().ToList();
                var formatList = data.Select(p => p._tw_tax_summary.FORMAT).Distinct().ToList();
                var deleteData = db.YRTAX.Where(p => p.YEAR == instance.YearMonth && MainForm.ReadSalaryGroups.Contains(p.SALADR) && compList.Contains(p.COMP) && formatList.Contains(p.FORMAT));//考量經理的寫入權限範圍較小，改用讀取權限
                db.YRTAX.DeleteAllOnSubmit(deleteData);
                db.SubmitChanges();
                if (data.Any())
                {
                    foreach (var it in data)
                    {
                        JBModule.Data.Linq.YRTAX rr = new JBModule.Data.Linq.YRTAX
                        {
                            ACC_NO = it._tw_tax_summary.NOBR,
                            ADDR_2 = it._tw_tax_summary.ADDR2,
                            BLANK_1 = "",
                            SALADR = it.SALADR,
                            YEAR = instance.YearMonth,
                            COMP = it._tw_tax_summary.COMP,
                            DATE = "",
                            ERR_MARK = "",
                            F0103 = it._tw_tax_summary.F0103,
                            F0407 = it._tw_tax_summary.F0407,
                            FORMAT = it._tw_tax_summary.FORMAT,
                            ID = it._tw_tax_summary.ID,
                            ID1 = it._tw_tax_summary.ID1,
                            IDCODE = it._tw_tax_summary.IDCODE,
                            KEY_DATE = DateTime.Now,
                            KEY_MAN = MainForm.USER_NAME,
                            MARK = "",
                            NAME_C = it._tw_tax_summary.NAME_C,
                            NOBR = it._tw_tax_summary.NOBR,
                            POSTCODE2 = it._tw_tax_summary.POST2,
                            TOT_AMT = it._tw_tax_summary.AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.AMT),
                            REL_AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(it._tw_tax_summary.AMT) - JBModule.Data.CDecryp.Number(it._tw_tax_summary.D_AMT)),
                            RET_AMT = it._tw_tax_summary.RET_AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.RET_AMT),
                            SERIES = it._tw_tax_summary.SERIES,
                            T_OK = it._tw_tax_summary.IS_FILE,
                            TAX_AMT = it._tw_tax_summary.D_AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.D_AMT),
                            YEAR_B = instance.DateBegin.ToString("yyyy/MM/dd"),
                            YEAR_E = instance.DateEnd.ToString("yyyy/MM/dd"),
                        };
                        db.YRTAX.InsertOnSubmit(rr);
                    }
                    db.SubmitChanges();
                    trans.Commit();
                    MessageBox.Show("寫入完成");
                }
                else
                {
                    MessageBox.Show("找不到相關所得資料", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
