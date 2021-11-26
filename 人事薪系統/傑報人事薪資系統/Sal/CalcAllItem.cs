using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class CalcAllItem : Form
    {
        public CalcAllItem(DataTable dt, List<string> checkBoxList)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        private void CalcAllItem_Load(object sender, EventArgs e)
        {

        }
    }
}
