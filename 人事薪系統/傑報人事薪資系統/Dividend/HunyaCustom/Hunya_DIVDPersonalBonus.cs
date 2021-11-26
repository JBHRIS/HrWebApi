using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Dividend.HunyaCustom
{
    public partial class Hunya_DIVDPersonalBonus : JBControls.JBForm
    {
        public Hunya_DIVDPersonalBonus()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Hunya_DIVDPersonalBonus_Calculator frm = new Hunya_DIVDPersonalBonus_Calculator();
            frm.ShowDialog();
        }

        private void JQDIVDPersonalBonus_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = (e.PrimaryKey as Dictionary<string, object>);
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_DIVDPersonalBonus.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            if (instance != null)
            {
                if (!Sal.Function.CanModify(instance.EmployeeID))
                {
                    MessageBox.Show(string.Format("你沒有刪除{0}資料的權限", instance.EmployeeID), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_DIVDPersonalBonus.DeleteOnSubmit(instance);
                db.SubmitChanges();
            }
        }
    }
}
