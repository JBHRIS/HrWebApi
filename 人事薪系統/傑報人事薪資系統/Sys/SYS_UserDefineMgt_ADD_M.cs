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
    public partial class SYS_UserDefineMgt_ADD_M : Form
    {
        public SYS_UserDefineMgt_ADD_M()
        {
            InitializeComponent();
        }
        public Guid UserDefineMasterID { set; get; }
        JBModule.Data.Linq.UserDefineMaster instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void SYS_UserDefineMgt_ADD_C_Load(object sender, EventArgs e)
        {
            if (!UserDefineMasterID.Equals(Guid.Empty))
            {
                instance = db.UserDefineMaster.Where(p => p.UserDefineMasterID.Equals(UserDefineMasterID)).FirstOrDefault();
                txtMasterName.Text = instance.UserDefineMasterName;
                txtNote.Text = instance.NOTE;
            }
            else
            {
                txtMasterName.Enabled = true;
                instance = new JBModule.Data.Linq.UserDefineMaster();
                instance.UserDefineMasterID = Guid.NewGuid();
                db.UserDefineMaster.InsertOnSubmit(instance);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            instance.UserDefineMasterName = txtMasterName.Text.ToString().Trim();
            instance.NOTE = txtNote.Text.ToString();
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
