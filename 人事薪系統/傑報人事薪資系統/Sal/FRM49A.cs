using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
namespace JBHR.Sal
{
    public partial class FRM49A : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM49A()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢察
        private void FRM49_Load(object sender, EventArgs e)
        {
            //SystemFunction.SetComboBoxItems(cbxSalcode, CodeFunction.GetSalCode(), true);
            SystemFunction.SetComboBoxItems(cbxSNO, CodeFunction.GetInsComp(), true, false, true);
            SystemFunction.SetComboBoxItems(cbxFormat, CodeFunction.GetFormat(), true, false, true);
            cc = new CheckControl();//必要欄位檢察
            cc.AddControl(cbxFormat);//必要欄位檢察
            cc.AddControl(txtClass);//必要欄位檢察
            cc.AddControl(cbxSNO);//必要欄位檢察
            this.iNSCOMPTableAdapter.Fill(this.insDS.INSCOMP, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.eXPSUPTableAdapter.FillByInit(this.salaryDS.EXPSUP);
            this.cOMPTableAdapter.Fill(this.baseDS.COMP);
            this.iNSUR_TYPETableAdapter.Fill(this.viewDS.INSUR_TYPE);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("EXPSUP");

            //填入薪資科目items
            var salcode = from sc in smd.SALCODE
                          select sc;
            this.salaryDS.SALCODE.FillData(smd.GetCommand(salcode));

            fullDataCtrl1.DataAdapter = eXPSUPTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;

                e.Values["sup_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["sup_amt"]));
                e.Values["pay_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["pay_amt"]));
                e.Values["ins_hamt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["ins_hamt"]));
                e.Values["total_amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["total_amt"]));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["sup_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["sup_amt"]));
            e.Values["pay_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["pay_amt"]));
            e.Values["ins_hamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["ins_hamt"]));
            e.Values["total_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["total_amt"]));
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                this.salaryDS.EXPSUP.AcceptChanges();
            }
        }
        void fdc_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            JBModule.Data.CNPOI.RenderDataTableToExcel(this.salaryDS.EXPLAB, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.EXPSUP)
            {
                try
                {
                    if (itm.INS_HAMT != 0)
                        itm.INS_HAMT = JBModule.Data.CDecryp.Number(itm.INS_HAMT);
                    if (itm.PAY_AMT != 0)
                        itm.PAY_AMT = JBModule.Data.CDecryp.Number(itm.PAY_AMT);
                    if (itm.SUP_AMT != 0)
                        itm.SUP_AMT = JBModule.Data.CDecryp.Number(itm.SUP_AMT);
                    if (itm.TOTAL_AMT != 0)
                        itm.TOTAL_AMT = JBModule.Data.CDecryp.Number(itm.TOTAL_AMT);
                }
                catch (Exception ex)
                {

                }
            }
            this.salaryDS.EXPSUP.AcceptChanges();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                
                //ptxFaName.Focus();
            }
        }
    }
}
