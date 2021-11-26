using JBModule.Data.Dto;
using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class SYS_MultContextMenu : Form
    {
        public SYS_MultContextMenu()
        {
            InitializeComponent();
        }
        public BtnAction BtnActResult { set; get; }
        public MenuStrip tempMenuStrip { set; get; }
        public object ThisMenuItem { set; get; }
        public MenuStripStructure new_MenuItem { set; get; }
        MenuItemInfo MIInfo = new MenuItemInfo();
        int RegionX1 = 0, RegionX2 = 0, RegionY1 = 0, RegionY2 = 0;
        //JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void SYS_MultContextMenu_Load(object sender, EventArgs e)
        {
            RegionX1 = this.Location.X;
            RegionY1 = this.Location.Y;
            RegionX2 = this.Location.X + this.Size.Width;
            RegionY2 = this.Location.Y + this.Size.Height;
            ToolStripMenuItem parentItem = new ToolStripMenuItem();
            MIInfo = new MenuItemInfo();
            if (ThisMenuItem is ToolStripMenuItem)
            {
                parentItem = (ThisMenuItem as ToolStripMenuItem).OwnerItem as ToolStripMenuItem;
                MIInfo = Set_MIInfo((ThisMenuItem as ToolStripMenuItem).Tag as MenuItemInfo);
            }
            else
            {
                parentItem = (ThisMenuItem as ToolStripSeparator).OwnerItem as ToolStripMenuItem;
                MIInfo = Set_MIInfo((ThisMenuItem as ToolStripSeparator).Tag as MenuItemInfo);
            }
            if (parentItem == null)
            {
                btnInsertUp.Enabled = false;
                //btnInsertDown.Enabled = false;
                btnInsertLeft.Enabled = true;
                btnSeparatorUp.Enabled = false;
                btnSeparatorDown.Enabled = false;
                if (MIInfo.AssemblyName == "ToolStripSeparator")
                {
                    btnInsertDown.Enabled = false;
                    btnHideVisible.Enabled = false;
                }
            }
            else
            {
                btnSeparatorLeft.Enabled = false;
                btnSeparatorRight.Enabled = false;
                if (MIInfo.AssemblyName == "ToolStripSeparator")
                {
                    btnInsertRight.Enabled = false;
                    btnHideVisible.Enabled = false;
                }
            }
        }

        private void SYS_MultContextMenu_MouseLeave(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            if (x <= RegionX1 || x >= RegionX2 || y <= RegionY1 || y >= RegionY2)
            {
                BtnActResult = BtnAction.Cancel;
                this.Close();
            }
        }

        private void btnInsertUp_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            BtnActResult = BtnAction.InsertUp;
            this.Close();
        }

        private void btnInsertDown_Click(object sender, EventArgs e)
        {
            if (MIInfo.ParentID.Equals(Guid.Empty))
            {
                MIInfo.ParentID = MIInfo.MenuStripID;
                MIInfo.Index = (ThisMenuItem as ToolStripMenuItem).DropDownItems.Count - 1;
            }
            Create_NewStripItem(MIInfo);
            new_MenuItem.ItemIndex++;
            BtnActResult = BtnAction.InsertDown;
            this.Close();
        }

        private void btnInsertLeft_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            BtnActResult = BtnAction.InsertLeft;
            this.Close();
        }

        private void btnInsertRight_Click(object sender, EventArgs e)
        {
            if (!MIInfo.ParentID.Equals(Guid.Empty))
            {
                MIInfo.ParentID = MIInfo.MenuStripID;
                MIInfo.Index = (ThisMenuItem as ToolStripMenuItem).DropDownItems.Count - 1; 
            }
            Create_NewStripItem(MIInfo);
            new_MenuItem.ItemIndex++;
            BtnActResult = BtnAction.InsertRight;
            this.Close();
        }

        private void btnHideVisible_Click(object sender, EventArgs e)
        {
            ((ThisMenuItem as ToolStripMenuItem).Tag as MenuItemInfo).Enable = !((ThisMenuItem as ToolStripMenuItem).Tag as MenuItemInfo).Enable;
            (ThisMenuItem as ToolStripMenuItem).ForeColor = ((ThisMenuItem as ToolStripMenuItem).Tag as MenuItemInfo).Enable ? Color.Black : Color.Gray;
            HrDBDataContext db = new HrDBDataContext();
            db.ExecuteCommand("Update [MENUSTRIPSTRUCTURE] set [ENABLE] = {0} Where [MENUSTRIPID] = {1};", ((ThisMenuItem as ToolStripMenuItem).Tag as MenuItemInfo).Enable, MIInfo.MenuStripID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要刪除此選單", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                HrDBDataContext db = new HrDBDataContext();
                delete_SubMenuStripStructure(ThisMenuItem);
                db.ExecuteCommand("update [MENUSTRIPSTRUCTURE] set [ItemIndex] = [ItemIndex] - 1 " +
                "where [MENUGROUPID] = {0} and [PARENTID] = {1} and [ItemIndex] >= {2}", MIInfo.MenuGroupID, MIInfo.ParentID, MIInfo.Index);
                BtnActResult = BtnAction.Detele;
                this.Close(); 
            }
        }

        private void btnSeparatorUp_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            new_MenuItem.AssemblyName = "ToolStripSeparator";
            BtnActResult = BtnAction.SeparatorUp;
            this.Close();
        }

        private void btnSeparatorDown_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            new_MenuItem.AssemblyName = "ToolStripSeparator";
            new_MenuItem.ItemIndex++;
            BtnActResult = BtnAction.SeparatorDown;
            this.Close();
        }

        private void btnSeparatorLeft_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            new_MenuItem.AssemblyName = "ToolStripSeparator";
            BtnActResult = BtnAction.SeparatorLeft;
            this.Close();
        }

        private void btnSeparatorRight_Click(object sender, EventArgs e)
        {
            Create_NewStripItem(MIInfo);
            new_MenuItem.AssemblyName = "ToolStripSeparator";
            new_MenuItem.ItemIndex++;
            BtnActResult = BtnAction.SeparatorRight;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            BtnActResult = BtnAction.Cancel;
            this.Close();
        }

        private void Create_NewStripItem(MenuItemInfo MIInfo)
        {
            new_MenuItem = new MenuStripStructure();
            new_MenuItem.MenuGroupID = MIInfo.MenuGroupID;
            new_MenuItem.ParentID = MIInfo.ParentID;
            new_MenuItem.ItemIndex = MIInfo.Index;
            new_MenuItem.MenuStripID = Guid.NewGuid();
            new_MenuItem.Enable = true;
            new_MenuItem.Key_Man = MainForm.USER_ID;
            new_MenuItem.Key_Date = DateTime.Now;
            new_MenuItem.MenuStripName = "";
            new_MenuItem.MenuStripText = "";
            new_MenuItem.CommonItem = false;
        }

        private MenuItemInfo Set_MIInfo(MenuItemInfo Source_MIInfo)
        {
            MenuItemInfo tempMIInfo = new MenuItemInfo();
            tempMIInfo.AssemblyName = Source_MIInfo.AssemblyName;
            tempMIInfo.Index = Source_MIInfo.Index;
            tempMIInfo.MenuGroupID = Source_MIInfo.MenuGroupID;
            tempMIInfo.MenuStripID = Source_MIInfo.MenuStripID;
            tempMIInfo.ParentID = Source_MIInfo.ParentID;
            tempMIInfo.Enable = Source_MIInfo.Enable;
            tempMIInfo.CommonItem = Source_MIInfo.CommonItem;
            return tempMIInfo;
        }

        private void delete_SubMenuStripStructure(object Target_MenuItem)
        {
            MenuItemInfo tempMIInfo;
            if (Target_MenuItem is ToolStripMenuItem)
            {
                tempMIInfo = (Target_MenuItem as ToolStripMenuItem).Tag as MenuItemInfo;
                foreach (var item in (Target_MenuItem as ToolStripMenuItem).DropDownItems)
                    delete_SubMenuStripStructure(item); 
            }
            else
                tempMIInfo = (Target_MenuItem as ToolStripSeparator).Tag as MenuItemInfo;
            HrDBDataContext db = new HrDBDataContext();
            db.ExecuteCommand("Delete [MENUSTRIPSTRUCTURE] Where [MENUSTRIPID] = {0};", tempMIInfo.MenuStripID);
        }
    }
    public enum BtnAction { InsertUp, InsertDown, InsertLeft, InsertRight, SeparatorUp, SeparatorDown, SeparatorLeft, SeparatorRight, Detele, EnOrDisable, MoveUp, MoveDwon, Cancel };
}
