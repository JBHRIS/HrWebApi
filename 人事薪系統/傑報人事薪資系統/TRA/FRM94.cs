using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Wel;

namespace JBHR.TRA
{
    public partial class FRM94 : JBControls.JBForm
    {
        CheckControl cc;
        public FRM94()
        {
            InitializeComponent();
        }

        private void FRM94_Load(object sender, EventArgs e)
        {
            this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
            // TODO:  這行程式碼會將資料載入 'traDS1.TRCOSC' 資料表。您可以視需要進行移動或移除。
            this.tRCOSCTableAdapter.Fill(this.traDS1.TRCOSC);
            // TODO:  這行程式碼會將資料載入 'basDS.BASE' 資料表。您可以視需要進行移動或移除。
            //this.bASETableAdapter.Fill(this.basDS.BASE);
            // TODO:  這行程式碼會將資料載入 'traDS1.TRCOSP' 資料表。您可以視需要進行移動或移除。
            SystemFunction.SetComboBoxItems(cbCOURSE, CodeFunction.GetCOURSE(), false, false, true);
            this.tRCOSPTableAdapter.FillByInit(this.traDS1.TRCOSP);
            
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbCOURSE);
            //cc.AddControl(cbTRCOMP);      //訓練機構
            //cc.AddControl(cbTR_INOUT);    //訓練型式
            //cc.AddControl(cbTRTYPE);      //課程類別
            //cc.AddControl(cbTRASSCODE);   //評核方式
            //cc.AddControl(cbDEPT);        //部門

            #endregion         
            
            

            fdc.DataAdapter = tRCOSPTableAdapter;
            WelDataClassesDataContext db = new WelDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.WhereCmd = Sal.Function.GetFilterCmd("TRCOSP");
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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
            //if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定
            //{
            //    e.Values["SEQ"] = Guid.NewGuid().ToString();
            //}
            var tr_guid = cbCOURSE.SelectedValue;
            var nobr = txtNobr.Text;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                var sql = from a in db.TRCOSP where a.COURSE == tr_guid && a.NOBR == nobr select 1;
                if (sql.Any())
                {
                    e.Cancel = true;
                    MessageBox.Show("已有該員工資料", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Modify)
            {
                var auto = dgv.CurrentRow.Cells["AUTO"].Value.ToString();
                var sql = from a in db.TRCOSP where a.COURSE == tr_guid && a.NOBR == nobr && a.AUTO.ToString() != auto select a;
                if (sql.Any())
                {
                    e.Cancel = true;
                    MessageBox.Show("已有該員工資料", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            //dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            //JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbCOURSE.Focus();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //    txtAdate.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (!Sal.Function.CanModify(ptxNobr.Text))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void txtOntime_Validating(object sender, CancelEventArgs e)
        {
            //if (!Sal.Function.ValidateTimeStringFormat(txtOntime.Text))
            //{
            //    errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
            //}
        }

        private void btnProduceHave_Click(object sender, EventArgs e)
        {
            //FRM24A frm = new FRM24A();
            //frm.ShowDialog();
        }

        private void ptxNobr_Validated(object sender, EventArgs e)
        {
            //QueryDept(txtNobr.Text, DateTime.Today);
        }
        void QueryDept(string Nobr, DateTime Date)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime dateNow = DateTime.Now.Date;
            var DEPT = from c in db.BASETTS
                       where c.NOBR == Nobr && c.ADATE <= dateNow && c.DDATE >= Date
                       select new
                       {
                           c.DEPT
                       };
            if (DEPT.Any())
            {
                //cbDEPT.SelectedValue = DEPT.FirstOrDefault().DEPT;
            }
            else
            {
                //cbDEPT.SelectedValue = "";
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //QueryDept(txtNobr.Text, DateTime.Today);
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM94IN();
            frm.DataTransfer = new ImportTransferToTRCOSP();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("課程代碼", traDS1.TRCOSC.Select(p => new JBControls.CheckImportData { DisplayCode = p.CODE, RealCode = p.GUID, DisplayName = p.COURSE }).ToList());
            
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("課程代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("課程名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("完成評核日", typeof(string));
            frm.DataTransfer.ColumnList.Add("缺課時數", typeof(string));
            frm.DataTransfer.ColumnList.Add("已訓時數", typeof(string));
            frm.DataTransfer.ColumnList.Add("申請編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否結訓", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否完成評核", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否合格", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            //frm.DataTransfer.UnMustColumnList = new List<string>();
            //frm.DataTransfer.UnMustColumnList.Add("合同种类代码");
            //frm.DataTransfer.UnMustColumnList.Add("派驻区代码");

            frm.ShowDialog();
        }
    }
}
