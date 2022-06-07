using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Dividend.HunyaCustom.Code
{
    public partial class Hunya_DIVDJobWeighting : JBControls.JBForm
    {
        public Hunya_DIVDJobWeighting()
        {
            InitializeComponent();
        }
        CheckControl cc;//必填欄位
        private void Hunya_DIVDJobLWeighting_Load(object sender, EventArgs e)
        {
            this.hunya_DIVDJobWeightingTableAdapter.Fill(this.hunya_Dividend.Hunya_DIVDJobWeighting, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBTableAdapter.Fill(this.hunya_Dividend.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbxJOB_DISP, CodeFunction.GetJob(), true, false, true);
            cc = new CheckControl();
            cc.AddControl(cbxJOB_DISP);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.DataAdapter = hunya_DIVDJobWeightingTableAdapter;
            fdc.Init_Ctrls();
            fdc.CodeColumn = "Hunya_DIVDJobWeighting.DIVDJOB";//**代碼權限設定**
            fdc.CodeSource = "JOB";//**代碼權限設定**
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fdc.BackupDataTable);
            }
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            var db = new JBModule.Data.Linq.HrDBDataContext();
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add &&  db.Hunya_DIVDJobWeighting.Where(p => p.DIVDJOB == cbxJOB_DISP.SelectedValue.ToString()).Any())
            {
                MessageBox.Show("已存在相同職等設定", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxJOB_DISP.Focus();
                e.Cancel = true;
                return;
            }
            if (!e.Cancel)
            {
                e.Values["KEYMAN"] = MainForm.USER_NAME;
                e.Values["KEYDATE"] = DateTime.Now;
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {
                    e.Values["GID"] = Guid.NewGuid();
                }
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
            cbxJOB_DISP.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbxJOB_DISP.Enabled = false;
        }
    }
}
