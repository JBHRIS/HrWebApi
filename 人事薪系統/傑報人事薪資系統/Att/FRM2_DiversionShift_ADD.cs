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
    public partial class FRM2_DiversionShift_ADD : JBControls.JBForm
    {
        public FRM2_DiversionShift_ADD()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog mdAdate = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.DiversionShift instance = new JBModule.Data.Linq.DiversionShift();
        //string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        List<DateTime> AttendDateList;
        private void FRM2_DiversionShift_ADD_Load(object sender, EventArgs e)
        {
            //topic = this.Text;
            EmpInitial();
        }
        private void EmpInitial()
        {
            SystemFunction.SetComboBoxItems(cbxDiversionGroup, CodeFunction.GetMtCode("DiversionGroupType"), false, true, true, true);
            SystemFunction.SetComboBoxItems(cbxDiversionAttendType, CodeFunction.GetDiversionAttendType(), false, true, true, true);
            if (Autokey == -1)
            {
                SetDateList();
                dtpBDate.Value = DateTime.Today;
                dtpEDate.Value = DateTime.Today.AddMonths(1);
                cbxDiversionGroup.Focus();
            }
            else
            {
                instance = db.DiversionShift.SingleOrDefault(p => p.AutoKey == Autokey);
                cbxDiversionGroup.SelectedValue = instance.DiversionGroup;
                dtpBDate.Value = instance.AttendDate;
                dtpEDate.Value = instance.AttendDate;
                cbxDiversionAttendType.SelectedValue = instance.DiversionAttendType;
                txtGuid.Text = instance.Guid.ToString();
                cbxDiversionGroup.Enabled = false;
                dtpBDate.Enabled = false;
                dtpEDate.Enabled = false;
                btnDateList.Enabled = false;
            }
        }
        private void btnDateList_Click(object sender, EventArgs e)
        {
            SetDateList();
        }

        void SetDateList()
        {
            if (Autokey == -1 && cbxDiversionGroup.SelectedValue != null)
            {
                DateTime bdate = dtpBDate.Value;
                DateTime edate = dtpEDate.Value;
                string DiversionGroup = cbxDiversionGroup.SelectedValue.ToString();
                AttendDateList = new List<DateTime>();
                for (DateTime dd = bdate; dd <= edate; dd = dd.AddDays(1))
                {
                    AttendDateList.Add(dd);
                }
                var DiversionShiftList = (from ds in db.DiversionShift
                                          join mt in db.MTCODE on ds.DiversionGroup equals mt.CODE
                                          join dat in db.DiversionAttendType on ds.DiversionAttendType equals dat.DiversionAttendType1
                                          where mt.CATEGORY == "DiversionGroupType"
                                          && ds.DiversionGroup == DiversionGroup
                                          select new { ds.DiversionGroup, DiversionGroupName = mt.NAME, ds.AttendDate, ds.DiversionAttendType, dat.DiversionAttendTypeName }).ToList();

                var sql = from a in AttendDateList
                          join ds in DiversionShiftList on a equals ds.AttendDate into g
                          from ds in g.DefaultIfEmpty()  //left join
                          select new
                          {
                              出勤日期 = a,
                              //分流組別 = ds != null ? ds.DiversionGroup : string.Empty,
                              //組別名稱 = ds != null ? ds.DiversionGroupName : string.Empty,
                              上班類別 = ds != null ? ds.DiversionAttendType : string.Empty,
                              類別名稱 = ds != null ? ds.DiversionAttendTypeName : string.Empty
                          };
                mdAdate.SetControl(btnDateList, sql.CopyToDataTable(), "出勤日期");
                //mdAdate.SelectedValues.Clear();
                btnDateList.Text = "出勤日期手動調整";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string DiversionGroupType = cbxDiversionGroup.SelectedValue.ToString();
            string DiversionAttendType = cbxDiversionAttendType.SelectedValue.ToString();
            AttendDateList = new List<DateTime>();
            foreach (var Adate in mdAdate.SelectedValues)
            {
                AttendDateList.Add(DateTime.Parse(Adate));
            }
            //DateTime BDate = dtpBDate.Value;
            //DateTime EDate = dtpEDate.Value;
            bool ReplaceSW = true;
            if (Autokey == -1)
            {
                List<JBModule.Data.Linq.DiversionShift> instanceRp = new List<JBModule.Data.Linq.DiversionShift>();
                instanceRp = db.DiversionShift.Where(p => p.DiversionGroup == DiversionGroupType && AttendDateList.Contains(p.AttendDate)).ToList();
                if (instanceRp.Any())
                {
                    if (MessageBox.Show("已存在同出勤日資料，Yes = 覆蓋, No = 略過.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                        db.DiversionShift.DeleteAllOnSubmit(instanceRp);
                        db.SubmitChanges();
                    }
                    else
                    {
                        ReplaceSW = false;
                    }
                }

                object[] PARMS = new object[] { Autokey, DiversionGroupType, AttendDateList, DiversionAttendType, ReplaceSW };
                BW.RunWorkerAsync(PARMS);
                this.tableLayoutPanel1.Enabled = false;
            }
            else
            {
                string msg = "";
                try
                {
                    instance.DiversionAttendType = DiversionAttendType;
                    instance.KeyDate = DateTime.Now;
                    instance.KeyMan = MainForm.USER_NAME;
                    JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey);
                    db.SubmitChanges();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "存檔錯誤.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msg = ex.Message;
                    JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AutoKey);
                }
            }
        }
        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            int Autokey = int.Parse(parameters[0].ToString());
            string DiversionGroupType = parameters[1] as string;
            string DiversionGroupDisp = CodeFunction.GetMtCode("DiversionGroupType").Where(p => p.Key == DiversionGroupType).First().Value;
            //DateTime BDate = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
            //DateTime Edate = (parameters[3] as DateTime?).GetValueOrDefault(DateTime.Today);
            List<DateTime> AttendDateList = parameters[2] as List<DateTime>;
            string DiversionAttendType = parameters[3] as string;
            bool ReplaceSW = (parameters[4] as Boolean?).GetValueOrDefault(true);
            string msg = "";
            try
            {
                string keyman = MainForm.USER_NAME;
                List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                int total = AttendDateList.Count;
                int count = 0;

                foreach (var dd in AttendDateList)
                {
                    DateTime keydate = DateTime.Now;

                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生 " + DiversionGroupDisp + " 分流班表資料");
                    instance = new JBModule.Data.Linq.DiversionShift();
                    JBModule.Data.Linq.DiversionShift instanceRp = new JBModule.Data.Linq.DiversionShift();
                    instanceRp = dbBW.DiversionShift.Where(p => p.DiversionGroup == DiversionGroupType && p.AttendDate == dd).FirstOrDefault();
                    if (instanceRp != null)
                    {
                        if (ReplaceSW)
                        {
                            instanceRp.DiversionAttendType = DiversionAttendType;
                            instanceRp.KeyDate = keydate;
                            instanceRp.KeyMan = keyman;
                            JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey);
                        }
                    }
                    else
                    {
                        instance.DiversionGroup = DiversionGroupType;
                        instance.AttendDate = dd;
                        instance.DiversionAttendType = DiversionAttendType;
                        instance.Guid = Guid.NewGuid();
                        instance.KeyDate = keydate;
                        instance.KeyMan = keyman;
                        JBModule.Message.DbLog.WriteLog("Insert", instance, this.Name, instance.AutoKey);
                        dbBW.DiversionShift.InsertOnSubmit(instance);
                    }
                    count++;
                    dbBW.SubmitChanges();
                }
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = "完成.";
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AutoKey);
            }
        }
        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.tableLayoutPanel1.Enabled = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpEDate.Value = dtpBDate.Value;
            SetDateList();
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpBDate.Value = dtpEDate.Value;
            SetDateList();
        }

        private void cbxDiversionGroup_DropDownClosed(object sender, EventArgs e)
        {
            SetDateList();
        }
    }
}
