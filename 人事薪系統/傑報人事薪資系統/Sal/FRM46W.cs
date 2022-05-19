using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM46W : JBControls.JBForm
    {
        public FRM46W()
        {
            InitializeComponent();
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var dialog = new JBControls.Forms.InputDialog();

            dialog.controlList.Add("申報年月", new TextBox());
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string YYMM = (dialog.controlList["申報年月"] as TextBox).Text;
                if (MessageBox.Show("即將更新選取薪資主檔的申報年月為" + YYMM + "，共計" + jbQuery1.SelectKeys.Count() + "，是否繼續?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (var keys in jbQuery1.SelectKeys)
                    {
                        var dicKeys = keys as Dictionary<string, object>;
                        db.ExecuteCommand("UPDATE WAGE SET FILE_YYMM={0} WHERE YYMM={1} AND SEQ={2} AND NOBR={3}", YYMM, dicKeys["計薪年月"].ToString(), dicKeys["期別"].ToString(), dicKeys["員工編號"].ToString());
                    }
                    MessageBox.Show("更新完成");
                }
            }
        }
    }
}
