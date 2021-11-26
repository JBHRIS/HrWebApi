using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace JBHR.ImportC
{
    abstract class ImportGen
    {

        //protected Att.dcBasDataContext DBDC = new Att.dcBasDataContext();

        //protected Att.dcAttDataContext DADC = new Att.dcAttDataContext();

        protected JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext();

        protected DataSet ds;

        public String FileName;

        private String allPathName;


        public int repeatDataExcel;

        protected object importDT;

        protected DataTable excelDT;

        protected JBHR.Att.FRM2CIS fRM2CIS;

        public String openFile(Control item, String oldPath)
        {
            ComboBox newItem = item as ComboBox;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls;*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //if (!oldPath.Equals(ofd.FileName))
                //{
                    excelDT = null;
                    newItem.SelectedIndex = -1;
                    newItem.Items.Clear();
                //}
                oldPath = ofd.FileName;
                try
                {
                    ds = JBModule.Data.CNPOI.ReadExcelToDataSet(oldPath);
                    foreach (DataTable item1 in ds.Tables)
                    {
                        newItem.Items.Add(item1.TableName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(new Form() { TopMost = true, TopLevel = true },Resources.Sal.ExcelIOError + Environment.NewLine + ex.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            allPathName = oldPath;
            //FileName = ;
            return oldPath;
            
        }

        public void setCBXItem(List<ComboBox> itemList)
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

        public void openPreviewForm(String title, List<int> repeatIndex)
        {
            if (excelDT != null)
            {
                fRM2CIS = new JBHR.Att.FRM2CIS();
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
                //dgvCardView.DataSource = dt;
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true, TopLevel = true },"請選擇資料表", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public DataTable setExcelTable(String tableName)
        {
            if (ds != null)
            {
                excelDT = ds.Tables[tableName];
            }


            FileName = allPathName + tableName;

            return this.excelDT;
        }

        public abstract DataTable ceateRoteChgTable(Dictionary<String, String> dic, ProgressBar PB);

        public abstract int insertRoteChg(DataGridView DGW, ProgressBar PB);

    }
}
