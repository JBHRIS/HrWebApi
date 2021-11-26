using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
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
    public partial class MainReportContentDept : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                var ph = (ContentPlaceHolder)this.Master.Master.FindControl("cphMain");
                if (ph != null)
                {
                    var phEtc = ph.FindControl("phEtc");
                    if (phEtc != null)
                        ((PlaceHolder)phEtc).Visible = false;
                }

                 ph = (ContentPlaceHolder)this.Master.Master.FindControl("cphMain");
                if (ph != null)
                {
                    var phContentDept = ph.FindControl("phContentDept");
                    if (phContentDept != null)
                        ((PlaceHolder)phContentDept).Visible = true;
                }
            }

            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportExcel);
        }

        public void _DataBind()
        {

        }
        public List<ReportContentRow> ListReportContent
        {
            get
            {
                var Value = new List<ReportContentRow>();
                if (WebPage.DataCache && UnobtrusiveSession.Session["ReportContentDept"] != null )
                {
                    Value = (List<ReportContentRow>)UnobtrusiveSession.Session["ReportContentDept"];
                }
                else
                {
                    var TypeCode = lblTypeCode.Text;
                    var MainCode = lblMainCode.Text;
                    var DeptCode = lblDeptCode.Text;
                    var SubDept = lblSubDept.Text == "1";
                    var Base = lblBase.Text == "1";

                    var EmpId = _User.UserCode;

                    if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var ReportTypeCode = lblReportTypeCode.Text;
                    var ReportContentCode = lblReportContentCode.Text;

                    if (ReportTypeCode.Length == 0 || ReportContentCode.Length == 0)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var cphMain = (ContentPlaceHolder)this.Master.Master.FindControl("cphMain");
                    if (cphMain != null)
                    {
                        var lblCopy = cphMain.FindControl("lblCopy");
                        if (lblCopy != null)
                        {
                            ((RadLabel)lblCopy).Text = "複本";
                            ViewState["Copy"] = "1";
                        }
                    }

                    var rs = (from c in dcMain.PerformanceReportContentDept
                              where c.PerformanceReportTypeCode == ReportTypeCode
                              && c.PerformanceMainCode == MainCode
                              && c.PerformanceDeptCode == DeptCode
                              && (ReportContentCode == "0" || c.ReportContentCode == ReportContentCode)
                              select new ReportContentRow
                              {
                                  AutoKey = c.AutoKey,
                                  Code = c.Code,
                                  ReportContentCode = c.ReportContentCode,
                                  ReportContentName = "",
                                  ContentTargetType = c.ContentTargetType,
                                  ContentTargetRef = c.ContentTargetRef,
                                  ReportContentSort = 0,
                                  Sort = c.Sort,
                                  UpdateMan = c.UpdateMan,
                                  UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                              }).ToList();

                    if (rs.Count == 0)
                    {
                        if (cphMain != null)
                        {
                            var lblCopy = cphMain.FindControl("lblCopy");
                            if (lblCopy != null)
                            {
                                ((RadLabel)lblCopy).Text = "樣版";
                                ViewState["Copy"] = "0";
                            }
                        }

                        rs = (from c in dcMain.PerformanceReportContent
                              where c.PerformanceReportTypeCode == ReportTypeCode
                              && (ReportContentCode == "0" || c.ReportContentCode == ReportContentCode)
                              orderby c.ReportContentCode, c.Sort
                              select new ReportContentRow
                              {
                                  AutoKey = c.AutoKey,
                                  Code = c.Code,
                                  ReportContentCode = c.ReportContentCode,
                                  ReportContentName = "",
                                  ContentTargetType = c.ContentTargetType,
                                  ContentTargetRef = c.ContentTargetRef,
                                  ReportContentSort = 0,
                                  Sort = c.Sort,
                                  UpdateMan = c.UpdateMan,
                                  UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                              }).ToList();
                    }

                    var rsReportContent = oMainDao.ShareCodeTextValue("ReportContent");

                    foreach (var r in rs)
                    {
                        var rReportContent = rsReportContent.FirstOrDefault(p => p.Value == r.ReportContentCode);
                        if (rReportContent != null)
                        {
                            r.ReportContentName = rReportContent.Text;
                            r.ReportContentSort = rReportContent.Sort;
                        }
                    }

                    Value = rs.OrderBy(p => p.ReportContentSort).ThenBy(p => p.Sort).ToList();

                    UnobtrusiveSession.Session["ReportContentDept"] = Value;
                }

                return Value;
            }
        }

        public class ReportContentRow
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string ReportContentCode { get; set; }
            public string ReportContentName { get; set; }
            public string ContentTargetType { get; set; }
            public string ContentTargetRef { get; set; }
            public int ReportContentSort { get; set; }
            public int Sort { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = ListReportContent;

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Report");
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

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;
            var SubDept = lblSubDept.Text == "1";
            var Base = lblBase.Text == "1";

            var EmpId = _User.UserCode;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var ReportTypeCode = lblReportTypeCode.Text;
            var ReportContentCode = lblReportContentCode.Text;

            if (ReportTypeCode.Length == 0 || ReportContentCode.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            //刪除目前的內容
            var rsDept = (from c in dcMain.PerformanceReportContentDept
                          where c.PerformanceReportTypeCode == ReportTypeCode
                          && c.PerformanceMainCode == MainCode
                          && c.PerformanceDeptCode == DeptCode
                          select c).ToList();

            dcMain.PerformanceReportContentDept.DeleteAllOnSubmit(rsDept);

            var rs = (from c in dcMain.PerformanceReportContent
                      where c.PerformanceReportTypeCode == ReportTypeCode
                      select c).ToList();

            var ListReportContentDept = new List<PerformanceReportContentDept>();

            foreach (var r in rs)
            {
                var rReportContentDept = new PerformanceReportContentDept();
                rReportContentDept.Code = Guid.NewGuid().ToString();
                rReportContentDept.PerformanceReportTypeCode = r.PerformanceReportTypeCode;
                rReportContentDept.PerformanceMainCode = MainCode;
                rReportContentDept.PerformanceDeptCode = DeptCode;
                rReportContentDept.ReportContentCode = r.ReportContentCode;
                rReportContentDept.ContentTargetType = r.ContentTargetType;
                rReportContentDept.ContentTargetRef = r.ContentTargetRef;
                rReportContentDept.Note = r.Note;
                rReportContentDept.Sort = r.Sort;
                rReportContentDept.InsertMan = _User.UserCode;
                rReportContentDept.InsertDate = DateTime.Now;
                rReportContentDept.UpdateMan = _User.UserCode;
                rReportContentDept.UpdateDate = DateTime.Now;
                ListReportContentDept.Add(rReportContentDept);
            }

            dcMain.PerformanceReportContentDept.InsertAllOnSubmit(ListReportContentDept);

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rsDept), "", "Performance-刪除部門報表內容", "", _User.UserCode);

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(ListReportContentDept), "", "Performance-新增部門報表內容", "", _User.UserCode);

            lblMsg.Text = "複製完成";

            lvMain.Rebind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;
            var SubDept = lblSubDept.Text == "1";
            var Base = lblBase.Text == "1";

            var EmpId = _User.UserCode;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var ReportTypeCode = lblReportTypeCode.Text;
            var ReportContentCode = lblReportContentCode.Text;

            if (ReportTypeCode.Length == 0 || ReportContentCode.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var State = ViewState["Copy"].ToString();
            if (State != "1")
            {
                lblMsg.Text = "您不能直接修改樣版內容，請先按複製樣版";
                return;
            }

            if (ReportContentCode == "0")
            {
                lblMsg.Text = "請先選擇一個評核內容再按新增";
                return;
            }

            var rs = (from c in dcMain.PerformanceReportContentDept
                      where c.PerformanceReportTypeCode == ReportTypeCode
                      && c.PerformanceMainCode == MainCode
                      && c.PerformanceDeptCode == DeptCode
                      && c.ReportContentCode == ReportContentCode
                      select c).ToList();

            int Sort = 5;
            if (rs.Count > 0)
                Sort = rs.Max(p => p.Sort) + 5;

            var r = new PerformanceReportContentDept();
            r.Code = Guid.NewGuid().ToString();
            r.PerformanceReportTypeCode = ReportTypeCode;
            r.PerformanceMainCode = MainCode;
            r.PerformanceDeptCode = DeptCode;
            r.ReportContentCode = ReportContentCode;
            r.ContentTargetType = "";
            r.ContentTargetRef = "";
            r.Note = "";
            r.Sort = Sort;
            r.InsertMan = _User.UserCode;
            r.InsertDate = DateTime.Now;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;
            dcMain.PerformanceReportContentDept.InsertOnSubmit(r);

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-新增部門報表內容", "", _User.UserCode);

            lblMsg.Text = "新增完成，資料將放置於畫面最後一筆";

            lvMain.Rebind();
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            UnobtrusiveSession.Session["ReportContentDept"] = null;

            var rs = ListReportContent;

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "ContentType")
            {
                e.Canceled = true;

                var State = ViewState["Copy"].ToString();
                if (State != "1")
                {
                    lblMsg.Text = "您不能直接修改樣版內容，請先按複製樣版";
                    return;
                }


                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("MainReportContentDeptEdit.aspx?AutoKey=" + AutoKey + "&ColumnName=Type");
            }
            else if (cn == "ContentRef")
            {
                e.Canceled = true;

                var State = ViewState["Copy"].ToString();
                if (State != "1")
                {
                    lblMsg.Text = "您不能直接修改樣版內容，請先按複製樣版";
                    return;
                }

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("MainReportContentDeptEdit.aspx?AutoKey=" + AutoKey + "&ColumnName=Ref");

            }
            else if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var State = ViewState["Copy"].ToString();
                if (State != "1")
                {
                    lblMsg.Text = "您不能直接修改樣版內容，請先按複製樣版";
                    return;
                }

                var r = (from c in dcMain.PerformanceReportContentDept
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcMain.PerformanceReportContentDept.DeleteOnSubmit(r);
                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-報表部門內容刪除", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }
        }
    }
}