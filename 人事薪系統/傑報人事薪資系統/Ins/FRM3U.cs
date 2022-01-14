using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Ins
{
    public partial class FRM3U : JBControls.JBForm
    {
        CheckControl cc;
        public FRM3U()
        {
            InitializeComponent();

        }

        private void FRM3U_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbCountcd);      //國別
            cc.AddControl(cbEmpcdB);        //員別
            #endregion

            Sal.Function.SetAvaliableVBase(this.insDS.V_BASE);
            var countcdData = CodeFunction.GetCountcd();
            SystemFunction.SetComboBoxItems(cbCountcd, countcdData, true, true, true, true); //國別
            cbCountcd.SelectedValue = countcdData.First().Key;

            var empcdData = CodeFunction.GetEmpcd();
            SystemFunction.SetComboBoxItems(cbEmpcdB, empcdData, true, true, true, true); //員別
            SystemFunction.SetComboBoxItems(cbEmpcdE, empcdData, true, true, true, true); //員別

            var inscompData = CodeFunction.GetInsComp();
            SystemFunction.SetComboBoxItems(cbINSCOMP, inscompData, true, true, true, true); //投保單位
            cbINSCOMP.SelectedValue = inscompData.First().Key;
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(cbDeptB, deptData, true, true, true, true);
            SystemFunction.SetComboBoxItems(cbDeptE, deptData, true, true, true, true);
            Dictionary<string, string> dicFormat = new Dictionary<string, string>();

            //1,台北分局,2,北區分局,3,中區分局,4,南區分局
            dicFormat.Add("1", "勞保健保勞退三表合一批次加保");
            dicFormat.Add("2", "勞保健保勞退三表合一批次退保");
            dicFormat.Add("3", "勞保健保勞退三表合一批次調整");
            dicFormat.Add("4", "勞保勞退二表合一批次加保");
            dicFormat.Add("5", "勞保勞退二表合一批次退保");
            dicFormat.Add("6", "勞保勞退二表合一批次調整");
            dicFormat.Add("7", "健保單獨批次加保");
            dicFormat.Add("8", "健保單獨批次退保");
            SystemFunction.SetComboBoxItems(cbFORMAT, dicFormat, false, true, true);
            this.iNSCOMPTableAdapter.Fill(this.insDS.INSCOMP, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            if (this.insDS.INSCOMP.FirstOrDefault() != null)
            {
                cbINSCOMP.SelectedValue = this.insDS.INSCOMP.FirstOrDefault().S_NO.Trim();
                string INSNO = this.insDS.INSCOMP.FirstOrDefault().INSNO.Trim();
                textBoxNET_NO.Text = INSNO.Length > 8 ? INSNO.Substring(0, 8) : INSNO;
                textBoxNET_CHK.Text = INSNO.Last().ToString();
            }

            Dictionary<string, string> dicUnit = new Dictionary<string, string>();
            dicUnit.Add("1", "台北分局");
            dicUnit.Add("2", "北區分局");
            dicUnit.Add("3", "中區分局");
            dicUnit.Add("4", "南區分局");
            dicUnit.Add("5", "高屏分局");
            dicUnit.Add("6", "東區分局");
            SystemFunction.SetComboBoxItems(cbBRCH, dicUnit);

            textBoxADATE.Text = DateTime.Now.ToString("yyyyMMdd");

            cbEmpcdB.SelectedValue = empcdData.First().Key;
            cbEmpcdE.SelectedValue = empcdData.Last().Key;

            popupTextBoxNOBRB.Text = this.insDS.V_BASE.First().NOBR;
            popupTextBoxNOBRE.Text = this.insDS.V_BASE.Last().NOBR;

            cbDeptB.SelectedValue = deptData.First().Key;
            cbDeptE.SelectedValue = deptData.Last().Key;

            textBoxNET_TXT.Text = cbFORMAT.Text.ToString() + ".xls";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                //e.Cancel = true;
                return;
            }
            #endregion

            switch (cbFORMAT.SelectedValue.ToString())
            {
                case "1":
                    TextCreator1();
                    break;
                case "2":
                    TextCreator2();
                    break;
                case "3":
                    TextCreator3();
                    break;
                case "4":
                    TextCreator4();
                    break;
                case "5":
                    TextCreator5();
                    break;
                case "6":
                    TextCreator6();
                    break;
                case "7":
                    TextCreator7();
                    break;
                case "8":
                    TextCreator8();
                    break;
            }
        }

        private void TextCreator1()
        {
            InsDS.U_SYS4DataTable u_sys4 = new InsDS.U_SYS4DataTable();
            InsDSTableAdapters.U_SYS4TableAdapter u_sys4Adapter = new JBHR.Ins.InsDSTableAdapters.U_SYS4TableAdapter();
            u_sys4Adapter.Fill(u_sys4);

            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0
                            //&& c.COUNT_MA == isWaiLao
                            //&& frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in frm3uDB.BASETTS
                                where bts.NOBR == c.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                            c.INSLAB.Any(inslabRow =>
                                inslabRow.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                && ((inslabRow.L_AMT > 10 && inslabRow.H_AMT > 10) || inslabRow.FA_IDNO.Trim().Length > 0)//需有勞健保金額，勞退可能沒有(外勞或雇主)
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.CODE == "1")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            //StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Default);
            JBHRIS.HR.Ins.CABatchPay3Of1 insu = new JBHRIS.HR.Ins.CABatchPay3Of1();
            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.CODE == "1"
                                  orderby c.FA_IDNO ascending
                                  select c;



                foreach (var inslabRow in inslabTable)
                {
                    //保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();

                    //保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();

                    //健保投保單位代碼 X(9)
                    string HeaUnitCode = "";
                    if (!inscomp.IsNull("inspo")) HeaUnitCode = inscomp.INSPO.Trim();
                    //else HeaUnitCode = fno3.GetFullLenStr(9);

                    //投保別 X(1)
                    string ApplyType = "";
                    //投保者 X(1)
                    string Applier = "";
                    if (inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        ApplyType = "2"; //勞保健保勞退
                        Applier = "1"; //本人
                    }
                    else
                    {
                        ApplyType = "3"; //健保                        
                        Applier = "2"; //眷屬
                    }

                    //外籍 X(1)
                    string Foreigner = "";
                    //被保險人身份證號 X(10)
                    string IDNO = "";
                    //投保者全名 X(50)
                    string Name = "";
                    //投保者國籍別 X(3)
                    //string fno23 = "";
                    //投保者性別 X(1)
                    if (baseRow.COUNT_MA)
                    {
                        Foreigner = "Y";
                        IDNO = baseRow.MATNO;
                        Name = baseRow.NAME_C;
                    }
                    else
                    {
                        IDNO = baseRow.IDNO;
                        Name = baseRow.NAME_C.Trim();
                    }

                    //出生日期 YYYYMMDD
                    DateTime Birthday = baseRow.BIRDT.Value;

                    //實際薪資
                    decimal amt = JBModule.Data.CDecryp.Number(inslabRow.H_AMT);//以健保薪資當作月實際薪資

                    //健保投保薪資/調後 9(6)
                    decimal HeaAmt = JBModule.Data.CDecryp.Number(inslabRow.H_AMT);
                    //if (Applier == "2") amt = HeaAmt;

                    //特殊身份別 X(1)
                    string SpTyp = inslabRow.SPTYP;

                    //勞基法特殊身份別 X(1)
                    string WBSPTYP = inslabRow.WBSPTYP;

                    //眷屬外籍 X(1)
                    string FamForn = "";
                    if (inslabRow.FAMILY != null && inslabRow.FAMILY.FAMFORN) FamForn = "Y";
                    //else FamForn = FamForn.GetFullLenStr(1);

                    //眷屬身份證號 X(10)
                    string FaIdNo = "";
                    //眷屬姓名 X(6)
                    string FaName = "";
                    //眷屬出生日期 YYYYMMDD
                    DateTime FaBirthday = new DateTime(1900, 1, 1);
                    //稱謂代碼 X(1)
                    string RelCode = "";
                    if (inslabRow.FA_IDNO.Trim().Length > 0)
                    {
                        FaIdNo = inslabRow.FA_IDNO.Trim();
                        FaName = inslabRow.FAMILY.FA_NAME.Trim();
                        FaBirthday = inslabRow.FAMILY.FA_BIRDT;
                        RelCode = inslabRow.FAMILY.REL_CODE;
                    }

                    //健保分局別 X(1)
                    string HeaGroup = cbBRCH.SelectedValue.ToString();

                    //健保加保原因別 X(1)
                    string HeaApplyReason = "";
                    if (inslabRow.INSNAME != null) HeaApplyReason = inslabRow.INSNAME.NO1;

                    //健保加保原因發生日期 YYYYMMDD
                    DateTime HeaReasonDate = Convert.ToDateTime(textBoxADATE.Text);
                    string fSex = "";



                    //提繳身份別 X(1)
                    string RetIdType = "";
                    if (!baseRow.COUNT_MA && inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        if (inslabRow.WBSPTYP.Trim().Length == 0) RetIdType = "1";
                        else
                        {
                            if (inslabRow.WBSPTYP == "0") RetIdType = "3";
                            else if (inslabRow.WBSPTYP == "8") RetIdType = " ";
                            else RetIdType = "2";
                        }
                    }

                    //月提繳工資 9(6)
                    string fno26 = JBModule.Data.CDecryp.Number(inslabRow.R_AMT).ToString().PadLeft(6, '0');
                    if (baseRow.COUNT_MA) fno26 = "0".PadLeft(6, '0');

                    //雇主提繳率 X(5)
                    decimal CompRate = Convert.ToDecimal(u_sys4[0].NRETIRERATE * 100);
                    if (baseRow.COUNT_MA) CompRate = 0;
                    if (Applier == "2") CompRate = 0;

                    //勞提率註記 X(1)
                    //decimal CompRate = 0;
                    //勞工提繳率 X(5)
                    decimal SelfRate = 0;
                    var basettsDataRow = (from c in baseRow.BASETTS
                                          where
                                          Convert.ToDateTime(textBoxADATE.Text).Date >= c.ADATE &&
                                          Convert.ToDateTime(textBoxADATE.Text).Date <= c.DDATE
                                          select c).FirstOrDefault();
                    if (basettsDataRow.RETRATE != 0 && inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        //CompRate = "Y";
                        SelfRate = basettsDataRow.RETRATE;
                    }

                    if (baseRow.COUNT_MA)
                    {
                        CompRate = 0;
                        SelfRate = 0;
                    }

                    //勞退提繳日與勞保生效日不同註記 X(1)
                    //string fno30 = " ";
                    //勞退提繳日期 X(7) 民國年
                    DateTime RetDate = new DateTime(1900, 1, 1);
                    //if (inslabRow.IN_DATE != inslabRow) RetDate = inslabRow.RBDATE;
                    insu.Insert(textBoxNET_NO.Text, textBoxNET_CHK.Text, inscomp.INSPO, ApplyType, Applier, Foreigner, IDNO, Name, Birthday, amt, HeaAmt, SpTyp, WBSPTYP, FaIdNo, FaName, FaBirthday, RelCode, HeaGroup, HeaApplyReason, HeaReasonDate, fSex, RetIdType, CompRate, SelfRate, RetDate);


                }

            }
            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);

            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void TextCreator2()
        {
            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0 &&
                            //c.COUNT_MA == isWaiLao && 
                            //frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            (from bts in frm3uDB.BASETTS
                             where bts.NOBR == c.NOBR
                             && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                             && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                             select 1).Any()
                           && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                            c.INSLAB.Any(inslabRow =>
                                inslabRow.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString() &&
                                inslabRow.CODE == "3")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            //StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Default);
            JBHRIS.HR.Ins.CABatchStop3Of1 insu = new JBHRIS.HR.Ins.CABatchStop3Of1();
            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.CODE == "3" && c.FA_IDNO.Trim().Length == 0//退保只顯示員工
                                  orderby c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    //勞保保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();

                    //勞保保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();

                    //健保保險證號 X(9)
                    string HeaID = "";
                    if (!inscomp.IsNull("inspo")) HeaID = inscomp.INSPO.Trim();
                    //else HeaID = HeaID.GetFullLenStr(9);

                    //健保分局別 X(1)
                    string HeaGroup = cbBRCH.SelectedValue.ToString();

                    //保險別 X(1)
                    string ApplyType = "";
                    //投保者 X(1)
                    string Applier = "";
                    if (inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        ApplyType = "2"; //勞保健保勞退                        
                        Applier = "1"; //本人
                    }
                    else
                    {
                        ApplyType = "3"; //健保                        
                        Applier = "2"; //眷屬
                    }

                    //本人外籍 X(1)
                    string Foreigner = "";
                    //本人身份證號 X(10)
                    string IdNo = "";

                    //被保險者居留證號 X(10)
                    string fIdNo = "";
                    if (baseRow.COUNT_MA)
                    {
                        Foreigner = "Y";
                        IdNo = baseRow.MATNO;
                        fIdNo = baseRow.MATNO;
                    }
                    else
                    {
                        IdNo = baseRow.IDNO;
                    }

                    //本人姓名 X(12)
                    string Name = "";
                    //本人民前/民國註記 X(1)
                    //string fno10 = "";
                    //本人出生日期 X(7) 民國年
                    DateTime Birthday = new DateTime(1900, 1, 1);
                    Name = baseRow.NAME_C.Trim();
                    //fno10 = " ";
                    Birthday = baseRow.BIRDT.Value.Date;


                    //眷屬外籍 X(1)
                    string fno12 = "";
                    if (inslabRow.FAMILY != null && inslabRow.FAMILY.FAMFORN) fno12 = "Y";

                    //眷屬姓名 X(12)
                    string faName = "";
                    //眷屬民前/民國註記 X(1)
                    //string fno15 = "";
                    //眷屬出生日期 X(7) 民國年
                    DateTime faBirthday = new DateTime(1900, 1, 1);
                    if (inslabRow.FA_IDNO.Trim().Length > 0)
                    {
                        faName = inslabRow.FAMILY.FA_NAME.Trim();
                        Birthday = inslabRow.FAMILY.FA_BIRDT;
                        IdNo = inslabRow.FA_IDNO;
                        Name = faName;
                        //fno15 = " ";
                        faBirthday = inslabRow.FAMILY.FA_BIRDT.Date;
                    }

                    //健保退保原因別 X(1)
                    string HeaOutReasonType = "2";

                    //健保退保原因說明別 X(1)
                    string HeaOutReasonCode = "";
                    if (inslabRow.INSNAME != null) HeaOutReasonCode = inslabRow.INSNAME.NO1;


                    //健保退保原因說明 X(8)
                    string HeaOutReasonNote = "";
                    if (inslabRow.FA_IDNO.Trim().Length == 0) HeaOutReasonNote = "離職";
                    else HeaOutReasonNote = "轉換單位";

                    //健保退保原因發生日期 X(7)
                    DateTime HeaOutReasonDate = inslabRow.OUT_DATE.Date;
                    insu.Insert(LabID, LabChk, HeaID, HeaGroup, ApplyType, Applier, Foreigner, Name, IdNo, fIdNo, Birthday, HeaOutReasonType, HeaOutReasonCode, HeaOutReasonNote, HeaOutReasonDate);
                    //string wStr = LabID + LabChk + HeaID + HeaGroup + ApplyType + Applier + Foreigner + Name + IdNo + fno10 +
                    //    Birthday + fno12 + fno13 + fIdNo + fno15 + fno16 + HeaOutReasonType + HeaOutReasonCode + HeaOutReasonNote + HeaOutReasonDate;

                    //sw.WriteLine(wStr);
                }
            }

            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);

            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void TextCreator3()
        {
            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0 &&
                            //c.COUNT_MA == isWaiLao && 
                            (from bts in frm3uDB.BASETTS
                             where bts.NOBR == c.NOBR
                             && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                             && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                             select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow =>
                                inslabRow.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                && inslabRow.L_AMT > 10 && inslabRow.H_AMT > 10//需有勞健保金額，勞退可能沒有(外勞或雇主)
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.CODE == "2")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            JBHRIS.HR.Ins.CABatchAdj3Of1 insu = new JBHRIS.HR.Ins.CABatchAdj3Of1();
            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.CODE == "2"
                                  && c.FA_IDNO.Trim().Length == 0//只抓員工
                                  orderby c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    //勞保保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();

                    //勞保保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();

                    //健保保險證號 X(9)
                    string HeaUnitCode = "";
                    if (!inscomp.IsNull("inspo")) HeaUnitCode = inscomp.INSPO.Trim();

                    //健保分局別 X(1)
                    string HeaGroup = cbBRCH.SelectedValue.ToString();

                    //外籍 X(1)
                    string Foreigner = "";
                    //身份證號 X(10)
                    string IdNo = "";
                    string fIdNo = "";
                    if (baseRow.COUNT_MA)
                    {
                        Foreigner = "Y";
                        IdNo = baseRow.MATNO;
                        fIdNo = baseRow.MATNO;
                    }
                    else
                    {
                        Foreigner = "";
                        IdNo = baseRow.IDNO;
                    }

                    //姓名 X(12)
                    string Name = baseRow.NAME_C.Trim();

                    //民前/民國註記 X(1)
                    string fno8 = " ";

                    //出生日期 X(7) 民國年
                    DateTime Birthday = baseRow.BIRDT.Value.Date;

                    //勞保調後投保薪資 X(5)
                    decimal AmtAfter = JBModule.Data.CDecryp.Number(inslabRow.R_AMT);//以健保薪資當作月實際薪資//20140827tony表示勞退金額與健保會脫鉤,所以改用勞退，健保會判斷健保欄位

                    ////勞退調後月提繳工資 X(6)
                    //decimal fno11 = "";
                    //if (baseRow.COUNT_MA) fno11 = "000000";
                    //else fno11 = JBModule.Data.CDecryp.Number(inslabRow.R_AMT);

                    //健保調後薪資 X(6)
                    decimal HeaAmtAft = JBModule.Data.CDecryp.Number(inslabRow.H_AMT);

                    //特殊身份別 X(1)
                    string SpTyp = inslabRow.SPTYP;

                    //健保調前薪資 X(6)
                    decimal HeaAmtBef = 0;
                    var preInslab = (from c in frm3uDB.INSLAB
                                     where (c.CODE.Trim() == "1" || c.CODE.Trim() == "2") && c.IN_DATE.Date < Convert.ToDateTime(textBoxADATE.Text).Date
                                     && c.NOBR == inslabRow.NOBR
                                     orderby c.IN_DATE descending
                                     select c).FirstOrDefault();
                    if (preInslab != null) HeaAmtBef = JBModule.Data.CDecryp.Number(preInslab.H_AMT);
                    else HeaAmtBef = 0;

                    if (inslabRow.FA_IDNO.Trim().Length > 0)
                    {
                        IdNo = inslabRow.FA_IDNO.Trim();
                        Name = inslabRow.FAMILY.FA_NAME.Trim();
                    }


                    insu.Insert(LabID, LabChk, HeaUnitCode, HeaGroup, Foreigner, Name, IdNo, fIdNo, Birthday, AmtAfter, HeaAmtBef, HeaAmtAft, SpTyp);
                    //string wStr = fno1 + fno2 + fno3 + fno4 + fno5 + fno6 + fno7 + fno8 + fno9 + fno10 +
                    //    fno11 + fno12 + fno13 + fno14;

                    //sw.WriteLine(wStr);
                }
            }

            //sw.Close();
            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);

            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void TextCreator4()
        {
            InsDS.U_SYS4DataTable u_sys4 = new InsDS.U_SYS4DataTable();
            InsDSTableAdapters.U_SYS4TableAdapter u_sys4Adapter = new JBHR.Ins.InsDSTableAdapters.U_SYS4TableAdapter();
            u_sys4Adapter.Fill(u_sys4);

            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0
                            //&& c.COUNT_MA == isWaiLao
                            //&& frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in frm3uDB.BASETTS
                                where bts.NOBR == c.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow => inslabRow.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                    && inslabRow.H_AMT <= 10//健保金額應該為0
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.CODE == "1")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            //StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Default);

            JBHRIS.HR.Ins.CABatchPay2Of1 insu = new JBHRIS.HR.Ins.CABatchPay2Of1();

            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  (
                                  (c.CODE == "1" && c.L_AMT != 10)
                                  ||
                                  (c.CODE == "3" && c.L_AMT != 10 &&
                                        !(from a in frm3uDB.INSLAB
                                          where a.NOBR == c.NOBR && a.FA_IDNO == c.FA_IDNO
                                              && c.IN_DATE.AddDays(-1) >= a.IN_DATE && c.IN_DATE.AddDays(-1) <= a.OUT_DATE
                                          select a).Any())
                                  )
                                  orderby c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    //保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();
                    string FormatType = "1";
                    //保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();
                    //外籍 X(1)
                    string Foreigner = "";
                    //被保險人身份證號 X(10)

                    string Name = "";
                    Name = baseRow.NAME_C;

                    string IdNo = "";
                    IdNo = baseRow.IDNO;


                    DateTime Birthday = baseRow.BIRDT.Value.Date;

                    decimal Salary = 0;
                    Salary = JBModule.Data.CDecryp.Number(inslabRow.R_AMT);//2011/11/8鬍鬚張表示應該是勞退薪資

                    string SpType = "";
                    SpType = inslabRow.SPTYP;

                    string LabSpType = "";
                    LabSpType = inslabRow.WBSPTYP;


                    //提繳身份別 X(1)
                    string RetIdType = "";
                    if (!baseRow.COUNT_MA && inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        if (inslabRow.WBSPTYP.Trim().Length == 0) RetIdType = "1";
                        else
                        {
                            if (inslabRow.WBSPTYP == "0") RetIdType = "3";
                            else if (inslabRow.WBSPTYP == "8") RetIdType = " ";
                            else RetIdType = "2";
                        }
                    }

                    string PayType = "";
                    string fSex = "";
                    if (baseRow.COUNT_MA)
                        fSex = baseRow.SEX;

                    //雇主提繳率 X(5)
                    decimal CompRate = Convert.ToDecimal(u_sys4[0].NRETIRERATE * 100);
                    if (baseRow.COUNT_MA) CompRate = 0;

                    //勞工提繳率 X(5)
                    decimal SelfRate = 0;
                    var basettsDataRow = (from c in baseRow.BASETTS
                                          where
                                          Convert.ToDateTime(textBoxADATE.Text).Date >= c.ADATE &&
                                          Convert.ToDateTime(textBoxADATE.Text).Date <= c.DDATE
                                          select c).FirstOrDefault();
                    if (basettsDataRow.RETRATE != 0 && inslabRow.FA_IDNO.Trim().Length == 0)
                    {
                        SelfRate = basettsDataRow.RETRATE;
                    }

                    if (baseRow.COUNT_MA)
                    {
                        SelfRate = 0;
                        Foreigner = "Y";
                    }

                    //勞退提繳日期 X(7) 民國年
                    DateTime RetDate = new DateTime(1900, 1, 1);

                    insu.Insert(FormatType, LabID, LabChk, Foreigner, Name, IdNo, Birthday, Salary, SpType, LabSpType, PayType, fSex, RetIdType, CompRate, SelfRate, RetDate);
                }
            }

            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);

            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void TextCreator5()
        {
            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0 &&
                            //c.COUNT_MA == isWaiLao && 
                            //frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            (from bts in frm3uDB.BASETTS
                             where bts.NOBR == c.NOBR
                             && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                             && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                             select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow =>
                                inslabRow.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date && inslabRow.H_AMT <= 10//健保金額應該為0
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.CODE == "3")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            //StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Default);
            JBHRIS.HR.Ins.CABatchStop2Of1 insu = new JBHRIS.HR.Ins.CABatchStop2Of1();
            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.CODE == "3"
                                  orderby c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    //勞保保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();
                    //勞保保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();
                    //本人外籍 X(1)
                    string Foreigner = "";
                    //姓名 N(6)
                    string Name = baseRow.NAME_C.Trim();
                    //本人身份證號 X(10)
                    string IdNo = "";
                    string fIdNo = "";
                    if (baseRow.COUNT_MA)
                    {
                        Foreigner = "Y";
                        fIdNo = baseRow.MATNO;
                        //Name = baseRow.NAME_C;
                    }
                    else
                    {
                        Foreigner = " ";
                        IdNo = baseRow.IDNO;
                    }
                    //本人民前/民國註記 X(1)
                    string fno6 = " ";
                    //本人出生日期 X(7) 民國年
                    DateTime Birthday = baseRow.BIRDT.Value.Date;
                    insu.Insert(LabID, LabChk, Foreigner, Name, IdNo, fIdNo, Birthday);
                    //string wStr = fno1 + fno2 + fno3 + fno4 + fno5 + fno6 + fno7;
                    //sw.WriteLine(wStr);
                }
            }
            //insu
            //sw.Close();
            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);
            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }





        private void TextCreator6()
        {
            InsDS.U_SYS4DataTable u_sys4 = new InsDS.U_SYS4DataTable();
            InsDSTableAdapters.U_SYS4TableAdapter u_sys4Adapter = new JBHR.Ins.InsDSTableAdapters.U_SYS4TableAdapter();
            u_sys4Adapter.Fill(u_sys4);

            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;

            var baseTable = from c in frm3uDB.BASE
                            where
                            c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 &&
                            c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0 &&
                            //c.COUNT_MA == isWaiLao && 
                            //frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            (from bts in frm3uDB.BASETTS
                             where bts.NOBR == c.NOBR
                             && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                             && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                             select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow =>
                                inslabRow.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                && inslabRow.H_AMT <= 10//健保金額應該為0
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.CODE == "2")
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            JBHRIS.HR.Ins.CABatchAdj2Of1 insu = new JBHRIS.HR.Ins.CABatchAdj2Of1();
            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.CODE == "2"
                                  && c.FA_IDNO.Trim().Length == 0//只抓員工
                                  orderby c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    //保險證號 X(8)
                    string LabID = textBoxNET_NO.Text.Trim();

                    //保險證號檢查碼 X(1)
                    string LabChk = textBoxNET_CHK.Text.Trim();
                    //外籍 X(1)
                    string Foreigner = "";

                    //被保險人姓名 N(06)
                    string Name = "";
                    Name = baseRow.NAME_C;

                    //被保險人身份證號 X(10)
                    string IdNo = "";
                    IdNo = baseRow.IDNO;
                    string fIdNo = "";
                    //生日(民國年)
                    DateTime Birthday = baseRow.BIRDT.Value.Date;
                    //勞保調後投保薪資
                    decimal AmtAfter = JBModule.Data.CDecryp.Number(inslabRow.R_AMT);

                    string SpTyp = "";
                    SpTyp = inslabRow.SPTYP;

                    var basettsDataRow = (from c in baseRow.BASETTS
                                          where
                                          Convert.ToDateTime(textBoxADATE.Text).Date >= c.ADATE &&
                                          Convert.ToDateTime(textBoxADATE.Text).Date <= c.DDATE
                                          select c).FirstOrDefault();

                    if (baseRow.COUNT_MA)
                    {
                        fIdNo = baseRow.MATNO;
                        Foreigner = "Y";
                    }
                    insu.Insert(LabID, LabChk, Foreigner, Name, IdNo, fIdNo, Birthday, AmtAfter, SpTyp);

                }
            }

            JBModule.Data.CNPOI.RenderDataTableToExcel(insu.ExportDataTable, @"C:\Temp\" + textBoxNET_TXT.Text);

            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void TextCreator7()
        {
            InsDS.U_SYS4DataTable u_sys4 = new InsDS.U_SYS4DataTable();
            InsDSTableAdapters.U_SYS4TableAdapter u_sys4Adapter = new JBHR.Ins.InsDSTableAdapters.U_SYS4TableAdapter();
            u_sys4Adapter.Fill(u_sys4);

            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;
            //加保
            var baseTable = from c in frm3uDB.BASE
                            where c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 && c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0
                            //&& c.COUNT_MA == isWaiLao 
                            //&& frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in frm3uDB.BASETTS
                                where bts.NOBR == c.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow => inslabRow.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                    && inslabRow.CODE == "1"//加保
                                    && inslabRow.L_AMT <= 10 && inslabRow.R_AMT <= 10//獨立保健保，應該沒有勞保勞退投保金額
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                    && inslabRow.FA_IDNO.Trim().Length > 0//只抓眷屬
                                    )
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Unicode);

            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.IN_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.FA_IDNO.Trim().Length > 0//抓員工&眷屬
                                  orderby c.NOBR, c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    try
                    {
                        //投保單位代號 X(9)
                        string fno1 = textBoxNET_NO.Text.Trim().GetFullLenStr(8) + textBoxNET_CHK.Text.Trim().GetFullLenStr(1);

                        //異動別 X(1)
                        string fno2 = "D";
                        //switch (inslabRow.CODE)
                        //{
                        //    case "1":
                        //        fno2 = "G";
                        //        break;
                        //    case "2":
                        //        fno2 = "L";
                        //        break;
                        //    case "3":
                        //        fno2 = "Ｓ";
                        //        break;
                        //}

                        //被保險人身分證字號 X(10)
                        string fno3 = inslabRow.BASE.IDNO.Trim().GetFullLenStr(10);

                        //空白 X(1)
                        string fno4 = "";
                        fno4 = fno4.GetFullLenStr(1);

                        //眷屬身分證字號 X(10)
                        string fno5 = inslabRow.FA_IDNO.Trim().GetFullLenStr(10);

                        //空白 X(1)
                        string fno6 = "";
                        fno6 = fno6.GetFullLenStr(1);

                        //稱謂代號 X(1)
                        string fno7 = inslabRow.FAMILY.REL_CODE.Trim().GetFullLenStr(1);

                        //保險對象性別 X(1)
                        string fno8 = "";
                        if (inslabRow.CODE != "1") fno8 = fno8.GetFullLenStr(1);
                        else
                        {
                            if (fno5.Substring(0, 1) == "1") fno8 = "M";
                            else fno8 = "F";
                        }

                        //民國前註記 X(1)
                        string fno9 = "";
                        if (inslabRow.FAMILY.FA_BIRDT.Date.Year - 1911 < 1) fno9 = "－";
                        else fno9 = fno9.GetFullLenStr(1);

                        //保險對象出生日期 X(7) 民國年
                        string fno10 = (inslabRow.FAMILY.FA_BIRDT.Date.Year - 1911).ToString("000") + inslabRow.FAMILY.FA_BIRDT.Date.Month.ToString("00") + inslabRow.FAMILY.FA_BIRDT.Date.Day.ToString("00");

                        //身分別 X(1)
                        string fno11 = "";
                        fno11 = fno11.GetFullLenStr(1);

                        //地區人口 X(1)
                        string fno12 = "";
                        //if (fno2 == "2") fno12 = "Ｖ";
                        //else
                        fno12 = fno12.GetFullLenStr(1);

                        //退保／停保註記 X(1)
                        string fno13 = "";
                        //if (inslabRow.CODE == "2" || fno2 == "M") fno13 = "Ｖ";
                        //else
                        fno13 = fno13.GetFullLenStr(1);

                        //轉出註記 X(1)
                        string fno14 = "";
                        //if (inslabRow.CODE == "2" || fno2 == "M") fno14 = "Ｖ";
                        //else
                        fno14 = fno14.GetFullLenStr(1);

                        //眷屬續保註記 X(1)
                        //Ｓ－在學就讀且無職業
                        //Ｐ－受禁治產宣告尚未撤銷
                        //Ａ－殘障而不能自謀生活
                        //Ｈ－罹患重大傷病且無職業
                        //Ｇ－應屆畢業或服兵役退伍且無職業，於畢業學期終了或退伍日起一年內。

                        string fno15 = "";
                        //if (fno2 == "M") fno15 = "Ｖ";
                        //else
                        //    if (fno2 == "P" && (inslabRow.CODE == "Ｓ" || inslabRow.CODE == "P" || inslabRow.CODE == "A" || inslabRow.CODE == "H" || inslabRow.CODE == "G")) fno15 = "Ｖ";
                        //    else
                        fno15 = fno15.GetFullLenStr(1);

                        //停保／退保／眷屬續保／加保原因 X(1)
                        string fno16 = inslabRow.CODE1.Trim().GetFullLenStr(1);

                        //投保金額 X(6)
                        decimal HeaAmt = JBModule.Data.CDecryp.Number(inslabRow.H_AMT);
                        string fno17 = HeaAmt.ToString("000000");

                        //空白 X(1)
                        string fno18 = "";
                        fno18 = fno18.GetFullLenStr(7);

                        string fno19 = "";
                        //資格取得日期 X(7)
                        switch (inslabRow.CODE)
                        {
                            case "1":
                                fno19 = (inslabRow.IN_DATE.Date.Year - 1911).ToString("000") + inslabRow.IN_DATE.Date.Month.ToString("00") + inslabRow.IN_DATE.Date.Day.ToString("00");
                                break;
                            case "3":
                                fno19 = (inslabRow.OUT_DATE.Date.Year - 1911).ToString("000") + inslabRow.OUT_DATE.Date.Month.ToString("00") + inslabRow.OUT_DATE.Date.Day.ToString("00");
                                break;
                            case "2":
                                fno19 = (inslabRow.IN_DATE.Date.Year - 1911).ToString("000") + inslabRow.IN_DATE.Date.Month.ToString("00") + inslabRow.IN_DATE.Date.Day.ToString("00");
                                break;
                        }

                        //更改後身分證字號
                        string fno20 = "";
                        fno20 = fno20.GetFullLenStr(10);

                        //民國前註記 X(1)
                        string fno21 = "";
                        if (inslabRow.FAMILY.FA_BIRDT.Date.Year - 1911 < 1) fno21 = "－";
                        else fno21 = fno21.GetFullLenStr(1);

                        //更改後出生日期 X(7)
                        string fno22 = "";
                        fno22 = fno22.GetFullLenStr(7);

                        //更改後性別 X(1)
                        string fno23 = "";
                        fno23 = fno23.GetFullLenStr(1);

                        //更改後稱謂代號 X(1)
                        string fno24 = "";
                        fno24 = fno24.GetFullLenStr(1);

                        //調整後投保金額 X(6)
                        string fno25 = "";
                        fno25 = fno25.GetFullLenStr(6);

                        //所屬縣市代碼 X(2)
                        string fno26 = "";
                        fno26 = fno26.GetFullLenStr(2);

                        //來源別 X(1)
                        string fno27 = "2";

                        //空白 X(1)
                        string fno28 = "";
                        fno28 = fno28.GetFullLenStr(10);

                        //保險對象姓名 X(24)
                        string fno29 = inslabRow.FAMILY.FA_NAME.Trim().GetFullLenStr(12);


                        string wStr = fno1 + fno2 + fno3 + fno4 + fno5 + fno6 + fno7 + fno8 + fno9 + fno10 +
                                      fno11 + fno12 + fno13 + fno14 + fno15 + fno16 + fno17 + fno18 + fno19 + fno20 +
                                      fno21 + fno22 + fno23 + fno24 + fno25 + fno26 + fno27 + fno28 + fno29;

                        sw.WriteLine(wStr);

                    }

                    catch
                    {
                        MessageBox.Show("工號:" + inslabRow.NOBR + "資料有誤，請查看");
                    }
                }
            }
            sw.Close();
            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

        }
        private void TextCreator8()
        {
            InsDS.U_SYS4DataTable u_sys4 = new InsDS.U_SYS4DataTable();
            InsDSTableAdapters.U_SYS4TableAdapter u_sys4Adapter = new JBHR.Ins.InsDSTableAdapters.U_SYS4TableAdapter();
            u_sys4Adapter.Fill(u_sys4);

            Ins.FRM3ULINQ.FRM3UDataClassesDataContext frm3uDB = new JBHR.Ins.FRM3ULINQ.FRM3UDataClassesDataContext();

            //bool isWaiLao;
            //if (radioButtonTYPE1.Checked) isWaiLao = false;
            //else isWaiLao = true;
            //退保
            var baseTable = from c in frm3uDB.BASE
                            where c.NOBR.CompareTo(popupTextBoxNOBRB.Text) >= 0 && c.NOBR.CompareTo(popupTextBoxNOBRE.Text) <= 0
                            //&& c.COUNT_MA == isWaiLao 
                            //&& frm3uDB.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in frm3uDB.BASETTS
                                where bts.NOBR == c.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in frm3uDB.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            && c.BASETTS.Any(basettsRow =>
                                Convert.ToDateTime(textBoxADATE.Text).Date >= basettsRow.ADATE &&
                                Convert.ToDateTime(textBoxADATE.Text).Date <= basettsRow.DDATE &&
                                basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptB.SelectedValue.ToString()) >= 0 && basettsRow.DEPT1.D_NO_DISP.CompareTo(cbDeptE.SelectedValue.ToString()) <= 0 &&
                                basettsRow.EMPCD.CompareTo(cbEmpcdB.SelectedValue.ToString()) >= 0 && basettsRow.EMPCD.CompareTo(cbEmpcdE.SelectedValue.ToString()) <= 0) &&
                                c.INSLAB.Any(inslabRow => inslabRow.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                    && inslabRow.CODE == "3"//加保
                                    && inslabRow.L_AMT <= 10 && inslabRow.R_AMT <= 10//獨立保健保，應該沒有勞保勞退投保金額
                                && inslabRow.FA_IDNO.Trim().Length > 0//只抓眷屬
                                    )
                                    && !c.INSLAB.Any(inslabRow => inslabRow.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date
                                    && inslabRow.CODE == "3"//加保
                                && inslabRow.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                                && inslabRow.FA_IDNO.Trim().Length == 0//員工未退保
                                    )
                            orderby c.NOBR ascending
                            select c;

            var inscomp = (from c in insDS.INSCOMP
                           where c.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()
                           select c).FirstOrDefault();

            StreamWriter sw = new StreamWriter(@"c:\temp\" + textBoxNET_TXT.Text, false, Encoding.Unicode);

            foreach (var baseRow in baseTable)
            {
                var inslabTable = from c in baseRow.INSLAB
                                  where
                                  c.OUT_DATE.Date == Convert.ToDateTime(textBoxADATE.Text).Date &&
                                  c.FA_IDNO.Trim().Length > 0//抓員工&眷屬
                                  orderby c.NOBR, c.FA_IDNO ascending
                                  select c;

                foreach (var inslabRow in inslabTable)
                {
                    try
                    {
                        //投保單位代號 X(9)
                        string fno1 = textBoxNET_NO.Text.Trim().GetFullLenStr(8) + textBoxNET_CHK.Text.Trim().GetFullLenStr(1);

                        //異動別 X(1)
                        string fno2 = "L";
                        //switch (inslabRow.CODE)
                        //{
                        //    case "1":
                        //        fno2 = "G";
                        //        break;
                        //    case "2":
                        //        fno2 = "L";
                        //        break;
                        //    case "3":
                        //        fno2 = "Ｓ";
                        //        break;
                        //}

                        //被保險人身分證字號 X(10)
                        string fno3 = inslabRow.BASE.IDNO.Trim().GetFullLenStr(10);

                        //空白 X(1)
                        string fno4 = "";
                        fno4 = fno4.GetFullLenStr(1);

                        //眷屬身分證字號 X(10)
                        string fno5 = inslabRow.FA_IDNO.Trim().GetFullLenStr(10);

                        //空白 X(1)
                        string fno6 = "";
                        fno6 = fno6.GetFullLenStr(1);

                        //稱謂代號 X(1)
                        string fno7 = "";
                        //if (inslabRow.FAMILY != null)
                        fno7 = "".GetFullLenStr(1);
                        //else fno7 = fno7.GetFullLenStr(1);

                        //保險對象性別 X(1)
                        string fno8 = "";
                        //if (inslabRow.CODE != "1") 
                        fno8 = fno8.GetFullLenStr(1);
                        //else
                        //{
                        //    if (fno5.Substring(0, 1) == "1") fno8 = "M";
                        //    else fno8 = "F";
                        //}

                        //民國前註記 X(1)
                        string fno9 = "";
                        //if (inslabRow.FAMILY.FA_BIRDT.Date.Year - 1911 < 1) fno9 = "－";
                        //else 
                        fno9 = fno9.GetFullLenStr(1);

                        //保險對象出生日期 X(7) 民國年
                        string fno10 = "".GetFullLenStr(7);

                        //身分別 X(1)
                        string fno11 = "";
                        fno11 = fno11.GetFullLenStr(1);

                        //地區人口 X(1)
                        string fno12 = "";
                        //if (fno2 == "2") fno12 = "Ｖ";
                        //else
                        fno12 = fno12.GetFullLenStr(1);

                        //退保／停保註記 X(1)
                        string fno13 = "";
                        if (inslabRow.CODE == "3" || fno2 == "6")
                            fno13 = fno13.GetFullLenStr(1);
                        else fno13 = "V";

                        //轉出註記 X(1)
                        string fno14 = "";
                        if (inslabRow.CODE == "3" || fno2 == "6")
                            fno14 = "V";
                        else
                            fno14 = fno14.GetFullLenStr(1);

                        //眷屬續保註記 X(1)
                        //Ｓ－在學就讀且無職業
                        //Ｐ－受禁治產宣告尚未撤銷
                        //Ａ－殘障而不能自謀生活
                        //Ｈ－罹患重大傷病且無職業
                        //Ｇ－應屆畢業或服兵役退伍且無職業，於畢業學期終了或退伍日起一年內。

                        string fno15 = "";
                        //if (fno2 == "M") fno15 = "Ｖ";
                        //else
                        //    if (fno2 == "P" && (inslabRow.CODE == "Ｓ" || inslabRow.CODE == "P" || inslabRow.CODE == "A" || inslabRow.CODE == "H" || inslabRow.CODE == "G")) fno15 = "Ｖ";
                        //    else
                        fno15 = fno15.GetFullLenStr(1);

                        //停保／退保／眷屬續保／加保原因 X(1)
                        string fno16 = "".GetFullLenStr(1);

                        //投保金額 X(6)
                        decimal HeaAmt = JBModule.Data.CDecryp.Number(inslabRow.H_AMT);
                        string fno17 = "";
                        fno17 = fno17.GetFullLenStr(6);

                        //空白 X(7)
                        string fno18 = "";
                        fno18 = fno18.GetFullLenStr(7);

                        string fno19 = "";
                        //資格取得日期 X(7)
                        switch (inslabRow.CODE)
                        {
                            case "1":
                                fno19 = (inslabRow.IN_DATE.Date.Year - 1911).ToString("000") + inslabRow.IN_DATE.Date.Month.ToString("00") + inslabRow.IN_DATE.Date.Day.ToString("00");
                                break;
                            case "3":
                                fno19 = (inslabRow.OUT_DATE.Date.Year - 1911).ToString("000") + inslabRow.OUT_DATE.Date.Month.ToString("00") + inslabRow.OUT_DATE.Date.Day.ToString("00");
                                break;
                            case "2":
                                fno19 = (inslabRow.IN_DATE.Date.Year - 1911).ToString("000") + inslabRow.IN_DATE.Date.Month.ToString("00") + inslabRow.IN_DATE.Date.Day.ToString("00");
                                break;
                        }

                        //更改後身分證字號
                        string fno20 = "";
                        fno20 = fno20.GetFullLenStr(10);

                        //民國前註記 X(1)
                        string fno21 = "";
                        if (inslabRow.FAMILY.FA_BIRDT.Date.Year - 1911 < 1) fno21 = "－";
                        else fno21 = fno21.GetFullLenStr(1);

                        //更改後出生日期 X(7)
                        string fno22 = "";
                        fno22 = fno22.GetFullLenStr(7);

                        //更改後性別 X(1)
                        string fno23 = "";
                        fno23 = fno23.GetFullLenStr(1);

                        //更改後稱謂代號 X(1)
                        string fno24 = "";
                        fno24 = fno24.GetFullLenStr(1);

                        //調整後投保金額 X(6)
                        string fno25 = "";
                        fno25 = fno25.GetFullLenStr(6);

                        //所屬縣市代碼 X(2)
                        string fno26 = "";
                        fno26 = fno26.GetFullLenStr(2);

                        //來源別 X(1)
                        string fno27 = "2";

                        //空白 X(12)
                        string fno28 = "";
                        fno28 = fno28.GetFullLenStr(10);

                        //保險對象姓名 X(24)
                        string fno29 = inslabRow.FAMILY.FA_NAME.Trim().GetFullLenStr(13);


                        string wStr = fno1 + fno2 + fno3 + fno4 + fno5 + fno6 + fno7 + fno8 + fno9 + fno10 +
                                      fno11 + fno12 + fno13 + fno14 + fno15 + fno16 + fno17 + fno18 + fno19 + fno20 +
                                      fno21 + fno22 + fno23 + fno24 + fno25 + fno26 + fno27 + fno28 + fno29;

                        sw.WriteLine(wStr);

                    }

                    catch
                    {
                        MessageBox.Show("工號:" + inslabRow.NOBR + "資料有誤，請查看");
                    }
                }
            }
            sw.Close();
            MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

        }


        private void cbINSCOMP_SelectedIndexChange(object sender, EventArgs e)
        {
            var inscomp = this.insDS.INSCOMP.Where(p => p.S_NO.Trim() == cbINSCOMP.SelectedValue.ToString()).FirstOrDefault();
            if (inscomp != null)
            {
                string INSNO = inscomp.INSNO.Trim();
                textBoxNET_NO.Text = INSNO.Length > 8 ? INSNO.Substring(0, 8) : INSNO;
                textBoxNET_CHK.Text = INSNO.Last().ToString();
            }
        }


        private void cbFORMAT_Validated(object sender, EventArgs e)
        {
            textBoxNET_TXT.Text = cbFORMAT.Text.ToString();
            switch (cbFORMAT.SelectedValue.ToString())
            {
                case "7":
                    textBoxNET_TXT.Text += ".txt";
                    break;
                case "8":
                    textBoxNET_TXT.Text += ".txt";
                    break;
                default:
                    textBoxNET_TXT.Text += ".xls";
                    break;
            }
        }
    }

    static class Ext
    {
        public static string GetFullLenStr(this string str, int len)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());

            string emptyStr = "".PadRight(len - bytes.Length, ' ');
            string ss = str.Trim() + emptyStr;
            return ss;
        }
    }
}
