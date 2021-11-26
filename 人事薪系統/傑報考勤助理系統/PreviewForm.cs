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
    public partial class PreviewForm : Form
    {
        DataTable dt = new DataTable();
        EnumerableRowCollection ie;
        public string SelectKey = "";
        public PreviewForm()
        {
            InitializeComponent();
        }
        public string Form_Title
        {
            set { this.Text = value; }
        }
        public DataTable DataTable
        {
            set
            {
                dt = value;
                dataGridView1.DataSource = value;
            }
        }
        public EnumerableRowCollection IE
        {
            set { ie = value; }
        }
        private void view_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterParent;
            btnOk.Text += "(" + dataGridView1.Rows.Count + ")";
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SelectKey = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                var cell = dataGridView1.SelectedCells[0];
                SelectKey = dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void view_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dt.DefaultView;

                JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Text + ".xls");
                System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Text + ".xls");
            }
            catch
            {
                MessageBox.Show(Resources.Sal.ExportError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SelectKey = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                var cell = dataGridView1.SelectedCells[0];
                SelectKey = dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
