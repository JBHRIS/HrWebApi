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
    public partial class FRM4JC : Form
    {
        public FRM4JC()
        {
            InitializeComponent();
        }
        string copyStr = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxItemAuto, CodeFunction.GetSalFunction(SelectCalcType), true);
            SystemFunction.SetComboBoxItems(cbxNobr, CodeFunction.GetBase(), true);
            SystemFunction.SetComboBoxItems(cbxCALCTYPE, CodeFunction.GetMtCode("CALC_TYPE"), false);
            SystemFunction.SetComboBoxItems(cbxItemAuto, CodeFunction.GetSalFunction(SelectCalcType), false);
            cbxNobr.SelectedValue = "";
            txtYYMM.Text = DateTime.Today.ToString("yyyyMM");
            cbxCALCTYPE.SelectedIndex = 0;
            cbxItemAuto.SelectedValue = "";
            txtYYMM_Validated(null, null);
            GetScript(SelectCalcType, SelectItemAuto);
            SetGridViewBySalBase();
        }
        void SetGridViewBySalBase()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var dt1 = from a in db.SALBASE
                     where a.CALCTYPE == SelectCalcType
                     select a.SALNAME ;
            var dt2 = from a in db.SALFUNCTION
                      where a.CALCTYPE == SelectCalcType
                      && a.REF select a.ITEM ;
            var dt = dt1.Union(dt2).Select(p => new { 參數值 = "%" + p + "%" });

            dgvSalBase.DataSource = dt;
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            string cont = txtCont.Text;
            object reslut = null;
            
            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
            try
            {
                string Nobr = cbxNobr.SelectedValue.ToString();
                string Yymm = txtYYMM.Text;
                DateTime attDateB = Convert.ToDateTime(txtCalcAttDateB.Text);
                DateTime attDateE = Convert.ToDateTime(txtCalcAttDateE.Text);
                DateTime salDateB = Convert.ToDateTime(txtCalcSalDateB.Text);
                DateTime salDateE = Convert.ToDateTime(txtCalcSalDateE.Text);
                string calcType = cbxCALCTYPE.SelectedValue.ToString();
                JBModule.Data.CalcSalaryByFunction calcSalary = new JBModule.Data.CalcSalaryByFunction();
                var RefDic = calcSalary.GetRefValue(calcType, Nobr, attDateB, attDateE, salDateB, salDateE, Yymm);

                cont = calcSalary.TransString(ref RefDic, txtCont.Text);
                txtDCont.Text = cont;
                reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                // reslut = Microsoft.JScript.Eval.JScriptEvaluate("var out = 'hello';   for ( var x = 1; x < 10; x++) { out = out + 'Line ' + x  + '\\t\\n'; }", Engine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (reslut == null)
            {
                lbAns.Text = "無資料";
            }
            else
            {
                lbAns.Text = reslut.ToString();
            }
        }
        void GetScript(string calcType, string itemAuto)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALFUNCTION
                      where a.AUTO.ToString() == itemAuto
                      && a.CALCTYPE == calcType
                      select a;
            if (sql.Any())
                txtCont.Text = sql.First().SCRIPT.ToString();
            else
                txtCont.Text = "";
        }
        private void btnUpdateScript_Click(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.SALFUNCTION
                          where a.AUTO.ToString() == SelectItemAuto
                          select a;
                if (!sql.Any()) return;
                var firstSql = sql.First();
                firstSql.SCRIPT = txtCont.Text;
                db.SubmitChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReadScript_Click(object sender, EventArgs e)
        {
            GetScript(SelectCalcType, SelectItemAuto);
        }
        string TransString(Dictionary<string, string> refDic, string script)
        {
            string cont = script;
            foreach (var item in refDic)
            {
                cont = cont.Replace(string.Format("{0}", item.Key), item.Value.ToString());
            }
            return cont;
        }
        private Dictionary<string, string> GetRefValue(string CalcType, string Nobr, DateTime attDateB, DateTime attDateE, DateTime salDateB, DateTime salDateE)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlBaseByCalcType = db.SALBASE.Where(p => p.CALCTYPE == CalcType);
            var sqlBaseByBase = from a in db.SALBASD
                                join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                                join c in db.SALBASE on b.SALBASE equals c.AUTO.ToString()
                                where a.NOBR == Nobr
                                && salDateE >= a.ADATE && salDateE <= a.DDATE
                                && c != null
                                select new { KEY = c.SALNAME, VALUE = b.SAL_CODE };

            //參數值
            Dictionary<string, string> Ref = new Dictionary<string, string>();
            //參數轉換為值
            Dictionary<string, string> RefValue = new Dictionary<string, string>();
            //固定取代的運算值
            Dictionary<string, string> Repdic = new Dictionary<string, string>();
            Repdic.Add("{CalcNobr}", Nobr);
            Repdic.Add("{CalcAttDateB}", attDateB.ToShortDateString());
            Repdic.Add("{CalcAttDateE}", attDateE.ToShortDateString());
            Repdic.Add("{CalcSalDateB}", salDateB.ToShortDateString());
            Repdic.Add("{CalcSalDateE}", salDateE.ToShortDateString());
            foreach (var item in sqlBaseByBase)
            {
                Repdic.Add("{" + item.KEY + "}", item.VALUE);
            }

            foreach (var item in sqlBaseByCalcType)
            {//處理參數方法
                string newStr = item.REFFUNCTION;
                foreach (var it in Repdic)
                {
                    newStr = newStr.Replace(it.Key, it.Value);
                }
                newStr = GetSqlQueryValue(db, newStr);
                Ref.Add(string.Format("%{0}%", item.SALNAME), newStr);
            }
            foreach (var item in Ref)
            {
                string value = "";
                value = item.Value.ToString();
                while (value.Contains('%'))
                {
                    foreach (var itt in Ref)
                    {
                        value = value.Replace(itt.Key, string.Format("({0})", itt.Value));
                    }
                }
                value = GetSqlQueryValue(db, value);

                RefValue.Add(item.Key, value);
            }
            return RefValue;
        }
        private string GetSqlQueryValue(JBModule.Data.Linq.HrDBDataContext db, string newStr)
        {
            try { newStr = db.ExecuteQuery<string>(newStr).First().ToString(); }
            catch
            {
                try { newStr = db.ExecuteQuery<decimal>(newStr).First().ToString(); }
                catch
                {
                    try { newStr = db.ExecuteQuery<int>(newStr).First().ToString(); }
                    catch { }
                }
            }
            return newStr;
        }

        private void txtYYMM_Validated(object sender, EventArgs e)
        {
            
        }

        private void cbxCALCTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGridViewBySalBase();
            SystemFunction.SetComboBoxItems(cbxItemAuto, CodeFunction.GetSalFunction(SelectCalcType), true);
            cbxItemAuto.SelectedValue = "";
        }

        private void cbxAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetScript(SelectCalcType, SelectItemAuto);
        }

        private void btnEditSalFunction_Click(object sender, EventArgs e)
        {
            EditSalFunction editSalFunction = new EditSalFunction(cbxCALCTYPE.SelectedValue.ToString());
            editSalFunction.ShowDialog();
            SystemFunction.SetComboBoxItems(cbxItemAuto, CodeFunction.GetSalFunction(SelectCalcType), false);
            SetGridViewBySalBase();
        }

        private void btnCalcAll_Click(object sender, EventArgs e)
        {
            DateTime bdate = DateTime.Now;
            List<string> ckList = new List<string>();
            DataTable dt = GetCalcSalDt();
            if (SelectCalcType == "ATT")
            {
                dt = GetCalcAttDt();
                ckList = new List<string>() { "考勤", "加班" };
            }
            CalcAllItem calcAllItem = new CalcAllItem(dt, ckList);
            calcAllItem.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            calcAllItem.Text += string.Format(" 花費{0}秒", Math.Round((DateTime.Now - bdate).TotalSeconds, 2).ToString());
            calcAllItem.Show();
        }

        private DataTable GetCalcAttDt()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string Nobr = cbxNobr.SelectedValue.ToString();
            DateTime attDateB = Convert.ToDateTime(txtCalcAttDateB.Text);
            DateTime attDateE = Convert.ToDateTime(txtCalcAttDateE.Text);
            DateTime salDateB = Convert.ToDateTime(txtCalcSalDateB.Text);
            DateTime salDateE = Convert.ToDateTime(txtCalcSalDateE.Text);
            string Yymm = txtYYMM.Text;
            string CalcType = cbxCALCTYPE.SelectedValue.ToString();
            JBModule.Data.CalcSalaryByFunction calcSalary = new JBModule.Data.CalcSalaryByFunction();

            var attend = (from a in db.ATTEND
                          join b in db.ROTE on a.ROTE equals b.ROTE1
                          join c in db.ROTE_BONUS on b.ROTE1 equals c.ROTE
                          join d in db.SALFUNCTION on c.SALFUNCTION equals d.AUTO.ToString()
                          where a.ADATE >= attDateB && a.ADATE <= attDateE
                          && a.NOBR == Nobr
                          && (c.CHECK4)
                          orderby a.ADATE
                          select new { a.NOBR, a.ADATE, BTIME = "", ETIME = "", roteBonus = c.AUTO.ToString() }).Distinct();

            //group  new { Nobr = a.NOBR, Bdate = a.ADATE, RoteBonus = c.AUTO.ToString(), 班別代碼 = b.ROTE1, 班別名稱 = b.ROTENAME, 項目 = d.ITEM, 金額 = "", 公式 = d.SCRIPT }
            //by new { a.NOBR, a.ADATE, roteBonus = c.AUTO.ToString()} ;

            var ot = (from a in db.OT
                          join b in db.ROTE on a.OT_ROTE equals b.ROTE1
                          join c in db.ROTE_BONUS on b.ROTE1 equals c.ROTE
                          join d in db.SALFUNCTION on c.SALFUNCTION equals d.AUTO.ToString()
                          where a.BDATE >= attDateB && a.BDATE <= attDateE
                          && a.NOBR == Nobr
                          && (c.CHECK5)
                          orderby a.BDATE
                          select new { a.NOBR, a.BDATE, a.BTIME, a.ETIME, roteBonus = c.AUTO.ToString() }).Distinct();
            
            //var sql = from a in db.SALFUNCTION
            //          where a.CALCTYPE == SelectCalcType && a.CALC
            //          orderby a.SORT
            //          select new { 項目 = a.ITEM, 金額 = "", 公式 = a.SCRIPT };
            DataTable dt = new DataTable();
            dt.Columns.Add("工號");
            dt.Columns.Add("日期");
            dt.Columns.Add("起時");
            dt.Columns.Add("迄時");
            dt.Columns.Add("班別名稱");
            dt.Columns.Add("金額");
            dt.Columns.Add("薪資名稱");
            dt.Columns.Add("考勤", typeof(Boolean));
            dt.Columns.Add("加班", typeof(Boolean));
            dt.Columns.Add("項目");
            dt.Columns.Add("公式");
            
            this.Refresh();
            foreach (var item in attend)
            {
                var calcAtt = calcSalary.GetCalcAttMsg(CalcType, item.NOBR, item.ADATE, item.roteBonus);
                foreach (var calc in calcAtt)
                {
                    var row = dt.NewRow();
                    row["工號"] = calc.Nobr;
                    row["日期"] = calc.Bdate.ToShortDateString();
                    row["起時"] = calc.Btime;
                    row["迄時"] = calc.Etime;
                    row["班別名稱"] = calc.RoteName;
                    row["金額"] = calc.Amt;
                    row["薪資名稱"] = calc.SalName;
                    row["考勤"] = calc.checkAtt;
                    row["加班"] = calc.checkOt;
                    row["項目"] = calc.FunctionName;
                    row["公式"] = calc.Function;
                    dt.Rows.Add(row);
                }
            }
            foreach (var item in ot)
            {
                var calcOt = calcSalary.GetCalcOtMsg(CalcType, item.NOBR, item.BDATE, item.BTIME, item.ETIME, item.roteBonus);
                foreach (var calc in calcOt)
                {
                    var row = dt.NewRow();
                    row["工號"] = calc.Nobr;
                    row["日期"] = calc.Bdate.ToShortDateString();
                    row["起時"] = calc.Btime;
                    row["迄時"] = calc.Etime;
                    row["班別名稱"] = calc.RoteName;
                    row["金額"] = calc.Amt;
                    row["薪資名稱"] = calc.SalName;
                    row["考勤"] = calc.checkAtt;
                    row["加班"] = calc.checkOt;
                    row["項目"] = calc.FunctionName;
                    row["公式"] = calc.Function;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        private DataTable GetCalcSalDt()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string Nobr = cbxNobr.SelectedValue.ToString();
            DateTime attDateB = Convert.ToDateTime(txtCalcAttDateB.Text);
            DateTime attDateE = Convert.ToDateTime(txtCalcAttDateE.Text);
            DateTime salDateB = Convert.ToDateTime(txtCalcSalDateB.Text);
            DateTime salDateE = Convert.ToDateTime(txtCalcSalDateE.Text);
            string Yymm = txtYYMM.Text;
            string CalcType = cbxCALCTYPE.SelectedValue.ToString();
            JBModule.Data.CalcSalaryByFunction calcSalary = new JBModule.Data.CalcSalaryByFunction();

            var sql = from b in db.SALCODE
                      join c in db.SALFUNCTION on b.CAL_TYPE equals c.AUTO.ToString()
                      where c != null
                      && db.GetCodeFilter("SALCODE", b.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      select new { Nobr = "", Salcode = b.SAL_CODE, SalName = b.SAL_NAME, Item = c.ITEM, Amt = "", Function = c.SCRIPT };
            //var sql = from a in db.SALFUNCTION
            //          where a.CALCTYPE == SelectCalcType && a.CALC
            //          orderby a.SORT
            //          select new { 項目 = a.ITEM, 金額 = "", 公式 = a.SCRIPT };
            DataTable dt = new DataTable();
            dt.Columns.Add("工號");
            dt.Columns.Add("薪資代碼");
            dt.Columns.Add("薪資名稱");
            dt.Columns.Add("金額");
            dt.Columns.Add("公式");
            //int num = 0;
            //foreach (var base1 in db.BASE.ToList())
            //{
            //if (num++ > numCalcNum.Value) break;
            //Nobr = base1.NOBR;
            this.Refresh();
            var EmpList = calcSalary.GetCalcSalaryMsg(CalcType, Nobr, Yymm, attDateB, attDateE, salDateB, salDateE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            foreach (var item in EmpList)
            {
                var row = dt.NewRow();
                row["工號"] = Nobr;
                row["薪資代碼"] = item.Salcode;
                row["薪資名稱"] = item.SalName;
                //row["項目"] = item.項目;
                row["金額"] = item.Amt;
                row["公式"] = item.Function;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public string SelectCalcType
        {
            get { return (cbxCALCTYPE.SelectedValue ?? "").ToString(); }
            set { value = (cbxCALCTYPE.SelectedValue ?? "").ToString(); }
        }
        public string SelectItemAuto
        {
            get { return (cbxItemAuto.SelectedValue ?? "").ToString(); }
            set { value = (cbxItemAuto.SelectedValue ?? "").ToString(); }
        }

        private void btnYYMM_Prev_Click(object sender, EventArgs e)
        {
            try
            {
                int yy = Convert.ToInt16(txtYYMM.Text.Substring(0, 4));
                int mm = Convert.ToInt16(txtYYMM.Text.Substring(4, 2));
                txtYYMM.Text = new DateTime(yy, mm, 1).AddMonths(-1).ToString("yyyyMM");
            }
            catch { }
        }

        private void btnYYMM_Next_Click(object sender, EventArgs e)
        {
            try
            {
                int yy = Convert.ToInt16(txtYYMM.Text.Substring(0, 4));
                int mm = Convert.ToInt16(txtYYMM.Text.Substring(4, 2));
                txtYYMM.Text = new DateTime(yy, mm, 1).AddMonths(1).ToString("yyyyMM");
            }
            catch { }
        }

        private void txtYYMM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYYMM.Text.Length != 6)
                {
                    txtYYMM.Focus();
                    return;
                }
                else
                {
                    //int yy = Convert.ToInt16(txtYYMM.Text.Substring(0, 4));
                    //int mm = Convert.ToInt16(txtYYMM.Text.Substring(4, 2));
                    Sal.Core.SalaryDate sd = new Core.SalaryDate(txtYYMM.Text);
                    txtCalcAttDateB.Text = sd.FirstDayOfAttend.ToShortDateString();
                    txtCalcAttDateE.Text = sd.LastDayOfAttend.ToShortDateString();
                    txtCalcSalDateB.Text = sd.FirstDayOfSalary.ToShortDateString();
                    txtCalcSalDateE.Text = sd.LastDayOfSalary.ToShortDateString();
                    cbxCALCTYPE.Focus();
                }
            }
            catch
            {
                txtYYMM.Focus();
                return;
            }
        }

        private void btnCalcType_Prev_Click(object sender, EventArgs e)
        {

            try
            {
                cbxCALCTYPE.SelectedIndex += 1;
            }
            catch { }
        }

        private void btnCalcType_Next_Click(object sender, EventArgs e)
        {

            try
            {
                cbxCALCTYPE.SelectedIndex -= 1;
            }
            catch { }
        }

        private Font SetFontSize(Font font, float addSize)
        {
            var currentSize = font.Size;
            currentSize = currentSize + addSize;
            return new Font(font.FontFamily, currentSize);
        }
        private void btnCont_small_Click(object sender, EventArgs e)
        {
            int addSize = -1;
            int currentSize = Convert.ToInt32(lbFontSize.Text);
            if (currentSize == 1) return;
            lbFontSize.Text = (currentSize + addSize).ToString();
            txtCont.Font = SetFontSize(txtCont.Font, addSize);
            txtDCont.Font = SetFontSize(txtDCont.Font, addSize);
            dgvSalBase.Font = SetFontSize(dgvSalBase.Font, addSize);
        }

        private void btnCont_big_Click(object sender, EventArgs e)
        {
            int addSize = 1;
            lbFontSize.Text = (Convert.ToInt32(lbFontSize.Text) + addSize).ToString();
            txtCont.Font = SetFontSize(txtCont.Font, addSize);
            txtDCont.Font = SetFontSize(txtDCont.Font, addSize);
            dgvSalBase.Font =  SetFontSize(dgvSalBase.Font, addSize);
        }
    }
}
