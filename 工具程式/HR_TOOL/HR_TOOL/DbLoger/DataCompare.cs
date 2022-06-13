using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HR_TOOL.DbLoger
{
    public partial class DataCompare : Telerik.WinControls.UI.RadForm
    {
        public DataTable Source1;
        public DataTable Source2;
        public DataCompare()
        {
            InitializeComponent();
        }

        private void DataCompare_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Source1;
            dataGridView2.DataSource = Source2;
            foreach (DataColumn it in Source1.Columns)
            {
                if (Source1.Rows[0][it.ColumnName].ToString() != Source2.Rows[0][it.ColumnName].ToString())
                {
                    var style=new DataGridViewCellStyle();
                    style.BackColor= Color.Red;
                    dataGridView1.Columns[it.ColumnName].DefaultCellStyle = style;
                    dataGridView2.Columns[it.ColumnName].DefaultCellStyle = style;
                }
            }
        }

        private void radGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.HorizontalScrollingOffset = dataGridView1.HorizontalScrollingOffset;
        }
    }
}
