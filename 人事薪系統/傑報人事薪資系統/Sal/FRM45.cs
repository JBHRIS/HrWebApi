using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Data;
using JBHR.Sal.Core;
namespace JBHR.Sal
{
    public partial class FRM45 : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        #region 參數
        /// <summary>
        /// 應發薪資
        /// </summary>
        decimal Must_Pay = 0;
        /// <summary>
        /// 應發應稅
        /// </summary>
        decimal Must_Pay_Tax = 0;
        /// <summary>
        /// 應付薪資
        /// </summary>
        decimal Real_Pay = 0;
        /// <summary>
        /// 應扣薪資
        /// </summary>
        decimal Must_Cut = 0;
        /// <summary>
        /// 應扣應稅
        /// </summary>
        decimal Must_Cut_Tax = 0;
        /// <summary>
        /// 應稅薪資
        /// </summary>
        decimal Must_Tax = 0;
        /// <summary>
        /// 代扣總計
        /// </summary>
        decimal Teco_Total = 0;
        /// <summary>
        /// 實付薪資
        /// </summary>
        decimal Total_Amt = 0;
        /// <summary>
        /// 所得稅
        /// </summary>
        decimal Tax_Amt = 0;
        /// <summary>
        /// 銀行代扣
        /// </summary>
        decimal Bank_Teco = 0;
        /// <summary>
        /// 媒體格式
        /// </summary>
        string Format = "";
        #endregion

        public FRM45()
        {
            InitializeComponent();
        }

        private void FRM45_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'medDS.YRFORMAT' 資料表。您可以視需要進行移動或移除。
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
            this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
            this.sALCODETableAdapter.Fill(this.dsPlus.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.wAGEDTableAdapter.FillByInit(this.dsPlus.WAGED);

            var plusSQL = from a in smd.SALCODE
                          join b in smd.SALATTR on a.SAL_ATTR equals b.SALATTR1
                          where b.TYPE == "1"
                          select a;
            var minusSQL = from a in smd.SALCODE
                           join b in smd.SALATTR on a.SAL_ATTR equals b.SALATTR1
                           where b.TYPE == "2"
                           select a;
            var tecoSQL = from a in smd.SALCODE
                          join b in smd.SALATTR on a.SAL_ATTR equals b.SALATTR1
                          where b.TYPE == "3"
                          select a;
            this.dsPlus.SALCODE.FillData(smd.GetCommand(plusSQL));
            this.dsMinus.SALCODE.FillData(smd.GetCommand(minusSQL));
            this.dsTeco.SALCODE.FillData(smd.GetCommand(tecoSQL));

            Function.SetAvaliableBase(this.dsPlus.BASE);
            SetEnable(false);
            FormInit();
        }
        /// <summary>
        /// 畫面初始化
        /// </summary>
        void FormInit()
        {
            txtSeq.Enabled = false;
            txtYymm.Enabled = false;
            ptxNobr.Enabled = false;
            if (lblState.Text == "add" || lblState.Text == "edit")
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (lblState.Text == "query")
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (lblState.Text == "cancel")
            {
                RejectChange();
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            if (Function.IsSalaryLockedByNobr(txtYymm.Text, txtSeq.Text, ptxNobr.Text))//已鎖檔
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }

            btnAdd.Focus();

            //if (txtYymm.Text.Trim().Length > 0)
            //{
            //    SalaryDate sd = new SalaryDate(txtYymm.Text);
            //    textBox1.Text = Function.GetDate(sd.FirstDayOfAttend);
            //    textBox2.Text = Function.GetDate(sd.LastDayOfAttend);
            //}
        }
        /// <summary>
        /// 參數繫結
        /// </summary>
        void ValueBinding()
        {
            Must_Pay = this.dsPlus.WAGED.Any() ? this.dsPlus.WAGED.Sum(amt => amt.AMT) : 0;

            var pay_tax_List = from dt in this.dsPlus.WAGED
                               join salcode in SalaryVar.dtSalcode on dt.SAL_CODE equals salcode.SAL_CODE
                               join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1
                               where salattr.TAX
                               select dt.AMT;
            Must_Pay_Tax = pay_tax_List.Any() ? pay_tax_List.Sum() : 0;

            Must_Cut = this.dsMinus.WAGED.Any() ? this.dsMinus.WAGED.Sum(amt => amt.AMT) : 0;
            var cutList = (from dt in this.dsMinus.WAGED join salcode in SalaryVar.dtSalcode on dt.SAL_CODE equals salcode.SAL_CODE join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1 where salattr.TAX select dt.AMT);
            Must_Cut_Tax = cutList.Any() ? cutList.Sum() : 0;

            Teco_Total = this.dsTeco.WAGED.Sum(amt => amt.AMT);
            var waged_bank = (from a in smd.WAGED
                              join b in smd.SALCODE on a.SAL_CODE equals b.SAL_CODE
                              where a.NOBR == ptxNobr.Text
                              && a.YYMM == txtYymm.Text
                              && a.SEQ == txtSeq.Text
                              && b.SAL_ATTR == "R"
                              select a).ToList();
            //foreach (var it in waged_bank)
            //    it.AMT = JBModule.Data.CDecryp.Number(it.AMT);
            Bank_Teco = waged_bank.Any() ? waged_bank.Sum(amt => JBModule.Data.CDecryp.Number(amt.AMT)) : 0;

            var waged_tax = (from a in smd.WAGED
                             join b in smd.SALCODE on a.SAL_CODE equals b.SAL_CODE
                             where a.NOBR == ptxNobr.Text
                             && a.YYMM == txtYymm.Text
                             && a.SEQ == txtSeq.Text
                             && b.SAL_CODE == MainForm.TaxConfig.TAXSALCODE
                             select a).ToList();
            Tax_Amt = waged_tax.Any() ? waged_tax.Sum(amt => JBModule.Data.CDecryp.Number(amt.AMT)) : 0;
            Must_Tax = Must_Pay_Tax - Must_Cut_Tax;
            Real_Pay = Must_Pay - Must_Cut;
            Total_Amt = Real_Pay - Teco_Total;
            txtPayAmt.Text = Must_Pay.ToString();
            txtPayTax.Text = Must_Pay_Tax.ToString();
            txtTecoTotal.Text = Teco_Total.ToString();
            txtCut.Text = Must_Cut.ToString();
            txtCutTax.Text = Must_Cut_Tax.ToString();
            txtPayTotal.Text = Real_Pay.ToString();
            txtTotalAmt.Text = Total_Amt.ToString();
            txtTaxTotal.Text = Must_Tax.ToString();
            txtTaxAmt.Text = Tax_Amt.ToString();
            txtBankTeco.Text = Bank_Teco.ToString();
            //comboBox1.SelectedValue = Format;
        }
        /// <summary>
        /// 計算
        /// </summary>
        /// <returns></returns>
        int Calc()
        {
            //dvPlus.DataSource = null;//初始化-清空
            //dvMinus.DataSource = null;
            //dvTeco.DataSource = null;
            if (!Function.CanView(ptxNobr.Text))//沒有檢視的權限
            {
                MessageBox.Show(Resources.Sal.NonReadableRule, Resources.All.DialogTitle,
                                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return 0;
            }
            if (!Function.CanModify(ptxNobr.Text))//沒有修改的權限
            {
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle,
                                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //return 0;//沒修改權限，不過可以檢視，所以只做提示
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }

            dsPlus.WAGE.Clear();
            dsPlus.WAGED.Clear();
            dsMinus.WAGED.Clear();
            dsTeco.WAGED.Clear();

            var data = from waged in smd.WAGED
                       join salcode in smd.SALCODE on waged.SAL_CODE equals salcode.SAL_CODE
                       where waged.NOBR.Trim() == ptxNobr.Text.Trim()
                       && waged.YYMM.Trim() == txtYymm.Text.Trim() && waged.SEQ.Trim() == txtSeq.Text.Trim()
                       select waged;

            int i = 0;
            //取得計薪主檔
            var wage_sql = from wage in smd.WAGE
                           where wage.NOBR.Trim() == ptxNobr.Text.Trim()
                           && wage.YYMM.Trim() == txtYymm.Text.Trim() && wage.SEQ.Trim() == txtSeq.Text.Trim()
                           select wage;
            this.dsPlus.WAGE.FillData(smd.GetCommand(wage_sql));
            var wage_data = this.dsPlus.WAGE;

            if (lblState.Text == "edit")//如果是修改，顯示既有的資料
            {
                i = wage_data.Count();
                if (i == 0)
                {
                    MessageBox.Show(Resources.Sal.SalaryDataNoFound, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnQuery.Focus();
                    return 0;
                }

            }
            else if (lblState.Text == "add")
            {
                if (wage_data.Any())
                {
                    MessageBox.Show(Resources.Sal.WageIsExists, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return 0;
                }
                if (!Function.CanModify(ptxNobr.Text))
                {
                    MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//不能修改，所以終止新增的動作
                    return 0;
                }
                SalaryDS.WAGERow rWage = dsPlus.WAGE.NewWAGERow();//如果是新增就加入一筆主檔
                var baseSQL = from a in smd.BASE
                              join b in smd.BASETTS on a.NOBR equals b.NOBR
                              where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE.Value
                              && a.NOBR == ptxNobr.Text
                              select new { BASE = a, BASETTS = b };
                if (!baseSQL.Any())//找不到basetts
                {
                    MessageBox.Show(Resources.Sal.DataNoFound + "(BASETTS)", Resources.All.DialogTitle,
                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return 0;
                }
                SalaryDate sd = new SalaryDate(txtYymm.Text);
                var baseData = baseSQL.First();
                rWage.ACCOUNT_NO = baseData.BASE.ACCOUNT_NO;
                rWage.ADATE = DateTime.Now.Date;
                rWage.BANKNO = baseData.BASE.BANKNO;
                rWage.CASH = false;
                rWage.COMP = baseData.BASETTS.COMP;
                rWage.DATE_B = sd.FirstDayOfSalary;
                rWage.DATE_E = sd.LastDayOfSalary;
                rWage.FORMAT = "50";
                rWage.KEY_DATE = DateTime.Now;
                rWage.KEY_MAN = MainForm.USER_NAME;
                rWage.NOBR = ptxNobr.Text;
                rWage.NOTE = "";
                rWage.SALADR = baseData.BASETTS.SALADR;
                rWage.SEQ = txtSeq.Text;
                rWage.TAXRATE = 1;
                rWage.WK_DAYS = sd.TotalSalaryDays;
                rWage.YYMM = txtYymm.Text;
                dsPlus.WAGE.AddWAGERow(rWage);
                SetEnable(true);
                (wAGEBindingSource.Current as DataRowView).BeginEdit();
                foreach (var itm in SalaryVar.dtSalcode.OrderBy(p => p.SAL_CODE_DISP))//依照屬性分配
                {
                    var qq = from a in SalaryVar.dtSalattr where a.SALATTR1 == itm.SAL_ATTR select a;
                    if (qq.Any())
                    {
                        var q = qq.First();
                        SalaryDS.WAGEDRow r;
                        if (q.TYPE == "1") r = dsPlus.WAGED.NewWAGEDRow();
                        else if (q.TYPE == "2") r = dsMinus.WAGED.NewWAGEDRow();
                        else if (q.TYPE == "3") r = dsTeco.WAGED.NewWAGEDRow();
                        else continue;
                        r.AMT = 0;
                        r.NOBR = ptxNobr.Text;
                        r.SAL_CODE = itm.SAL_CODE;
                        r.SEQ = txtSeq.Text;
                        r.YYMM = txtYymm.Text;
                        if (q.TYPE == "1") dsPlus.WAGED.AddWAGEDRow(r);
                        else if (q.TYPE == "2") dsMinus.WAGED.AddWAGEDRow(r);
                        else if (q.TYPE == "3") dsTeco.WAGED.AddWAGEDRow(r);
                    }
                }

            }
            if (this.dsPlus.WAGE.Count() == 0)
            {
                Init();
                return 0;
            }

            var total_data = data;
            //資料分成四類
            var waged_plus = from waged in total_data join salcode in smd.SALCODE on waged.SAL_CODE equals salcode.SAL_CODE join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1 where salattr.TYPE.Trim() == "1" orderby salcode.SAL_CODE_DISP select waged;
            var waged_minus = from waged in total_data join salcode in smd.SALCODE on waged.SAL_CODE equals salcode.SAL_CODE join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1 where salattr.TYPE.Trim() == "2" orderby salcode.SAL_CODE_DISP select waged;
            var waged_teco = from waged in total_data join salcode in smd.SALCODE on waged.SAL_CODE equals salcode.SAL_CODE join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1 where salattr.TYPE.Trim() == "3" orderby salcode.SAL_CODE_DISP select waged;
            var waged_bank = from waged in total_data join salcode in smd.SALCODE on waged.SAL_CODE equals salcode.SAL_CODE join salattr in smd.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1 where salattr.TYPE.Trim() == "4" orderby salcode.SAL_CODE_DISP select waged;


            this.dsPlus.WAGED.FillData(smd.GetCommand(waged_plus));
            foreach (var ii in this.dsPlus.WAGED)
                ii.AMT = JBModule.Data.CDecryp.Number(ii.AMT);
            this.dsMinus.WAGED.FillData(smd.GetCommand(waged_minus));
            foreach (var ii in this.dsMinus.WAGED)
                ii.AMT = JBModule.Data.CDecryp.Number(ii.AMT);
            this.dsTeco.WAGED.FillData(smd.GetCommand(waged_teco));
            foreach (var ii in this.dsTeco.WAGED)
                ii.AMT = JBModule.Data.CDecryp.Number(ii.AMT);
            //計算

            ValueBinding();
            FormInit();
            return i;
        }

        private void txtYymm_Validated(object sender, EventArgs e)
        {
            try
            {
                SalaryDate sd = new SalaryDate(txtYymm.Text);
                txtSeq.Enabled = true;
                txtSeq.Focus();
            }
            catch
            {
                MessageBox.Show(Resources.Sal.YymmFormatInvalidated, Resources.All.DialogTitle,
                         MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtYymm.Focus();
            }
        }

        private void txtSeq_Validated(object sender, EventArgs e)
        {
            //if (Function.IsSalaryLocked(txtYymm.Text, txtSeq.Text, MainForm.WORKADR))//已鎖檔
            //{
            //    MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
            //            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            ptxNobr.Enabled = true;
            ptxNobr.Focus();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)//如果有員工資料，在執行focus out的動作
            {
                smd = new SalaryMDDataContext();
                bool RetruenSW = false;
                if (Function.IsSalaryLockedByNobr(txtYymm.Text, txtSeq.Text, ptxNobr.Text))//已鎖檔
                {
                    MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (lblState.Text == "add")
                    {
                        RetruenSW = true;
                        txtYymm.Focus();
                    }
                }
                if (!RetruenSW)
                    Calc();
                //FormInit();
            }
            //else ptxNobr.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RejectChange();//取消變更
            txtYymm.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            lblState.Text = "add";
            SetEnable(false);
            txtYymm.Focus();

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            RejectChange();//取消變更
            txtYymm.Enabled = true;
            btnSave.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            lblState.Text = "query";
            SetEnable(false);
            txtYymm.Focus();
        }

        private void dvPlus_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            JBControls.DataGridView dv = sender as JBControls.DataGridView;
            if (!dv.ReadOnly)
            {
                var row = (dv.DataSource as BindingSource).Current as DataRowView;
                row["yymm"] = txtYymm.Text;
                row["seq"] = txtSeq.Text;
                row["nobr"] = ptxNobr.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Function.CanModify(ptxNobr.Text))//沒有修改的權限
            {
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle,
                                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;//沒修改權限
            }
            if (Function.IsSalaryLockedByNobr(txtYymm.Text, txtSeq.Text, ptxNobr.Text))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //加密後寫回，寫回後解密
            if (MessageBox.Show(Resources.Sal.DataChangeConfirm, Resources.All.DialogTitle,
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var dvP = (bsWagedPlus.Current as DataRowView);
                if (dvP != null) dvP.EndEdit();
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.dsPlus.WAGED);
                foreach (var itm in dsPlus.WAGED)
                {
                    itm.AMT = JBModule.Data.CEncrypt.Number(itm.AMT);
                    if (lblState.Text == "add" && itm.AMT == 10)
                    {
                        //itm.Delete();
                        itm.AcceptChanges();//新增時，不帶入0
                    }
                }
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.dsPlus.WAGED);
                this.wAGEDTableAdapter.Update(dsPlus.WAGED);
                foreach (var itm in dsPlus.WAGED) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);

                var dvM = (bsWageMinus.Current as DataRowView);
                if (dvM != null) dvM.EndEdit();
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.dsMinus.WAGED);
                foreach (var itm in dsMinus.WAGED)
                {
                    itm.AMT = JBModule.Data.CEncrypt.Number(itm.AMT);
                    if (lblState.Text == "add" && itm.AMT == 10)
                    {
                        //itm.Delete();
                        itm.AcceptChanges();//新增時，不帶入0
                    }
                }
                this.wAGEDTableAdapter.Update(dsMinus.WAGED);

                //(bsWageTeco.Current as DataRowView).EndEdit();
                var dvT = (bsWageTeco.Current as DataRowView);
                if (dvT != null) dvT.EndEdit();
                foreach (var itm in dsMinus.WAGED) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);

                foreach (var itm in dsTeco.WAGED)
                {
                    itm.AMT = JBModule.Data.CEncrypt.Number(itm.AMT);
                    if (lblState.Text == "add" && itm.AMT == 10)
                        itm.AcceptChanges();//新增時，不帶入0
                }
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.dsTeco.WAGED);
                this.wAGEDTableAdapter.Update(dsTeco.WAGED);
                foreach (var itm in dsTeco.WAGED) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);

                //(wAGEBindingSource.Current as DataRowView).EndEdit();
                var dvB = (wAGEBindingSource.Current as DataRowView);
                if (dvB != null) dvB.EndEdit();
                if (this.dsPlus.WAGE.Any())
                {
                    this.dsPlus.WAGE.First().KEY_DATE = DateTime.Now;
                    this.dsPlus.WAGE.First().KEY_MAN = MainForm.USER_NAME;
                }
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.dsPlus.WAGE);
                this.wAGETableAdapter.Update(this.dsPlus.WAGE);//更新主檔
            }
            else return;
            btnAdd.Enabled = true;
            btnQuery.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            SetEnable(false);
            lblState.Text = "wait";
        }
        void RejectChange()
        {
            dsPlus.WAGE.RejectChanges();
            dsPlus.WAGED.RejectChanges();
            dsMinus.WAGED.RejectChanges();
            dsTeco.WAGED.RejectChanges();

            dsPlus.WAGE.Clear();
            dsPlus.WAGED.Clear();
            dsMinus.WAGED.Clear();
            dsTeco.WAGED.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Function.CanModify(ptxNobr.Text))//沒有修改的權限
            {
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle,
                                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;//沒修改權限
            }
            if (Function.IsSalaryLockedByNobr(txtYymm.Text, txtSeq.Text, ptxNobr.Text))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (MessageBox.Show(Resources.Sal.DeleteConfirm, Resources.All.DialogTitle,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                //加密後寫回，寫回後解密
                foreach (var itm in dsPlus.WAGED) itm.Delete();
                this.wAGEDTableAdapter.Update(dsPlus.WAGED);

                foreach (var itm in dsMinus.WAGED) itm.Delete();
                this.wAGEDTableAdapter.Update(dsMinus.WAGED);

                foreach (var itm in dsTeco.WAGED) itm.Delete();
                this.wAGEDTableAdapter.Update(dsTeco.WAGED);

                foreach (var itm in dsPlus.WAGE) itm.Delete();
                this.wAGETableAdapter.Update(this.dsPlus.WAGE);//更新主檔

                btnAdd.Enabled = true;
                btnQuery.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        void Init()
        {
            textBox12.Text = "";
            txtSalDateB.Text = "";
            txtSalDateE.Text = "";
            textBox14.Text = "";
            textBox17.Text = "";
            textBox20.Text = "";
            textBox18.Text = "";
            textBox21.Text = "";
            comboBox1.SelectedValue = "";
            checkBox1.Checked = false;
            textBox16.Text = "";
        }
        void SetEnable(bool enable)
        {
            txtSalDateB.Enabled = enable;
            txtSalDateE.Enabled = enable;

            textBox14.Enabled = enable;
            textBox12.Enabled = enable;

            textBox16.Enabled = enable;
            textBox17.Enabled = enable;
            dvPlus.ReadOnly = !enable;
            dvMinus.ReadOnly = !enable;
            dvTeco.ReadOnly = !enable;

            //tableLayoutPanel4.Enabled = enable;
            tableLayoutPanel5.Enabled = enable;
            tableLayoutPanel6.Enabled = enable;
            tableLayoutPanel7.Enabled = enable;
        }

        private void dvPlus_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            ValueBinding();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            FRM45A frm = new FRM45A();
            frm.nobr = ptxNobr.Text;
            frm.yymm = txtYymm.Text;
            if (txtYymm.Text.Trim().Length > 0)
            {
                if (DateTime.TryParse(textBox1.Text, out frm.d1) && DateTime.TryParse(textBox2.Text, out frm.d2))
                {
                    frm.d1 = Convert.ToDateTime(textBox1.Text);
                    frm.d2 = Convert.ToDateTime(textBox2.Text);
                    frm.ShowDialog();
                }
            }
        }

        private void btnOT_Click(object sender, EventArgs e)
        {
            FRM45B frm = new FRM45B();
            frm.nobr = ptxNobr.Text;
            if (txtYymm.Text.Trim().Length > 0)
            {
                frm.yymm = txtYymm.Text;
                frm.ShowDialog();
            }
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            FRM45C frm = new FRM45C();
            frm.nobr = ptxNobr.Text;
            if (txtYymm.Text.Trim().Length > 0)
            {
                frm.yymm = txtYymm.Text;
                frm.ShowDialog();
            }
        }

        private void btnInslab_Click(object sender, EventArgs e)
        {
            FRM45D frm = new FRM45D();
            frm.nobr = ptxNobr.Text;
            if (txtYymm.Text.Trim().Length > 0)
            {
                frm.yymm = txtYymm.Text;
                frm.ShowDialog();
            }
        }

        private void btnBase_Click(object sender, EventArgs e)
        {
            FRM45E frm = new FRM45E();
            frm.nobr = ptxNobr.Text;
            if (txtYymm.Text.Trim().Length > 0)
            {
                frm.d1 = Convert.ToDateTime(textBox1.Text);
                frm.d2 = Convert.ToDateTime(textBox2.Text);
                frm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtYymm.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            lblState.Text = "edit";
            SetEnable(true);
            (wAGEBindingSource.Current as DataRowView).BeginEdit();
            FormInit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblState.Text = "cancel";
            FormInit();
            SetEnable(false);
        }
    }
}
