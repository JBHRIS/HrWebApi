using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Bll;
using Bll.Absence.Vdb;
using Bll.Employee.Vdb;
using Bll.Flow.Vdb;
using Bll.Salary.Vdb;
using Bll.Token.Vdb;
using Dal;
using Dal.Dao.Absence;
using Dal.Dao.Employee;
using Dal.Dao.Flow;
using Dal.Dao.Salary;
using Dal.Dao.Token;
using Newtonsoft.Json;

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
    public class SaveEmploy : System.Web.Services.WebService
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

            var oFormAppEmployDao = new FormsAppEmployByProcessIdDao();
            var FormAppEmployCond = new FormsAppEmployByProcessIdConditions();
            FormAppEmployCond.ProcessFlowID = ProcessID.ToString();
            FormAppEmployCond.Sign = true;
            FormAppEmployCond.SignState = "";
            FormAppEmployCond.Status = "";

            var rsFormAppEmploy = oFormAppEmployDao.GetData(FormAppEmployCond);
            var rFormAppEmploy = new FormsAppEmployByProcessIdRow();
            if (rsFormAppEmploy.Status)
            {
                if (rsFormAppEmploy.Data != null)
                {
                    rFormAppEmploy = rsFormAppEmploy.Data as FormsAppEmployByProcessIdRow;
                }
            }

            var rAppM = (from c in dcFlow.FormsApp
                         where c.idProcess == ProcessID
                         select c).FirstOrDefault();

            var rsAppS = (from c in dcFlow.FormsAppEmploy
                          where c.idProcess == ProcessID
                          select c).ToList();

            var rsAppInfo = (from c in dcFlow.FormsAppInfo
                             where c.idProcess == ProcessID
                             select c).ToList();

            var rForm = (from c in dcFlow.Forms
                         where c.Code == rAppM.FormsCode
                         select c).FirstOrDefault();

            if (rAppM == null || rsAppS.Count == 0 || rFormAppEmploy == null)
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

            string sSubject = "【通知】(" + rsAppS.First().EmpId + ")" + rsAppS.First().EmpName + " 之" + rForm.Name;
            string sBody = "";
            string sInfo = "";

            List<string> lsSendMail = new List<string>();

            var rEmp = (from c in rsEmp
                        where c.id == rAppM.EmpId
                        select c).FirstOrDefault();

            if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                lsSendMail.Add(rEmp.email);
            bool iPass = false;
            foreach (var rAppS in rsAppS)
            {
                var rAppInfo = rsAppInfo.Where(p => p.Code == rAppS.Code).FirstOrDefault();

                if (rAppS.Sign)
                {
                    if (rAppM.FormsCode == "Employ")
                    {
                        var oCurrentJobStatus = new CurrentJobStatusDao();
                        var CurrentJobStatusCond = new CurrentJobStatusConditions();
                        CurrentJobStatusCond.AccessToken = ClientToken;
                        CurrentJobStatusCond.nobr = rAppS.EmpId;
                        CurrentJobStatusCond.Adate = DateTime.Now.Date;
                        var rsStatus = oCurrentJobStatus.GetData(CurrentJobStatusCond);
                        if (rsStatus.Status && rsStatus.Data != null)
                        {
                            var rsTTS = rsStatus.Data as CurrentJobStatusRow;
                            var oUpdateEmployeeInfo = new EmployeeJobStatusAddChangeDao();
                            var UpdateEmployeeInfoCond = new EmployeeJobStatusAddChangeConditions();
                            UpdateEmployeeInfoCond.AccessToken = ClientToken;
                            UpdateEmployeeInfoCond.TTS = rsTTS.Result;
                            if (rFormAppEmploy.ResultAreaCode != "03")
                            {
                                UpdateEmployeeInfoCond.TTS.Ttscode = rFormAppEmploy.ResultAreaCode == "04" ? "2" : "6";
                                UpdateEmployeeInfoCond.TTS.Adate = rFormAppEmploy.DateAppoint;
                                UpdateEmployeeInfoCond.TTS.Ddate = new DateTime(9999, 12, 31);
                                if (rFormAppEmploy.ResultAreaCode == "04")
                                    UpdateEmployeeInfoCond.TTS.Oudt = rFormAppEmploy.DateAppoint;
                                UpdateEmployeeInfoCond.TTS.Dept = rFormAppEmploy.DeptCodeChange;
                                UpdateEmployeeInfoCond.TTS.Deptm = rFormAppEmploy.DeptmCodeChange;
                                UpdateEmployeeInfoCond.TTS.Job = rFormAppEmploy.JobCodeChange;
                                UpdateEmployeeInfoCond.TTS.Jobl = rFormAppEmploy.JoblCodeChange;
                                UpdateEmployeeInfoCond.TTS.KeyDate = DateTime.Now.Date;
                                UpdateEmployeeInfoCond.TTS.KeyMan = rAppM.EmpName;
                                var rsUpdateInfo = oUpdateEmployeeInfo.GetData(UpdateEmployeeInfoCond);
                                if (rsUpdateInfo.Status && rsUpdateInfo != null)
                                    iPass = rsUpdateInfo.Status;
                                else
                                    iPass = false;
                            }
                            else
                            {
                                UpdateEmployeeInfoCond.TTS.Ttscode = "6";
                                UpdateEmployeeInfoCond.TTS.Adate = rFormAppEmploy.DateAppoint;
                                UpdateEmployeeInfoCond.TTS.ApDate = UpdateEmployeeInfoCond.TTS.ApDate.GetValueOrDefault().AddMonths(rFormAppEmploy.ExtendMonth);
                                UpdateEmployeeInfoCond.TTS.KeyDate = DateTime.Now.Date;
                                UpdateEmployeeInfoCond.TTS.KeyMan = rAppM.EmpName;
                                var rsUpdateInfo = oUpdateEmployeeInfo.GetData(UpdateEmployeeInfoCond);
                                if (rsUpdateInfo.Status && rsUpdateInfo != null)
                                    iPass = rsUpdateInfo.Status;
                                else
                                    iPass = false;
                            }
                        }

                        //新增薪資異動資料
                        if (iPass)
                        {
                            var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppEmploy.ChangeLogs.Last().SalaryContent);
                            foreach (var Salary in SalaryData)
                            {
                                Salary.Value = AccessData.DESDecrypt(Salary.Value, "JBSalary", rFormAppEmploy.ChangeLogs.Last().EmployCode.Substring(0, 8));
                                var oAddSalaryChange = new AddSalaryChangeDao();
                                var AddSalaryChangeCond = new AddSalaryChangeConditions();
                                AddSalaryChangeCond.AccessToken = ClientToken;
                                AddSalaryChangeCond.employeeId = rAppS.EmpId;
                                AddSalaryChangeCond.SalaryCode = Salary.Column1;
                                AddSalaryChangeCond.ChageDate = DateTime.Now.Date;
                                AddSalaryChangeCond.Amount = Convert.ToDecimal(Salary.Value);
                                AddSalaryChangeCond.Remark = "";
                                var rsSalaryChange = oAddSalaryChange.GetData(AddSalaryChangeCond);
                                if (rsSalaryChange.Status && rsSalaryChange.Data != null)
                                    iPass = rsSalaryChange.Status;
                                if (!iPass)
                                    break;
                            }
                        }
                    }
                    //iPass = oAbsDao.AbsSave(rAppS.EmpId, rAppS.HolidayCode, rAppS.DateB, rAppS.DateE, rAppS.TimeB, rAppS.TimeE, rAppS.Note, rAppM.EmpName, "", rAppM.ProcessID, "", "", false, true, 0, false, "", true);

                    rAppS.SignState = "3";


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

            return iPass;
        }
    }
}
