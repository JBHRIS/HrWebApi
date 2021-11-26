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
    public partial class FRM49CN : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM49CN()
        {
            InitializeComponent();
        }

        private void FRM49_Load(object sender, EventArgs e)
        {
            this.insCnCompTableAdapter.Fill(this.insDS.InsCnComp);
            this.insurCnCodeTableAdapter.Fill(this.insDS.InsurCnCode);
            this.explabCNTableAdapter.FillByInit(this.salaryDS.ExplabCN);
            this.cOMPTableAdapter.Fill(this.baseDS.COMP);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE);

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
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("EXPLABCN");
            cbxModify.Enabled = false;

            fullDataCtrl1.DataAdapter = explabCNTableAdapter;
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
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;

                e.Values["comp"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["comp"]));
                e.Values["exp"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["exp"]));
                e.Values["AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["AMT"]));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["comp"]));
            e.Values["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["exp"]));
            e.Values["AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["AMT"]));
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                this.salaryDS.ExplabCN.AcceptChanges();
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
            foreach (var itm in this.salaryDS.ExplabCN)
            {
                try
                {
                    if (itm.COMP != 0)
                        itm.COMP = JBModule.Data.CDecryp.Number(itm.COMP);
                    if (itm.EXP != 0)
                        itm.EXP = JBModule.Data.CDecryp.Number(itm.EXP);
                    if (itm.AMT != 0)
                        itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
                }
                catch (Exception ex)
                {

                }
            }
            this.salaryDS.EXPLAB.AcceptChanges();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
           
        }
    }
}
