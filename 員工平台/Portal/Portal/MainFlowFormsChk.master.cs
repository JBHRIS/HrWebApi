using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Dal;
using Dal.Dao.Flow;
using Bll.Flow.Vdb;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Bll;
using System.ComponentModel;

namespace Portal
{
    public partial class MainFlowFormsChk : WebPageMasterPage
    {
        public event EventHandler Finish_Click;
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        string FormCode = "";
        bool isDirect = false;
        private CompanySettingRow CompanySetting;
        private string LanguageCookie = "";
        private ShareDictionaryDao oShareDictionary = new ShareDictionaryDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
            {
                if (UnobtrusiveSession.Session["CompanySetting"] != null)
                {
                    var CompanySstting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                    this.CompanySetting = CompanySstting;

                    dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                    dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                }
                else
                {
                    var CompanyId = Request.Cookies["CompanyId"].Value;
                    var oShareCompany = new ShareCompanyDao();
                    var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
                    this.CompanySetting = CompanySetting;
                    dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                    dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                }
            }
            if (!IsPostBack)
            {
                LanguageCookie = Request.Cookies["Language"]?.Value ?? "";

                lblEmpName.Text = _User.EmpName + "," + _User.EmpId;
                lblDept.Text = _User.EmpDeptName;

                if (Request.QueryString["ProcessApParmAuto"] != null || Request.QueryString["ProcessApViewAuto"] != null)
                {
                    string RequestValue = "";
                    if (Request.QueryString["ProcessApParmAuto"] != null)
                        RequestValue = UnobtrusiveSession.Session["ProcessApParmAuto"].ToString();
                    else if (Request.QueryString["ProcessApViewAuto"] != null)
                        RequestValue = UnobtrusiveSession.Session["ProcessApViewAuto"].ToString();

                    string RequestName = "";
                    RequestName = UnobtrusiveSession.Session["RequestName"].ToString();
                    int ApKey = 0;
                    int pid = 0;
                    if (int.TryParse(RequestValue, out pid))
                    {
                        ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

                        lblApKey.Text = pid.ToString();

                        if (RequestName == "ApParm")
                        {
                            ApKey = pid;
                            var rGetAp = oService.GetApParm(pid);
                            if (rGetAp.ProcessFlow_id != 0)
                            {
                                pid = rGetAp.ProcessFlow_id;

                                //反推是否已經簽核結束
                                var rProcessNode = (from c in dcFlow.ProcessNode
                                                    where c.auto == rGetAp.ProcessNode_auto
                                                    select c).FirstOrDefault();

                                if (rProcessNode != null && !rProcessNode.isFinish.GetValueOrDefault(true))
                                {
                                    btnSubmit.Visible = true;
                                    lblManage.Text = "1";
                                }
                            }
                        }
                        else if (RequestName == "View")
                        {
                            btnReturn.Visible = true;
                            btnSubmit.Visible = false;
                            return;
                            //ApKey = pid;
                            //var rGetAp = oService.GetApParm(pid);
                            //if (rGetAp.ProcessFlow_id != 0)
                            //{
                            //    pid = rGetAp.ProcessFlow_id;

                            //    //反推是否已經簽核結束
                            //    var rProcessNode = (from c in dcFlow.ProcessNode
                            //                        where c.auto == rGetAp.ProcessNode_auto
                            //                        select c).FirstOrDefault();

                            //    if (rProcessNode != null && !rProcessNode.isFinish.GetValueOrDefault(true))
                            //    {
                            //        lblManage.Text = "1";
                            //    }
                            //}
                        }
                    }

                    lblProcessID.Text = pid.ToString();

                    //用ProcessID找出應該要簽核的人 並比對是否與登入的人一致
                    var rProcessCheck = (from pn in dcFlow.ProcessNode
                                         join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                         where pn.ProcessFlow_id == pid
                                         && !pn.isFinish.GetValueOrDefault(true)
                                         orderby pn.adate descending
                                         select pc).FirstOrDefault();

                    if (rProcessCheck != null)
                    {
                        //如果需要判斷是否為真正的主管簽核 此行要拿掉
                        lblNobrSign.Text = lblNobrSign.Text.Trim().Length > 0 ? lblNobrSign.Text : rProcessCheck.Emp_idDefault;
                        lblUserInfo.Text += "@Sign:" + lblNobrSign.Text;

                        if (lblNobrSign.Text == rProcessCheck.Emp_idDefault || lblNobrSign.Text == rProcessCheck.Emp_idAgent)
                        {
                            var rRole = (from r in dcFlow.Role
                                         join d in dcFlow.Dept on r.Dept_id equals d.id
                                         where r.id == rProcessCheck.Role_idDefault
                                         && r.Emp_id == rProcessCheck.Emp_idDefault
                                         select new
                                         {
                                             RoleId = r.id,
                                             EmpNobr = r.Emp_id,
                                             DeptTree = d.DeptLevel_id,
                                         }).FirstOrDefault();

                            if (rRole != null)
                            {
                                if (ApKey != 0)
                                {
                                    //寫回ApParm
                                    var rProcessApParm = (from c in dcFlow.ProcessApParm
                                                          where c.auto == ApKey
                                                          && c.ProcessFlow_id == pid
                                                          && c.ProcessCheck_auto == rProcessCheck.auto
                                                          && c.ProcessNode_auto == rProcessCheck.ProcessNode_auto
                                                          select c).FirstOrDefault();

                                    if (rProcessApParm != null)
                                    {
                                        rProcessApParm.Role_id = rProcessCheck.Role_idDefault;
                                        rProcessApParm.Emp_id = rProcessCheck.Emp_idDefault;

                                        dcFlow.SubmitChanges();
                                    }
                                }

                                lblDeptTree.Text = Convert.ToInt32(rRole.DeptTree).ToString();
                            }
                        }
                    }
                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {



            if (Finish_Click != null)//Contentpage所註冊的新增表身動作
            {
                //Submit_Click(this, EventArgs.Empty);
            }
            else
            {

            }



            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();



            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            FormCode = rAppM.FormsCode;




            //var AbsFormTable = dcFlow.wfAppAbs;
            //var OtFormTable = dcFlow.wfAppOt;
            //var AbscFormTable = dcFlow.wfAppAbsc;
            //var CardFormTable = dcFlow.wfAppCard;
            //var FormTable = new List<T>();
            switch (FormCode)
            {
                case "Abs":
                    AbsFinish();
                    break;
                case "Abs1":
                    Abs1Finish();
                    break;
                case "Ot":
                    OtFinish();
                    break;
                case "Ot1":
                    Ot1Finish();
                    break;
                case "OvtB":
                    OvtBFinish();
                    break;
                case "Ovt":
                    OvtFinish();
                    break;
                case "Absc":
                    AbscFinish();
                    break;
                case "Card":
                    CardFinish();
                    break;
                case "ShiftShort":
                    ShiftShortFinish();
                    break;
                case "ShiftLong":
                    ShiftLongFinish();
                    break;
                case "Abn":
                    AbnFinish();
                    break;
                case "Employ":
                    EmployFinish();
                    break;
                case "EmployApprove":
                    EmployApproveFinish();
                    break;
                case "Appoint":
                    AppointFinish();
                    break;

            }
            var ToFormSign = (from c in dcFlow.FormsExtend
                              where c.FormsCode == "Common" && c.Code == "ToFormSign" && c.Active == true
                              select c).FirstOrDefault();
            if (isDirect && ToFormSign != null)
            {
                if (ToFormSign.Column1 == null)
                    Response.Redirect("~/FormSign.aspx");
                else
                    Response.Redirect(ToFormSign.Column1);
            }
        }
        protected void AbsFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAbs
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHR.Connection);
            var rsHcode = oHcodeDao.GetHocdeDetail("", false);

            //再檢查剩餘時數
            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
            foreach (var rAppS in rsAppS)
            {
                if (rAppS.Sign)
                {
                    if (rsHcode.Where(p => p.Code == rAppS.HolidayCode).First().CheckBalance)
                    {
                        var rBalance = oAbsDao.GetBalanceNew(rAppS.EmpId, rAppS.DateB, rAppS.HolidayCode).FirstOrDefault();
                        if (rBalance == null || (rBalance.Balance - rAppS.Use) < 0 || (rBalance.BalanceGroup - rAppS.Use) < 0)
                        {
                            //lblErrorMsg.Text = rAppS.sName + "申請" + rAppS.dDateB.ToShortDateString() + rAppS.sHname + "剩餘時數不足，請先直接駁回";
                            //return;
                        }
                    }
                }
            }

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }



            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void Abs1Finish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAbs
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHR.Connection);
            var rsHcode = oHcodeDao.GetHocdeDetail("", false);

            //再檢查剩餘時數
            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
            foreach (var rAppS in rsAppS)
            {
                if (rAppS.Sign)
                {
                    if (rsHcode.Where(p => p.Code == rAppS.HolidayCode).First().CheckBalance)
                    {
                        var rBalance = oAbsDao.GetBalanceNew(rAppS.EmpId, rAppS.DateB, rAppS.HolidayCode).FirstOrDefault();
                        if (rBalance == null || (rBalance.Balance - rAppS.Use) < 0 || (rBalance.BalanceGroup - rAppS.Use) < 0)
                        {
                            //lblErrorMsg.Text = rAppS.sName + "申請" + rAppS.dDateB.ToShortDateString() + rAppS.sHname + "剩餘時數不足，請先直接駁回";
                            //return;
                        }
                    }
                }
            }

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void OtFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;
                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void Ot1Finish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void OvtBFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            var rsFlowNodeId = (from pn in dcFlow.ProcessApParm
                                join pc in dcFlow.ProcessNode on pn.ProcessNode_auto equals pc.auto
                                where pn.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                orderby pc.auto descending
                                select pc).FirstOrDefault();

            var OvtBDynamic = (from c in dcFlow.FormsExtend//批次加班單申請者確認節點編號
                               where c.FormsCode == "OvtB" && c.Code == "OvtBOt1CheckNode" && c.Active == true
                               select c).FirstOrDefault();

            string FlowNodeId = rsFlowNodeId.FlowNode_id;
            bool IsOt1CheckNode = false;

            if (OvtBDynamic != null && OvtBDynamic.Column1 != null && OvtBDynamic.Column1 != "")
            {
                var NodeId = OvtBDynamic.Column1.Split(';');
                if (NodeId.Contains(FlowNodeId))//若是在需要確認的節點需要檢查時間是在刷卡時間內
                {
                    string NotInOt = "";
                    IsOt1CheckNode = true;
                    foreach (var r in rsAppS)
                    {
                        if (r.Sign)
                        {
                            string Nobr = r.EmpId;
                            string OtCat = r.OtCateCode;
                            string Otrcd = r.OtrcdCode;
                            string Rote = r.RoteCode;
                            DateTime DateB = r.DateB.Date;
                            string TimeB = r.TimeB;
                            string TimeE = r.TimeE;

                            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
                            var rsAbs = oAbsDao.GetAbs(Nobr, DateB, DateB);
                            var lsHcode = new List<string>();

                            var OtAbs1Hcode = (from c in dcFlow.FormsExtend
                                               where c.FormsCode == "Ot" && c.Active == true && c.Code == "OtAbs1Hcode"
                                               select c).FirstOrDefault();
                            if (OtAbs1Hcode != null)
                            {
                                var sHcode = OtAbs1Hcode.Column1.Split(';').ToList();
                                lsHcode.AddRange(sHcode);
                            }
                            else
                            {
                                lsHcode.Add("N");
                            }
                            var rAbs = rsAbs.Where(p => lsHcode.Contains(p.Hcode)).FirstOrDefault();
                            bool IsAbs = false;
                            DateTime dDateTimeB, dDateTimeE;
                            if (rAbs != null)
                            {

                                dDateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));    //加班开始日期时间
                                dDateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));    //加班结束日期时间

                                DateTime dAbsDateTimeB, dAbsDateTimeE;
                                dAbsDateTimeB = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeB));    //实际开始日期时间
                                dAbsDateTimeE = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeE));    //实际结束日期时间
                                                                                                                                     //检视公出单
                                if (dAbsDateTimeB <= dDateTimeB && dDateTimeE <= dAbsDateTimeE)
                                {
                                    IsAbs = true;
                                }
                            }
                            if (!IsAbs && !oAttcardDao.IsCardTime(Nobr, DateB, TimeB, TimeE))
                            {
                                //NotInOt += Nobr + "," + DateB.ToString() + "," + TimeB + "," + TimeE + "<BR>";
                                lblErrorMsg.Text = "有加班資料刷卡時間不在申請時間內，請重新確認";
                                return;
                            }
                        }
                    }
                }
            }

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = IsOt1CheckNode ? "0" : lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void OvtFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            var rsFlowNodeId = (from pn in dcFlow.ProcessApParm
                                join pc in dcFlow.ProcessNode on pn.ProcessNode_auto equals pc.auto
                                where pn.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                orderby pc.auto descending
                                select pc).FirstOrDefault();

            var OvtDynamic = (from c in dcFlow.FormsExtend//批次加班單申請者確認節點編號
                              where c.FormsCode == "Ovt" && c.Code == "OvtOt1CheckNode" && c.Active == true
                              select c).FirstOrDefault();

            string FlowNodeId = rsFlowNodeId.FlowNode_id;
            bool IsOt1CheckNode = false;

            if (OvtDynamic != null && OvtDynamic.Column1 != null && OvtDynamic.Column1 != "")
            {
                var NodeId = OvtDynamic.Column1.Split(';');
                if (NodeId.Contains(FlowNodeId))//若是在需要確認的節點需要檢查時間是在刷卡時間內
                {
                    IsOt1CheckNode = true;
                    string NotInOt = "";
                    foreach (var r in rsAppS)
                    {
                        if (r.Sign)
                        {
                            string Nobr = r.EmpId;
                            string OtCat = r.OtCateCode;
                            string Otrcd = r.OtrcdCode;
                            string Rote = r.RoteCode;
                            DateTime DateB = r.DateB.Date;
                            string TimeB = r.TimeB;
                            string TimeE = r.TimeE;

                            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
                            var rsAbs = oAbsDao.GetAbs(Nobr, DateB, DateB);
                            var lsHcode = new List<string>();

                            var OtAbs1Hcode = (from c in dcFlow.FormsExtend
                                               where c.FormsCode == "Ot" && c.Active == true && c.Code == "OtAbs1Hcode"
                                               select c).FirstOrDefault();
                            if (OtAbs1Hcode != null)
                            {
                                var sHcode = OtAbs1Hcode.Column1.Split(';').ToList();
                                lsHcode.AddRange(sHcode);
                            }
                            else
                            {
                                lsHcode.Add("N");
                            }
                            var rAbs = rsAbs.Where(p => lsHcode.Contains(p.Hcode)).FirstOrDefault();
                            bool IsAbs = false;
                            DateTime dDateTimeB, dDateTimeE;
                            if (rAbs != null)
                            {

                                dDateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));    //加班开始日期时间
                                dDateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));    //加班结束日期时间

                                DateTime dAbsDateTimeB, dAbsDateTimeE;
                                dAbsDateTimeB = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeB));    //实际开始日期时间
                                dAbsDateTimeE = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeE));    //实际结束日期时间
                                                                                                                                     //检视公出单
                                if (dAbsDateTimeB <= dDateTimeB && dDateTimeE <= dAbsDateTimeE)
                                {
                                    IsAbs = true;
                                }
                            }
                            if (!IsAbs && !oAttcardDao.IsCardTime(Nobr, DateB, TimeB, TimeE))
                            {
                                //NotInOt += Nobr + "," + DateB.ToString() + "," + TimeB + "," + TimeE + "<BR>";
                                lblErrorMsg.Text = "有加班資料刷卡時間不在申請時間內，請重新確認";
                                return;
                            }
                        }
                    }

                }
            }

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = IsOt1CheckNode ? "0" : lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void CardFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppCard
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();

            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void AbscFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAbsc
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }

            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void ShiftShortFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppShiftShort
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();


            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }



            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void ShiftLongFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppShiftLong
                          where c.ProcessID == lblProcessID.Text
                          select c).ToList();


            if (lblDeptTree.Text.Length == 0 || Convert.ToInt32(lblDeptTree.Text) <= 0)
            {
                lblErrorMsg.Text = "簽核錯誤，請登出重新簽核";
                return;
            }



            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var IsNeedRejectReason = (from c in dcFlow.FormsExtend
                                      where c.FormsCode == "Common" && c.Active == true && c.Code == "IsNeedRejectReason"
                                      select c).FirstOrDefault();

            string Note = "";
            var txtNote = cphMain.FindControl("txtNote");
            if (txtNote != null)
            {
                Note = ((RadTextBox)txtNote).Text;
                if (IsNeedRejectReason != null && Note == "" && rAppM.SignState == "2")
                {
                    lblErrorMsg.Text = "駁回需輸入意見";
                    return;
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = Note;
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }


            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;

                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void AbnFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAbn
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();

            rAppM.Sign = rsAppS.Where(p => p.Sign).Any();
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = "";
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }

            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;
                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void EmployFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppEmploy
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();

            rAppM.Sign = (btnCheck.SelectedValue != "2");
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = btnCheck.SelectedValue == "2" ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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

            if (UnobtrusiveSession.Session["EmployChangeLog"] == null)
            {
                lblErrorMsg.Text = "請先點選下方更新後，再送出審核";
                return;
            }

            if (rEmpM != null)
            {
                var oEmployChangeLog = UnobtrusiveSession.Session["EmployChangeLog"] as FormsAppEmployChangeLog;
                dcFlow.FormsAppEmployChangeLog.InsertOnSubmit(oEmployChangeLog);
                rsAppS.FirstOrDefault().DeptCodeChange = oEmployChangeLog.DeptCodeChange;
                rsAppS.FirstOrDefault().DeptNameChange = oEmployChangeLog.DeptNameChange;
                rsAppS.FirstOrDefault().DeptmCodeChange = oEmployChangeLog.DeptmCodeChange;
                rsAppS.FirstOrDefault().DeptmNameChange = oEmployChangeLog.DeptmNameChange;
                rsAppS.FirstOrDefault().JobCodeChange = oEmployChangeLog.JobCodeChange;
                rsAppS.FirstOrDefault().JobNameChange = oEmployChangeLog.JobNameChange;
                rsAppS.FirstOrDefault().JoblCodeChange = oEmployChangeLog.JoblCodeChange;
                rsAppS.FirstOrDefault().JoblNameChange = oEmployChangeLog.JoblNameChange;
                rsAppS.FirstOrDefault().ResultAreaCode = oEmployChangeLog.ResultAreaCode;
                rsAppS.FirstOrDefault().ResultAreaName = oEmployChangeLog.ResultAreaName;
                rsAppS.FirstOrDefault().ExtendMonth = oEmployChangeLog.ExtendMonth;
                rsAppS.FirstOrDefault().DateAppoint = oEmployChangeLog.DateAppoint;
                rsAppS.FirstOrDefault().Sign = rAppM.Sign;
                rsAppS.FirstOrDefault().SignState = rAppM.SignState;
                rsAppS.FirstOrDefault().Status = rAppM.Status;

                var LsSalaryData = UnobtrusiveSession.Session["LsSalaryData"] as List<TextValueRow>;
                foreach (var SalaryData in LsSalaryData)
                {
                    var oSalaryChangeLog = new FormsAppEmploySalary();
                    oSalaryChangeLog.EmployCode = rsAppS.First().Code;
                    oSalaryChangeLog.SalaryCode = SalaryData.Column1;
                    oSalaryChangeLog.SalaryName = SalaryData.Text;
                    oSalaryChangeLog.MoneyValue = 0;
                    oSalaryChangeLog.EncodeMoneyValue = 0;
                    oSalaryChangeLog.Note = SalaryData.Value;
                    oSalaryChangeLog.Status = "1";
                    oSalaryChangeLog.InsertMan = _User.EmpId;
                    oSalaryChangeLog.InsertDate = DateTime.Now;
                    oSalaryChangeLog.UpdateMan = _User.EmpId;
                    oSalaryChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppEmploySalary.InsertOnSubmit(oSalaryChangeLog);
                }

                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = "";
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }

            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;
                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void EmployApproveFinish()
        {
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

            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppEmploy
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();

            rAppM.Sign = (btnCheck.SelectedValue != "2");
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = btnCheck.SelectedValue == "2" ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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

            if (UnobtrusiveSession.Session["EmployChangeLog"] == null)
            {
                lblErrorMsg.Text = "請先點選下方更新後，再送出審核";
                return;
            }

            if (rEmpM != null)
            {
                var oEmployChangeLog = UnobtrusiveSession.Session["EmployChangeLog"] as FormsAppEmployChangeLog;
                dcFlow.FormsAppEmployChangeLog.InsertOnSubmit(oEmployChangeLog);
                rsAppS.FirstOrDefault().DeptCodeChange = oEmployChangeLog.DeptCodeChange;
                rsAppS.FirstOrDefault().DeptNameChange = oEmployChangeLog.DeptNameChange;
                rsAppS.FirstOrDefault().DeptmCodeChange = oEmployChangeLog.DeptmCodeChange;
                rsAppS.FirstOrDefault().DeptmNameChange = oEmployChangeLog.DeptmNameChange;
                rsAppS.FirstOrDefault().JobCodeChange = oEmployChangeLog.JobCodeChange;
                rsAppS.FirstOrDefault().JobNameChange = oEmployChangeLog.JobNameChange;
                rsAppS.FirstOrDefault().JoblCodeChange = oEmployChangeLog.JoblCodeChange;
                rsAppS.FirstOrDefault().JoblNameChange = oEmployChangeLog.JoblNameChange;
                rsAppS.FirstOrDefault().ResultAreaCode = oEmployChangeLog.ResultAreaCode;
                rsAppS.FirstOrDefault().ResultAreaName = oEmployChangeLog.ResultAreaName;
                rsAppS.FirstOrDefault().ExtendMonth = oEmployChangeLog.ExtendMonth;
                rsAppS.FirstOrDefault().DateAppoint = oEmployChangeLog.DateAppoint;
                rsAppS.FirstOrDefault().Sign = rAppM.Sign;
                rsAppS.FirstOrDefault().SignState = rAppM.SignState;
                rsAppS.FirstOrDefault().Status = rAppM.Status;

                var LsSalaryData = UnobtrusiveSession.Session["LsSalaryData"] as List<TextValueRow>;
                foreach (var SalaryData in LsSalaryData)
                {
                    var oSalaryChangeLog = new FormsAppEmploySalary();
                    oSalaryChangeLog.EmployCode = rsAppS.First().Code;
                    oSalaryChangeLog.SalaryCode = SalaryData.Column1;
                    oSalaryChangeLog.SalaryName = SalaryData.Text;
                    oSalaryChangeLog.MoneyValue = 0;
                    oSalaryChangeLog.EncodeMoneyValue = 0;
                    oSalaryChangeLog.Note = SalaryData.Value;
                    oSalaryChangeLog.Status = "1";
                    oSalaryChangeLog.InsertMan = _User.EmpName;
                    oSalaryChangeLog.InsertDate = DateTime.Now;
                    oSalaryChangeLog.UpdateMan = _User.EmpName;
                    oSalaryChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppEmploySalary.InsertOnSubmit(oSalaryChangeLog);
                }

                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = "";
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }

            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;
                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }
        protected void AppointFinish()
        {
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


            var rAppM = (from c in dcFlow.FormsApp
                         where c.ProcessID == lblProcessID.Text
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAppoint
                          where c.ProcessId == lblProcessID.Text
                          select c).ToList();
            var oAppoint = new FormsAppAppoint();
            if (UnobtrusiveSession.Session["Appoint"] != null)
            {
                oAppoint = UnobtrusiveSession.Session["Appoint"] as FormsAppAppoint;
                //宏亞不開啟此功能
                //

                //foreach (var rAppS in rsAppS)
                //{
                //    if (rAppS.AllowSign == false && !oAppoint.AllowSign)
                //    {
                //        lblErrorMsg.Text = "待HR開啟權限後，再送出審核";
                //        return;
                //    }
                //}
            }
            else
            {
                lblErrorMsg.Text = "請先點選下方更新後，再送出審核";
                return;
            }


            rAppM.Sign = (btnCheck.SelectedValue != "2");
            rAppM.Cond01 = lblDeptTree.Text;
            rAppM.SignState = btnCheck.SelectedValue == "2" ? "2" : rAppM.SignState;
            rAppM.DateTimeD = DateTime.Now;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrSign.Text
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
                var oAppointChangeLog = UnobtrusiveSession.Session["AppointChangeLog"] as FormsAppAppointChangeLog;
                dcFlow.FormsAppAppointChangeLog.InsertOnSubmit(oAppointChangeLog);
                rsAppS.FirstOrDefault().DeptCodeChange = oAppointChangeLog.DeptCodeChange;
                rsAppS.FirstOrDefault().DeptNameChange = oAppointChangeLog.DeptNameChange;
                rsAppS.FirstOrDefault().DeptmCodeChange = oAppointChangeLog.DeptmCodeChange;
                rsAppS.FirstOrDefault().DeptmNameChange = oAppointChangeLog.DeptmNameChange;
                rsAppS.FirstOrDefault().JobCodeChange = oAppointChangeLog.JobCodeChange;
                rsAppS.FirstOrDefault().JobNameChange = oAppointChangeLog.JobNameChange;
                rsAppS.FirstOrDefault().JoblCodeChange = oAppointChangeLog.JoblCodeChange;
                rsAppS.FirstOrDefault().JoblNameChange = oAppointChangeLog.JoblNameChange;
                rsAppS.FirstOrDefault().AllowSalary = oAppoint.AllowSalary;
                rsAppS.FirstOrDefault().AllowSign = oAppoint.AllowSign;
                rsAppS.FirstOrDefault().Qualified = oAppoint.Qualified;
                rsAppS.FirstOrDefault().Evaluation = oAppoint.Evaluation;
                rsAppS.FirstOrDefault().DateAppoint = oAppointChangeLog.DateAppoint;
                rsAppS.FirstOrDefault().Sign = rAppM.Sign;
                rsAppS.FirstOrDefault().SignState = rAppM.SignState;
                rsAppS.FirstOrDefault().Status = rAppM.Status;
                if (UnobtrusiveSession.Session["LsSalaryData"] == null && oAppoint.AllowSalary)
                {
                    lblErrorMsg.Text = "資料已過期，請重新整理後再送出";
                    return;
                }
                var LsSalaryData = UnobtrusiveSession.Session["LsSalaryData"] as List<TextValueRow>;
                foreach (var SalaryData in LsSalaryData)
                {
                    var oSalaryChangeLog = new FormsAppEmploySalary();
                    oSalaryChangeLog.EmployCode = rsAppS.First().Code;
                    oSalaryChangeLog.SalaryCode = SalaryData.Column1;
                    oSalaryChangeLog.SalaryName = SalaryData.Text;
                    oSalaryChangeLog.MoneyValue = 0;
                    oSalaryChangeLog.EncodeMoneyValue = 0;
                    oSalaryChangeLog.Note = SalaryData.Value;
                    oSalaryChangeLog.Status = "1";
                    oSalaryChangeLog.InsertMan = _User.EmpName;
                    oSalaryChangeLog.InsertDate = DateTime.Now;
                    oSalaryChangeLog.UpdateMan = _User.EmpName;
                    oSalaryChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppEmploySalary.InsertOnSubmit(oSalaryChangeLog);
                }

                var rSignM = (from c in dcFlow.FormsSign
                              where c.ProcessId == lblProcessID.Text
                              && c.Key1 == lblApKey.Text
                              && c.EmpId == rEmpM.EmpNobr
                              select c).FirstOrDefault();

                if (rSignM == null)
                {
                    rSignM = new FormsSign();
                    dcFlow.FormsSign.InsertOnSubmit(rSignM);
                }

                rSignM.FormsCode = FormCode;
                rSignM.ProcessId = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                rSignM.Key1 = lblApKey.Text;
                rSignM.Key2 = lblApKey.Text;
                rSignM.EmpId = rEmpM.EmpNobr;
                rSignM.EmpName = rEmpM.EmpName;
                rSignM.DeptCode = rEmpM.DeptCode;
                rSignM.DeptName = rEmpM.DeptName;
                rSignM.JobCode = rEmpM.JobCode;
                rSignM.JobName = rEmpM.JobName;
                rSignM.RoleId = rEmpM.RoleId;
                rSignM.Sign = rAppM.Sign;
                rSignM.SignNote = "";
                rSignM.Sort = 1;
                rSignM.Note = "";
                rSignM.Status = "1";
                rSignM.InsertDate = DateTime.Now;
                rSignM.InsertMan = rSignM.EmpId;
            }

            dcFlow.SubmitChanges();

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            try
            {
                if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                    lblMsg.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                else
                {
                    //闖關直接通知流程起始者
                    //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                    //{
                    //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                    //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                    //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                    //                          orderby c.auto descending
                    //                          select c).FirstOrDefault();

                    //    if (rProcessApParm != null)
                    //    {
                    //        rAppM.sConditions1 = "00";
                    //        rAppM.sConditions6 = "0";  //代理人簽過了

                    //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                    //        rProcessApParm.Role_id = rsAppS.First().sRole;

                    //        dcFlow.SubmitChanges();
                    //        dcForm.SubmitChanges();

                    //        if (!oService.WorkFinish(rProcessApParm.auto))
                    //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                    //    }
                    //}
                    UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                    isDirect = true;
                    //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的審核單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + lblProcessID.Text.ToString() + "';", true);
                    //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex + "流程發生問題，您核准的動作可能無法完成。(2)";
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string ProcessID = UnobtrusiveSession.Session["ProcessID"] as string;
            string EmpID = UnobtrusiveSession.Session["EmpID"] as string;
            string Role = UnobtrusiveSession.Session["Role"] as string;
            string DateB = UnobtrusiveSession.Session["DateB"] as string;
            string DateE = UnobtrusiveSession.Session["DateE"] as string;
            string State = UnobtrusiveSession.Session["State"] as string;
            string FormsCode = UnobtrusiveSession.Session["FormsCode"] as string;
            string Dept = UnobtrusiveSession.Session["Dept"] as string;

            if (ProcessID != null && EmpID != null && Role != null && DateB != null && DateE != null && State != null && FormsCode != null && Dept != null)
            {
                string Parameter = "?ProcessID=" + ProcessID + "&EmpID=" + EmpID + "&Role=" + Role + "&DateB=" + DateB
                    + "&DateE=" + DateE + "&State=" + State + "&FormsCode=" + FormsCode + "&Dept=" + Dept;
                Response.Redirect("FormFlowView.aspx" + Parameter);

            }
            else
            {
                Response.Redirect("FormFlowView.aspx");
            }
        }
    }
}