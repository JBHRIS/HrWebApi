using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    /***
     * 
     * 
     * 
     * 
     * 
     * */


    public partial class FRM32 : JBControls.JBForm
    {
        bool isChange = false;
        bool isOutIns = false;
        DataRowView drv = null;
        public static string ReturnFaIdno = "";
        public FRM32()
        {
            InitializeComponent();
        }
        string Nobr, Fa_idno;
        DateTime Adate;
        bool IsNew;
        public FRM32(string nobr, string fa_idno, DateTime aDate, bool isNew)
        {
            InitializeComponent();
            Nobr = nobr;
            Fa_idno = fa_idno;
            Adate = aDate;
            IsNew = isNew;
        }
        CheckControl cc;//必要欄位檢察
        DbTransaction trans;
        private void FRM32_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'insDS.FAMILY' 資料表。您可以視需要進行移動或移除。
            this.fAMILYTableAdapter.FillByAvailable(this.insDS.FAMILY);
            cc = new CheckControl();//必要欄位檢察
            cc.AddControl(comboBoxS_NO);//必要欄位檢察
            cc.AddControl(comboBoxCode);//必要欄位檢察
            cc.AddControl(comboBoxCode1);//必要欄位檢察
            cc.AddControl(comboBoxHRATE_CODE);//必要欄位檢察
            cc.AddControl(comboBoxS_NO);//必要欄位檢察
            SystemFunction.SetComboBoxItems(comboBoxS_NO, CodeFunction.GetInsComp(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxCode1, CodeFunction.GetInsName(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxCode, CodeFunction.GetMtCode("INSURCD"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxSPTYP, CodeFunction.GetMtCode("SPTYP"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxWBSPTYP, CodeFunction.GetMtCode("WBSPTYP"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxLRATE_CODE, CodeFunction.GetLarCode(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxHRATE_CODE, CodeFunction.GetHarCode(), true, false, true);
            //this.taINHOLI.Fill(this.dsView.INHOLI);
            this.iNSLABTableAdapter.FillByInit(this.insDS.INSLAB);//載入時顯示空白
            Sal.Function.SetAvaliableVBase(this.insDS.V_BASE);
            //this.iNSURCDTableAdapter.Fill(this.insDS.INSURCD);
            //this.hARCODETableAdapter.Fill(this.insDS.HARCODE);
            //this.lARCODETableAdapter.Fill(this.insDS.LARCODE);
            //this.wBSPTYPTableAdapter.Fill(this.insDS.WBSPTYP);
            //this.sPTYPTableAdapter.Fill(this.insDS.SPTYP);
            //this.iNSNAMETableAdapter.Fill(this.insDS.INSNAME);
            this.iNSCOMPTableAdapter.Fill(this.insDS.INSCOMP, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.iNSLABTableAdapter.Fill(this.insDS.INSLAB);

            foreach (var row in this.insDS.INSLAB)
            {
                row.L_AMT = JBModule.Data.CDecryp.Number(row.L_AMT);
                row.H_AMT = JBModule.Data.CDecryp.Number(row.H_AMT);
                row.R_AMT = JBModule.Data.CDecryp.Number(row.R_AMT);
            }
            this.insDS.INSLAB.AcceptChanges();
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("INSLAB.nobr");
            filterData();

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.DataAdapter = iNSLABTableAdapter;
            fullDataCtrl1.Init_Ctrls();

            bnAddFamily.Enabled = false;
            bnToIndt.Enabled = false;

            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            if (iNSLABBindingSource.Current != null)
            {
                if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                {
                    DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                    if (outDate == Convert.ToDateTime("9999/12/31"))
                    {
                        bnChange.Enabled = true;
                        bnOutIns.Enabled = true;
                    }
                }
            }
            if (IsNew)
            {
                IsNew = false;
                fullDataCtrl1.bnAdd_Click(null, null);
                txtNobr.Text = Nobr;
                txtBdate.Text = Adate.ToShortDateString();
                txtFaidno.Text = Fa_idno;
            }
        }

        private void filterData()
        {
            //if (!MainForm.MANGSUPER)
            //{
            //    BasDataClassesDataContext db = new BasDataClassesDataContext();

            //    DataTable dt = (iNSLABBindingSource.DataSource as DataSet).Tables[iNSLABBindingSource.DataMember];
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();
            //    fullDataCtrl1.Init_Ctrls();
            //}
        }

        private bool checkSavePower(string nobr)
        {
            //bool isOK;
            //if (!MainForm.PROCSUPER)
            //{
            //    BasDataClassesDataContext db = new BasDataClassesDataContext();
            //    var data = (from c in db.V_BASE where c.NOBR.Trim() == nobr && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //    if (data == null) isOK = false;
            //    else isOK = true;
            //}
            //else isOK = true;

            //return isOK;
            return Sal.Function.CanModify(nobr);
        }

        private void fullDataCtrl1_BeforeAdd(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            txtFaName.Text = "";
        }

        private void bnChange_Click(object sender, EventArgs e)
        {
            isChange = true;
            drv = iNSLABBindingSource.Current as DataRowView;
            fullDataCtrl1.bnAdd_Click(sender, e);
            //不可對眷屬做調整
            //if ((iNSLABBindingSource.Current as DataRowView)["fa_idno"] != null && (iNSLABBindingSource.Current as DataRowView)["fa_idno"].ToString().Trim().Length == 0)
            //{
            //    isChange = true;
            //    drv = iNSLABBindingSource.Current as DataRowView;
            //    fullDataCtrl1.bnAdd_Click(sender, e);
            //}
            //else
            //{
            //    MessageBox.Show(Resources.Ins.DontChangeByFamily, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtNobr.Focus();
            bnAddFamily.Enabled = true;
            bnToIndt.Enabled = true;
            e.Values["in_date"] = DateTime.Now.Date;
            InsDataClassesDataContext db = new InsDataClassesDataContext();
            if (isChange)
            {
                e.Values["nobr"] = drv["nobr"];
                e.Values["fa_idno"] = drv["fa_idno"];
                e.Values["code"] = "2";
                comboBoxCode.SelectedValue = "2";
                e.Values["in_date"] = DateTime.Now.Date;
                e.Values["out_date"] = Convert.ToDateTime("9999/12/31");
                e.Values["rout_date"] = Convert.ToDateTime("9999/12/31");
                e.Values["l_amt"] = drv["l_amt"];
                e.Values["h_amt"] = drv["h_amt"];
                e.Values["r_amt"] = drv["r_amt"];
                comboBoxS_NO.SelectedValue = drv["s_no"];
                comboBoxLRATE_CODE.SelectedValue = drv["lrate_code"];
                comboBoxHRATE_CODE.SelectedValue = drv["hrate_code"];
                comboBoxSPTYP.SelectedValue = drv["sptyp"];
                comboBoxWBSPTYP.SelectedValue = drv["wbsptyp"];
                txtNobr.ReadOnly = true;
                txtFaidno.ReadOnly = true;
                bnAddFamily.Enabled = false;
                //txtBdate.Focus();
                var family = from c in insDS.FAMILY where c.NOBR.ToString().Trim() == drv["nobr"].ToString().Trim() && c.FA_IDNO.ToString().Trim() == drv["fa_idno"].ToString().Trim() select c;
                if (family.Any()) txtFaName.Text = family.First().FA_NAME.ToString();
                if (drv["fa_idno"] != "")
                {
                    e.Values["h_amt"] = drv["h_amt"];
                    textBoxH_AMT.Enabled = false;
                    if (Convert.ToDecimal(drv["h_amt"]) == 0)
                    {

                        var check_H_AMT = from c in db.INSLAB
                                          where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() &&
                                          c.FA_IDNO.Trim() == "" &&
                                          c.OUT_DATE == Convert.ToDateTime("9999/12/31")
                                          select c.H_AMT;
                        if (check_H_AMT.Any())
                        {
                            e.Values["h_amt"] = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                        }
                        else
                            MessageBox.Show("查無員工資料！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                e.Values["CODE"] = "1";
                comboBoxCode.SelectedValue = "1";
                e.Values["CODE1"] = "1";
                comboBoxCode1.SelectedValue = "1";
                if (e.Values["fa_idno"].ToString().Trim().Length > 0) comboBoxCode.SelectedValue = "2";
                e.Values["out_date"] = Convert.ToDateTime("9999/12/31");
                e.Values["rout_date"] = Convert.ToDateTime("9999/12/31");
                e.Values["lrate_code"] = "1";
                e.Values["hrate_code"] = "1";
                e.Values["SPTYP"] = "";
                e.Values["WBSPTYP"] = "";

                var default_inscomp = this.insDS.INSCOMP.Where(p => p.DEFA == true);
                if (default_inscomp.Any())
                    e.Values["s_no"] = default_inscomp.First().S_NO;
            }

            comboBoxCode.Enabled = false;

            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            bnView1.Enabled = false;
            bnView2.Enabled = false;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            bnAddFamily.Enabled = false;
            bnToIndt.Enabled = false;
            txtFaidno.Enabled = false;
            DateTime in_date = Convert.ToDateTime(txtBdate.Text);
            DateTime out_date = Convert.ToDateTime(txtEdate.Text);
            DateTime rout_date = Convert.ToDateTime(txtROutDate.Text);
            if (e.Values["fa_idno"].ToString().Trim() != "")
            {//只檢查眷屬資料
                textBoxH_AMT.Enabled = false;
                InsDataClassesDataContext db = new InsDataClassesDataContext();
                var check_H_AMT = from c in db.INSLAB
                                  where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() &&
                                  c.FA_IDNO.Trim() == "" && c.IN_DATE <= out_date && c.OUT_DATE >= in_date
                                  //c.OUT_DATE == Convert.ToDateTime("9999/12/31")
                                  select c.H_AMT;
                if (check_H_AMT.Any())
                {

                    if (Convert.ToDecimal(textBoxH_AMT.Text) != JBModule.Data.CDecryp.Number(check_H_AMT.First()))
                    {
                        e.Values["h_amt"] = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                    }
                }
            }

            if (isOutIns)
            {
                e.Values["code"] = "3";
                comboBoxCode.SelectedValue = "3";
                e.Values["code1"] = "4";
                comboBoxCode1.SelectedValue = "4";
                if (txtFaidno.Text.Trim().Length > 0)
                {
                    e.Values["code1"] = "3";
                    comboBoxCode1.SelectedValue = "3";
                }
                e.Values["out_date"] = DateTime.Now.Date;
                e.Values["rout_date"] = DateTime.Now.Date;
                comboBoxS_NO.Enabled = false;
                comboBoxSPTYP.Enabled = false;
                comboBoxWBSPTYP.Enabled = false;
                textBoxL_AMT.Enabled = false;
                comboBoxLRATE_CODE.Enabled = false;
                textBoxH_AMT.Enabled = false;
                comboBoxHRATE_CODE.Enabled = false;
                textBoxR_AMT.Enabled = false;
            }

            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            bnView1.Enabled = false;
            bnView2.Enabled = false;
        }

        private void bnOutIns_Click(object sender, EventArgs e)
        {
            isOutIns = true;
            fullDataCtrl1.bnEdit_Click(sender, e);
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
            bnView1.Enabled = true;
            bnView2.Enabled = true;
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            string EmployeeId = txtNobr.Text;
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            string faidno = txtFaidno.Text.Trim();
            DateTime in_date = Convert.ToDateTime(txtBdate.Text);
            DateTime out_date = Convert.ToDateTime(txtEdate.Text);
            DateTime rout_date = Convert.ToDateTime(txtROutDate.Text);

            InsDataClassesDataContext db = new InsDataClassesDataContext();
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add && fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit && isChange == false && isOutIns == false)
            {//新增狀態
                //e.Values["h_amt"] = textBoxH_AMT.Text;
                var check_date = from c in db.INSLAB
                                 where c.NOBR.Trim() == EmployeeId.Trim() &&
                                 c.FA_IDNO.Trim() == faidno
                                 && (
                                 (c.IN_DATE <= in_date && c.OUT_DATE >= in_date) ||
                                 (c.IN_DATE <= out_date && c.OUT_DATE >= out_date)
                                 )
                                 select c;
                if (check_date.Any())
                {
                    MessageBox.Show("加保日期有重疊！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                //textBoxH_AMT.Text = JBModule.Data.CDecryp.Number(sql.First().H_AMT).ToString(); //解密
                //decimal Hamt = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxH_AMT.Text));//加密

                if (faidno != "")
                {//只檢查眷屬資料
                    var check_H_AMT = from c in db.INSLAB
                                      where c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
                                      c.FA_IDNO.Trim() == "" && c.IN_DATE <= out_date && c.OUT_DATE >= in_date
                                      //c.OUT_DATE == Convert.ToDateTime("9999/12/31")
                                      select c.H_AMT;
                    if (check_H_AMT.Any())
                    {

                        if (Convert.ToDecimal(textBoxH_AMT.Text) != JBModule.Data.CDecryp.Number(check_H_AMT.First()))
                        {
                            var v = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                            MessageBox.Show("「健保投保金額」輸入錯誤，將自動變更為與員工相同之健保投保金額！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxH_AMT.Text = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                            e.Cancel = true;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("查無員工投保紀錄，家屬不可投保。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if ((fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify && fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit) || isChange == true)
            {//修改和調整狀態
                DateTime clickDate = Convert.ToDateTime(isChange ? drv["in_date"] : e.Values.Row["in_date", DataRowVersion.Original]);

                var check_date = from c in db.INSLAB
                                 where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() &&
                                 c.FA_IDNO.Trim() == faidno &&
                                 c.IN_DATE != clickDate &&
                                 (
                                 (c.IN_DATE <= in_date && c.OUT_DATE >= in_date) ||
                                 (c.IN_DATE <= out_date && c.OUT_DATE >= out_date)
                                 )
                                 select c;

                if (check_date.Any())
                {
                    MessageBox.Show("加保日期有重疊！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                if (isChange && e.Values["in_date"] != null && drv["in_date"] != null && in_date == Convert.ToDateTime(drv["in_date"]))
                {
                    MessageBox.Show("「加保日期」尚未修改。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBdate.Focus();
                    e.Cancel = true;
                    return;
                }

                if (isChange && faidno != "")
                {//只檢查眷屬資料
                    var check_H_AMT = from c in db.INSLAB
                                      where c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
                                      c.FA_IDNO.Trim() == "" && c.IN_DATE <= out_date && c.OUT_DATE >= in_date
                                      //c.OUT_DATE == Convert.ToDateTime("9999/12/31")
                                      select c.H_AMT;
                    if (check_H_AMT.Any())
                    {

                        if (Convert.ToDecimal(textBoxH_AMT.Text) != JBModule.Data.CDecryp.Number(check_H_AMT.First()))
                        {
                            var v = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                            MessageBox.Show("「健保投保金額」輸入錯誤，將自動變更為與員工相同之健保投保金額！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxH_AMT.Text = JBModule.Data.CDecryp.Number(check_H_AMT.First()).ToString();
                            e.Cancel = true;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("查無員工投保紀錄，家屬不可投保。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }
            }
            if (out_date < in_date)
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Ins.OutDateLessThenInDateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!checkSavePower(EmployeeId))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxL_AMT.Text.Trim().Length > 0 && Convert.ToDecimal(textBoxL_AMT.Text) > 0)
            {
                if (comboBoxLRATE_CODE.SelectedValue == null || comboBoxLRATE_CODE.SelectedValue.ToString().Trim().Length == 0)
                {
                    e.Cancel = true;
                    MessageBox.Show(Resources.Ins.LRateReqErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxLRATE_CODE.Focus();
                    return;
                }
            }
            if (textBoxH_AMT.Text.Trim().Length > 0 && Convert.ToDecimal(textBoxH_AMT.Text) > 0)
            {
                if (comboBoxHRATE_CODE.SelectedValue == null || comboBoxHRATE_CODE.SelectedValue.ToString().Trim().Length == 0)
                {
                    e.Cancel = true;
                    MessageBox.Show(Resources.Ins.HRateReqErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxHRATE_CODE.Focus();
                    return;
                }
            }

            //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            //{
            //    if (txtFaidno.Text.Trim().Length == 0)
            //    {
            //        decimal Lamt = (textBoxL_AMT.Text.Trim().Length > 0) ? JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxL_AMT.Text)) : 10;
            //        decimal Hamt = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxH_AMT.Text));
            //        decimal Ramt = (textBoxR_AMT.Text.Trim().Length > 0) ? JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxR_AMT.Text)) : 10;
            //        var check_data = from c in db.INSLAB
            //                         where
            //                            c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
            //                            c.FA_IDNO.Trim() == faidno &&
            //                            new string[] { "1", "2" }.Contains(c.CODE.Trim()) &&
            //                            DateTime.Now.Date >= c.IN_DATE && DateTime.Now.Date <= c.OUT_DATE &&
            //                            c.L_AMT == Lamt &&
            //                            c.H_AMT == Hamt &&
            //                            c.R_AMT == Ramt
            //                         select c;
            //        //if (check_data.Count() > 0)//20120522 tony說不要卡限制，為了產假?只改身分別代碼
            //        //{
            //        //    e.Cancel = true;
            //        //    MessageBox.Show(Resources.Ins.AmtLvRepeat, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return;
            //        //}
            //    }
            //    else
            //    {
            //        //decimal Hamt = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxH_AMT.Text));
            //        //var check_data = from c in db.INSLAB
            //        //                 where
            //        //                    c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
            //        //                    c.FA_IDNO.Trim() == faidno &&
            //        //                    new string[] { "1", "2" }.Contains(c.CODE.Trim()) &&
            //        //                    DateTime.Now.Date >= c.IN_DATE && DateTime.Now.Date <= c.OUT_DATE &&
            //        //                    c.H_AMT == Hamt
            //        //                 select c;
            //        //if (check_data.Count() > 0)
            //        //{
            //        //    e.Cancel = true;
            //        //    MessageBox.Show(Resources.Ins.AmtLvRepeat, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    return;
            //        //}
            //    }
            //}

            if (!e.Cancel)
            {
                var conn = iNSLABTableAdapter.Connection;
                InsDataClassesDataContext trans_db;
                using (trans_db = new InsDataClassesDataContext(conn))
                {
                    try
                    {
                        if (trans_db.Connection.State != ConnectionState.Open) trans_db.Connection.Open();
                        trans = trans_db.Connection.BeginTransaction();
                        iNSLABTableAdapter.Transaction = trans as SqlTransaction;
                        trans_db.Transaction = trans;
                        if (isChange)
                        {
                            Dictionary<string, string> fa_idno = new Dictionary<string, string>();

                            //本人含眷屬設定退保日期					
                            var inslab = from c in trans_db.INSLAB
                                         where
                                         c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
                                         new string[] { "1", "2" }.Contains(c.CODE.Trim()) &&
                                         in_date > c.IN_DATE && in_date <= c.OUT_DATE
                                         select c;
                            if (faidno.Length > 0)
                                inslab = inslab.Where(p => p.FA_IDNO == faidno);
                            foreach (var row in inslab)
                            {
                                row.OUT_DATE = in_date.AddDays(-1);
                                row.ROUT_DATE = in_date.AddDays(-1);

                                if (row.FA_IDNO.Trim().Length > 0 && row.FA_IDNO.Trim() != faidno)
                                {
                                    fa_idno.Add(row.FA_IDNO.Trim(), row.HRATE_CODE.Trim());
                                }
                            }

                            //新增眷屬調整資料
                            foreach (string key in fa_idno.Keys)
                            {
                                INSLAB newInsLab = new INSLAB();
                                newInsLab.NOBR = EmployeeId.ToString().Trim();
                                newInsLab.FA_IDNO = key;
                                newInsLab.CODE = "2";
                                newInsLab.IN_DATE = in_date;
                                newInsLab.OUT_DATE = out_date;
                                newInsLab.ROUT_DATE = rout_date;
                                newInsLab.LRATE_CODE = "";
                                newInsLab.L_AMT = JBModule.Data.CEncrypt.Number(0);
                                newInsLab.HRATE_CODE = fa_idno[key];
                                newInsLab.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["h_amt"]));
                                newInsLab.R_AMT = JBModule.Data.CEncrypt.Number(0);
                                newInsLab.KEY_MAN = MainForm.USER_NAME;
                                newInsLab.KEY_DATE = DateTime.Now;
                                newInsLab.SEQ = "";
                                newInsLab.CODE1 = e.Values["CODE1"].ToString();
                                newInsLab.NOTE = "";
                                newInsLab.S_NO = e.Values["s_no"].ToString();
                                newInsLab.SPTYP = e.Values["sptyp"].ToString();
                                newInsLab.WBSPTYP = e.Values["wbsptyp"].ToString();
                                trans_db.INSLAB.InsertOnSubmit(newInsLab);
                            }
                            trans_db.SubmitChanges();
                        }

                        if (isOutIns)
                        {
                            if (faidno.Length == 0)
                            {
                                //眷屬退保(先更新畫面中的資料)						
                                var inslabDS = from c in insDS.INSLAB
                                               where
                                                  c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
                                                  c.FA_IDNO.Trim().Length > 0 &&
                                                  new string[] { "1", "2" }.Contains(c.CODE.Trim()) &&
                                                  out_date >= c.IN_DATE && out_date <= c.OUT_DATE
                                               select c;
                                foreach (var row in inslabDS)
                                {
                                    row.CODE = "3";
                                    row.CODE1 = "3";
                                    row.OUT_DATE = out_date;
                                    row.ROUT_DATE = rout_date;
                                    row.L_AMT = JBModule.Data.CEncrypt.Number(0);
                                    row.H_AMT = JBModule.Data.CEncrypt.Number(row.H_AMT);
                                    row.R_AMT = JBModule.Data.CEncrypt.Number(0);
                                    iNSLABTableAdapter.Update(row);
                                }

                                //眷屬退保(再更新資料庫中的資料)						
                                var inslab = from c in trans_db.INSLAB
                                             where
                                                c.NOBR.Trim() == EmployeeId.ToString().Trim() &&
                                                c.FA_IDNO.Trim().Length > 0 &&
                                                new string[] { "1", "2" }.Contains(c.CODE.Trim()) &&
                                                out_date >= c.IN_DATE && out_date <= c.OUT_DATE
                                             select c;
                                foreach (var row in inslab)
                                {
                                    row.CODE = "3";
                                    row.CODE1 = "3";
                                    row.OUT_DATE = out_date;
                                    row.ROUT_DATE = rout_date;
                                }
                            }
                            trans_db.SubmitChanges();

                        }
                        if (textBoxL_AMT.Text != null && Convert.ToDecimal(textBoxL_AMT.Text) != 0)
                            textBoxL_AMT.Text = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxL_AMT.Text)).ToString();
                        else
                            textBoxL_AMT.Text = JBModule.Data.CEncrypt.Number(0).ToString();
                        e.Values["L_AMT"] = Convert.ToDecimal(textBoxL_AMT.Text);

                        if (textBoxH_AMT.Text != null && Convert.ToDecimal(textBoxH_AMT.Text) != 0)
                            textBoxH_AMT.Text = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxH_AMT.Text)).ToString();
                        else
                            textBoxH_AMT.Text = JBModule.Data.CEncrypt.Number(0).ToString();
                        e.Values["H_AMT"] = Convert.ToDecimal(textBoxH_AMT.Text);

                        if (textBoxR_AMT.Text != null && Convert.ToDecimal(textBoxR_AMT.Text) != 0)
                            textBoxR_AMT.Text = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(textBoxR_AMT.Text)).ToString();
                        else
                            textBoxR_AMT.Text = JBModule.Data.CEncrypt.Number(0).ToString();
                        e.Values["R_AMT"] = Convert.ToDecimal(textBoxH_AMT.Text);

                        e.Values["key_man"] = MainForm.USER_NAME;
                        e.Values["key_date"] = DateTime.Now;
                    }

                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                        //trans_db.Connection.Close();
                    }
                }
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (e.Error)
            {
                if (trans.Connection.State == ConnectionState.Open) trans.Rollback();
                return;
            }
            else
            {

                if (trans.Connection.State == ConnectionState.Open) trans.Commit();
                //if (fullDataCtrl1.RecentQuerySql.Trim().Length == 0) this.iNSLABTableAdapter.Fill(this.insDS.INSLAB);
                //else
                //{
                //    this.insDS.INSLAB.Clear();
                //    this.insDS.INSLAB.Load(new JBModule.Data.CSQL(iNSLABTableAdapter.Connection).GetDataTable(fullDataCtrl1.RecentQuerySql).CreateDataReader());
                //}

                //foreach (var row in this.insDS.INSLAB)
                //{
                //    row.L_AMT = JBModule.Data.CDecryp.Number(row.L_AMT);
                //    row.H_AMT = JBModule.Data.CDecryp.Number(row.H_AMT);
                //    row.R_AMT = JBModule.Data.CDecryp.Number(row.R_AMT);
                //}
                //InsDataClassesDataContext db = new InsDataClassesDataContext();


                //眷屬退保(先更新畫面中的資料)						
                if (isChange || isOutIns)
                {
                    var inslabDS = from c in insDS.INSLAB
                                   where
                                      c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() &&
                                      c.FA_IDNO.Trim().Length > 0 &&
                                      c.FA_IDNO.Trim() != e.Values["fa_idno"].ToString().Trim() &&
                                      new string[] { "3" }.Contains(c.CODE.Trim()) &&
                                      Convert.ToDateTime(e.Values["out_date"]) >= c.IN_DATE && Convert.ToDateTime(e.Values["out_date"]) <= c.OUT_DATE
                                   select c;
                    if (inslabDS.Any())
                    {
                        foreach (var row in inslabDS)
                        {

                            row.L_AMT = JBModule.Data.CDecryp.Number(0);
                            row.H_AMT = JBModule.Data.CDecryp.Number(row.H_AMT);
                            row.R_AMT = JBModule.Data.CDecryp.Number(0);
                        }
                    }
                }
                e.Values["L_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["L_AMT"]));
                e.Values["H_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["H_AMT"]));
                e.Values["R_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["R_AMT"]));

                this.insDS.INSLAB.AcceptChanges();

                filterData();

                isChange = false;
                isOutIns = false;
                bnAddFamily.Enabled = false;
                bnToIndt.Enabled = false;
                textBoxH_AMT.ReadOnly = false;
                txtNobr.ReadOnly = false;
                txtFaidno.ReadOnly = false;
                bnChange.Enabled = false;
                bnOutIns.Enabled = false;
                if (iNSLABBindingSource.Current != null)
                {
                    if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                    {
                        DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                        if (outDate == Convert.ToDateTime("9999/12/31"))
                        {
                            bnChange.Enabled = true;
                            bnOutIns.Enabled = true;
                        }
                    }
                }
            }

            bnView1.Enabled = true;
            bnView2.Enabled = true;
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            bnAddFamily.Enabled = false;
            bnToIndt.Enabled = false;
            textBoxH_AMT.ReadOnly = false;
            txtNobr.ReadOnly = false;
            txtFaidno.ReadOnly = false;
            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            if (iNSLABBindingSource.Current != null)
            {
                if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                {
                    DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                    if (outDate == Convert.ToDateTime("9999/12/31"))
                    {
                        bnChange.Enabled = true;
                        bnOutIns.Enabled = true;
                    }
                }
            }

            isChange = false;
            isOutIns = false;

            bnView1.Enabled = true;
            bnView2.Enabled = true;
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DecrypData();

            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            if (iNSLABBindingSource.Current != null)
            {
                if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                {
                    DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                    if (outDate == Convert.ToDateTime("9999/12/31"))
                    {
                        bnChange.Enabled = true;
                        bnOutIns.Enabled = true;
                    }
                }
            }
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DecrypData();

            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            if (iNSLABBindingSource.Current != null)
            {
                if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                {
                    DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                    if (outDate == Convert.ToDateTime("9999/12/31"))
                    {
                        bnChange.Enabled = true;
                        bnOutIns.Enabled = true;
                    }
                }
            }
        }

        private void DecrypData()
        {
            if (this.insDS.INSLAB.Count > 0)
            {
                bnChange.Enabled = true;
                bnOutIns.Enabled = true;

                for (int i = 0; i < iNSLABBindingSource.Count; i++)
                {
                    (iNSLABBindingSource[i] as DataRowView).BeginEdit();
                    if ((iNSLABBindingSource[i] as DataRowView)["L_AMT"] != null && Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["L_AMT"]) != 0)
                    {
                        (iNSLABBindingSource[i] as DataRowView)["L_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["L_AMT"]));
                    }
                    if ((iNSLABBindingSource[i] as DataRowView)["H_AMT"] != null && Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["H_AMT"]) != 0)
                    {
                        (iNSLABBindingSource[i] as DataRowView)["H_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["H_AMT"]));
                    }
                    if ((iNSLABBindingSource[i] as DataRowView)["R_AMT"] != null && Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["R_AMT"]) != 0)
                    {
                        (iNSLABBindingSource[i] as DataRowView)["R_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal((iNSLABBindingSource[i] as DataRowView)["R_AMT"]));
                    }
                    (iNSLABBindingSource[i] as DataRowView).EndEdit();
                }
                this.insDS.INSLAB.AcceptChanges();
            }
            else
            {
                bnChange.Enabled = false;
                bnOutIns.Enabled = false;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void txtFaidno_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void bnAddFamily_Click(object sender, EventArgs e)
        {
            Bas.FRM13 frm13 = new JBHR.Bas.FRM13();
            //frm13.MdiParent = this.ParentForm;
            frm13.Nobr = txtNobr.Text;
            ReturnFaIdno = "";
            frm13.ShowDialog();
            txtFaidno.Text = ReturnFaIdno;
            txtFaidno.Focus();
        }

        private void bnToIndt_Click(object sender, EventArgs e)
        {
            InsDataClassesDataContext db = new InsDataClassesDataContext();

            var basetts = from c in db.BASETTS where c.ADATE == db.BASETTS.Max(r => (r.NOBR.Trim().ToLower() == txtNobr.Text.Trim().ToLower()) ? r.ADATE : Convert.ToDateTime("1900/1/1")) && c.NOBR.Trim().ToLower() == txtNobr.Text.Trim().ToLower() select c;
            if (basetts != null)
            {
                txtBdate.Text = basetts.First().INDT.Value.ToString("yyyy/MM/dd");
            }
        }

        private void bnView1_Click(object sender, EventArgs e)
        {
            FRM32A frm32a = new FRM32A();
            frm32a.Owner = this;
            frm32a.ShowDialog();
            if (frm32a.Nobr.Trim().Length > 0)
            {
                fullDataCtrl1.bnAdd_Click(null, null);
                txtNobr.Text = frm32a.Nobr;
                bnToIndt_Click(null, null);
                button1_Click(null, null);
            }
        }
        object tmpObj = null;
        private void bnView2_Click(object sender, EventArgs e)
        {
            FRM32B frm32b = new FRM32B();
            frm32b.Owner = this;
            frm32b.ShowDialog();
            if (frm32b.Nobr.Trim().Length > 0)
            {
                fullDataCtrl1.Query(frm32b.Nobr);
                tmpObj = frm32b;
                fullDataCtrl1.BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_RunWorkerCompleted);
            }
        }

        void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FRM32B frm32b = tmpObj as FRM32B;
            if (insDS.INSLAB.Count > 0)
            {
                var sql = from a in insDS.INSLAB where a.NOBR == frm32b.Nobr && a.IN_DATE <= frm32b.outdt && a.OUT_DATE >= frm32b.outdt && a.FA_IDNO.Trim().Length == 0 select a;
                if (sql.Any())
                {
                    int index = iNSLABBindingSource.Find("in_date", sql.First().IN_DATE);
                    if (index != -1) iNSLABBindingSource.Position = index;
                    else iNSLABBindingSource.Position = 0;
                    bnOutIns_Click(null, null);
                    txtEdate.Text = Sal.Function.GetDate(frm32b.outdt);
                    txtROutDate.Text = Sal.Function.GetDate(frm32b.outdt);
                }
            }
        }

        private void txtHamt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxH_AMT.Text) > 0)
                {
                    decimal amt = 0;
                    if (decimal.TryParse(textBoxH_AMT.Text, out amt))
                    {
                        decimal amt_compare = Sal.Core.Inslab.Inslab.GetHeaAmtByInsurlv(amt);
                        if (amt != amt_compare)
                        {
                            if (MessageBox.Show(Resources.Ins.AmtLvNotFound + Environment.NewLine + "按下確定自動修正投保金額",
                                Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                                == System.Windows.Forms.DialogResult.OK)
                            {
                                textBoxH_AMT.Text = amt_compare.ToString();
                            }
                            else if (textBoxH_AMT.Enabled != false && textBoxH_AMT.ReadOnly != true)
                                textBoxH_AMT.Focus();
                        }
                    }
                }
            }
            catch
            {
                textBoxH_AMT.Text = "0";
            }
        }

        private void txtRamt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxR_AMT.Text) > 0)
                {
                    decimal amt = 0;
                    if (decimal.TryParse(textBoxR_AMT.Text, out amt))
                    {
                        decimal amt_compare = Sal.Core.Inslab.Inslab.GetRetAmtByInsurlv(amt);
                        if (amt != amt_compare)
                        {
                            if (MessageBox.Show(Resources.Ins.AmtLvNotFound + Environment.NewLine + "按下確定自動修正投保金額",
                                Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                                == System.Windows.Forms.DialogResult.OK)
                            {
                                textBoxR_AMT.Text = amt_compare.ToString();
                            }
                            else if (textBoxR_AMT.Enabled != false && textBoxR_AMT.ReadOnly != true)
                                textBoxR_AMT.Focus();
                        }
                    }
                }
            }
            catch
            {
                textBoxR_AMT.Text = "0";
            }
        }

        private void txtLamt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxL_AMT.Text) > 0)
                {
                    decimal amt = 0;
                    if (decimal.TryParse(textBoxL_AMT.Text, out amt))
                    {
                        decimal amt_compare = Sal.Core.Inslab.Inslab.GetLabAmtByInsurlv(amt);
                        if (amt != amt_compare)
                        {
                            if (MessageBox.Show(Resources.Ins.AmtLvNotFound + Environment.NewLine + "按下確定自動修正投保金額", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                            {
                                textBoxL_AMT.Text = amt_compare.ToString();
                            }
                            else if (textBoxL_AMT.Enabled != false && textBoxL_AMT.ReadOnly != true) 
                                textBoxL_AMT.Focus();
                        }
                    }
                }
            }
            catch
            {
                textBoxL_AMT.Text = "0";
            }
        }

        private void iNSLABBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bnChange.Enabled = false;
            bnOutIns.Enabled = false;
            if (iNSLABBindingSource.Current != null)
            {
                if (new string[] { "1", "2" }.Contains((iNSLABBindingSource.Current as DataRowView)["code"].ToString().Trim()))
                {
                    DateTime outDate = Convert.ToDateTime((iNSLABBindingSource.Current as DataRowView)["out_date"]);
                    if (outDate == Convert.ToDateTime("9999/12/31"))
                    {
                        //if ((iNSLABBindingSource.Current as DataRowView)["fa_idno"].ToString().Trim().Length == 0)
                        bnChange.Enabled = true;
                        bnOutIns.Enabled = true;
                    }
                }
            }
        }

        private void txtFaidno_Leave(object sender, EventArgs e)
        {
            if (txtFaidno.Text.Trim().Length > 0)
            {
                InsDataClassesDataContext db = new InsDataClassesDataContext();
                var family = (from c in db.FAMILY where c.NOBR.Trim().ToLower() == txtNobr.Text.Trim().ToLower() && c.FA_IDNO.Trim().ToLower() == txtFaidno.Text.Trim().ToLower() select c).FirstOrDefault();
                if (family == null)
                {
                    if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit)
                    {
                        MessageBox.Show(Resources.Ins.FamilyNotFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFaidno.Text = "";
                        txtFaidno.Focus();
                    }
                    txtFaName.Text = "";
                    textBoxH_AMT.Enabled = true;
                    textBoxH_AMT.ReadOnly = false;
                }
                else
                {
                    txtFaName.Text = family.FA_NAME.Trim();
                    textBoxH_AMT.ReadOnly = true;
                    //textBoxH_AMT.Enabled = false;
                }
            }
            else
            {
                txtFaName.Text = "";
                textBoxH_AMT.ReadOnly = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (txtFaidno.Text.Trim().Length > 0)
            {
                InsDataClassesDataContext db = new InsDataClassesDataContext();
                var family = (from c in insDS.FAMILY where c.NOBR.Trim().ToLower() == txtNobr.Text.Trim().ToLower() && c.FA_IDNO.Trim().ToLower() == txtFaidno.Text.Trim().ToLower() select c).FirstOrDefault();
                if (family == null)
                {
                    txtFaName.Text = "";
                }
                else
                {
                    txtFaName.Text = family.FA_NAME.Trim();
                }
            }
            else txtFaName.Text = "";

        }

        private void txtEdate_Validated(object sender, EventArgs e)
        {
            txtROutDate.Text = txtEdate.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParse(txtBdate.Text, out dd))
                {
                    var date = Convert.ToDateTime(txtBdate.Text);
                    Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
                    var sql = from a in db.SALBASD
                              join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                              join c in db.SALATTR on b.SAL_ATTR equals c.SALATTR1
                              where a.NOBR == txtNobr.Text && date >= a.ADATE && date <= a.DDATE && b.INSLAB
                              && a.AMT != 10
                              select new { SALBASD = a, SALCODE = b, SALATTR = c };
                    if (sql.Any())
                    {
                        decimal amt = 0;
                        foreach (var it in sql)
                        {
                            var value = JBModule.Data.CDecryp.Number(it.SALBASD.AMT);
                            if (it.SALATTR.FLAG != "-")
                                amt += value;
                            else amt = value;
                        }
                        if (amt > 0)
                        {
                            if (txtFaidno.Text != "")
                                textBoxL_AMT.Text = "0";
                            else
                                textBoxL_AMT.Text = Sal.Core.Inslab.Inslab.GetLabAmtByInsurlv(amt).ToString();
                            textBoxL_AMT.Focus();
                            textBoxH_AMT.Text = Sal.Core.Inslab.Inslab.GetHeaAmtByInsurlv(amt).ToString();
                            textBoxH_AMT.Focus();
                            if (txtFaidno.Text != "")
                                textBoxR_AMT.Text = "0";
                            else
                                textBoxR_AMT.Text = Sal.Core.Inslab.Inslab.GetRetAmtByInsurlv(amt).ToString();
                            textBoxR_AMT.Focus();
                            button1.Focus();
                        }
                    }
                    else
                        MessageBox.Show("查無可參考的薪資資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtFaidno_Validated(object sender, EventArgs e)
        {
            if (txtFaidno.Text.Trim().Length > 0)//只處理眷屬
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParse(txtBdate.Text, out dd))
                    CheckNobrIns(txtNobr.Text, dd);
            }
        }
        void CheckNobrIns(string Nobr, DateTime Date)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.INSLAB where a.NOBR == Nobr && Date >= a.IN_DATE && Date <= a.OUT_DATE && a.FA_IDNO.Trim().Length == 0 select a;
            if (sql.Any())
            {
                textBoxL_AMT.Text = "0";
                textBoxH_AMT.Text = JBModule.Data.CDecryp.Number(sql.First().H_AMT).ToString();
                //textBoxH_AMT.ReadOnly = true;
                textBoxR_AMT.Text = "0";
                var row = iNSLABBindingSource.Current as DataRowView;
                if (row != null)
                {
                    var row1 = row.Row as InsDS.INSLABRow;
                    if (row1 != null)
                    {
                        row1.S_NO = sql.First().S_NO;
                        comboBoxS_NO.SelectedValue = sql.First().S_NO;
                    }
                }
                if (textBoxH_AMT.Enabled != false && textBoxH_AMT.ReadOnly != true)
                    textBoxH_AMT.Focus();
            }
            else
            {

            }
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            if (txtFaidno.Text.Trim().Length > 0)//只處理眷屬
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParse(txtBdate.Text, out dd))
                    CheckNobrIns(txtNobr.Text, dd);
            }
        }

        private void txtNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                DateTime dd = new DateTime();
                if (DateTime.TryParse(txtBdate.Text, out dd))
                {
                    var date = Convert.ToDateTime(txtBdate.Text);
                    Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
                    var sql = from a in db.SALBASD
                              join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                              join c in db.SALATTR on b.SAL_ATTR equals c.SALATTR1
                              where a.NOBR == txtNobr.Text && date >= a.ADATE && date <= a.DDATE && b.INSLAB
                              && a.AMT != 10
                              select new { SALBASD = a, SALCODE = b, SALATTR = c };
                    if (sql.Any())
                    {
                        decimal amt = 0;
                        foreach (var it in sql)
                        {
                            var value = JBModule.Data.CDecryp.Number(it.SALBASD.AMT);
                            if (it.SALATTR.FLAG != "-")
                                amt += value;
                            else amt = value;
                        }
                        if (amt > 0)
                            textBoxH_AMT.Text = Sal.Core.Inslab.Inslab.GetHeaAmtByInsurlv(amt).ToString();
                    }
                }
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(txtNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
