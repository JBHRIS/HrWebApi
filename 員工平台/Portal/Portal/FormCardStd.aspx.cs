using Bll.Flow.Vdb;
using Dal;
using Dal.Dao.Flow;
using OldBll.MT.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormCardStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Card";
        protected void Page_Load(object sender, EventArgs e)
        {
            LanguageCookie = Request.Cookies["Language"]?.Value ?? "";
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
                txtDateB.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;
                SetInfoAppM();
                SetDefault();
                txtNameAppS_DataBind();
                ddlReason_DataBind();
                SetCardTime(lblNobrAppM.Text, DateTime.Now.Date);
                gvAppS.Rebind();
            }


        }
        private void SetDefault()
        {
            var rForm = (from c in dcFlow.Forms
                         where c.Code == _FormCode
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblFlowTreeID.Text = rForm.FlowTreeId;
                lblFormNoteStd.Text = rForm.NoteStd;
                Title = rForm.Name;
            }
        }
        private void SetInfoAppM()
        {
            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrAppM.Text
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                         }).FirstOrDefault();

            if (rEmpM != null)
            {
                lblRoleAppM.Text = rEmpM.RoleId;
                lblNobrAppM.Text = rEmpM.EmpNobr;
                lblNameAppM.Text = rEmpM.EmpName;
                lblDeptCodeAppM.Text = rEmpM.DeptCode;
                lblDeptNameAppM.Text = rEmpM.DeptName;
                lblJobNameAppM.Text = rEmpM.JobName;
            }
            //if (rEmpM == null)
            //{
            //    RadWindowManager1.RadAlert("人事資料有誤，請通知人事", 300, 100, "警告訊息", "", "");
            //    return;
            //}
            //Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHR.Connection);
            //var rsPortalRole = oBasDao.GetPortalRoleByNobr(lblNobrAppM.Text);
            //var PortalRole = rsPortalRole.Where(p => p.RoleCode == "Coordinator").FirstOrDefault();
            //if (PortalRole != null)
            //{
            //    txtChiNameAppS.Enabled = true;
            //    txtChiNameAppS.Visible = true;
            //    lblChiName.Visible = true;
            //    lblChiNamePS.Visible = true;
            //}
        }

        #region 載入預設資料
        private void ddlReason_DataBind()
        {
            OldDal.Dao.Att.CardLosdDao oCardLosdDao = new OldDal.Dao.Att.CardLosdDao(dcHR.Connection);
            var rs = oCardLosdDao.GetData();
            ddlReason.DataSource = rs;
            ddlReason.DataTextField = "Name";
            ddlReason.DataValueField = "Code";
            ddlReason.DataBind();
        }
        private void SetCardTime(string sNobr, DateTime dDate)
        {
            lblCardDate1.Text = "";
            lblCardDate2.Text = "";
            lblCardDate3.Text = "";
            lblCardTime1.Text = "";
            lblCardTime2.Text = "";
            lblCardTime3.Text = "";

            string Card = GetCardTime(sNobr, dDate.AddDays(-1));
            if (Card.Length > 0)
            {
                lblCardDate1.Text = dDate.AddDays(-1).ToShortDateString();
                lblCardTime1.Text = Card;
            }


            Card = GetCardTime(sNobr, dDate);
            if (Card.Length > 0)
            {
                lblCardDate2.Text = dDate.ToShortDateString();
                lblCardTime2.Text = Card;
            }

            Card = GetCardTime(sNobr, dDate.AddDays(1));
            if (Card.Length > 0)
            {
                lblCardDate3.Text = dDate.AddDays(1).ToShortDateString();
                lblCardTime3.Text = Card;
            }

            if (lblCardTime1.Text == "" && lblCardTime2.Text == "" && lblCardTime3.Text == "")
            {
                if (LanguageCookie != null && LanguageCookie != "")
                    lblCardTime1.Text = oShareDictionary.TextTranslate("ErrorMsg", "WithoutAttendData", "1", LanguageCookie);
                else
                    lblCardTime1.Text = "無出勤資料";
            }
        }
        private string GetCardTime(string sNobr, DateTime dDate)
        {
            string Card = "";

            OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
            var rsCard = oCardDao.GetData(sNobr, dDate.Date);
            if (rsCard.Count > 0)
            {
                Card = dDate.ToShortDateString() + "-";

                foreach (var rCard in rsCard)
                    Card += rCard.OnTime + ",";
            }

            return Card;
        }
        public void txtNameAppS_DataBind()
        {
            var CardOnlyShowSelf = (from c in dcFlow.FormsExtend
                                    where c.FormsCode == "Card" && c.Code == "CardOnlyShowSelf" && c.Active == true
                                    select c).FirstOrDefault();
            if (CardOnlyShowSelf == null)
            {
                var rs = AccessData.GetPeopleByDeptTree(_User, CompanySetting);
                var rs1 = AccessData.GetDeptListEmp(_User, CompanySetting);
                var result = rs.Union(rs1).ToList();
                var key = new Dictionary<string, string>();
                foreach (var r in result.ToArray())
                {
                    if (key.ContainsKey(r.Value))
                    {
                        result.Remove(r);
                    }
                    else
                    {
                        key.Add(r.Value, r.Value);
                    }
                }

                txtNameAppS.DataSource = result;
                txtNameAppS.DataTextField = "Text";
                txtNameAppS.DataValueField = "Value";
                txtNameAppS.DataBind();
            }
            else
            {
                var result = new List<Bll.TextValueRow>();
                var rs = new Bll.TextValueRow();
                rs.Text = _User.EmpName + "," + _User.EmpId;
                rs.Value = _User.EmpId;
                result.Add(rs);
                txtNameAppS.DataSource = result;
                txtNameAppS.DataTextField = "Text";
                txtNameAppS.DataValueField = "Value";
                txtNameAppS.DataBind();
            }

        }
        #endregion

        #region 被申請人姓名
        protected void txtNameAppS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetName(e.Text);
        }
        protected void txtNameAppS_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetName(lblNobrAppM.Text);
        }
        protected void txtNameAppS_TextChanged(object sender, EventArgs e)
        {
            RadComboBox txt = sender as RadComboBox;
            RadComboBoxItem li = txt.SelectedItem;

            if (li != null)
                SetName(li);
            else if (txtNameAppS.Text.Trim().Length > 0)
            {
                SetName(txtNameAppS.Text);
            }

        }
        private void SetName(RadComboBoxItem li)
        {
            if (li != null)
            {
                txtNameAppS.ClearSelection();
                li.Selected = true;
                SetName(li.Value);
            }
        }
        private void SetName(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

            var rBas = oBasDao.GetBase(sNobr).FirstOrDefault();
            if (rBas != null)
            {
                lblNobrAppS.Text = rBas.Nobr;
                txtNameAppS.Text = rBas.Name;
                txtNameAppS.ToolTip = rBas.Name;
            }
            else
                txtNameAppS.Text = txtNameAppS.ToolTip;

        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //var rSysVar = (from c in dcFlow.SysVar
                //               select c).FirstOrDefault();

                var oSysVarDao = new SysVarDao();
                var SysVarCond = new SysVarConditions();

                SysVarCond.AccessToken = _User.AccessToken;
                SysVarCond.RefreshToken = _User.RefreshToken;
                SysVarCond.CompanySetting = CompanySetting;
                var rsSysVar = oSysVarDao.GetData(SysVarCond);
                var rSysVar = new SysVarRow();
                if (rsSysVar.Status)
                {
                    if (rsSysVar.Data != null)
                    {
                        rSysVar = rsSysVar.Data as SysVarRow;
                        if (rSysVar.SysClose)
                        {
                            if (LanguageCookie != null && LanguageCookie != "")
                                lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "SystemMaintain", "1", LanguageCookie);
                            else
                                lblErrorMsg.Text = "系統維護中，請稍後再送出表單";
                            return;
                        }
                    }
                }
                if (txtDateB.SelectedDate == null)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "DateInputError", "1", LanguageCookie);
                    else
                        lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                    return;
                }

                if (txtTimeB.Text.Length != 4)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "DateInputError", "1", LanguageCookie);
                    else
                        lblErrorMsg.Text = "您的開始或結束時間沒有輸入正確";
                    return;
                }

                string Nobr = lblNobrAppS.Text;
                string NobrAgent1 = lblNobrAgent1.Text;
                DateTime Date = txtDateB.SelectedDate.Value;
                string Time = txtTimeB.Text;
                string Note = txtNote.Text.Trim();
                DateTime DateTimeB = Date.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(Time));
                string CardLost = ddlReason.Text;

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
                var rAttendDate = oAttendDao.GetAttendH(Nobr, Date).FirstOrDefault();
                if (rAttendDate == null)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "AttendDataError", "1", LanguageCookie);
                    else
                        lblErrorMsg.Text = "出勤資料錯誤，請洽人事單位";
                    return;
                }

                //DateTime AppDate = Convert.ToDateTime(rAttendDate.Text);

                //if (DateB < AppDate)
                //{
                //    RadWindowManager1.RadAlert("您所申請的日期必須是前一次出勤日之後，請洽人事單位", 300, 100, "警告訊息", "", "");
                //    return;
                //}

                //檢查重複的資料
                var rsAppS = (from c in dcFlow.FormsAppCard
                              where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == Nobr
                              && c.DateB == Date
                              && c.TimeB == Time
                              select c).ToList();

                if (rsAppS.Any())
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "DataRepeat", "1", LanguageCookie);
                    else
                        lblErrorMsg.Text = "資料重複或流程正在進行中";
                    return;
                }

                OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
                var rCard = oCardDao.GetData(Nobr, Date, Time).FirstOrDefault();

                if (rCard != null)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "PesonnelDataRepeat", "1", LanguageCookie);
                    else
                        lblErrorMsg.Text = "人事資料重複";
                    return;
                }

                DateTime DateB = Date;
                DateTime DateE = Date;
                string TimeB = Time;
                string TimeE = Time;

                //判定是否有超過三次

                //借用加班的24轉48來判定日期
                OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
                oOtDao.ConvertTime24To48(Nobr, ref DateB, ref DateE, ref TimeB, ref TimeE);

                OldDal.Dao.Sal.SalaryLockDao oSalaryLockDao = new OldDal.Dao.Sal.SalaryLockDao(dcHR.Connection);
                var TwoDate = oSalaryLockDao.GetSalDate(DateB);

                var lsDate = oAttendDao.GetAttendByForgetNum(Nobr, TwoDate.DateA, TwoDate.DateD);
                var rsAppForGet = (from c in dcFlow.FormsAppCard
                                   where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                                   && c.EmpId == Nobr
                                   && c.DateTimeB <= TwoDate.DateD
                                   && c.DateTimeB >= TwoDate.DateA
                                   select c).ToList();
                TextValueRow tv;
                var rDate = lsDate.Where(p => p.Text == DateB.ToShortDateString()).FirstOrDefault();
                if (rDate != null)
                    rDate.Value = (Convert.ToInt32(rDate.Value)).ToString();
                else
                {
                    tv = new TextValueRow();
                    tv.Text = DateB.ToShortDateString();
                    tv.Value = "1";
                    lsDate.Add(tv);
                }

                foreach (var r in rsAppForGet)
                {
                    DateB = r.DateB;
                    DateE = r.DateB;
                    TimeB = r.TimeB;
                    TimeE = r.TimeB;

                    oOtDao.ConvertTime24To48(Nobr, ref DateB, ref DateE, ref TimeB, ref TimeE);

                    rDate = lsDate.Where(p => p.Text == DateB.ToShortDateString()).FirstOrDefault();

                    //抓取請假時間去判斷忘刷次數

                    OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                    var rsAbs = oAbsDao.GetAbs(Nobr, DateB, DateE);
                    if (rsAbs.Count() != 0)
                    {
                        if (rsAbs.First().DateB != DateB || rsAbs.First().DateE != DateE || rsAbs.First().DateTimeB.ToString() != TimeB || rsAbs.First().DateTimeE.ToString() != TimeE)
                        {
                            if (rDate != null)
                                rDate.Value = (Convert.ToInt32(rDate.Value)).ToString();
                            else
                            {
                                tv = new TextValueRow();
                                tv.Text = DateB.ToShortDateString();
                                tv.Value = "1";
                                lsDate.Add(tv);
                            }
                        }
                    }
                    else
                    {
                        if (rDate != null)
                            rDate.Value = (Convert.ToInt32(rDate.Value)).ToString();
                        else
                        {
                            tv = new TextValueRow();
                            tv.Text = DateB.ToShortDateString();
                            tv.Value = "1";
                            lsDate.Add(tv);
                        }
                    }
                }

                int i = lsDate.Sum(p => Convert.ToInt32(p.Value));
                var ForgetTime = (from c in dcFlow.FormsExtend
                                  where c.Active && c.FormsCode == "Card" && c.Code == "ForgetTime"
                                  select c.Column1).FirstOrDefault();

                var ForgetCheck = (from c in dcFlow.FormsExtend
                                   where c.Active && c.FormsCode == "Card" && c.Code == "ForgetCheck"
                                   select c.Column1).FirstOrDefault();
                

                if (ForgetCheck != null)
                {
                    var Count = 0; 
                    var lsCardCode = ForgetCheck.Split(';').ToList();
                    for (var ADate = TwoDate.DateA; ADate <= TwoDate.DateD; ADate = ADate.AddDays(1))
                    {
                        var CardData = oCardDao.GetData(Nobr, ADate).GroupBy(p => p.DateA).ToList();
                        foreach (var CardTime in CardData)
                        {
                            if (lsDate.Where(p => p.Text == CardTime.Key.ToShortDateString()).Any())
                                foreach (var Data in CardTime)
                                {
                                    if (Data.Los && lsCardCode.Contains(Data.Reason))
                                    {
                                        Count++;
                                        break;
                                    }
                                    else if (Data.Los)
                                    {
                                        var Forget = lsDate.Where(p => p.Text == CardTime.Key.ToShortDateString()).Select(p => p.Value).FirstOrDefault();
                                        Count += Convert.ToInt32(Forget);
                                        break;
                                    }
                                }
                        }
                    }
                    if (ForgetTime != null && Count >= Convert.ToInt32(ForgetTime))
                    {
                        lblErrorMsg.Text = "本月的忘刷次數已超過" + ForgetTime + "次";
                        return;
                    }
                }

                else if (ForgetTime != null && i > Convert.ToInt32(ForgetTime))
                {
                    lblErrorMsg.Text = "本月的忘刷次數已超過" + ForgetTime + "次";
                    return;
                }

                var rEmpS = (from role in dcFlow.Role
                             join emp in dcFlow.Emp on role.Emp_id equals emp.id
                             join dept in dcFlow.Dept on role.Dept_id equals dept.id
                             join pos in dcFlow.Pos on role.Pos_id equals pos.id
                             where role.Emp_id == Nobr
                             select new
                             {
                                 RoleId = role.id,
                                 EmpNobr = emp.id,
                                 EmpName = emp.name,
                                 DeptCode = dept.id,
                                 DeptName = dept.name,
                                 JobCode = pos.id,
                                 JobName = pos.name,
                                 Auth = role.deptMg.Value,
                             }).FirstOrDefault();

                var rEmpM = (from role in dcFlow.Role
                             join emp in dcFlow.Emp on role.Emp_id equals emp.id
                             join dept in dcFlow.Dept on role.Dept_id equals dept.id
                             join pos in dcFlow.Pos on role.Pos_id equals pos.id
                             where role.Emp_id == lblNobrAppM.Text
                             select new
                             {
                                 RoleId = role.id,
                                 EmpNobr = emp.id,
                                 EmpName = emp.name,
                                 DeptCode = dept.id,
                                 DeptName = dept.name,
                                 JobCode = pos.id,
                                 JobName = pos.name,
                                 Auth = role.deptMg.Value,
                             }).FirstOrDefault();

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rBasS = oBasDao.GetBaseByNobr(Nobr, DateTime.Now.Date).FirstOrDefault();

                var rBasAgent1 = oBasDao.GetBase(NobrAgent1).FirstOrDefault();

                var Code = Guid.NewGuid().ToString();

                var rsFormsAppCard = new FormsAppCard();
                rsFormsAppCard.Code = Code;
                rsFormsAppCard.ProcessID = lblProcessID.Text;
                rsFormsAppCard.idProcess = 0;
                rsFormsAppCard.EmpId = rEmpS.EmpNobr;
                rsFormsAppCard.EmpName = rEmpS.EmpName;
                rsFormsAppCard.DeptCode = rEmpS.DeptCode;
                rsFormsAppCard.DeptName = rEmpS.DeptName;
                rsFormsAppCard.JobCode = rEmpS.JobCode;
                rsFormsAppCard.JobName = rEmpS.JobName;
                rsFormsAppCard.RoleId = rEmpS.RoleId;
                rsFormsAppCard.DateTimeB = DateTimeB;
                rsFormsAppCard.DateTimeE = DateTimeB;
                rsFormsAppCard.DateB = Date;
                rsFormsAppCard.DateE = Date;
                rsFormsAppCard.TimeB = Time;
                rsFormsAppCard.TimeE = Time;
                rsFormsAppCard.CardLostCode = ddlReason.SelectedValue;
                rsFormsAppCard.CardLostName = CardLost;
                rsFormsAppCard.Sign = true;
                rsFormsAppCard.SignState = "0";
                rsFormsAppCard.Note = txtNote.Text;
                rsFormsAppCard.Status = "1";
                rsFormsAppCard.InsertMan = lblNobrAppM.Text;
                rsFormsAppCard.InsertDate = DateTime.Now;
                rsFormsAppCard.UpdateDate = null;
                rsFormsAppCard.UpdateMan = null;

                var rsFormsAppInfo = new FormsAppInfo()
                {
                    Code = Code,
                    EmpId = rEmpS.EmpNobr,
                    EmpName = rEmpS.EmpName,
                    idProcess = 0,
                    ProcessId = lblProcessID.Text,
                    KeyDate = DateTime.Now,
                    SignState = "1",
                    InfoSign = rsFormsAppCard.EmpName + "," + rsFormsAppCard.DateB.ToShortDateString() + "," + rsFormsAppCard.TimeB + "," + rsFormsAppCard.Note,
                    InfoMail = MessageSendMail.CardBody(rsFormsAppCard.EmpId, rsFormsAppCard.EmpName, rsFormsAppCard.DeptName, rsFormsAppCard.DateB, rsFormsAppCard.TimeB, rsFormsAppCard.Note)
                };


                dcFlow.FormsAppCard.InsertOnSubmit(rsFormsAppCard);
                dcFlow.FormsAppInfo.InsertOnSubmit(rsFormsAppInfo);

                dcFlow.SubmitChanges();


                gvAppS.Rebind();
                //var Script = "$(document).ready(function() {$('.footable').footable();});";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
                Session["sProcessID"] = lblProcessID.Text;
                Session["FormCode"] = _FormCode;
                Session["FlowTreeID"] = lblFlowTreeID.Text;

                if (LanguageCookie != null && LanguageCookie != "")
                    lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "AddSuccess", "1", LanguageCookie);
                else
                    lblNotifyMsg.Text = "新增成功";
            }
            catch (Exception)
            {
                if (LanguageCookie != null && LanguageCookie != "")
                    lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "AddFailed", "1", LanguageCookie);
                else
                    lblNotifyMsg.Text = "新增失敗";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var cn = ((RadButton)sender).CommandName;
            var ca = ((RadButton)sender).CommandArgument;
            var Code = (from c in dcFlow.FormsAppCard
                        where c.AutoKey.ToString() == ca
                        select c.Code).FirstOrDefault();
            UnobtrusiveSession.Session["FormGuidCode"] = Code;

            ucFileManage._lblKey.Text = ca;
            ucFileManage._lvMain.Rebind();
        }

        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppCard
                      where c.ProcessID == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void gvAppS_DataBound(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in gvAppS.Items)
            {
                var No = item.FindControl("lblListNumber") as RadLabel;
                if (No != null)
                {
                    count++;
                    No.Text = count.ToString();
                }

            }
            var lblAbsCount = gvAppS.FindControl("lblCount") as RadLabel;
            if (lblAbsCount != null)
                lblAbsCount.Text = count.ToString();
        }

        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppCard
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();

            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppCard.DeleteOnSubmit(r);

                    dcFlow.SubmitChanges();
                    if (LanguageCookie != null && LanguageCookie != "")
                        lblErrorMsg.Text = oShareDictionary.TextTranslate("ErrorMsg", "DeleteSuccess", "1", LanguageCookie);
                    else
                        lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }

        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            string Nobr = lblNobrAppS.Text;
            DateTime Date = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

            SetCardTime(Nobr, Date);
        }
    }
}