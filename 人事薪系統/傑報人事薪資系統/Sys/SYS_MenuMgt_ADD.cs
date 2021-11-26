using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBModule.Data.Linq;

namespace JBHR.Sys
{
    public partial class SYS_MenuMgt_ADD : JBControls.JBForm
    {
        public SYS_MenuMgt_ADD()
        {
            InitializeComponent();
        }

        public Guid MenuGroupID { set; get; }
        JBModule.Data.Linq.MenuGroup instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void SYS_MenuMgt_ADD_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbInherit, CodeFunction.GetMenuGroupID(), true);
            if (!MenuGroupID.Equals(Guid.Empty))
            {
                instance = db.MenuGroup.Where(p => p.MenuGroupID == MenuGroupID).FirstOrDefault();
                txtMUGPName.Text = instance.MenuGroupName;
                lbInherit.Text = "目前選單設定";
                cbInherit.SelectedValue = MenuGroupID.ToString();
                cbInherit.Enabled = false;
                txtNote.Text = instance.Note;
            }
            else
            {
                instance = new JBModule.Data.Linq.MenuGroup();
                instance.MenuGroupID = Guid.NewGuid();
                db.MenuGroup.InsertOnSubmit(instance);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            instance.MenuGroupName = txtMUGPName.Text.ToString().Trim();
            instance.Note = txtNote.Text.ToString();
            instance.Key_Man = MainForm.USER_ID;
            instance.Key_Date = DateTime.Now;
            db.SubmitChanges();

            if (cbInherit.SelectedValue.ToString() != instance.MenuGroupID.ToString())
            {
                var sqlold = db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(instance.MenuGroupID));
                if (sqlold.Any())
                {
                    db.MenuStripStructure.DeleteAllOnSubmit(sqlold);
                    db.SubmitChanges();
                }

                var sqlnew = db.MenuStripStructure.Where(p => p.MenuGroupID.ToString() == cbInherit.SelectedValue.ToString()).ToList();
                //if (!sqlnew.Any())
                //    sqlnew = db.MenuStripStructure.Where(p => p.MenuGroupID.Equals(Guid.Empty)).ToList();

                if (sqlnew.Any())
                {
                    Dictionary<Guid, Guid> ParentIDMapping = new Dictionary<Guid, Guid>();
                    ParentIDMapping.Add(Guid.Empty, Guid.Empty);
                    foreach (var item in sqlnew)
                        ParentIDMapping.Add(item.MenuStripID, Guid.NewGuid());

                    foreach (var item in sqlnew)
                    {
                        MenuStripStructure NewItem = new MenuStripStructure();
                        NewItem.MenuGroupID = instance.MenuGroupID;
                        NewItem.MenuStripID = ParentIDMapping[item.MenuStripID];
                        NewItem.MenuStripName = item.MenuStripName;
                        NewItem.MenuStripText = item.MenuStripText;
                        NewItem.ParentID = ParentIDMapping[item.ParentID];
                        NewItem.Enable = item.Enable;
                        NewItem.ItemIndex = item.ItemIndex;
                        NewItem.AssemblyName = item.AssemblyName;
                        NewItem.ShortcutKeys = item.ShortcutKeys;
                        NewItem.Key_Man = MainForm.USER_ID;
                        NewItem.Key_Date = DateTime.Now;
                        NewItem.CommonItem = item.CommonItem;
                        db.MenuStripStructure.InsertOnSubmit(NewItem);

                        #region 註冊新的程序代碼
                        if (item.AssemblyName != null)
                        {
                            var JBHRForm = item.AssemblyName.Split('.');
                            if (JBHRForm[0] == "JBHR")
                            {
                                string SelectKey = JBHRForm[JBHRForm.Length - 1];
                                var sqlcheck = db.U_PRG.Where(p => p.PROG == SelectKey);
                                if (!sqlcheck.Any())
                                {
                                    JBModule.Data.Linq.U_PRG new_U_PRG = new JBModule.Data.Linq.U_PRG();
                                    new_U_PRG.PROG = SelectKey;
                                    new_U_PRG.PROG_NAME = item.MenuStripText;
                                    new_U_PRG.SYSTEM = JBHRForm[0];
                                    new_U_PRG.ROOT = false;
                                    new_U_PRG.KEY_MAN = MainForm.USER_ID;
                                    new_U_PRG.KEY_DATE = DateTime.Now;
                                    db.U_PRG.InsertOnSubmit(new_U_PRG);
                                }
                            }
                        } 
                        #endregion
                    }
                    db.SubmitChanges(); 
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
