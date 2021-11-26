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
    public partial class U_USER : JBControls.JBForm
    {
        public U_USER()
        {
            InitializeComponent();
        }
        JBModule.Data.Linq.HrDBDataContext db = null;
        private void U_USER_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            if (MainForm.ADMIN)
                this.u_USERTableAdapter.FillBySYSTEM(this.sysDS.U_USER, MainForm.SYSTEM);
            else
                this.u_USERTableAdapter.FillBySYSTEM_WORKADR(this.sysDS.U_USER);
            if (this.sysDS.U_USER.Count > 0)
            {
                foreach (var row in this.sysDS.U_USER)
                {
                    row.PASSWORD = JBModule.Data.CDecryp.Text(row.PASSWORD);
                }
            }
            GetCompany(textBox1.Text);
            fullDataCtrl1.DataAdapter = u_USERTableAdapter;
            cbxAdmin.Enabled = false;
            cbxAllApp.Enabled = false;
            cbxSys.Enabled = false;
            fullDataCtrl1.Init_Ctrls();
            if (!MainForm.ADMIN)
                fullDataCtrl1.WhereCmd = string.Format("(CHARINDEX(RTRIM(SYSTEM), '{0}') <> 0) AND EXISTS " +
                                "(SELECT          USER_ID, COMPANY, DATAGROUP, READRULE, WRITERULE, NOTE, KEY_DATE, KEY_MAN " +
                                "  FROM               U_DATAGROUP AS a" +
                                " WHERE(USER_ID = U_USER.USER_ID) AND EXISTS "+
                                "(SELECT          USER_ID, COMPANY, DATAGROUP, READRULE, WRITERULE, NOTE, KEY_DATE,KEY_MAN " +
                                "FROM               U_DATAGROUP AS b " +
                                "WHERE(USER_ID = '{1}') AND(COMPANY = '{2}') AND " +
                                "(DATAGROUP = a.DATAGROUP)) AND(COMPANY = '{2}'))", MainForm.SYSTEM, MainForm.USER_ID, MainForm.COMPANY);
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!CheckChangeRule(cbxSys.Checked, cbxAdmin.Checked))
            {
                MessageBox.Show("您沒有異動該帳號的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            db = new JBModule.Data.Linq.HrDBDataContext();
            var sql1 = from a in db.U_DATAGROUP where a.USER_ID == textBox1.Text select a;
            db.U_DATAGROUP.DeleteAllOnSubmit(sql1);
            var sql2 = from a in db.U_USERCOMP where a.USER_ID == textBox1.Text select a;
            db.U_USERCOMP.DeleteAllOnSubmit(sql2);
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                db.SubmitChanges();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!CheckChangeRule(cbxSys.Checked, cbxAdmin.Checked))
            {
                MessageBox.Show("您沒有異動該帳號的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            db = new JBModule.Data.Linq.HrDBDataContext();
            SysDS.U_USERDataTable U_USERDataTable = new SysDS.U_USERDataTable();
            u_USERTableAdapter.FillByUSERID(U_USERDataTable, textBox1.Text);
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                if (U_USERDataTable.Count > 0)
                {
                    MessageBox.Show(Resources.Sys.UserIDRptErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                AddDataGroup frm = new AddDataGroup();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    JBModule.Data.Linq.U_USERCOMP uc = new JBModule.Data.Linq.U_USERCOMP();
                    uc.COMPANY = MainForm.COMPANY;
                    uc.KEY_DATE = DateTime.Now;
                    uc.KEY_MAN = MainForm.USER_NAME;
                    uc.NOTE = "";
                    uc.USER_ID = textBox1.Text;
                    db.U_USERCOMP.InsertOnSubmit(uc);

                    JBModule.Data.Linq.U_DATAGROUP ud = new JBModule.Data.Linq.U_DATAGROUP();
                    ud.COMPANY = MainForm.COMPANY;
                    ud.KEY_DATE = DateTime.Now;
                    ud.KEY_MAN = MainForm.USER_NAME;
                    ud.NOTE = "";
                    ud.USER_ID = textBox1.Text;
                    ud.READRULE = frm.Read;
                    ud.WRITERULE = frm.Write;
                    ud.DATAGROUP = frm.DataGroup;
                    db.U_DATAGROUP.InsertOnSubmit(ud);
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (!e.Cancel)
            {
                //Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;

                //if (!MainForm.PROCSUPER)
                //{
                //    if (U_USERRow.WORKADR.Trim() != MainForm.WORKADR)
                //    {
                //        MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        e.Cancel = true;
                //        return;
                //    }
                //}

                e.Values["SYSTEM"] = "JBHR";
                e.Values["PASSWORD"] = JBModule.Data.CEncrypt.Text(textBox4.Text);
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                db.SubmitChanges();
                GetCompany(textBox1.Text);
                Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;
                U_USERRow.PASSWORD = JBModule.Data.CDecryp.Text(U_USERRow.PASSWORD);
                uUSERBindingSource.ResetCurrentItem();

                if (U_USERRow.USER_ID == MainForm.USER_ID)
                {
                    Sys.SysDS.U_USERDataTable U_USERDataTable = new JBHR.Sys.SysDS.U_USERDataTable();
                    Sys.SysDSTableAdapters.U_USERTableAdapter U_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
                    U_USERTableAdapter.FillByUSERID(U_USERDataTable, MainForm.USER_ID);

                    if (U_USERDataTable.Count > 0)
                    {
                        MainForm.USER_ID = U_USERDataTable[0].USER_ID.Trim();
                        MainForm.USER_NAME = U_USERDataTable[0].NAME.Trim();
                        //MainForm.WORKADR = U_USERDataTable[0].WORKADR.Trim();
                        //MainForm.SUPER = U_USERDataTable[0].SUPER;
                        //MainForm.PROCSUPER = U_USERDataTable[0].PROCSUPER;
                        //MainForm.MANGSUPER = U_USERDataTable[0].MANGSUPER;
                        MainForm.SYSTEM = "";
                        foreach (var row in U_USERDataTable)
                        {
                            if (MainForm.SYSTEM.Trim().Length == 0)
                            {
                                MainForm.SYSTEM = row.SYSTEM.Trim();
                            }
                            else
                            {
                                MainForm.SYSTEM += "," + row.SYSTEM.Trim();
                            }
                        }

                        (this.ParentForm as MainForm).toolStripStatusLabel1.Text = Resources.Sys.LoginUserID + MainForm.USER_ID;
                        (this.ParentForm as MainForm).toolStripStatusLabel2.Text = Resources.Sys.LoginUserName + MainForm.USER_NAME;
                        //(this.ParentForm as MainForm).toolStripStatusLabel3.Text = Resources.Sys.DefaultWorkadr + MainForm.WORKADR;
                        (this.ParentForm as MainForm).toolStripStatusLabel4.Text = Resources.Sys.SYSTEM + MainForm.SYSTEM;
                        //(this.ParentForm as MainForm).toolStripStatusLabel5.Text = Resources.Sys.SUPER + ((MainForm.SUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                        //(this.ParentForm as MainForm).toolStripStatusLabel6.Text = Resources.Sys.MANGSUPER + ((MainForm.MANGSUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                        //(this.ParentForm as MainForm).toolStripStatusLabel7.Text = Resources.Sys.PROCSUPER + ((MainForm.PROCSUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                    }
                }

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
            //SetControls(false);
            Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;
            SysDS.U_USERDataTable U_USERDataTable = new SysDS.U_USERDataTable();
            u_USERTableAdapter.FillByUSERID(U_USERDataTable, U_USERRow.USER_ID);
            if (U_USERDataTable.Count > 0)
            {
                U_USERRow.PASSWORD = JBModule.Data.CDecryp.Text(U_USERDataTable[0].PASSWORD);
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
            CheckAdminAccessControl();
        }
        void GetCompany(string userid)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.U_USERCOMP where a.USER_ID == userid select new { 公司名稱 = a.COMP.COMPNAME, 數目 = a.U_DATAGROUP.Count() };
            dataGridView1.DataSource = sql;
        }
        void GetUserCompany()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.U_USERCOMP where a.USER_ID == textBox1.Text select a).ToList();
        }

        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            GetCompany(textBox1.Text);
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CheckAdminAccessControl();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }

        void CheckAll(bool chk)
        {
            //if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            //    foreach (DataGridViewRow r in dataGridView1.Rows)
            //        r.Cells[0].Value = chk;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
        //    {
        //        if (e.ColumnIndex == 0)
        //        {
        //            var chk = dataGridView1.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
        //            chk.Value = chk.EditingCellFormattedValue;
        //        }
        //    }
        //}


        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (!CheckChangeRule(cbxSys.Checked, cbxAdmin.Checked))
                {
                    MessageBox.Show("您沒有設定該帳號的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                U_USERCOMP frm = new U_USERCOMP();
                frm.UserID = textBox1.Text.Trim();
                frm.ShowDialog();
                GetCompany(textBox1.Text);
            }
        }
        void CheckAdminAccessControl()
        {
            cbxSys.Enabled = MainForm.ADMIN;
            cbxAllApp.Enabled = MainForm.SUPER || MainForm.ADMIN;
            cbxAdmin.Enabled = MainForm.ADMIN;
            ptxNobr.Enabled = MainForm.ADMIN;
        }
        bool CheckChangeRule(bool SysRule, bool Admin)
        {
            if (textBox1.Text.Trim() == MainForm.USER_ID) return true;
            if (MainForm.ADMIN) return true;
            if (MainForm.SYSTEMRULE)
            {
                if (Admin) return false;
                if (SysRule) return false;
                return true;
            }
            return false;
        }

        private void ButtonQueryRule_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                JBControls.Utl.UTL02 frm = new JBControls.Utl.UTL02();
                frm.UserID = textBox1.Text.Trim();
                frm.ShowDialog();
            }
        }
    }

}
