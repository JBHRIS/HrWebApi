using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class wnStatus : Form
    {
        public int maxProc
        {
            get { return this.progressBar1.Maximum; }
            set { this.progressBar1.Maximum = value; }
        }
        public wnStatus()
        {
            InitializeComponent();
        }
        public void SetMessage(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.Location = new Point((this.Width - lblMsg.Width) / 2, lblMsg.Location.Y);
        }
        public void SetProcess(int procState)
        {
            progressBar1.Value = procState;

        }
    }
}
