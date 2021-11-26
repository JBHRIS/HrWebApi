using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll.CardView.Vdb;
using Dal.Dao.CardView;
using System.Text;
using Bll;
using Dal;
using JBModule.Data.Linq;

namespace Portal
{
    public partial class AppEmployeeAttendCard : WebPageBase
    {
        public dcAppDataContext dcApp = new dcAppDataContext();
        public dcHrDataContext dcHr = new dcHrDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                _DataBind();
                ddlEmp_DataBind();
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }
        }
        public void LoadData(string Key = "")
        {

        }
        public void _DataBind()
        {
            DateTime DateNow = DateTime.Now.Date;
            txtDateB.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, 1);
            txtDateE.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, DateTime.DaysInMonth(DateNow.Year, DateNow.Month));
        }
        public void ddlEmp_DataBind()
        {

            var rs = AccessData.GetSearchListEmp(_User, CompanySetting);

            HrDBDataContext dcHrDB = new HrDBDataContext(dcHr.Connection.ConnectionString);
            rs = (from c in dcHrDB.BASE
                  orderby c.NOBR
                  select new TextValueRow
                  {
                      Text = c.NAME_C.Trim() + "," + c.NOBR.Trim(),
                      Value = c.NOBR.Trim(),
                  }).ToList();

            //暫時把所取得的Sort變成9
            //新增一個全部 Sort為0
            foreach (var r in rs)
                r.Sort = 9;

            var tv = new TextValueRow();
            tv.Text = "全部";
            tv.Value = "*";
            tv.Sort = 1;
            rs.Add(tv);

            //按排序 再按照工號
            rs = rs.OrderBy(p => p.Sort).ThenBy(p => p.Value).ToList();

            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();

            if (ddlEmp.FindItemByValue(_User.EmpId) != null)
                ddlEmp.FindItemByValue(_User.EmpId).Selected = true;

            //ddlEmp.Value = new List<string>() { _User.EmpId };
        }
        protected void btnEmpSelectAll_Click(object sender, EventArgs e)
        {
            //ddlEmp.Value = ddlEmp.Items.Cast<MultiSelectItem>().Select(p => p.Value).ToList();
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            HrDBDataContext dcHrDB = new HrDBDataContext(dcHr.Connection.ConnectionString);

            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
            if (ddlEmp.SelectedItem == null)
                return;

            var EmpId = ddlEmp.SelectedItem.Value;

            var ListEmpId = new List<string>();

            if (EmpId == "*")
            {
                ListEmpId = (from c in dcHrDB.BASE
                             select c.NOBR).ToList();
            }
            else
                ListEmpId.Add(EmpId);

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<CardViewRow>();

            //向api取得驗証
            var oCardView = new CardViewDao();
            var CardViewCond = new CardViewConditions();
            CardViewCond.AccessToken = _User.AccessToken;
            CardViewCond.RefreshToken = _User.RefreshToken;
            CardViewCond.CompanySetting = CompanySetting;
            CardViewCond.isForget = isCheck.Checked;
            CardViewCond.employeeList = ListEmpId;
            CardViewCond.dateBegin = DateB;
            CardViewCond.dateEnd = DateE;

            //var Result = oCardView.GetData(CardViewCond);

            //if (Result.Status)
            //{
            //    if (Result.Data != null)
            //    {
            //        rs = Result.Data as List<CardViewRow>;
            //    }
            //}

            rs = (from c in dcHrDB.CARD
                  join b in dcHrDB.BASE on c.NOBR equals b.NOBR
                  where DateB <= c.ADATE && c.ADATE <= DateE
                  && c.LOS == isCheck.Checked
                  && ListEmpId.Contains(c.NOBR)
                  orderby c.ADATE, c.ONTIME
                  select new CardViewRow
                  {
                      ForgetReason = c.REASON,
                      AttcardTime = c.ONTIME,
                      DateA = c.ADATE,
                      EmpId = c.NOBR,
                      EmpName = b.NAME_C,
                  }).ToList();

            var rVdb = (from c in dcApp.CardAppDetails
                        where ListEmpId.Contains(c.Nobr)
                        select c).ToList();

            foreach (var r in rs)
            {
                DateTime CardDateTime = r.DateA.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(r.AttcardTime));
                if (rVdb.Where(p => p.CardSend.Value.ToString("yyyy/MM/dd HH:mm") == CardDateTime.ToString("yyyy/MM/dd HH:mm") && p.Nobr.Trim() == r.EmpId.Trim()).Any())
                    r.DetailAutokey = rVdb.Where(p => p.CardSend.Value.ToString("yyyy/MM/dd HH:mm") == CardDateTime.ToString("yyyy/MM/dd HH:mm") && p.Nobr.Trim() == r.EmpId.Trim()).FirstOrDefault().AutoKey;
            }

            lvMain.DataSource = rs;



            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            HrDBDataContext dcHrDB = new HrDBDataContext(dcHr.Connection.ConnectionString);

            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
            if (ddlEmp.SelectedItem == null)
                return;

            var EmpId = ddlEmp.SelectedItem.Value;

            var ListEmpId = new List<string>();

            if (EmpId == "*")
            {
                ListEmpId = (from c in dcHrDB.BASE
                             select c.NOBR).ToList();
            }
            else
                ListEmpId.Add(EmpId);

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<CardViewRow>();

            //向api取得驗証
            var oCardView = new CardViewDao();
            var CardViewCond = new CardViewConditions();
            CardViewCond.AccessToken = _User.AccessToken;
            CardViewCond.RefreshToken = _User.RefreshToken;
            CardViewCond.CompanySetting = CompanySetting;
            CardViewCond.isForget = isCheck.Checked;
            CardViewCond.employeeList = ListEmpId;
            CardViewCond.dateBegin = DateB;
            CardViewCond.dateEnd = DateE;

            rs = (from c in dcHrDB.CARD
                  join b in dcHrDB.BASE on c.NOBR equals b.NOBR
                  where DateB <= c.ADATE && c.ADATE <= DateE
                  && c.LOS == isCheck.Checked
                  && ListEmpId.Contains(c.NOBR)
                  select new CardViewRow
                  {
                      ForgetReason = c.REASON,
                      AttcardTime = c.ONTIME,
                      DateA = c.ADATE,
                      EmpId = c.NOBR,
                      EmpName = b.NAME_C,
                  }).ToList();



            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Card");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = (Page.Master as Main).FormTitle + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDateB.SelectedDate.Value.AddMonths(3) < txtDateE.SelectedDate)
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "時間起迄限3個月";
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
                return;
            }
            if (txtDateB.SelectedDate > txtDateE.SelectedDate)
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "開始時間大於結束時間";
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
                return;
            }
            lblMsg.Text = "";
            lvMain.Rebind();
        }

        protected void btnCardDetail_Click(object sender, EventArgs e)
        {
            RadButton btnCardDetail = sender as RadButton;
            btnCardDetail.Attributes.Add("onclick", "this.form.target='_blank'");
            UnobtrusiveSession.Session["CardAppDetailsID"] = btnCardDetail.CommandArgument;
            Response.Redirect("AppCardDetail.aspx");
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
            foreach (var item in lvMain.Items)
            {
                RadButton btnCardDetail = item.FindControl("btnCardDetail") as RadButton;
                if (btnCardDetail.CommandArgument != null && btnCardDetail.CommandArgument != "0")
                    btnCardDetail.Visible = true;
            }
        }
    }
}