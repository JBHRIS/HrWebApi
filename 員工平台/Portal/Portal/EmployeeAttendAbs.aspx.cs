using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll.AbsenceView.Vdb;
using Dal.Dao.AbsenceView;
using Dal.Dao.Absence;
using Bll.Absence.Vdb;
using Bll;
using System.Text;

namespace Portal
{
    public partial class EmployeeAttendAbs : WebPageBase
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                ddlEmp_DataBind();
                _DataBind();
                ddlHcode_DataBind();
                ButtonShown();

            }
        }
        public void LoadData(string Key = "")
        {

        }

        private void ButtonShown()
        {
            var LocalPath = System.IO.Path.GetFileName(Request.PhysicalPath);
            var MenuList = AccessData.GetListSystemPage(_User, CompanySetting);
            
            var FormCode = MenuList.Where(p => p.FileName == LocalPath).Select(p => p.Code).FirstOrDefault();
            var FormAttribute = MenuList.Where(p => p.ParentCode == FormCode).Select(p=>p.Code).ToList();
            if (FormAttribute.Contains("AbsViewExport"))
            {
                btnExportExcelEntitle.Visible = true;
                btnExportExcelTaken.Visible = true;
            }
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
        public void ddlHcode_DataBind()
        {
            var oHcodeTypes = new HcodeTypesDao();
            var HcodeTypesCond = new HcodeTypesConditions();
            HcodeTypesCond.AccessToken = _User.AccessToken;
            HcodeTypesCond.RefreshToken = _User.RefreshToken;
            HcodeTypesCond.CompanySetting = CompanySetting;
            var Result = oHcodeTypes.GetData(HcodeTypesCond);
            var rs = new List<HcodeTypesRow>();
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<HcodeTypesRow>;
                }
            }
            var rsList = new List<TextValueRow>();
            if (rs != null)
            {
                foreach (var rList in rs)
                {
                    var r = new TextValueRow();
                    r.Text = rList.TypeName;
                    r.Value = rList.Htype;
                    r.Sort = 9;
                    rsList.Add(r);
                }
            }

            var tv = new TextValueRow();
            tv.Text = "全部";
            tv.Value = "*";
            tv.Sort = 1;
            rsList.Add(tv);

            //按排序 再按照工號
            rs = rs.OrderBy(p => p.Sort).ToList();

            rsList = rsList.OrderBy(p => p.Value).ToList();
            ddlHcode.DataSource = rsList;
            ddlHcode.DataTextField = "Text";
            ddlHcode.DataValueField = "Value";
            ddlHcode.DataBind();

            if (ddlHcode.FindItemByValue("*") != null)
                ddlHcode.FindItemByValue("*").Selected = true;

            //ddlAbsType.Value = ddlAbsType.Items.Cast<MultiSelectItem>().Select(p => p.Value).ToList();
        }

        protected void btnEmpSelectAll_Click(object sender, EventArgs e)
        {
            //ddlEmp.Value = ddlEmp.Items.Cast<MultiSelectItem>().Select(p => p.Value).ToList();
        }
        public void _DataBind()
        {
            DateTime DateNow = DateTime.Now.Date;
            txtDateB.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, 1);
            txtDateE.SelectedDate = new DateTime(DateNow.Year, DateNow.Month, DateTime.DaysInMonth(DateNow.Year, DateNow.Month));
            
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

            lvMainTaken.Rebind();
            lvMainEntitle.Rebind();
        }
        protected void lvMainTaken_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
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

            //var ListLeaveType = AbsType.Value.Cast<string>().ToList();
            if (ddlHcode.SelectedItem == null)
                return;

            var HcodeCode = ddlHcode.SelectedItem.Value;

            var ListHcodeCode = new List<string>();

            if (HcodeCode == "*")
            {
                var oHcodeTypes = new HcodeTypesDao();
                var HcodeTypesCond = new HcodeTypesConditions();
                HcodeTypesCond.AccessToken = _User.AccessToken;
                HcodeTypesCond.RefreshToken = _User.RefreshToken;
                HcodeTypesCond.CompanySetting = CompanySetting;

                var Result1 = oHcodeTypes.GetData(HcodeTypesCond);
                var rs1 = new List<HcodeTypesRow>();
                if (Result1.Status)
                {
                    if (Result1.Data != null)
                    {
                        rs1 = Result1.Data as List<HcodeTypesRow>;
                    }
                }

                ListHcodeCode = rs1.Select(p => p.Htype).ToList();
            }
            else
                ListHcodeCode.Add(HcodeCode);

            var ListFlag = new List<string>();
            ListFlag.Add("-");

            var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            HcodeTypesByHcodeCond.htype = ListHcodeCode;
            HcodeTypesByHcodeCond.flag = ListFlag;
            var rsListLeaveCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            var ListLeaveCode = new List<string>();
            if (rsListLeaveCode.Status)
            {
                if (rsListLeaveCode.Data != null)
                {
                    var ResultList = rsListLeaveCode.Data as List<HcodeTypesByHcodeRow>;
                    foreach (var resultData in ResultList)
                    {
                        ListLeaveCode.Add(resultData.Hcode);
                    }
                }
            }

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<AbsenceTakenViewRow>();


            //向api取得驗証
            var oAbsenceTakenView = new AbsenceTakenViewDao();
            var AbsenceTakenViewCond = new AbsenceTakenViewConditions();
            AbsenceTakenViewCond.AccessToken = _User.AccessToken;
            AbsenceTakenViewCond.RefreshToken = _User.RefreshToken;
            AbsenceTakenViewCond.CompanySetting = CompanySetting;
            AbsenceTakenViewCond.leaveCodeList = ListLeaveCode;
            AbsenceTakenViewCond.employeeList = ListEmpId;
            AbsenceTakenViewCond.dateBegin = DateB;
            AbsenceTakenViewCond.dateEnd = DateE;

            var Result = oAbsenceTakenView.GetData(AbsenceTakenViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbsenceTakenViewRow>;
                }
            }

            lvMainTaken.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            
        }
        protected void lvMainEntitle_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
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

            //var ListLeaveType = AbsType.Value.Cast<string>().ToList();
            if (ddlHcode.SelectedItem == null)
                return;

            var HcodeCode = ddlHcode.SelectedItem.Value;

            var ListHcodeCode = new List<string>();

            if (HcodeCode == "*")
            {
                var oHcodeTypes = new HcodeTypesDao();
                var HcodeTypesCond = new HcodeTypesConditions();
                HcodeTypesCond.AccessToken = _User.AccessToken;
                HcodeTypesCond.RefreshToken = _User.RefreshToken;
                HcodeTypesCond.CompanySetting = CompanySetting;

                var Result1 = oHcodeTypes.GetData(HcodeTypesCond);
                var rs1 = new List<HcodeTypesRow>();
                if (Result1.Status)
                {
                    if (Result1.Data != null)
                    {
                        rs1 = Result1.Data as List<HcodeTypesRow>;
                    }
                }

                ListHcodeCode = rs1.Select(p => p.Htype).ToList();
            }
            else
                ListHcodeCode.Add(HcodeCode);

            var ListFlag = new List<string>();
            ListFlag.Add("+");

            var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            HcodeTypesByHcodeCond.htype = ListHcodeCode;
            HcodeTypesByHcodeCond.flag = ListFlag;
            var rsListLeaveCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            var ListLeaveCode = new List<string>();
            if (rsListLeaveCode.Status)
            {
                if (rsListLeaveCode.Data != null)
                {
                    var ResultList = rsListLeaveCode.Data as List<HcodeTypesByHcodeRow>;
                    foreach (var resultData in ResultList)
                    {
                        ListLeaveCode.Add(resultData.Hcode);
                    }
                }
            }

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            var rs = new List<AbsenceEntitleViewRow>();

            //向api取得驗証得到表單資訊
            var oAbsenceEntitleView = new AbsenceEntitleViewDao();
            var AbsenceEntitleViewCond = new AbsenceEntitleViewConditions();
            AbsenceEntitleViewCond.AccessToken = _User.AccessToken;
            AbsenceEntitleViewCond.RefreshToken = _User.RefreshToken;
            AbsenceEntitleViewCond.CompanySetting = CompanySetting;
            AbsenceEntitleViewCond.leaveCodeList = ListLeaveCode;
            AbsenceEntitleViewCond.employeeList = ListEmpId;
            AbsenceEntitleViewCond.dateBegin = DateB;
            AbsenceEntitleViewCond.dateEnd = DateE;

            var Result = oAbsenceEntitleView.GetData(AbsenceEntitleViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbsenceEntitleViewRow>;
                }
            }

            lvMainEntitle.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void btnExportExcelTaken_Click(object sender, EventArgs e)
        {
            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
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

            //var ListLeaveType = AbsType.Value.Cast<string>().ToList();
            if (ddlHcode.SelectedItem == null)
                return;

            var HcodeCode = ddlHcode.SelectedItem.Value;

            var ListHcodeCode = new List<string>();

            if (HcodeCode == "*")
            {
                var oHcodeTypes = new HcodeTypesDao();
                var HcodeTypesCond = new HcodeTypesConditions();
                HcodeTypesCond.AccessToken = _User.AccessToken;
                HcodeTypesCond.RefreshToken = _User.RefreshToken;
                HcodeTypesCond.CompanySetting = CompanySetting;

                var Result1 = oHcodeTypes.GetData(HcodeTypesCond);
                var rs1 = new List<HcodeTypesRow>();
                if (Result1.Status)
                {
                    if (Result1.Data != null)
                    {
                        rs1 = Result1.Data as List<HcodeTypesRow>;
                    }
                }

                ListHcodeCode = rs1.Select(p => p.Htype).ToList();
            }
            else
                ListHcodeCode.Add(HcodeCode);

            var ListFlag = new List<string>();
            ListFlag.Add("-");

            var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            HcodeTypesByHcodeCond.htype = ListHcodeCode;
            HcodeTypesByHcodeCond.flag = ListFlag;
            var rsListLeaveCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            var ListLeaveCode = new List<string>();
            if (rsListLeaveCode.Status)
            {
                if (rsListLeaveCode.Data != null)
                {
                    var ResultList = rsListLeaveCode.Data as List<HcodeTypesByHcodeRow>;
                    foreach (var resultData in ResultList)
                    {
                        ListLeaveCode.Add(resultData.Hcode);
                    }
                }
            }

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);


            var rs = new List<AbsenceTakenViewRow>();


            //向api取得驗証
            var oAbsenceTakenView = new AbsenceTakenViewDao();
            var AbsenceTakenViewCond = new AbsenceTakenViewConditions();
            AbsenceTakenViewCond.AccessToken = _User.AccessToken;
            AbsenceTakenViewCond.RefreshToken = _User.RefreshToken;
            AbsenceTakenViewCond.CompanySetting = CompanySetting;
            AbsenceTakenViewCond.leaveCodeList = ListLeaveCode;
            AbsenceTakenViewCond.employeeList = ListEmpId;
            AbsenceTakenViewCond.dateBegin = DateB;
            AbsenceTakenViewCond.dateEnd = DateE;

            var Result = oAbsenceTakenView.GetData(AbsenceTakenViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbsenceTakenViewRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Abs");
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
        protected void btnExportExcelEntitle_Click(object sender, EventArgs e)
        {
            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();
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

            //var ListLeaveType = AbsType.Value.Cast<string>().ToList();
            if (ddlHcode.SelectedItem == null)
                return;

            var HcodeCode = ddlHcode.SelectedItem.Value;

            var ListHcodeCode = new List<string>();

            if (HcodeCode == "*")
            {
                var oHcodeTypes = new HcodeTypesDao();
                var HcodeTypesCond = new HcodeTypesConditions();
                HcodeTypesCond.AccessToken = _User.AccessToken;
                HcodeTypesCond.RefreshToken = _User.RefreshToken;
                HcodeTypesCond.CompanySetting = CompanySetting;

                var Result1 = oHcodeTypes.GetData(HcodeTypesCond);
                var rs1 = new List<HcodeTypesRow>();
                if (Result1.Status)
                {
                    if (Result1.Data != null)
                    {
                        rs1 = Result1.Data as List<HcodeTypesRow>;
                    }
                }

                ListHcodeCode = rs1.Select(p => p.Htype).ToList();
            }
            else
                ListHcodeCode.Add(HcodeCode);

            var ListFlag = new List<string>();
            ListFlag.Add("+");

            var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            HcodeTypesByHcodeCond.htype = ListHcodeCode;
            HcodeTypesByHcodeCond.flag = ListFlag;
            var rsListLeaveCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            var ListLeaveCode = new List<string>();
            if (rsListLeaveCode.Status)
            {
                if (rsListLeaveCode.Data != null)
                {
                    var ResultList = rsListLeaveCode.Data as List<HcodeTypesByHcodeRow>;
                    foreach (var resultData in ResultList)
                    {
                        ListLeaveCode.Add(resultData.Hcode);
                    }
                }
            }

            var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);


            var rs = new List<AbsenceEntitleViewRow>();

            //向api取得驗証得到表單資訊
            var oAbsenceEntitleView = new AbsenceEntitleViewDao();
            var AbsenceEntitleViewCond = new AbsenceEntitleViewConditions();
            AbsenceEntitleViewCond.AccessToken = _User.AccessToken;
            AbsenceEntitleViewCond.RefreshToken = _User.RefreshToken;
            AbsenceEntitleViewCond.CompanySetting = CompanySetting;
            AbsenceEntitleViewCond.leaveCodeList = ListLeaveCode;
            AbsenceEntitleViewCond.employeeList = ListEmpId;
            AbsenceEntitleViewCond.dateBegin = DateB;
            AbsenceEntitleViewCond.dateEnd = DateE;

            var Result = oAbsenceEntitleView.GetData(AbsenceEntitleViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AbsenceEntitleViewRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Abs");
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
    }
}