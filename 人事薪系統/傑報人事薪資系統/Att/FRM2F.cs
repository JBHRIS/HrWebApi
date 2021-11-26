using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace JBHR.Att
{
    public partial class FRM2F : JBControls.JBForm
    {
        public FRM2F()
        {
            InitializeComponent();
        }

        private void U_SYS7_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dataFormat = new Dictionary<string, string>();
            dataFormat.Add("Taiwan", "民國年");
            dataFormat.Add("International", "西元年");
            Dictionary<string, string> spiltType = new Dictionary<string, string>();
            spiltType.Add("Position", "位置");
            spiltType.Add("Signal", "符號");
            SystemFunction.SetComboBoxItems(comboBoxDateFormat, dataFormat);
            SystemFunction.SetComboBoxItems(comboBoxSpiltType, spiltType);
            this.u_SYS7TableAdapter.Fill(this.sysDS.U_SYS7);           
            fullDataCtrl1.DataAdapter = u_SYS7TableAdapter;
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

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
          
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
           
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
          
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var vw = (DataRowView)uSYS7BindingSource.Current;
            if (vw != null && vw.Row != null)
            {
                FRM2FA frm = new FRM2FA();
                frm.CardNO = Convert.ToInt32(vw[0]);
                frm.Text += "-刷卡機：" + vw[1].ToString() + "(" + vw[0].ToString() + ")";
                frm.ShowDialog();
            }
        }

        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEx1.SelectedRows != null && textBox1.Text.Trim().Length != 0)
            {

            }
        }
    }
}