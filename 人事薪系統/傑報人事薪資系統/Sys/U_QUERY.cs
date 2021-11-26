using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq;
namespace JBHR.Sys
{
    public partial class U_QUERY : JBControls.JBForm
    {
        public string Source = "";
        public string Code = "";

        public U_QUERY()
        {
            InitializeComponent();
        }

        private void bnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void U_QUERY_Load(object sender, EventArgs e)
        {
            this.cALC_CONDITIONTableAdapter.FillBySourceCode(this.sysDS.CALC_CONDITION, Source, Code);
            this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE, Source);
            cbCriteria.SelectedIndex = 0;
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            if (cbQueryField.SelectedIndex != -1 && txtValue1.Text.Trim().Length > 0)
            {
                //JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var r = sysDS.CALC_CONDITION.NewCALC_CONDITIONRow();
                r.CODE = Code;
                r.COND_TYPE = cbQueryField.SelectedValue.ToString();
                r.CONDITION = cbCriteria.Text;
                r.KEY_DATE = DateTime.Now;
                r.KEY_MAN = MainForm.USER_NAME;
                r.SOURCE = Source;
                r.VALUE1 = txtValue1.Text;
                r.VALUE2 = txtValue1.Text;
                sysDS.CALC_CONDITION.AddCALC_CONDITIONRow(r);
            }
            gridQuery.Rows[gridQuery.Rows.Count - 1].Selected = true;
            txtValue1.Focus();
            txtValue1.SelectAll();
        }
        void RefreshData()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.CALC_CONDITION where a.SOURCE == Source && a.CODE == Code select a;

        }

        private void gridQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridQuery.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                (gridQuery.Rows[e.RowIndex].DataBoundItem as DataRowView).Delete();
            }
        }

        private void bnQuery_Click(object sender, EventArgs e)
        {
            cALC_CONDITIONTableAdapter.Update(sysDS.CALC_CONDITION);
            this.Close();
        }


        private void cbQueryField_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue1.Text = "";

            //if (columnType.ContainsKey(cbQueryField.Text))
            //{
            //    string selected_column_type = columnType[cbQueryField.Text];

            //if (selected_column_type == "System.String")
            //{
            //    txtValue1.ValidType = TextBox.EValidType.String;
            //    txtValue1.Mask = "";
            //    txtValue2.ValidType = TextBox.EValidType.String;
            //    txtValue2.Mask = "";
            //}
            //else if (selected_column_type == "System.DateTime")
            //{
            //    txtValue1.ValidType = TextBox.EValidType.Date;
            //    txtValue1.Text = DateTime.Now.ToString("yyyyMMdd");
            //    txtValue2.ValidType = TextBox.EValidType.Date;
            //    txtValue2.Text = "99991231";
            //}
            //else if (selected_column_type == "System.Boolean")
            //{
            //    txtValue1.ValidType = TextBox.EValidType.Boolean;
            //    txtValue2.ValidType = TextBox.EValidType.Boolean;
            //}
            //else if (selected_column_type == "System.Decimal")
            //{
            //    txtValue1.ValidType = TextBox.EValidType.Decimal;
            //    txtValue2.ValidType = TextBox.EValidType.Decimal;
            //}
            //else
            //{
            //    txtValue1.ValidType = TextBox.EValidType.Integer;
            //    txtValue2.ValidType = TextBox.EValidType.Integer;
            //}
            txtValue1.Focus();
            //}
        }

        private void U_QUERY_Activated(object sender, EventArgs e)
        {
            //if (gridSort.Rows.Count > 0)
            //{
            //    gridSort.Rows[0].Selected = true;
            //    gridSort.Rows[0].Cells[0].Selected = true;
            //}
        }

        private void txtValue2_Enter(object sender, EventArgs e)
        {
            //if (columnType[cbQueryField.Text] == "System.DateTime")
            //{
            //    DateTime DT1 = Convert.ToDateTime(txtValue1.Text);
            //    DateTime DT2;
            //    if (DT1.Day == 1)
            //    {
            //        DT2 = Convert.ToDateTime(DT1.Year.ToString() + "/" + DT1.Month.ToString() + "/" + DateTime.DaysInMonth(DT1.Year, DT1.Month).ToString());
            //    }
            //    else
            //    {
            //        try
            //        {
            //            //DT2 = Convert.ToDateTime(DT1.Year.ToString() + "/" + (DT1.Month + 1).ToString() + "/" + (DT1.Day - 1).ToString());//遇到12月會錯
            //            DT2 = DT1.AddMonths(1).AddDays(-1);
            //        }
            //        catch
            //        {
            //            DT2 = Convert.ToDateTime(DT1.Year.ToString() + "/" + (DT1.Month + 1).ToString() + "/" + DateTime.DaysInMonth(DT1.Year, DT1.Month + 1).ToString());
            //        }
            //    }
            //    txtValue2.Text = DT2.ToString("yyyyMMdd");
            //}
            //else
            //{
            //    txtValue2.Text = txtValue1.Text;
            //}
            //txtValue2.SelectAll();
        }

        private void gridSort_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow it in gridSort.Rows)
            //{
            //    var rr = it.Cells[1] as DataGridViewComboBoxCell;
            //    rr.Value = rr.Items[0];
            //}
        }
    }
}
