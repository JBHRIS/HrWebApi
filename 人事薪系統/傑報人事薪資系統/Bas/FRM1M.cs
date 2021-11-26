using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1M : JBControls.JBForm
    {
        CheckControl cc;
        public FRM1M()
        {
            InitializeComponent();
        }

        private void FRM1M_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            //cc.AddControl(cbWORKCD);      //工作地點
            #endregion
            btnDataGroup.Enabled = MainForm.ADMIN;
            this.cOMPTableAdapter.FillByInit(this.basDS.COMP);//載入時顯示空白
            this.wORKCDTableAdapter.Fill(this.basDS.WORKCD);
            this.iNSCOMPTableAdapter.Fill(this.insDS.INSCOMP,MainForm.USER_ID,MainForm.COMPANY,MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbWORKCD, CodeFunction.GetWorkcd(), true, false, true);  //工作地點
            SystemFunction.SetComboBoxItems(cbINSCOMP, CodeFunction.GetInsComp(), true, false, true);  //投保單位
            this.yRHSNTableAdapter.Fill(this.basDS.YRHSN);
            //this.cOMPTableAdapter.Fill(this.basDS.COMP);

            fullDataCtrl1.DataAdapter = cOMPTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            #region 必要欄位檢察
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            #endregion

            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnDataGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                FRM1MD frm = new FRM1MD();
                frm.CompID = textBox1.Text;
                frm.ShowDialog();
            }
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                FRM1MC frm = new FRM1MC();
                frm.CompID = textBox1.Text;
                frm.ShowDialog();
            }
        }

        private void ButtonLNG_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                JBControls.Fomrs.MTLNG frm = new JBControls.Fomrs.MTLNG();
                frm.Source = "COMP";
                frm.Code = textBox1.Text;
                frm.Text += "(" + textBox2.Text + ")";
                frm.ShowDialog();
            }
        }
    }
}
