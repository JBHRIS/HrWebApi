using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;//記得using
using System.Reflection;//記得using

namespace JBHR
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 登入者帳號
        /// </summary>
        public static string LOGIN_ID = "";
        /// <summary>
        /// 使用者代號
        /// </summary>
        public static string USER_ID = "";
        /// <summary>
        /// 使用者姓名
        /// </summary>
        public static string USER_NAME = "";
        /// <summary>
        /// 資料群組
        /// </summary>
        public static string WORKADR = "";
        /// <summary>
        /// 可寫入全部群組資料
        /// </summary>
        public static bool PROCSUPER
        {
            get
            {
                return false;
            }
            set
            {

            }
        }
        /// <summary>
        /// 可取得全部群組資料
        /// </summary>
        public static bool MANGSUPER
        {
            get
            {
                return false;
            }
            set
            {

            }
        }
        /// <summary>
        /// 系統權限
        /// </summary>
        public static bool SYSTEMRULE = false;
        /// <summary>
        /// 全部作業
        /// </summary>
        public static bool SUPER = false;
        /// <summary>
        /// 系統管理者
        /// </summary>
        public static bool ADMIN = false;
        /// <summary>
        /// 公司代碼
        /// </summary>
        public static string COMPANY = "";
        /// <summary>
        /// 公司名稱
        /// </summary>
        public static string COMPANY_NAME = "";
        /// <summary>
        /// 系統
        /// </summary>
        public static string SYSTEM = "";
        public static List<JBModule.Data.Linq.U_DATAGROUP> AllRules
        {
            get
            {
                var qq = from a in UserCompList where a.COMPANY == MainForm.COMPANY select a;
                if (qq.Any())
                {
                    return qq.First().U_DATAGROUP.ToList(); ;
                }
                return new List<JBModule.Data.Linq.U_DATAGROUP>();
            }
        }
        public static List<JBModule.Data.Linq.U_DATAGROUP> ReadRules
        {
            get
            {
                var qq = from a in AllRules where a.READRULE select a;
                if (qq.Any())
                {
                    return qq.ToList();
                }
                return new List<JBModule.Data.Linq.U_DATAGROUP>();
            }
        }
        public static List<JBModule.Data.Linq.U_DATAGROUP> WriteRules
        {
            get
            {
                var qq = from a in AllRules where a.WRITERULE select a;
                if (qq.Any())
                {
                    return qq.ToList();
                }
                return new List<JBModule.Data.Linq.U_DATAGROUP>();
            }
        }
        public static List<string> UserList = new List<string>();

        Dictionary<string, string> ShortCutKeys = new Dictionary<string, string>();
        Sys.SysDS.U_USERDataTable u_loignDataTable = new JBHR.Sys.SysDS.U_USERDataTable();
        Sys.SysDS.U_PRGIDDataTable U_PRGIDDataTable = new JBHR.Sys.SysDS.U_PRGIDDataTable();
        public static List<JBModule.Data.Linq.U_USERCOMP> UserCompList = new List<JBModule.Data.Linq.U_USERCOMP>();
        public static Dictionary<string, string> CompDic = new Dictionary<string, string>();
        public static List<string> NobrListOfRead
        {
            get
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE.Value
                          && MainForm.ReadRules.Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select a.NOBR;
                return sql.ToList();
            }
        }
        public static List<string> NobrListOfWrite
        {
            get
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE.Value
                          && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select a.NOBR;
                return sql.ToList();
            }
        }
        public static JBModule.Data.Linq.U_SYS1 CompanyConfig = null;
        public static JBModule.Data.Linq.U_SYS2 SalaryConfig = null;
        public static JBModule.Data.Linq.U_SYS3 OvertimeConfig = null;
        public static JBModule.Data.Linq.U_SYS4 LabConfig = null;
        public static JBModule.Data.Linq.U_SYS5 HealthConfig = null;
        public static JBModule.Data.Linq.U_SYS6 GroupInsConfig = null;
        public static JBModule.Data.Linq.U_SYS8 YearHolidayConfig = null;
        public static JBModule.Data.Linq.U_SYS9 TaxConfig = null;
        public static JBModule.Data.Linq.U_SYS10 MailConfig = null;
        bool isComfirmClosing = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text = "人事薪資考勤管理系統(" + Sal.Core.SysVar.CompanyVar.COMPANY + ")";
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    this.Text += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}

            foreach (var mainmenu_item in menuStrip1.Items)
            {
                ToolStripMenuItem mnu = mainmenu_item as ToolStripMenuItem;
                if (mnu != null)
                    set_menuitem_event(mnu);
            }

            U_LOGIN u_loign = new U_LOGIN();
            u_loign.Icon = this.Icon;
            u_loign.Owner = this;
            DialogResult ret = u_loign.ShowDialog();

            if (ret == DialogResult.Yes)
            {
                check_login(MainForm.USER_ID);
            }
            if (ret == DialogResult.No)
            {
                重新登錄ToolStripMenuItem.Enabled = true;
                更改密碼ToolStripMenuItem.Enabled = false;

                資料維護DToolStripMenuItem.Enabled = false;
                報表列印RToolStripMenuItem.Enabled = false;
            }
            if (ret == DialogResult.Cancel) this.Close();
            JBModule.Message.TextLog.path = @"C:\Temp\Error";
        }

        private void check_login(string userid)
        {
            MainForm.USER_ID = userid;
            var frm = this as MainForm;
            if (frm != null)
            {
                var dbHR = new JBModule.Data.Linq.HrDBDataContext();
                //if (userid == "JBADMIN")
                //    sql = from a in dbHR.U_USERCOMP where a.USER_ID == userid select a;
                var userData = from a in dbHR.U_USER where a.SYSTEM == "JBHR" select a;
                MainForm.UserList = userData.Select(p => p.USER_ID).ToList();

                frm.toolStripUserList.DropDownItems.Clear();
                MainForm.CompDic = new Dictionary<string, string>();
                MainForm.UserCompList = new List<JBModule.Data.Linq.U_USERCOMP>();
                if (LOGIN_ID == "JBADMIN")
                    frm.toolStripUserList.DropDownItems.Add(LOGIN_ID);
                if (userid == "JBADMIN")
                {
                    MainForm.SUPER = true;
                    MainForm.ADMIN = true;
                    MainForm.SYSTEMRULE = true;
                }
                else
                {
                    var currentUserData = from a in userData where a.USER_ID == userid select a;
                    var currentUser = currentUserData.First();
                    MainForm.ADMIN = currentUser.ADMIN;
                    MainForm.SUPER = currentUser.SUPER || MainForm.ADMIN;
                    MainForm.SYSTEMRULE = currentUser.MANGSUPER || MainForm.ADMIN;
                    var sql = from a in dbHR.U_USERCOMP where a.USER_ID == userid select a;
                    MainForm.UserCompList = sql.ToList();
                }
                foreach (var it in MainForm.UserList)
                    frm.toolStripUserList.DropDownItems.Add(it);
                frm.toolStripCbxCompany.Items.Clear();
                JBControls.ControlConfig.CurrentUser = userid;
                if (MainForm.ADMIN)//如果是管理者，就直接可以看到全部公司跟權限
                {
                    MainForm.UserCompList.Clear();
                    var sqlAdmin = from a in dbHR.COMP select a;
                    foreach (var it in sqlAdmin)
                    {
                        JBModule.Data.Linq.U_USERCOMP uc = new JBModule.Data.Linq.U_USERCOMP();
                        uc.COMPANY = it.COMP1;
                        uc.USER_ID = LOGIN_ID;
                        uc.KEY_DATE = DateTime.Now;
                        uc.KEY_MAN = MainForm.USER_ID;
                        uc.COMP = it;
                        MainForm.UserCompList.Add(uc);
                        foreach (var r in it.COMP_DATAGROUP)
                        {
                            JBModule.Data.Linq.U_DATAGROUP ug = new JBModule.Data.Linq.U_DATAGROUP();
                            ug.COMPANY = it.COMP1;
                            ug.USER_ID = LOGIN_ID;
                            ug.DATAGROUP = r.DATAGROUP;
                            ug.KEY_DATE = DateTime.Now;
                            ug.KEY_MAN = MainForm.USER_ID;
                            ug.READRULE = true;
                            ug.WRITERULE = true;
                            ug.COMP = it;
                            uc.U_DATAGROUP.Add(ug);
                            ug.DATAGROUP1 = r.DATAGROUP1;
                        }
                    }
                }
                if (userid == LOGIN_ID)
                    toolStripUserList.ForeColor = Color.Black;
                else toolStripUserList.ForeColor = Color.Red;

                foreach (var it in MainForm.UserCompList)
                {
                    MainForm.CompDic.Add(it.COMPANY, it.COMP.COMPNAME);
                    frm.toolStripCbxCompany.Items.Add(it.COMP.COMPNAME);
                }
                if (frm.toolStripCbxCompany.Items.Count > 0)
                {
                    frm.toolStripCbxCompany.SelectedIndex = 0;
                    //frm.toolStripCbxCompany_SelectedIndexChanged(null, null);
                }
            }
            if (userid == "JBADMIN")
            {
                foreach (var mainmenu_item in menuStrip1.Items)
                {
                    ToolStripMenuItem mnu = mainmenu_item as ToolStripMenuItem;
                    if (mnu != null)
                        init_menuitem(mnu);
                }
            }
            else
            {
                Sys.SysDSTableAdapters.U_USERTableAdapter u_loignTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
                u_loignDataTable = u_loignTableAdapter.GetDataByUSERID(userid);
                if (u_loignDataTable.Count > 0)
                {
                    if (u_loignDataTable[0].SUPER || MainForm.ADMIN)
                    {
                        foreach (var mainmenu_item in menuStrip1.Items)
                        {
                            ToolStripMenuItem mnu = mainmenu_item as ToolStripMenuItem;
                            if (mnu != null)
                                init_menuitem(mnu);
                        }
                    }
                    else
                    {
                        Sys.SysDSTableAdapters.U_PRGIDTableAdapter U_PRGIDTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_PRGIDTableAdapter();
                        U_PRGIDDataTable = U_PRGIDTableAdapter.GetDataByUSERID(userid, SYSTEM);

                        foreach (var mainmenu_item in menuStrip1.Items)
                        {
                            ToolStripMenuItem mnu = mainmenu_item as ToolStripMenuItem;
                            if (mnu != null)
                                set_menuitem(mnu, userid);
                        }

                    }
                }
                重新登錄ToolStripMenuItem.Enabled = true;
                更改密碼ToolStripMenuItem.Enabled = true;

                if (MainForm.SYSTEMRULE || MainForm.ADMIN)
                {
                    重新登錄ToolStripMenuItem.Enabled = true;
                }
                SetRule();
                SetTitle();
                JBControls.FullDataCtrl.UserId = userid;
                JBControls.FullDataCtrl.Admin = ADMIN;
            }
        }

        private void set_menuitem(ToolStripMenuItem mainmenu_item, string userid)
        {
            foreach (object submenu_item in mainmenu_item.DropDownItems)
            {
                if (submenu_item is ToolStripMenuItem)
                {
                    if ((submenu_item as ToolStripMenuItem).Tag != null)
                    {
                        if ((submenu_item as ToolStripMenuItem).Tag.ToString().Trim().Length > 0)
                        {
                            string[] menu_tag = (submenu_item as ToolStripMenuItem).Tag.ToString().Trim().Split(new char[] { '.' });

                            DataRow row = U_PRGIDDataTable.FindByUSER_IDPROGSYSTEM(userid, menu_tag[menu_tag.Length - 1], u_loignDataTable[0].SYSTEM.Trim());
                            if (row == null)
                            {
                                (submenu_item as ToolStripMenuItem).Enabled = false;
                            }
                            else (submenu_item as ToolStripMenuItem).Enabled = true;
                        }
                        else
                        {
                            if ((submenu_item as ToolStripMenuItem).DropDownItems.Count > 0) set_menuitem(submenu_item as ToolStripMenuItem, userid);
                        }
                    }
                    else
                    {
                        if ((submenu_item as ToolStripMenuItem).DropDownItems.Count > 0) set_menuitem(submenu_item as ToolStripMenuItem, userid);
                    }
                }
            }
        }

        private void init_menuitem(ToolStripMenuItem mainmenu_item)
        {
            mainmenu_item.Enabled = true;
            foreach (object submenu_item in mainmenu_item.DropDownItems)
            {
                if (submenu_item is ToolStripMenuItem)
                {
                    (submenu_item as ToolStripMenuItem).Enabled = true;
                    if ((submenu_item as ToolStripMenuItem).DropDownItems.Count > 0) init_menuitem(submenu_item as ToolStripMenuItem);
                }
            }
        }

        private void refresh_menu()
        {
            MainDSTableAdapters.U_PRGTableAdapter U_PRGTableAdapter = new JBHR.MainDSTableAdapters.U_PRGTableAdapter();
            MainDS.U_PRGDataTable U_PRGDataTable = U_PRGTableAdapter.GetData();
            foreach (var row in U_PRGDataTable) row.Delete();
            U_PRGTableAdapter.Update(U_PRGDataTable);

            foreach (ToolStripMenuItem mainmenu_item in menuStrip1.Items)
            {
                import_menuitem(mainmenu_item, U_PRGDataTable);
            }
            U_PRGTableAdapter.Update(U_PRGDataTable);
        }

        private void import_menuitem(ToolStripMenuItem mainmenu_item, MainDS.U_PRGDataTable U_PRGDataTable)
        {
            foreach (object submenu_item in mainmenu_item.DropDownItems)
            {
                if (submenu_item is ToolStripMenuItem)
                {
                    if ((submenu_item as ToolStripMenuItem).Tag != null)
                    {
                        string[] menu_tag = (submenu_item as ToolStripMenuItem).Tag.ToString().Trim().Split(new char[] { '.' });

                        MainDS.U_PRGRow U_PRGRow = U_PRGDataTable.NewU_PRGRow();
                        U_PRGRow.PROG = menu_tag[menu_tag.Count() - 1];
                        U_PRGRow.PROG_NAME = (submenu_item as ToolStripMenuItem).Text;
                        U_PRGRow.SYSTEM = "JBHR";
                        U_PRGRow.ROOT = false;
                        U_PRGRow.KEY_DATE = DateTime.Now;
                        U_PRGRow.KEY_MAN = "JBHR";
                        U_PRGDataTable.AddU_PRGRow(U_PRGRow);
                    }
                    else
                    {
                        if ((submenu_item as ToolStripMenuItem).DropDownItems.Count > 0) import_menuitem(submenu_item as ToolStripMenuItem, U_PRGDataTable);
                    }
                }
            }
        }

        private void set_menuitem_event(ToolStripMenuItem mainmenu_item)
        {
            foreach (object submenu_item in mainmenu_item.DropDownItems)
            {
                if (submenu_item is ToolStripMenuItem)
                {
                    (submenu_item as ToolStripMenuItem).Click += ToolStripMenuItem_Click;
                    if ((submenu_item as ToolStripMenuItem).DropDownItems.Count > 0) set_menuitem_event(submenu_item as ToolStripMenuItem);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            if (tsmi.Tag != null && tsmi.Tag.ToString().Length > 0)
            {
                if (tsmi.Tag.ToString().ToLower() == "u_login")
                {
                    ChildrenFormClose();

                    USER_ID = "";
                    USER_NAME = "";
                    WORKADR = "";
                    SUPER = false;
                    PROCSUPER = false;
                    SYSTEMRULE = false;
                    SYSTEM = "";

                    toolStripStatusLabel1.Text = "";
                    toolStripStatusLabel2.Text = "";
                    //toolStripStatusLabel3.Text = "";
                    toolStripStatusLabel4.Text = "";
                    //toolStripStatusLabel5.Text = "";
                    //toolStripStatusLabel6.Text = "";
                    //toolStripStatusLabel7.Text = "";

                    U_LOGIN u_loign = new U_LOGIN();
                    u_loign.Icon = this.Icon;
                    u_loign.Owner = this;
                    DialogResult ret = u_loign.ShowDialog();

                    if (ret == DialogResult.Yes)
                    {
                        check_login(MainForm.USER_ID);
                    }
                    if (ret == DialogResult.No)
                    {
                        重新登錄ToolStripMenuItem.Enabled = true;
                        更改密碼ToolStripMenuItem.Enabled = false;

                        資料維護DToolStripMenuItem.Enabled = false;
                        報表列印RToolStripMenuItem.Enabled = false;
                    }
                    if (ret == DialogResult.Cancel) this.Close();
                }
                else
                {
                    try
                    {
                        bool isOpend = false;
                        foreach (var f in this.MdiChildren)
                        {
                            var patterns = tsmi.Tag.ToString().Split('.');
                            if (patterns.Count() == 2 && patterns[1].Equals(f.Name))
                            {
                                isOpend = true;
                                f.Focus();
                                break;
                            }
                        }

                        if (!isOpend)
                        {
                            JBControls.JBForm form = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("JBHR." + tsmi.Tag.ToString(), true) as JBControls.JBForm;
                            form.Text = form.Name + "-" + (sender as ToolStripMenuItem).Text;
                            form.Icon = this.Icon;
                            form.MdiParent = this;
                            form.toolStripMenuItem = tsmi;
                            form.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            if (isComfirmClosing)
            {
                if (MainForm.USER_NAME != "")
                {
                    if (MessageBox.Show(Resources.All.ExitSystem, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                isComfirmClosing = false;
                this.Close();
            }
        }

        void SetMenu(ToolStripItemCollection MenuItems)
        {
            foreach (object obj in MenuItems)
            {
                ToolStripMenuItem itm = obj as ToolStripMenuItem;
                if (itm != null)
                {
                    itm.ShortcutKeys = Keys.None;
                    if (itm.Tag != null && itm.Tag.ToString().Trim().Length > 0)
                    {
                        if (ShortCutKeys.ContainsKey(itm.Name))
                        {
                            Keys myKey = new Keys();
                            switch (ShortCutKeys[itm.Name])
                            {
                                case "F1":
                                    myKey = Keys.F1;
                                    break;
                                case "F2":
                                    myKey = Keys.F2;
                                    break;
                                case "F3":
                                    myKey = Keys.F3;
                                    break;
                                case "F4":
                                    myKey = Keys.F4;
                                    break;
                                case "F5":
                                    myKey = Keys.F5;
                                    break;
                                case "F6":
                                    myKey = Keys.F6;
                                    break;
                                case "F7":
                                    myKey = Keys.F7;
                                    break;
                                case "F8":
                                    myKey = Keys.F8;
                                    break;
                                case "F9":
                                    myKey = Keys.F9;
                                    break;
                                case "F10":
                                    myKey = Keys.F10;
                                    break;
                                case "F11":
                                    myKey = Keys.F11;
                                    break;
                                case "F12":
                                    myKey = Keys.F12;
                                    break;
                                default:
                                    myKey = Keys.None;
                                    break;
                            }
                            itm.ShortcutKeys = myKey;
                        }
                    }
                    if (itm.DropDownItems.Count > 0)
                        SetMenu(itm.DropDownItems);
                }
            }
        }

        private void 信件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.MailQueueMonitor frm = new JBModule.Message.UI.MailQueueMonitor();
            frm.KEY_MAN = MainForm.USER_NAME;
            frm.Icon = this.Icon;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 記錄管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.LogMonitor frm = new JBModule.Message.UI.LogMonitor();
            frm.KEY_MAN = MainForm.USER_NAME;
            frm.Icon = this.Icon;
            frm.MdiParent = this;
            frm.Show();
        }

        private void 郵件參數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBModule.Message.UI.Parameter frm = new JBModule.Message.UI.Parameter();
            //frm.KEY_MAN = MainForm.USER_NAME;
            frm.Icon = this.Icon;
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripCbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MdiChildren.Any())
            {
                if (MessageBox.Show("切換公司別時，現有的視窗將會全部關閉，是否要繼續?", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    ChildrenFormClose();
                else
                {
                    toolStripCbxCompany.SelectedIndexChanged -= new EventHandler(toolStripCbxCompany_SelectedIndexChanged);//停用事件
                    toolStripCbxCompany.SelectedItem = MainForm.COMPANY_NAME;
                    toolStripCbxCompany.SelectedIndexChanged += new EventHandler(toolStripCbxCompany_SelectedIndexChanged);//重啟事件
                    return;
                }
            }
            MainForm.COMPANY = MainForm.CompDic.Where(p => p.Value == toolStripCbxCompany.SelectedItem.ToString()).First().Key;
            MainForm.COMPANY_NAME = toolStripCbxCompany.SelectedItem.ToString();
            MainForm.SetSysConfig(MainForm.COMPANY);

            JBControls.FullDataCtrl.Company = MainForm.COMPANY;
            SetRule();
            SetTitle();
            var control = this.FindForm().GetNextControl(this, true);
            if (control == null) return;
            while (!control.TabStop)
            {
                control = this.FindForm().GetNextControl(control, true);
                if (control == null) return;//避免null錯誤
            }
            control.Focus();
        }
        void SetRule()
        {
            toolStripDropDownButton1.DropDownItems.Clear();
            toolStripDropDownButton1.Text = "讀取權限(" + ReadRules.Count().ToString("00") + ")";
            foreach (var it in ReadRules)
            {
                toolStripDropDownButton1.DropDownItems.Add(it.DATAGROUP1.GROUPNAME);
            }


            toolStripDropDownButton2.DropDownItems.Clear();
            toolStripDropDownButton2.Text = "寫入權限(" + WriteRules.Count().ToString("00") + ")";
            foreach (var it in WriteRules)
            {
                toolStripDropDownButton2.DropDownItems.Add(it.DATAGROUP1.GROUPNAME);
            }
        }
        void ChildrenFormClose()
        {
            if (this.MdiChildren.Count() > 0)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
            }
        }

        private void toolStripUserList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (MessageBox.Show("此操作會切換到帳號模擬時，現有的視窗將會全部關閉，是否要繼續?", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ChildrenFormClose();
                check_login(e.ClickedItem.Text);
                toolStripUserList.Text = e.ClickedItem.Text;
            }
        }

        private void toolStripCbxDataGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = this.FindForm().GetNextControl(this, true);
            if (control == null) return;
            while (!control.TabStop)
            {
                control = this.FindForm().GetNextControl(control, true);
                if (control == null) return;//避免null錯誤
            }
            control.Focus();
        }
        public static void SetSysConfig(string Comp)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            var sys1 = from a in db.U_SYS1 where a.Comp == Comp select a;
            MainForm.CompanyConfig = sys1.FirstOrDefault();

            var sys2 = from a in db.U_SYS2 where a.Comp == Comp select a;
            MainForm.SalaryConfig = sys2.FirstOrDefault();

            var sys3 = from a in db.U_SYS3 where a.Comp == Comp select a;
            MainForm.OvertimeConfig = sys3.FirstOrDefault();

            var sys4 = from a in db.U_SYS4 where a.Comp == Comp select a;
            MainForm.LabConfig = sys4.FirstOrDefault();

            var sys5 = from a in db.U_SYS5 where a.Comp == Comp select a;
            MainForm.HealthConfig = sys5.FirstOrDefault();

            var sys6 = from a in db.U_SYS6 where a.Comp == Comp select a;
            MainForm.GroupInsConfig = sys6.FirstOrDefault();

            var sys8 = from a in db.U_SYS8 where a.Comp == Comp select a;
            MainForm.YearHolidayConfig = sys8.FirstOrDefault();

            var sys9 = from a in db.U_SYS9 where a.Comp == Comp select a;
            MainForm.TaxConfig = sys9.FirstOrDefault();

            var sys10 = from a in db.U_SYS10 where a.Comp == Comp select a;
            MainForm.MailConfig = sys10.FirstOrDefault();
        }
        void SetTitle()
        {
            if (MainForm.CompanyConfig != null)
                this.Text = "考勤助理系統(" + MainForm.CompanyConfig.COMPANY + ")";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            if (U_LOGIN.ConnectionName.Trim().Length > 0) this.Text += "(" + U_LOGIN.ConnectionName + ")";
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            ConfigManager frm = new ConfigManager();
            frm.Icon = this.Icon;
            frm.Category = "DLL.Config";
            frm.MdiParent = this;
            frm.Show();
        }

        //private void 系統資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    AboutBoxVersion frm = new AboutBoxVersion();
        //    frm.Icon = this.Icon;
        //    frm.ShowDialog();
        //}
    }
}
