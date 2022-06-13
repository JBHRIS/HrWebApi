using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace HR_TOOL
{
    public partial class U_SETDB : JBControls.JBForm
    {
        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public string EditType = "";
        public U_SETDB()
        {
            InitializeComponent();
        }

        private void U_SETDB_Load(object sender, EventArgs e)
        {
            if (EditType == "Edit")
            {
                ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
                string[] keyValues = cs.GetConnValue(U_LOGIN.ConnectionName).Split(new char[] { ';' });
                txtSettingName.Text = U_LOGIN.ConnectionName;
                foreach (string keyValue in keyValues)
                {
                    string[] settings = keyValue.Split(new char[] { '=' });
                    switch (settings[0].Trim())
                    {
                        case "Data Source":
                            textBoxSERVER.Text = JBModule.Data.CDecryp.Text(settings[1].Trim());
                            break;
                        case "Initial Catalog":
                            textBoxDATABASE.Text = JBModule.Data.CDecryp.Text(settings[1].Trim());
                            break;
                        case "User ID":
                            textBoxUSERID.Text = JBModule.Data.CDecryp.Text(settings[1].Trim());
                            break;
                        case "Password":
                            textBoxPASSWORD.Text = JBModule.Data.CDecryp.Text(settings[1].Trim());
                            break;
                    }
                }
            }
        }

        private void bnTest_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                MessageBox.Show("資料庫連線成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                MessageBox.Show("資料庫連線失敗", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            if (txtSettingName.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫設定檔名稱", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxSERVER.Text.Trim().Length == 0)
            {
                MessageBox.Show("欄位不可以是空白", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxDATABASE.Text.Trim().Length == 0)
            {
                MessageBox.Show("欄位不可以是空白", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxUSERID.Text.Trim().Length == 0)
            {
                MessageBox.Show("欄位不可以是空白", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPASSWORD.Text.Trim().Length == 0)
            {
                MessageBox.Show("欄位不可以是空白", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", JBModule.Data.CEncrypt.Text(textBoxSERVER.Text), JBModule.Data.CEncrypt.Text(textBoxDATABASE.Text), JBModule.Data.CEncrypt.Text(textBoxUSERID.Text), JBModule.Data.CEncrypt.Text(textBoxPASSWORD.Text.Trim()));
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            if (EditType == "Add")
            {
                cs.AddConnValue(txtSettingName.Text, connectionString);
            }
            else
            {
                cs.SetConnValue(U_LOGIN.ConnectionName, txtSettingName.Text, connectionString);
            }
            cs.Save();
            this.Close();
            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string connectionString = "";
            //bool findConnectionSetting = false;

            //if (config.AppSettings.Settings.AllKeys.Contains("ProjectConnectionKey"))
            //{
            //    string connectionHeader = config.AppSettings.Settings["ProjectConnectionKey"].Value;
            //    //if (Program.Shotcut.Trim().Length > 0) connectionHeader = Program.Shotcut;
            //    string[] drives = Directory.GetLogicalDrives();
            //    bool isExists = false;
            //    foreach (string drive in drives)
            //    {
            //        if (File.Exists(drive + connectionHeader + ".CONNECTION.STR"))
            //        {
            //            findConnectionSetting = true;
            //            connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);
            //            string str1 = JBModule.Data.CEncrypt.Text("connectionString[=]" + connectionString);

            //            StreamWriter sw = new StreamWriter(drive + connectionHeader + ".CONNECTION.STR", false, Encoding.Default);
            //            sw.WriteLine(str1);
            //            sw.Close();
            //            isExists = true;
            //            break;
            //        }
            //    }
            //    if (!isExists)
            //    {
            //        drives = Directory.GetLogicalDrives();
            //        foreach (string drive in drives)
            //        {
            //            if (File.Exists(drive + "JBHR.CONNECTION.STR"))
            //            {
            //                findConnectionSetting = true;
            //                connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);
            //                string str1 = JBModule.Data.CEncrypt.Text("connectionString[=]" + connectionString);

            //                StreamWriter sw = new StreamWriter(drive + "JBHR.CONNECTION.STR", false, Encoding.Default);
            //                sw.WriteLine(str1);
            //                sw.Close();
            //                break;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    string[] drives = Directory.GetLogicalDrives();
            //    foreach (string drive in drives)
            //    {
            //        if (File.Exists(drive + "JBHR.CONNECTION.STR"))
            //        {
            //            findConnectionSetting = true;
            //            connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);
            //            string str1 = JBModule.Data.CEncrypt.Text("connectionString[=]" + connectionString);

            //            StreamWriter sw = new StreamWriter(drive + "JBHR.CONNECTION.STR", false, Encoding.Default);
            //            sw.WriteLine(str1);
            //            sw.Close();
            //            break;
            //        }
            //    }
            //}

            //if (findConnectionSetting) Application.Restart();
            //else
            //{
            //    MessageBox.Show(Resources.All.ConnectionSettingNotFound + "\n" + Resources.All.PlsInsertUSBKey, "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}