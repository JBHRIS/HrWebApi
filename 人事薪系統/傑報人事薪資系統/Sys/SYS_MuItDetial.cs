using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using JBModule.Data.Dto;

namespace JBHR.Sys
{
    public partial class SYS_MuItDetial : Form
    {
        public SYS_MuItDetial()
        {
            InitializeComponent();
        }
        public ToolStripMenuItem ThisMenuItem = new ToolStripMenuItem();
        Dictionary<string, string> FormList = new Dictionary<string, string>();
        Dictionary<string, Type> ExTypes = new Dictionary<string, Type>();
        private void Sys_MuItDetial_Load(object sender, EventArgs e)
        {
            InitialAssemblyList();
            SystemFunction.SetComboBoxItems(cbFromList, FormList, true, true, true, true);
            txtMenuName.Text = ThisMenuItem.Name;
            txtDspText.Text = ThisMenuItem.Text;
            if ((ThisMenuItem.Tag as MenuItemInfo).AssemblyName != null)
                cbFromList.SelectedValue = (ThisMenuItem.Tag as MenuItemInfo).AssemblyName;
            chbCommon.Checked = (ThisMenuItem.Tag as MenuItemInfo).CommonItem;
        }

        private void InitialAssemblyList()
        {
            var Aseemblys = AppDomain.CurrentDomain.GetAssemblies();
            string MainFunc = System.Diagnostics.Process.GetCurrentProcess().ProcessName; //AppDomain.CurrentDomain.FriendlyName;
            //MainFunc = MainFunc.Remove(MainFunc.IndexOf('.'));
            List<string> ClassList = new List<string>();
            ClassList.Add("JBModule.Message");
            ClassList.Add("JBControls");
            ClassList.Add("JBHR");
            List<string> FormType = new List<string>();
            FormType.Add("Form");
            FormType.Add("JBForm");
            FormType.Add("U_PATCH");
            foreach (var assembly in Aseemblys)
            {
                string AsmName = assembly.GetName().Name;
                if (AsmName == MainFunc || ClassList.Contains(AsmName))
                {
                    var exportedType = assembly.GetExportedTypes();
                    foreach (var item in exportedType)
                    {
                        if (item.BaseType != null && FormType.Contains(item.BaseType.Name) && !FormList.ContainsKey(item.Name))
                        {
                            //FormList.Add(item.Name, item.FullName);
                            //ExTypes.Add(item.Name, item);
                            FormList.Add(item.FullName, item.FullName);
                            ExTypes.Add(item.FullName, item);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuItemInfo menuItemInfo = ThisMenuItem.Tag as MenuItemInfo;
            ThisMenuItem.Name = txtMenuName.Text;
            ThisMenuItem.Text = txtDspText.Text;
            menuItemInfo.AssemblyName = cbFromList.SelectedValue.ToString() != "" ? cbFromList.SelectedValue.ToString() : null;
            ThisMenuItem.Tag = menuItemInfo;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(menuItemInfo.MenuGroupID) && !p.MenuStripID.Equals(menuItemInfo.MenuStripID) && p.MenuStripName == txtMenuName.Text).Any())
            {
                MessageBox.Show("已存在相同的選單名稱.");
                txtMenuName.Focus();
                return;
            }
            var instance = db.MenuStripStructure.Where(p => p.MenuStripID.Equals(menuItemInfo.MenuStripID)).First();
            instance.MenuStripName = ThisMenuItem.Name;
            instance.MenuStripText = ThisMenuItem.Text;
            instance.AssemblyName = menuItemInfo.AssemblyName;
            instance.CommonItem = chbCommon.Checked;
            instance.Key_Man = MainForm.USER_ID;
            instance.Key_Date = DateTime.Now;
            if (instance.AssemblyName != null)
            {
                var JBHRForm = instance.AssemblyName.Split('.');
                if (JBHRForm[0] == "JBHR")
                {
                    string SelectKey = JBHRForm[JBHRForm.Length - 1];
                    var sqlcheck = db.U_PRG.Where(p => p.PROG == SelectKey);
                    if (!sqlcheck.Any())
                    {
                        JBModule.Data.Linq.U_PRG new_U_PRG = new JBModule.Data.Linq.U_PRG();
                        new_U_PRG.PROG = SelectKey;
                        new_U_PRG.PROG_NAME = instance.MenuStripText;
                        new_U_PRG.SYSTEM = JBHRForm[0];
                        new_U_PRG.ROOT = false;
                        new_U_PRG.KEY_MAN = MainForm.USER_ID;
                        new_U_PRG.KEY_DATE = DateTime.Now;
                        db.U_PRG.InsertOnSubmit(new_U_PRG);
                    }
                }
            }
            db.SubmitChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
