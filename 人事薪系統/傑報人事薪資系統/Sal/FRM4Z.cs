using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4Z : JBControls.JBForm
    {
        public FRM4Z()
        {
            InitializeComponent();
        }

        private void FRM4Z_Load(object sender, EventArgs e)
        {
            this.tAXLVLTableAdapter.Fill(this.salaryDS.TAXLVL);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.DataAdapter = this.tAXLVLTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
            }
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.Text = "所得稅級距表資料批次匯入";
            frm.FieldForm = new FRM4Z_Import();
            FRM4Z_Import.FRM4Z_ImportData TAXLVL_ImportData = new FRM4Z_Import.FRM4Z_ImportData();
            frm.DataTransfer = TAXLVL_ImportData;

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("年度", typeof(int));
            frm.DataTransfer.ColumnList.Add("薪資上限", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("薪資下限", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數00", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數01", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數02", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數03", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數04", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數05", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數06", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數07", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數08", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數09", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數10", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扶養人數11", typeof(decimal));



            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("扶養人數00");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數01");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數02");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數03");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數04");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數05");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數06");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數07");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數08");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數09");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數10");
            frm.DataTransfer.UnMustColumnList.Add("扶養人數11");

            frm.ShowDialog();
        }
    }
}
