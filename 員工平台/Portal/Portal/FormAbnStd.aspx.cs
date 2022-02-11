using Bll.Flow.Vdb;
using Dal;
using Dal.Dao.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormAbnStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Abn";
        public static List<OldBll.Att.Vdb.AbsDataTable> result = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
                //txtDateB.SelectedDate = DateTime.Now.Date;
                //txtDateE.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;
                SetInfoAppM();
                SetDate();
                SetDefault();
                SetReason_DataBind();
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
                //lblNote.Text = rForm.sStdNote;
                Title = rForm.Name;
            }
        }
        private void SetDate()
        {
            var DateB = DateTime.Now;
            for (int i = 1; i <= 12; i++)
                ddlMonth.Items.Add(new RadComboBoxItem(i.ToString(), i.ToString()));
            ddlYear.Items.Add(new RadComboBoxItem(DateB.AddYears(-1).Year.ToString(), DateB.AddYears(-1).Year.ToString()));
            ddlYear.Items.Add(new RadComboBoxItem(DateB.Year.ToString(), DateB.Year.ToString()));
            ddlYear.Items.Add(new RadComboBoxItem(DateB.AddYears(1).Year.ToString(), DateB.AddYears(1).Year.ToString()));
            ddlYear.SelectedValue = DateB.Year.ToString();
            ddlMonth.SelectedValue = DateB.Month.ToString();
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
        private void SetReason_DataBind()
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var ReasonList = oAttendDao.GetAttendCheckRemarkType();
            foreach (var Reason in ReasonList)
            { 
                ddlReason.Items.Add(new RadComboBoxItem(Reason.Text, Reason.Value));
            }
            var AbnData = oAttendDao.GetAttendCheckType();
            isEarlyCome.CommandArgument = AbnData[0].Value;
            //isEarlyCome.Text = AbnData[0].Text;
            isLateOut.CommandArgument = AbnData[1].Value;
            //isLateOut.Text = AbnData[1].Text;
        }
        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var lvData = sender as RadListView;
            var Item = e.EventSource as RadCheckBox;
            var lvItem = Item.NamingContainer as RadListViewDataItem;
            var index = lvItem.DataItemIndex;
            foreach (var d in gvAppS.Items)
            {
                //var isEarlyCome = d.FindControl("isEarlyCheck") as RadCheckBox;
                //var isLateOut = d.FindControl("isLateCheck") as RadCheckBox;
                //var ADate = d.FindControl("lblDate") as RadLabel;
                //var FormCode = isEarlyCome.CommandArgument;
                //var Exsist = (from c in dcFlow.FormsAppAbn
                //              where c.Code == FormCode
                //              select c).FirstOrDefault();
                //if (Exsist != null)//如果有的話就更新
                //{
                //    if (isEarlyCome.Checked == true || isLateOut.Checked == true)
                //    {
                //        Exsist.IsEarlyWork = (bool)isEarlyCome.Checked;

                //        Exsist.IsLateOut = (bool)isLateOut.Checked;
                //    }
                //}
                //else //沒有就新增
                //{ 
                    
                //}
            }
            var isEarlyCome = lvData.Items[index].FindControl("isEarlyCheck") as RadCheckBox;
            var isLateOut = lvData.Items[index].FindControl("isLateCheck") as RadCheckBox;
            var ADate = lvData.Items[index].FindControl("lblDate") as RadLabel;
            var FormCode = isEarlyCome.CommandArgument;
            var Exsist = (from c in dcFlow.FormsAppAbn
                          where c.Code == FormCode
                          select c).FirstOrDefault();
            if (Exsist != null)//如果有的話就更新
            {
                if (isEarlyCome.Checked == true || isLateOut.Checked == true)
                {
                    Exsist.IsEarlyWork = (bool)isEarlyCome.Checked;
                    Exsist.EarlyWorkMin = (bool)isEarlyCome.Checked ? Convert.ToInt32(isEarlyCome.CommandName) : 0;
                    Exsist.IsLateOut = (bool)isLateOut.Checked;
                    Exsist.LateOutMin = (bool)isLateOut.Checked ? Convert.ToInt32(isLateOut.CommandName) : 0;
                    Exsist.UpdateDate = DateTime.Now;
                    Exsist.UpdateMan = _User.EmpName;
                }
                else
                {
                    var infoData = (from c in dcFlow.FormsAppInfo
                                    where c.Code == FormCode
                                    select c).FirstOrDefault();
                    if (infoData != null)
                        dcFlow.FormsAppInfo.DeleteOnSubmit(infoData);
                    dcFlow.FormsAppAbn.DeleteOnSubmit(Exsist);
                }
                dcFlow.SubmitChanges();
            }
            else //沒有就新增
            {
                if (isEarlyCome.Checked == true || isLateOut.Checked == true)
                {
                    var oFormsAppAbn = new FormsAppAbn();
                    oFormsAppAbn.EmpName = _User.EmpName;
                    oFormsAppAbn.EmpId = _User.EmpId;
                    oFormsAppAbn.DeptName = _User.EmpDeptName;
                    oFormsAppAbn.Code = FormCode;
                    oFormsAppAbn.ProcessId = lblProcessID.Text;
                    oFormsAppAbn.idProcess = 0;
                    oFormsAppAbn.DateB = Convert.ToDateTime(ADate.Text);
                    oFormsAppAbn.RoleId = lblRoleAppM.Text;
                    oFormsAppAbn.DeptCode = lblDeptCodeAppM.Text;
                    oFormsAppAbn.DeptName = lblDeptNameAppM.Text;
                    oFormsAppAbn.JobCode = lblJobCodeAppM.Text;
                    oFormsAppAbn.JobName = lblJobNameAppM.Text;
                    oFormsAppAbn.IsEarlyWork = (bool)isEarlyCome.Checked;
                    oFormsAppAbn.EarlyWorkMin = (bool)isEarlyCome.Checked ? Convert.ToInt32(isEarlyCome.CommandName) : 0;
                    oFormsAppAbn.IsLateOut = (bool)isLateOut.Checked;
                    oFormsAppAbn.LateOutMin = (bool)isLateOut.Checked ? Convert.ToInt32(isLateOut.CommandName) : 0;
                    oFormsAppAbn.AbnCode = ddlReason.SelectedValue;
                    oFormsAppAbn.Sign = true;
                    oFormsAppAbn.SignState = "1";
                    oFormsAppAbn.Note = ddlReason.Text;
                    oFormsAppAbn.Status = "1";
                    oFormsAppAbn.UpdateDate = DateTime.Now;
                    oFormsAppAbn.UpdateMan = _User.EmpName;
                    oFormsAppAbn.InsertDate = DateTime.Now;
                    oFormsAppAbn.InsertMan = _User.EmpName;
                    dcFlow.FormsAppAbn.InsertOnSubmit(oFormsAppAbn);

                    var oFormsAppInfo = new FormsAppInfo();
                    oFormsAppInfo.Code = FormCode;
                    oFormsAppInfo.EmpId = _User.EmpId;
                    oFormsAppInfo.EmpName = _User.EmpName;
                    oFormsAppInfo.idProcess = 0;
                    oFormsAppInfo.ProcessId = lblProcessID.Text;
                    oFormsAppInfo.KeyDate = DateTime.Now;
                    oFormsAppInfo.SignState = "1";
                    oFormsAppInfo.InfoSign = oFormsAppAbn.EmpName + "," + oFormsAppAbn.DateB.ToShortDateString() + "," + (oFormsAppAbn.IsEarlyWork ? "早來" + oFormsAppAbn.EarlyWorkMin + "分鐘" : "") + (oFormsAppAbn.IsLateOut ? "晚退" + oFormsAppAbn.LateOutMin + "分鐘" : "");
                    oFormsAppInfo.InfoMail = MessageSendMail.AbnBody(oFormsAppAbn.EmpId, oFormsAppAbn.EmpName, oFormsAppAbn.DeptName, oFormsAppAbn.DateB, "");
                    dcFlow.FormsAppInfo.InsertOnSubmit(oFormsAppInfo);

                    dcFlow.SubmitChanges();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            plReason.Visible = false;
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            List<string> listEmpId = new List<string>();
            var DateB = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), 1);
            var DateE = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue)));
            listEmpId.Add(_User.EmpId);
            var listAbn = oAttendDao.GetAttendAbnormal(listEmpId, DateB, DateE);
            var listAbnCheck = oAttendDao.GetAttendCheck(listEmpId, DateB, DateE);

            var result = new List<FormAppAbnRow>();
            foreach (var c in listAbnCheck)//將已申請的單子拿掉
            {
                foreach (var d in listAbn)
                {
                    if (c.Nobr == d.Nobr && c.DateA == d.DateA && c.Type == d.Type)
                    {
                        listAbn.Remove(d);
                        break;
                    }
                }
            }
            if (listAbn.Count != 0)
            {
                plReason.Visible = true;
                var gListAbn = listAbn.GroupBy(p => p.DateA.Date).OrderBy(p => p.Key).ToList();
                foreach (var type in gListAbn)
                {
                    bool Ear = false;
                    bool Lat = false;
                    int Ear_Min = 0;
                    int Lat_Min = 0;
                    bool Ear_Enabled = false;
                    bool Lat_Enabled = false;
                    //bool DB = false;

                    foreach (var Dat in type)
                    {
                        bool Ear_finish = false;
                        bool Lat_finish = false;
                        var DB_Check = (from Check_Date in dcFlow.FormsAppAbn
                                        where Check_Date.EmpId == lblNobrAppM.Text && Check_Date.DateB == Dat.DateA
                                        select new
                                        {
                                            isInFlow = (Check_Date.idProcess != 0 && Check_Date.SignState != "2"),
                                            Date = Check_Date.DateB,
                                            bEarly = Check_Date.IsEarlyWork,
                                            bLate = Check_Date.IsLateOut,
                                            State = Check_Date.SignState
                                        }).ToList();
                        foreach (var DB_CheckList in DB_Check)
                        {
                            //DB = true;
                            if (DB_CheckList.bEarly == true && DB_CheckList.State == "1" && DB_CheckList.isInFlow)
                                Ear_Enabled = true;
                            if (DB_CheckList.bEarly == true && DB_CheckList.State == "3" && DB_CheckList.isInFlow)
                                Ear_finish = true;
                            if (DB_CheckList.bLate == true && DB_CheckList.State == "1" && DB_CheckList.isInFlow)
                                Lat_Enabled = true;
                            if (DB_CheckList.bLate == true && DB_CheckList.State == "3" && DB_CheckList.isInFlow)
                                Lat_finish = true;
                        }
                        if (Dat.Type == isEarlyCome.CommandArgument && (bool)isEarlyCome.Checked && !Ear_finish)
                        {
                            Ear = true;
                            Ear_Min = Dat.ErrorMins;
                        }
                        if (Dat.Type == isLateOut.CommandArgument && (bool)isLateOut.Checked && !Lat_finish)
                        {
                            Lat = true;
                            Lat_Min = Dat.ErrorMins;
                        }
                    }

                    if (Ear == true || Lat == true)
                        result.Add(new FormAppAbnRow
                        {
                            ADate = type.Key,
                            //Ear = Ear,
                            //Lat = Lat,
                            EarlyTime = Ear_Min.ToString(),
                            LateTime = Lat_Min.ToString(),
                            isEarlyInProcess = Ear_Enabled,
                            isLateInProcess = Lat_Enabled,
                            //Check_DB = DB
                        });
                }
            }


            gvAppS.DataSource = result;

            Session["sProcessID"] = lblProcessID.Text;
            Session["FormCode"] = _FormCode;
            Session["FlowTreeID"] = lblFlowTreeID.Text;
        }

        protected void gvAppS_DataBound(object sender, EventArgs e)
        {
            LanguageCookie = Request.Cookies["Language"]?.Value ?? "";
            var ListView = sender as RadListView;
            var DataS = ListView.DataSource as List<FormAppAbnRow>;
            var Count = 0;
            foreach (var item in ListView.Items)
            {
                var isEarlyCheck = item.FindControl("isEarlyCheck") as RadCheckBox;
                var isLateCheck = item.FindControl("isLateCheck") as RadCheckBox;
                if (DataS[Count].isEarlyInProcess)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        isEarlyCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "DataInFlow", "1", LanguageCookie);
                    else
                        isEarlyCheck.Text = "流程進行中";
                }
                else
                {
                    if (DataS[Count].EarlyTime == "0")
                    {
                        if (LanguageCookie != null && LanguageCookie != "")
                            isEarlyCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "NoEarlyRecord", "1", LanguageCookie);
                        else
                            isEarlyCheck.Text = "無早到紀錄";
                    }
                    else
                    {
                        if (LanguageCookie != null && LanguageCookie != "")
                            isEarlyCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "Early", "1", LanguageCookie) + DataS[Count].EarlyTime + " minutes";
                        else
                            isEarlyCheck.Text = "早到" + DataS[Count].EarlyTime + "分鐘";
                    }
                }
                if (DataS[Count].isEarlyInProcess || DataS[Count].EarlyTime == "0")
                    isEarlyCheck.Enabled = false;
                if (DataS[Count].isLateInProcess)
                {
                    if (LanguageCookie != null && LanguageCookie != "")
                        isLateCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "DataInFlow", "1", LanguageCookie);
                    else
                        isLateCheck.Text = "流程進行中";
                }
                else
                {
                    if (DataS[Count].LateTime == "0")
                    {
                        if (LanguageCookie != null && LanguageCookie != "")
                            isLateCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "NoLateRecord", "1", LanguageCookie);
                        else
                            isLateCheck.Text = "無晚退紀錄";
                    }
                    else
                    {

                        if (LanguageCookie != null && LanguageCookie != "")
                            isLateCheck.Text = oShareDictionary.TextTranslate("ErrorMsg", "Late", "1", LanguageCookie) + DataS[Count].LateTime + "minutes";
                        else
                            isLateCheck.Text = "晚退" + DataS[Count].LateTime + "分鐘";
                    }
                }
                if (DataS[Count].isLateInProcess || DataS[Count].LateTime == "0")
                    isLateCheck.Enabled = false;
                Count++;
            }
        }
    }
}