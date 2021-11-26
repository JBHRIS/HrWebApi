using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
namespace JBHR
{
    public partial class QueryForm : JBControls.JBForm
    {
        public QueryForm()
        {
            InitializeComponent();
        }
        public delegate void SelectChangedEvent(object sender, SelectChangedEventArgs e);
        public event SelectChangedEvent SelectChanged;
        public string CurrentSelectValue = "";
        bool NewForm = true;
        private void QueryForm_Load(object sender, EventArgs e)
        {
            if (NewForm)
            {
                Sal.Function.SetAvaliableBase(this.mainDS.V_BASE);
                var deptData = CodeFunction.GetDeptDisp();
                SystemFunction.SetComboBoxItems(dept_b, deptData);
                SystemFunction.SetComboBoxItems(dept_e, deptData);
                nobr_b.Text = this.mainDS.V_BASE.First().NOBR;
                nobr_e.Text = this.mainDS.V_BASE.Last().NOBR;
                dept_b.SelectedValue = deptData.First().Key;
                dept_e.SelectedValue = deptData.Last().Key;
                NewForm = false;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      where a.NOBR.CompareTo(nobr_b.Text) >= 0 && a.NOBR.CompareTo(nobr_e.Text) <= 0
                      && c.D_NO_DISP.CompareTo(dept_b.SelectedValue.ToString()) >= 0 && c.D_NO_DISP.CompareTo(dept_e.SelectedValue.ToString()) <= 0
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && (cbxIncludeLeave.Checked || ttscodeList.Contains(b.TTSCODE))
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 狀態 = ttscodeList.Contains(b.TTSCODE) ? "在職" : "離職", 編制部門 = c.D_NAME, 到職日期 = b.INDT.Value };
            dataGridView1.DataSource = sql;
            this.Text = sql.Count().ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        public class SelectChangedEventArgs : EventArgs
        {
            private string _result;
            public SelectChangedEventArgs(string result)
                : base()
            {
                this._result = result;
            }
            /// <summary>
            /// 狀態內容
            /// </summary>
            public string Result
            {
                get
                {
                    return _result;
                }
            }
        }

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                CurrentSelectValue = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (SelectChanged != null)
                {
                    SelectChangedEventArgs args = new SelectChangedEventArgs(CurrentSelectValue);
                    SelectChanged(sender, args);
                }
            }
        }
    }
}
