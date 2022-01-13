using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Dal;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Bll.Files.Vdb;
using Dal.Dao.Files;
using Dal.Dao.WorkFromHome;
using Bll.WorkFromHome.Vdb;
using System.ComponentModel;
using OldDal.Dao.Bas;
using Dal.Dao.Employee;
using Bll.Employee.Vdb;
using Bll;
using Dal.Dao.Salary;
using Bll.Salary.Vdb;
using Newtonsoft.Json;

namespace Portal
{
    public partial class MainFlowFormsStd : WebPageMasterPage
    {
        public event EventHandler Submit_Click;
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private CompanySettingRow CompanySetting;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmpName.Text = _User.EmpName + "," + _User.EmpId;
            lblDept.Text = _User.EmpDeptName;
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
            UnobtrusiveSession.Session["RequestName"] = "";
            if (!IsPostBack)
            {
            }

        }
        [Bindable(true)]
        public RadLabel _lblErrorMsg
        {
            get
            {
                return lblErrorMsg;
            }
            set
            {
                lblErrorMsg = value;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Submit_Click != null)//Contentpage所註冊的新增表身動作
            {
                //Submit_Click(this, EventArgs.Empty);
            }
            else
            {

            }
            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();

            string FormCode = Session["FormCode"].ToString();



            //var AbsFormTable = dcFlow.wfAppAbs;
            //var OtFormTable = dcFlow.wfAppOt;
            //var AbscFormTable = dcFlow.wfAppAbsc;
            //var CardFormTable = dcFlow.wfAppCard;
            //var FormTable = new List<T>();
            switch (FormCode)
            {
                case "Abs":
                    AbsSubmit();
                    break;
                case "Abs1":
                    Abs1Submit();
                    break;
                case "Ot":
                    OtSubmit();
                    break;
                case "Ot1":
                    Ot1Submit();
                    break;
                case "OvtB":
                    OvtBSubmit();
                    break;
                case "Ovt":
                    OvtSubmit();
                    break;
                case "Card":
                    CardSubmit();
                    break;
                case "Absc":
                    AbscSubmit();
                    break;
                case "ShiftShort":
                    ShiftShortSubmit();
                    break;
                case "ShiftLong":
                    ShiftLongSubmit();
                    break;
                case "Abn":
                    AbnSubmit();
                    break;
                case "WorkLog"://這個沒有流程但先這樣弄
                    WorkLogSubmit();
                    break;
                case "Employ":
                    EmploySubmit();
                    break;
                case "EmployApprove":
                    EmployApproveSubmit();
                    break;
                case "Appoint":
                    AppointSubmit();
                    break;
            }
        }
        protected void AbsSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppAbs
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "您並未申請任何資料，請先申請至少一筆資料";
                return;
            }

            bool bFilePass = true;

            var FormExtend = (from c in dcFlow.FormsExtend
                              where c.FormsCode == "Abs" && c.Code == "CheckFile" && c.Active == true
                              select c).ToList();
            if (FormExtend != null)
            {
                var HCodeList = new List<string>();
                HCodeList = FormExtend.Select(p => p.Column1).ToList();
                foreach (var rApp in rsApp)
                {
                    if (HCodeList.Contains(rApp.HolidayCode))
                    {
                        var FileTicket = rApp.Code;
                        var result = new List<FilesByFileTicketRow>();
                        var oFilesByFileTicket = new FilesByFileTicketDao();
                        var FilesByFileTicketCond = new FilesByFileTicketConditions();
                        FilesByFileTicketCond.AccessToken = _User.AccessToken;
                        FilesByFileTicketCond.RefreshToken = _User.RefreshToken;
                        FilesByFileTicketCond.CompanySetting = CompanySetting;
                        FilesByFileTicketCond.fileTicket = FileTicket;
                        var Result = oFilesByFileTicket.GetData(FilesByFileTicketCond);

                        if (Result.Status)
                        {
                            if (Result.Data != null)
                            {
                                result = Result.Data as List<FilesByFileTicketRow>;
                            }
                        }
                        if (result.Count == 0)
                        {
                            bFilePass = false;
                        }
                    }
                }

            }



            var CheckFileWithCondition = (from c in dcFlow.FormsExtend
                                          where c.FormsCode == "Abs" && c.Code == "CheckFileWithConditions" && c.Active == true
                                          select c).ToList();

            foreach (var rCheckFileWithCondition in CheckFileWithCondition)
            {

                var Hcode = rCheckFileWithCondition.Column1;
                var Use = Convert.ToDecimal(rCheckFileWithCondition.Column2);
                if (rsApp.Where(p => p.HolidayCode == Hcode).Sum(p => p.Use) >= Use)
                {
                    var FileTicket = rsApp.First().Code;
                    var result = new List<FilesByFileTicketRow>();
                    var oFilesByFileTicket = new FilesByFileTicketDao();
                    var FilesByFileTicketCond = new FilesByFileTicketConditions();
                    FilesByFileTicketCond.AccessToken = _User.AccessToken;
                    FilesByFileTicketCond.RefreshToken = _User.RefreshToken;
                    FilesByFileTicketCond.CompanySetting = CompanySetting;
                    FilesByFileTicketCond.fileTicket = FileTicket;
                    var Result = oFilesByFileTicket.GetData(FilesByFileTicketCond);

                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            result = Result.Data as List<FilesByFileTicketRow>;
                        }
                    }
                    if (result.Count == 0)
                    {
                        bFilePass = false;
                    }
                }
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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
            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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


            if (!bFilePass)
            {
                lblErrorMsg.Text = "特定假別需上傳附件";
                return;
            }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之請假單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之請假單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之請假單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";
                var AbsDynamic = (from c in dcFlow.FormsExtend//請假單代理人確認節點編號
                                  where c.FormsCode == "Abs" && c.Code == "AbsDynamic" && c.Active == true
                                  select c).FirstOrDefault();

                var rEmpAgent = (from role in dcFlow.Role
                                 join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                 join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                 join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                 where role.Emp_id == rsAppS.First().AgentEmpId
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

                if (AbsDynamic != null && AbsDynamic.Column1 != null && AbsDynamic.Column1 != "")
                {
                    oService.SaveDynamic(iProcessID, AbsDynamic.Column1, rEmpAgent.EmpNobr, rEmpAgent.RoleId);
                }
                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    {
                        var rAgent = (from c in dcFlow.Emp
                                      where c.id == rAppS.AgentEmpId.Trim()
                                      select c).FirstOrDefault();

                        if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                            lsSendMail.Add(rAgent.email.Trim());
                    }

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                var sDay = rsAppS.First().UnitCode == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var GetDeptTreeByJob = (from c in dcFlow.FormsExtend  // 根據職稱來分辨職等
                                        where c.FormsCode == "Abs" && c.Code == "GetDeptTreeByJob" && c.Active == true
                                        select c).FirstOrDefault();
                string DeptTree = "";
                if (GetDeptTreeByJob != null)
                {
                    //var oJob = new JobDao(dcHR.Connection);
                    //DeptTree = oJob.GetDeptTreeByJob(rEmpS.JobCode);
                    var SqlCommand = "Select DEPT_TREE from Job where JOB='" + rEmpS.JobCode + "'";//特殊欄位所以直接用SQL語法來寫
                    var JobData = dcHR.ExecuteQuery<string>(SqlCommand).FirstOrDefault();
                    if(JobData != null)
                        DeptTree = JobData;
                }

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Abs",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0,    //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = sDay,//請假天數
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",//是否為主管
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rsApp.First().HolidayCode,//假別代碼
                    Cond07 = rBasM.DI,
                    Cond08 = DeptTree
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void Abs1Submit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppAbs
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            //var rEmpS = (from role in dcFlow.Role
            //             join emp in dcFlow.Emp on role.Emp_id equals emp.id
            //             join dept in dcFlow.Dept on role.Dept_id equals dept.id
            //             join pos in dcFlow.Pos on role.Pos_id equals pos.id
            //             where role.Emp_id == rsApp.First().EmpId
            //             select new
            //             {
            //                 RoleId = role.id,
            //                 EmpNobr = emp.id,
            //                 EmpName = emp.name,
            //                 DeptCode = dept.id,
            //                 DeptName = dept.name,
            //                 JobCode = pos.id,
            //                 JobName = pos.name,
            //                 Auth = role.deptMg.Value,
            //             }).FirstOrDefault();

            bool bFilePass = true;

            if (!bFilePass)
            {
                //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
                //return;
            }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之公出單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之公出單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之公出單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";
                var Abs1Dynamic = (from c in dcFlow.FormsExtend//請假單代理人確認節點編號
                                   where c.FormsCode == "Abs1" && c.Code == "Abs1Dynamic" && c.Active == true
                                   select c).FirstOrDefault();
                var rEmpAgent = (from role in dcFlow.Role
                                 join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                 join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                 join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                 where role.Emp_id == rsAppS.First().AgentEmpId
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

                if (Abs1Dynamic != null && Abs1Dynamic.Column1 != null && Abs1Dynamic.Column1 != "")
                {
                    oService.SaveDynamic(iProcessID, Abs1Dynamic.Column1, rEmpAgent.EmpNobr, rEmpAgent.RoleId);
                }
                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    {
                        var rAgent = (from c in dcFlow.Emp
                                      where c.id == rAppS.AgentEmpId.Trim()
                                      select c).FirstOrDefault();

                        if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                            lsSendMail.Add(rAgent.email.Trim());
                    }

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                var sDay = rsAppS.First().UnitCode == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use) / 8));



                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();
                var rEmpS = (from role in dcFlow.Role
                             join emp in dcFlow.Emp on role.Emp_id equals emp.id
                             join dept in dcFlow.Dept on role.Dept_id equals dept.id
                             join pos in dcFlow.Pos on role.Pos_id equals pos.id
                             where role.Emp_id == rsAppS.First().EmpId
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
                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Abs1",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0,    //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = sDay,
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rsApp.First().HolidayCode
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void OtSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppOt
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            var OtOver = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Code == "OtOver" && c.Active == true
                          select c).FirstOrDefault();

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            foreach (var r in rsApp)
            {
                DateTime calDateB = new DateTime(r.DateB.Year, r.DateB.Month, 1).Date;
                DateTime calDateE = new DateTime(r.DateB.Year, r.DateB.Month, DateTime.DaysInMonth(r.DateB.Year, r.DateB.Month)).Date;

                var calHour = oOtDao.GetHoursSum(r.EmpId, calDateB, calDateE, false);

                var rsAppS = (from c in dcFlow.FormsAppOt
                              where (c.ProcessID == sProcessID || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == r.EmpId
                              select c).ToList();


                var rsFlow = rsAppS.Where(p => calDateB <= p.DateB && p.DateB <= calDateE).ToList();
                if (rsFlow.Count > 0)
                    calHour += rsFlow.Sum(p => p.Use);


                //calHour += r.iTotalHour;
                var rBasS = oBasDao.GetBaseByNobr(r.EmpId, DateTime.Now.Date).FirstOrDefault();



                RadLabel NotifyMsg = cphMain.FindControl("lblNotifyMsg") as RadLabel;
                if (NotifyMsg != null && OtOver == null)
                {
                    if (calHour > 46)
                    {
                        NotifyMsg.Text = r.EmpName + "本月加班時數已超過46小時上限，請洽人事單位";
                        return;
                    }
                }
            }

            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();


            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之加班單，請進入系統簽核";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                //foreach (var s in lsNoticeSendMail)
                //{
                //    if (s != "")
                //    {
                //        var rSendMail = new wfSendMail();
                //        rSendMail.sProcessID = iProcessID.ToString();
                //        rSendMail.idProcess = iProcessID;
                //        rSendMail.sGuid = Guid.NewGuid().ToString();
                //        rSendMail.sToAddress = s;
                //        rSendMail.sSubject = sNoticeSubject;
                //        rSendMail.sBody = sBody;
                //        rSendMail.bOnly = s != "";
                //        rSendMail.sKeyMan = sNobrM;
                //        rSendMail.dKeyDate = DateTime.Now;
                //        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                //    }
                //}

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數



                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}


                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var Calculate = rsAppS.First().Use.ToString();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var Ot1Time = oOtDao.GetOt1(rsAppS.First().EmpId, rsAppS.First().DateTimeB, rsAppS.First().DateTimeE);
                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Ot",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = Calculate,//加班時數
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond07 = rBasM.DI,
                    Cond08 = Ot1Time.Count == 0 ? "0":"1"
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void Ot1Submit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppOt
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            var OtOver = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Code == "OtOver" && c.Active == true
                          select c).FirstOrDefault();

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            foreach (var r in rsApp)
            {
                DateTime calDateB = new DateTime(r.DateB.Year, r.DateB.Month, 1).Date;
                DateTime calDateE = new DateTime(r.DateB.Year, r.DateB.Month, DateTime.DaysInMonth(r.DateB.Year, r.DateB.Month)).Date;

                var calHour = oOtDao.GetHoursSum(r.EmpId, calDateB, calDateE, false);

                var rsAppS = (from c in dcFlow.FormsAppOt
                              where (c.ProcessID == sProcessID || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == r.EmpId
                              select c).ToList();


                var rsFlow = rsAppS.Where(p => calDateB <= p.DateB && p.DateB <= calDateE).ToList();
                if (rsFlow.Count > 0)
                    calHour += rsFlow.Sum(p => p.Use);


                //calHour += r.iTotalHour;
                var rBasS = oBasDao.GetBaseByNobr(r.EmpId, DateTime.Now.Date).FirstOrDefault();

                RadLabel NotifyMsg = cphMain.FindControl("lblNotifyMsg") as RadLabel;
                if (NotifyMsg != null && OtOver == null)
                {
                    if (calHour > 46)
                    {
                        NotifyMsg.Text = r.EmpName + "本月加班時數已超過46小時上限，請洽人事單位";
                        return;
                    }
                }
            }

            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();


            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之預估加班單，請進入系統簽核";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                //foreach (var s in lsNoticeSendMail)
                //{
                //    if (s != "")
                //    {
                //        var rSendMail = new wfSendMail();
                //        rSendMail.sProcessID = iProcessID.ToString();
                //        rSendMail.idProcess = iProcessID;
                //        rSendMail.sGuid = Guid.NewGuid().ToString();
                //        rSendMail.sToAddress = s;
                //        rSendMail.sSubject = sNoticeSubject;
                //        rSendMail.sBody = sBody;
                //        rSendMail.bOnly = s != "";
                //        rSendMail.sKeyMan = sNobrM;
                //        rSendMail.dKeyDate = DateTime.Now;
                //        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                //    }
                //}

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}


                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var Calculate = rsAppS.First().Use.ToString();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Ot1",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = Calculate,//加班時數
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0" //被申請者的部門層級

                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void OvtSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppOt
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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


            var OtOver = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Code == "OtOver" && c.Active == true
                          select c).FirstOrDefault();

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            foreach (var r in rsApp)
            {
                DateTime calDateB = new DateTime(r.DateB.Year, r.DateB.Month, 1).Date;
                DateTime calDateE = new DateTime(r.DateB.Year, r.DateB.Month, DateTime.DaysInMonth(r.DateB.Year, r.DateB.Month)).Date;

                var calHour = oOtDao.GetHoursSum(r.EmpId, calDateB, calDateE, false);

                var rsAppS = (from c in dcFlow.FormsAppOt
                              where (c.ProcessID == sProcessID || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == r.EmpId
                              select c).ToList();


                var rsFlow = rsAppS.Where(p => calDateB <= p.DateB && p.DateB <= calDateE).ToList();
                if (rsFlow.Count > 0)
                    calHour += rsFlow.Sum(p => p.Use);


                //calHour += r.iTotalHour;
                var rBasS = oBasDao.GetBaseByNobr(r.EmpId, DateTime.Now.Date).FirstOrDefault();

                RadLabel NotifyMsg = cphMain.FindControl("lblNotifyMsg") as RadLabel;
                if (NotifyMsg != null && OtOver == null)
                {
                    if (calHour > 46)
                    {
                        NotifyMsg.Text = r.EmpName + "本月加班時數已超過46小時上限，請洽人事單位";
                        return;
                    }
                }
            }

            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();


            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之加班單，請進入系統簽核";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                //foreach (var s in lsNoticeSendMail)
                //{
                //    if (s != "")
                //    {
                //        var rSendMail = new wfSendMail();
                //        rSendMail.sProcessID = iProcessID.ToString();
                //        rSendMail.idProcess = iProcessID;
                //        rSendMail.sGuid = Guid.NewGuid().ToString();
                //        rSendMail.sToAddress = s;
                //        rSendMail.sSubject = sNoticeSubject;
                //        rSendMail.sBody = sBody;
                //        rSendMail.bOnly = s != "";
                //        rSendMail.sKeyMan = sNobrM;
                //        rSendMail.dKeyDate = DateTime.Now;
                //        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                //    }
                //}

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}


                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var Calculate = rsAppS.First().Use.ToString();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                bool IsOt1 = true;
                if (rsAppS.First().DateTimeB < DateTime.Now)//判斷是否為預估加班單
                    IsOt1 = false;

                var OvtAppMCheck = (from c in dcFlow.FormsExtend//判斷預估流程是否回到申請者，Active=false則為流程起始者
                                    where c.FormsCode == "Ovt" && c.Code == "OvtAppMCheck" && c.Active == true
                                    select c).Any();

                var OvtDynamic = (from c in dcFlow.FormsExtend//批次加班單申請者確認節點編號
                                  where c.FormsCode == "Ovt" && c.Code == "OvtDynamic" && c.Active == true
                                  select c).FirstOrDefault();

                if (OvtDynamic != null && OvtDynamic.Column1 != null && OvtDynamic.Column1 != "")
                {
                    oService.SaveDynamic(iProcessID, OvtDynamic.Column1, rEmpM.EmpNobr, rEmpM.RoleId);
                }

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Ovt",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = Calculate,//加班時數
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond07 = IsOt1 == true ? "1" : "0",//是否為預估
                    Cond08 = OvtAppMCheck == true ? "1" : "0"//判斷預估流程是否回到申請者，關閉則為流程起始者
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void OvtBSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppOt
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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


            var OtOver = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Code == "OtOver" && c.Active == true
                          select c).FirstOrDefault();

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            foreach (var r in rsApp)
            {
                DateTime calDateB = new DateTime(r.DateB.Year, r.DateB.Month, 1).Date;
                DateTime calDateE = new DateTime(r.DateB.Year, r.DateB.Month, DateTime.DaysInMonth(r.DateB.Year, r.DateB.Month)).Date;

                var calHour = oOtDao.GetHoursSum(r.EmpId, calDateB, calDateE, false);

                var rsAppS = (from c in dcFlow.FormsAppOt
                              where (c.ProcessID == sProcessID || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == r.EmpId
                              select c).ToList();


                var rsFlow = rsAppS.Where(p => calDateB <= p.DateB && p.DateB <= calDateE).ToList();
                if (rsFlow.Count > 0)
                    calHour += rsFlow.Sum(p => p.Use);


                //calHour += r.iTotalHour;
                var rBasS = oBasDao.GetBaseByNobr(r.EmpId, DateTime.Now.Date).FirstOrDefault();

                RadLabel NotifyMsg = cphMain.FindControl("lblNotifyMsg") as RadLabel;
                if (NotifyMsg != null && OtOver == null)
                {
                    if (calHour > 46)
                    {
                        NotifyMsg.Text = r.EmpName + "本月加班時數已超過46小時上限，請洽人事單位";
                        return;
                    }
                }
            }

            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();


            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之批次加班單，請進入系統簽核";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                //foreach (var s in lsNoticeSendMail)
                //{
                //    if (s != "")
                //    {
                //        var rSendMail = new wfSendMail();
                //        rSendMail.sProcessID = iProcessID.ToString();
                //        rSendMail.idProcess = iProcessID;
                //        rSendMail.sGuid = Guid.NewGuid().ToString();
                //        rSendMail.sToAddress = s;
                //        rSendMail.sSubject = sNoticeSubject;
                //        rSendMail.sBody = sBody;
                //        rSendMail.bOnly = s != "";
                //        rSendMail.sKeyMan = sNobrM;
                //        rSendMail.dKeyDate = DateTime.Now;
                //        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                //    }
                //}

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}


                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var Calculate = rsAppS.First().Use.ToString();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                bool IsOt1 = true;
                if (rsAppS.First().DateTimeB < DateTime.Now)//判斷是否為預估加班單
                    IsOt1 = false;

                var OvtBAppMCheck = (from c in dcFlow.FormsExtend//判斷預估流程是否回到申請者，Active=false則為流程起始者
                                     where c.FormsCode == "OvtB" && c.Code == "OvtBAppMCheck" && c.Active == true
                                     select c).Any();

                var OvtBDynamic = (from c in dcFlow.FormsExtend//批次加班單申請者確認節點編號
                                   where c.FormsCode == "OvtB" && c.Code == "OvtBDynamic" && c.Active == true
                                   select c).FirstOrDefault();

                if (OvtBDynamic != null && OvtBDynamic.Column1 != null && OvtBDynamic.Column1 != "")
                {
                    oService.SaveDynamic(iProcessID, OvtBDynamic.Column1, rEmpM.EmpNobr, rEmpM.RoleId);
                }

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "OvtB",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = Calculate,//加班時數
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond07 = IsOt1 == true ? "1" : "0",//是否為預估
                    Cond08 = OvtBAppMCheck == true ? "1" : "0"//判斷預估流程是否回到申請者，關閉則為流程起始者
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void CardSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppCard
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            bool bFilePass = true;

            if (!bFilePass)
            {
                //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
                //return;
            }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();


            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之忘刷單，請進入系統簽核";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                //foreach (var s in lsNoticeSendMail)
                //{
                //    if (s != "")
                //    {
                //        var rSendMail = new wfSendMail();
                //        rSendMail.sProcessID = iProcessID.ToString();
                //        rSendMail.idProcess = iProcessID;
                //        rSendMail.sGuid = Guid.NewGuid().ToString();
                //        rSendMail.sToAddress = s;
                //        rSendMail.sSubject = sNoticeSubject;
                //        rSendMail.sBody = sBody;
                //        rSendMail.bOnly = s != "";
                //        rSendMail.sKeyMan = sNobrM;
                //        rSendMail.dKeyDate = DateTime.Now;
                //        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                //    }
                //}

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                //var sDay = rsAppS.First().sUnit == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Card",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0,    //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0" //被申請者的部門層級
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void AbscSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppAbsc
                         where c.ProcessId == sProcessID
                         select c).ToList();



            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "請選擇銷假資料";
                return;
            }

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            //    bool bFilePass = true;

            //    if (!bFilePass)
            //    {
            //        //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //        //return;
            //    }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            //    lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之銷假單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之銷假單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之銷假單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                var sDay = rsAppS.First().UnitCode == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.Use) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Absc",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond02 = sDay,
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rsAppS.Count().ToString()
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void ShiftShortSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppShiftShort
                         where c.ProcessId == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "您並未申請任何資料，請先申請至少一筆資料";
                return;
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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
            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            bool bFilePass = true;

            if (!bFilePass)
            {
                //lblErrorMsg.Text = "特定假別需上傳附件";
                //return;
            }



            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之換班單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之換班單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之換班單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "ShiftShort",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0,    //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0" //被申請者的部門層級

                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void ShiftLongSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppShiftLong
                         where c.ProcessID == sProcessID
                         select c).ToList();

            var gAppS = (rsApp.GroupBy(p => new { p.idProcess })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            string sNobrM = _User.EmpId;
            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "您並未申請任何資料，請先申請至少一筆資料";
                return;
            }

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            bool bFilePass = true;

            if (!bFilePass)
            {
                //lblErrorMsg.Text = "特定假別需上傳附件";
                //return;
            }



            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之調班單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之調班單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之調班單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessID = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().Date);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "ShiftLong",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0,    //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0" //被申請者的部門層級

                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void AbnSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppAbn
                         where c.ProcessId == sProcessID
                         select c).ToList();



            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "請選擇異常資料";
                return;
            }

            string sNobrM = _User.EmpId;
            //if (!gAppS.Any())
            //{
            //    RadWindowManager1.RadAlert("您並未申請任何資料，請先申請至少一筆資料", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //    return;
            //}

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            //    bool bFilePass = true;

            //    if (!bFilePass)
            //    {
            //        //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //        //return;
            //    }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            //    lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();



            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之異常註記單，請進入系統簽核";
                string sAgengSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之異常註記單，您是他的代理人";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之異常註記單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = s == "" ? sSubject : sAgengSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateB);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                //var sDay = rsAppS.First().sUnit == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Abn",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpNobr,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0" //被申請者的部門層級
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void WorkLogSubmit()
        {
            var workLogs = UnobtrusiveSession.Session["WorkLog"] as List<WorkLogVdb>;
            bool isSucess = true;
            foreach (var c in workLogs)
            {
                var oInsertWorkLog = new InsertWorkLogDao();
                var InsertWorkLogCond = new InsertWorkLogConditions();
                InsertWorkLogCond.AccessToken = _User.AccessToken;
                InsertWorkLogCond.RefreshToken = _User.RefreshToken;
                InsertWorkLogCond.CompanySetting = CompanySetting;
                InsertWorkLogCond.EmployeeId = _User.EmpId;
                InsertWorkLogCond.EmployeeName = _User.EmpName;
                InsertWorkLogCond.AttendDate = c.DateB;
                InsertWorkLogCond.BeginTime = c.TimeB;
                InsertWorkLogCond.EndTime = c.TimeE;
                InsertWorkLogCond.WorkHours = 8;
                InsertWorkLogCond.Workitem = "";
                InsertWorkLogCond.Description = c.Note;
                InsertWorkLogCond.FileId = c.GUID;
                InsertWorkLogCond.KeyMan = _User.EmpName;
                InsertWorkLogCond.AutoKey = 0;
                InsertWorkLogCond.Guid = Guid.NewGuid();
                var Result = oInsertWorkLog.GetData(InsertWorkLogCond);
                if (!Result.Status)
                {
                    isSucess = false;
                }
            }
            if (isSucess)
            {
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的工作日誌已成功送出了');self.location = 'FormWorkLog.aspx';", true);
            }
            else
            {
                lblErrorMsg.Text = "上傳失敗";
            }
        }
        protected void EmploySubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppEmploy
                         where c.ProcessId == sProcessID
                         select c).ToList();



            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "請點選下方的確認";
                return;
            }

            string sNobrM = _User.EmpId;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            //    bool bFilePass = true;

            //    if (!bFilePass)
            //    {
            //        //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //        //return;
            //    }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            //    lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();


            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工任用單，請進入系統簽核";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工任用單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                var EmployDynamic = (from c in dcFlow.FormsExtend//晉升單申請者確認節點編號
                                            where c.FormsCode == "Employ" && c.Code == "EmployDynamic" && c.Active == true
                                            select c).ToList();
                foreach (var EDynamic in EmployDynamic)
                {
                    if (EDynamic != null && EDynamic.Column1 != null && EDynamic.Column1 != "" && EDynamic.Column2 != null && EDynamic.Column2 != "")
                    {

                        var NodeConfirm = (from c in dcFlow.wfDynamic
                                           where c.idProcess == iProcessID && c.idFlowNode == EDynamic.Column2
                                           select c).FirstOrDefault();
                        if (NodeConfirm != null)
                            continue;

                        var oCurrentJobStatus = new CurrentJobStatusDao();
                        var CurrentJobStatusCond = new CurrentJobStatusConditions();
                        CurrentJobStatusCond.AccessToken = _User.AccessToken;
                        CurrentJobStatusCond.RefreshToken = _User.RefreshToken;
                        CurrentJobStatusCond.CompanySetting = CompanySetting;
                        CurrentJobStatusCond.nobr = rsApp.First().EmpId;
                        CurrentJobStatusCond.Adate = DateTime.Now.Date;
                        var rsStatus = oCurrentJobStatus.GetData(CurrentJobStatusCond);
                        var rsTTS = new CurrentJobStatusRow();
                        if (rsStatus.Status && rsStatus.Data != null)
                        {
                            rsTTS = rsStatus.Data as CurrentJobStatusRow;
                        }
                        if (EDynamic.Column3 != null && (EDynamic.Column3 == "" || EDynamic.Column3 == rsTTS.Result.Saladr))
                        {
                            var rEmp = (from role in dcFlow.Role
                                        join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                        join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                        join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                        where role.Emp_id == EDynamic.Column2
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
                            if (rEmp != null)
                                oService.SaveDynamic(iProcessID, EDynamic.Column1, rEmp.EmpNobr, rEmp.RoleId);
                        }
                    }
                }
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    //新增寫入紀錄
                    var oEmployChangeLog = new FormsAppEmployChangeLog();
                    oEmployChangeLog.EmployCode = rAppS.Code;
                    oEmployChangeLog.DateAppoint = DateTime.Now.Date;
                    oEmployChangeLog.DeptCodeChange = "";
                    oEmployChangeLog.DeptNameChange = "";
                    oEmployChangeLog.DeptmCodeChange = "";
                    oEmployChangeLog.DeptmNameChange = "";
                    oEmployChangeLog.JobCodeChange = "";
                    oEmployChangeLog.JobNameChange = "";
                    oEmployChangeLog.JoblCodeChange = "";
                    oEmployChangeLog.JoblNameChange = "";
                    oEmployChangeLog.ResultAreaCode = "";
                    oEmployChangeLog.ResultAreaName = "";
                    oEmployChangeLog.ExtendMonth = 0;
                    oEmployChangeLog.Performance01 = "HR起單";
                    oEmployChangeLog.Performance02 = "HR起單";
                    oEmployChangeLog.Performance03 = "HR起單";
                    oEmployChangeLog.Performance04 = "HR起單";
                    oEmployChangeLog.Performance05 = "HR起單";
                    oEmployChangeLog.SalaryContent = UnobtrusiveSession.Session["SalaryData"].ToString();
                    oEmployChangeLog.Note = "";
                    oEmployChangeLog.Status = "1";
                    oEmployChangeLog.InsertMan = _User.EmpName;
                    oEmployChangeLog.InsertDate = DateTime.Now;
                    oEmployChangeLog.UpdateMan = _User.EmpName;
                    oEmployChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppEmployChangeLog.InsertOnSubmit(oEmployChangeLog);

                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sNoticeSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateA);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                //var sDay = rsAppS.First().sUnit == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();
                var rBasS = oBasDao.GetBaseByNobr(rsAppS.First().EmpId, DateTime.Now.Date).FirstOrDefault();

                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Employ",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpName,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rBasS.JoblCode,
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void EmployApproveSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppEmploy
                         where c.ProcessId == sProcessID
                         select c).ToList();



            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "請點選下方的確認";
                return;
            }

            string sNobrM = _User.EmpId;

            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            //    bool bFilePass = true;

            //    if (!bFilePass)
            //    {
            //        //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //        //return;
            //    }


            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            //    lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();


            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工核定單，請進入系統簽核";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工核定單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                var EmployApproveDynamic = (from c in dcFlow.FormsExtend//晉升單申請者確認節點編號
                                            where c.FormsCode == "EmployApprove" && c.Code == "EmployApproveDynamic" && c.Active == true
                                            select c).ToList();
                foreach (var EADynamic in EmployApproveDynamic)
                {
                    if (EADynamic != null && EADynamic.Column1 != null && EADynamic.Column1 != "" && EADynamic.Column2 != null && EADynamic.Column2 != "")
                    {
                        var NodeConfirm = (from c in dcFlow.wfDynamic
                                           where c.idProcess == iProcessID && c.idFlowNode == EADynamic.Column2
                                           select c).FirstOrDefault();
                        if (NodeConfirm != null)
                            continue;

                        var oCurrentJobStatus = new CurrentJobStatusDao();
                        var CurrentJobStatusCond = new CurrentJobStatusConditions();
                        CurrentJobStatusCond.AccessToken = _User.AccessToken;
                        CurrentJobStatusCond.RefreshToken = _User.RefreshToken;
                        CurrentJobStatusCond.CompanySetting = CompanySetting;
                        CurrentJobStatusCond.nobr = rsApp.First().EmpId;
                        CurrentJobStatusCond.Adate = DateTime.Now.Date;
                        var rsStatus = oCurrentJobStatus.GetData(CurrentJobStatusCond);
                        var rsTTS = new CurrentJobStatusRow();
                        if (rsStatus.Status && rsStatus.Data != null)
                        {
                            rsTTS = rsStatus.Data as CurrentJobStatusRow;
                        }
                        if (EADynamic.Column3 != null && (EADynamic.Column3 == "" || EADynamic.Column3 == rsTTS.Result.Saladr))
                        {
                            var rEmp = (from role in dcFlow.Role
                                        join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                        join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                        join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                        where role.Emp_id == EADynamic.Column2
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
                            if (rEmp != null)
                                oService.SaveDynamic(iProcessID, EADynamic.Column1, rEmp.EmpNobr, rEmp.RoleId);
                        }

                    }
                }
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    //新增寫入紀錄
                    var oEmployChangeLog = new FormsAppEmployChangeLog();
                    oEmployChangeLog.EmployCode = rAppS.Code;
                    oEmployChangeLog.DateAppoint = DateTime.Now.Date;
                    oEmployChangeLog.DeptCodeChange = "";
                    oEmployChangeLog.DeptNameChange = "";
                    oEmployChangeLog.DeptmCodeChange = "";
                    oEmployChangeLog.DeptmNameChange = "";
                    oEmployChangeLog.JobCodeChange = "";
                    oEmployChangeLog.JobNameChange = "";
                    oEmployChangeLog.JoblCodeChange = "";
                    oEmployChangeLog.JoblNameChange = "";
                    oEmployChangeLog.ResultAreaCode = "";
                    oEmployChangeLog.ResultAreaName = "";
                    oEmployChangeLog.ExtendMonth = 0;
                    oEmployChangeLog.Performance01 = "HR起單";
                    oEmployChangeLog.Performance02 = "HR起單";
                    oEmployChangeLog.Performance03 = "HR起單";
                    oEmployChangeLog.Performance04 = "HR起單";
                    oEmployChangeLog.Performance05 = "HR起單";
                    oEmployChangeLog.SalaryContent = UnobtrusiveSession.Session["SalaryData"].ToString();
                    oEmployChangeLog.Note = "";
                    oEmployChangeLog.Status = "1";
                    oEmployChangeLog.InsertMan = _User.EmpName;
                    oEmployChangeLog.InsertDate = DateTime.Now;
                    oEmployChangeLog.UpdateMan = _User.EmpName;
                    oEmployChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppEmployChangeLog.InsertOnSubmit(oEmployChangeLog);

                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    var rFormAppInfo = new wfFormAppInfo();
                    rFormAppInfo.idProcess = iProcessID;
                    rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    rFormAppInfo.sNobr = rAppS.EmpId;
                    rFormAppInfo.sName = rAppS.EmpName;
                    rFormAppInfo.sState = "1";
                    rFormAppInfo.sInfo = sInfo;
                    rFormAppInfo.sGuid = rAppS.Code;
                    lsFormAppInfo.Add(rFormAppInfo);
                    dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sNoticeSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateA);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                //var sDay = rsAppS.First().sUnit == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse) / 8));

                var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();
                var rBasS = oBasDao.GetBaseByNobr(rsAppS.First().EmpId, DateTime.Now.Date).FirstOrDefault();
                var rFormsApp = new FormsApp()
                {
                    FormsCode = "EmployApprove",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpName,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rBasS.JoblCode
                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
        protected void AppointSubmit()
        {
            string sProcessID = Session["sProcessID"].ToString();

            var rsApp = (from c in dcFlow.FormsAppAppoint
                         where c.ProcessId == sProcessID
                         select c).ToList();



            var gAppS = (rsApp.GroupBy(p => new { p.EmpId })).ToList();

            var rsFile = (from c in dcFlow.wfFormUploadFile
                          where c.sProcessID == sProcessID
                          select c).ToList();

            if (!gAppS.Any())
            {
                lblErrorMsg.Text = "請先點選下方的確認";
                return;
            }

            string sNobrM = _User.EmpId;
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

            var rBasM = oBasDao.GetBaseByNobr(sNobrM, DateTime.Now.Date).FirstOrDefault();
            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobrM
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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == rsApp.First().EmpId
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

            //    bool bFilePass = true;

            //    if (!bFilePass)
            //    {
            //        //RadWindowManager1.RadAlert("特定假別需上傳附件", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
            //        //return;
            //    }




            var lsNobr = rsApp.Select(p => p.EmpId).Distinct().ToList();

            //    lsNobr = rsApp.Select(p => p.AgentEmpId).Distinct().ToList();

            List<string> lsDept = rsApp.Select(p => p.DeptCode).Distinct().ToList();
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);


            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);


            List<wfFormAppInfo> lsFormAppInfo = new List<wfFormAppInfo>();


            int x = 0, y = 0;
            int iProcessID = 0;
            foreach (var rsAppS in gAppS)
            {
                List<string> lsSendMail = new List<string>();
                lsSendMail.Add("");    //給主管審核用

                List<string> lsNoticeSendMail = new List<string>();
                lsNoticeSendMail.Add("");    //給通知人用

                string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工晉升單，請進入系統簽核";
                string sNoticeSubject = "【通知您】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之員工晉升單";
                string sBody = "";

                iProcessID = oService.GetProcessID();
                var AppointDynamic = (from c in dcFlow.FormsExtend//晉升單申請者確認節點編號
                                      where c.FormsCode == "Appoint" && c.Code == "AppointDynamic" && c.Active == true
                                      select c).ToList();
                
                foreach (var ADynamic in AppointDynamic)
                {
                    if (ADynamic != null && ADynamic.Column1 != null && ADynamic.Column1 != "" && ADynamic.Column2 != null && ADynamic.Column2 != "")
                    {
                        var NodeConfirm = (from c in dcFlow.wfDynamic
                                           where c.idProcess == iProcessID && c.idFlowNode == ADynamic.Column2
                                           select c).FirstOrDefault();
                        if (NodeConfirm != null)
                            continue;

                        var oCurrentJobStatus = new CurrentJobStatusDao();
                        var CurrentJobStatusCond = new CurrentJobStatusConditions();
                        CurrentJobStatusCond.AccessToken = _User.AccessToken;
                        CurrentJobStatusCond.RefreshToken = _User.RefreshToken;
                        CurrentJobStatusCond.CompanySetting = CompanySetting;
                        CurrentJobStatusCond.nobr = rsApp.First().EmpId;
                        CurrentJobStatusCond.Adate = DateTime.Now.Date;
                        var rsStatus = oCurrentJobStatus.GetData(CurrentJobStatusCond);
                        var rsTTS = new CurrentJobStatusRow();
                        if (rsStatus.Status && rsStatus.Data != null)
                        {
                            rsTTS = rsStatus.Data as CurrentJobStatusRow;
                        }
                        if (ADynamic.Column3 != null && (ADynamic.Column3 == "" || ADynamic.Column3 == rsTTS.Result.Saladr))
                        {
                            var rEmp = (from role in dcFlow.Role
                                        join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                        join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                        join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                        where role.Emp_id == ADynamic.Column2
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
                            if (rEmp != null)
                                oService.SaveDynamic(iProcessID, ADynamic.Column1, rEmp.EmpNobr, rEmp.RoleId);
                        }
                    }
                }

                var lsDeptchange = rsApp.Select(p => p.DeptmCodeChange).Distinct().ToList();
                var rsDeptChange = oDeptDao.GetDeptm(lsDeptchange, new List<string>() { });
                var rDeptChnge = rsDeptChange.Where(p => p.Code == rsAppS.First().DeptmCodeChange).FirstOrDefault();
                var AppointDynamicDept = (from c in dcFlow.FormsExtend
                                          where c.FormsCode == "Appoint" && c.Code == "AppointDynamicDept" && c.Active == true
                                          select c).ToList();
                foreach (var ADynamicDept in AppointDynamicDept)
                {
                    if (ADynamicDept.Column1 != null && ADynamicDept.Column1 != "")
                    {
                        var rEmp = (from role in dcFlow.Role
                                    join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                    join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                    join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                    where role.Emp_id == rDeptChnge.Manage
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
                        if (rEmp != null)
                            oService.SaveDynamic(iProcessID, ADynamicDept.Column1, rEmp.EmpNobr, rEmp.RoleId);
                    }
                }
                string sInfo = "";

                foreach (var rAppS in rsAppS)
                {
                    List<TextValueRow> resSalary = new List<TextValueRow>();

                    var AppointSalary = (from c in dcFlow.FormsExtend
                                         where c.FormsCode == "Appoint" && c.Code == "AppointSalary" && c.Active
                                         select c).FirstOrDefault();

                    if (AppointSalary != null)
                    {
                        var oBasicSalaryCode = new BasicSalaryCodeDao();
                        var BasicSalaryCodeCond = new BasicSalaryCodeConditions();
                        BasicSalaryCodeCond.AccessToken = _User.AccessToken;
                        BasicSalaryCodeCond.RefreshToken = _User.RefreshToken;
                        BasicSalaryCodeCond.CompanySetting = CompanySetting;
                        var resBasicSalCode = oBasicSalaryCode.GetData(BasicSalaryCodeCond);
                        if (resBasicSalCode.Status && resBasicSalCode.Data != null)
                        {
                            var rs = resBasicSalCode.Data as List<BasicSalaryCodeRow>;
                            if (rs != null)
                            {
                                foreach (var r in rs)
                                {
                                    var rTextValue = new TextValueRow();
                                    rTextValue.Text = r.SalName;
                                    rTextValue.Value = AccessData.DESEncrypt("0", "JBSalary", rAppS.Code.Substring(0, 8));
                                    rTextValue.Column1 = r.SalCode;
                                    resSalary.Add(rTextValue);
                                }
                            }
                        }
                    }
                    var oSalaryChange = new SalaryChangeDao();
                    var SalaryChangeCond = new SalaryChangeConditions();
                    SalaryChangeCond.AccessToken = _User.AccessToken;
                    SalaryChangeCond.RefreshToken = _User.RefreshToken;
                    SalaryChangeCond.CompanySetting = CompanySetting;
                    SalaryChangeCond.nobr = rAppS.EmpId;
                    SalaryChangeCond.CheckDate = DateTime.Now;
                    var SalrayData = oSalaryChange.GetData(SalaryChangeCond);
                    if (SalrayData.Status && SalrayData.Data != null)
                    {
                        var res = SalrayData.Data as List<SalaryChangeRow>;
                        if (res != null)
                        {
                            foreach (var r in res)
                            {
                                if (AppointSalary != null)
                                {
                                    foreach (var rsSalary in resSalary)
                                    {

                                        if (rsSalary.Column1 == r.SalCode)
                                        {
                                            rsSalary.Value = AccessData.DESEncrypt(r.Amount.ToString(), "JBSalary", rAppS.Code.Substring(0, 8));
                                        }
                                    }
                                }
                                else
                                {
                                    r.DESData = AccessData.DESEncrypt(r.Amount.ToString(), "JBSalary", rAppS.Code.Substring(0, 8));
                                    var rTextValue = new TextValueRow();
                                    rTextValue.Text = r.SalName;
                                    rTextValue.Value = r.DESData;
                                    rTextValue.Column1 = r.SalCode;
                                    resSalary.Add(rTextValue);
                                }
                            }
                        }
                    }

                    //新增寫入紀錄
                    var oFormsAppAppointChangeLog = new FormsAppAppointChangeLog();
                    oFormsAppAppointChangeLog.AppointCode = rAppS.Code;
                    oFormsAppAppointChangeLog.DateAppoint = rAppS.DateAppoint;
                    oFormsAppAppointChangeLog.DeptCodeChange = rAppS.DeptCodeChange;
                    oFormsAppAppointChangeLog.DeptNameChange = rAppS.DeptNameChange;
                    oFormsAppAppointChangeLog.DeptmCodeChange = rAppS.DeptmCodeChange;
                    oFormsAppAppointChangeLog.DeptmNameChange = rAppS.DeptmNameChange;
                    oFormsAppAppointChangeLog.JobCodeChange = rAppS.JobCodeChange;
                    oFormsAppAppointChangeLog.JobNameChange = rAppS.JobName;
                    oFormsAppAppointChangeLog.JoblCodeChange = rAppS.JoblCodeChange;
                    oFormsAppAppointChangeLog.JoblNameChange = rAppS.JoblNameChange;
                    oFormsAppAppointChangeLog.Performance1 = UnobtrusiveSession.Session["Performance1"].ToString();
                    oFormsAppAppointChangeLog.Performance2 = UnobtrusiveSession.Session["Performance2"].ToString();
                    oFormsAppAppointChangeLog.SalaryContent = JsonConvert.SerializeObject(resSalary);
                    oFormsAppAppointChangeLog.Note = "";
                    oFormsAppAppointChangeLog.Status = "1";
                    oFormsAppAppointChangeLog.InsertMan = _User.EmpName;
                    oFormsAppAppointChangeLog.InsertDate = DateTime.Now;
                    oFormsAppAppointChangeLog.UpdateMan = _User.EmpName;
                    oFormsAppAppointChangeLog.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppAppointChangeLog.InsertOnSubmit(oFormsAppAppointChangeLog);

                    var rsFormsAppInfo = (from c in dcFlow.FormsAppInfo
                                          where c.Code == rAppS.Code
                                          select c).FirstOrDefault();

                    if (rsFormsAppInfo != null)
                        sBody += rsFormsAppInfo.InfoMail;

                    //更改附檔流程序號
                    var rsFileWhere = rsFile.Where(p => p.sKey == rAppS.Code);
                    foreach (var rFileWhere in rsFileWhere)
                    {
                        rFileWhere.sProcessID = iProcessID.ToString();
                        rFileWhere.idProcess = iProcessID;
                    }

                    rAppS.ProcessId = iProcessID.ToString();
                    rAppS.idProcess = iProcessID;
                    rAppS.SignState = "1"; //開始
                    if (rsFormsAppInfo != null)
                    {
                        rsFormsAppInfo.ProcessId = iProcessID.ToString();
                        rsFormsAppInfo.idProcess = iProcessID;
                    }

                    //當角色不同時，就將資料寫入ProcessFlowShare
                    //if (rEmpM.RoleId != rAppS.sRole)
                    //    oService.FlowShare(rAppS.idProcess, rAppS.sRole, rAppS.sNobr);

                    //代理人通知

                    //if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    //{
                    //    var rAgent = (from c in dcFlow.Emp
                    //                  where c.id == rAppS.AgentEmpId.Trim()
                    //                  select c).FirstOrDefault();

                    //    if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                    //        lsSendMail.Add(rAgent.email.Trim());
                    //}

                    //通知信件
                    if (rsFormsAppInfo != null)
                        sInfo += rsFormsAppInfo.InfoSign + "<BR>";

                    //var rFormAppInfo = new wfFormAppInfo();
                    //rFormAppInfo.idProcess = iProcessID;
                    //rFormAppInfo.sProcessID = rFormAppInfo.idProcess.ToString();
                    //rFormAppInfo.sNobr = rAppS.EmpId;
                    //rFormAppInfo.sName = rAppS.EmpName;
                    //rFormAppInfo.sState = "1";
                    //rFormAppInfo.sInfo = sInfo;
                    //rFormAppInfo.sGuid = rAppS.Code;
                    //lsFormAppInfo.Add(rFormAppInfo);
                    //dcFlow.wfFormAppInfo.InsertOnSubmit(rFormAppInfo);


                }

                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = iProcessID.ToString();
                    rSendMail.idProcess = iProcessID;
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sNoticeSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = s != "";
                    rSendMail.sKeyMan = sNobrM;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }

                //通知信件
                foreach (var s in lsNoticeSendMail)
                {
                    if (s != "")
                    {
                        var rSendMail = new wfSendMail();
                        rSendMail.sProcessID = iProcessID.ToString();
                        rSendMail.idProcess = iProcessID;
                        rSendMail.sGuid = Guid.NewGuid().ToString();
                        rSendMail.sToAddress = s;
                        rSendMail.sSubject = sNoticeSubject;
                        rSendMail.sBody = sBody;
                        rSendMail.bOnly = s != "";
                        rSendMail.sKeyMan = sNobrM;
                        rSendMail.dKeyDate = DateTime.Now;
                        dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                    }
                }

                //var iTotalDay = 0;
                //iTotalDay = Convert.ToInt32(rsAppS.Max(p => p.iTotalDay));//取最高天數

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

                var RoteList = oAttendDao.GetAttend(rEmpM.EmpNobr, rsApp.First().DateA);
                var Rote = "0P";
                if (RoteList.Where(p => p.RoteCode == "0Z").ToList().Count > 0)
                {
                    Rote = "0Z";
                }

                if (RoteList.Where(p => p.RoteCode == "00").ToList().Count > 0)
                {
                    Rote = "00";
                }

                if (RoteList.Where(p => p.RoteCode == "0X").ToList().Count > 0)
                {
                    Rote = "0X";
                }
                //bool bAttendDataPass = false;
                //foreach (var rAppS in rsAppS)//判斷是否超過出勤鎖檔
                //{
                //    if (bAttendDataPass = oAttendDao.AttendDataPass(rAppS.sNobr, rAppS.dDateB, rAppS.dDateE))
                //        break;
                //}


                var rsDept = oDeptDao.GetDeptm(lsDept, new List<string>() { });
                var rDept = rsDept.Where(p => p.Code == rsAppS.First().DeptCode).FirstOrDefault();
                //var sDay = rsAppS.First().sUnit == "天" ? Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse))) : Convert.ToString(Convert.ToInt32(rsAppS.Max(p => p.iUse) / 8));

                var rBasS = oBasDao.GetBaseByNobr(rsAppS.First().EmpId, DateTime.Now.Date).FirstOrDefault();
                var rFormsApp = new FormsApp()
                {
                    FormsCode = "Appoint",
                    ProcessID = iProcessID.ToString(),
                    idProcess = iProcessID,
                    EmpId = rEmpM.EmpNobr,
                    EmpName = rEmpM.EmpName,
                    DeptCode = rEmpM.DeptCode,
                    DeptName = rEmpM.DeptName,
                    JobCode = rEmpM.JobCode,
                    JobName = rEmpM.JobName,
                    RoleId = rEmpM.RoleId,
                    DeptTreeB = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //被申請者的部門層級
                    DeptTreeE = rDept != null ? Convert.ToInt32(rDept.Tree) : 0, //目前所簽核到的部門
                    DateTimeA = DateTime.Now,
                    DateTimeD = null,
                    Sign = true,
                    SignState = "1",
                    Note = "",
                    Status = "1",
                    InsertDate = DateTime.Now,
                    InsertMan = rEmpM.EmpName,
                    UpdateDate = null,
                    UpdateMan = null,
                    Cond01 = rDept != null ? rDept.Tree : "0", //目前所簽核到的部門
                    Cond03 = Rote,
                    Cond04 = rEmpS.Auth ? "1" : "0",
                    Cond05 = rDept != null ? rDept.Tree : "0", //被申請者的部門層級
                    Cond06 = rBasS.JoblCode,
                    Cond07 = rsAppS.First().ChangeItemCode,
                    Cond08 = (rsAppS.First().DeptmCode == rsAppS.First().DeptmCodeChange) ? "0":"1" //簽核部門如有改變則為1，否則為0

                };


                dcFlow.FormsApp.InsertOnSubmit(rFormsApp);

                dcFlow.SubmitChanges();
                UnobtrusiveSession.Session["idProcess"] = iProcessID;
                string FlowTreeID = Session["FlowTreeID"].ToString();

                x++;
                if (oService.FlowStart(iProcessID, FlowTreeID, rsAppS.First().RoleId, rsAppS.First().EmpId, rEmpM.RoleId, rEmpM.EmpNobr))
                    y++;
            }

            if (x == y && y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('您的申請單已成功送出了');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            else if (y > 0)
                RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "alert('流程傳送成功 但有部份流程失敗');self.location = 'FormFlowImage.aspx?idProcess=" + iProcessID.ToString() + "';", true);
            //else
            //RadWindowManager1.RadAlert("流程傳送失敗", 300, 100, "警告訊息", "", ""); //刪除失敗 警告訊息
        }
    }
}