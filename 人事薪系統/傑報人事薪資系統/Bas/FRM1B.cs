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
    public partial class FRM1B : JBControls.JBForm
    {
        CheckControl cc;
        public FRM1B()
        {
            InitializeComponent();
        }

        private void FRM1B_Load(object sender, EventArgs e)
        {
            this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE,"TTSCODE");
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbSUBCODE);      //科系
            cc.AddControl(cbEDUCODE);      //教育程度代號
            #endregion
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sCHLTableAdapter.FillByInit(this.basDS.SCHL);//載入時顯示空白
            SystemFunction.SetComboBoxItems(cbSUBCODE, CodeFunction.GetSubCode(), true, false, true); //科系
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            SystemFunction.SetComboBoxItems(cbEDUCODE, CodeFunction.GetMtCode("EDUCODE"), true, false, true); //教育程度代號
            
            this.sUBCODETableAdapter.Fill(this.basDS.SUBCODE);
            this.eDUCODETableAdapter.Fill(this.basDS.EDUCODE);
            this.sCHLTableAdapter.FillByInit(this.basDS.SCHL);

            fullDataCtrl1.DataAdapter = sCHLTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("D", "日間部");
            dic.Add("N", "夜間部");
            cbDayOrNight.AddItem(dic);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("schl"); 
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

            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                //FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                //var basetts = from c in db.BASETTS
                //              where c.NOBR.ToLower().Trim() == e.Values["nobr"].ToString().ToLower().Trim()
                //              orderby c.ADATE descending
                //              select c;
                //if (basetts.Count() > 0)
                //{
                //    e.Values.Row["dept_name"] = basetts.FirstOrDefault().DEPT1.D_NAME.Trim();
                //    e.Values.Row["job_name"] = basetts.FirstOrDefault().JOB1.JOB_NAME.Trim();
                //    dataGridView1.Refresh();
                //}
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

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM1BIN();
            frm.DataTransfer = new ImportSCHLData();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("D", "日間部");
            dic.Add("N", "夜間部");

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("教育程度代號", CodeFunction.GetMtCode("EDUCODE",false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("科系", this.basDS.SUBCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.SUBCODE, RealCode = p.SUBCODE, DisplayName = p.SUBDESC }).ToList());
            frm.DataTransfer.CheckData.Add("日夜", dic.Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value, CheckValue1 = p.Value }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("學校", typeof(string));
            frm.DataTransfer.ColumnList.Add("教育程度代號", typeof(string));
            frm.DataTransfer.ColumnList.Add("科系", typeof(string));
            frm.DataTransfer.ColumnList.Add("詳細科系名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("日夜", typeof(string));
            frm.DataTransfer.ColumnList.Add("生效日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("入學年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("畢業年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("畢業", typeof(Boolean));
            frm.DataTransfer.ColumnList.Add("肄業", typeof(Boolean));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("日夜");
            frm.DataTransfer.UnMustColumnList.Add("生效日期");
            frm.DataTransfer.UnMustColumnList.Add("入學年月");
            frm.DataTransfer.UnMustColumnList.Add("畢業年月");
            frm.DataTransfer.UnMustColumnList.Add("畢業");
            frm.DataTransfer.UnMustColumnList.Add("肄業");
            frm.DataTransfer.UnMustColumnList.Add("備註");
            frm.ShowDialog();
        }
    }
}
