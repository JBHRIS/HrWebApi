using JBControls;
using JBModule.Data.Dto;
using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class SYS_MenuMgt : JBForm
    {
        public SYS_MenuMgt()
        {
            InitializeComponent();
        }
        public MenuStrip tempMenuStrip { set; get; }
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        Color OrgColor = new ToolStripMenuItem().BackColor;
        Guid SelectedMenuGroupID = new Guid();

        /// <summary>
        ///    From Load
        /// </summary>
        private void SYS_MenuManagement_Load(object sender, EventArgs e)
        {
            jbQuery1.Query();
            jbQuery2.Query();
        }

        #region 選單細節設定相關功能
        /// <summary>
        ///    Create a New ToolStripMenuItem with Some Initial Parameters.
        /// </summary>
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
                ToolStripMenuItem new_MenuItem = new ToolStripMenuItem();
                new_MenuItem.Name = sub_MenuItem.MenuStripName;
                new_MenuItem.Text = sub_MenuItem.MenuStripText;
                new_MenuItem.Tag = MIInfo;
                KeysConverter KC = new KeysConverter();
                if (sub_MenuItem.ShortcutKeys != null)
                    new_MenuItem.ShortcutKeys = (Keys)KC.ConvertFromString(sub_MenuItem.ShortcutKeys);
                new_MenuItem.ForeColor = MIInfo.Enable ? Color.Black : Color.Gray;
                new_MenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
                new_MenuItem.DoubleClickEnabled = true;
                new_MenuItem.DoubleClick += new EventHandler(this.new_Menuitem_DoubleClick);
                new_MenuItem.MouseDown += new MouseEventHandler(this.new_Menuitem_MouseDown);
                return new_MenuItem;
            }
            else
            {
                ToolStripSeparator new_MenuItem = new ToolStripSeparator();
                new_MenuItem.Name = sub_MenuItem.MenuStripName;
                new_MenuItem.Text = sub_MenuItem.MenuStripText;
                new_MenuItem.Tag = MIInfo;
                new_MenuItem.ForeColor = MIInfo.Enable ? Color.Black : Color.Gray;
                //new_MenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
                //new_MenuItem.DoubleClickEnabled = true;
                //new_MenuItem.DoubleClick += new EventHandler(this.new_Menuitem_DoubleClick);
                new_MenuItem.MouseDown += new MouseEventHandler(this.new_Menuitem_MouseDown);
                return new_MenuItem;
            }
        }
        /// <summary>
        ///    Open the ContextMenu when Mouse RightKey Clicked.
        /// </summary>
        private void new_Menuitem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Guid lastParentID = Guid.Empty;
                SYS_MultContextMenu multContextMenu = new SYS_MultContextMenu();
                #region 呼叫右鍵選單
                if (sender is ToolStripMenuItem)
                {
                    lastParentID = ((sender as ToolStripMenuItem).Tag as MenuItemInfo).ParentID;
                    AutoCloseTurnOFF(sender as ToolStripMenuItem);
                    (sender as ToolStripMenuItem).BackColor = SystemColors.ActiveCaption;
                    multContextMenu.StartPosition = FormStartPosition.Manual;
                    multContextMenu.Location = new Point(Cursor.Position.X - 10, Cursor.Position.Y - 10);
                    multContextMenu.ThisMenuItem = sender;
                    multContextMenu.tempMenuStrip = menuStripSetting;
                    //multContextMenu.TransparencyKey = SystemColors.Control;
                    multContextMenu.ShowDialog();
                    (sender as ToolStripMenuItem).BackColor = OrgColor;
                    AutoCloseTurnON(sender as ToolStripMenuItem);
                }
                else
                {
                    lastParentID = ((sender as ToolStripSeparator).Tag as MenuItemInfo).ParentID;
                    (sender as ToolStripSeparator).BackColor = SystemColors.ActiveCaption;
                    if ((sender as ToolStripSeparator).OwnerItem != null)
                        AutoCloseTurnOFF((sender as ToolStripSeparator).OwnerItem as ToolStripMenuItem);
                    multContextMenu.StartPosition = FormStartPosition.Manual;
                    multContextMenu.Location = new Point(Cursor.Position.X - 10, Cursor.Position.Y - 10);
                    multContextMenu.ThisMenuItem = sender;
                    multContextMenu.tempMenuStrip = menuStripSetting;
                    //multContextMenu.TransparencyKey = SystemColors.Control;
                    multContextMenu.ShowDialog();
                    if ((sender as ToolStripSeparator).OwnerItem != null)
                        AutoCloseTurnON((sender as ToolStripSeparator).OwnerItem as ToolStripMenuItem);
                    (sender as ToolStripSeparator).BackColor = OrgColor;
                } 
                #endregion
                MenuItemInfo MIInfo = new MenuItemInfo();
                ToolStripMenuItem parent_MenuItem = new ToolStripMenuItem();
                ToolStripMenuItem new_MenuItem = new ToolStripMenuItem();
                ToolStripSeparator new_Separator = new ToolStripSeparator();
                #region 判斷選單事件
                switch (multContextMenu.BtnActResult)
                {
                    case BtnAction.InsertUp:
                    case BtnAction.InsertDown:
                    case BtnAction.InsertLeft:
                    case BtnAction.InsertRight:
                        new_MenuItem = CreateNewMenuItem(multContextMenu.new_MenuItem) as ToolStripMenuItem;
                        MIInfo = new_MenuItem.Tag as MenuItemInfo;
                        //var sql = db.MenuStripStructure.Where(p => p.ParentID.Equals(MIInfo.ParentID) && p.ItemIndex >= MIInfo.Index);
                        db.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] + 1 " +
                            "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", MIInfo.MenuGroupID, MIInfo.ParentID, MIInfo.Index);
                        db.MenuStripStructure.InsertOnSubmit(multContextMenu.new_MenuItem);
                        db.SubmitChanges();
                        if (MIInfo.ParentID.Equals(Guid.Empty))
                        {
                            if (multContextMenu.BtnActResult == BtnAction.InsertDown)
                                (sender as ToolStripMenuItem).DropDownItems.Add(new_MenuItem);
                            else
                            {
                                if (menuStripSetting.Items.Count > MIInfo.Index)
                                    menuStripSetting.Items.Insert(MIInfo.Index, new_MenuItem);
                                else
                                    menuStripSetting.Items.Add(new_MenuItem);
                            }
                        }
                        else
                        {
                            if (MIInfo.ParentID.Equals(lastParentID))
                            {
                                if (sender is ToolStripMenuItem)
                                    parent_MenuItem = (sender as ToolStripMenuItem).OwnerItem as ToolStripMenuItem;
                                else
                                    parent_MenuItem = (sender as ToolStripSeparator).OwnerItem as ToolStripMenuItem;
                                parent_MenuItem.ShowDropDown();
                                if (parent_MenuItem.DropDownItems.Count > MIInfo.Index)
                                    parent_MenuItem.DropDownItems.Insert(MIInfo.Index, new_MenuItem);
                                else
                                    parent_MenuItem.DropDownItems.Add(new_MenuItem);
                            }
                            else
                            {
                                parent_MenuItem = (sender as ToolStripMenuItem);
                                parent_MenuItem.ShowDropDown();
                                parent_MenuItem.DropDownItems.Add(new_MenuItem);
                            }
                        }
                        new_Menuitem_DoubleClick(new_MenuItem, new EventArgs());
                        ResetItemIndex(parent_MenuItem);
                        break;
                    case BtnAction.Detele:
                        db.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] - 1 " +
                                    "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", MIInfo.MenuGroupID, MIInfo.ParentID, MIInfo.Index);
                        if (sender is ToolStripMenuItem)
                        {
                            MIInfo = (sender as ToolStripMenuItem).Tag as MenuItemInfo;
                            (sender as ToolStripMenuItem).DropDownItems.Clear();
                            parent_MenuItem = (sender as ToolStripMenuItem).OwnerItem as ToolStripMenuItem;
                        }
                        else
                        {
                            MIInfo = (sender as ToolStripSeparator).Tag as MenuItemInfo;
                            parent_MenuItem = (sender as ToolStripSeparator).OwnerItem as ToolStripMenuItem;
                        }
                        if (parent_MenuItem != null)
                            parent_MenuItem.DropDownItems.RemoveAt(MIInfo.Index);
                        else
                            menuStripSetting.Items.RemoveAt(MIInfo.Index);
                        ResetItemIndex(parent_MenuItem);
                        break;
                    case BtnAction.SeparatorUp:
                    case BtnAction.SeparatorDown:
                    case BtnAction.SeparatorLeft:
                    case BtnAction.SeparatorRight:
                        new_Separator = CreateNewMenuItem(multContextMenu.new_MenuItem) as ToolStripSeparator;
                        MIInfo = new_Separator.Tag as MenuItemInfo;
                        db.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] + 1 " +
                        "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", MIInfo.MenuGroupID, MIInfo.ParentID, MIInfo.Index);
                        db.MenuStripStructure.InsertOnSubmit(multContextMenu.new_MenuItem);
                        db.SubmitChanges();
                        if (MIInfo.ParentID.Equals(Guid.Empty))
                        {
                            if (menuStripSetting.Items.Count > MIInfo.Index)
                                menuStripSetting.Items.Insert(MIInfo.Index, new_Separator);
                            else
                                menuStripSetting.Items.Add(new_Separator);
                        }
                        else
                        {
                            if (sender is ToolStripMenuItem)
                                parent_MenuItem = (sender as ToolStripMenuItem).OwnerItem as ToolStripMenuItem;
                            else
                                parent_MenuItem = (sender as ToolStripSeparator).OwnerItem as ToolStripMenuItem;
                            parent_MenuItem.ShowDropDown();
                            if (parent_MenuItem.DropDownItems.Count > MIInfo.Index)
                                parent_MenuItem.DropDownItems.Insert(MIInfo.Index, new_Separator);
                            else
                                parent_MenuItem.DropDownItems.Add(new_Separator);
                        }
                        ResetItemIndex(parent_MenuItem);
                        break;
                    default:
                        break;
                } 
                #endregion
            }
        }
        /// <summary>
        ///    Open the MenuDetial Form when Mouse Double Clicked.
        /// </summary>
        private void new_Menuitem_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                AutoCloseTurnOFF(sender as ToolStripMenuItem);//停用下拉選單自動關閉功能，防止開啟
                (sender as ToolStripMenuItem).BackColor = SystemColors.ActiveCaption;
                SYS_MuItDetial muItDetial = new SYS_MuItDetial();
                muItDetial.StartPosition = FormStartPosition.Manual;
                muItDetial.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                muItDetial.ThisMenuItem = sender as ToolStripMenuItem;
                muItDetial.ShowDialog();
                (sender as ToolStripMenuItem).BackColor = OrgColor;
                AutoCloseTurnON(sender as ToolStripMenuItem);
            }
            else if (sender is MenuStrip && (sender as MenuStrip).Items.Count == 0)
            {
                MenuStripStructure instance = new MenuStripStructure();
                instance.MenuGroupID = SelectedMenuGroupID;
                instance.MenuStripID = Guid.NewGuid();
                instance.ParentID = Guid.Empty;
                instance.Key_Man = MainForm.USER_ID;
                instance.Key_Date = DateTime.Now;
                instance.Enable = true;
                instance.CommonItem = false;
                instance.MenuStripName = "";
                instance.MenuStripText = "";
                instance.ItemIndex = 0;
                instance.AssemblyName = null;
                instance.ShortcutKeys = null;

                db.MenuStripStructure.InsertOnSubmit(instance);
                db.SubmitChanges();

                ToolStripMenuItem new_MenuItem = CreateNewMenuItem(instance) as ToolStripMenuItem;
                menuStripSetting.Items.Add(new_MenuItem);

                AutoCloseTurnOFF(new_MenuItem);
                new_MenuItem.BackColor = SystemColors.ActiveCaption;
                SYS_MuItDetial muItDetial = new SYS_MuItDetial();
                muItDetial.StartPosition = FormStartPosition.Manual;
                muItDetial.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                muItDetial.ThisMenuItem = new_MenuItem;
                muItDetial.ShowDialog();
                new_MenuItem.BackColor = OrgColor;
                AutoCloseTurnON(new_MenuItem);
            }
        }
        /// <summary>
        ///    Turn ToolStripMenuItem's AutoClose OFF
        /// </summary>
        private void AutoCloseTurnOFF(ToolStripMenuItem targetItem)
        {
            targetItem.DropDown.AutoClose = false;
            if (targetItem.OwnerItem != null)
                AutoCloseTurnOFF(targetItem.OwnerItem as ToolStripMenuItem);
        }
        /// <summary>
        ///        Turn ToolStripMenuItem's AutoClose ON
        /// </summary>
        private void AutoCloseTurnON(ToolStripMenuItem targetItem)
        {
            targetItem.DropDown.AutoClose = true;
            if (targetItem.OwnerItem != null)
                AutoCloseTurnON(targetItem.OwnerItem as ToolStripMenuItem);
        }
        /// <summary>
        ///    Reset ToolStripMenuItem.DropDownItems's Index
        /// </summary>
        private void ResetItemIndex(ToolStripMenuItem Target_MenuItem)
        {
            int index = 0;
            ToolStripItemCollection TSICollenction = menuStripSetting.Items;
            if (Target_MenuItem != null && Target_MenuItem.Tag != null)
                TSICollenction = Target_MenuItem.DropDownItems;
            foreach (var item in TSICollenction)
            {
                if (item is ToolStripMenuItem)
                    ((item as ToolStripMenuItem).Tag as MenuItemInfo).Index = index;
                else
                    ((item as ToolStripSeparator).Tag as MenuItemInfo).Index = index;
                index++;
            }
        }
        /// <summary>
        ///    Avoid Closing that RightKey click ToolStripItem;
        /// </summary>
        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        } 
        #endregion
        #region 選單群組 DataGridView 相關功能
        /// <summary>
        ///    Update the tempMenuStrip When menuGroupDataGridView's seletedKeys Changed.
        /// </summary>
        private void menuGroupDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid SelectedKey = Guid.Parse(jbQuery1.SelectedKey.ToString());
            SelectedMenuGroupID = SelectedKey;
            RefreshMainMenuStrip(SelectedKey);
        }
        /// <summary>
        ///    Refresh the MainMenuStrip
        /// </summary>
        private void RefreshMainMenuStrip(Guid SelectedKey)
        {
            var MSSofMenuGroupID = db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(SelectedKey)).ToList();
            foreach (var item in menuStripSetting.Items)
                if (item is ToolStripMenuItem)
                    (item as ToolStripMenuItem).DropDown.Hide();

            menuStripSetting.SuspendLayout();
            menuStripSetting.Items.Clear();
            db = new JBModule.Data.Linq.HrDBDataContext();
            foreach (var item in MSSofMenuGroupID.Where(p => p.ParentID.Equals(Guid.Empty)).OrderBy(p => p.ItemIndex))
            {
                if (item.AssemblyName != "ToolStripSeparator")
                {
                    ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                    CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID);
                    menuStripSetting.Items.Add(new_MenuItem);
                }
                else
                {
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(item) as ToolStripSeparator;
                    menuStripSetting.Items.Add(new_MenuItem);
                }
            }
            menuStripSetting.ResumeLayout();
        }
        /// <summary>
        ///    Create ToolStripMenuItem.DropDownItems
        /// </summary>
        private void CreateDropDwonItems(Guid parentID, ToolStripMenuItem parent_MenuItem, List<MenuStripStructure> MSSofMenuGroupID)
        {
            foreach (var item in MSSofMenuGroupID.Where(p => p.ParentID.Equals(parentID)).OrderBy(p => p.ItemIndex))
            {
                if (item.AssemblyName != "ToolStripSeparator")
                {
                    ToolStripMenuItem new_MenuItem = CreateNewMenuItem(item) as ToolStripMenuItem;
                    CreateDropDwonItems(item.MenuStripID, new_MenuItem, MSSofMenuGroupID);
                    parent_MenuItem.DropDownItems.Add(new_MenuItem);
                }
                else
                {
                    ToolStripSeparator new_MenuItem = CreateNewMenuItem(item) as ToolStripSeparator;
                    parent_MenuItem.DropDownItems.Add(new_MenuItem);
                }
            }
        }
        /// <summary>
        ///    menuGroupDataGridView's Insert、Update、Delete function 
        /// </summary>
        private void menuGroupDataGridView_RowDelete(object sender, JBQuery.RowDeleteEventArgs e)
        {
            db = new JBModule.Data.Linq.HrDBDataContext();
            var instance = db.MenuGroup.SingleOrDefault(p => p.MenuGroupID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.MenuGroup.DeleteOnSubmit(instance);
            var instance1 = db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(Guid.Parse(e.PrimaryKey.ToString())));
            db.MenuStripStructure.DeleteAllOnSubmit(instance1);
            db.SubmitChanges();
            jbQuery1.Query();
        }
        private void menuGroupDataGridView_RowInsert(object sender, JBQuery.RowInsertEventArgs e)
        {
            SYS_MenuMgt_ADD frm = new SYS_MenuMgt_ADD();
            frm.Icon = this.Icon;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.ShowDialog();
            jbQuery1.Query();
        }
        private void menuGroupDataGridView_RowUpdate(object sender, JBQuery.RowUpdateEventArgs e)
        {
            SYS_MenuMgt_ADD frm = new SYS_MenuMgt_ADD();
            frm.Icon = this.Icon;
            frm.MenuGroupID = Guid.Parse(jbQuery1.SelectedKey.ToString());
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.ShowDialog();
            jbQuery1.Query();
        }
        #endregion
        #region 公司選單 DataGridView 相關功能
        /// <summary>
        ///    CompMenudataGridView's Insert function 
        /// </summary>
        private void jbQuery2_RowInsert(object sender, JBQuery.RowInsertEventArgs e)
        {
            JBHR.Bas.FRM1M frm = new Bas.FRM1M();
            frm.Icon = this.Icon;
            frm.ShowDialog();
            jbQuery2.Query();
            SYS_MenuMgt_ADD_C frm_C = new SYS_MenuMgt_ADD_C();
        }
        /// <summary>
        ///    CompMenudataGridView's Update function 
        /// </summary>
        private void jbQuery2_RowUpdate(object sender, JBQuery.RowUpdateEventArgs e)
        {
            SYS_MenuMgt_ADD_C frm = new SYS_MenuMgt_ADD_C();
            frm.Icon = this.Icon;
            frm.COMP = jbQuery2.SelectedKey.ToString();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.ShowDialog();
            jbQuery2.Query();
        }
        #endregion
    }
}
