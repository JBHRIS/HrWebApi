using Dal;
using OldBll.Att.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Portal.WebServices
{
    /// <summary>
    ///SaveAbn 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class SaveAbn : System.Web.Services.WebService
    {
        public SaveAbn()
        {

            //如果使用設計的元件，請取消註解下列一行
            //InitializeComponent(); 
        }
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

            var rsAppS = (from c in dcFlow.FormsAppAbn
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

            var rsEmp = (from c in dcFlow.Emp
                         where lsNobr.Contains(c.id)
                         select c).ToList();


            //Dal.Dao.Att.AbsDao oAbsDao = new Dal.Dao.Att.AbsDao(dcHR.Connection);
            //Dal.Dao.Att.OtDao oOtDao = new Dal.Dao.Att.OtDao(dcHR.Connection);
            OldDal.Dao.Att.AttendDao oAttDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);

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

                var rAppInfo = rsAppInfo.Where(p => p.idProcess == rAppS.idProcess).FirstOrDefault();
                if (rAppS.Sign)
                {
                    int iPass = 0;
                    AttendAbnormalRow Attend_Abn = new AttendAbnormalRow();
                    Attend_Abn.Nobr = rAppS.EmpId;
                    Attend_Abn.DateA = rAppS.DateB;
                    if (rAppS.IsEarlyWork == true)
                    {
                        Attend_Abn.Type = "ComeEarly";
                        int Edit = oAttDao.EditAttend(Attend_Abn);
                    }
                    if (rAppS.IsLateOut == true)
                    {
                        Attend_Abn.Type = "GoLate";
                        int Edit = oAttDao.EditAttend(Attend_Abn);
                    }
                    AttendCheckRow ACR = new AttendCheckRow();
                    ACR.Nobr = rAppS.EmpId;
                    ACR.DateA = rAppS.DateB;
                    ACR.RemarkType = rAppS.AbnCode;
                    ACR.Remark = rAppS.Note;
                    ACR.CreateDate = DateTime.Now;
                    ACR.CreateMan = "system";
                    ACR.UpdateDate = DateTime.Now;
                    ACR.UpdateMan = "system";
                    if (rAppS.IsEarlyWork == true)
                    {
                        ACR.Type = "ComeEarly";
                        iPass = oAttDao.SaveAttendCheck(ACR);
                    }
                    if (rAppS.IsLateOut == true)
                    {
                        ACR.Type = "GoLate";
                        iPass = oAttDao.SaveAttendCheck(ACR);
                    }


                    //iPass = oAbsDao.AbsSave(rAppS.sNobr, rAppS.sHcode, rAppS.dDateB, rAppS.dDateE, rAppS.sTimeB, rAppS.sTimeE, rAppS.sNote, rAppM.sName, "", rAppM.sProcessID, "", "", false, true, 0, false, "", true);

                    rAppS.SignState = "3";
                }

                sBody += ("此筆資料" + (rAppS.SignState == "3" ? "<font color='blue'>核准</font>" : "<font color='red'>駁回</font>")) + "<BR><BR>";

                rEmp = (from c in rsEmp
                        where c.id == rAppS.EmpId
                        select c).FirstOrDefault();

                if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                    lsSendMail.Add(rEmp.email);

                //Info狀態改變
                if (rAppInfo != null)
                    rAppInfo.SignState = rAppS.SignState;
            }
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

            return true;
        }
    }
}
