using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.Linq;
using System.Linq;

namespace HR_TOOL.CodeGroup
{
    public partial class CodeGroupForm : Telerik.WinControls.UI.RadForm
    {
        public CodeGroupForm()
        {
            InitializeComponent();
        }

        private void CodeGroupForm_Load(object sender, EventArgs e)
        {
            var db = new CodeDataDataContext();
            CodeFunction.SetCache();
            SetGridColumn();
            radDropDownList1.Items.Clear();
            foreach (var it in CodeFunction.CodeCache)
            {
                radDropDownList1.Items.Add(it.Key);
            }
            var lstViewData = db.COMP_DATAGROUP.Select(p => p.COMP).Distinct();
            foreach (var it in lstViewData.ToArray())
            {
                radListView1.Items.Add(it);
            }
        }
        void SetGridColumn()
        {
            //radGridView1.Columns.Add("Chk");
            //radGridView1.Columns["Chk"].HeaderText = "";
            //radGridView1.Columns["Chk"]
            //radGridView1.Columns["Chk"].Width = 200;

            radGridView1.Columns.Add("Key");
            radGridView1.Columns["Key"].HeaderText = "代碼";
            radGridView1.Columns["Key"].FieldName = "Key";
            radGridView1.Columns["Key"].Width = 200;

            radGridView1.Columns.Add("Value");
            radGridView1.Columns["Value"].HeaderText = "名稱";
            radGridView1.Columns["Value"].FieldName = "Value";
            radGridView1.Columns["Value"].Width = 200;
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            if (radDropDownList1.Text != null)
            {
                Dictionary<string, string> data = CodeFunction.CodeCache[radDropDownList1.Text.ToString()];
                if (radCheckBox2.Checked)
                {
                    var db = new CodeDataDataContext();
                    var CodeFilterData = (from a in db.CODE_FILTER where a.SOURCE == radDropDownList1.Text select new { a.CODE, a.CODEGROUP }).ToList();
                    data = (from a in data where !CodeFilterData.Where(p => p.CODE == a.Key).Any() select a).ToDictionary(p => p.Key, p => p.Value);
                }
                radGridView1.DataSource = data;
            }
        }

        private void radCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            foreach (var it in radGridView1.Rows)
            {
                it.Cells[0].Value = radCheckBox1.Checked;
            }
        }

        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radCheckBox2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            LoadData();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var db = new CodeDataDataContext();
            var CodeFilterData = (from a in db.CODE_FILTER where a.SOURCE == radDropDownList1.Text select a).ToList();
            List<CODE_FILTER> insertData = new List<CODE_FILTER>();
            List<string> chkList = new List<string>();
            foreach (var it in radListView1.Items)
                if (it.CheckState== Telerik.WinControls.Enumerations.ToggleState.On)
                chkList.Add(it.Text);
            var lstViewData = db.COMP_DATAGROUP.Where(p => chkList.Contains(p.COMP)).Select(p => p.DATAGROUP).Distinct();
            int cc = 0;
            foreach (var it in radGridView1.Rows)
            {
                if (Convert.ToBoolean(it.Cells[0].Value))
                {
                    foreach (var its in lstViewData)
                    {
                        var checkExists = from a in CodeFilterData where a.CODE == it.Cells[1].Value.ToString() && a.CODEGROUP == its select a;
                        if (!checkExists.Any())
                        {
                            CODE_FILTER r = new CODE_FILTER();
                            r.CODE = it.Cells[1].Value.ToString();
                            r.CODEGROUP = its;
                            r.KEY_DATE = DateTime.Now;
                            r.KEY_MAN = "JB";
                            r.NOTE = "";
                            r.SOURCE = radDropDownList1.Text;
                            CodeFilterData.Add(r);
                            insertData.Add(r);
                            cc++;
                        }
                    }
                }
            }
            db.CODE_FILTER.InsertAllOnSubmit(insertData);
            db.SubmitChanges();
            MessageBox.Show("完成，共寫入" + cc.ToString() + "筆");
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("警告，此操作將刪除所有Code_Filter資料表中Source為" + radDropDownList1.Text + "的資料，是否繼續?", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var db = new CodeDataDataContext();
                int i = db.ExecuteCommand("DELETE CODE_FILTER WHERE SOURCE={0}", new object[] { radDropDownList1.Text });
                MessageBox.Show("完成，共刪除" + i.ToString() + "筆");
            }
        }
    }
}
