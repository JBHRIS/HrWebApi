using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM3F : JBControls.JBForm
    {
        public FRM3F()
        {
            InitializeComponent();
        }

        List<JBControls.CheckImportData> CheckListOfEmpData = new List<JBControls.CheckImportData>();
        List<JBControls.CheckImportData> EmpData = new List<JBControls.CheckImportData>();
        private void FRM3F_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'basDS.FAMILY1' 資料表。您可以視需要進行移動或移除。
            this.fAMILY1TableAdapter.Fill(this.basDS.FAMILY1);
            Sal.Function.SetAvaliableVBase(this.insDS.V_BASE);
            //this.fAMILYTableAdapter.Fill(this.basDS.FAMILY);
            this.iNSUR_TYPETableAdapter.Fill(this.insDS.INSUR_TYPE);
            SystemFunction.SetComboBoxItems(cbINSUR_TYPE, CodeFunction.GetMtCode("INSUR_TYPE"), true, false, true); //費用種類
            this.iNPOLABTableAdapter.Fill(this.insDS.INPOLAB);

            fullDataCtrl1.DataAdapter = iNPOLABTableAdapter;
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("inpolab");
            fullDataCtrl1.Init_Ctrls();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            EmpData = (from a in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN)
                       select new JBControls.CheckImportData
                       {
                           RealCode = a.NOBR,
                           DisplayCode = a.NOBR,
                           DisplayName = a.NOBR,
                           ReturnValue = a.DATAGROUP,
                       }).ToList();



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
            if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            //frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM3F_IMPORT();
            frm.DataTransfer = new InsuranceCompareImport();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();

            frm.DataTransfer.CheckData.Add("身分證號", CheckListOfEmpData);
            frm.DataTransfer.CheckData.Add("員工資料", EmpData);
            //frm.DataTransfer.CheckData.Add("眷屬證號", CheckListOfEmpData);
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("身分證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬證號", typeof(string));
            frm.DataTransfer.ColumnList.Add("保險年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("費用種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("個人負擔", typeof(decimal?));
            frm.DataTransfer.ColumnList.Add("公司負擔", typeof(decimal?));

            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.ShowDialog();
        }

        private void popupTextBox2_Leave(object sender, EventArgs e)
        {
            if (popupTextBox1.Text.Trim().Length > 0)
            {
                popupTextBox2.WhereCmd = "nobr = '" + popupTextBox1.Text + "'";
            }
            else popupTextBox2.WhereCmd = "";
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("將刪除所有畫面中的資料，是否要繼續?","警告",  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== System.Windows.Forms.DialogResult.OK)
            {
                foreach(var it in insDS.INPOLAB)
                {
                    it.Delete();
                }
                iNPOLABTableAdapter.Update(insDS.INPOLAB);
                MessageBox.Show("刪除完成");
            }
        }
    }
}
