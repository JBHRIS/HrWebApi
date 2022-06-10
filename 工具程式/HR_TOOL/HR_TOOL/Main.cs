using HR_TOOL.DataUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        static string user_id;
        static string user_name;
        public static string USER_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public static string USER_NAME
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private void 產生器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBHRKEYCREATOR.Form1 frm = new JBHRKEYCREATOR.Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 金鑰檢視器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryKeyViewer frm = new SalaryKeyViewer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 修正異動日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FixBasetts.FixBasettsForm frm = new FixBasetts.FixBasettsForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 代碼權限ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CodeGroup.CodeGroupForm frm = new CodeGroup.CodeGroupForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 資料更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataUpdate.DataUpdateForm frm = new DataUpdate.DataUpdateForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 健保資料匯入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHI.NHI_Import frm = new NHI.NHI_Import();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            JBModule.Data.CDecryp.USER_ID = "JBADMIN";
            JBModule.Data.CEncrypt.USER_ID = "JBADMIN";
            U_LOGIN login = new U_LOGIN();
            //login.Parent = this;
            login.MainForm = this;
            if (login.ShowDialog() != System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void 查詢主檔設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBQuery.U_VIEW frm = new JBQuery.U_VIEW();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 萬用查詢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBQuery.JB_VIEW frm = new JBQuery.JB_VIEW();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 信件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.MailQueueMonitor frm = new JBModule.Message.UI.MailQueueMonitor();
            frm.KEY_MAN = Main.USER_NAME;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 記錄管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.LogMonitor frm = new JBModule.Message.UI.LogMonitor();
            frm.KEY_MAN = Main.USER_NAME;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 郵件參數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.Parameter frm = new JBModule.Message.UI.Parameter();
            //frm.KEY_MAN = MainForm.USER_NAME;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 備份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBase.DbBackup frm = new DataBase.DbBackup();
            //frm.KEY_MAN = MainForm.USER_NAME;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 發送信件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.MailForm frm = new JBModule.Message.UI.MailForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 代碼修改刪除管控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTrigger frm = new CreateTrigger();
            frm.MdiParent = this;
            frm.Show();
        }
        private void radGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBQuery.Rad_View frm = new JBQuery.Rad_View();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 元件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Module.LibraryForm frm = new Module.LibraryForm();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 模組管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Module.ModuleForm frm = new Module.ModuleForm();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 測試模組ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Module.TestModuleForm frm = new Module.TestModuleForm();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.Show();
        }

        //private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    DbLoger.TableTriggerLogForm frm = new DbLoger.TableTriggerLogForm();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void 修正關聯資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForeignKeyUpdateForm frm = new ForeignKeyUpdateForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
