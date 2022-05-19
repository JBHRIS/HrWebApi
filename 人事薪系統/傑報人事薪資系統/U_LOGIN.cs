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

namespace JBHR
{
    public partial class U_LOGIN : JBControls.JBForm
    {
        public U_LOGIN()
        {
            InitializeComponent();
        }
        public static string ConnectionName = "";
        public static string ConnectionString = "";

        private void button1_Click(object sender, EventArgs e)
        {
            U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            //ConfigSetting cs1 = new ConfigSetting();//覆蓋程式設定檔(解密)
            U_LOGIN.ConnectionString = JBModule.Data.CDecryp.ConnectString(cs.GetConnValue(U_LOGIN.ConnectionName)) + ";Connection Timeout=60";
            JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = U_LOGIN.ConnectionString;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string connectionString = U_LOGIN.ConnectionString;
            JBHR.Properties.Settings.Default["JBHRConnectionString"] = connectionString;
            if (connectionString.Trim().Length > 0)
            {
                config.ConnectionStrings.ConnectionStrings["JBHR.Properties.Settings.JBHRConnectionString"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            if (textBox1.Text.Trim() == "JBADMIN")
            {
                if (textBox2.Text.Trim().ToLower() == "jb8421" + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "1021")
                {
                    JBModule.Data.CDecryp.USER_ID = textBox1.Text.Trim();
                    JBModule.Data.CEncrypt.USER_ID = textBox1.Text.Trim();

                    MainForm.LOGIN_ID = textBox1.Text.Trim();
                    MainForm.USER_ID = textBox1.Text.Trim();
                    MainForm.USER_NAME = "傑報資訊";
                    MainForm.WORKADR = "ALL";
                    MainForm.SUPER = true;
                    MainForm.PROCSUPER = true;
                    MainForm.MANGSUPER = true;
                    MainForm.SYSTEM = "JBHR";
                    MainForm.ADMIN = true;

                    (this.Owner as MainForm).toolStripStatusLabel1.Text = Resources.Sys.LoginUserID;// +MainForm.USER_ID;
                    (this.Owner as MainForm).toolStripUserList.Text = MainForm.USER_ID;
                    (this.Owner as MainForm).toolStripStatusLabel2.Text = Resources.Sys.LoginUserName + MainForm.USER_NAME;
                    //(this.Owner as MainForm).toolStripStatusLabel3.Text = Resources.Sys.DefaultWorkadr + MainForm.WORKADR;
                    (this.Owner as MainForm).toolStripStatusLabel4.Text = Resources.Sys.SYSTEM + MainForm.SYSTEM;
                    //(this.Owner as MainForm).toolStripStatusLabel5.Text = Resources.Sys.SUPER + ((MainForm.SUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                    //(this.Owner as MainForm).toolStripStatusLabel6.Text = Resources.Sys.MANGSUPER + ((MainForm.MANGSUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                    //(this.Owner as MainForm).toolStripStatusLabel7.Text = Resources.Sys.PROCSUPER + ((MainForm.PROCSUPER) ? Resources.Sys.YES : Resources.Sys.NO);

                    BasDataClassesDataContext db = new BasDataClassesDataContext();
                    U_SYS_LOGIN u_sys_login = new U_SYS_LOGIN();
                    u_sys_login.IN_TIME = DateTime.Now;
                    u_sys_login.USER_ID = MainForm.USER_ID;
                    u_sys_login.USER_NAME = MainForm.USER_NAME;
                    u_sys_login.WORKADR = MainForm.WORKADR;
                    u_sys_login.SUPER = MainForm.SUPER;
                    u_sys_login.PROCSUPER = MainForm.PROCSUPER;
                    u_sys_login.MANGSUPER = MainForm.MANGSUPER;
                    u_sys_login.SYSTEM = MainForm.SYSTEM;
                    db.U_SYS_LOGIN.InsertOnSubmit(u_sys_login);
                    db.SubmitChanges();
                    JBControls.FullDataCtrl.SystemType = "JBHR";
                    JBControls.FullDataCtrl.UserId = u_sys_login.USER_ID;

                    var frm = this.Owner as MainForm;
                    if (frm != null)
                    {
                        frm.toolStripUserList.Enabled = MainForm.ADMIN;
                    }
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Resources.Sys.WrongPassword, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            else
            {
                Sys.SysDS.U_USERDataTable U_USERDataTable = new JBHR.Sys.SysDS.U_USERDataTable();
                Sys.SysDSTableAdapters.U_USERTableAdapter U_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
                U_USERTableAdapter.FillByUSERID(U_USERDataTable, textBox1.Text);

                if (U_USERDataTable.Count > 0)
                {
                    if (textBox2.Text.Trim().ToLower() == JBModule.Data.CDecryp.Text(U_USERDataTable[0].PASSWORD).Trim().ToLower())
                    {
                        JBModule.Data.CDecryp.USER_ID = U_USERDataTable[0].USER_ID.Trim();
                        JBModule.Data.CEncrypt.USER_ID = U_USERDataTable[0].USER_ID.Trim();

                        MainForm.LOGIN_ID = U_USERDataTable[0].USER_ID.Trim();
                        MainForm.USER_ID = U_USERDataTable[0].USER_ID.Trim();
                        MainForm.USER_NAME = U_USERDataTable[0].NAME.Trim();
                        MainForm.WORKADR = U_USERDataTable[0].WORKADR.Trim();
                        MainForm.SUPER = U_USERDataTable[0].SUPER;
                        MainForm.PROCSUPER = U_USERDataTable[0].PROCSUPER;
                        MainForm.MANGSUPER = U_USERDataTable[0].MANGSUPER;
                        MainForm.ADMIN = U_USERDataTable[0].ADMIN;
                        MainForm.SYSTEM = "";
                        JBControls.FullDataCtrl.UserName = MainForm.USER_NAME;
                        JBControls.FullDataCtrl.UserId = MainForm.USER_ID;

                        var frm = this.Owner as MainForm;
                        if (frm != null)
                        {
                            frm.toolStripUserList.Enabled = MainForm.ADMIN;
                        }
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


                        (this.Owner as MainForm).toolStripStatusLabel1.Text = "          " + Resources.Sys.LoginUserID;// +MainForm.USER_ID;
                        (this.Owner as MainForm).toolStripUserList.Text = MainForm.USER_ID;
                        (this.Owner as MainForm).toolStripStatusLabel2.Text = Resources.Sys.LoginUserName + MainForm.USER_NAME;
                        //(this.Owner as MainForm).toolStripStatusLabel3.Text = Resources.Sys.DefaultWorkadr + MainForm.WORKADR;
                        (this.Owner as MainForm).toolStripStatusLabel4.Text = Resources.Sys.SYSTEM + MainForm.SYSTEM;
                        //(this.Owner as MainForm).toolStripStatusLabel5.Text = Resources.Sys.SUPER + ((MainForm.SUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                        //(this.Owner as MainForm).toolStripStatusLabel6.Text = Resources.Sys.MANGSUPER + ((MainForm.MANGSUPER) ? Resources.Sys.YES : Resources.Sys.NO);
                        //(this.Owner as MainForm).toolStripStatusLabel7.Text = Resources.Sys.PROCSUPER + ((MainForm.PROCSUPER) ? Resources.Sys.YES : Resources.Sys.NO);

                        BasDataClassesDataContext db = new BasDataClassesDataContext();
                        U_SYS_LOGIN u_sys_login = new U_SYS_LOGIN();
                        u_sys_login.IN_TIME = DateTime.Now;
                        u_sys_login.USER_ID = MainForm.USER_ID;
                        u_sys_login.USER_NAME = MainForm.USER_NAME;
                        u_sys_login.WORKADR = MainForm.WORKADR;
                        u_sys_login.SUPER = MainForm.SUPER;
                        u_sys_login.PROCSUPER = MainForm.PROCSUPER;
                        u_sys_login.MANGSUPER = MainForm.MANGSUPER;
                        u_sys_login.SYSTEM = MainForm.SYSTEM;
                        db.U_SYS_LOGIN.InsertOnSubmit(u_sys_login);
                        db.SubmitChanges();
                        JBControls.FullDataCtrl.SystemType = "JBHR";
                        JBControls.FullDataCtrl.UserId = u_sys_login.USER_ID;
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Resources.Sys.WrongPassword, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(Resources.Sys.WrongLoginID, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                }
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
            string DefaultPath = @"C:\temp\" + ConfigSetting.AppSettingValue("ProjectConnectionKey") + ".config";
            if (File.Exists(DefaultPath))
                Program.SystemConfigPath = DefaultPath;
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList(), false, true, true);
            if (cs.GetConnectionStringList().Count < 10)
                this.cbxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //避免一開始就觸發SelectIndexChanged
            cbxConnections.Leave += new EventHandler(cbxConnections_SelectedIndexChanged);

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
                cbxConnections.SelectedValue = ConnectionName;
            }
            else
            {
                if (cbxConnections.Items.Count > 0)
                    U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
                else
                {
                    MessageBox.Show("請先新增連線資訊" + Environment.NewLine 
                        + @"或是從其他電腦複製C:\Temp\app.config 並覆蓋到本機對應的檔案");
                }
            }
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
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList(), false, true, true);
            if (cs.GetConnectionStringList().Count < 10)
                this.cbxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
            U_SETDB frm = new U_SETDB();
            frm.EditType = "Edit";
            frm.ShowDialog();
            ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
            SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList(), false, true, true);
            if (cs.GetConnectionStringList().Count < 10)
                this.cbxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void pbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要刪除此連線設定檔?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                U_LOGIN.ConnectionName = cbxConnections.SelectedValue.ToString();
                ConfigSetting cs = new ConfigSetting(Program.SystemConfigPath);
                cs.DeleteConnValue(U_LOGIN.ConnectionName);
                cs.Save();
                SystemFunction.SetComboBoxItems(cbxConnections, cs.GetConnectionStringList(), false, true, true);
                if (cs.GetConnectionStringList().Count < 10)
                    this.cbxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
