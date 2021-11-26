using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Att
{
    public partial class FRM2_DiversionAttendType : JBControls.JBForm
    {
        public FRM2_DiversionAttendType()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢查
        private void FRM2_DiversionAttendType_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            //cc.AddControl(txtDiversionAttendType);
            //cc.AddControl(txtDiversionAttendName);
            // TODO: 這行程式碼會將資料載入 'dsAtt.DiversionAttendType' 資料表。您可以視需要進行移動或移除。
            this.diversionAttendTypeTableAdapter.Fill(this.dsAtt.DiversionAttendType);
            fdc.DataAdapter = diversionAttendTypeTableAdapter;

            chkCheckWFH_Attend.Enabled = false;
            chkCheckWebCard.Enabled = false;
            chkCheckWorkLog.Enabled = false;
            chkCheckTemperoturyReport.Enabled = false;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.Init_Ctrls();
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            var OverLapAdd = this.dsAtt.DiversionAttendType.Where(p => p.DiversionAttendType == txtDiversionAttendType.Text);
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add && OverLapAdd.Any())
            {
                e.Cancel = true;
                MessageBox.Show("已存在相同代碼.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiversionAttendType.Focus();
                return;
            }
            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
                    e.Values["Guid"] = Guid.NewGuid();
                e.Values["KeyMan"] = MainForm.USER_NAME;
                e.Values["KeyDate"] = DateTime.Now;
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
            txtDiversionAttendType.Focus();
            chkCheckWFH_Attend.Checked = false;
            chkCheckWebCard.Checked = false;
            chkCheckWorkLog.Checked = false;
            chkCheckTemperoturyReport.Checked = false;
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }
    }
}
