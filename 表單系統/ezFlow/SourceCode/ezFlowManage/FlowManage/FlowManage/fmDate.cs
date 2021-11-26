using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlowManage
{
    public partial class fmDate : Form
    {
        public fmDate()
        {
            InitializeComponent();
        }

        private void btnYorN_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            if (dtStart.Value.Date  > dtEnd.Value.Date  && btn.Tag.ToString() == "Yes")
            {
                MessageBox.Show("開始日期不可比結束日期大", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.AccessibleDescription = dtStart.Value.Date.ToString("yyyy/MM/dd 00:00:00") + "# AND adate <= #" + dtEnd.Value.Date.ToString("yyyy/MM/dd 23:59:59");
            this.AccessibleName = dtStart.Value.ToShortDateString() + "至" + dtEnd.Value.ToShortDateString();
            DialogResult = (btn.Tag.ToString() == "Yes") ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
    }
}
