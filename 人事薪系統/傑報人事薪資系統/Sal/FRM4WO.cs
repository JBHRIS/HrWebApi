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
    public partial class FRM4WO : JBControls.JBForm
    {
        public FRM4WO()
        {
            InitializeComponent();
        }

        string WriteOFF = "銷假";

        private void FRM4WO_Load(object sender, EventArgs e)
        {
            //if (JBModule.Data.CEncrypt.Number(1) == 10)
            //{
            //    Application.ExitThread();
            //}
            //else
            //{
                BasDataClassesDataContext db = new BasDataClassesDataContext();
                var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
                if (u_prg != null)
                {
                    btnWriteOff.Enabled = u_prg.EDIT;
                }
                else if (MainForm.ADMIN)
                    btnWriteOff.Enabled = true;
            //}
        }

        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            if (jqAbs.SelectedKey != null)
            {
                HrDBDataContext db = new HrDBDataContext();
                string SelectedKey = jqAbs.SelectedKey.ToString();
                var ABSsql = db.View_AbsWriteOff.Where(p => p.編號 == SelectedKey).FirstOrDefault();
                if (Function.IsAttendLocked(ABSsql.請假日期,ABSsql.員工編號))
                {
                    if ((ABSsql.扣款金額 != null && (ABSsql.扣款金額 == "有" && JBModule.Data.CEncrypt.Number(1) != 10))
                       || ABSsql.扣款金額 == null)
                    {
                        FRM4WO_WriteOff frm = new FRM4WO_WriteOff();
                        frm.ABSGuid = SelectedKey;
                        frm.Icon = this.Icon;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                        if (frm.ShowDialog() == DialogResult.OK)
                            jqAbs.Query();
                    }
                }
                else
                {
                    MessageBox.Show("指定資料出勤尚未鎖檔,建議從原出勤資料做刪除.");
                }
            }
        }

        private void gvAbs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            string SelectedKey = jqAbs.SelectedKey.ToString();
            var ABSsql = db.View_AbsWriteOff.Where(p => p.編號 == SelectedKey).FirstOrDefault();
            if (ABSsql.屬性 == WriteOFF)
                btnWriteOff.Text = "撤銷銷假";
            else
                btnWriteOff.Text = "銷假作業";
        }
    }
}
