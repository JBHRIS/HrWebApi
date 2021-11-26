using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
namespace JBHR.Att
{
    public partial class FRM24A : JBControls.JBForm
    {
        public FRM24A()
        {
            InitializeComponent();
        }

        private void FRM25A_Load(object sender, EventArgs e)
        {
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            this.dEPTTableAdapter1.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM24A", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("AcceptRangeByOffTime", "下班卡延後最大分鐘數", "0", "設定隨機延後打卡分鐘數的最大分鐘數", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("AcceptRangeByOnTime", "上班卡提前最大分鐘數", "0", "設定隨機提前打卡分鐘數的最大分鐘數", "TextBox", "", "String");

            txtDateB.Text = Sal.Function.GetDate();
            txtDateE.Text = Sal.Function.GetDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM24A", MainForm.COMPANY);
            string sAcceptRangeByOnTime = AppConfig.GetConfig("AcceptRangeByOnTime").Value;
            string sAcceptRangeByOffTime = AppConfig.GetConfig("AcceptRangeByOffTime").Value;
            int dec = 0;
            if (isRandom.Checked && (!int.TryParse(sAcceptRangeByOnTime, out dec) || dec == 0))
            {
                MessageBox.Show("「上班卡提前最大分鐘數」尚未設定或格式錯誤", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isRandom.Checked && (!int.TryParse(sAcceptRangeByOffTime, out dec) || dec == 0))
            {
                MessageBox.Show("「下班卡延後最大分鐘數」尚未設定或格式錯誤", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int iAcceptRangeByOnTime = Convert.ToInt32(sAcceptRangeByOnTime);
            int iAcceptRangeByOffTime = Convert.ToInt32(sAcceptRangeByOffTime);

            DateTime date_b, date_e;
            date_b = Convert.ToDateTime(txtDateB.Text);
            date_e = Convert.ToDateTime(txtDateE.Text);

            DateTime t1, t2;
            t1 = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<NobrAdateByAbs> absList = null;
            var sql = (from a in db.ATTEND
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       join c in db.ROTE on a.ROTE equals c.ROTE1
                       join d in db.CARDAPP on a.NOBR equals d.NOBR into ad
                       from cardapp in ad.DefaultIfEmpty()
                       //join f in db.DEPT on b.DEPT equals f.D_NO
                       where a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                       && mdEmp.SelectedValues.Contains(a.NOBR) //已做權限篩選
                       && radCheckedDropDownList1.CheckedItems.Select(p => p.Value).Contains(a.ROTE)
                       && radCheckedDropDownList2.CheckedItems.Select(p => p.Text).Contains(b.CARD)
                       && a.ADATE >= date_b && a.ADATE <= date_e
                       && c.ON_TIME.Trim().Length > 0 && c.OFF_TIME.Trim().Length > 0
                       select new { ATTEND = a, ROTE = c, CARDAPP = cardapp }).ToList();
            var CardSQL = (from a in db.CARD
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           join f in db.DEPT on b.DEPT equals f.D_NO
                           where a.ADATE >= date_b && a.ADATE <= date_e.AddDays(1)//可能跨天
                            && mdEmp.SelectedValues.Contains(a.NOBR) //已做權限篩選
                           select a).ToList();
            if (checkAbs.Checked)
            {
                absList = (from a in db.ABS
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           //join f in db.DEPT on b.DEPT equals f.D_NO
                           join c in db.HCODE on a.H_CODE equals c.H_CODE
                           where mdEmp.SelectedValues.Contains(a.NOBR) //已做權限篩選
                           && a.BDATE >= date_b && a.BDATE <= date_e
                           && c.FLAG == "-"
                           //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           //&& db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           select new NobrAdateByAbs { NOBR = a.NOBR, ADATE = a.BDATE }).ToList();
                sql = (from a in sql
                       where !absList.Any(p => p.NOBR == a.ATTEND.NOBR && p.ADATE == a.ATTEND.ADATE)
                       select a).ToList();
            }
            var roteList = (from a in db.ROTE select a).ToList();
            List<JBModule.Data.Linq.CARD> insertCardList = new List<JBModule.Data.Linq.CARD>();
            foreach (var itm in sql)
            {
                db = new JBModule.Data.Linq.HrDBDataContext();
                JBModule.Data.Linq.CARD card = null;
                if (CodeFunction.GetHolidayRoteList().Contains(itm.ATTEND.ROTE)) continue;//如果遇到假日就略過

                if (rdb21.Checked || rdb22.Checked)//如果是選全部或是上班卡
                {
                    DateTime adate = itm.ATTEND.ADATE;
                    string ontime = itm.ROTE.ON_TIME;
                    transTo24DateTimeForOnTime(ref adate, ref ontime);
                    ontime = hhmmAddRandomMinutes(ontime, iAcceptRangeByOnTime * -1);
                    card = new JBModule.Data.Linq.CARD();
                    card.ADATE = adate;
                    card.NOBR = itm.ATTEND.NOBR;
                    card.CARDNO = itm.CARDAPP != null ? itm.CARDAPP.CARDNO : itm.ATTEND.NOBR;
                    card.CODE = "FRM24A";
                    card.DAYS = 1;
                    card.IPADD = "";
                    card.KEY_DATE = DateTime.Now;
                    card.KEY_MAN = MainForm.USER_NAME;
                    card.LOS = false;
                    card.MENO = "";
                    card.NOT_TRAN = false;
                    card.ONTIME = ontime;//上班時間
                    card.REASON = "";
                    card.SERNO = "";
                    db.CARD.InsertOnSubmit(card);
                }
                if (rdb21.Checked || rdb23.Checked)//如果是選全部或是下班卡
                {
                    DateTime adate = itm.ATTEND.ADATE;
                    string offtime = itm.ROTE.OFF_TIME;
                    transTo24DateTimeForOffTime(ref adate, ref offtime);
                    var dtRote = from a in roteList where a.ROTE1 == itm.ATTEND.ROTE select a;
                    JBModule.Data.Linq.ROTE rote = new JBModule.Data.Linq.ROTE();
                    if (dtRote.Any())
                        rote = dtRote.First();
                    else new Exception("找不到班別" + rote.ROTE1);

                    if (rote.ALLLATES1 > 0)
                    {
                        int hh, mm;
                        hh = Convert.ToInt32(offtime.Substring(0, 2));
                        mm = Convert.ToInt32(offtime.Substring(2));
                        mm += Convert.ToInt32(rote.ALLLATES1);
                        if (mm >= 60)
                        {
                            mm -= 60;
                            hh++;
                            if (hh >= 24)
                            {
                                hh -= 24;
                                adate = adate.AddDays(1);
                            }
                        }
                        offtime = hh.ToString("00") + mm.ToString("00");
                    }
                    offtime = hhmmAddRandomMinutes(offtime, iAcceptRangeByOffTime);
                    card = new JBModule.Data.Linq.CARD();
                    card.ADATE = adate;
                    card.NOBR = itm.ATTEND.NOBR;
                    card.CARDNO = itm.CARDAPP != null ? itm.CARDAPP.CARDNO : itm.ATTEND.NOBR;
                    card.CODE = "FRM24A";
                    card.DAYS = 1;
                    card.IPADD = "";
                    card.KEY_DATE = DateTime.Now;
                    card.KEY_MAN = MainForm.USER_NAME;
                    card.LOS = false;
                    card.MENO = "";
                    card.NOT_TRAN = false;
                    card.ONTIME = offtime;//下班時間
                    card.REASON = "";
                    card.SERNO = "";
                    db.CARD.InsertOnSubmit(card);
                }
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    JBModule.Message.TextLog.WriteLog(ex);
                }
            }

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        void transTo24DateTimeForOffTime(ref DateTime aDate, ref string offTime)
        {
            if (offTime.CompareTo("2400") >= 0)
            {
                int hh, mm;
                hh = Convert.ToInt32(offTime.Substring(0, 2));
                mm = Convert.ToInt32(offTime.Substring(2));
                hh -= 24;
                offTime = hh.ToString("00") + mm.ToString("00");
                aDate = aDate.AddDays(1);
            }
        }
        void transTo24DateTimeForOnTime(ref DateTime aDate, ref string onTime)
        {
            if (onTime.CompareTo("2400") >= 0)
            {
                int hh, mm;
                hh = Convert.ToInt32(onTime.Substring(0, 2));
                mm = Convert.ToInt32(onTime.Substring(2));
                hh -= 24;
                onTime = hh.ToString("00") + mm.ToString("00");
                aDate = aDate.AddDays(1);
            }
        }
        string hhmmAddRandomMinutes(string time, int addMaxMinutes)
        {
            if (!isRandom.Checked) return time;
            DateTime d = DateTime.Now.Date;
            int hh = Convert.ToInt32(time.Substring(0, 2));
            int mm = Convert.ToInt32(time.Substring(2, 2));
            d = d.AddHours(hh).AddMinutes(mm);
            int maxValue = addMaxMinutes < 0 ? addMaxMinutes * -1 : addMaxMinutes;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            int rdValue = rd.Next(maxValue);
            d = d.AddMinutes(addMaxMinutes < 0 ? rdValue * -1 : rdValue);
            return d.ToString("HHmm");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime date_b, date_e;
            date_b = Convert.ToDateTime(txtDateB.Text);
            date_e = Convert.ToDateTime(txtDateE.Text);
            var CardSQL = (from a in db.CARD
                           //join b in db.BASETTS on a.NOBR equals b.NOBR
                           //join f in db.DEPT on b.DEPT equals f.D_NO
                           where mdEmp.SelectedValues.Contains(a.NOBR)
                           && a.ADATE >= date_b && a.ADATE <= date_e
                           && a.CODE == "FRM24A"
                           //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           //&& db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           select a).ToList();
            try
            {
                db.CARD.DeleteAllOnSubmit(CardSQL);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("刪除完畢");
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        void SetEmpData()
        {
            DateTime dateBegin = Convert.ToDateTime(txtDateB.Text);
            DateTime dateEnd = Convert.ToDateTime(txtDateE.Text);
            var EmpData = Repo.EmpRepo.GetEmpAllWithDeptCard(Repo.EmpRepo.GetEmpListByAttendDate(dateBegin, dateEnd));            
            mdEmp.SetControl(buttonEmp, EmpData, "員工編號");
        }

        private void txtDateB_Validated(object sender, EventArgs e)
        {
            SetEmpData();
        }

        private void txtDateE_Validated(object sender, EventArgs e)
        {
            SetEmpData();
        }
    }
}

class NobrAdateByAbs
{
    public string NOBR { get; set; }
    public DateTime ADATE { get; set; }
}
class NobrAdateOntimeByCard
{
    public string NOBR { get; set; }
    public DateTime ADATE { get; set; }
    public string ONTIME { get; set; }
}
