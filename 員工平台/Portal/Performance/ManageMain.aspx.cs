using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
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
    public partial class ManageMain : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlType_DataBind();
            }
        }

        public void ddlType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("PerformanceType");

            ddlType.DataSource = rs;
            ddlType.DataTextField = "Text";
            ddlType.DataValueField = "Value";
            ddlType.DataBind();
        }

        protected void ddlType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();
        }

        public void _DataBind()
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlType.SelectedItem == null)
                return;

            var TypeCode = ddlType.SelectedItem.Value;

            var rs = (from c in dcMain.PerformanceMain
                          //join b in dcMain.EMPTYPE on c.EmpCategoryCode equals b.EMP_TYPE
                      where c.TypeCode == TypeCode
                      select new PerformanceMainRow
                      {
                          AutoKey = c.AutoKey,
                          Name = c.Name,
                          Yymm = c.Yymm,
                          DateBase = c.DateBase,
                          DateA = c.DateA,
                          DateD = c.DateD,
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._DefDate),
                          EmpCategoryCode = c.EmpCategoryCode,
                          EmpCategoryName = "",
                          DeptCount = dcMain.PerformanceFlow.Count(p => p.PerformanceMainCode == c.Code),
                          EmpCount = dcMain.PerformanceBase.Count(p => p.PerformanceMainCode == c.Code),
                      }).ToList();

            var rsEmpCategory = oMainDao.ShareCodeNameCode("EmpCategory");

            foreach (var r in rs)
            {
                r.EmpCategoryName = rsEmpCategory.FirstOrDefault(p => p.Code == r.EmpCategoryCode)?.Name ?? r.EmpCategoryName;
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            if (dt.Columns.Contains("EmpCategoryCode")) dt.Columns.Remove("EmpCategoryCode");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("PerformanceMain");
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

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (ddlType.SelectedItem == null)
                return;

            var TypeCode = ddlType.SelectedItem.Value;

            var rs = (from c in dcMain.PerformanceMain
                          //join b in dcMain.EMPTYPE on c.EmpCategoryCode equals b.EMP_TYPE
                      where c.TypeCode == TypeCode
                      select new PerformanceMainRow
                      {
                          AutoKey = c.AutoKey,
                          Name = c.Name,
                          Yymm = c.Yymm,
                          DateBase = c.DateBase,
                          DateA = c.DateA,
                          DateD = c.DateD,
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._DefDate),
                          EmpCategoryCode = c.EmpCategoryCode,
                          EmpCategoryName = "",
                          DeptCount = dcMain.PerformanceFlow.Count(p => p.PerformanceMainCode == c.Code),
                          EmpCount = dcMain.PerformanceBase.Count(p => p.PerformanceMainCode == c.Code),
                      }).ToList();

            var rsEmpCategory = oMainDao.ShareCodeNameCode("EmpCategory");

            foreach (var r in rs)
            {
                r.EmpCategoryName = rsEmpCategory.FirstOrDefault(p => p.Code == r.EmpCategoryCode)?.Name ?? r.EmpCategoryName;
            }

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        public class PerformanceMainRow
        {
            public int AutoKey { get; set; }
            public string Name { get; set; }
            public string Yymm { get; set; }
            public DateTime DateBase { get; set; }
            public DateTime DateA { get; set; }
            public DateTime DateD { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
            public string EmpCategoryCode { get; set; }
            public string EmpCategoryName { get; set; }
            public int DeptCount { get; set; }
            public int EmpCount { get; set; }

        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "Edit")
            {
                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMainEdit.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "MainDept")
            {
                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMainDept.aspx?AutoKey=" + AutoKey);
            }

            if (cn == "MailSend" || cn == "Reminder")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                var msg = "無寄送信件";

                var rPerformanceMain = dcMain.PerformanceMain.FirstOrDefault(p => p.AutoKey == AutoKey);

                if (rPerformanceMain != null)
                {
                    var Code = rPerformanceMain.Code;

                    var rsPerformanceDept = dcMain.PerformanceDept.Where(p => p.PerformanceMainCode == Code).ToList();

                    var rsPerformanceFlow = dcMain.PerformanceFlow.Where(p => p.PerformanceMainCode == Code).ToList();

                    var ListFlowCode = rsPerformanceFlow.Select(p => p.Code).Distinct().ToList();

                    var rsPerformanceFlowNode = dcMain.PerformanceFlowNode.Where(p => ListFlowCode.Contains(p.PerformanceFlowCode)).ToList();

                    var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

                    var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
                    var rMail = oShareDefault.DefaultMail;

                    var FromAddr = "service@jbjob.com.tw";
                    var FromName = "傑報管理系統";
                    if (rMail != null)
                    {
                        FromAddr = rMail.Sender;
                        FromName = rMail.SenderName;
                    }

                    //寄送通知信
                    int i = 0;
                    var MailCode = "01-1";
                    if (cn == "Reminder")
                        MailCode = "01-2";
                    var rMailTpl = dcShare.ShareMailTpl.FirstOrDefault(p => p.Key1 == "Performance" && p.Code == MailCode);
                    if (rMailTpl != null)
                    {
                        foreach (var rPerformanceFlow in rsPerformanceFlow)
                        {
                            var rPerformanceFlowNode = rsPerformanceFlowNode.FirstOrDefault(p => p.PerformanceFlowCode == rPerformanceFlow.Code );

                            if (rPerformanceFlowNode != null)
                            {
                                var rPerformanceDept = rsPerformanceDept.FirstOrDefault(p => p.ManagerId == rPerformanceFlowNode.EmpIdDefault);
                                if (rPerformanceDept != null)
                                {
                                    if (rPerformanceDept.Mail.IndexOf("@") >= 0)
                                    {
                                        var EmpIdDefault = rPerformanceDept.ManagerId;
                                        var DeptCode = rPerformanceDept.Code;

                                        var dcParameter = new Dictionary<string, string>();
                                        dcParameter.Add("MainCode", Code);
                                        dcParameter.Add("DeptCode", rPerformanceFlow.PerformanceDeptCode);

                                        //放入當前部門代碼及登入者工號
                                        var ValidateKey = Guid.NewGuid().ToString();
                                        var Parm = "ValidateKey=" + ValidateKey + "&EmpId=" + EmpIdDefault + "&DeptCode=" + DeptCode;
                                        Parm = Security.Encrypt(Parm);
                                        oValidateDao.SetValidate(ValidateKey, Parm);

                                        var Subject = "";
                                        var Body = "";
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

                                        i++;
                                    }
                                }
                            }
                        }
                        dcShare.SubmitChanges();

                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：", "", "Performance-寄送全體信件", "", _User.UserCode);

                        msg = "通知成功，共通知" + i.ToString() + "封信件";
                    }
                }

                lblMsg.Text = msg;

                lvMain.Rebind();
            }

            if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcMain.PerformanceMain
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                if (r != null)
                {
                    var Code = r.Code;

                    //基本資料
                    var rsPerformanceBase = (from c in dcMain.PerformanceBase
                                             where c.PerformanceMainCode == Code
                                             select c).ToList();

                    var rsPerformanceBaseLog = (from c in dcMain.PerformanceBaseLog
                                                where c.PerformanceMainCode == Code
                                                select c).ToList();

                    //部門資料
                    var rsPerformanceDept = (from c in dcMain.PerformanceDept
                                             where c.PerformanceMainCode == Code
                                             select c).ToList();

                    var rsPerformanceDeptRating = (from c in dcMain.PerformanceDeptRating
                                                   where c.PerformanceMainCode == Code
                                                   select c).ToList();

                    //主流程
                    var rsFlow = (from c in dcMain.PerformanceFlow
                                  where c.PerformanceMainCode == Code
                                  select c).ToList();

                    var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

                    //流程節點
                    var rsNode = (from c in dcMain.PerformanceFlowNode
                                  where ListFlowCode.Contains(c.PerformanceFlowCode)
                                  select c).ToList();

                    //簽核記錄
                    var rsSign = (from c in dcMain.PerformanceFlowSign
                                  where ListFlowCode.Contains(c.PerformanceFlowCode)
                                  select c).ToList();

                    dcMain.PerformanceMain.DeleteOnSubmit(r);
                    dcMain.PerformanceDept.DeleteAllOnSubmit(rsPerformanceDept);
                    dcMain.PerformanceDeptRating.DeleteAllOnSubmit(rsPerformanceDeptRating);
                    dcMain.PerformanceBase.DeleteAllOnSubmit(rsPerformanceBase);
                    dcMain.PerformanceBaseLog.DeleteAllOnSubmit(rsPerformanceBaseLog);
                    dcMain.PerformanceFlowSign.DeleteAllOnSubmit(rsSign);
                    dcMain.PerformanceFlowNode.DeleteAllOnSubmit(rsNode);
                    dcMain.PerformanceFlow.DeleteAllOnSubmit(rsFlow);

                    dcMain.SubmitChanges();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：", "", "Performance-刪除考核資料", "", _User.UserCode);

                    var msg = "刪除完成";

                    lblMsg.Text = msg;

                    lvMain.Rebind();
                }
            }
        }
    }
}