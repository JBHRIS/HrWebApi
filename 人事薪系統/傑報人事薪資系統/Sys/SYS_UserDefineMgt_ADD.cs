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
    public partial class SYS_UserDefineMgt_ADD : JBControls.JBForm
    {
        public SYS_UserDefineMgt_ADD()
        {
            InitializeComponent();
        }

        public Guid UserDefineGroupID { set; get; }
        public Guid UserDefineMasterID { set; get; }
        JBModule.Data.Linq.UserDefineGroup instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //TableLayoutPanel temptblayout = new TableLayoutPanel();
        List<Control> Ctls = new List<Control>();
        //int ColumnCnt = 5;
        //int RowCnt = 5;
        int ItemsWidth = 100;
        int ItemsHeight = 30;
        Dictionary<string, string> TablelayoutList = new Dictionary<string, string>();
        private void SYS_UserDefineMgt_ADD_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxFromList, MainForm.FormList, true, true, true, true);
            SystemFunction.SetComboBoxItems(cbxTableLayout, TablelayoutList, true, true, true, true);
            if (!UserDefineGroupID.Equals(Guid.Empty))
            {
                instance = db.UserDefineGroup.Where(p => p.UserDefineGroupID.Equals(UserDefineGroupID) && p.UserDefineMasterID.Equals(UserDefineMasterID)).FirstOrDefault();
                txtUDGPName.Text = instance.UserDefineGroupName;
                cbxFromList.SelectedValue = instance.FormName != null ? instance.FormName : string.Empty;
                cbxFromList_SelectionChangeCommitted(sender, e);
                SystemFunction.SetComboBoxItems(cbxTableLayout, TablelayoutList, true, true, true, true);
                cbxTableLayout.SelectedValue = instance.TableLayoutName != null ? instance.TableLayoutName : string.Empty;
                txtNote.Text = instance.Note;
            }
            else
            {
                instance = new JBModule.Data.Linq.UserDefineGroup();
                instance.UserDefineGroupID = Guid.NewGuid();
                instance.UserDefineMasterID = UserDefineMasterID;
                db.UserDefineGroup.InsertOnSubmit(instance);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            instance.UserDefineGroupName = txtUDGPName.Text.ToString().Trim();
            instance.FormName = cbxFromList.SelectedValue.ToString();
            instance.TableLayoutName = cbxTableLayout.SelectedValue.ToString();
            instance.Note = txtNote.Text.ToString();
            instance.Key_Man = MainForm.USER_ID;
            instance.Key_Date = DateTime.Now;
            foreach (Control ctl in Ctls)
            {
                if (string.Format("{0}-{1}", ctl.Parent.Name, ctl.Name) == instance.TableLayoutName)
                {
                    TableLayoutPanel tblayout = ctl as TableLayoutPanel;
                    instance.ColumnCnt = tblayout.ColumnCount;
                    instance.RowCnt = tblayout.RowCount;
                    instance.ItemsWidth = ItemsWidth;
                    instance.ItemsHeight = ItemsHeight;
                    break;
                }
            }
            if (UserDefineGroupID.Equals(Guid.Empty) && db.UserDefineGroup.Where(p => p.UserDefineMasterID.Equals(instance.UserDefineMasterID) && p.FormName == instance.FormName && p.TableLayoutName == instance.TableLayoutName).Any())
            {
                MessageBox.Show("已存在相同的頁面表格設定!", "重複警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.SubmitChanges();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxFromList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TablelayoutList = new Dictionary<string, string>();
            if (cbxFromList.SelectedValue != null && MainForm.ExTypes.ContainsKey(cbxFromList.SelectedValue.ToString()))
            {
                Type ThisFormType = MainForm.ExTypes[cbxFromList.SelectedValue.ToString()];
                Form frm = Activator.CreateInstance(ThisFormType) as Form;
                Ctls = JBTools.Extend.ControlsProcess.GetAllControls(frm);
                foreach (Control ctl in Ctls)
                {
                    if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    {
                        if (ctl.Parent is GroupBox | ctl.Parent is TabControl | ctl.Parent is Panel | ctl.Parent is FlowLayoutPanel | ctl.Parent is TableLayoutPanel)
                            TablelayoutList.Add(string.Format("{0}-{1}", ctl.Parent.Name, ctl.Name), string.Format("{0} - {1}", ctl.Parent.Name, ctl.Name));
                    }
                }
            }
            SystemFunction.SetComboBoxItems(cbxTableLayout, TablelayoutList, true, true, true, true);
        }
    }
}
