using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM12P : Form
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        string Emp = "";
        public FRM12P(string Nobr, DateTime Adate)
        {
            InitializeComponent();
            txtRoutDate.Text = Adate.ToShortDateString();
            txtOutDate.Text = Adate.ToShortDateString();
            Emp = Nobr;
        }
        private void bnSave_Click(object sender, EventArgs e)
        {
            DateTime outDate = Convert.ToDateTime(txtOutDate.Text);
            DateTime routDate = Convert.ToDateTime(txtRoutDate.Text);
            var inslab = GetInsLabByNobr(Emp);
            var inslabByEmp = inslab.Where(p => p.FA_IDNO.Trim() == "").OrderByDescending(q=>q.IN_DATE).FirstOrDefault();
            if (inslabByEmp == null)
            {
                MessageBox.Show("查無員工勞健保投保資料");
                //this.Close();
                return;
            }
            if (inslabByEmp.CODE != "3" && inslabByEmp.OUT_DATE == new DateTime(9999, 12, 31))
            {

            }
            var lastInslab = (from a in inslab
                              orderby a.FA_IDNO,a.IN_DATE descending
                              select a).GroupBy(p => p.FA_IDNO).Distinct().ToList();

            try
            {
                foreach (var it in lastInslab)
                {
                    var item = it.First();
                    if (item.CODE == "3") continue;
                    if (item.FA_IDNO == "" && item.IN_DATE > outDate)
                    {
                        MessageBox.Show(string.Format("退保日期輸入錯誤，不可小於最後一次異動日期 {0}", item.IN_DATE.ToShortDateString()));
                        return;
                    }
                    item.OUT_DATE = item.IN_DATE > outDate? item.IN_DATE: outDate;
                    item.ROUT_DATE = item.IN_DATE > routDate ? item.IN_DATE : routDate;
                    item.KEY_DATE = DateTime.Now;
                    item.KEY_MAN = MainForm.USER_NAME;
                    item.CODE = "3";
                }
                db.SubmitChanges();
                MessageBox.Show("退保完畢");
            }
            catch (Exception ex)
            {
                MessageBox.Show("退保失敗\n錯誤資訊如下：\n"+ex.Message);
            }
            
            this.Close();
        }
        List<JBModule.Data.Linq.INSLAB> GetInsLabByNobr(string Nobr)
        {
            var sql = from a in db.INSLAB
                      where a.NOBR.Trim() == Nobr.Trim()
                      select a;
            return sql.ToList();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
