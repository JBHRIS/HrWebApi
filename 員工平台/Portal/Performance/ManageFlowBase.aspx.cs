using Bll.Performance.Vdb;
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
    public partial class ManageFlowBase : WebPageBase
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
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
                return;

            var EmpCategoryCode = rMain.EmpCategoryCode;

            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            select c).ToList();

            var rs = (from c in dcMain.PerformanceBase
                      where c.PerformanceMainCode == MainCode
                      && (c.PerformanceDeptCode == DeptCode || DeptCode == "-")
                      select c).ToList();

            //置換
            foreach (var r in rs)
            {
                var rRating = rsRating.FirstOrDefault(p => p.Code == r.RatingCode);
                if (rRating != null)
                    r.RatingCode = rRating.Name;
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
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            var AutoKey = "0";
            UnobtrusiveSession.Session["AutoKey"] = AutoKey;
            UnobtrusiveSession.Session["MainCode"] = MainCode;

            Response.Redirect("ManageFlowBaseEdit.aspx?AutoKey=" + AutoKey);
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = new List<PerformanceBase>();

            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lvMain.DataSource = rs;
                return;
            }

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
                return;

            var EmpCategoryCode = rMain.EmpCategoryCode;

            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            select c).ToList();

            rs = (from c in dcMain.PerformanceBase
                  where c.PerformanceMainCode == MainCode
                  && (c.PerformanceDeptCode == DeptCode || DeptCode == "-")
                  select c).ToList();

            //如果不是管理者就需要人員權限
            if (_User.RoleKey > 4)
            {
                //取得有該產生者有權限的名單
                var ListEmpId = dcHr.WriteRuleTable1ByNobr(_User.UserCode, "A", true, DateTime.Now.ToShortDateString()).Select(p => p.NOBR.Trim()).ToList();

                double dLoopCycle = (ListEmpId.Count / 2000d);
                int loopCycle = Convert.ToInt32(Math.Ceiling(dLoopCycle));
                loopCycle = loopCycle == 0 ? 1 : loopCycle;
                List<PerformanceBase> rsPerformanceBase = new List<PerformanceBase>();
                List<PerformanceBase> rsPerformanceBaseTemp = new List<PerformanceBase>();
                //more than 2100 parameter would raise error
                for (int x = 0; x < loopCycle; x++)
                {
                    int rangeIndex = (x * 2000);
                    var tempList = ListEmpId.GetRange(rangeIndex, Math.Min(2000, ListEmpId.Count - rangeIndex));

                    rsPerformanceBaseTemp = (from c in rs
                                             where tempList.Contains(c.EmpId)
                                             select c).ToList();

                    rsPerformanceBase = rsPerformanceBase.Union(rsPerformanceBaseTemp).ToList();
                }

                rs = rsPerformanceBase;
            }

            rs = rs.Take(200).ToList();

            //置換
            foreach (var r in rs)
            {
                var rRating = rsRating.FirstOrDefault(p => p.Code == r.RatingCode);
                if (rRating != null)
                    r.RatingCode = rRating.Name;
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

            if (cn == "SaveHr")
            {
                e.Canceled = true;

                lblMsg.Text = "目前沒有效果";
            }
            if (cn == "Edit")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;
                UnobtrusiveSession.Session["MainCode"] = MainCode;

                Response.Redirect("ManageFlowBaseEdit.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "Delete")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                var rBase = (from c in dcMain.PerformanceBase
                             where c.AutoKey == AutoKey
                             select c).FirstOrDefault();

                if (rBase != null)
                {
                    dcMain.PerformanceBase.DeleteOnSubmit(rBase);
                    dcMain.SubmitChanges();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rBase), "", "Performance-刪除員工", "", _User.UserCode);

                    lvMain.Rebind();
                }
            }
        }
    }
}