using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace Performance
{
    public partial class MainBaseReminder : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                _DataBind();
            }

            lblMsg.Text = "";
        }

        public void _DataBind()
        {
            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var EmpId = _User.UserCode;

            var ListDeptCode = ListDept.Select(p => p.Code).ToList();

            //用部門反推可以簽核的部門(可以用員工基本資料推也可以用主程推)
            //取得主流程
            var rsFlow = (from pf in dcMain.PerformanceFlow
                          where ListDeptCode.Contains(pf.PerformanceDeptCode)
                          && pf.PerformanceMainCode == MainCode
                          select pf).ToList();

            ListDeptCode = rsFlow.Select(p => p.PerformanceDeptCode).ToList();
            var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

            //取得流程節點 尋找 主管可以簽的表單 且 未簽核結束的
            var rsNode = (from c in dcMain.PerformanceFlowNode
                          where ListFlowCode.Contains(c.PerformanceFlowCode)
                          select c).ToList();

            //垂直展開門
            var rs = (from c in dcMain.PerformanceDept
                      where ListDeptCode.Contains(c.Code)
                      && c.PerformanceMainCode == MainCode
                      select new TextValueRow
                      {
                          Text = c.Name,
                          Value = c.Code,
                      }).ToList();

            cblDept.DataSource = rs;
            cblDept.DataBindings.DataTextField = "Text";
            cblDept.DataBindings.DataValueField = "Value";
            cblDept.DataBind();

            //尋找允許退回的部門
            foreach (ButtonListItem cbDept in cblDept.Items)
            {
                var Dept = cbDept.Value;
                var Msg = "";

                var rFlow = rsFlow.FirstOrDefault(p => p.PerformanceDeptCode == Dept);
                if (rFlow.IsFinish && rFlow.IsCancel && rFlow.IsError)
                    Msg = "(流程暫停)";
                else if (rFlow.IsFinish)
                    Msg = "(流程已簽核完成)";
                else if (rFlow.IsCancel)
                    Msg = "(流程取消)";
                else if (rFlow.IsError)
                    Msg = "(流程發生異常)";
                else
                {
                    //流程相關節點
                    var rsNodeByFlowCode = rsNode.Where(p => p.PerformanceFlowCode == rFlow.Code).ToList();

                    //反向排序尋找最後一筆(理論上，不可能找不到資料)
                    var rNode = rsNodeByFlowCode.OrderByDescending(p => p.Sort).First();

                    if (!(!rNode.IsFinish && rNode.EmpIdDefault == EmpId))
                    {
                        rNode = rsNodeByFlowCode.Where(p => p.EmpIdDefault == EmpId).OrderByDescending(p => p.Sort).FirstOrDefault();
                        if (rNode == null)
                            //Msg = "(下層部門主管尚未簽核完成)";
                            Msg = "";
                        else if (rNode.ActiveCode == "01")
                            Msg = "(已完成送出)";
                        else if (rNode.ActiveCode == "02")
                            //Msg = "(已經退回前一關主管)";
                            Msg = "";
                    }
                    else if (rNode.DeptSort == 1)
                        Msg = "(第一關無法催簽)";
                    else
                        Msg = "(流程在自己身上)";
                }

                cbDept.Selected = Msg.Length == 0;
                cbDept.Enabled = Msg.Length == 0;

                cbDept.Text += Msg;
            }

            LoadData(0);
        }

        public void LoadData(int Key)
        {
            btnSign.Enabled = cblDept.Items.Cast<ButtonListItem>().Where(x => x.Selected).Count() > 0;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var _UserId = _User.UserCode;

            List<string> ListDeptCode = cblDept.Items.Cast<ButtonListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "考核主檔設定錯誤，請洽人事單位";
                return;
            }

            var Yymm = rMain.Yymm;
            var EmpCategoryCode = rMain.EmpCategoryCode;

            //取得主流程
            var rsFlow = (from pf in dcMain.PerformanceFlow
                          where ListDeptCode.Contains(pf.PerformanceDeptCode)
                          && pf.PerformanceMainCode == MainCode
                          && !pf.IsCancel
                          && !pf.IsError
                          && !pf.IsFinish
                          select pf).ToList();

            var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

            //取得流程節點 尋找 主管可以簽的表單 且 未簽核結束的
            var rsNode = (from c in dcMain.PerformanceFlowNode
                          where ListFlowCode.Contains(c.PerformanceFlowCode)
                          //&& !c.IsFinish
                          //&& c.EmpIdDefault == _UserCode
                          select c).ToList();

            //取出當前部門層級
            var rDept = dcMain.PerformanceDept.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.Code == DeptCode);
            if (rDept == null)
            {
                lblMsg.Text = "部門資訊不正確，請洽管理單位(1)";
                return;
            }

            var DeptTree = rDept.DeptTree;
            var EmpIdDefault = rDept.ParentManagerId;

            //暫時存入部門資訊 稍後要寄信
            List<TextValueRow> rsDeptManager = new List<TextValueRow>();
            var rDeptManager = new TextValueRow();

            foreach (var dc in ListDeptCode)
            {
                var rFlow = rsFlow.FirstOrDefault(p => p.PerformanceDeptCode == dc);

                if (rFlow != null)
                {
                    //取得目前所有節點
                    var rsNodeByFlowCode = rsNode.Where(p => p.PerformanceFlowCode == rFlow.Code).ToList();

                    if (rsNodeByFlowCode.Count > 0)
                    {
                        //反向排序
                        var rNode = rsNodeByFlowCode.OrderByDescending(p => p.Sort).First();
                        if (rNode != null)
                        {
                            //準備寄信
                            rDeptManager.Value = rFlow.PerformanceDeptCode;
                            rDeptManager.Text = rNode.EmpIdDefault;
                            rsDeptManager.Add(rDeptManager);
                        }
                    }
                }
            }

            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          //&& c.ManagerId == EmpIdDefault
                          orderby c.DeptTree descending
                          select c).ToList();

            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rMail = oShareDefault.DefaultMail;

            var FromAddr = "service@jbjob.com.tw";
            var FromName = "傑報管理系統";
            if (rMail != null)
            {
                FromAddr = rMail.Sender;
                FromName = rMail.SenderName;
            }

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

            int i = 0;
            var rsMailTpl = dcShare.ShareMailTpl.Where(p => p.Key1 == "Performance").ToList();
            foreach (var r in rsDeptManager)
            {
                var rMailTpl = rsMailTpl.FirstOrDefault(p => p.Code == "01-2");
                if (rMailTpl != null)
                {
                    var rDept1 = rsDept.FirstOrDefault(p => p.ManagerId == r.Text);

                    var dcParameter = new Dictionary<string, string>();
                    dcParameter.Add("MainCode", MainCode);
                    dcParameter.Add("DeptCode", r.Value);

                    var Subject = "";
                    var Body = "";

                    //放入當前部門代碼及登入者工號
                    var ValidateKey = Guid.NewGuid().ToString();
                    var Parm = "ValidateKey=" + ValidateKey + "&EmpId=" + rDept1.ManagerId + "&DeptCode=" + rDept1.Code;
                    Parm = Security.Encrypt(Parm);
                    oValidateDao.SetValidate(ValidateKey, Parm);

                    oPerformance.OutMailContent(out Subject, out Body, rMailTpl.AutoKey, 0, true, dcParameter, Parm);

                    var rShareSendQueue = new ShareSendQueue();
                    rShareSendQueue.SystemCode = WebPage._SystemCode;
                    rShareSendQueue.Code = Guid.NewGuid().ToString();
                    rShareSendQueue.SendTypeCode = "01";
                    rShareSendQueue.FromAddr = FromAddr;
                    rShareSendQueue.FromName = FromName;
                    rShareSendQueue.ToAddr = rDept.Mail;
                    rShareSendQueue.ToName = rDept.ManagerName;
                    rShareSendQueue.ToAddrCopy = "";
                    rShareSendQueue.ToNameCopy = "";
                    rShareSendQueue.ToAddrConfidential = "";
                    rShareSendQueue.ToNameConfidential = "";
                    rShareSendQueue.Subject = Subject;
                    rShareSendQueue.Body = Body;
                    rShareSendQueue.Retry = 0;
                    rShareSendQueue.Sucess = false;
                    rShareSendQueue.Suspend = false;
                    rShareSendQueue.DateSend = DateTime.Now;
                    rShareSendQueue.Sort = 9;
                    rShareSendQueue.Note = "";
                    rShareSendQueue.Status = "1";
                    rShareSendQueue.InsertMan = _User.UserCode;
                    rShareSendQueue.InsertDate = DateTime.Now;
                    rShareSendQueue.UpdateMan = _User.UserCode;
                    rShareSendQueue.UpdateDate = DateTime.Now;
                    dcShare.ShareSendQueue.InsertOnSubmit(rShareSendQueue);       

                    i++;
                }
            }

            dcShare.SubmitChanges();

            lblMsg.Text = "送出成功";
        }        

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }
    }
}