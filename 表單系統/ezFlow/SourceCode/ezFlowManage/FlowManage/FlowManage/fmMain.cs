using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FlowManage
{
    public partial class fmMain : Form
    {
        private ToolStripItem tsi;
        private ToolStripMenuItem WindowsList;

        public fmMain()
        {
            InitializeComponent();

            dsMainTableAdapters.MenuTableAdapter taMenu = new FlowManage.dsMainTableAdapters.MenuTableAdapter();
            dsMain odsMain = new dsMain();
            taMenu.Fill(odsMain.Menu);

            //取得根項目
            var queryResult = (from RootItems in odsMain.Menu
                               where RootItems.sParentCode == ""
                               orderby RootItems.iSort
                               select RootItems);

            foreach (var item in queryResult)
            {
                tsi = muStrip.Items.Add(item.sName);
                tsi.Tag = item.sCode;
                tsi.Name = item.sCode;
                tsi.Click += new EventHandler(MenuItemClicked);
                if (item.sCode == "WindowsList") WindowsList = tsi as ToolStripMenuItem;    //加入已開啟試窗的選項
                AddChildMenuItems(tsi, odsMain.Menu);
            }
        }

        private void AddChildMenuItems(ToolStripItem parent, dsMain.MenuDataTable dt)
        {
            ToolStripMenuItem ParentItem = (ToolStripMenuItem)parent;

            //取得ID準備展出子項目
            string ID = (from menuItem in dt
                         where menuItem.sName == ParentItem.Text
                         select menuItem.sCode).First();

            //取得子項目
            var queryResult = (from menuItem in dt
                               where menuItem.sParentCode == ID
                               orderby menuItem.iSort
                               select menuItem);

            if (queryResult.Count() > 0)
            {
                foreach (var item in queryResult)
                {
                    if (item.sName == "-")  //畫分隔線
                        ParentItem.DropDownItems.Add(item.sName);
                    else
                    {
                        tsi = ParentItem.DropDownItems.Add(item.sName);
                        tsi.Tag = item.sCode;
                        tsi.Name = item.sCode;
                        tsi.Click += new EventHandler(MenuItemClicked);
                        AddChildMenuItems(tsi, dt); //不斷向下展出子項目
                    }
                }
            }
        }

        //自訂事件
        private void MenuItemClicked(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                string ClickedItemText = tsmi.Text;
                //listBox1.Items.Add(ClickedItemText);

                Process p;
                switch (tsmi.Tag.ToString())
                {
                    case "Exit":
                        Application.Exit();
                        break;
                    case "ArrangeIcons":    //縮到最小化
                        this.LayoutMdi(MdiLayout.ArrangeIcons);
                        break;
                    case "Cascade": //重疊顯示
                        this.LayoutMdi(MdiLayout.Cascade);
                        break;
                    case "TileHorizontal":  //垂直對齊
                        this.LayoutMdi(MdiLayout.TileHorizontal);
                        break;
                    case "TileVertical":    //水平對齊
                        this.LayoutMdi(MdiLayout.TileVertical);
                        break;
                    case "Close":   //全部關閉
                        foreach (Form frm in this.MdiChildren)
                            frm.Close();
                        break;
                    case "ezFlow":   //流程編輯
                        //實例一個Process類，啟動一個獨立進程
                        p = new Process();
                        //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
                        p.StartInfo.FileName = "ezFlow.exe";			  //設定程序名
                        //p.StartInfo.Arguments = "/c " + command;	 //設定程式執行參數
                        p.StartInfo.UseShellExecute = false;		  //關閉Shell的使用
                        p.StartInfo.RedirectStandardInput = true;	//重定向標準輸入
                        p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
                        p.StartInfo.RedirectStandardError = true;	//重定向錯誤輸出
                        p.StartInfo.CreateNoWindow = true;			 //設置不顯示窗口
                        p.Start();	//啟動
                        //p.StandardInput.WriteLine(command);		 //也可以用這種方式輸入要執行的命令
                        //p.StandardInput.WriteLine("exit");		  //不過要記得加上Exit要不然下一行程式執行的時候會當機
                        //return p.StandardOutput.ReadToEnd();		  //從輸出流取得命令執行結果
                        break;
                    case "TeamViewer":    //TeamViewer
                        p = new Process();
                        //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
                        p.StartInfo.FileName = "tv/TeamViewer.exe";			  //設定程序名
                        //p.StartInfo.Arguments = "/c " + command;	 //設定程式執行參數
                        p.StartInfo.UseShellExecute = false;		  //關閉Shell的使用
                        p.StartInfo.RedirectStandardInput = true;	//重定向標準輸入
                        p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
                        p.StartInfo.RedirectStandardError = true;	//重定向錯誤輸出
                        p.StartInfo.CreateNoWindow = true;			 //設置不顯示窗口
                        p.Start();	//啟動
                        break;
                    default:    //開啟子畫面
                        try
                        {
                            Form form = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("FlowManage." + tsmi.Tag.ToString(), true) as Form;
                            form.Text = tsmi.Text + "-" + tsmi.Tag;
                            form.Tag = tsmi.Tag;
                            form.MdiParent = this;
                            muStrip.MdiWindowListItem = WindowsList;    //將工作中試窗放入已開畫面的項目
                            form.Show();
                        }
                        catch { }
                        break;
                }
            }
        }

        private void fmMain_MdiChildActivate(object sender, EventArgs e)
        {
            //this.Text = this.ActiveMdiChild;

            foreach (ToolStripMenuItem ddi in this.muStrip.Items)
                if (ddi.Name != "WindowsList")
                    SetMenuItem(ddi);
        }

        private void SetMenuItem(ToolStripItem parent)
        {
            ToolStripMenuItem ParentItem = (ToolStripMenuItem)parent;
            foreach (var ddi in ParentItem.DropDownItems)
            {
                if (ddi.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem tsmi = ddi as ToolStripMenuItem;

                    tsmi.Enabled = true;
                    foreach (var ddiL in WindowsList.DropDownItems)
                    {
                        if (ddiL.GetType() == typeof(ToolStripMenuItem))
                        {
                            ToolStripMenuItem tsmiL = ddiL as ToolStripMenuItem;

                            if (tsmiL.Text.IndexOf(tsmi.Text) >= 0)
                                tsmi.Enabled = false;
                        }
                    }

                    SetMenuItem(tsmi);
                }
            }
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            ((Form)sender).Text += ",DB:" + System.Configuration.ConfigurationManager.AppSettings["DB_NAME"];
        }
    }
}