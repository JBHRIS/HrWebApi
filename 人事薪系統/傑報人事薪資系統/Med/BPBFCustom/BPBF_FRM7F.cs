using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med.BPBFCustom
{
    public partial class BPBF_FRM7F : JBControls.JBForm
    {
        public BPBF_FRM7F()
        {
            InitializeComponent();
        }
        CheckControl cc;
        private void BPBF_FRM7F_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(txtT_CODE);
            cc.AddControl(txtT_Name);
            #endregion
            // TODO: 這行程式碼會將資料載入 'medDS.TCODE' 資料表。您可以視需要進行移動或移除。
            this.tCODETableAdapter.Fill(this.medDS.TCODE);
            fullDataCtrl1.DataAdapter = tCODETableAdapter;
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

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
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

            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                HrDBDataContext db = new HrDBDataContext();
                var code = db.TCODE.Where(p => p.T_CODE == txtT_CODE.Text.Trim()).FirstOrDefault();
                if (code != null)
                {
                    MessageBox.Show("已存在相同的所得代號", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtT_CODE.Focus();
                    e.Cancel = true;
                    return;
                }
            }

            if (!e.Cancel)
            {
                e.Values["Key_Man"] = MainForm.USER_NAME;
                e.Values["Key_Date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }
    }
}
