using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_SETLMS : JBControls.JBForm
    {
        public U_SETLMS()
        {
            InitializeComponent();
        }

        private void U_SETLMS_Load(object sender, EventArgs e)
        {
            this.u_GROUP1TableAdapter.Fill(this.sysDS.U_GROUP1);
            this.u_PRGTableAdapter.Fill(this.sysDS.U_PRG);
            if (MainForm.ADMIN)
                this.u_USERTableAdapter.FillByNOTSUPER(this.sysDS.U_USER, MainForm.SYSTEM);
            else
                this.u_USERTableAdapter.FillByNOTSUPER_WORKADR(this.sysDS.U_USER, MainForm.SYSTEM, MainForm.COMPANY, MainForm.USER_ID);
        }

        private void uUSERBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && uUSERBindingSource.Current != null)
            {
                this.u_PRGIDTableAdapter.FillByUSERID(this.sysDS.U_PRGID, (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString(), MainForm.SYSTEM);
                var userid = (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.U_USER where a.USER_ID == userid select a;
                if (sql.Any())
                {
                    SetChangeRule(CheckChangeRule(userid, sql.First().MANGSUPER, sql.First().ADMIN));
                }
                else
                {
                    SetChangeRule(CheckChangeRule(userid, MainForm.MANGSUPER, MainForm.ADMIN));
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && uUSERBindingSource.Current != null)
            {
                this.u_PRGIDTableAdapter.FillByUSERID(this.sysDS.U_PRGID, (uUSERBindingSource.Current as DataRowView)["USER_ID"].ToString(), MainForm.SYSTEM);

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && uUSERBindingSource.Current != null)
            {
                this.u_PRGIDTableAdapter.FillByPROG(this.sysDS.U_PRGID, (uPRGBindingSource.Current as DataRowView)["PROG"].ToString(), MainForm.SYSTEM);
            }
        }

        private void uPRGBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;


            Sys.SysDS.U_PRGRow U_PRGRow = (uPRGBindingSource.Current as DataRowView).Row as Sys.SysDS.U_PRGRow;

            uPRGIDBindingSource.AddNew();
            (uPRGIDBindingSource.Current as DataRowView).BeginEdit();
            (uPRGIDBindingSource.Current as DataRowView)["USER_ID"] = U_USERRow.USER_ID.Trim();
            (uPRGIDBindingSource.Current as DataRowView)["PROG"] = U_PRGRow.PROG.Trim();
            (uPRGIDBindingSource.Current as DataRowView)["ADD_"] = ckAdd1.Checked;
            (uPRGIDBindingSource.Current as DataRowView)["EDIT"] = ckEdit1.Checked;
            (uPRGIDBindingSource.Current as DataRowView)["DELE"] = ckDel1.Checked;
            (uPRGIDBindingSource.Current as DataRowView)["PRINT_"] = ckExport1.Checked;
            (uPRGIDBindingSource.Current as DataRowView)["SYSTEM"] = U_USERRow.SYSTEM.Trim();
            (uPRGIDBindingSource.Current as DataRowView)["KEY_MAN"] = MainForm.USER_NAME;
            (uPRGIDBindingSource.Current as DataRowView)["KEY_DATE"] = DateTime.Now;
            try
            {
                (uPRGIDBindingSource.Current as DataRowView).EndEdit();

                try
                {
                    var db = new JBModule.Data.Linq.HrDBDataContext();
                    var sql = (from a in db.U_PRG
                               where a.PROG.Contains(U_PRGRow.PROG.Trim() + "-")
                               select a).ToList();
                    var sql1 = (from a in db.U_PRGID
                                where a.PROG.Contains(U_PRGRow.PROG.Trim() + "-")
                                 && a.USER_ID == U_USERRow.USER_ID.Trim()
                                select a).ToList();
                    foreach (var it in sql)
                    {
                        if (sql1.Where(p => p.PROG == it.PROG).Any()) continue;//如果已經有了就不動
                        uPRGIDBindingSource.AddNew();
                        (uPRGIDBindingSource.Current as DataRowView).BeginEdit();
                        (uPRGIDBindingSource.Current as DataRowView)["USER_ID"] = U_USERRow.USER_ID.Trim();
                        (uPRGIDBindingSource.Current as DataRowView)["PROG"] = it.PROG.Trim();
                        (uPRGIDBindingSource.Current as DataRowView)["ADD_"] = ckAdd1.Checked;
                        (uPRGIDBindingSource.Current as DataRowView)["EDIT"] = ckEdit1.Checked;
                        (uPRGIDBindingSource.Current as DataRowView)["DELE"] = ckDel1.Checked;
                        (uPRGIDBindingSource.Current as DataRowView)["PRINT_"] = ckExport1.Checked;
                        (uPRGIDBindingSource.Current as DataRowView)["SYSTEM"] = U_USERRow.SYSTEM.Trim();
                        (uPRGIDBindingSource.Current as DataRowView)["KEY_MAN"] = MainForm.USER_NAME;
                        (uPRGIDBindingSource.Current as DataRowView)["KEY_DATE"] = DateTime.Now;
                        (uPRGIDBindingSource.Current as DataRowView).EndEdit();
                    }
                    CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.U_PRGID);
                    u_PRGIDTableAdapter.Update(sysDS.U_PRGID);

                    ckAdd1.Checked = false;
                    ckEdit1.Checked = false;
                    ckDel1.Checked = false;
                    ckExport1.Checked = false;

                    uPRGIDBindingSource.ResetBindings(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.SaveError + "\n\n" + Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.SaveError + "\n\n" + Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                (uPRGIDBindingSource.Current as DataRowView).CancelEdit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sys.SysDS.U_PRGIDRow U_PRGIDRow = (uPRGIDBindingSource.Current as DataRowView).Row as Sys.SysDS.U_PRGIDRow;

            (uPRGIDBindingSource.Current as DataRowView).BeginEdit();

            U_PRGIDRow.KEY_MAN = MainForm.USER_NAME;
            U_PRGIDRow.KEY_DATE = DateTime.Now;

            (uPRGIDBindingSource.Current as DataRowView).EndEdit();
            try
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.U_PRGID);
                u_PRGIDTableAdapter.Update(sysDS.U_PRGID);

                MessageBox.Show(Resources.All.SaveComplete, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.SaveError + "\n\n" + Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sys.SysDS.U_PRGIDRow U_PRGIDRow = (uPRGIDBindingSource.Current as DataRowView).Row as Sys.SysDS.U_PRGIDRow;

            if (MessageBox.Show(Resources.All.DeleteConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sys.SysDS.U_USERRow U_USERRow = (uUSERBindingSource.Current as DataRowView).Row as Sys.SysDS.U_USERRow;
                var db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.U_PRGID
                           where a.PROG.Contains(U_PRGIDRow.PROG.Trim() + "-")
                            && a.USER_ID == U_USERRow.USER_ID
                           select a).ToList();
                db.U_PRGID.DeleteAllOnSubmit(sql);
                (uPRGIDBindingSource.Current as DataRowView).Delete();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.U_PRGID);
                u_PRGIDTableAdapter.Update(sysDS.U_PRGID);
                db.SubmitChanges();
                uUSERBindingSource_CurrentChanged(null, null);
                if (dataGridViewEx3.CurrentRow != null) dataGridViewEx3.CurrentRow.Selected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (uUSERBindingSource.Current == null)
            {
                MessageBox.Show(Resources.Sys.NoSelectUser, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedValue.Trim() == "")
            {
                MessageBox.Show(Resources.Sys.NoSelectGroup, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow[] U_PRGIDs = sysDS.U_PRGID.Select("user_id = '" + (uUSERBindingSource.Current as DataRowView).Row["user_id"].ToString() + "'");
            SysDS.U_GROUPDataTable U_GROUPDataTable = new SysDSTableAdapters.U_GROUPTableAdapter().GetDataByGROUP_ID(comboBox1.SelectedValue);

            foreach (DataRow row in U_GROUPDataTable.Rows)
            {
                var find_U_PRGIDRow = U_PRGIDs.FirstOrDefault(u_prgid => u_prgid["prog"].ToString().Trim().ToLower() == row["prog"].ToString().Trim().ToLower());
                if (find_U_PRGIDRow == null)
                {
                    SysDS.U_PRGIDRow U_PRGIDRow = sysDS.U_PRGID.NewU_PRGIDRow();
                    U_PRGIDRow.USER_ID = (uUSERBindingSource.Current as DataRowView).Row["user_id"].ToString();
                    U_PRGIDRow.PROG = row["prog"].ToString();
                    U_PRGIDRow.ADD_ = Convert.ToBoolean(row["add_"]);
                    U_PRGIDRow.EDIT = Convert.ToBoolean(row["edit"]);
                    U_PRGIDRow.DELE = Convert.ToBoolean(row["dele"]);
                    U_PRGIDRow.PRINT_ = Convert.ToBoolean(row["print_"]);
                    U_PRGIDRow.SYSTEM = row["system"].ToString();
                    U_PRGIDRow.KEY_MAN = MainForm.USER_NAME;
                    U_PRGIDRow.KEY_DATE = DateTime.Now;
                    sysDS.U_PRGID.AddU_PRGIDRow(U_PRGIDRow);
                }
            }

            u_PRGIDTableAdapter.Update(sysDS.U_PRGID);
        }

        private void dataGridViewEx2_SelectionChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                this.u_PRGIDTableAdapter.FillByPROG(this.sysDS.U_PRGID, (uPRGBindingSource.Current as DataRowView)["PROG"].ToString(), MainForm.SYSTEM);
            }
        }
        bool CheckChangeRule(string UserId, bool SysRule, bool Admin)
        {
            if (MainForm.ADMIN) return true;//管理者都可以看
            if (UserId.Trim() == MainForm.USER_ID.Trim()) return false;//非管理者不能改自己的權限
            if (SysRule) return false;//也不可修改同為系統權限的使用者
            if (MainForm.SYSTEMRULE) return true;//此外都可以
            return false;
        }
        void SetChangeRule(bool enable)
        {
            button1.Enabled = enable;
            button2.Enabled = enable;
            button3.Enabled = enable;
            button4.Enabled = enable;
            //button5.Enabled = enable;
        }
    }
}