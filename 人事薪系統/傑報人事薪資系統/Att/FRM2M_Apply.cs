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
    public partial class FRM2M_Apply : JBControls.JBForm
    {
        public FRM2M_Apply()
        {
            InitializeComponent();
        }

        private void JQMealApply_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM2M_Apply_ADD frm = new FRM2M_Apply_ADD();
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    JQMealApply.Query();
            //}
        }

        private void JQMealApply_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM2M_Apply_ADD frm = new FRM2M_Apply_ADD();
            frm.Autokey = Convert.ToInt32(JQMealApply.SelectedKey);
            frm.ShowDialog();
            //JQMealApply.Query();
        }

        private void JQMealApply_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var PrimaryKey = e.PrimaryKey;
            var instance = db.MEALAPPLYRECORD.SingleOrDefault(p => p.AUTOKEY == Convert.ToInt32(PrimaryKey));
            if (!Sal.Function.CanModify(instance.NOBR))
            {
                MessageBox.Show("你沒有刪除該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AUTOKEY);
            db.MEALAPPLYRECORD.DeleteOnSubmit(instance);
            db.SubmitChanges();
        }
    }
}
