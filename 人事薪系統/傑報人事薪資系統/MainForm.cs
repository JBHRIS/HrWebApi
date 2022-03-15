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
using SQLController.SqlTools;
using Autofac;
using System.Data.SqlClient;
using JBHR.Properties;
using JBModule.Data.Linq;
using JBModule.Data.Dto;
using JBHR.Sys;
using System.Deployment.Application;

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
        public static RunMode RunningMode;
        public static Autofac.IContainer JbContainer;
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

        //Dictionary<string, string> ShortCutKeys = new Dictionary<string, string>();
        public static JBHRIS.BLL.Repo.IRepoHelper RepoHelper = new JBModule.Data.Repo.RepoHelper();
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

        /// <summary>
        /// MainForm's MainMenuStrip
        /// </summary>
        //private MenuStrip mainMenuStrip = null;
        private MenuStrip totalMenuStrip = new MenuStrip();
        public static Dictionary<string, string> FormList = new Dictionary<string, string>();
        public static Dictionary<string, Type> ExTypes = new Dictionary<string, Type>();
        Font MenuFont = new Font("微軟正黑體", 10, FontStyle.Regular);
        ToolStripMenuItem MdiWindowListItem = new ToolStripMenuItem();
        List<string> exMenuList = new List<string>();//預設例外選單:當使用者權限只有Super時不會強制顯示
        List<string> cmMenuList = new List<string>();//預設公用選單
        SqlAutoUpdate sauFunc = new SqlAutoUpdate();
        public MainForm()
        {
            InitializeComponent();
            DrawMDIBackgroundColor();
        }
        #region 複製選單相關方法
        private object CreateNewMenuItem(object sub_menuitem)//依照既有資料創建新的MenuItem(ojbect:ToolStripMenuItem、ToolStripSeparator)
        {
            if (sub_menuitem is ToolStripMenuItem)
            {
                ToolStripMenuItem new_Menuitem = new ToolStripMenuItem();
                ToolStripMenuItem temp_Menuitem = (sub_menuitem as ToolStripMenuItem);
                new_Menuitem.Name = temp_Menuitem.Name;
                new_Menuitem.Text = temp_Menuitem.Text;
                new_Menuitem.Tag = temp_Menuitem.Tag;
                new_Menuitem.ShortcutKeys = temp_Menuitem.ShortcutKeys;
                new_Menuitem.Enabled = temp_Menuitem.Enabled;
                return new_Menuitem;
            }
            else
            {
                ToolStripSeparator new_Menuitem = new ToolStripSeparator();
                ToolStripSeparator temp_Menuitem = (sub_menuitem as ToolStripSeparator);
                new_Menuitem.Name = temp_Menuitem.Name;
                new_Menuitem.Text = temp_Menuitem.Text;
                new_Menuitem.Tag = temp_Menuitem.Tag;
                new_Menuitem.Enabled = temp_Menuitem.Enabled;
                return new_Menuitem;
            }
        }
        private void Init_menuitem_func(ToolStripItemCollection target_MenuItem, ToolStripMenuItem source_MenuItem)//複製來源選單樹
        {
            foreach (var sub_MenuItem in source_MenuItem.DropDownItems)
            {
                if (sub_MenuItem is ToolStripMenuItem)
                {
                    if ((sub_MenuItem as ToolStripMenuItem).Available)
                    {
                        ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                        if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                            Init_menuitem_func(new_MenuItem.DropDownItems, sub_MenuItem as ToolStripMenuItem);
                        target_MenuItem.Add(new_MenuItem); 
                    }
                }
                else if (sub_MenuItem is ToolStripSeparator)
                {
                    if ((sub_MenuItem as ToolStripSeparator).Available)
                    {
                        ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                        target_MenuItem.Add(new_MenuItem); 
                    }
                }
            }
        }

        /// <summary>
        ///    MenuStripStructure Initial
        ///    o
        /// </summary>
        private MenuStripStructure MSSInstanceIni(ToolStripItemCollection source_Items, object sub_MenuItem, Guid MenuGroupID, Guid ParentID)//, object new_MenuItem
        {
            MenuStripStructure instance = new MenuStripStructure();
            instance.MenuGroupID = MenuGroupID;
            instance.MenuStripID = Guid.NewGuid();
            instance.ParentID = ParentID;
            instance.Key_Man = MainForm.USER_ID;
            instance.Key_Date = DateTime.Now;
            instance.CommonItem = false;
            if (sub_MenuItem is ToolStripMenuItem)
            {
                ToolStripMenuItem temp_Menuitem = (sub_MenuItem as ToolStripMenuItem);
                instance.MenuStripName = temp_Menuitem.Name;
                instance.MenuStripText = temp_Menuitem.Text;
                instance.ItemIndex = source_Items.IndexOf(temp_Menuitem as ToolStripMenuItem);
                instance.AssemblyName = null;
                if (temp_Menuitem.Tag != null && temp_Menuitem.Tag.ToString().Trim().Length != 0)
                {
                    string AssemblyName = temp_Menuitem.Tag.ToString().Trim();
                    if (FormList.ContainsKey(AssemblyName.ToUpper()))
                        instance.AssemblyName = temp_Menuitem.Tag.ToString();
                    else if (FormList.ContainsKey("JBHR." + AssemblyName.ToUpper()))
                        instance.AssemblyName = "JBHR." + temp_Menuitem.Tag.ToString();
                }
                if (temp_Menuitem.ShortcutKeys != Keys.None)
                    instance.ShortcutKeys = temp_Menuitem.ShortcutKeys.ToString();
                else
                    instance.ShortcutKeys = null;
                if (cmMenuList.Contains(temp_Menuitem.Name))
                    instance.CommonItem = true;
                instance.Enable = temp_Menuitem.Enabled;
            }
            else
            {
                ToolStripSeparator temp_Menuitem = (sub_MenuItem as ToolStripSeparator);
                instance.MenuStripName = temp_Menuitem.Name;
                instance.MenuStripText = temp_Menuitem.Text;
                instance.ItemIndex = source_Items.IndexOf(temp_Menuitem as ToolStripSeparator);
                instance.AssemblyName = "ToolStripSeparator";
                if (cmMenuList.Contains(temp_Menuitem.Name))
                    instance.CommonItem = true;
                instance.Enable = temp_Menuitem.Enabled;
            }
            return instance;
        }
        private void MenuItemInfoSetTag(MenuStripStructure instance, object new_MenuItem)
        {
            MenuItemInfo MIInfo = new MenuItemInfo();
            MIInfo.MenuGroupID = instance.MenuGroupID;
            MIInfo.MenuStripID = instance.MenuStripID;
            MIInfo.ParentID = instance.ParentID;
            MIInfo.AssemblyName = instance.AssemblyName;
            MIInfo.Index = instance.ItemIndex;
            MIInfo.Enable = instance.Enable;
            MIInfo.CommonItem = instance.CommonItem;
            if (new_MenuItem is ToolStripMenuItem)
                (new_MenuItem as ToolStripMenuItem).Tag = MIInfo;
            else
                (new_MenuItem as ToolStripSeparator).Tag = MIInfo;
        }
        /// <summary>
        ///    ToolStripMenuItem Initial Function into DB
        /// </summary>
        private void Init_menuitem_func( ToolStripMenuItem source_MenuItem, Guid MenuGroupID, Guid ParentID,JBModule.Data.Linq.HrDBDataContext db)//ToolStripItemCollection target_MenuItem, , List<MenuStripStructure> MMSList)
        {
            foreach (var sub_MenuItem in source_MenuItem.DropDownItems)
            {
                MenuStripStructure instance = new MenuStripStructure();
                if (sub_MenuItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                    instance = MSSInstanceIni(source_MenuItem.DropDownItems, sub_MenuItem, MenuGroupID, ParentID);
                    MenuItemInfoSetTag(instance, new_MenuItem);
                    db.MenuStripStructure.InsertOnSubmit(instance);
                    if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                        Init_menuitem_func( sub_MenuItem as ToolStripMenuItem, MenuGroupID, instance.MenuStripID,db);
                    //target_MenuItem.Add(new_MenuItem);
                }
                else if (sub_MenuItem is ToolStripSeparator)
                {
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                    instance = MSSInstanceIni(source_MenuItem.DropDownItems, sub_MenuItem, MenuGroupID, ParentID);
                    MenuItemInfoSetTag(instance, new_MenuItem);
                    db.MenuStripStructure.InsertOnSubmit(instance);
                    //target_MenuItem.Add(new_MenuItem);
                }
            }
        }
        private void Init_menuitem_func(ToolStripMenuItem source_MenuItem, Guid MenuGroupID, Guid ParentID, List<MenuStripStructure> NewList)//ToolStripItemCollection target_MenuItem, , List<MenuStripStructure> MMSList)
        {
            foreach (var sub_MenuItem in source_MenuItem.DropDownItems)
            {
                MenuStripStructure instance = new MenuStripStructure();
                if (sub_MenuItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                    instance = MSSInstanceIni(source_MenuItem.DropDownItems, sub_MenuItem, MenuGroupID, ParentID);
                    MenuItemInfoSetTag(instance, new_MenuItem);
                    NewList.Add(instance);//db.MenuStripStructure.InsertOnSubmit(instance);
                    if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                        Init_menuitem_func(sub_MenuItem as ToolStripMenuItem, MenuGroupID, instance.MenuStripID, NewList);
                    //target_MenuItem.Add(new_MenuItem);
                }
                else if (sub_MenuItem is ToolStripSeparator)
                {
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                    instance = MSSInstanceIni(source_MenuItem.DropDownItems, sub_MenuItem, MenuGroupID, ParentID);
                    MenuItemInfoSetTag(instance, new_MenuItem);
                    NewList.Add(instance);//db.MenuStripStructure.InsertOnSubmit(instance);
                    //target_MenuItem.Add(new_MenuItem);
                }
            }
        }

        #endregion

        private void InitialAssemblyList()
        {
            #region 取得exportedType符合FromType的Assembly
            var Assemblys = AppDomain.CurrentDomain.GetAssemblies();
            List<string> FormType = new List<string>();
            FormType.Add("Form");
            //FormType.Add("JBForm");
            //FormType.Add("U_PATCH");
            foreach (var assembly in Assemblys)
            {
                string AsmName = assembly.GetName().Name;
                var exportedType = assembly.GetExportedTypes();
                foreach (var item in exportedType)
                {
                    var derived = item;
                    do
                    {
                        derived = derived.BaseType;
                        if (derived != null && FormType.Contains(derived.Name) && !FormList.ContainsKey(item.Name))
                        {
                            FormList.Add(item.FullName.ToUpper(), item.Name.ToUpper());
                            ExTypes.Add(item.FullName.ToUpper(), item);
                            derived = null;
                        }
                    } while (derived != null);
                }
            } 
            #endregion
        }

        private void DrawMDIBackgroundColor()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    string hex = "#EEEEEE";// "#E8EDF6";
                    ctl.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                }
            }
        }

        private void InitialCheckFunc()
        {
            if (sauFunc.ConnectionString != U_LOGIN.ConnectionString)
            {
                bool exists = false;
                using (SqlConnection connection = new SqlConnection(U_LOGIN.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "select case when exists((select * from information_schema.tables where table_name = 'SQLUPDATETABLE')) then 1 else 0 end", connection);
                    connection.Open();
                    exists = (int)cmd.ExecuteScalar() == 1;
                }

                var dbHR = new HrDBDataContext();
                var ApplicationName = dbHR.AppConfig.Where(p => p.Category == "Appconfig" && p.Code == "ApplicationName").FirstOrDefault();

                if (exists && ApplicationName == null)
                {
                    #region 當有SqlUpdateTable時卻沒ApplicationName表示初導入
                    AppConfig appConfig = new AppConfig()
                    {
                        Category = "Appconfig",
                        Code = "ApplicationName",
                        Comp = "",
                        ControlType = "TextBox",
                        DataSource = "",
                        DataType = "String",
                        KeyDate = DateTime.Now,
                        KeyMan = "JB",
                        NameP = "執行程式名稱",
                        Note = "",
                        Sort = 0,
                        Value = "JBHR2"
                    };
                    dbHR.AppConfig.InsertOnSubmit(appConfig);
                    dbHR.SubmitChanges(); 
                    #endregion
                }

                if (exists && ApplicationName != null && ApplicationName.Value == "JBHR2")
                {
                    sauFunc = new SqlAutoUpdate(U_LOGIN.ConnectionString);
                    sauFunc.SqlUpdateCheck();
                    #region 預設選單建立及更新
                    bool ClickOnceFirstRun = false;
                    if (ApplicationDeployment.IsNetworkDeployed)
                    {
                        ApplicationDeployment deployment = ApplicationDeployment.CurrentDeployment;
                        ClickOnceFirstRun = deployment.IsFirstRun;
                    }

                    var MenuSql = dbHR.MenuGroup.Where(p => p.MenuGroupName == "_SystemDefault");
                    if (!MenuSql.Any())
                    {
                        #region 建立系統選單預設值-MenuGroup
                        MenuGroup instanceMG = new MenuGroup();
                        instanceMG.MenuGroupID = Guid.NewGuid();
                        dbHR.MenuGroup.InsertOnSubmit(instanceMG);

                        instanceMG.MenuGroupName = "_SystemDefault";
                        instanceMG.Note = "預設選單,請勿隨意修改刪除.必要時請自行調整.";
                        instanceMG.Key_Man = MainForm.USER_ID;
                        instanceMG.Key_Date = DateTime.Now;
                        dbHR.SubmitChanges();
                        #endregion

                        #region 建立系統選單細節預設值-MenuStripStructure
                        MenuStripStructure instanceDF = new MenuStripStructure();
                        foreach (var sub_MenuItem in totalMenuStrip.Items)
                        {
                            if (sub_MenuItem is ToolStripMenuItem)
                            {
                                ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                                instanceDF = MSSInstanceIni(totalMenuStrip.Items, sub_MenuItem, instanceMG.MenuGroupID, Guid.Empty);
                                MenuItemInfoSetTag(instanceDF, new_MenuItem);
                                dbHR.MenuStripStructure.InsertOnSubmit(instanceDF);
                                if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                                    Init_menuitem_func(sub_MenuItem as ToolStripMenuItem, instanceMG.MenuGroupID, instanceDF.MenuStripID, dbHR);
                            }
                            else if (sub_MenuItem is ToolStripSeparator)
                            {
                                ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                                instanceDF = MSSInstanceIni(totalMenuStrip.Items, sub_MenuItem, instanceMG.MenuGroupID, Guid.Empty);
                                MenuItemInfoSetTag(instanceDF, new_MenuItem);
                                dbHR.MenuStripStructure.InsertOnSubmit(instanceDF);
                            }
                        }
                        dbHR.SubmitChanges();
                        #endregion
                    }

                    #region 當有公司資料沒有選單設定時帶入預設選單
                    var sqlcomp = dbHR.COMP1.Where(p => p.MenuGroupID == null || p.MenuGroupID.Equals(Guid.Empty));
                    if (sqlcomp.Any())
                    {
                        var sql = dbHR.MenuGroup.Where(p => p.MenuGroupName == "_SystemDefault").First();
                        foreach (var item in sqlcomp)
                        {
                            item.MenuGroupID = sql.MenuGroupID;
                            dbHR.SubmitChanges();
                        }
                    }
                    #endregion

                    if (MainForm.ADMIN || MainForm.USER_ID == "JBADMIN" || ClickOnceFirstRun == true)
                    {
                        #region 更新預設選單副本供選單管理使用
                        List<MenuStripStructure> NewList = new List<MenuStripStructure>();
                        MenuStripStructure instance = new MenuStripStructure();
                        foreach (var sub_MenuItem in totalMenuStrip.Items)
                        {
                            if (sub_MenuItem is ToolStripMenuItem)
                            {
                                ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                                instance = MSSInstanceIni(totalMenuStrip.Items, sub_MenuItem, Guid.Empty, Guid.Empty);
                                MenuItemInfoSetTag(instance, new_MenuItem);
                                NewList.Add(instance);//dbHR.MenuStripStructure.InsertOnSubmit(instance);
                                if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                                    Init_menuitem_func(sub_MenuItem as ToolStripMenuItem, Guid.Empty, instance.MenuStripID, NewList);
                            }
                            else if (sub_MenuItem is ToolStripSeparator)
                            {
                                ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                                instance = MSSInstanceIni(totalMenuStrip.Items, sub_MenuItem, Guid.Empty, Guid.Empty);
                                MenuItemInfoSetTag(instance, new_MenuItem);
                                NewList.Add(instance);
                                //dbHR.MenuStripStructure.InsertOnSubmit(instance);
                            }
                        }

                        var OldList = dbHR.MenuStripStructure.Where(p => p.MenuGroupID.Equals(Guid.Empty)).ToList();
                        if (OldList.Count() > 0)//當MENUGROUPID=Guid.Empty的資料時，表示非初始安裝程式，需確認是否有選單更新
                        {
                            dbHR = new HrDBDataContext();
                            //var NewList = dbHR.MenuStripStructure.Where(p => p.MenuGroupID.Equals(Guid.Empty)).ToList();
                            var DeleteArr = OldList.Select(p => new { p.MenuStripName, p.MenuStripText, p.ItemIndex, p.CommonItem, p.ShortcutKeys, p.Enable, p.AssemblyName })
                                .Where(c => !NewList.Select(p => new { p.MenuStripName, p.MenuStripText, p.ItemIndex, p.CommonItem, p.ShortcutKeys, p.Enable, p.AssemblyName }).Contains(c)).ToList();//有刪除的選單
                            var InsertArr = NewList.Select(p => new { p.MenuStripName, p.MenuStripText, p.ItemIndex, p.CommonItem, p.ShortcutKeys, p.Enable, p.AssemblyName })
                                .Where(c => !OldList.Select(p => new { p.MenuStripName, p.MenuStripText, p.ItemIndex, p.CommonItem, p.ShortcutKeys, p.Enable, p.AssemblyName }).Contains(c)).ToList();//有新增的選單 
                                                                                                                                                                                                      //新增:DeleteArr = 0 InsertArr = N , 刪除:DeleteArr = N InsertArr = 0 , 修改:DeleteArr = N InsertArr =N
                            if (DeleteArr.Count > 0 || InsertArr.Count > 0)
                            {
                                if (OldList.Count > 0)
                                    dbHR.ExecuteCommand("delete MENUSTRIPSTRUCTURE Where MENUGROUPID = {0}", Guid.Empty);
                                dbHR.MenuStripStructure.InsertAllOnSubmit(NewList);
                                dbHR.SubmitChanges();
                            }

                            List<MenuStripStructure> oldAll = new List<MenuStripStructure>();
                            #region 刪除選單功能，移除選單後須調整選單Index
                            foreach (var item in DeleteArr.OrderByDescending(p => p.ItemIndex))//刪除現有符合移除的設定(非Guid.Empty的資料)
                            {
                                var sqlListAll = CodeFunction.GetMenuStripStructures(item.MenuStripName, item.MenuStripText, item.CommonItem, item.AssemblyName, item.Enable, item.ShortcutKeys).ToList();
                                var sqlList = sqlListAll.Where(p => !p.MenuGroupID.Equals(Guid.Empty)).ToList();
                                oldAll.AddRange(sqlList);
                                var DelelteMenus = dbHR.MenuStripStructure.Where(p => p.MenuStripName.Equals(item.MenuStripName) && p.MenuStripText.Equals(item.MenuStripText)
                                                            && p.CommonItem == item.CommonItem && p.Enable == item.Enable
                                                            && (p.AssemblyName.Equals(item.AssemblyName) || (p.AssemblyName == null && item.AssemblyName == null))
                                                            && (p.ShortcutKeys.Equals(item.ShortcutKeys) || (p.ShortcutKeys == null && item.ShortcutKeys == null))
                                                            && !p.MenuGroupID.Equals(Guid.Empty));
                                dbHR.MenuStripStructure.DeleteAllOnSubmit(DelelteMenus);
                                dbHR.SubmitChanges();
                                //dbHR = new HrDBDataContext();
                                foreach (var Delitem in sqlList)
                                {
                                    dbHR.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] - 1 " +
                                        "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", Delitem.MenuGroupID, Delitem.ParentID, Delitem.ItemIndex);
                                }
                            }
                            #endregion

                            #region 新增選單功能，插入選單後須調整選單Index
                            foreach (var item in InsertArr)
                            {
                                dbHR = new HrDBDataContext();
                                var sqlListAll = CodeFunction.GetMenuStripStructures(item.MenuStripName, item.MenuStripText, item.CommonItem, item.AssemblyName, item.Enable, item.ShortcutKeys).ToList();
                                var InsertMenu = sqlListAll.Where(p => p.MenuGroupID.Equals(Guid.Empty)).First();
                                var PreSql = dbHR.MenuStripStructure.Where(p => p.MenuGroupID.Equals(InsertMenu.MenuGroupID) && p.ParentID.Equals(InsertMenu.ParentID));
                                MenuStripStructure PreMenu = PreSql.Where(p => p.ItemIndex == InsertMenu.ItemIndex - 1).FirstOrDefault();
                                var ParentMenu = dbHR.MenuStripStructure.Where(p => p.MenuStripID.Equals(InsertMenu.ParentID)).FirstOrDefault();
                                var MenuGroupIDList = dbHR.MenuGroup.Select(p => p.MenuGroupID);
                                foreach (var MGIDitem in MenuGroupIDList)
                                {
                                    MenuStripStructure new_MenuItem = new MenuStripStructure();
                                    new_MenuItem.MenuGroupID = MGIDitem;
                                    new_MenuItem.MenuStripID = Guid.NewGuid();
                                    new_MenuItem.MenuStripName = InsertMenu.MenuStripName;
                                    new_MenuItem.MenuStripText = InsertMenu.MenuStripText;
                                    new_MenuItem.ParentID = InsertMenu.ParentID;
                                    new_MenuItem.ItemIndex = InsertMenu.ItemIndex;
                                    new_MenuItem.CommonItem = InsertMenu.CommonItem;
                                    new_MenuItem.ShortcutKeys = InsertMenu.ShortcutKeys;
                                    new_MenuItem.Enable = InsertMenu.Enable;
                                    new_MenuItem.AssemblyName = InsertMenu.AssemblyName;
                                    new_MenuItem.Key_Man = InsertMenu.Key_Man;
                                    new_MenuItem.Key_Date = InsertMenu.Key_Date;
                                    if (ParentMenu != null)
                                    {
                                        var MGIDParntMenu = dbHR.MenuStripStructure.Where(p => p.MenuGroupID.Equals(new_MenuItem.MenuGroupID) && p.MenuStripName == ParentMenu.MenuStripName).FirstOrDefault();
                                        if (MGIDParntMenu != null)
                                            new_MenuItem.ParentID = MGIDParntMenu.MenuStripID;
                                        else
                                            continue;
                                    }
                                    if (PreMenu != null)
                                    {
                                        var sql = dbHR.MenuStripStructure.Where(p => p.MenuGroupID.Equals(new_MenuItem.MenuGroupID) && p.ParentID.Equals(new_MenuItem.ParentID));
                                        var PM = sql.Where(p => p.MenuStripName == PreMenu.MenuStripName).FirstOrDefault();
                                        if (PM == null)
                                            new_MenuItem.ItemIndex = sql.Select(p => p.ItemIndex).Max() + 1;
                                        else
                                            new_MenuItem.ItemIndex = PM.ItemIndex + 1;
                                    }

                                    dbHR.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] + 1 " +
                                            "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", new_MenuItem.MenuGroupID, new_MenuItem.ParentID, new_MenuItem.ItemIndex);

                                    var OldMenuStrip = oldAll.Where(p => new_MenuItem.MenuStripName == p.MenuStripName   && new_MenuItem.MenuStripText == p.MenuStripText && new_MenuItem.CommonItem == p.CommonItem && InsertMenu.ShortcutKeys == p.ShortcutKeys
                                      && new_MenuItem.Enable == p.Enable && new_MenuItem.AssemblyName == p.AssemblyName && new_MenuItem.MenuGroupID.Equals(p.MenuGroupID)).FirstOrDefault();

                                    if (OldMenuStrip != null)
                                    {
                                        dbHR.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set PARENTID = {0} " + 
                                            "where [MENUGROUPID] = {1} and [PARENTID] = {2}", new_MenuItem.MenuStripID, new_MenuItem.MenuGroupID, OldMenuStrip.MenuStripID);
                                        new_MenuItem.ItemIndex = OldMenuStrip.ItemIndex;
                                        oldAll.Remove(OldMenuStrip);
                                    }
                                    dbHR.MenuStripStructure.InsertOnSubmit(new_MenuItem);
                                    dbHR.SubmitChanges();
                                }
                            }

                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateApplication();

            #region 複製所有功能選單
            foreach (var sub_MenuItem in this.MainMenuStrip.Items)
            {
                if (sub_MenuItem is ToolStripMenuItem)
                {
                    if ((sub_MenuItem as ToolStripMenuItem).Available)
                    {
                        ToolStripMenuItem new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripMenuItem;
                        if ((sub_MenuItem as ToolStripMenuItem).DropDownItems.Count > 0)
                            Init_menuitem_func(new_MenuItem.DropDownItems, sub_MenuItem as ToolStripMenuItem);
                        totalMenuStrip.Items.Add(new_MenuItem);//視窗開啟後顯示全部Item 
                    }
                }
                else if (sub_MenuItem is ToolStripSeparator)
                {
                    if ((sub_MenuItem as ToolStripSeparator).Available)
                    {
                        ToolStripSeparator new_MenuItem = CreateNewMenuItem(sub_MenuItem) as ToolStripSeparator;
                        totalMenuStrip.Items.Add(CreateNewMenuItem(sub_MenuItem as ToolStripSeparator) as ToolStripSeparator); 
                    }
                }
            }
            #endregion

            #region 權限為Super時不須強制顯示的Menu
            exMenuList.Add("使用者資料ToolStripMenuItem");
            exMenuList.Add("資料群組代碼toolStripMenuItem");
            exMenuList.Add("權限群組設定ToolStripMenuItem");
            exMenuList.Add("使用者權限設定ToolStripMenuItem");
            exMenuList.Add("程式資料設定ToolStripMenuItem");
            exMenuList.Add("資料異動記錄ToolStripMenuItem");
            exMenuList.Add("查詢條件設定toolStripMenuItem");
            exMenuList.Add("系統設定ToolStripMenuItem");
            exMenuList.Add("自定義欄位維護toolStripMenuItem");
            #endregion

            #region 不管權限為何都必須強制顯示的Menu
            cmMenuList.Add("重新登錄ToolStripMenuItem");
            cmMenuList.Add("更改密碼ToolStripMenuItem");
            cmMenuList.Add("版本ToolStripMenuItem");
            cmMenuList.Add("視窗WToolStripMenuItem");
            #endregion

            this.MainMenuStrip.Items.Clear();

            InitialAssemblyList();

            U_LOGIN u_loign = new U_LOGIN();
            u_loign.Owner = this;
            DialogResult ret = u_loign.ShowDialog();

            if (ret == DialogResult.Yes)
            {
                //if (sauFunc.ConnectionString != U_LOGIN.ConnectionString)
                //{
                //    sauFunc = new SqlAutoUpdate(U_LOGIN.ConnectionString);
                //    sauFunc.SqlUpdateCheck(); 
                //}
                InitialCheckFunc();
                check_login(MainForm.USER_ID);
            }
            if (ret == DialogResult.Cancel) this.Close();
            JBModule.Message.TextLog.path = @"C:\Temp\Error";
        }

        private void check_login(string userid)
        {
            MainForm.USER_ID = userid;
            var frm = this as MainForm;
            btnMenuManagement.Enabled = false;
            btnMenuManagement.Visible = false;
            if (frm != null)
            {
                RepoHelper = new JBModule.Data.Repo.RepoHelper();
                var dbHR = new HrDBDataContext();
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
                    btnMenuManagement.Enabled = true;
                    btnMenuManagement.Visible = true;
                }
                else
                {
                    var currentUserData = from a in userData where a.USER_ID == userid select a;
                    var currentUser = currentUserData.First();
                    MainForm.ADMIN = currentUser.ADMIN;
                    MainForm.SUPER = currentUser.SUPER || MainForm.ADMIN;
                    MainForm.SYSTEMRULE = currentUser.MANGSUPER || MainForm.ADMIN;
                    var sql = from a in dbHR.U_USERCOMP 
                              join b in dbHR.COMP on a.COMPANY equals b.COMP1
                              orderby b.Sort,a.COMPANY
                              where a.USER_ID == userid select a;
                    MainForm.UserCompList = sql.ToList();
                }
                foreach (var it in MainForm.UserList)
                    frm.toolStripUserList.DropDownItems.Add(it);
                frm.toolStripCbxCompany.Items.Clear();
                JBControls.ControlConfig.CurrentUser = userid;
                
                if (MainForm.ADMIN)//如果是管理者，就直接可以看到全部公司跟權限
                {
                    MainForm.UserCompList.Clear();
                    var sqlAdmin = from a in dbHR.COMP orderby a.Sort,a.COMP1 select a;
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
            }
            if (userid != "JBADMIN")
            {
                Sys.SysDSTableAdapters.U_USERTableAdapter u_loignTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
                u_loignDataTable = u_loignTableAdapter.GetDataByUSERID(userid);
                if (u_loignDataTable.Count > 0)
                {
                    if (!(u_loignDataTable[0].SUPER || MainForm.ADMIN))
                    {
                        Sys.SysDSTableAdapters.U_PRGIDTableAdapter U_PRGIDTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_PRGIDTableAdapter();
                        U_PRGIDDataTable = U_PRGIDTableAdapter.GetDataByUSERID(userid, SYSTEM);
                    }
                }
                SetRule();
                SetTitle();
                //報表參數
                SetReport();
                JBHR.Reports.NotifyParameter.SetAttendSetting();
            }
            if (frm.toolStripCbxCompany.Items.Count > 0)
            {
                frm.toolStripCbxCompany.SelectedIndex = 0;
                //frm.toolStripCbxCompany_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show("此使帳號無公司群組設定.");
                this.MainMenuStrip.Items.Clear();
            }
        }

        private void SetNewMenuStrip()
        {
            HrDBDataContext db = new HrDBDataContext();
            var sql = db.COMP1.Where(p => p.COMP == MainForm.COMPANY);
            if (sql.Any())
            {
                this.MainMenuStrip.SuspendLayout();
                string COMPANY = MainForm.COMPANY;
                string USERID = MainForm.USER_ID;
                bool ADMIN = MainForm.ADMIN;
                bool SUPER = u_loignDataTable.Count > 0 ? u_loignDataTable[0].SUPER : false;
                bool SYSTEMRULE = MainForm.SYSTEMRULE;
                SysDS.U_PRGIDDataTable u_PRGIDRows = U_PRGIDDataTable;
                this.MainMenuStrip.Items.Clear();
                RefreshMainMenuStrip(COMPANY, USERID, ADMIN, SUPER, SYSTEMRULE, u_PRGIDRows);
                this.MainMenuStrip.Items.Add(this.toolStripCbxCompany);
                this.MainMenuStrip.MdiWindowListItem = MdiWindowListItem;
                this.MainMenuStrip.ResumeLayout();
            }
            else
            {
                MessageBox.Show(string.Format("公司代碼:{0}資料已不存在,請重新登入後在嘗試.", MainForm.COMPANY), "資料不存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    //if (sauFunc.ConnectionString != U_LOGIN.ConnectionString)
                    //{
                    //    sauFunc = new SqlAutoUpdate(U_LOGIN.ConnectionString);
                    //    sauFunc.SqlUpdateCheck();
                    //}
                    InitialCheckFunc();
                    check_login(MainForm.USER_ID);
                }
                if (ret == DialogResult.Cancel) this.Close();
            }
        }

        private MenuStrip RefreshMainMenuStrip(string COMPANY, string USER_ID, bool ADMIN, bool SUPER, bool SYSTEMRULE, SysDS.U_PRGIDDataTable u_PRGIDRows)
        {
            MenuStrip new_MenuStrip = this.menuStrip1;//new MenuStrip();
            HrDBDataContext db = new HrDBDataContext();
            var MenuGroupID = db.COMP1.Where(p => p.COMP == COMPANY).First().MenuGroupID;
            var MSSofMenuGroupID = db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(MenuGroupID)).ToList();
            db = new HrDBDataContext();

            //橫向選單顯示判斷
            foreach (var item in MSSofMenuGroupID.Where(p => p.ParentID.Equals(Guid.Empty)).OrderBy(p => p.ItemIndex))
            {
                if (item.AssemblyName != "ToolStripSeparator")
                {
                    #region 當設定為ToolStripMenuItem時
                    if (item.AssemblyName != null)
                    {
                        #region 當選單有設定開啟頁面時
                        if (item.CommonItem)
                        {
                            #region 當設定為公用選單時
                            ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                            CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);//直向選單顯示判斷
                            new_MenuStrip.Items.Add(new_MenuItem);

                            if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                                new_MenuItem.Enabled = false;
                            #endregion
                        }
                        else if (FormList.ContainsKey(item.AssemblyName.ToUpper()))
                        {
                            #region 選單設定及權限判斷
                            ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                            CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);//直向選單顯示判斷
                            new_MenuStrip.Items.Add(new_MenuItem);
                            if (USER_ID != "JBADMIN")
                            {
                                DataRow row = U_PRGIDDataTable.FindByUSER_IDPROGSYSTEM(USER_ID, FormList[item.AssemblyName.ToUpper()], u_loignDataTable[0].SYSTEM.Trim());

                                if (row == null)
                                    new_MenuItem.Enabled = false;
                            }

                            if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                                new_MenuItem.Enabled = false;

                            if (USER_ID == "JBADMIN" || ADMIN || SUPER || SYSTEMRULE)
                                new_MenuItem.Enabled = true;
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region 當選單無設定開啟頁面時
                        ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                        CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);
                        //if (item.CommonItem || new_MenuItem.DropDownItems.Count != 0 || (new_MenuItem.Tag as MenuItemInfo).AssemblyName != null)
                        new_MenuStrip.Items.Add(new_MenuItem);

                        if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                            new_MenuItem.Enabled = false;
                        #endregion
                    }
                    #endregion
                }
                else if (item.Enable)
                {
                    #region 當設定為ToolStripSeparator時
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(item) as ToolStripSeparator;
                    new_MenuStrip.Items.Add(new_MenuItem);
                    if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                        new_MenuItem.Enabled = false;
                    #endregion
                }
            }
            return new_MenuStrip;
        }
        /// <summary>
        ///    Create ToolStripMenuItem.DropDownItems
        /// </summary>
        private void CreateDropDwonItems(Guid parentID, ToolStripMenuItem parent_MenuItem, List<MenuStripStructure> MSSofMenuGroupID,string USER_ID,bool ADMIN,bool SUPER,bool SYSTEMRULE)
        {
            string DataName = JBHR.Reports.ReportClass.GetDataName();
            foreach (var item in MSSofMenuGroupID.Where(p => p.ParentID.Equals(parentID)).OrderBy(p => p.ItemIndex))
            {
                if (item.AssemblyName != "ToolStripSeparator")
                {
                    #region 當設定為ToolStripMenuItem時
                    if (item.AssemblyName != null)
                    {
                        #region 當選單有設定開啟頁面時
                        if (item.CommonItem)
                        {
                            #region 設定為公用選單時
                            ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                            CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);
                            parent_MenuItem.DropDownItems.Add(new_MenuItem);

                            if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                                new_MenuItem.Enabled = false;
                            #endregion
                        }
                        else if (FormList.ContainsKey(item.AssemblyName.ToUpper()))
                        {
                            #region 選單設定及權限判斷
                            ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                            CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);
                            parent_MenuItem.DropDownItems.Add(new_MenuItem);
                            if (USER_ID != "JBADMIN")
                            {
                                DataRow row = U_PRGIDDataTable.FindByUSER_IDPROGSYSTEM(USER_ID, FormList[item.AssemblyName.ToUpper()], u_loignDataTable[0].SYSTEM.Trim());

                                if (row == null)
                                    new_MenuItem.Enabled = false; 
                            }

                            if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                                new_MenuItem.Enabled = false;

                            if (USER_ID == "JBADMIN" || ADMIN || SUPER || SYSTEMRULE)
                            {
                                if (exMenuList.Contains(item.MenuStripName) && (USER_ID == "JBADMIN" || ADMIN || SYSTEMRULE))//只有super權限須強制不顯示
                                    new_MenuItem.Enabled = true;
                                else if (!exMenuList.Contains(item.MenuStripName) && (USER_ID == "JBADMIN" || ADMIN || SUPER))
                                    new_MenuItem.Enabled = true;
                            }

                            //客製報表顯示
                            if (DataName.ToUpper() != "SINHERHR" && item.MenuStripName == "rBA標準工時表ToolStripMenuItem")
                                new_MenuItem.Visible = false;
                            #endregion
                        }
                       
                        #endregion
                    }
                    else
                    {
                        #region 當選單無設定開啟頁面時
                        ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                        CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID, USER_ID, ADMIN, SUPER, SYSTEMRULE);
                        //if (item.CommonItem || new_MenuItem.DropDownItems.Count != 0 || (new_MenuItem.Tag as MenuItemInfo).AssemblyName != null)
                        parent_MenuItem.DropDownItems.Add(new_MenuItem);

                        if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                            new_MenuItem.Enabled = false;
                        #endregion
                    } 
                    #endregion
                }
                else
                {
                    #region 當設定為ToolStripSeparator時
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(item) as ToolStripSeparator;
                    parent_MenuItem.DropDownItems.Add(new_MenuItem);
                    if (!item.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                        new_MenuItem.Enabled = false; 
                    #endregion
                }
            }
        }
        private object CreateNewMenuItem(MenuStripStructure sub_MenuItem)
        {
            MenuItemInfo MIInfo = new MenuItemInfo();
            MIInfo.MenuGroupID = sub_MenuItem.MenuGroupID;
            MIInfo.MenuStripID = sub_MenuItem.MenuStripID;
            MIInfo.AssemblyName = sub_MenuItem.AssemblyName;
            MIInfo.ParentID = sub_MenuItem.ParentID;
            MIInfo.Index = sub_MenuItem.ItemIndex;
            MIInfo.Enable = sub_MenuItem.Enable;
            MIInfo.CommonItem = sub_MenuItem.CommonItem;
            if (sub_MenuItem.AssemblyName != "ToolStripSeparator")
            {
                #region 初始化ToolStripMenuItem相關設定
                ToolStripMenuItem new_MenuItem = new ToolStripMenuItem();
                new_MenuItem.Font = MenuFont;
                new_MenuItem.Name = sub_MenuItem.MenuStripName;
                new_MenuItem.Text = sub_MenuItem.MenuStripText;
                new_MenuItem.Tag = MIInfo;
                KeysConverter KC = new KeysConverter();
                if (sub_MenuItem.ShortcutKeys != null)
                    new_MenuItem.ShortcutKeys = (Keys)KC.ConvertFromString(sub_MenuItem.ShortcutKeys);
                if (sub_MenuItem.AssemblyName != null && FormList.ContainsKey(sub_MenuItem.AssemblyName.ToUpper()))
                    new_MenuItem.Click += ToolStripMenuItem_Click;
                else if (sub_MenuItem.MenuStripName == "自訂查詢QtoolStripMenuItem")
                {
                    #region 當選單功能為自訂查詢QtoolStripMenuItem時,需依設定產生選單
                    JBControls.Utl.Utlity utl = new JBControls.Utl.Utlity(this);
                    utl.CreateMenu(MainForm.USER_ID, new_MenuItem, "HRM_Query", "", JBControls.Utl.Utlity.QueryFormType.Form);
                    JBControls.FullDataCtrl.UserId = MainForm.USER_ID;
                    JBControls.FullDataCtrl.Admin = MainForm.ADMIN;

                    JBControls.JBQuery.staticParameters.Clear();
                    JBControls.JBQuery.staticParameters.Add("UserId", MainForm.USER_ID);
                    JBControls.JBQuery.staticParameters.Add("Company", MainForm.COMPANY);
                    JBControls.JBQuery.staticParameters.Add("Admin", MainForm.ADMIN ? "1" : "0");

                    JBHRIS.BLL.ContainerManager containerManager = new JBHRIS.BLL.ContainerManager("");
                    var conn = new SqlConnection(JBHR.Properties.Settings.Default.JBHRConnectionString);
                    containerManager.AddConnection(conn);
                    containerManager.AddModule();
                    MainForm.JbContainer = containerManager.GetContainer(); 
                    #endregion
                }
                else if (MainForm.ADMIN && sub_MenuItem.MenuStripName == "自訂查詢設定ToolStripMenuItem")
                {
                    JBControls.Utl.Utlity utl = new JBControls.Utl.Utlity(this);
                    utl.CreateQueryMenu(MainForm.USER_ID, new_MenuItem, "HRM_Query", "", JBControls.Utl.Utlity.QueryFormType.Form);
                }
                else if (sub_MenuItem.MenuStripName == "報表參數ToolStripMenuItem")
                {
                    new_MenuItem.Click += 報表參數ToolStripMenuItem_Click;
                    new_MenuItem.Enabled = false;

                    if (!sub_MenuItem.Enable)//當設定為不啟用時,則關閉功能，但當設定為啟用時，需視系統原生設定為主
                        new_MenuItem.Enabled = false;

                    if (USER_ID == "JBADMIN" || ADMIN || SUPER || SYSTEMRULE)
                    {
                        if (exMenuList.Contains(sub_MenuItem.MenuStripName) && (USER_ID == "JBADMIN" || ADMIN || SYSTEMRULE))//只有super權限須強制不顯示
                            new_MenuItem.Enabled = true;
                        else if (!exMenuList.Contains(sub_MenuItem.MenuStripName) && (USER_ID == "JBADMIN" || ADMIN || SUPER))
                            new_MenuItem.Enabled = true;
                    }
                }
                else if (sub_MenuItem.MenuStripName == "視窗WToolStripMenuItem")
                    MdiWindowListItem = new_MenuItem;
                return new_MenuItem; 
                #endregion
            }
            else
            {
                #region 初始化ToolStripSeparator
                ToolStripSeparator new_MenuItem = new ToolStripSeparator();
                new_MenuItem.Font = MenuFont;
                new_MenuItem.Name = sub_MenuItem.MenuStripName;
                new_MenuItem.Text = sub_MenuItem.MenuStripText;
                new_MenuItem.Tag = MIInfo;
                return new_MenuItem; 
                #endregion
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            MenuItemInfo MIInfo = tsmi.Tag as MenuItemInfo;
            string frmName = FormList[MIInfo.AssemblyName.ToUpper()].ToUpper();
            if (frmName == "U_LOGIN")
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
                    //if (sauFunc.ConnectionString != U_LOGIN.ConnectionString)
                    //{
                    //    sauFunc = new SqlAutoUpdate(U_LOGIN.ConnectionString);
                    //    sauFunc.SqlUpdateCheck();
                    //}
                    InitialCheckFunc();
                    check_login(MainForm.USER_ID);
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
                        if (frmName.Equals(f.Name.ToUpper()))
                        {
                            isOpend = true;
                            f.Focus();
                            break;
                        }
                    }

                    if (!isOpend)
                    {
                        Type ThisFormType = ExTypes[MIInfo.AssemblyName.ToUpper()];

                        dynamic frm = Activator.CreateInstance(ThisFormType);
                        frm.Text = frm.Name + "-" + (sender as ToolStripMenuItem).Text; ;
                        frm.Icon = this.Icon;
                        var member = ThisFormType.BaseType.GetMember("toolStripMenuItem", BindingFlags.Public | BindingFlags.Instance);
                        if (member != null && member.Length > 0)
                            frm.toolStripMenuItem = tsmi;
                        frm.MdiParent = this;
                        frm.Show();
                        //if (ThisFormType.BaseType.Name == "Form")
                        //{
                        //    Form frm = Activator.CreateInstance(ThisFormType) as Form;
                        //    frm.Text = frm.Name + "-" + (sender as ToolStripMenuItem).Text; ;
                        //    frm.Icon = this.Icon;
                        //    frm.MdiParent = this;
                        //    frm.Show();

                        //}
                        //else if (ThisFormType.BaseType.Name == "JBForm")
                        //{
                        //    JBControls.JBForm frm = Activator.CreateInstance(ThisFormType) as JBControls.JBForm;
                        //    frm.Text = frm.Name + "-" + (sender as ToolStripMenuItem).Text; ;
                        //    frm.Icon = this.Icon;
                        //    frm.MdiParent = this;
                        //    frm.toolStripMenuItem = tsmi;
                        //    frm.Show();
                        //}
                        //else if (ThisFormType.BaseType.Name == "U_PATCH")
                        //{
                        //    JBControls.U_PATCH frm = Activator.CreateInstance(ThisFormType) as JBControls.U_PATCH;
                        //    frm.Text = frm.Name + "-" + (sender as ToolStripMenuItem).Text; ;
                        //    frm.Icon = this.Icon;
                        //    frm.MdiParent = this;
                        //    frm.toolStripMenuItem = tsmi;
                        //    frm.Show();
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void toolStripCbxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 切換公司別的動作
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
            JBControls.ControlConfig.CurrentCompany = MainForm.COMPANY;
            MainForm.COMPANY_NAME = toolStripCbxCompany.SelectedItem.ToString();
            MainForm.SetSysConfig(MainForm.COMPANY);

            JBControls.FullDataCtrl.Company = MainForm.COMPANY;
            SetRule();
            SetTitle();
            SetReport();
            var control = this.FindForm().GetNextControl(this, true);
            if (control == null) return;
            while (!control.TabStop)
            {
                control = this.FindForm().GetNextControl(control, true);
                if (control == null) return;//避免null錯誤
            }
            SetNewMenuStrip();
            control.Focus(); 
            #endregion
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
                this.Text = "人事薪資考勤管理系統(" + MainForm.CompanyConfig.COMPANY + ")";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                RunningMode = RunMode.ReleaseMode;
                this.Text += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            else RunningMode = RunMode.DevelopMode;
            if (U_LOGIN.ConnectionName.Trim().Length > 0) this.Text += "(" + U_LOGIN.ConnectionName + ")";
        }
        public enum RunMode
        {
            ReleaseMode,
            DevelopMode,
        }

        private void 報表參數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JBHR.Reports.NotifyParameter.SetAttendSetting();
            ConfigManager frm = new ConfigManager();
            frm.Icon = this.Icon;
            frm.Category = "Report";
            frm.MdiParent = this;
            frm.Show();
        }
        void SetReport()
        {
            JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("Report", MainForm.COMPANY);
            var aa = acg.GetConfig("ReportPercent");
            if (aa.Value == null)
                acg.CheckParameterAndSetDefault("ReportPercent", "報表顯示", "100", "顯示百分比", "TextBox", "", "Int");
        }

        private void btnMenuManagement_ButtonClick(object sender, EventArgs e)
        {
            #region 選單設定按鍵
            Sys.SYS_MenuMgt frm = new Sys.SYS_MenuMgt();
            frm.Icon = this.Icon;
            frm.tempMenuStrip = totalMenuStrip;
            frm.ShowDialog();
            check_login(MainForm.USER_ID); 
            #endregion
        }

        public static List<JBModule.Data.Linq.U_DATAGROUP> ReadSalaryRules
        {
            get
            {
                var qq = from a in AllSalaryRules where a.READRULE select a;
                if (qq.Any())
                {
                    return qq.ToList();
                }
                return new List<JBModule.Data.Linq.U_DATAGROUP>();
            }
        }
        public static List<JBModule.Data.Linq.U_DATAGROUP> AllSalaryRules
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
        public static List<JBModule.Data.Linq.U_DATAGROUP> WriteSalaryRules
        {
            get
            {
                var qq = from a in AllSalaryRules where a.WRITERULE select a;
                if (qq.Any())
                {
                    return qq.ToList();
                }
                return new List<JBModule.Data.Linq.U_DATAGROUP>();
            }
        }
        public static List<string> ReadDataGroups
        {
            get
            {
                var qq = from a in ReadRules where a.COMPANY == MainForm.COMPANY select a.DATAGROUP;
                return qq.ToList();
            }
        }
        public static List<string> WriteDataGroups
        {
            get
            {
                var qq = from a in WriteRules where a.COMPANY == MainForm.COMPANY select a.DATAGROUP;
                return qq.ToList();
            }
        }
        public static List<string> ReadSalaryGroups
        {
            get
            {
                var qq = from a in ReadSalaryRules where a.COMPANY == MainForm.COMPANY select a.DATAGROUP;
                return qq.ToList();
            }
        }
        public static List<string> WriteSalaryGroups
        {
            get
            {
                var qq = from a in WriteSalaryRules where a.COMPANY == MainForm.COMPANY select a.DATAGROUP;
                return qq.ToList();
            }
        }

        private void 通知設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 信件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #region 更新檢查
        bool _updateFlag = false;
        public void UpdateApplication()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
            try
            {
                bool isUpdate = ApplicationDeployment.CurrentDeployment.CheckForUpdate();
                if (isUpdate && (this._updateFlag == false))
                {
                    DialogResult updateResult = MessageBox.Show("線上有新的版本，是否馬上更新版本?", "更新通知", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (updateResult == DialogResult.Yes)
                    {
                        this._updateFlag = true;
                        //this.timer1.Stop();
                        deploy.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(deploy_UpdateProgressChanged);
                        deploy.UpdateCompleted += new AsyncCompletedEventHandler(deploy_UpdateCompleted);
                        deploy.UpdateAsync();
                    }
                    else
                    {
                        //TODO:不馬上通知的動作
                        //this._updateFlag = true;
                        //this.timer1.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗，程式依然可正常運行.");
                JBModule.Message.DbLog.WriteToDB(ex.Message, "更新失敗", "err", this.Name, -1, MainForm.USER_NAME, Guid.NewGuid().ToString());
            }
        }

        void deploy_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //更新完成
            if (MessageBox.Show("更新完畢，是否要重新啟動?", "訊息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Restart();
            buttonRestart.Visible = true;
        }

        void deploy_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            //更新狀態更新
            this.progressBar1.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    UpdateApplication();
        //}
        #endregion

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
