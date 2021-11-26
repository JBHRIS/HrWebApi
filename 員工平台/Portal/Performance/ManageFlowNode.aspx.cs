using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageFlowNode : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }
        }

        public void _DataBind()
        {

        }

        public class NodeRow
        {
            public int AutoKey { get; set; }

            public string PerformanceDeptCodeDefault { get; set; }
            public string PerformanceDeptNameDefault { get; set; }
            public string PerformanceDeptCodeReal { get; set; }
            public string PerformanceDeptNameReal { get; set; }

            public string EmpIdDefault { get; set; }
            public string EmpNameDefault { get; set; }
            public string EmpIdReal { get; set; }
            public string EmpNameReal { get; set; }

            public string ActiveCode { get; set; }
            public string ActiveName { get; set; }

            public bool IsFinish { get; set; }

            public string UpdateMan { get; set; }
            public DateTime? UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            //取得各流程主要代碼
            var rsFlow = (from c in dcMain.PerformanceFlow
                          where c.PerformanceMainCode == MainCode
                          && (c.PerformanceDeptCode == DeptCode || DeptCode == "-")
                          select c).ToList();

            var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

            var rs = (from c in dcMain.PerformanceFlowNode
                      where ListFlowCode.Contains(c.PerformanceFlowCode)
                      orderby c.Sort
                      select new NodeRow
                      {
                          AutoKey = c.AutoKey,
                          PerformanceDeptCodeDefault = c.PerformanceDeptCodeDefault,
                          PerformanceDeptCodeReal = c.PerformanceDeptCodeReal,
                          EmpIdDefault = c.EmpIdDefault,
                          EmpIdReal = c.EmpIdReal,
                          ActiveCode = c.ActiveCode,
                          IsFinish = c.IsFinish,
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate,
                      }).ToList();

            //取得動作代碼
            var rsPerformanceFlowSignActive = oMainDao.ShareCodeTextValue("PerformanceFlowSignActive");

            //取得部門資訊
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            //置換
            foreach (var r in rs)
            {
                //置換動作代碼為中文
                var rPerformanceFlowSignActive = rsPerformanceFlowSignActive.FirstOrDefault(p => p.Value == r.ActiveCode);
                if (rPerformanceFlowSignActive != null)
                    r.ActiveName = rPerformanceFlowSignActive.Text;

                if (r.ActiveCode == "00")
                    r.ActiveName = "未送出";

                //置換部門代碼為中文
                var rDept = rsDept.FirstOrDefault(p => p.Code == r.PerformanceDeptCodeDefault);
                if (rDept != null)
                    r.PerformanceDeptNameDefault = rDept.Name;

                rDept = rsDept.FirstOrDefault(p => p.Code == r.PerformanceDeptCodeReal);
                if (rDept != null)
                    r.PerformanceDeptNameReal = rDept.Name;

                //置換工號為中文
                rDept = rsDept.FirstOrDefault(p => p.ManagerId == r.EmpIdDefault);
                if (rDept != null)
                    r.EmpNameDefault = rDept.ManagerName;

                rDept = rsDept.FirstOrDefault(p => p.ManagerId == r.EmpIdReal);
                if (rDept != null)
                    r.EmpNameReal = rDept.ManagerName;
            }

            //處理html
            foreach (var r in rs)
            {
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareMailTpl");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }

        protected void btnFlowSet_Click(object sender, EventArgs e)
        {
            var btn = sender as RadButton;
            FlowSet(btn.CommandName);
        }

        private void FlowSet(string FlowSet)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            if (DeptCode == "-")
            {
                lblMsg.Text = "部門全選中，流程無法處理，請選擇一個部門";
                return;
            }

            var rFlow = (from c in dcMain.PerformanceFlow
                         where c.PerformanceMainCode == MainCode
                         && c.PerformanceDeptCode == DeptCode
                         select c).FirstOrDefault();

            if (rFlow != null)
            {
                var FlowCode = rFlow.Code;

                switch (FlowSet)
                {
                    case "ReStart":
                        var rsNode = (from c in dcMain.PerformanceFlowNode
                                      where c.PerformanceFlowCode == FlowCode
                                      select c).ToList();

                        var rNode = rsNode.FirstOrDefault(p => p.Sort == 1);
                        if (rNode != null)
                        {
                            //改變主流程
                            rFlow.IsFinish = false;

                            //改變目前節點
                            rNode.IsFinish = false;
                            rNode.EmpIdReal = "";
                            rNode.PerformanceDeptCodeReal = "";
                            rNode.ActiveCode = "00";
                            rNode.UpdateMan = _User.UserCode;
                            rNode.UpdateDate = DateTime.Now;

                            //刪除後面的流程
                            rsNode = rsNode.Where(p => p.Sort > 1).ToList();

                            dcMain.PerformanceFlowNode.DeleteAllOnSubmit(rsNode);
                            dcMain.SubmitChanges();

                            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rNode), "", "Performance-流程重送", "", _User.UserCode);

                        }

                        break;
                    case "Cancel":
                        //改變主流程
                        rFlow.IsCancel = true;
                        dcMain.SubmitChanges();

                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rFlow), "", "Performance-中止流程", "", _User.UserCode);
                        break;
                    case "Start":
                        rFlow.IsCancel = false;
                        dcMain.SubmitChanges();

                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rFlow), "", "Performance-恢復重送", "", _User.UserCode);
                        break;
                }

                lvMain.Rebind();
            }
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = new List<NodeRow>();

            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lvMain.DataSource = rs;
                return;
            }

            //取得各流程主要代碼
            var rsFlow = (from c in dcMain.PerformanceFlow
                          where c.PerformanceMainCode == MainCode
                          && (c.PerformanceDeptCode == DeptCode || DeptCode == "-")
                          select c).ToList();

            var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

            rs = (from c in dcMain.PerformanceFlowNode
                  where ListFlowCode.Contains(c.PerformanceFlowCode)
                  orderby c.Sort
                  select new NodeRow
                  {
                      AutoKey = c.AutoKey,
                      PerformanceDeptCodeDefault = c.PerformanceDeptCodeDefault,
                      PerformanceDeptCodeReal = c.PerformanceDeptCodeReal,
                      EmpIdDefault = c.EmpIdDefault,
                      EmpIdReal = c.EmpIdReal,
                      ActiveCode = c.ActiveCode,
                      IsFinish = c.IsFinish,
                      UpdateMan = c.UpdateMan,
                      UpdateDate = c.UpdateDate,
                  }).ToList();

            //取得動作代碼
            var rsPerformanceFlowSignActive = oMainDao.ShareCodeTextValue("PerformanceFlowSignActive");

            //取得部門資訊
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            //置換
            foreach (var r in rs)
            {
                //置換動作代碼為中文
                var rPerformanceFlowSignActive = rsPerformanceFlowSignActive.FirstOrDefault(p => p.Value == r.ActiveCode);
                if (rPerformanceFlowSignActive != null)
                    r.ActiveName = rPerformanceFlowSignActive.Text;

                if (r.ActiveCode == "00")
                    r.ActiveName = "未送出";

                //置換部門代碼為中文
                var rDept = rsDept.FirstOrDefault(p => p.Code == r.PerformanceDeptCodeDefault);
                if (rDept != null)
                    r.PerformanceDeptNameDefault = rDept.Name;

                rDept = rsDept.FirstOrDefault(p => p.Code == r.PerformanceDeptCodeReal);
                if (rDept != null)
                    r.PerformanceDeptNameReal = rDept.Name;

                //置換工號為中文
                rDept = rsDept.FirstOrDefault(p => p.ManagerId == r.EmpIdDefault);
                if (rDept != null)
                    r.EmpNameDefault = rDept.ManagerName;

                rDept = rsDept.FirstOrDefault(p => p.ManagerId == r.EmpIdReal);
                if (rDept != null)
                    r.EmpNameReal = rDept.ManagerName;
            }

            lvMain.DataSource = rs;

            btnFlowCancel.Enabled = !rsFlow.Any(p => p.IsCancel);
            btnFlowStart.Enabled = rsFlow.Any(p => p.IsCancel);

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "Start")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                //刪除本節點之後的節點
                var rNode = (from c in dcMain.PerformanceFlowNode
                             where c.AutoKey == AutoKey
                             select c).FirstOrDefault();

                if (rNode != null)
                {
                    var Sort = rNode.Sort;

                    var FlowCode = rNode.PerformanceFlowCode;

                    var rFlow = (from c in dcMain.PerformanceFlow
                                 where c.Code == FlowCode
                                 select c).FirstOrDefault();

                    if (rFlow != null)
                    {
                        //改變主流程
                        rFlow.IsFinish = false;

                        //改變目前節點
                        rNode.IsFinish = false;
                        rNode.EmpIdReal = "";
                        rNode.PerformanceDeptCodeReal = "";
                        rNode.ActiveCode = "00";
                        rNode.UpdateMan = _User.UserCode;
                        rNode.UpdateDate = DateTime.Now;

                        //刪除後面的流程
                        var rsNode = (from c in dcMain.PerformanceFlowNode
                                      where c.PerformanceFlowCode == FlowCode
                                      && c.Sort > Sort
                                      select c).ToList();

                        //記錄過程
                        var rSign = new PerformanceFlowSign();
                        rSign.PerformanceFlowCode = rFlow.Code;
                        rSign.PerformanceFlowNodeCode = rNode.Code;
                        rSign.Code = Guid.NewGuid().ToString();
                        rSign.EmpId = _User.UserCode;
                        rSign.EmpName = _User.UserCode;
                        rSign.JobCode = "";
                        rSign.JobName = "";
                        rSign.ActiveCode = "01";
                        rSign.Sort = Sort;
                        rSign.Note = "人事重送";
                        rSign.InfoLog = "";
                        rSign.InsertMan = _User.UserCode;
                        rSign.InsertDate = DateTime.Now;
                        rSign.UpdateMan = _User.UserCode;
                        rSign.UpdateDate = DateTime.Now;
                        dcMain.PerformanceFlowSign.InsertOnSubmit(rSign);

                        dcMain.PerformanceFlowNode.DeleteAllOnSubmit(rsNode);
                        dcMain.SubmitChanges();

                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rFlow), "", "Performance-節點重送", "", _User.UserCode);
                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rNode), "", "Performance-節點重送", "", _User.UserCode);
                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rSign), "", "Performance-節點重送", "", _User.UserCode);

                        lvMain.Rebind();
                    }
                }
            }
            if (cn == "Change")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageFlowNodeChange.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "MailSend" || cn == "Reminder")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                var msg = "無寄送信件";

                var rNode = dcMain.PerformanceFlowNode.FirstOrDefault(p => p.AutoKey == AutoKey);

                var MailCode = "01-1";
                if (cn == "Reminder")
                    MailCode = "01-2";
                var rMailTpl = dcShare.ShareMailTpl.FirstOrDefault(p => p.Key1 == "Performance" && p.Code == MailCode);
                if (rMailTpl != null)
                    if (rNode != null)
                    {
                        var EmpIdDefault = rNode.EmpIdDefault;

                        var rPerformanceDept = dcMain.PerformanceDept.FirstOrDefault(p => p.ManagerId == EmpIdDefault);
                        if (rPerformanceDept != null)
                        {
                            if (rPerformanceDept.Mail.IndexOf("@") >= 0)
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

                                var dcParameter = new Dictionary<string, string>();
                                dcParameter.Add("MainCode", MainCode);
                                dcParameter.Add("DeptCode", DeptCode);

                                //放入當前部門代碼及登入者工號
                                var ValidateKey = Guid.NewGuid().ToString();
                                var Parm = "ValidateKey=" + ValidateKey + "&EmpId=" + EmpIdDefault + "&DeptCode=" + DeptCode;
                                Parm = Security.Encrypt(Parm);
                                oValidateDao.SetValidate(ValidateKey, Parm);

                                var Subject = "";
                                var Body = "";
                                var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
                                oPerformance.OutMailContent(out Subject, out Body, rMailTpl.AutoKey, 0, true, dcParameter, Parm);

                                var rShareSendQueue = new ShareSendQueue();
                                rShareSendQueue.SystemCode = WebPage._SystemCode;
                                rShareSendQueue.Code = Guid.NewGuid().ToString();
                                rShareSendQueue.SendTypeCode = "01";
                                rShareSendQueue.FromAddr = FromAddr;
                                rShareSendQueue.FromName = FromName;
                                rShareSendQueue.ToAddr = rPerformanceDept.Mail;
                                rShareSendQueue.ToName = rPerformanceDept.ManagerName;
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

                                dcMain.SubmitChanges();

                                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rShareSendQueue), "", "Performance-通知", "", _User.UserCode);

                              msg = "通知成功";
                            }
                        }
                    }
                lblMsg.Text = msg;
            }
        }
    }
}