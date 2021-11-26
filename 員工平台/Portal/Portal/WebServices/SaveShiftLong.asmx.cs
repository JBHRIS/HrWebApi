using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Portal.WebServices
{
    /// <summary>
    ///SaveShiftLong 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class SaveShiftLong : System.Web.Services.WebService
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

            var rsAppS = (from c in dcFlow.FormsAppShiftLong
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

            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

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

                if (rAppS.Sign)
                {
                    DateTime dDate = rAppS.Date.Date;
                    bool bPass = oBasDao.BasettsSaveByShiftLong(rAppS.EmpId, dDate, rAppS.RotetCode, "", "", rAppS.Note, rAppM.EmpId, rAppM.ProcessID);
                    rAppS.SignState = "3";
                }

                sBody += ("此筆資料" + (rAppS.SignState == "3" ? "<font color='blue'>核准</font>" : "<font color='red'>駁回</font>")) + rAppInfo.InfoMail + "<BR><BR>";

                rEmp = (from c in rsEmp
                        where c.id == rAppS.EmpId
                        select c).FirstOrDefault();

                if (rEmp != null && rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                    lsSendMail.Add(rEmp.email);

                //Info狀態改變
                if (rAppInfo != null)
                    rAppInfo.SignState = rAppS.SignState;
            }


            dcFlow.SubmitChanges();

            return true;
        }
    }
}
