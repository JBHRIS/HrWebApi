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
    public partial class FRM24Q : JBControls.JBForm
    {
        public FRM24Q()
        {
            InitializeComponent();
        }
        public delegate void SelectChangedEvent(object sender, SelectChangedEventArgs e);
        public event SelectChangedEvent SelectChanged;
        public string CurrentSelectValue = "";
        bool NewForm = true;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

        string nobr;

        private void FRM24Q_Load(object sender, EventArgs e)
        {
            if (NewForm)
            {
                Sal.Function.SetAvaliableBase(this.mainDS.V_BASE);
                //var deptData = CodeFunction.GetDept_effe();
                dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
                dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
                dept_e.SelectedIndex = dept_e.Items.Count - 1;

                //SystemFunction.SetComboBoxItems(dept_b, deptData);
                //SystemFunction.SetComboBoxItems(dept_e, deptData);
                nobr_b.Text = this.mainDS.V_BASE.First().NOBR;
                nobr_e.Text = this.mainDS.V_BASE.Last().NOBR;
                //dept_b.SelectedValue = deptData.First().Key;
                //dept_e.SelectedValue = deptData.Last().Key;
                date_b.Text = JBHR.Reports.ReportClass.GetSalBDate(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Month));
                date_e.Text = DateTime.Now.ToString("yyyyMMdd").PadLeft(8, '0');
                NewForm = false;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      join d in db.CARDAPP on a.NOBR equals d.NOBR
                      where a.NOBR.CompareTo(nobr_b.Text) >= 0 && a.NOBR.CompareTo(nobr_e.Text) <= 0
                      && c.D_NO_DISP.CompareTo(dept_b.SelectedValue.ToString()) >= 0 && c.D_NO_DISP.CompareTo(dept_e.SelectedValue.ToString()) <= 0
                      && b.ADATE.Date <= Convert.ToDateTime(date_e.Text).Date && b.DDATE.Value.Date >= Convert.ToDateTime(date_b.Text).Date
                      && b.ADATE == (from f in db.BASETTS where f.NOBR == b.NOBR && ttscodeList.Contains(f.TTSCODE) select f).Max(p => p.ADATE)
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      select new { 編制部門 = c.D_NAME, 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 卡號 = d.CARDNO,  到職日期 = b.INDT.Value };
            dataGridView1.DataSource = sql;

            if (sql.Any())
            {
                nobr = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var sqlCard = from a in db.CARD
                              where a.NOBR == nobr
                              && a.ADATE.Date >= Convert.ToDateTime(date_b.Text).Date && a.ADATE.Date <= Convert.ToDateTime(date_e.Text).Date
                              select new { 員工編號 = a.NOBR, 刷卡日期 = a.ADATE, 刷卡時間 = a.ONTIME, 輸入人員 = a.KEY_MAN, 輸入日期 = a.KEY_DATE };
                dataGridView2.DataSource = sqlCard;
            }
            else
            {
                dataGridView2.Rows.Clear();
                //dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
                 
            this.Text = "查詢共"　+ sql.Count().ToString()　+　"筆資料";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                nobr = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var sqlCard = from a in db.CARD
                              where a.NOBR == nobr
                              && a.ADATE.Date >= Convert.ToDateTime(date_b.Text).Date && a.ADATE.Date <= Convert.ToDateTime(date_e.Text).Date
                              select new { 員工編號 = a.NOBR, 刷卡日期 = a.ADATE, 刷卡時間 = a.ONTIME, 輸入人員 = a.KEY_MAN, 輸入日期 = a.KEY_DATE };
                dataGridView2.DataSource = sqlCard;
            }
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
