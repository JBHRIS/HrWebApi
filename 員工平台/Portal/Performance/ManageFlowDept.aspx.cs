using Bll.Dept.Vdb;
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
    public partial class ManageFlowDept : WebPageBase
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

            //取得目前部門
            var rDept = (from c in dcMain.PerformanceDept
                         where c.PerformanceMainCode == MainCode
                         && c.Code == DeptCode
                         select c).FirstOrDefault();

            if (rDept == null)
                return;

            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          orderby c.DeptTree
                          select c).ToList();

            var ListDeptCode = new List<string>();

            var End = 0;    //預防無窮迴圈
            do
            {
                ListDeptCode.Add(DeptCode);
                rDept = rsDept.FirstOrDefault(p => p.Code == DeptCode);
                if (rDept != null)
                    DeptCode = rDept.ParentCode;

                End++;
            } while (rDept != null && End <= 20);

            //var ListDeptCode = rDept.PathCode.Split('/');

            //取得向上所有部門
            var rs = (from c in dcMain.PerformanceDept
                      where c.PerformanceMainCode == MainCode
                      && (ListDeptCode.Contains(c.Code) || DeptCode == "-")
                      orderby c.DeptTree
                      select c).ToList();

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

        protected void btnDeptPath_Click(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          orderby c.DeptTree
                          select new DeptRow
                          {
                              Code = c.Code,
                              Name = c.Name,
                              ParentCode = c.ParentCode,
                              DeptTree = c.DeptTree,
                              ManagerId = c.ManagerId,
                              Mail = c.Mail,
                              ParentManagerId = "",
                              PathCode = "",
                              PathName = "",
                          }).ToList();

            //填入部門Path
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            oPerformance.SetDeptPath(rsDept);

            var rs = (from c in dcMain.PerformanceDept
                      where c.PerformanceMainCode == MainCode
                      orderby c.DeptTree
                      select c).ToList();

            foreach (var r in rs)
            {
                var rDept = rsDept.FirstOrDefault(p => p.Code == r.Code);
                if (rDept != null)
                {
                    r.PathCode = rDept.PathCode;
                    r.PathName = rDept.PathName;
                    r.UpdateMan = _User.UserCode;
                    r.UpdateDate = DateTime.Now;
                }

                r.ParentManagerId = oPerformance.GetManagerId(rsDept, r.ParentCode, r.ManagerId);
            }

            dcMain.SubmitChanges();
            lvMain.Rebind();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rs), "", "Performance-部門重組", "", _User.UserCode);

            lblMsg.Text = "重組成功";
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

            Response.Redirect("ManageFlowDeptEdit.aspx?AutoKey=" + AutoKey);
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = new List<PerformanceDept>();

            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lvMain.DataSource = rs;
                return;
            }

            //取得目前部門
            var rDept = (from c in dcMain.PerformanceDept
                         where c.PerformanceMainCode == MainCode
                         && (c.Code == DeptCode || DeptCode == "-")
                         select c).FirstOrDefault();

            if (rDept == null)
                return;

            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          orderby c.DeptTree
                          select c).ToList();

            var ListDeptCode = new List<string>();

            var End = 0;    //預防無窮迴圈
            do
            {
                ListDeptCode.Add(DeptCode);
                rDept = rsDept.FirstOrDefault(p => p.Code == DeptCode);
                if (rDept != null)
                    DeptCode = rDept.ParentCode;

                End++;
            } while (rDept != null && End <= 20);

            //var ListDeptCode = rDept.PathCode.Split('/');

            //取得向上所有部門
             rs = (from c in dcMain.PerformanceDept
                      where c.PerformanceMainCode == MainCode
                      && (ListDeptCode.Contains(c.Code) || DeptCode == "-")
                      orderby c.DeptTree
                      select c).ToList();

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

            if (cn == "Rating")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageFlowDeptRating.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "Edit")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;
                UnobtrusiveSession.Session["MainCode"] = MainCode;

                Response.Redirect("ManageFlowDeptEdit.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "Delete")
            {
                e.Canceled = true;

                int AutoKey = Convert.ToInt32(ca);

                var rDept = (from c in dcMain.PerformanceDept
                             where c.AutoKey == AutoKey
                             select c).FirstOrDefault();

                if (rDept != null)
                {
                    dcMain.PerformanceDept.DeleteOnSubmit(rDept);
                    dcMain.SubmitChanges();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rDept), "", "Performance-刪除部門", "", _User.UserCode);

                    lvMain.Rebind();
                }
            }
        }


    }
}