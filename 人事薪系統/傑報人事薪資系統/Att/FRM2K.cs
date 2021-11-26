using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace JBHR.Att
{
    public partial class FRM2K : JBControls.JBForm
    {
        public FRM2K()
        {
            InitializeComponent();
        }

        private void U_SYS7_Load(object sender, EventArgs e)
        {
            this.u_SYS7ATableAdapter.Fill(this.dsAtt.U_SYS7A);

            fullDataCtrl1.DataAdapter = u_SYS7ATableAdapter;
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
            btnTest.Enabled = false;
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
                btnImport.Enabled = true;
                btnTest.Enabled = false;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;
            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtCardName.Focus();
            btnImport.Enabled = false;
            btnTest.Enabled = true;
            txtLastCheck.Text = Sal.Core.SalaryDate.DateString(new DateTime(1900, 1, 1));
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            btnImport.Enabled = false;
            btnTest.Enabled = true;
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            btnTest.Enabled = false;
            btnImport.Enabled = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var vw = (DataRowView)uSYS7ABindingSource.Current;
            if (vw != null && vw.Row != null)
            {
                FRM2KB frm = new FRM2KB();
                frm.code = Convert.ToInt32(vw[0]);
                frm.Text += "FRM2KB-刷卡機：" + vw[1].ToString();
                frm.ShowDialog();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //string connectionString =
            //    string.Format(
            //    "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
            //    , txtDataSource.Text, txtInitailCatalog.Text, txtUserId.Text, txtPassWord.Text);
            string ConnectString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", txtDataSource.Text);
            OleDbConnection conn = new OleDbConnection(ConnectString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                MessageBox.Show(Resources.All.DBConnectOK, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

                FRM2KA frm = new FRM2KA();
                frm.datasource = txtDataSource.Text;
                frm.initialcatalog = txtInitailCatalog.Text;
                frm.userid = txtUserId.Text;
                frm.passwd = txtPassWord.Text;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtDataTable.Text = frm.datatable;
                    txtNobr.Text = frm.nobr;
                    txtAdate.Text = frm.date;
                    txtOntime.Text = frm.time;
                    txtCardNo.Text = frm.cardno;
                    txtCheckTime.Text = frm.checktime;
                    txtSource.Text = frm.source;
                    txtIP.Text = frm.ipaddr;
                    txtTemperature.Text = frm.temperature;
                }
                //btnImport.Enabled = true;
            }
            catch
            {
                MessageBox.Show(Resources.All.DBConnectErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnBroswer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mdb檔|*.mdb";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDataSource.Text = ofd.FileName;
            }
        }
    }
}