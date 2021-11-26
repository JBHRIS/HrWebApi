using JBHR.BLL.Sal;
using JBModule.Data;
using JBModule.Data.Linq;
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
    public partial class FRM4WO_WriteOff : Form
    {
        public FRM4WO_WriteOff()
        {
            InitializeComponent();
        }
        public string ABSGuid { set; get; }
        string WriteOFF = "銷假";
        private void FRM4WO_WriteOff_Load(object sender, EventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            var ABSsql = db.View_AbsWriteOff.Where(p=>p.編號 == ABSGuid).FirstOrDefault();
            if (ABSsql != null)
            {
                this.Text = string.Format("員工:{0} {1}:{2}", ABSsql.員工編號, ABSsql.屬性, ABSsql.請假日期.ToString("yyyy-MM-dd"));
                if (ABSsql.屬性 == WriteOFF)
                    btnSave.Text = string.Format("取消{0}", ABSsql.屬性);
            }
            else
            {
                MessageBox.Show(string.Format("Guid = {0} 並非可進行銷假作業的資料.", ABSGuid));
                this.Close();
                return;
            }

            if (ABSsql.扣款金額 == null || ABSsql.屬性 == WriteOFF)
            {
                txtYymm.Enabled = false;
                txtSeq.Enabled = false;
                txtMemo.Enabled = false;
                ptxSalcode.Enabled = false;
                if (ABSsql.屬性 == WriteOFF)
                {
                    lbDetail.Text = "補扣發明細";
                    var RT = db.RelayTable.Where(p => p.ParentKey == ABSsql.編號 && p.ParentSource == typeof(ABS).Name && p.ChildBSource == typeof(ENRICH).Name);
                    if (RT.Any())
                    {
                        List<JBModule.Data.Linq.ENRICH> enrichList = new List<JBModule.Data.Linq.ENRICH>();
                        foreach (var item in RT)
                        {
                            enrichList.AddRange(db.ENRICH.Where(p => p.AUTOKEY == int.Parse(item.ChildKey)));
                        }
                        dgvSALABS.DataSource = (from el in enrichList
                                                join s in db.SALCODE on el.SAL_CODE equals s.SAL_CODE
                                                select new { 計薪年月 = el.YYMM, 金額 = JBModule.Data.CDecryp.Number(el.AMT), 科目 = s.SAL_NAME, 科目代碼 = s.SAL_CODE_DISP }).CopyToDataTable();
                    } 
                }
            }
            else
            {
                txtMemo.Text = "銷假還款";
                var salabs = from a in db.SALABS
                             join g in db.SALCODE on a.SAL_CODE equals g.SAL_CODE
                             join i in db.SALCODE on a.MLSSALCODE equals i.SAL_CODE
                             where a.NOBR == ABSsql.員工編號 && a.YYMM == ABSsql.計薪年月 && a.ADATE == ABSsql.請假日期
                                    && a.BTIME == ABSsql.請假起 && a.H_CODE == ABSsql.假別代碼
                             select new
                             {
                                 扣薪科目 = g.SAL_NAME,
                                 扣款金額 = JBModule.Data.CDecryp.Number(a.AMT),
                                 扣款科目 = i.SAL_NAME,
                                 扣款代碼 = g.SAL_CODE
                             };
                dgvSALABS.DataSource = salabs.CopyToDataTable();

                SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), false, true, true);
                SalaryDate sd = new SalaryDate(DateTime.Now.Date.ToString("yyyyMM"));
                sd = new SalaryDate(sd.FirstDayOfSalary);
                txtYymm.Text = sd.YYMM;
                txtSeq.Text = "2";
                ptxSalcode.SelectedValue = salabs.First().扣款代碼;
                txtYymm.Focus();
            }
        }

        private void txtYymm_Validated(object sender, EventArgs e)
        {
            try
            {
                SalaryDate sd = new SalaryDate(txtYymm.Text);
                txtSeq.Enabled = true;
                txtSeq.Focus();
            }
            catch
            {
                MessageBox.Show(Resources.Sal.YymmFormatInvalidated, Resources.All.DialogTitle,
                         MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtYymm.Focus();
            }
        }

        private void txtSeq_Validated(object sender, EventArgs e)
        {
            if (Function.IsSalaryLocked(txtYymm.Text, txtSeq.Text, MainForm.WORKADR))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtYymm.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            var ABSsql = db.View_AbsWriteOff.Where(p => p.編號 == ABSGuid).FirstOrDefault();
            if (ABSsql.屬性 != WriteOFF)
            {
                if (MessageBox.Show("是否要進行銷假作業?(如有扣款資料會新增補扣發資料)", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                
                if (ABSsql.扣款金額 != null)
                {
                    if (Function.IsSalaryLocked(txtYymm.Text, txtSeq.Text, MainForm.WORKADR))
                    {
                        MessageBox.Show(string.Format("計薪年月:{0} 期別:{1} 已鎖檔,因無法新增補扣發資料,無法進行銷假作業.", txtYymm.Text, txtSeq.Text));
                        return;
                    }
                    else
                    {
                        var salabs = (from a in db.SALABS
                                     join g in db.SALCODE on a.SAL_CODE equals g.SAL_CODE
                                     join i in db.SALCODE on a.MLSSALCODE equals i.SAL_CODE
                                     where a.NOBR == ABSsql.員工編號 && a.YYMM == ABSsql.計薪年月 && a.ADATE == ABSsql.請假日期
                                            && a.BTIME == ABSsql.請假起 && a.H_CODE == ABSsql.假別代碼
                                     select new
                                     {
                                         扣薪科目 = g.SAL_NAME,
                                         扣款金額 = JBModule.Data.CDecryp.Number(a.AMT),
                                         扣款科目 = i.SAL_NAME,
                                         扣款代碼 = g.SAL_CODE
                                     }).ToList();

                        JBModule.Data.Linq.ENRICH enrich = new JBModule.Data.Linq.ENRICH();
                        enrich.NOBR = ABSsql.員工編號;
                        enrich.YYMM = txtYymm.Text;
                        enrich.SEQ = txtSeq.Text;
                        enrich.SAL_CODE = ptxSalcode.SelectedValue.ToString();
                        var salattr = db.SALATTR.Where(p => p.SALATTR1 == db.SALCODE.Where(q => q.SAL_CODE == enrich.SAL_CODE).FirstOrDefault().SAL_ATTR).FirstOrDefault();
                        if (salattr.FLAG == "-")
                            enrich.AMT = CEncrypt.Number((decimal)salabs.Sum(p => p.扣款金額) * (-1));
                        else
                            enrich.AMT = CEncrypt.Number((decimal)salabs.Sum(p => p.扣款金額));//JBModule.Data.CEncrypt.Number((decimal)ABSsql.扣款金額);
                        enrich.MEMO = txtMemo.Text;// "銷假還款";
                        enrich.IMPORT = true;
                        enrich.FA_IDNO = "";
                        enrich.KEY_DATE = DateTime.Now;
                        enrich.KEY_MAN = MainForm.USER_ID;
                        db.ENRICH.InsertOnSubmit(enrich);
                        db.SubmitChanges();
                        int enPK = enrich.AUTOKEY;

                        RelayTable RT = new RelayTable();
                        RT.ParentKey = ABSsql.編號;
                        RT.ParentSource = typeof(ABS).Name;
                        RT.ChildKey = enPK.ToString();
                        RT.ChildBSource = typeof(ENRICH).Name;
                        RT.CreateDate = DateTime.Now;
                        RT.CreateMan = MainForm.USER_ID;
                        db.RelayTable.InsertOnSubmit(RT);
                        db.SubmitChanges();

                        MessageBox.Show("完成產生銷假還款資料至補扣發."); 
                    }
                }

                var abs = db.ABS.Where(p => p.Guid == ABSGuid).FirstOrDefault();
                JBModule.Data.Linq.ABSC absc = new JBModule.Data.Linq.ABSC();
                absc.Guid = abs.Guid;
                absc.NOBR = abs.NOBR;
                absc.YYMM = abs.YYMM;
                absc.H_CODE = abs.H_CODE;
                absc.BDATE = abs.BDATE;
                absc.EDATE = abs.EDATE;
                absc.BTIME = abs.BTIME;
                absc.ETIME = abs.ETIME;
                absc.TOL_HOURS = abs.TOL_HOURS;
                absc.A_NAME = abs.A_NAME;
                absc.NOTE = abs.NOTE;
                absc.SERNO = abs.SERNO;
                absc.KEY_DATE = DateTime.Now;
                absc.KEY_MAN = MainForm.USER_ID;
                db.ABSC.InsertOnSubmit(absc);
                db.ABS.DeleteOnSubmit(abs);
                db.SubmitChanges();

                //var absd = db.ABSD.Where(p=>p.ABSSUBTRACT == ABSGuid);
                //if (absd.Any())
                //{
                //    db.ABSD.DeleteAllOnSubmit(absd);
                //    db.SubmitChanges();
                //}

                JBHR.Att.FRM28.AutoABSD(absc.NOBR, absc.H_CODE, absc.BDATE, absc.Guid, 0, true);//TOL_HOURS帶入0表示刪除
                MessageBox.Show("完成銷假作業並已完成重新沖假.");
            }
            else
            {
                if (MessageBox.Show("是否要撤銷銷假資料?(如有扣款資料會刪除補扣發資料)", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if (ABSsql.扣款金額 != null)
                {
                    var RT = db.RelayTable.Where(p => p.ParentKey == ABSsql.編號 && p.ParentSource == typeof(ABS).Name && p.ChildBSource == typeof(ENRICH).Name);
                    if (RT.Any())
                    {
                        foreach (var item in RT)
                        {
                            var enrich = db.ENRICH.Where(p => p.AUTOKEY == int.Parse(item.ChildKey)).FirstOrDefault();
                            if (enrich != null)
                            {
                                if (Function.IsSalaryLocked(enrich.YYMM, enrich.SEQ, MainForm.WORKADR))
                                {
                                    MessageBox.Show(string.Format("計薪年月:{0} 期別:{1} 已鎖檔,因無法刪除補扣發資料,無法進行取消銷假作業.", enrich.YYMM, enrich.SEQ));
                                    return;
                                }
                                else
                                    db.ENRICH.DeleteOnSubmit(enrich);
                                //db.SubmitChanges();
                            }
                        }
                        db.RelayTable.DeleteAllOnSubmit(RT);
                        db.SubmitChanges();
                    }
                    MessageBox.Show("完成刪除補扣發還款資料.");
                }

                var absc = db.ABSC.Where(p => p.Guid == ABSGuid).FirstOrDefault();
                JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                abs.Guid = absc.Guid;
                abs.NOBR = absc.NOBR;
                abs.YYMM = absc.YYMM;
                abs.H_CODE = absc.H_CODE;
                abs.BDATE = absc.BDATE;
                abs.EDATE = absc.EDATE;
                abs.BTIME = absc.BTIME;
                abs.ETIME = absc.ETIME;
                abs.TOL_HOURS = absc.TOL_HOURS;
                abs.A_NAME = absc.A_NAME;
                abs.NOTE = absc.NOTE;
                abs.SERNO = absc.SERNO;
                abs.KEY_DATE = DateTime.Now;
                abs.KEY_MAN = MainForm.USER_ID;
                abs.SYSCREATE = false;
                abs.TOL_DAY = 0;
                db.ABS.InsertOnSubmit(abs);
                db.ABSC.DeleteOnSubmit(absc);
                db.SubmitChanges();

                JBHR.Att.FRM28.AutoABSD(abs.NOBR, abs.H_CODE, abs.BDATE, abs.Guid, abs.TOL_HOURS, true);//TOL_HOURS帶入0表示刪除
                MessageBox.Show("已撤銷銷假資料並已完成重新沖假.");
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
