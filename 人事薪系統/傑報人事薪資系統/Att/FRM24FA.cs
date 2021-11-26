using JBTools.Extend;
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
    public partial class FRM24FA : JBControls.JBForm
    {
        public FRM24FA()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.FOOD_CARD instance = new JBModule.Data.Linq.FOOD_CARD();
        Dictionary<string, string> MealTypeList = new Dictionary<string, string>();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        string MealGroup;
        List<string> nobrs = new List<string>();
        List<string> mealtypes = new List<string>();
        CheckedListBox.CheckedIndexCollection CheckedIndices;
        DateTime BDate, Edate;
        string Note;
        bool RpSW = true;
        private void FRM24FWA_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }

        private void EmpInitial()
        {
            SystemFunction.SetComboBoxItems(cbxMealGroup, CodeFunction.GetMealGroup(), true, true, true, true);
            if (Autokey == -1)
            {
                dtpBDate.Value = DateTime.Today;
                dtpEDate.Value = DateTime.Today;
                cbxMealGroup.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            nobrs = mdEmp.SelectedValues;
            BDate = dtpBDate.Value;
            Edate = dtpEDate.Value;
            Note = txtNOTE.Text;
            CheckedIndices = chkMealTypeListBox.CheckedIndices;
            if (CheckedIndices.Count == 0)
            {
                MessageBox.Show("未選取任何的用餐種類.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                foreach (int i in CheckedIndices)
                {
                    mealtypes.Add(MealTypeList.Keys.ToArray()[i]);
                }
            }
            MealGroup = cbxMealGroup.SelectedValue.ToString();
            BW.RunWorkerAsync();
            this.tableLayoutPanel1.Enabled = false;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            //string mealtype = cbxMealType.SelectedValue.ToString();
            try
            {
                string keyman = MainForm.USER_NAME;
                DateTime keydate = DateTime.Now;
                //bool ReplaceSW = false;
                if (Autokey == -1)
                {
                    List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                    int total = nobrs.Count;
                    int count = 0;

                    List<JBModule.Data.Linq.BASETTS> basetts = new List<JBModule.Data.Linq.BASETTS>();
                    foreach (var nobrList in nobrs.Split(1000))
                    {
                        var sql = db.BASETTS.Where(p => nobrList.Contains(p.NOBR)).ToList();
                        basetts.AddRange(sql);
                    }

                    foreach (var nobr in nobrs)
                    {
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生" + nobr + "食堂刷卡資料.");
                        var cardapp = db.CARDAPP.Where(p => p.NOBR == nobr).FirstOrDefault();
                        string cardno = cardapp == null ? nobr : cardapp.CARDNO;
                        for (DateTime dd = BDate; dd <= Edate; dd = dd.AddDays(1))
                        {
                            if (!basetts.Where(p => p.ADATE <= dd && p.DDATE >= dd && new string[] { "1", "4", "6" }.Contains(p.TTSCODE)).Any())
                                continue;

                            if (chkHoliNot.Checked)
                            {//假日就跳過
                                var roteSql = (from a in db.ATTEND where a.NOBR == nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                                if (roteSql != null && holi_codeList.Contains(roteSql)) continue;
                            }

                            foreach (var mealtype in mealtypes)
                            {
                                var mealtypeDetail = db.MealType.Where(p => p.MealGroup == MealGroup && p.MealType_Code == mealtype).First();
                                DateTime adate = dd;
                                DateTime Btime = dd.AddTime(mealtypeDetail.BTime);
                                DateTime Etime = dd.AddTime(mealtypeDetail.ETime);

                                DateTime RDdateTime = GetRandomDate(Btime, Etime);
                                adate = RDdateTime.Date;
                                string ontime = RDdateTime.Hour.ToString("00") + RDdateTime.Minute.ToString("00");
                                instance = new JBModule.Data.Linq.FOOD_CARD();
                                JBModule.Data.Linq.FOOD_CARD instanceRp = new JBModule.Data.Linq.FOOD_CARD();
                                instanceRp = db.FOOD_CARD.Where(p => p.NOBR == nobr && p.ADATE == adate && p.ONTIME == ontime && p.CARDNO == cardno).FirstOrDefault();
                                if (instanceRp != null)
                                {
                                    instanceRp.CODE = "FRM24FWA";
                                    instanceRp.NOT_TRAN = false;
                                    instanceRp.REASON = "產生食堂刷卡資料";
                                    instanceRp.DAYS = 1;
                                    instanceRp.LOS = false;
                                    instanceRp.IPADD = "";
                                    instanceRp.MENO = Note;
                                    instanceRp.SERNO = "";
                                    instanceRp.KEY_DATE = keydate;
                                    instanceRp.KEY_MAN = keyman;
                                    instanceRp.FULLTIME = keydate;
                                }
                                else
                                {
                                    instance.CODE = "FRM24FWA";
                                    instance.NOBR = nobr;
                                    instance.ADATE = adate;
                                    instance.ONTIME = ontime;
                                    instance.CARDNO = cardno;
                                    instance.NOT_TRAN = false;
                                    instance.REASON = "產生食堂刷卡資料";
                                    instance.DAYS = 1;
                                    instance.LOS = false;
                                    instance.IPADD = "";
                                    instance.MENO = Note;
                                    instance.SERNO = "";
                                    instance.KEY_DATE = keydate;
                                    instance.KEY_MAN = keyman;
                                    instance.FULLTIME = keydate;
                                    db.FOOD_CARD.InsertOnSubmit(instance);
                                }
                            }
                        }
                        count++;
                        db.SubmitChanges();
                    }
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
                //JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AUTOKEY);
            }
        }

        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }


        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tableLayoutPanel1.Enabled = true;
            if (!e.Cancelled)
            {
                if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                    MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmp_Enter(object sender, EventArgs e)
        {
            SetEmpList();
        }

        void SetEmpList()
        {
            if (Autokey == -1)
            {
                string MealGroup = cbxMealGroup.SelectedValue.ToString();
                //DateTime ndate = DateTime.Today;//Convert.ToDateTime(dtpADATE.Text);
                DateTime bdate = dtpBDate.Value;
                DateTime edate = dtpEDate.Value;
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join mt in db.MTCODE on b.TTSCODE equals mt.CODE
                          join ad in (db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR)) on a.NOBR equals ad.Key
                          join ud in (from udv in db.UserDefineValue
                                      join uds in db.UserDefineSource on udv.SourceID equals uds.SourceID
                                      join md in db.MealGroup on udv.Value equals md.MealGroup_Code
                                      where uds.SourceName == "MealGroup" && udv.Value == MealGroup
                                      select new { udv.Code, md.MealGroup_Code, md.MealGroup_DISP, md.MealGroup_Name }) on a.NOBR equals ud.Code
                          //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                          where edate >= b.ADATE && edate <= b.DDATE.Value
                          //&& new string[] { "1", "4", "6" }.Contains(b.TTSCODE)
                          && mt.CATEGORY == "TTSCODE"
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new { 員工編號 = a.NOBR, 姓名 = a.NAME_C, 用餐群组 = ud.MealGroup_DISP + "-" + ud.MealGroup_Name, 異動狀態 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? "在职" : mt.NAME, 職等 = b.JOBL, 編制部門 = b.DEPT1.D_NAME, _index = ud.MealGroup_Code };
                mdEmp.SetControl(btnEmp, sql.CopyToDataTable(), "員工編號");
                mdEmp.SelectedValues.Clear();
                btnEmp.Text = "請選擇需要產生食堂刷卡的人員";
            }
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpEDate.Value = dtpBDate.Value;
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpBDate.Value = dtpEDate.Value;
            SetEmpList();
        }

        private void cbxMealGroup_DropDownClosed(object sender, EventArgs e)
        {
            mdEmp.Source = new DataTable();
            btnEmp.Tag = null;
            MealTypeList.Clear();
            chkMealTypeListBox.Items.Clear();
            MealTypeList = CodeFunction.GetMealType(cbxMealGroup.SelectedValue.ToString());
            foreach (var item in MealTypeList.Values)
                chkMealTypeListBox.Items.Add(item, false);
            SetEmpList();
        }
    }
}
