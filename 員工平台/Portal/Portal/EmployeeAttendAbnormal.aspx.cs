using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll.AbnormalView.Vdb;
using Dal.Dao.AbnormalView;
using System.Text;
using Bll;

namespace Portal
{
    public partial class EmployeeAttendAbnormal : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                ddlEmp_DataBind();
                _DataBind();
            }
        }
        public void LoadData(string Key = "")
        {

        }
        public void ddlEmp_DataBind()
        {
            var rs = AccessData.GetSearchListEmp(_User, CompanySetting);

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
        }
        public void _DataBind()
        {
            DateTime DateNow = DateTime.Now.Date;
            txtDateB.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, 1);
            txtDateE.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, DateTime.DaysInMonth(DateNow.Year, DateNow.Month));
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedItem == null)
                return;
            var EmpId = ddlEmp.SelectedItem.Value;
            var ListEmpId = new List<string>();
            if (EmpId == "*")
            {
                var rsListEmp = AccessData.GetSearchListEmp(_User, CompanySetting);
                ListEmpId = rsListEmp.Select(p => p.Value).ToList();
            }
            else
                ListEmpId.Add(EmpId);

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<AbnormalViewRow>();

            //向api取得驗証
            var oAbnormalView = new AbnormalViewDao();
            var AbnormalViewCond = new AbnormalViewConditions();
            AbnormalViewCond.AccessToken = _User.AccessToken;
            AbnormalViewCond.RefreshToken = _User.RefreshToken;
            AbnormalViewCond.CompanySetting = CompanySetting;
            AbnormalViewCond.isNoCheck = isNoCheck.Checked;
            AbnormalViewCond.employeeList = ListEmpId;
            AbnormalViewCond.dateBegin = DateB;
            AbnormalViewCond.dateEnd = DateE;

            var Result = oAbnormalView.GetData(AbnormalViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbnormalViewRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Abnormal");
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
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (ddlEmp.SelectedItem == null)
                return;
            var EmpId = ddlEmp.SelectedItem.Value;
            var ListEmpId = new List<string>();
            if (EmpId == "*")
            {
                var rsListEmp = AccessData.GetSearchListEmp(_User, CompanySetting);
                ListEmpId = rsListEmp.Select(p => p.Value).ToList();
            }
            else
                ListEmpId.Add(EmpId);

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<AbnormalViewRow>();

            //向api取得驗証
            var oAbnormalView = new AbnormalViewDao();
            var AbnormalViewCond = new AbnormalViewConditions();
            AbnormalViewCond.AccessToken = _User.AccessToken;
            AbnormalViewCond.RefreshToken = _User.RefreshToken;
            AbnormalViewCond.CompanySetting = CompanySetting;
            AbnormalViewCond.isNoCheck = isNoCheck.Checked;
            AbnormalViewCond.employeeList = ListEmpId;
            AbnormalViewCond.dateBegin = DateB;
            AbnormalViewCond.dateEnd = DateE;

            var Result = oAbnormalView.GetData(AbnormalViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbnormalViewRow>;
                }
            }

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
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
    }
}