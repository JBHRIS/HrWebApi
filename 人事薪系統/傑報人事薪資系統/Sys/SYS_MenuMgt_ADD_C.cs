using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class SYS_MenuMgt_ADD_C : Form
    {
        public SYS_MenuMgt_ADD_C()
        {
            InitializeComponent();
        }
        public string COMP { set; get; }
        JBModule.Data.Linq.COMP1 instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void SYS_MenuMgt_ADD_C_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbInherit, CodeFunction.GetMenuGroupID(), true);
            instance = db.COMP1.Where(p => p.COMP == COMP).FirstOrDefault();
            txtCompID.Text = instance.COMP;
            txtCompName.Text = instance.COMPNAME;
            cbInherit.SelectedValue = instance.MenuGroupID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbInherit.SelectedValue.ToString() == "")
                instance.MenuGroupID = null;
            else
                instance.MenuGroupID = Guid.Parse(cbInherit.SelectedValue.ToString());
            instance.KEY_DATE = DateTime.Now;
            instance.KEY_MAN = MainForm.USER_ID;
            db.SubmitChanges();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
