using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using JBHR.Att;

namespace JBHR.ImportC.ImportGenObj
{
    abstract class ImportExcel
    {

        public DataSet ds
        {
            get;
            set;
        }

        public DataTable dt
        {
            get;
            set;
        }

        public String openFile()
        {
            string Path = "";

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Path = ofd.FileName;
            }
            return Path;
        }

        public DataSet getTableName(string Path)
        {
            DataSet ds = new DataSet();
            ds = JBModule.Data.CNPOI.ReadExcelToDataSet(Path);
            return ds;
        }

        public void setCBXItem(List<ComboBox> itemList,DataTable excelDT)
        {
            foreach (var item in itemList)
            {
                item.SelectedIndex = -1;
                item.Items.Clear();
            }
            if (excelDT != null)
            {
                foreach (DataColumn item in excelDT.Columns)
                {
                    foreach (ComboBox item1 in itemList)
                    {
                        item1.Items.Add(item.ColumnName);
                    }
                }
            }
        }

        public void openPreviewForm(String title, List<int> repeatIndex, DataTable excelDT)
        {
            if (excelDT != null)
            {
                FRM2CIS fRM2CIS = new FRM2CIS();
                fRM2CIS.setExcel = excelDT;
                if (repeatIndex != null)
                {
                    fRM2CIS.setRepeatIndex = repeatIndex;
                }
                else
                {
                    fRM2CIS.setRepeatIndex = new List<int>();
                }
                fRM2CIS.setTitle = title;
                fRM2CIS.setlbTotal = excelDT.Rows.Count;
                fRM2CIS.ShowDialog();
            }
            else
            {
                MessageBox.Show("請選擇資料表", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public abstract DataTable ceateTable(Dictionary<String, String> dic, ProgressBar PB);

        public abstract int insertDB(DataGridView DGW, ProgressBar PB);

        public abstract int insertAndUpdateDB(DataGridView DGW, ProgressBar PB);

    }
}
