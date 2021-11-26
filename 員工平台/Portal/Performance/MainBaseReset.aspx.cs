using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
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
    public partial class MainBaseReset : WebPageBase
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

            //尋找允許簽出的部門
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
                            Msg = "(下層部門主管尚未簽核完成)";
                        else if (rNode.ActiveCode == "01")
                            Msg = "(已完成送出)";
                        else if (rNode.ActiveCode == "02")
                            Msg = "(已經退回前一關主管)";
                    }
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

            //基本資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                          && c.EmpId != _UserId
                          select c).ToList();

            //取得流程節點 尋找 主管可以簽的表單 且 未簽核結束的
            var rsNode = (from c in dcMain.PerformanceFlowNode
                          where ListFlowCode.Contains(c.PerformanceFlowCode)
                          && !c.IsFinish
                          && c.EmpIdDefault == _UserId
                          select c).ToList();

            var ListFlowNodeCode = rsNode.Select(p => p.Code).ToList();

            var rsBaseLog = (from c in dcMain.PerformanceBaseLog
                             where c.PerformanceMainCode == MainCode
                             && ListFlowNodeCode.Contains(c.PerformanceFlowNodeCode)
                             && c.EmpId != _UserId
                             select c).ToList();

            var i = 0;
            foreach (var rBaseLog in rsBaseLog)
            {
                var rBase = rsBase.FirstOrDefault(p => p.EmpId == rBaseLog.EmpId);

                if (rBase != null)
                {
                    rBase.WorkPerformance = rBaseLog.WorkPerformance;    //工作績效
                    rBase.MannerEsteem = rBaseLog.MannerEsteem;   //態度評價
                    rBase.AbilityEsteem = rBaseLog.AbilityEsteem;  //能力評價
                    rBase.Encourage = rBaseLog.Encourage;  //激勵
                    rBase.TotalIntegrate = rBaseLog.TotalIntegrate; //總積分
                    rBase.RatingCode = rBaseLog.RatingCode;    //評等
                    rBase.BonusCardinal = rBaseLog.BonusCardinal;  //獎金基數
                    rBase.InWorkSpecific = rBaseLog.InWorkSpecific; //在職比
                    rBase.BonusTotal = rBaseLog.BonusTotal; //總獎金
                    rBase.BonusDeduct = rBaseLog.BonusDeduct;    //可扣獎金
                    rBase.BonusMax = rBaseLog.BonusMax;    //最高加發獎金
                    rBase.BonusAdjust = rBaseLog.BonusAdjust;    //考績加減
                    rBase.BonusReal = rBaseLog.BonusReal;  //實際獎金
                    rBase.Note = rBaseLog.Note;

                    i++;
                }
            }

            dcMain.SubmitChanges();

            lblMsg.Text = "還原成功，共還原" + i + "筆資料";
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