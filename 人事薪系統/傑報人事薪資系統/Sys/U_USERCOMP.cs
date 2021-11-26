using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_USERCOMP : JBControls.JBForm
    {
        public U_USERCOMP()
        {
            InitializeComponent();
        }
        public string UserID = "";
        JBModule.Data.Linq.HrDBDataContext db = null;
        string comp = "";
        private void U_USER_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxComp, CodeFunction.GetComp());
            this.cOMPTableAdapter.Fill(this.basDS.COMP);
            this.u_USERCOMPTableAdapter.FillByUserID(this.sysDS.U_USERCOMP, UserID);

            fullDataCtrl1.DataAdapter = u_USERCOMPTableAdapter;

            fullDataCtrl1.Init_Ctrls();
            GetDataGroup(cbxComp.SelectedValue.ToString());
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            comp = cbxComp.SelectedValue.ToString();
            if (!MainForm.ADMIN && !MainForm.CompDic.ContainsKey(cbxComp.SelectedValue.ToString()))
            {
                MessageBox.Show("你沒有權限刪除該公司別的資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            db = new JBModule.Data.Linq.HrDBDataContext();
            var sql1 = from a in db.U_DATAGROUP where a.USER_ID == UserID && a.COMPANY == cbxComp.SelectedValue.ToString() select a;
            db.U_DATAGROUP.DeleteAllOnSubmit(sql1);
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                db = new JBModule.Data.Linq.HrDBDataContext();
                var sql1 = from a in db.U_DATAGROUP where a.USER_ID == UserID && a.COMPANY == comp select a;
                db.U_DATAGROUP.DeleteAllOnSubmit(sql1);
                db.SubmitChanges();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!MainForm.ADMIN && !MainForm.CompDic.ContainsKey(cbxComp.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("你沒有權限異動該公司別的資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            e.Values["user_id"] = UserID;
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

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (this.sysDS.U_USER.Count > 0)
            {
                foreach (var row in this.sysDS.U_USER)
                {
                    row.PASSWORD = JBModule.Data.CDecryp.Text(row.PASSWORD);
                }
            }
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (this.sysDS.U_USER.Count > 0)
            {
                foreach (var row in this.sysDS.U_USER)
                {
                    row.PASSWORD = JBModule.Data.CDecryp.Text(row.PASSWORD);
                }
            }
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbxComp.Enabled = false;
        }

        void GetDataGroup(string comp)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.U_DATAGROUP where a.USER_ID == UserID && a.COMPANY == comp select new { 群組名稱 = a.COMP_DATAGROUP.DATAGROUP1.GROUPNAME, 讀取 = a.READRULE, 寫入 = a.WRITERULE };
            dataGridView1.DataSource = sql;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                U_DATAGROUP frm = new U_DATAGROUP();
                frm.UserID = UserID;
                frm.CompID = cbxComp.SelectedValue.ToString().Trim();
                frm.ShowDialog();
                GetDataGroup(cbxComp.SelectedValue.ToString().Trim());
            }
        }

        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            if (cbxComp.SelectedValue != null)
                GetDataGroup(cbxComp.SelectedValue.ToString().Trim());
        }
    }

}
