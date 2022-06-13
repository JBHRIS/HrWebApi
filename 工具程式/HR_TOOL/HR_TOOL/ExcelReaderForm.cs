using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using JBTools.IO;
namespace HR_TOOL
{
    public partial class ExcelReaderForm : Telerik.WinControls.UI.RadForm
    {
        public ExcelReaderForm()
        {
            InitializeComponent();
        }
        NpoiExcelReader reader;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                radTextBox1.Text = ofd.FileName;
                reader = new NpoiExcelReader(ofd.FileName);
                var nameList = reader.ColumnNameList;
                foreach (var it in nameList)
                    radDropDownList1.Items.Add(it);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //reader.ColumnPosition = 0;
            //reader.ColumnNameStyle = LoadExcelColumnNameStyle.ExcelColumnName;
            //var ds = reader.LoadExcelToDataSet();
            var ds = JBModule.Data.CNPOI.ReadExcelToDataSet(radTextBox1.Text);
            radGridView1.DataSource = ds.Tables[0];
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                radTextBox2.Text = sfd.FileName;
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = (radGridView1.DataSource as DataTable).Clone();
            foreach (DataRow r in (radGridView1.DataSource as DataTable).Rows)
                dt.ImportRow(r);
            ds.Tables.Add(dt);
            JBModule.Data.CNPOI.SaveDataSetToExcel(ds, radTextBox2.Text, true);

            JBModule.Data.CNPOI.SetExcelRowState(radTextBox2.Text, ds.Tables[0].TableName, 2, JBModule.Data.CNPOI.ExcelRowState.Error);
        }

    }
}
