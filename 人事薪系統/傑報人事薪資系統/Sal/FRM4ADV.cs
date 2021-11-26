using JBHR.Sal.Core;
using JBTools.Extend;
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
    public partial class FRM4ADV : JBControls.JBForm
    {
        public FRM4ADV()
        {
            InitializeComponent();
        }

        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4ADV", MainForm.COMPANY);
        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog hcodetypeSelection = new JBControls.MultiSelectionDialog();
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();

        private void FRM4ADV_Load(object sender, EventArgs e)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig.CheckParameterAndSetDefault("AdvanceLeaveHcodeType", "借假類別代碼", "", "指定借假類別代碼", "ComboBox", "select HTYPE,HTYPE_DISP +'-'+ TYPE_NAME from HcodeType where dbo.getcodefilter('HcodeType',HTYPE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("YearCloseByMonth", "年度結算月份", "0", "指定年度結算月份,到指定月份時,會自動勾選年度結算.(0=不指定)", "TextBox", "", "Int");
            AppConfig.CheckParameterAndSetDefault("ResignEmpWriteOff", "離職員工強制結算", "False", "離職人員在產生沖銷時是否要強制結算.", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("ResignEmpHcodeTypes", "離職人員強制沖假", "H1,H2,H3", "指定請假類別代碼,時數不足時會產生對應的請假(失效),以「,」做分隔.", "TextBox", "", "string");
            AppConfig.CheckParameterAndSetDefault("OTHrsWriteOff", "是否抵扣加班時數", "True", "是否要用加班時數做抵扣.", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            int chkMonth = AppConfig.GetConfig("YearCloseByMonth").GetInter(0);
            dtpBDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpEDate.Value = new DateTime(DateTime.Today.Year, 12, 31);
            SalaryDate sd = new SalaryDate(DateTime.Today);
            chkWriteOff.Checked = !(AppConfig.GetConfig("OTHrsWriteOff").GetString() == "True" ? true : false);
            txtYYMM.Text = sd.YYMM;
            CYYMMFC.AddControl(txtYYMM, true);
            if (sd.Month == chkMonth)
                chkYearClose.Checked = true;
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
        }

        private void chkWriteOff_CheckedChanged(object sender, EventArgs e)
        {
            btnHCodeType.Enabled = chkWriteOff.Checked;
        }

        private void btnHCode_Click(object sender, EventArgs e)
        {
            if (hcodetypeSelection.Source == null)
            {
                hcodetypeSelection.SetControl(btnHCodeType, Repo.AttRepo.GetHcodeType(), "_HTYPE");
                hcodetypeSelection.SelectedValues = new List<string>();
                hcodetypeSelection.ShowDialog();
                btnHCodeType.Text = string.Format("選取({0})", hcodetypeSelection.SelectedValues.Count());
            } 
        }

        private void btnGenEmp_Click(object sender, EventArgs e)
        {
            DateTime BDate = dtpBDate.Value;
            DateTime EDate = dtpEDate.Value;
            var db = new JBModule.Data.Linq.HrDBDataContext();

            var AdvanceLeaveHcodeType = AppConfig.GetConfig("AdvanceLeaveHcodeType").GetString();
            if (!db.HcodeType.Where(p=>p.HTYPE == AdvanceLeaveHcodeType).Any())
            {
                MessageBox.Show(string.Format("找不到借假類別代碼{0}的設定,請至齒輪進行重設.", AdvanceLeaveHcodeType));
                return;
            }
            var AdvanceLeaveXCode = db.HCODE.Where(p => p.HTYPE == AdvanceLeaveHcodeType && p.FLAG == "X").FirstOrDefault();
            if (AdvanceLeaveXCode == null)
            {
                MessageBox.Show(string.Format("找不到借假沖假代碼(特性:X)的設定,請至假別代碼設定."));
                return;
            }

            SalaryDate sd = new SalaryDate(txtYYMM.Text);
            var empSql = from a in db.ABS
                      join h in db.HCODE on a.H_CODE equals h.H_CODE
                      join ht in db.HcodeType on h.HTYPE equals ht.HTYPE
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join bt in db.BASETTS on b.NOBR equals bt.NOBR
                      join d in db.DEPT on bt.DEPT equals d.D_NO
                      //join wrt in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals wrt.NOBR
                      join MT in db.MTCODE on bt.TTSCODE equals MT.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(bt.TTSCODE) ? "在職" : MT.NAME
                      where a.BDATE >= BDate && a.BDATE <= EDate
                      && bt.ADATE <= sd.LastDayOfAttend.AddDays(1) && bt.DDATE >= sd.LastDayOfAttend.AddDays(1)
                      && ht.HTYPE == AdvanceLeaveHcodeType && h.FLAG == "-"
                      && MT.CATEGORY == "TTSCODE"
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bt.SALADR)
                      orderby a.NOBR
                      orderby JobState
                      select new { 
                          員工編號 = a.NOBR, 
                          員工姓名 = b.NAME_C, 
                          在離職 = JobState, 
                          部門代碼 = d.D_NO_DISP, 
                          部門名稱 = d.D_NAME,
                          離職日期 = bt.OUDT,
                          留職停薪日 = bt.STDT,
                          停薪離職日 = bt.STOUDT
                      };
            empSelection.SetControl(btnEmp, empSql.Distinct().CopyToDataTable(), "員工編號");
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            var control = CYYMMFC.CheckRequiredFields();
            if (control != null)
            {
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                control.Focus();
                return;
            }

            bool Lock = false;
            SalaryDate sd = new SalaryDate(txtYYMM.Text);
            foreach (var emp in empSelection.SelectedValues)
            {
                for (DateTime dt = sd.FirstDayOfAttend; dt <= sd.LastDayOfAttend; dt = dt.AddDays(1))
                {
                    var saladr = Sal.Core.SalaryDate.GetSaladr(emp, dt);
                    Lock = Sal.Core.SalaryDate.CheckAttendLock(dt, saladr);
                }
                if (Lock) break;
            }
            if(Lock)
                MessageBox.Show(Resources.Att.AttendDateLocked , Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                string tip = string.Format("是否要用計薪年月為{0}的加班,對{1}至{2}的借假進行沖銷作業{3}", txtYYMM.Text, dtpBDate.Value.ToShortDateString(), dtpEDate.Value.ToShortDateString(), chkOverride.Checked ? ",並覆蓋已存在的資料?" : ".");
                if (MessageBox.Show(tip, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                    return;

                var EmpList = empSelection.SelectedValues;
                var Bdate = dtpBDate.Value;
                var Edate = dtpEDate.Value;
                var YYMM = txtYYMM.Text;
                var AdvanceLeaveHcodeType = AppConfig.GetConfig("AdvanceLeaveHcodeType").GetString();
                var HcodeTypeList = chkWriteOff.Checked ? hcodetypeSelection.SelectedValues : new List<string>();
                if (chkWriteOff.Checked && HcodeTypeList.Count == 0)
                {
                    MessageBox.Show("尚未指定沖假類別.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                var ResignEmpWriteOff = AppConfig.GetConfig("ResignEmpWriteOff").GetString() == "True" ? true : false;
                var ResignHcodeTypeList = AppConfig.GetConfig("ResignEmpHcodeTypes").GetString("").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var OTHrsWriteOff = AppConfig.GetConfig("OTHrsWriteOff").GetString() == "True" ? true : false;
                var Override = chkOverride.Checked;
                var YearClose = chkYearClose.Checked;
                object[] parameters = new object[] { EmpList, Bdate, Edate, YYMM, AdvanceLeaveHcodeType, HcodeTypeList, ResignEmpWriteOff, ResignHcodeTypeList, OTHrsWriteOff, Override, YearClose };

                BW.RunWorkerAsync(parameters);
                this.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBTools.Stopwatch sw = new JBTools.Stopwatch();
                sw.Start();

                object[] parameters = e.Argument as object[];
                List<string> emplistAll = parameters[0] as List<string>;
                DateTime bdate = (parameters[1] as DateTime?).GetValueOrDefault(DateTime.Today);
                DateTime edate = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
                string yymm = parameters[3] as string;
                string advanceLeavehcodetype = parameters[4] as string;
                List<string> hcodetypelist = parameters[5] as List<string>;
                bool resignclose = (parameters[6] as bool?).GetValueOrDefault(false);

                var RHCTSource = db.HcodeType.Where(p=> db.GetCodeFilter("HcodeType", p.HTYPE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value);
                List<string> resignhcodetypelist = RHCTSource.Where(p => (parameters[7] as List<string>).Contains(p.HTYPE_DISP)).Select(p => p.HTYPE).ToList();

                var hcodetypes = (from ht in db.HcodeType
                                  join h1 in db.HCODE on ht.GetCode equals h1.H_CODE into ps1
                                  from h1 in ps1.DefaultIfEmpty()
                                  join h2 in db.HCODE on ht.ExpireCode equals h2.H_CODE into ps2
                                  from h2 in ps2.DefaultIfEmpty()
                                  where hcodetypelist.Contains(ht.HTYPE)
                                  orderby ht.Sort
                                  select new { 類別 = ht, 得假 = h1 ,失效 = h2 }).ToList();

                var resignhcodetypes = (from ht in db.HcodeType
                                        join h1 in db.HCODE on ht.GetCode equals h1.H_CODE into ps1
                                        from h1 in ps1.DefaultIfEmpty()
                                        join h2 in db.HCODE on ht.ExpireCode equals h2.H_CODE into ps2
                                        from h2 in ps2.DefaultIfEmpty()
                                        where resignhcodetypelist.Contains(ht.HTYPE)
                                        orderby ht.Sort
                                        select new { 類別 = ht, 得假 = h1, 失效 = h2 }).ToList();
                bool OTHrsWriteOff = (parameters[8] as bool?).GetValueOrDefault(false);
                bool overridesw = (parameters[9] as bool?).GetValueOrDefault(false);
                bool yearclose = (parameters[10] as bool?).GetValueOrDefault(false);
                SalaryDate sd = new SalaryDate(yymm);
                foreach (var emplist in emplistAll.Split(1000))
                {
                    var EmpStateList = (from bt in db.BASETTS
                                        where emplist.Contains(bt.NOBR)
                                        && bt.ADATE <= sd.LastDayOfAttend.AddDays(1) && bt.DDATE >= sd.LastDayOfAttend.AddDays(1)
                                        select bt).ToList();

                    var ABSplusAll = (from a in db.ABS
                                      join h in db.HCODE on a.H_CODE equals h.H_CODE
                                      join ht in db.HcodeType on h.HTYPE equals ht.HTYPE
                                      where a.BDATE <= sd.LastDayOfAttend && a.EDATE >= sd.LastDayOfAttend
                                      && h.FLAG == "+" //&& a.Balance > 0
                                      && emplist.Contains(a.NOBR)
                                      orderby a.NOBR, h.SORT, a.EDATE, a.BDATE
                                      select new { ABS = a, HcodeType = ht }).ToList();

                    var ADVplusList = (from a in db.ABS
                                       join h in db.HCODE on a.H_CODE equals h.H_CODE
                                       join ht in db.HcodeType on h.HTYPE equals ht.HTYPE
                                       where a.EDATE >= bdate && a.BDATE <= edate
                                       && ht.HTYPE == advanceLeavehcodetype && h.FLAG == "+"
                                       && emplist.Contains(a.NOBR)
                                       //&& a.YYMM == sd.Year.ToString()
                                       orderby a.NOBR, h.SORT, a.EDATE, a.BDATE
                                       select a).ToList();

                    var ABSplusFinal = (from aa in ABSplusAll
                                        where hcodetypelist.Contains(aa.HcodeType.HTYPE)
                                        select aa.ABS).ToList();
                    var ResignABSplusFinal = (from aa in ABSplusAll
                                                where resignhcodetypelist.Contains(aa.HcodeType.HTYPE)
                                                select aa.ABS).ToList();

                    var ABSList = (from a in db.ABS
                                   join h in db.HCODE on a.H_CODE equals h.H_CODE
                                   join ht in db.HcodeType on h.HTYPE equals ht.HTYPE
                                   join ad in db.ABSD on a.Guid equals ad.ABSADD into ps
                                   from ad in ps.DefaultIfEmpty()
                                   where a.BDATE >= bdate && a.BDATE <= edate
                                   && ht.HTYPE == advanceLeavehcodetype && h.FLAG == "-"
                                   && ad.ABSADD == null
                                   && emplist.Contains(a.NOBR)
                                   orderby a.NOBR, a.BDATE
                                   select a).ToList();

                    var OTList = (from o in db.OT
                                  where o.YYMM == yymm
                                  && o.OT_HRS > 0
                                  && emplist.Contains(o.NOBR)
                                  orderby o.NOBR, o.BDATE
                                  select o).ToList();

                    var AdvanceLeaveXCode = db.HCODE.Where(p => p.HTYPE == advanceLeavehcodetype && p.FLAG == "X").First().H_CODE;

                    foreach (var emp in emplist)
                    {
                        var OTDatabyEmp = OTList.Where(p => p.NOBR == emp);
                        var ABSPlusbyEmp = ADVplusList.Where(p => p.NOBR == emp).FirstOrDefault();
                        if (ABSPlusbyEmp == null)
                        {
                            JBModule.Message.DbLog.WriteLog(string.Format("員工{0}在指定區間內無借假(得)資料", emp), parameters, this.Name, 1);
                            continue;
                        }
                        
                        var ABSListbyEmp = ABSList.Where(p => p.NOBR == emp);
                        var OTHrs = OTDatabyEmp.Sum(p => p.OT_HRS);
                        var ABSHrs = ABSListbyEmp.Sum(p => p.TOL_HOURS);

                        var AdvanceLeaveX = db.ABS.Where(p => p.NOBR == emp && p.H_CODE == AdvanceLeaveXCode && p.YYMM == yymm && p.BTIME == "0000").FirstOrDefault();
                        if (overridesw)
                        {
                            if (AdvanceLeaveX != null)
                            {
                                ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance - AdvanceLeaveX.TOL_HOURS;
                                ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours + AdvanceLeaveX.TOL_HOURS;
                                db.ABS.DeleteOnSubmit(AdvanceLeaveX);
                                db.ABSD.DeleteAllOnSubmit(db.ABSD.Where(p => p.ABSADD == ABSPlusbyEmp.Guid && p.ABSSUBTRACT == AdvanceLeaveX.Guid));
                            }

                            string cashoutHcode = (from ad in db.ABSD
                                                   join a in db.ABS on ad.ABSSUBTRACT equals a.Guid
                                                   join h in db.HCODE on a.H_CODE equals h.H_CODE
                                                   where ad.ABSADD == ABSPlusbyEmp.Guid
                                                   && h.HTYPE != advanceLeavehcodetype
                                                   select ad.ABSSUBTRACT).FirstOrDefault();
                            var cashoutList = (from ad in db.ABSD
                                               where ad.ABSSUBTRACT == cashoutHcode
                                               select ad).ToList();
                            foreach (var item in cashoutList)
                            {
                                var pABS = db.ABS.Where(p => p.Guid == item.ABSADD).FirstOrDefault();
                                if (pABS != null)
                                {
                                    if (pABS.Guid == ABSPlusbyEmp.Guid)
                                    {
                                        ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance - item.USEHOUR;
                                        ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours + item.USEHOUR;
                                    }
                                    else
                                    {
                                        pABS.Balance = pABS.Balance + item.USEHOUR;
                                        pABS.LeaveHours = pABS.LeaveHours - item.USEHOUR;
                                    }

                                }
                            }
                            db.ABS.DeleteAllOnSubmit(db.ABS.Where(p => p.Guid == cashoutHcode));
                            db.ABSD.DeleteAllOnSubmit(db.ABSD.Where(p => p.ABSSUBTRACT == cashoutHcode));

                            var AdvanceLeaveYC = db.ABS.Where(p => p.NOBR == emp && p.H_CODE == AdvanceLeaveXCode && p.YYMM == yymm && p.BTIME == "4800").FirstOrDefault();
                            if (AdvanceLeaveYC != null)
                            {
                                ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance - AdvanceLeaveYC.TOL_HOURS;
                                ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours + AdvanceLeaveYC.TOL_HOURS;
                                db.ABS.DeleteOnSubmit(AdvanceLeaveYC);
                                db.ABSD.DeleteAllOnSubmit(db.ABSD.Where(p => p.ABSADD == ABSPlusbyEmp.Guid && p.ABSSUBTRACT == AdvanceLeaveYC.Guid));
                            }
                            db.SubmitChanges();
                        }
                        else if (AdvanceLeaveX != null)
                            continue;

                        var EmpState = EmpStateList.Where(p => p.NOBR == emp).FirstOrDefault();
                        List<string> resigntts = new List<string>() { "2", "3", "5" };

                        if (OTHrsWriteOff && OTHrs > 0)
                        {
                            AdvanceLeaveX = new JBModule.Data.Linq.ABS
                            {
                                A_NAME = string.Empty,
                                BDATE = sd.FirstDayOfAttend,//DateTime.Today,
                                BTIME = "0000",
                                EDATE = sd.LastDayOfAttend,//DateTime.Today,
                                ETIME = "0000",
                                H_CODE = AdvanceLeaveXCode,
                                KEY_DATE = DateTime.Now,
                                KEY_MAN = MainForm.USER_NAME,
                                NOBR = emp,
                                nocalc = false,
                                NOTE = string.Format("由系統產生:沖銷計薪年月為{0}的借假沖銷.", yymm),
                                NOTEDIT = true,
                                SERNO = string.Empty,
                                SYSCREATE = true,
                                SYSCREATE1 = false,
                                TOL_DAY = 0,
                                TOL_HOURS = OTHrs >= ABSHrs ? ABSHrs : OTHrs,
                                Balance = 0,
                                Guid = Guid.NewGuid().ToString(),
                                LeaveHours = 0,
                                YYMM = yymm,
                            };
                            db.ABS.InsertOnSubmit(AdvanceLeaveX);

                            ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance + AdvanceLeaveX.TOL_HOURS;
                            ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours - AdvanceLeaveX.TOL_HOURS;

                            insertABSD(db, ABSPlusbyEmp, AdvanceLeaveX, AdvanceLeaveX.TOL_HOURS); 
                        }

                        if (ABSPlusbyEmp.LeaveHours > 0)
                        {
                            if (hcodetypelist.Count > 0)
                            {
                                foreach (var item in hcodetypes)
                                {
                                    if (item.失效 != null) //item.得假 != null &&
                                    {
                                        var pABS = ABSplusFinal.Where(p => p.NOBR == emp).ToList(); //&& p.H_CODE == item.得假.H_CODE).ToList();
                                        decimal plushrs = pABS.Sum(p => p.Balance.GetValueOrDefault(0));
                                        if (plushrs > 0)
                                        {
                                            var cashoutABS = new JBModule.Data.Linq.ABS
                                            {
                                                A_NAME = string.Empty,
                                                BDATE = sd.LastDayOfAttend,//DateTime.Today,
                                                BTIME = "4800",
                                                EDATE = sd.LastDayOfAttend,//DateTime.Today,
                                                ETIME = "4800",
                                                H_CODE = item.失效.H_CODE,
                                                KEY_DATE = DateTime.Now,
                                                KEY_MAN = MainForm.USER_NAME,
                                                NOBR = emp,
                                                nocalc = false,
                                                NOTE = string.Format("由系統產生:借假沖銷作業加班時數不足時的扣假作業."),
                                                NOTEDIT = true,
                                                SERNO = string.Empty,
                                                SYSCREATE = true,
                                                SYSCREATE1 = false,
                                                TOL_DAY = 0,
                                                TOL_HOURS = ABSPlusbyEmp.LeaveHours >= plushrs ? plushrs : ABSPlusbyEmp.LeaveHours.Value,
                                                Balance = 0,
                                                Guid = Guid.NewGuid().ToString(),
                                                LeaveHours = 0,
                                                YYMM = yymm,
                                            };
                                            db.ABS.InsertOnSubmit(cashoutABS);

                                            ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours - cashoutABS.TOL_HOURS;
                                            ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance + cashoutABS.TOL_HOURS;

                                            decimal hrs = cashoutABS.TOL_HOURS;
                                            foreach (var p in pABS)
                                            {
                                                decimal usehrs = p.Balance >= hrs ? hrs : p.Balance.Value;
                                                p.Balance = p.Balance.Value - usehrs;
                                                p.LeaveHours = p.TOL_HOURS - p.Balance;
                                                hrs = hrs - usehrs;

                                                insertABSD(db, p, cashoutABS, usehrs);
                                                if (hrs <= 0)
                                                    break;
                                            }

                                            insertABSD(db, ABSPlusbyEmp, cashoutABS, cashoutABS.TOL_HOURS);
                                        }

                                        if (ABSPlusbyEmp.LeaveHours <= 0)
                                            break;
                                    }
                                }
                            }
                            else if (resigntts.Contains(EmpState.TTSCODE) && resignhcodetypelist.Count > 0)
                            {
                                foreach (var item in resignhcodetypes)
                                {
                                    if (item.失效 != null)//item.得假 != null &&
                                    {
                                        var pABS = ResignABSplusFinal.Where(p => p.NOBR == emp);/// && p.H_CODE == item.得假.H_CODE).ToList();
                                        decimal plushrs = pABS.Sum(p => p.Balance.GetValueOrDefault(0));
                                        if (plushrs > 0)
                                        {
                                            var cashoutABS = new JBModule.Data.Linq.ABS
                                            {
                                                A_NAME = string.Empty,
                                                BDATE = sd.LastDayOfAttend,//DateTime.Today,
                                                BTIME = "4800",
                                                EDATE = sd.LastDayOfAttend,//DateTime.Today,
                                                ETIME = "4800",
                                                H_CODE = item.失效.H_CODE,
                                                KEY_DATE = DateTime.Now,
                                                KEY_MAN = MainForm.USER_NAME,
                                                NOBR = emp,
                                                nocalc = false,
                                                NOTE = string.Format("由系統產生:借假沖銷作業加班時數不足時的扣假作業."),
                                                NOTEDIT = true,
                                                SERNO = string.Empty,
                                                SYSCREATE = true,
                                                SYSCREATE1 = false,
                                                TOL_DAY = 0,
                                                TOL_HOURS = ABSPlusbyEmp.LeaveHours >= plushrs ? plushrs : ABSPlusbyEmp.LeaveHours.Value,
                                                Balance = 0,
                                                Guid = Guid.NewGuid().ToString(),
                                                LeaveHours = 0,
                                                YYMM = yymm,
                                            };
                                            db.ABS.InsertOnSubmit(cashoutABS);

                                            ABSPlusbyEmp.LeaveHours = ABSPlusbyEmp.LeaveHours - cashoutABS.TOL_HOURS;
                                            ABSPlusbyEmp.Balance = ABSPlusbyEmp.Balance + cashoutABS.TOL_HOURS;

                                            decimal hrs = cashoutABS.TOL_HOURS;
                                            foreach (var p in pABS)
                                            {
                                                decimal usehrs = p.Balance >= hrs ? hrs : p.Balance.Value;
                                                p.Balance = p.Balance.Value - usehrs;
                                                p.LeaveHours = p.TOL_HOURS - p.Balance;
                                                hrs = hrs - usehrs;

                                                insertABSD(db, p, cashoutABS, usehrs);
                                                if (hrs <= 0)
                                                    break;
                                            }

                                            insertABSD(db, ABSPlusbyEmp, cashoutABS, cashoutABS.TOL_HOURS);
                                        }

                                        if (ABSPlusbyEmp.LeaveHours <= 0)
                                            break;
                                    }
                                }
                            }
                        }

                        if ((yearclose || (resignclose && resigntts.Contains(EmpState.TTSCODE))) && ABSPlusbyEmp.LeaveHours > 0)
                        {
                            var AdvanceLeaveYC = new JBModule.Data.Linq.ABS
                            {
                                A_NAME = string.Empty,
                                BDATE = sd.LastDayOfAttend,//DateTime.Today,
                                BTIME = "4800",
                                EDATE = sd.LastDayOfAttend,//DateTime.Today,
                                ETIME = "4800",
                                H_CODE = AdvanceLeaveXCode,
                                KEY_DATE = DateTime.Now,
                                KEY_MAN = MainForm.USER_NAME,
                                NOBR = emp,
                                nocalc = false,
                                NOTE = resigntts.Contains(EmpState.TTSCODE) ? string.Format("由系統產生:離職、留停及停離結算.") : string.Format("由系統產生:借假年度結算."),
                                NOTEDIT = true,
                                SERNO = string.Empty,
                                SYSCREATE = true,
                                SYSCREATE1 = false,
                                TOL_DAY = 0,
                                TOL_HOURS = ABSPlusbyEmp.LeaveHours.Value,
                                Balance = 0,
                                Guid = Guid.NewGuid().ToString(),
                                LeaveHours = 0,
                                YYMM = yymm,
                            };
                            db.ABS.InsertOnSubmit(AdvanceLeaveYC);
                            ABSPlusbyEmp.Balance = ABSPlusbyEmp.TOL_HOURS;
                            ABSPlusbyEmp.LeaveHours = 0;
                            insertABSD(db, ABSPlusbyEmp, AdvanceLeaveYC, AdvanceLeaveYC.TOL_HOURS);
                        }
                        db.SubmitChanges();
                    }
                }
                sw.Stop();
                //sw.ShowMessage();
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = string.Format("{0}.", sw.Message);
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog("Finish", parameters, this.Name, 1);
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, e.Argument, this.Name, 0);
            }
        }
        private static void insertABSD(JBModule.Data.Linq.HrDBDataContext db, JBModule.Data.Linq.ABS ABSADD, JBModule.Data.Linq.ABS ABSSUBTRACT , decimal UseHrs)
        {
            var rABSD = new JBModule.Data.Linq.ABSD();
            rABSD.ABSADD = ABSADD.Guid;
            rABSD.ABSSUBTRACT = ABSSUBTRACT.Guid;
            rABSD.USEHOUR = UseHrs;
            rABSD.KEY_MAN = MainForm.USER_NAME;
            rABSD.KEY_DATE = DateTime.Now;
            db.ABSD.InsertOnSubmit(rABSD);
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
            this.Enabled = true;
            //this.DialogResult = DialogResult.OK;
        }
    }
}
