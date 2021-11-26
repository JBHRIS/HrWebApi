using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Tool
{
    public partial class FRM71 : JBControls.JBForm
    {
        public FRM71()
        {
            InitializeComponent();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                JBHR.BLL.Att.Holiday holi = new BLL.Att.Holiday(ptxNobr.Text, DateTime.Now.Date);
                txtTimeB.Text = holi.SpecialLeaveTotalDays.ToString();
                textBox1.Text = holi.UsedSpecialLeaveHours.ToString();
                textBox2.Text = holi.CurrentSpecialLeaveHours.ToString();
            }
        }

        private void FRM71_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
        }
    }
}
