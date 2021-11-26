using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2_DiversionGroup : JBControls.JBForm
    {
        public FRM2_DiversionGroup()
        {
            InitializeComponent();
        }

        private void JQDiversionGroup_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM2_DiversionGroup_ADD frm = new FRM2_DiversionGroup_ADD();
            frm.ShowDialog();
        }

        private void JQDiversionGroup_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM2_DiversionGroup_ADD frm = new FRM2_DiversionGroup_ADD();
            frm.Autokey = Convert.ToInt32(JQDiversionGroup.SelectedKey);
            frm.ShowDialog();
        }

        private void JQDiversionGroup_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var PrimaryKey = e.PrimaryKey;
            var instance = db.DiversionGroup.SingleOrDefault(p => p.AutoKey == Convert.ToInt32(PrimaryKey));
            if (!Sal.Function.CanModify(instance.EmployeeId))
            {
                MessageBox.Show("你沒有刪除該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AutoKey);
            db.DiversionGroup.DeleteOnSubmit(instance);
            db.SubmitChanges();
        }
    }
}
