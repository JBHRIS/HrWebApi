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
    public partial class FRM13 : JBControls.JBForm
    {
        CheckControl cc;
        public FRM13()
        {
            InitializeComponent();
        }
        public string Nobr = "";
        private void FRM13_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbRELCODE);      //眷屬種類
            #endregion

            this.fAMILYTableAdapter.FillByInit(this.basDS.FAMILY);//載入時顯示空白
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            this.rELCODETableAdapter.Fill(this.basDS.RELCODE);
            SystemFunction.SetComboBoxItems(cbRELCODE, CodeFunction.GetRelcode(), true, false, true); //眷屬種類
            if (!string.IsNullOrEmpty(Nobr))
                this.fAMILYTableAdapter.FillByNobr(this.basDS.FAMILY, Nobr); 

            fullDataCtrl1.DataAdapter = fAMILYTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("family.nobr");
            fullDataCtrl1.Init_Ctrls();

            if (Nobr.Trim().Length == 0)
            {
                dataGridViewEx1.Columns[0].Visible = false;
            }
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

            if (!checkSavePower(e.Values["nobr"].ToString()))
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
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private bool checkSavePower(string nobr)
        {
            return Sal.Function.CanModify(nobr);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.View) return;
            if (textBox1.Text.Trim().Length == 0) return;

            FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
            string DataPropertyName = "FA_IDNO";
            (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

            if (!(JBTools.FormatValidate.CheckIDNO(textBox1.Text) || JBTools.FormatValidate.CheckRPNumber(textBox1.Text)))
            {
                MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //textBox1.Focus();
                //(fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
            }    
        }
     
        private void dataGridViewEx1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridViewEx1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
            if (cell != null)
            {
                Ins.FRM32.ReturnFaIdno = dataGridViewEx1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.Close();
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            popupTextBox1.Focus();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM13IN();
            frm.DataTransfer = new ImportFamilyData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("眷屬種類", this.basDS.RELCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.REL_CODE, RealCode = p.REL_CODE, DisplayName = p.REL_NAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬身份証號", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬生日", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬地址", typeof(string));

            //frm.DataTransfer.ColumnList.Add("備註欄", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("眷屬生日");
            frm.DataTransfer.UnMustColumnList.Add("眷屬地址");

            frm.ShowDialog();
        }
    }
}
