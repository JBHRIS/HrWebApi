using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2V : JBControls.JBForm
    {
        public FRM2V()
        {
            InitializeComponent();
        }
        private void FRM2V_Load(object sender, EventArgs e)
        {

        }

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                var id = (int)jbQuery1.SelectedKey;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var errorRecord = db.ATTEND_ABNORMAL.SingleOrDefault(p => p.ID == id);
                if (errorRecord != null)
                {
                    var checkRecord = db.ATTEND_ABNORMAL_CHECK.FirstOrDefault(p => p.NOBR == errorRecord.NOBR && p.ADATE == errorRecord.ADATE && p.TYPE == errorRecord.TYPE);
                    if (checkRecord != null)
                    {
                        MessageBox.Show("此筆異常紀錄已存在註記資料，請使用修改方式進行內容變更");
                    }
                    else
                    {
                        FRM2V_EDIT frm = new FRM2V_EDIT();
                        frm.Id = id;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                var id = (int)e.PrimaryKey;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var errorRecord = db.ATTEND_ABNORMAL.SingleOrDefault(p => p.ID == id);
                if (errorRecord != null)
                {
                    var checkRecord = db.ATTEND_ABNORMAL_CHECK.FirstOrDefault(p => p.NOBR == errorRecord.NOBR && p.ADATE == errorRecord.ADATE && p.TYPE == errorRecord.TYPE);
                    if (checkRecord == null)
                    {
                        MessageBox.Show("此筆異常紀錄未建立註記資料，請使用使用新增方式建立資料");
                        FRM2V_EDIT frm = new FRM2V_EDIT();
                        frm.Id = id;
                        frm.ShowDialog();
                    }
                    else
                    {
                        FRM2V_EDIT frm = new FRM2V_EDIT();
                        frm.Id = id;
                        frm.CheckId = checkRecord.ID;
                        frm.ShowDialog();
                    }
                } 
            }
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(e.PrimaryKey);

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var errorRecord = db.ATTEND_ABNORMAL.SingleOrDefault(p => p.ID == Id);
            if (!Sal.Function.IsAttendLocked(errorRecord.ADATE, errorRecord.NOBR))
            {
                var checkRecord = db.ATTEND_ABNORMAL_CHECK.Where(p => p.NOBR == errorRecord.NOBR && p.ADATE == errorRecord.ADATE && p.TYPE == errorRecord.TYPE);
                db.ATTEND_ABNORMAL_CHECK.DeleteAllOnSubmit(checkRecord);
                db.SubmitChanges();
            }

        }

        private void buttonPatch_Click(object sender, EventArgs e)
        {
            FRM2V_EDIT_M frm = new FRM2V_EDIT_M();
            int total = jbQuery1.SelectKeys.Count();
            int success = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var db = new JBModule.Data.Linq.HrDBDataContext();
                foreach (int Id in jbQuery1.SelectKeys)
                {
                    var errorRecord = db.ATTEND_ABNORMAL.SingleOrDefault(p => p.ID == Id);
                    if (!Sal.Function.IsAttendLocked(errorRecord.ADATE, errorRecord.NOBR))
                    {
                        var checkRecord = db.ATTEND_ABNORMAL_CHECK.FirstOrDefault(p => p.NOBR == errorRecord.NOBR && p.ADATE == errorRecord.ADATE && p.TYPE == errorRecord.TYPE);
                        if (checkRecord == null)
                        {
                            checkRecord = new ATTEND_ABNORMAL_CHECK();
                            checkRecord.ADATE = errorRecord.ADATE;
                            checkRecord.NOBR = errorRecord.NOBR;
                            checkRecord.TYPE = errorRecord.TYPE;
                            checkRecord.REMARK_TYPE = frm.RemarkType;
                            checkRecord.REMARK = frm.Remark;
                            checkRecord.CREATE_DATE = DateTime.Now;
                            checkRecord.CREATE_MAN = MainForm.USER_NAME;
                            db.ATTEND_ABNORMAL_CHECK.InsertOnSubmit(checkRecord);
                            checkRecord.UPDATE_DATE = DateTime.Now;
                            checkRecord.UPDATE_MAN = MainForm.USER_NAME;
                            db.SubmitChanges();
                            success++;
                        }
                    }
                }
            }
            MessageBox.Show("批次註記完成，共選取" + total.ToString() + "筆，實際完成" + success.ToString() + "筆");
        }
    }
}
