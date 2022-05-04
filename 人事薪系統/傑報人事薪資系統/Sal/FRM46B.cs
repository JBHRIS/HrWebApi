using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM46B : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        JBControls.FullDataCtrl.EEditType etype = JBControls.FullDataCtrl.EEditType.None;
        public FRM46B()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM46B_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(ptxDept);//必要欄位檢查
            cc.AddControl(cbxSalcode);//必要欄位檢查

            SystemFunction.SetComboBoxItems(ptxDept, CodeFunction.GetDept(), true, false, true);
            ptxDept.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxSalcode, CodeFunction.GetSalCode(), true, false, true);
            cbxSalcode.Enabled = false;
            //this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Function.SetAvaliableBase(this.salaryDS.BASE);
            this.sALBASNDTableAdapter.FillByInit(this.salaryDS.SALBASND);
            this.dEPTTableAdapter1.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = this.sALBASNDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                //txtAdate.Focus();
                BASETTS basetts_row = Function.GetCurrentBasetts(ptxNobr.Text);
                if (basetts_row != null)
                {
                    ptxDept.SelectedValue = basetts_row.DEPT;
                }
            }
        }
        /// <summary>
        /// 新增後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Core.SalaryDate.DateString();
        }
        /// <summary>
        /// 修改後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            var acno = e.Values["ACNO"].ToString();
            if (smd.WAGEDD.Where(p=>p.ACNO == acno).Any())
            {
                e.Cancel = true;
                MessageBox.Show("無法刪除已存在代扣明細的代扣資料.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            if (Convert.ToDecimal(txtAPer.Text) == 0 && cbxBank.Checked)//選擇強制扣款，但是未設定1/3
            {
                e.Cancel = true;
                MessageBox.Show("選擇法院強制扣款時，強制扣款比率不可以設定為0", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                etype = fullDataCtrl1.EditType;
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["T_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt.Text));
                e.Values["P_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtPAmt.Text));
                //e.Values["F_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt.Text));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                e.Values["p_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["p_amt"]));
                e.Values["t_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["t_amt"]));
                if (etype == JBControls.FullDataCtrl.EEditType.Add)
                {
                    var acno = from salbasnd_row in smd.SALBASND where salbasnd_row.NOBR == e.Values["nobr"].ToString() && salbasnd_row.YYMM_B == e.Values["yymm_b"].ToString() && salbasnd_row.YYMM_E == e.Values["yymm_e"].ToString() select salbasnd_row;
                    if (acno.Count() > 0)
                    {
                        e.Values["acno"] = acno.Max(aa => aa.ACNO);
                        this.salaryDS.SALBASND.AcceptChanges();
                    }
                }
            }
        }

        /// <summary>
        /// 匯出後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        /// <summary>
        /// 查詢後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        void GridBind()
        {
            //// TODO: 這行程式碼會將資料載入 'salaryDS.SALBASD' 資料表。您可以視需要進行移動或移除。
            foreach (var itm in this.salaryDS.SALBASND)
            {
                itm.P_AMT = JBModule.Data.CDecryp.Number(itm.P_AMT);
                itm.T_AMT = JBModule.Data.CDecryp.Number(itm.T_AMT);
                itm.F_AMT = JBModule.Data.CDecryp.Number(itm.F_AMT);
            }
            this.salaryDS.SALBASND.AcceptChanges();
        }

        private void txtSeq_Validated(object sender, EventArgs e)
        {
            //txtYymmB.Focus();
        }

        private void txtYymmE_Validated(object sender, EventArgs e)
        {
            //cbxBank.Focus();
        }

        private void txtPPer_Validated(object sender, EventArgs e)
        {
            //txtDeDept.Focus();
        }

        private void txtLawTel_Validated(object sender, EventArgs e)
        {
            //txtPDate.Focus();
        }

        private void txtCDate_Validated(object sender, EventArgs e)
        {
            //txtMemo.Focus();
        }
        //bool CanModify(string nobr)
        //{
        //    var sql = from b in smd.BASETTS
        //              where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE
        //              && (b.SALADR == MainForm.WORKADR || MainForm.PROCSUPER) && b.NOBR == nobr
        //              select b;
        //    return sql.Any();
        //}

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    SalaryMDDataContext db = new SalaryMDDataContext();
                    var sql = from a in db.WAGEDD where a.NOBR == ptxNobr.Text && a.ACNO == txtAcno.Text select a;
                    if (sql.Any())
                    {
                        decimal amt = sql.ToList().Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                        txtPayed.Text = amt.ToString();
                        decimal Total = decimal.Parse(txtAmt.Text);
                        txtHasToPay.Text = (Total - amt).ToString();
                    }
                }
                catch (Exception ex)
                {
                    txtPayed.Text = "---";
                    txtHasToPay.Text = "---";
                }
            }
        }
    }
}
