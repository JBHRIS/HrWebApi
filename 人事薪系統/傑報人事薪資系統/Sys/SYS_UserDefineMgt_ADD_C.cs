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
    public partial class SYS_UserDefineMgt_ADD_C : Form
    {
        public SYS_UserDefineMgt_ADD_C()
        {
            InitializeComponent();
        }
        public string COMP { set; get; }
        JBModule.Data.Linq.COMP1 instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void SYS_UserDefineMgt_ADD_C_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxMaster, CodeFunction.GetUserDefineMasterID(), true);
            instance = db.COMP1.Where(p => p.COMP == COMP).FirstOrDefault();
            txtCompID.Text = instance.COMP;
            txtCompName.Text = instance.COMPNAME;
            cbxMaster.SelectedValue = instance.UserDefineMasterID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxMaster.SelectedValue.ToString() == "")
                instance.UserDefineMasterID = null;
            else
                instance.UserDefineMasterID = Guid.Parse(cbxMaster.SelectedValue.ToString());
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
