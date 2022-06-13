using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;
using System.Configuration;

namespace HR_TOOL
{
    public partial class U_LOGIN : JBControls.JBForm
    {
        public U_LOGIN()
        {
            InitializeComponent();
        }
        public static string ConnectionName = "";
        public static string ConnectionString = "";
        public Form MainForm;
        private void button1_Click(object sender, EventArgs e)
        {
            U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            //ConfigSetting cs1 = new ConfigSetting();//覆蓋程式設定檔(解密)
            U_LOGIN.ConnectionString = JBModule.Data.CDecryp.ConnectString(cs.GetConnValue(U_LOGIN.ConnectionName));
            //cs1.SetConnValue("JBHR.Properties.Settings.JBHRConnectionString", "JBHR.Properties.Settings.JBHRConnectionString", U_LOGIN.ConnectionString);
            //cs1.Save();
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string connectionString = U_LOGIN.ConnectionString;
            this.MainForm.Text = string.Format("HR工具箱({0})", U_LOGIN.ConnectionName);
            HR_TOOL.Properties.Settings.Default["HrDBConnectionString"] = connectionString;
            if (connectionString.Trim().Length > 0)
            {
                config.ConnectionStrings.ConnectionStrings["HR_TOOL.Properties.Settings.HrDBConnectionString"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            if (textBox1.Text.Trim() == "JBADMIN")
            {
                if (textBox2.Text.Trim().ToLower() == "jb8421" + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "1021")
                {
                    JBModule.Data.CDecryp.USER_ID = textBox1.Text.Trim();
                    JBModule.Data.CEncrypt.USER_ID = textBox1.Text.Trim();

                    Main.USER_ID = textBox1.Text.Trim();
                    Main.USER_NAME = "傑報資訊";



                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("錯誤的帳號或密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("錯誤的帳號或密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            U_SETDB u_setdb = new U_SETDB();
            u_setdb.Owner = this;
            u_setdb.ShowDialog();
        }

        private void U_LOGIN_Load(object sender, EventArgs e)
        {
            string DefaultPath = Program.SystemConfigPath;
            string hrmPath = @"C:\temp\App.Config";
            if (File.Exists(hrmPath))
                Program.SystemConfigPath = hrmPath;
            else if (File.Exists(DefaultPath))
                Program.SystemConfigPath = DefaultPath;
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList());
            //避免一開始就觸發SelectIndexChanged
            cbxConnections.SelectedIndexChanged += new EventHandler(cbxConnections_SelectedIndexChanged);

            string RecentConnection = cs.GetAppValue("RecentConnection");
            if (RecentConnection == null)
            {
                cs.SetAppValue("RecentConnection", "");
                if (cbxConnections.SelectedIndex != -1 && cbxConnections.SelectedValue.ToString().Trim().Length > 0)
                    cs.SetAppValue("RecentConnection", cbxConnections.SelectedValue.ToString());
                cs.Save();
                RecentConnection = cs.GetAppValue("RecentConnection");
            }

            if (cs.GetConnectionStringList().ContainsKey(RecentConnection))
            {
                U_LOGIN.ConnectionName = RecentConnection;
                cbxConnections.SelectedValue = U_LOGIN.ConnectionName;
            }
            else if (cbxConnections.SelectedValue!=null)
                U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();

            JBModule.Data.CDecryp.USER_ID = textBox1.Text.Trim();
            JBModule.Data.CEncrypt.USER_ID = textBox1.Text.Trim();
            JBModule.Data.CDecryp.HAS_DECRYP_KEY = false;
            JBModule.Data.CEncrypt.HAS_DECRYP_KEY = false;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            U_SETDB frm = new U_SETDB();
            frm.EditType = "Add";
            frm.ShowDialog();
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList());
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
            U_SETDB frm = new U_SETDB();
            frm.EditType = "Edit";
            frm.ShowDialog();
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList());
        }

        private void pbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要刪除此連線設定檔?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
                ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
                cs.DeleteConnValue(U_LOGIN.ConnectionName);
                cs.Save();
                SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList());
                MessageBox.Show("刪除完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxConnections.SelectedValue != null && cbxConnections.SelectedValue.ToString() != U_LOGIN.ConnectionName)
            {
                //if (MessageBox.Show("是否切換連線至[" + cbxConnections.SelectedValue.ToString() + "]", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                //{
                U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
                ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
                cs.SetAppValue("RecentConnection", cbxConnections.SelectedValue.ToString());
                cs.Save();
                ConfigSetting cs1 = new ConfigSetting();//覆蓋程式設定檔(解密)
                U_LOGIN.ConnectionString = JBModule.Data.CDecryp.ConnectString(cs.GetConnValue(U_LOGIN.ConnectionName));
                //    cs1.SetConnValue("JBHR.Properties.Settings.JBHRConnectionString", "JBHR.Properties.Settings.JBHRConnectionString", U_LOGIN.ConnectionString);
                //    cs1.Save();
                //    Application.Restart();
                //}
                //else
                //{
                //    cbxConnections.SelectedValue = U_LOGIN.ConnectionName;//取消的話切回原連線
                //}
            }
        }
    }
}
