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
    public partial class FRM42 : JBControls.JBForm
    {
        public FRM42()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM42_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBox2);//必要欄位檢查
            cc.AddControl(comboBox3);//必要欄位檢查
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetMtCode("SALTYCD_DIV"), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetMtCode("SALTYCD_DAYS"), true, false, true);
            comboBox2.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetMtCode("SALTYCD_HOURS"), true, false, true);
            comboBox3.Enabled = false;
            //this.sALTYCD_HOURSTableAdapter.Fill(this.viewDS.SALTYCD_HOURS);
            //this.sALTYCD_DAYSTableAdapter.Fill(this.viewDS.SALTYCD_DAYS);
            //this.sALTYCD_DIVTableAdapter.Fill(this.viewDS.SALTYCD_DIV);
            this.sALTYCDTableAdapter.Fill(this.salaryDS.SALTYCD);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.DataAdapter = sALTYCDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }


        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }

            e.Values["kEy_MaN"] = MainForm.USER_NAME;
            e.Values["KeY_dAtE"] = DateTime.Now;
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
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }
    }
}
