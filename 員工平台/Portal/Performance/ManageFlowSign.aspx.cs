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
    public partial class ManageFlowSign : WebPageBase
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

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            //var ph = (ContentPlaceHolder)this.Master.Master.FindControl("cphMain");

            //var TypeCode = "";
            //var ddlType = ph.FindControl("ddlType");
            //if (ddlType != null)
            //    TypeCode = ((RadDropDownList)ddlType).SelectedItem.Value;

            //var MainCode = "";
            //var ddlMain = ph.FindControl("ddlMain");
            //if (ddlMain != null)
            //    MainCode = ((RadDropDownList)ddlMain).SelectedItem.Value;

            //var DeptCode = "";
            //var ddlDept = ph.FindControl("ddlDept");
            //if (ddlDept != null)
            //    DeptCode = ((RadDropDownList)ddlDept).SelectedItem.Value;

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
            var ListDeptCode = rsFlow.Select(p => p.PerformanceDeptCode).ToList();

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

        protected void btnInsert_Click(object sender, EventArgs e)
        {

        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = new List<PerformanceFlowSign>();

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
            var ListDeptCode = rsFlow.Select(p => p.PerformanceDeptCode).ToList();

             rs = (from c in dcMain.PerformanceFlowSign
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

            lvMain.DataSource = rs;

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

            if (cn == "Delete")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                var rSign = (from c in dcMain.PerformanceFlowSign
                             where c.AutoKey == AutoKey
                             select c).FirstOrDefault();

                if (rSign != null)
                {
                    dcMain.PerformanceFlowSign.DeleteOnSubmit(rSign);
                    dcMain.SubmitChanges();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rSign), "", "Performance-刪除簽核流程", "", _User.UserCode);

                    lvMain.Rebind();
                }
            }
        }
    }
}