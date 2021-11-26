using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBModule.Data.Linq;

namespace JBHR.Att
{
    public partial class FRM2M_CardType : JBControls.JBForm
    {
        public FRM2M_CardType()
        {
            InitializeComponent();
        }
        private void FRM2M_CardType_Load(object sender, EventArgs e)
        {
            JQCardType.SortString = "員工編號 ASC, 刷卡日期 ASC";
        }

        private void JQCardType_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM2M_CardType_ADD frm = new FRM2M_CardType_ADD();
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    JQCardType.Query();
            //}
        }

        private void JQCardType_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM2M_CardType_ADD frm = new FRM2M_CardType_ADD();
            frm.Autokey = Convert.ToInt32(JQCardType.SelectedKey);
            frm.ShowDialog();
            //JQCardType.Query();
        }

        private void JQCardType_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var PrimaryKey = e.PrimaryKey;
            var instance = db.MealCardType.SingleOrDefault(p => p.AutoKey == Convert.ToInt32(PrimaryKey));
            if (!Sal.Function.CanModify(instance.NOBR))
            {
                MessageBox.Show("你沒有刪除該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AutoKey);
            db.MealCardType.DeleteOnSubmit(instance);
            db.SubmitChanges();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            FRM2M_CardType_Trans frm = new FRM2M_CardType_Trans();
            frm.Icon = this.Icon;
            frm.ShowDialog();
            //JQCardType.Query();
        }
    }
}
