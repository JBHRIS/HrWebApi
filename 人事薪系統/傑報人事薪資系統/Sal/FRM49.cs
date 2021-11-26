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
    public partial class FRM49 : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM49()
        {
            InitializeComponent();
        }

        private void FRM49_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbINSUR_TYPE, CodeFunction.GetMtCode("INSUR_TYPE"), true, false, true);
            cbINSUR_TYPE.Enabled = false;
            this.cOMPTableAdapter.Fill(this.baseDS.COMP);
            //this.iNSUR_TYPETableAdapter.Fill(this.viewDS.INSUR_TYPE);
            this.eXPLABTableAdapter.FillByInit(this.salaryDS.EXPLAB);

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
           fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            //填入薪資科目items
            var salcode = from sc in smd.SALCODE
                          where new string[]
                          {
                              MainForm.LabConfig.LSALCODE,
                              MainForm.HealthConfig.HSALCODE,
                              MainForm.LabConfig.RETSALCODE
                          }
                          .Contains(sc.SAL_CODE)
                          select sc;
            this.salaryDS.SALCODE.FillData(smd.GetCommand(salcode));

            fullDataCtrl1.DataAdapter = eXPLABTableAdapter;
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
                e.Values["jobamt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["jobamt"]));
                e.Values["fundamt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["fundamt"]));
                e.Values["exp"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["exp"]));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["comp"]));
            e.Values["jobamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["jobamt"]));
            e.Values["fundamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["fundamt"]));
            e.Values["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["exp"]));
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                this.salaryDS.EXPLAB.AcceptChanges();
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
            foreach (var itm in this.salaryDS.EXPLAB)
            {
                try
                {
                    if (itm.COMP != 0)
                        itm.COMP = JBModule.Data.CDecryp.Number(itm.COMP);
                    if (itm.EXP != 0)
                        itm.EXP = JBModule.Data.CDecryp.Number(itm.EXP);
                    if (itm.JOBAMT != 0)
                        itm.JOBAMT = JBModule.Data.CDecryp.Number(itm.JOBAMT);
                    if (itm.FUNDAMT != 0)
                        itm.FUNDAMT = JBModule.Data.CDecryp.Number(itm.FUNDAMT);
                }
                catch (Exception ex)
                {

                }
            }
            this.salaryDS.EXPLAB.AcceptChanges();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                try
                {
                    var fa = from ff in smd.FAMILY where ff.NOBR == ptxNobr.Text && ff.FA_IDNO.Trim().Length > 0 select ff;
                    this.baseDS.FAMILY.FillData(smd.GetCommand(fa));
                    BaseDS.FAMILYRow r = this.baseDS.FAMILY.NewFAMILYRow();
                    r.ADDR = "";
                    r.AUTOINSLAB = false;
                    r.BBC = "";
                    r.COMPNY = "";
                    r.EDUCODE = "";
                    r.FA_BIRDT = DateTime.Now;
                    r.FA_IDNO = "";
                    r.FA_NAME = "";
                    r.FAMFORN = false;
                    r.GSM = "";
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = "";
                    r.LIVE = false;
                    r.NOBR = ptxNobr.Text;
                    r.REL_CODE = "";
                    r.TAX = false;
                    r.TEL = "";
                    r.TITLE = "";
                    this.baseDS.FAMILY.AddFAMILYRow(r);
                }
                catch
                {

                }
                //ptxFaName.Focus();
            }
        }
    }
}
