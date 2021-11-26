using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
    public partial class FRM62 : JBControls.JBForm
    {
        CheckControl cc;
        public FRM62()
        {
            InitializeComponent();
        }

        private void FRM62_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(comboBox1);      //格式
            cc.AddControl(comboBox2);      //福利代號
            #endregion
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetFormat(), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetWcode(), true, false, true);
            comboBox2.Enabled = false;
            this.yRFOMATTableAdapter.Fill(this.welDS.YRFOMAT);
            this.wCODETableAdapter.Fill(this.welDS.WCODE);
            Sal.Function.SetAvaliableVBase(this.welDS.V_BASE);

            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite("WELF.SALADR");
            fullDataCtrl1.DataAdapter = wELFTableAdapter;

            WelDataClassesDataContext db = new WelDataClassesDataContext();
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

            //if (!MainForm.PROCSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();
            //    var data = (from c in db.V_BASE where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //    if (data == null)
            //    {
            //        e.Cancel = true;
            //        MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
                var db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.BASETTS where a.NOBR == popupTextBox1.Text && DateTime.Today >= a.ADATE && DateTime.Today <= a.DDATE.Value select a;
                if (sql.Any())
                    e.Values["saladr"] = sql.First().SALADR;
                if (!MainForm.WriteDataGroups.Contains(e.Values["saladr"].ToString()))
                    e.Values["saladr"] = MainForm.WriteDataGroups.First();
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
            filterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM62I frm62i = new FRM62I();
            frm62i.Owner = this;
            frm62i.ShowDialog();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            filterData();
        }

        private void filterData()
        {
            //if (!MainForm.MANGSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();

            //    DataTable dt = (wELFBindingSource.DataSource as DataSet).Tables[wELFBindingSource.DataMember];
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();

            //    fullDataCtrl1.Init_Ctrls();
            //}
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
