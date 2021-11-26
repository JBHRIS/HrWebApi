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
    public partial class MainBaseApprove : WebPageBase
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

            var Sign = 0;

            var rDept = dcMain.PerformanceDept.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.Code == DeptCode);
            var DeptTree = 0;
            var TopInfo = "(您已經是最高階主管)";
            if (rDept != null)
            {
                //取得最高主管部門層級
                DeptTree = rDept.DeptTree;

                //下一關主管姓名
                rDept = dcMain.PerformanceDept.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.Code == rDept.ParentCode);
                if (rDept != null)
                    TopInfo = rDept.JobName + " " + rDept.ManagerName;
                else
                    Sign = 999;
            }



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

                if (Msg.Length == 0)
                {
                    //只有第一次進來才會改變簽核狀態
                    if (Sign == 0 && Sign != 999)
                        Sign = 1;

                    if (DeptTree >= rFlow.DeptTreeE)
                    {
                        Msg = "(可以簽核後流程結束)";
                        if (Sign != 999)
                        Sign = 2;
                    }
                    else
                    {
                        Msg = "(呈送下階簽核主管：" + TopInfo + ")";
                    }
                }

                cbDept.Text += Msg;
            } 

            LoadData(Sign);
        }

        public void LoadData(int Key)
        {
            var Sign = Key;

            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
               UnobtrusiveSession.Session["ListDept"] == null ||
               UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var EmpId = _User.UserCode;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var ListDeptCode = cblDept.Items.Cast<ButtonListItem>().Where(x => x.Selected).Select(x => x.Value).ToList();

            var rs = (from c in dcMain.PerformanceBase
                      where ListDeptCode.Contains(c.PerformanceDeptCode)
                      && c.PerformanceMainCode == MainCode
                      && c.EmpId != EmpId
                      select c).Distinct().ToList();

            //取出當前部門層級
            var rDept = dcMain.PerformanceDept.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.Code == DeptCode);
            var DeptTree = 0;
            if (rDept != null)
            {
                //取得最高主管部門層級
                DeptTree = rDept.DeptTree;
            }

            //判斷最高主管層級必須大於部門設定的可視層級才可以看獎金
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.Code)
                          select c).ToList();

            var TopDeptTreeB = rsDept.Count > 0 ? rsDept.Max(p => p.DeptTreeB) : 0;

            //必須大於等於
            var BonusView = DeptTree >= TopDeptTreeB;

            lblPeopleNumber.Text = rs.Count.ToString();
            if (BonusView)
            {
                lblBonusReal.Text = string.Format("{0:N0}", rs.Sum(p => p.BonusReal));

                var BonusAdjust = -rs.Sum(p => p.BonusAdjust);
                lblBonusBalance.Text = string.Format("{0:N0}", BonusAdjust);
                lblBonusBalance.ForeColor = Color.Blue;
                if (BonusAdjust < 0)
                    lblBonusBalance.ForeColor = Color.Red;
            }

            //無法呈核 = 已經是最高階主管
            //無法核准 = 不是可核決者
            btnSign.Enabled = (Sign != 0) && (Sign != 999) && cblDept.Items.Cast<ButtonListItem>().Where(x => x.Selected).Count() > 0;
            btnApprove.Enabled = (Sign == 2 || Sign == 999) && cblDept.Items.Cast<ButtonListItem>().Where(x => x.Selected).Count() > 0;
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

            var cn = ((RadButton)sender).CommandName;
            var Approve = cn == "Approve";

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

            //取得人員名單 可能會超過2000筆 當條件會有問題
            var ListEmpId = rsBase.Select(p => p.EmpId).ToList();

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
            var EmpIdDefault = rDept.ParentManagerId;   //只寄給當前審核主管的主管，正確的寫法應該要取得節點的主管，再尋找該主管
            var DeptCodeDefault = rDept.ParentCode;

            //暫時存入部門資訊 稍後要寄信
            List<TextValueRow> rsDeptManager = new List<TextValueRow>();
            var rDeptManager = new TextValueRow();

            //準備寫入現有資料表           

            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            select c).ToList();

            var DateNow = DateTime.Now.Date;
            var rsBasetts = (from c in dcHr.ViewEmp
                             where DateNow >= c.DateA
                             && DateNow <= c.DateD
                             && ListEmpId.Contains(c.Code)
                             select new
                             {
                                 EmpId = c.Code,
                                 DeptCode = c.DeptCode,
                             }).ToList();

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

            foreach (var dc in ListDeptCode)
            {
                var rFlow = rsFlow.FirstOrDefault(p => p.PerformanceDeptCode == dc);

                if (rFlow != null)
                {
                    //取得目前所有節點
                    var rsNodeByFlowCode = rsNode.Where(p => p.PerformanceFlowCode == rFlow.Code).ToList();

                    if (rsNodeByFlowCode.Count > 0)
                    {
                        //反向排序找出最大值 再 加1
                        var Sort = rsNodeByFlowCode.OrderByDescending(p => p.Sort).First().Sort + 1;

                        var rNode = rsNodeByFlowCode.FirstOrDefault(p => p.EmpIdDefault == _UserId && !p.IsFinish);
                        if (rNode != null)
                        {
                            rNode.IsFinish = true;
                            rNode.EmpIdReal = _UserId;
                            rNode.PerformanceDeptCodeReal = DeptCode;
                            rNode.DeptTree = DeptTree;
                            rNode.UpdateMan = _UserId;
                            rNode.UpdateDate = DateTime.Now;

                            rFlow.DeptTree = DeptTree;
                            rFlow.UpdateMan = _UserId;
                            rFlow.UpdateDate = DateTime.Now;

                            //記錄過程
                            var rSign = new PerformanceFlowSign();
                            rSign.PerformanceFlowCode = rFlow.Code;
                            rSign.PerformanceFlowNodeCode = rNode.Code;
                            rSign.Code = Guid.NewGuid().ToString();
                            rSign.EmpId = _UserId;
                            rSign.EmpName = rDept.ManagerName;
                            rSign.JobCode = rDept.JobCode;
                            rSign.JobName = rDept.JobName;
                            rSign.ActiveCode = "01";
                            rSign.Sort = Sort;
                            rSign.Note = txtNote.Text;
                            rSign.InfoLog = "";
                            rSign.InsertMan = _UserId;
                            rSign.InsertDate = DateTime.Now;
                            rSign.UpdateMan = _UserId;
                            rSign.UpdateDate = DateTime.Now;
                            dcMain.PerformanceFlowSign.InsertOnSubmit(rSign);

                            //判斷流程是否需要結束
                            //如果當前部門層級大於最大的層級 就結束流程
                            if (Approve && (rFlow.DeptTree >= rFlow.DeptTreeE))
                            {
                                //流程結束
                                rSign.ActiveCode = "03";

                                rFlow.IsFinish = true;

                                //把結果寫回HR系統
                                var rsBaseByDept = rsBase.Where(p => p.PerformanceDeptCode == dc).ToList();
                                foreach (var rPerformanceBase in rsBaseByDept)
                                {
                                    var EmpId = rPerformanceBase.EmpId;
                                    var DeptCode1 = rPerformanceBase.PerformanceDeptCode;
                                    var JobCode = rPerformanceBase.JobCode;
                                    var JoblCode = rPerformanceBase.JoblCode;
                                    var Note = rPerformanceBase.Note;

                                    //置換成編制部門代碼
                                    var rBasetts = rsBasetts.FirstOrDefault(p => p.EmpId == EmpId);
                                    if (rBasetts != null)
                                        DeptCode1 = rBasetts.DeptCode;

                                    var rRating = rsRating.FirstOrDefault(p => p.Code == rPerformanceBase.RatingCode);
                                }

                                //通知HR審核完成
                            }
                            else
                            {
                                //創出一個新的審核節點
                                var rNodeNew = new PerformanceFlowNode();
                                rNodeNew.PerformanceFlowCode = rFlow.Code;
                                rNodeNew.Code = Guid.NewGuid().ToString();
                                rNodeNew.ParentCode = rNode.Code;
                                rNodeNew.PerformanceDeptCodeDefault = DeptCodeDefault;
                                rNodeNew.EmpIdDefault = EmpIdDefault;
                                rNodeNew.PerformanceDeptCodeReal = "";
                                rNodeNew.EmpIdReal = "";
                                rNodeNew.IsFinish = false;
                                rNodeNew.DeptTree = 0;
                                rNodeNew.DeptSort = rNode.DeptSort + 1;
                                rNodeNew.ActiveCode = "00";
                                rNodeNew.Sort = Sort;
                                rNodeNew.InsertMan = _UserId;
                                rNodeNew.InsertDate = DateTime.Now;
                                rNodeNew.UpdateMan = _UserId;
                                rNodeNew.UpdateDate = DateTime.Now;
                                dcMain.PerformanceFlowNode.InsertOnSubmit(rNodeNew);

                                //將資料存到log裡
                                var rsBaseByDept = rsBase.Where(p => p.PerformanceDeptCode == dc).ToList();
                                foreach (var rPerformanceBase in rsBaseByDept)
                                {
                                    var rPerformanceBaseLog = new PerformanceBaseLog();
                                    rPerformanceBase.CopyPropertyValues(rPerformanceBaseLog);
                                    rPerformanceBaseLog.PerformanceFlowNodeCode = rNodeNew.Code;
                                    dcMain.PerformanceBaseLog.InsertOnSubmit(rPerformanceBaseLog);
                                }

                                //立即通知主管審核
                            }

                            rNode.ActiveCode = rSign.ActiveCode;

                            //準備寄信
                            rDeptManager.Value = rFlow.PerformanceDeptCode;
                            rDeptManager.Text = rSign.ActiveCode;
                            rsDeptManager.Add(rDeptManager);
                        }
                    }
                }
            }

            dcMain.SubmitChanges();

            rDept = (from c in dcMain.PerformanceDept
                     where c.PerformanceMainCode == MainCode
                     && c.ManagerId == EmpIdDefault
                     orderby c.DeptTree descending
                     select c).FirstOrDefault();

            if (rDept != null)
            {
                var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
                var rMail = oShareDefault.DefaultMail;

                var FromAddr = "service@jbjob.com.tw";
                var FromName = "傑報管理系統";
                if (rMail != null)
                {
                    FromAddr = rMail.Sender;
                    FromName = rMail.SenderName;
                }

                int i = 0;
                var rsMailTpl = dcShare.ShareMailTpl.Where(p => p.Key1 == "Performance").ToList();
                foreach (var r in rsDeptManager)
                {
                    var rMailTpl = rsMailTpl.FirstOrDefault(p => p.Code == r.Text);
                    if (rMailTpl != null)
                    {
                        if (r.Text == "03")
                            continue;

                        var dcParameter = new Dictionary<string, string>();
                        dcParameter.Add("MainCode", MainCode);
                        dcParameter.Add("DeptCode", r.Value);

                        var Subject = "";
                        var Body = "";

                        //放入當前部門代碼及登入者工號
                        var ValidateKey = Guid.NewGuid().ToString();
                        var Parm = "ValidateKey=" + ValidateKey + "&EmpId=" + EmpIdDefault + "&DeptCode=" + DeptCode;
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
            }

            _DataBind();
            gvMain.Rebind();

            lblMsg.Text = "送出成功";
        }

        protected void gvMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var _UserId = _User.UserCode;

            List<string> ListDeptCode = ListDept.Select(p => p.Code).ToList();

            //取得各流程主要代碼
            var rsFlow = (from c in dcMain.PerformanceFlow
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                          select c).ToList();

            var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

            var rs = (from c in dcMain.PerformanceFlowSign
                      where ListFlowCode.Contains(c.PerformanceFlowCode)
                      orderby c.PerformanceFlowCode, c.Sort, c.InsertDate
                      select c).ToList();

            //取得動作代碼
            var rsPerformanceFlowSignActive = oMainDao.ShareCodeTextValue("PerformanceFlowSignActive");

            //取得部門資訊
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.Code)
                          select c).ToList();

            //置換
            foreach (var r in rs)
            {
                //置換動作代碼為中文
                var rPerformanceFlowSignActive = rsPerformanceFlowSignActive.FirstOrDefault(p => p.Value == r.ActiveCode);
                if (rPerformanceFlowSignActive != null)
                    r.ActiveCode = rPerformanceFlowSignActive.Text;

                //置換部門代碼為中文
                var rFlow = rsFlow.FirstOrDefault(p => p.Code == r.PerformanceFlowCode);
                if (rFlow != null)
                {
                    var rDpet = rsDept.FirstOrDefault(p => p.Code == rFlow.PerformanceDeptCode);
                    if (rDpet != null)
                        r.PerformanceFlowCode = rDpet.Name;
                }
            }

            gvMain.DataSource = rs;
        }

        protected void gvMain_ExportCellFormatting(object sender, ExportCellFormattingEventArgs e)
        {
            e.Cell.Style["mso-number-format"] = @"\@";
        }

        protected void gvMain_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void gvMain_DataBound(object sender, EventArgs e)
        {

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