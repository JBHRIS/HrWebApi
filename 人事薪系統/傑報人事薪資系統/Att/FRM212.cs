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
    public partial class FRM212 : JBControls.JBForm
    {
        public FRM212()
        {
            InitializeComponent();
        }
        CheckTimeFormatControl CTFC = new CheckTimeFormatControl();
        private void FRM212_Load(object sender, EventArgs e)
        {
            CTFC.AddControl(txtON_TIME, true, false, false);
            CTFC.AddControl(txtOFF_TIME, true, false, false);
            CTFC.AddControl(txtATT_END, true, false, false);
            CTFC.AddControl(txtRES_B_TIME, true, false, false);
            CTFC.AddControl(txtRES_E_TIME, true, false, false);
            CTFC.AddControl(txtRES_B2_TIME, true, false, false);
            CTFC.AddControl(txtRES_E2_TIME, true, false, false);
            CTFC.AddControl(txtRES_B3_TIME, true, false, false);
            CTFC.AddControl(txtRES_E3_TIME, true, false, false);
            CTFC.AddControl(txtRES_B4_TIME, true, false, false);
            CTFC.AddControl(txtRES_E4_TIME, true, false, false);
            CTFC.AddControl(txtOFFTIME2, false, false, false);
            CTFC.AddControl(txtOT_BEGIN, true, false, false);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetSalCode(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetSalCode(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetSalCode(), true, false, true);
            this.taSALCODE.Fill(this.dsSal.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.taROTE.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = taROTE;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "ROTE.ROTE";//**代碼權限設定**
            fdc.CodeSource = "ROTE";//**代碼權限設定**
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
                e.Values["ROTE"] = Guid.NewGuid().ToString();
            if (CheckRepeat(e.Values["ROTE"].ToString(), e.Values["ROTE_DISP"].ToString()))//**代碼權限設定**20121017
            {
                MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
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
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM212D frm = new FRM212D();
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None && dsAtt.ROTE.Count > 0)
            {
                if (bsROTE.Current == null) return;
                dsAtt.ROTERow r = ((bsROTE.Current as DataRowView).Row as dsAtt.ROTERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    frm.sRote = r.ROTE;
                    frm.ShowDialog();
                }
            }
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (bsROTE.Current == null) return;
                dsAtt.ROTERow r = ((bsROTE.Current as DataRowView).Row as dsAtt.ROTERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "ROTE";
                    frm.Code = r.ROTE;
                    frm.Text += "(" + r.ROTENAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTE
                      where a.ROTE1 != Code && a.ROTE_DISP == Disp
                     && db.GetCodeFilter("ROTE", a.ROTE1, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

    }
}
