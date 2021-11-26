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
    public partial class ManageRating : WebPageBase
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

        public class PerformanceRatingRow
        {
            public int AutoKey { get; set; }
            public string CompName { get; set; }
            public string EmpCategoryCode { get; set; }
            public string EmpCategoryName { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int BonusPerMax { get; set; }
            public int BonusPerMin { get; set; }
            public int NumPerMax { get; set; }
            public int NumPerMin { get; set; }
            public int NumPer { get; set; }
            public string Note { get; set; }
            public int Sort { get; set; }
            public int Num { get; set; }
            public string CheckNote { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = (from c in dcMain.PerformanceRating
                      orderby c.EmpCategoryCode, c.Sort
                      select new PerformanceRatingRow
                      { 
                          AutoKey =c.AutoKey,
                          CompName = "",
                          EmpCategoryCode = c.EmpCategoryCode,
                          EmpCategoryName = "",
                          Code=  c.Code,
                          Name= c.Name,
                          BonusPerMax=   c.BonusPerMax,
                          BonusPerMin=   c.BonusPerMin,
                          NumPerMax=   c.NumPerMax,
                          NumPerMin=   c.NumPerMin,
                          NumPer= c.NumPer,
                          Note= c.Note,
                          Sort=  c.Sort,
                          Num= c.Num,
                          CheckNote = c.CheckNote ? "是" : "否",
                          UpdateMan=  c.UpdateMan,
                          UpdateDate= c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                      }).ToList();

            var rsEmpCategory = oMainDao.ShareCodeNameCode("EmpCategory");

            foreach (var r in rs)
            {
                r.EmpCategoryName = rsEmpCategory.FirstOrDefault(p => p.Code == r.EmpCategoryCode)?.Name ?? r.EmpCategoryName;
            }

            //處理html

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("PerformanceRatingGroup");
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
            var rs = (from c in dcMain.PerformanceRating
                      orderby c.EmpCategoryCode, c.Sort
                      select new PerformanceRatingRow
                      {
                          AutoKey = c.AutoKey,
                          CompName = "",
                          EmpCategoryCode = c.EmpCategoryCode,
                          EmpCategoryName = "",
                          Code = c.Code,
                          Name = c.Name,
                          BonusPerMax = c.BonusPerMax,
                          BonusPerMin = c.BonusPerMin,
                          NumPerMax = c.NumPerMax,
                          NumPerMin = c.NumPerMin,
                          NumPer = c.NumPer,
                          Note = c.Note,
                          Sort = c.Sort,
                          Num = c.Num,
                          CheckNote = c.CheckNote ? "是" : "否",
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
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

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "Edit")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageRatingEdit.aspx?AutoKey=" + AutoKey);
            }
            else if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcMain.PerformanceRating
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcMain.PerformanceRating.DeleteOnSubmit(r);
                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-刪除評等", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }
        }
    }
}