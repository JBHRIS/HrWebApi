using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bll.Absence.Vdb;
using Bll.Token.Vdb;
using Dal;
using Dal.Dao.Absence;
using Dal.Dao.Token;

namespace Portal.WebServices
{
    /// <summary>
    ///SaveAbs 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class SaveAbsWithApi : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Run(int ID)
        {
            dcHrDataContext dcHR = new dcHrDataContext();
            dcFlowDataContext dcFlow = new dcFlowDataContext();

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


            int ProcessID = ID;
            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            var rGetApView = oService.GetApView(ID);
            ProcessID = rGetApView.ProcessFlow_id;

            var rAppM = (from c in dcFlow.FormsApp
                         where c.idProcess == ProcessID
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppAbs
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

            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);

            string sSubject = "【通知】(" + rAppM.EmpId + ")" + rAppM.EmpName + " 之" + rForm.Name;
            string sBody = "";
            string sInfo = "";

            List<string> lsSendMail = new List<string>();

            var rEmp = (from c in rsEmp
                        where c.id == rAppM.EmpId
                        select c).FirstOrDefault();

            if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                lsSendMail.Add(rEmp.email);
            int iPass = 0;
            foreach (var rAppS in rsAppS)
            {
                var rAppInfo = rsAppInfo.Where(p => p.Code == rAppS.Code).FirstOrDefault();

                if (rAppM.FormsCode == "Abs1")
                    sSubject = "【通知】(" + rAppM.EmpId + ")" + rAppM.EmpName + " 之" + rForm.Name;

                if (rAppS.Sign)
                {
                    

                    var oAbsenceSave = new AbsenceSaveDao();
                    var AbsenceDataDetailCond = new AbsenceDataDetailConditions();
                    AbsenceDataDetailCond.AccessToken = ClientToken;
                    AbsenceDataDetailCond.nobr = rAppS.EmpId;
                    AbsenceDataDetailCond.startDateTime = rAppS.DateTimeB;
                    AbsenceDataDetailCond.endDateTime = rAppS.DateTimeE;
                    AbsenceDataDetailCond.hcode = rAppS.HolidayCode;

                    var rsAbsSave = oAbsenceSave.GetData(AbsenceDataDetailCond);

                    if (rsAbsSave.Status && rsAbsSave.Data != null)
                    {
                        var rAbs = rsAbsSave.Data as string;
                        if (rAbs == null || rAbs.ToLower() == "false")
                            iPass++;
                    }
                    else
                        iPass++;

                    //iPass = oAbsDao.AbsSave(rAppS.EmpId, rAppS.HolidayCode, rAppS.DateB, rAppS.DateE, rAppS.TimeB, rAppS.TimeE, rAppS.Note, rAppM.EmpName, "", rAppM.ProcessID, "", "", false, true, 0, false, "", true);

                    rAppS.SignState = "3";

                    if (rAppS.AgentEmpId != null && rAppS.AgentEmpId.Trim().Length > 0)
                    {
                        var rAgent = (from c in dcFlow.Emp
                                      where c.id == rAppS.AgentEmpId.Trim()
                                      select c).FirstOrDefault();

                        if (rAgent != null && rAgent.email.Trim().Length > 0 && !lsSendMail.Contains(rAgent.email.Trim()))
                            lsSendMail.Add(rAgent.email.Trim());
                    }
                }

                sBody += ("此筆資料" + (rAppS.SignState == "3" ? "<font color='blue'>核准</font>" : "<font color='red'>駁回</font>")) + rAppInfo.InfoMail + "<BR><BR>";



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

            dcFlow.SubmitChanges();

            return iPass == 0 ? true : false;
        }
    }
}
