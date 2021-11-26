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
    public partial class FRM24T  : JBControls.JBForm
    {
        public FRM24T()
        {
            InitializeComponent();
        }

        private void FRM24T_Load(object sender, EventArgs e)
        {
            this.taDEPT.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

            txtNobrB.Text = this.dsBas.BASE.OrderBy(p=>p.NOBR).First().NOBR;
            txtNobrE.Text = this.dsBas.BASE.OrderBy(p => p.NOBR).Last().NOBR;
            txtDeptB.Text = this.dsBas.DEPT.OrderBy(p=>p.D_NO).First().D_NO;
            txtDeptE.Text = this.dsBas.DEPT.OrderBy(p => p.D_NO).Last().D_NO;
            txtDateB.Text = DateTime.Now.ToShortDateString();
            txtDateE.Text = txtDateB.Text;
            txtTime.Text = "10";
            
        }

        private decimal ret(dsBas.DEPTRow row)
        {
            return row.D_NAME.Trim().Length;            
        }

        private bool mywhere(dsBas.DEPTRow row)
        {
            if (row.D_NO.Contains("01")) return true;
            else return false;
        }

        private bool mywhere2(string a, int b)
        {
            return true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {

        }
    }
}
