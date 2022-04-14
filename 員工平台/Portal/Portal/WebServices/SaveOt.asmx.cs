using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bll.AbsenceView.Vdb;
using Bll.Employee.Vdb;
using Bll.Token.Vdb;
using Dal;
using Dal.Dao.AbsenceView;
using Dal.Dao.Employee;
using Dal.Dao.Token;

namespace Portal.WebServices
{
    /// <summary>
    ///SaveOt 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class SaveOt : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Run(int ID)
        {
            dcHrDataContext dcHR = new dcHrDataContext();
            dcFlowDataContext dcFlow = new dcFlowDataContext();

            int ProcessID = ID;
            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            var rGetApView = oService.GetApView(ID);
            ProcessID = rGetApView.ProcessFlow_id;

            var rAppM = (from c in dcFlow.FormsApp
                         where c.idProcess == ProcessID
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where c.idProcess == ProcessID
                          select c).ToList();

            var rsAppInfo = (from c in dcFlow.FormsAppInfo
                             where c.idProcess == ProcessID
                             select c).ToList();

            var rForm = (from c in dcFlow.Forms
                         where c.Code == rAppM.FormsCode
                         select c).FirstOrDefault();

            if (rAppM == null || rsAppS.Count == 0)
                return false;

            //表單流程結束記號
            rAppM.SignState = rAppM.Sign ? "3" : rAppM.SignState;

            List<string> lsNobr = new List<string>();
            lsNobr.Add(rAppM.EmpId);
            lsNobr.AddRange(rsAppS.Select(p => p.EmpId));
            var D1 = new DateTime();
            var D2 = new DateTime();
            D1 = rAppM.DateTimeA.Value.Date;
            D2 = rAppM.DateTimeD == null ? DateTime.Now : rAppM.DateTimeD.Value.Date;

            var rsFormSignM = (from c in dcFlow.FormsSign
                               where c.idProcess == ProcessID
                               orderby c.InsertDate
                               select c).ToList();

            var rsEmp = (from c in dcFlow.Emp
                         where lsNobr.Contains(c.id)
                         select c).ToList();

            string sSignNote = "";
            foreach (var rFormSignM in rsFormSignM)
                sSignNote += "<BR>" + rFormSignM.EmpName + "：" + rFormSignM.SignNote;

            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);

            string sSubject = "【通知】(" + rAppM.EmpId + ")" + rAppM.EmpName + " 之" + rForm.Name;
            string sBody = "";

            List<string> lsSendMail = new List<string>();

            var rEmp = (from c in rsEmp
                        where c.id == rAppM.EmpId
                        select c).FirstOrDefault();

            if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                lsSendMail.Add(rEmp.email);


            foreach (var rAppS in rsAppS)
            {
                var rAppInfo = rsAppInfo.Where(p => p.Code == rAppS.Code).FirstOrDefault();

                if (rAppM.FormsCode == "Ot1")
                    sSubject = "【通知】(" + rAppM.EmpId + ")" + rAppM.EmpName + " 之預估加班單";

                if (rAppS.Sign)
                {
                    var OtCompensatory = (from c in dcFlow.FormsExtend
                                          where c.FormsCode == "Ot" && c.Code == "OtCompensatory" && c.Active == true
                                          select c).ToList();

                    var OtCompensatoryDateA = (from c in dcFlow.FormsExtend
                                               where c.FormsCode == "Ot" && c.Code == "OtCompensatoryDateA" && c.Active == true
                                               select c).FirstOrDefault();

                    DateTime? DateA = null;
                    if (OtCompensatoryDateA != null)
                    {
                        switch (OtCompensatoryDateA.Column1)
                        {
                            case "1"://加班日當天
                                DateA = rAppS.DateB;
                                break;

                            case "2"://加班日隔天
                                DateA = rAppS.DateB.AddDays(1);
                                break;

                            case "3"://加班日次月初
                                DateA = new DateTime(rAppS.DateB.Year, rAppS.DateB.Month + 1, 1);
                                break;
                        }
                    }

                    var OtCompensatoryDateD = (from c in dcFlow.FormsExtend
                                              where c.FormsCode == "Ot" && c.Code == "OtCompensatoryDateD" && c.Active == true
                                              select c).FirstOrDefault();
                    
                    DateTime? DateD = null;
                    if (OtCompensatoryDateD != null)
                    {
                        var oClientGetToken = new ClientGetTokenDao();
                        var ClientGetTokenCondition = new ClientGetTokenConditions();
                        ClientGetTokenCondition.ClientId = "JbFlow";
                        var ClientTokenData = oClientGetToken.GetData(ClientGetTokenCondition);
                        string ClientToken = "";
                        if (ClientTokenData.Status && ClientTokenData.Data != null)
                        {
                            var r = ClientTokenData.Data as ClientGetTokenRow;
                            ClientToken = r.AccessToken;
                        }
                        switch (OtCompensatoryDateD.Column1)
                        {
                            case "1"://年底
                                DateD = new DateTime(rAppS.DateB.Year, 12, 31).Date;
                                break;
                            case "2"://半年底
                                if (rAppS.DateB.Month <= 6)
                                    DateD = new DateTime(rAppS.DateB.Year, 6, 30).Date;
                                else
                                    DateD = new DateTime(rAppS.DateB.Year, 12, 31).Date;
                                break;
                            case "3"://季底
                                if (rAppS.DateB.Month <= 3)
                                    DateD = new DateTime(rAppS.DateB.Year, 3, 31).Date;
                                else if (rAppS.DateB.Month <= 6)
                                    DateD = new DateTime(rAppS.DateB.Year, 6, 30).Date;
                                else if (rAppS.DateB.Month <= 9)
                                    DateD = new DateTime(rAppS.DateB.Year, 9, 30).Date;
                                else
                                    DateD = new DateTime(rAppS.DateB.Year, 12, 31).Date;
                                break;
                            case "4"://和特休失效日一樣
                                if (OtCompensatoryDateD.Column2 != null && OtCompensatoryDateD.Column2 != "")
                                {
                                    var ListLeaveCode = new List<string>();
                                    ListLeaveCode.Add(OtCompensatoryDateD.Column2);
                                    var ListEmpId = new List<string>();
                                    ListEmpId.Add(rAppS.EmpId);
                                    var oAbsenceEntitleView = new AbsenceEntitleViewDao();
                                    var AbsenceEntitleViewCond = new AbsenceEntitleViewConditions();
                                    AbsenceEntitleViewCond.AccessToken = ClientToken;
                                    AbsenceEntitleViewCond.leaveCodeList = ListLeaveCode;
                                    AbsenceEntitleViewCond.employeeList = ListEmpId;
                                    AbsenceEntitleViewCond.dateBegin = rAppS.DateB;
                                    AbsenceEntitleViewCond.dateEnd = rAppS.DateE;

                                    var Result = oAbsenceEntitleView.GetData(AbsenceEntitleViewCond);
                                    var rs = new List<AbsenceEntitleViewRow>();
                                    if (Result.Status)
                                    {
                                        if (Result.Data != null)
                                        {
                                            rs = Result.Data as List<AbsenceEntitleViewRow>;
                                            if(rs.Count > 0)
                                                DateD =  rs[0].ExpirationDate;
                                        }
                                    }
                                }
                                break;
                            case "5"://到職日
                                var oEmployeeStartWorkDay = new EmployeeStartWorkDateDao();
                                var EmployeeStartWorkDayCond = new EmployeeStartWorkDateConditions();
                                EmployeeStartWorkDayCond.AccessToken = ClientToken;
                                EmployeeStartWorkDayCond.EmployeeID = rAppS.EmpId;
                                var rsEmpWorkStartDay = oEmployeeStartWorkDay.GetData(EmployeeStartWorkDayCond);

                                if (rsEmpWorkStartDay.Status && rsEmpWorkStartDay.Data != null)
                                {
                                    var EmpWorkStartDay = rsEmpWorkStartDay.Data as EmployeeStartWorkDateRow;
                                    if (EmpWorkStartDay != null)
                                    {
                                        DateD = new DateTime(rAppS.DateB.Year, EmpWorkStartDay.WorkDate.Month, EmpWorkStartDay.WorkDate.Day).Date;
                                        if (DateD < rAppS.DateB)
                                            DateD = new DateTime(rAppS.DateB.Year + 1, EmpWorkStartDay.WorkDate.Month, EmpWorkStartDay.WorkDate.Day).Date;
                                    }
                                }
                                break;
                            case "5-1"://到職日-1天
                                var oEmployeeStartWorkDay1 = new EmployeeStartWorkDateDao();
                                var EmployeeStartWorkDayCond1 = new EmployeeStartWorkDateConditions();
                                EmployeeStartWorkDayCond1.AccessToken = ClientToken;
                                EmployeeStartWorkDayCond1.EmployeeID = rAppS.EmpId;
                                var rsEmpWorkStartDay1 = oEmployeeStartWorkDay1.GetData(EmployeeStartWorkDayCond1);

                                if (rsEmpWorkStartDay1.Status && rsEmpWorkStartDay1.Data != null)
                                {
                                    var EmpWorkStartDay1 = rsEmpWorkStartDay1.Data as EmployeeStartWorkDateRow;
                                    if (EmpWorkStartDay1 != null)
                                    {
                                        DateD = new DateTime(rAppS.DateB.Year, EmpWorkStartDay1.WorkDate.Month, EmpWorkStartDay1.WorkDate.Day).AddDays(-1).Date;
                                        if (DateD < rAppS.DateB)
                                            DateD = new DateTime(rAppS.DateB.Year + 1, EmpWorkStartDay1.WorkDate.Month, EmpWorkStartDay1.WorkDate.Day).AddDays(-1).Date;
                                    }
                                }
                                break;
                            case "6"://加班日+N月
                                if (OtCompensatoryDateD.Column2 != null && OtCompensatoryDateD.Column2 != "")
                                    DateD = rAppS.DateB.AddMonths(Convert.ToInt32(OtCompensatoryDateD.Column2));
                                break;
                            case "7"://加班日+N月月底
                                if (OtCompensatoryDateD.Column2 != null && OtCompensatoryDateD.Column2 != "")
                                {
                                    DateD = rAppS.DateB.AddMonths(Convert.ToInt32(OtCompensatoryDateD.Column2));
                                    DateD = new DateTime(DateD.Value.Year, DateD.Value.Month, DateTime.DaysInMonth(DateD.Value.Year, DateD.Value.Month));
                                }
                                break;
                            case "8"://加班日<某個日期，則為該年底反之則為次年年底
                                if (OtCompensatoryDateD.Column2 != null && OtCompensatoryDateD.Column2 != "")
                                {
                                    var Month = Convert.ToInt32(OtCompensatoryDateD.Column2.Substring(0, 2));
                                    var Day  = Convert.ToInt32(OtCompensatoryDateD.Column2.Substring(2, 2));
                                    if (rAppS.DateB.Month > Month || (rAppS.DateB.Month == Month && rAppS.DateB.Day >= Day))
                                    {
                                        DateD = new DateTime(rAppS.DateB.Year + 1, 12 , 31);
                                    }
                                    else
                                    {
                                        DateD = new DateTime(rAppS.DateB.Year, 12, 31);
                                    }
                                }
                                break;
                            default:
                                break;
                        }

                    }
                    if (OtCompensatory == null || OtCompensatory.Count == 0)
                    {
                        int iPass = oOtDao.OtSave(rAppS.EmpId, rAppS.OtCateCode, rAppS.DateB,
                        rAppS.DateB, rAppS.TimeB, rAppS.TimeE, rAppS.Use, rAppS.OtrcdCode,
                        rAppS.RoteCode, rAppS.DeptsCode, "W04", rAppS.Note, rAppM.EmpName, rAppS.ProcessID,true, dDateA:DateA, dDateD:DateD);
                    }
                    else
                    {
                        foreach (var HcodeData in OtCompensatory)
                        {
                            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                            var rsBas = oBasDao.GetBaseByNobr(rAppS.EmpId, DateTime.Now).FirstOrDefault();
                            if (HcodeData.Column2 == rsBas.Saladr)
                            {
                                int iPass = oOtDao.OtSave(rAppS.EmpId, rAppS.OtCateCode, rAppS.DateB,
                                  rAppS.DateB, rAppS.TimeB, rAppS.TimeE, rAppS.Use, rAppS.OtrcdCode,
                                  rAppS.RoteCode, rAppS.DeptsCode, HcodeData.Column1, rAppS.Note, rAppM.EmpName, rAppS.ProcessID, true, dDateA: DateA, dDateD: DateD);
                                break;
                            }
                        }
                    }
                    rAppS.SignState = "3";

                }

                sBody += ("此筆資料" + (rAppS.SignState == "3" ? "<font color='blue'>核准</font>" : "<font color='red'>駁回</font>")) + rAppInfo.InfoMail + "<BR><BR>";

                D1 = D1 > rAppS.DateTimeB ? rAppS.DateTimeB : D1;//取得最小日期
                D2 = D2 < rAppS.DateTimeE ? rAppS.DateTimeE : D2;//取得最大日期

                rEmp = (from c in rsEmp
                        where c.id == rAppS.EmpId
                        select c).FirstOrDefault();

                ////啟動代理日期
                //if (rEmp != null)
                //{
                //    rEmp.dateB = rAppS.dDateTimeB;
                //    rEmp.dateE = rAppS.dDateTimeE;
                //}

                if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                    lsSendMail.Add(rEmp.email);

                //Info狀態改變

                if (rAppInfo != null)
                    rAppInfo.SignState = rAppS.SignState;
            }
            lsSendMail = lsSendMail.Distinct().ToList();
            if (sBody.Length > 0)
            {
                foreach (var s in lsSendMail)
                {
                    var rSendMail = new wfSendMail();
                    rSendMail.sProcessID = ProcessID.ToString();
                    rSendMail.idProcess = Convert.ToInt32(rSendMail.sProcessID);
                    rSendMail.sGuid = Guid.NewGuid().ToString();
                    rSendMail.sToAddress = s;
                    rSendMail.sSubject = sSubject;
                    rSendMail.sBody = sBody;
                    rSendMail.bOnly = true;
                    rSendMail.sKeyMan = rAppM.EmpId;
                    rSendMail.dKeyDate = DateTime.Now;
                    dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
                }
            }
            JBModule.Data.Linq.HrDBDataContext hrDB = new JBModule.Data.Linq.HrDBDataContext(dcHR.Connection);
            JBModule.Data.Service.LaborEventLawAbnormalDetectorService laborEventLawAbnormalDetectorService = new JBModule.Data.Service.LaborEventLawAbnormalDetectorService(hrDB);
            laborEventLawAbnormalDetectorService.UserName = rAppM.EmpName;
            laborEventLawAbnormalDetectorService.Run(lsNobr, D1.Date, D2.Date);
            dcFlow.SubmitChanges();

            return true;
        }
    }
}
