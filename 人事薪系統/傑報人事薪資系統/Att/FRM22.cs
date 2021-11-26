using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM22 : JBControls.JBForm
    {
        public FRM22()
        {
            InitializeComponent();
        }
        bool isAdd = false;
        bool isEdit = false;
        JBModule.Data.Dto.CardappDto oldCardappDto = new JBModule.Data.Dto.CardappDto();
        JBModule.Data.Dto.CardappDto newCardappDto = new JBModule.Data.Dto.CardappDto();
        JBModule.Data.Repo.CardappRepo cardappRepo = new JBModule.Data.Repo.CardappRepo();
        private void FRM22_Load(object sender, EventArgs e)
        {
            this.taCARDAPP.FillByInit(this.dsAtt.CARDAPP);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
           fdc.WhereCmd = Sal.Function.GetFilterCmd("CARDAPP");

            fdc.DataAdapter = taCARDAPP;
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            SetCardappDto(ref newCardappDto);
            string Msg = "";
            if (isAdd)
            {
                if (!cardappRepo.CanInsertCardapp(newCardappDto, out Msg))
                {
                    MessageBox.Show(Msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
            else if (isEdit)
            {
                if (!cardappRepo.CanUpdateCardapp(oldCardappDto, newCardappDto, out Msg))
                {
                    MessageBox.Show(Msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
            if (!Sal.Function.CanModify(ptxNobr.Text))// if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private bool ModifyCheck(string Nobr)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (MainForm.ADMIN)
            {
                var sqlAdmin = from b in db.BASETTS
                               where DateTime.Now.Date <= b.DDATE
                               && b.NOBR == Nobr
                               //&& (from a in db.COMP_DATAGROUP where a.DATAGROUP == b.SALADR &&  a.COMP == MainForm.COMPANY select a).Any()
                               select b;
                return sqlAdmin.Any() && MainForm.WriteRules.Where(p => p.DATAGROUP == sqlAdmin.First().SALADR).Any();
            }

            var sql = from b in db.BASETTS
                      where DateTime.Now.Date <= b.DDATE
                      && b.NOBR == Nobr
                      //&& (from a in db.U_DATAGROUP where a.DATAGROUP == b.SALADR && a.READRULE && a.USER_ID == MainForm.USER_ID && a.COMPANY == MainForm.COMPANY select a).Any()
                      select b;
            return sql.Any() && MainForm.WriteRules.Where(p => p.DATAGROUP == sql.First().SALADR).Any();
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
                isAdd = false;
                isEdit = false;
            }
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            isAdd = true;
            txtEDATE.Text = new DateTime(9999, 12, 31).ToShortDateString();
            ptxNobr.Focus();
            
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            isEdit = true;
            SetCardappDto(ref oldCardappDto);
            checkBox1.Focus();
            ptxNobr.Enabled = false;
        }

        private void popupTextBox1_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //    textBox1.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))//!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        void SetCardappDto(ref JBModule.Data.Dto.CardappDto cardappDto)
        {
            cardappDto.BDATE = Convert.ToDateTime(txtBDATE.Text);
            cardappDto.EDATE = Convert.ToDateTime(txtEDATE.Text);
            cardappDto.NOBR = ptxNobr.Text;
            cardappDto.CARDNO = txtCARDNO.Text;
        }

        private void fdc_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            isAdd = false;
            isEdit = false;
        }
    }
}
