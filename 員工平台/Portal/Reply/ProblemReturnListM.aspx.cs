using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Share;
using Bll.Share.Vdb;
using Dal;
using Telerik.Web.UI;
using Dal.Dao.Flow;
using System.Windows;
using Bll.Token.Vdb;
using System.Data;
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;

namespace Portal
{
    public partial class ProblemReturnListM : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_User.RoleKey!=2&&_User.RoleKey!=8)
            {
                Response.Redirect("ProblemReturn.aspx");
            }
            if (!IsPostBack)
            {
                SetUserInfo();
               
                txtReturnS_DataBind();
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExportExcel);
        }
        private void SetUserInfo()
        {
            lblUserCode.Text = _User.UserCode;
            lblCompanyId.Text = _User.CompanyId;
            lblEmpID.Text = _User.EmpId;
            lblEmpName.Text = _User.EmpName;
            lblRoleKey.Text = _User.RoleKey.ToString();


        }
     


        private void txtReturnS_DataBind()
        {
            var oGetQuestionCategoryDao = new ShareGetQuestionCategoryDao();
            var GetQuestionCategoryCond = new ShareGetQuestionCategoryConditions();
            var result = oGetQuestionCategoryDao.GetData(GetQuestionCategoryCond);
            var rsDataSource = result.Data as List<ShareGetQuestionCategoryRow>;

            if (rsDataSource != null)
            {
                txtReturnS.DataSource = rsDataSource;
                txtReturnS.DataTextField = "Name";
                txtReturnS.DataValueField = "Code";
                txtReturnS.DataBind();
                //txtReturnS.SelectedIndex = 0;
            }
           
            txtReturnS.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "所有類型", Value = "" });
            
           
            txtReturnX.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem { Text = "所有類型", Value = "" });
            txtReturnX.Items.Insert(1, new Telerik.Web.UI.RadComboBoxItem { Text = "已結單", Value = "已結單" });
            txtReturnX.Items.Insert(2, new Telerik.Web.UI.RadComboBoxItem { Text = "尚未結單", Value = "尚未結單" });
            txtReturnX.Items.Insert(3, new Telerik.Web.UI.RadComboBoxItem { Text = "已失效", Value = "已失效" });

        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            APIResult rsGetQuestionMain = new APIResult();

            if (_User.RoleKey == 2)
            {
                var oGetQuestionMain = new ShareGetQuestionMainDao();
                var GetquestionMainCond = new ShareGetQuestionMainConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            }
            else if (_User.RoleKey == 8)
            {
                var oGetQuestionMain = new ShareGetQuestionMainByCompanyDao();
                var GetquestionMainCond = new ShareGetQuestionMainByCompanyConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            }
            


            try
            {
                if (rsGetQuestionMain.Status)
                {
                    if (rsGetQuestionMain.Data != null)
                    {

                        if (_User.RoleKey == 2)
                        {
                            var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainRow>;
                            lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        }
                        else if (_User.RoleKey == 8)
                        {
                            var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainByCompanyRow>;
                            lvMain.DataSource = rsQM.OrderByDescending(x => x.InsertDate);
                        }
                        

                        var Script = "$(document).ready(function() {$('.footable').footable();});";
                        ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);


                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {

        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            RadButton button = sender as RadButton;
            var code = button.CommandArgument.ToString();
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageReturn.aspx?Code=" + code);
        }
        public void btnSet_Click(object sender, EventArgs e)
        {
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            Response.Redirect("MessageList.aspx");

        }

        protected void txtReturnS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var selectitem = sender as RadComboBox;
            if (txtReturnS.SelectedValue != "0")
            {

                RadListViewContainsFilterExpression expression1 = new RadListViewContainsFilterExpression("QuestionCategoryCode");
                lvMain.FilterExpressions.Remove(expression1);
                if (txtReturnS.SelectedValue != "")
                {
                    expression1.CurrentValue = txtReturnS.SelectedValue;
                    lvMain.FilterExpressions.Add(expression1);
                }

            }

            if (txtReturnX.SelectedValue != "0")
            {
                RadListViewContainsFilterExpression expression2 = new RadListViewContainsFilterExpression("CompleteStatus");
                lvMain.FilterExpressions.Remove(expression2);
                if (txtReturnX.SelectedValue != "")
                {
                    expression2.CurrentValue = txtReturnX.SelectedValue;
                    lvMain.FilterExpressions.Add(expression2);
                }

            }
            lvMain.Rebind();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            APIResult rsGetQuestionMain = new APIResult();

            if (_User.RoleKey == 2)
            {
                var oGetQuestionMain = new ShareGetQuestionMainDao();
                var GetquestionMainCond = new ShareGetQuestionMainConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            }
            else if (_User.RoleKey == 8)
            {
                var oGetQuestionMain = new ShareGetQuestionMainByCompanyDao();
                var GetquestionMainCond = new ShareGetQuestionMainByCompanyConditions();
                GetquestionMainCond.AccessToken = _User.AccessToken;
                GetquestionMainCond.RefreshToken = _User.RefreshToken;
                GetquestionMainCond.CompanySetting = CompanySetting;
                GetquestionMainCond.CompanyID = _User.CompanyId;
                rsGetQuestionMain = oGetQuestionMain.GetData(GetquestionMainCond);

            }

            if (rsGetQuestionMain.Status)
            {
                if (rsGetQuestionMain.Data != null)
                {
                    DataTable dt = new DataTable();
                    if (_User.RoleKey == 2)
                    {
                        var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainRow>;
                        if ((txtReturnS.SelectedValue != "0" && txtReturnS.SelectedValue != "") || (txtReturnX.SelectedValue != "0" && txtReturnX.SelectedValue != ""))
                        {
                            if (txtReturnS.SelectedValue != "0" && txtReturnS.SelectedValue != "")
                            {
                                rsQM = rsQM.Where(x => x.QuestionCategoryCode.Contains(txtReturnS.SelectedValue)).ToList<ShareGetQuestionMainRow>();
                            }

                            if (txtReturnX.SelectedValue != "0" && txtReturnX.SelectedValue != "")
                            {
                                if (txtReturnX.SelectedValue == "已結單")
                                {
                                    rsQM = rsQM.Where(x => x.Complete == true).ToList<ShareGetQuestionMainRow>();
                                }
                                else
                                {
                                    rsQM = rsQM.Where(x => x.Complete == false).ToList<ShareGetQuestionMainRow>();
                                }
                            }

                        }
                        dt = rsQM.CopyToDataTable();
                    }
                    else if (_User.RoleKey == 8)
                    {
                        var rsQM = rsGetQuestionMain.Data as List<ShareGetQuestionMainByCompanyRow>;
                        if ((txtReturnS.SelectedValue != "0" && txtReturnS.SelectedValue != "") || (txtReturnX.SelectedValue != "0" && txtReturnX.SelectedValue != ""))
                        {
                            if (txtReturnS.SelectedValue != "0" && txtReturnS.SelectedValue != "")
                            {
                                rsQM = rsQM.Where(x => x.QuestionCategoryCode.Contains(txtReturnS.SelectedValue)) as List<ShareGetQuestionMainByCompanyRow>;
                            }
                               
                            if(txtReturnX.SelectedValue != "0" && txtReturnX.SelectedValue != "")
                            {
                                if (txtReturnX.SelectedValue == "已結單")
                                {
                                    rsQM = rsQM.Where(x => x.Complete = true) as List<ShareGetQuestionMainByCompanyRow>;
                                }
                                else
                                {
                                    rsQM = rsQM.Where(x => x.Complete = false) as List<ShareGetQuestionMainByCompanyRow>;
                                }                               
                            }
                            
                        }
                        dt = rsQM.CopyToDataTable();
                    }
                    //移除不顯示的欄位
                    dt.Columns.Remove("CompanyId");
                    dt.Columns.Remove("Code");
                    dt.Columns.Remove("SystemCategoryCode");
                    dt.Columns.Remove("Key1");
                    dt.Columns.Remove("Key2");
                    dt.Columns.Remove("Key3");
                    dt.Columns.Remove("QuestionCategoryCode");
                    dt.Columns.Remove("IpAddress");
                    dt.Columns.Remove("DateE");
                    dt.Columns.Remove("Complete");
                    dt.Columns.Remove("Note");
                    dt.Columns.Remove("Status");
                    dt.Columns.Remove("InsertMan");
                    //更改欄位名稱
                    var ListGroupCode = new List<string>();
                    ListGroupCode.Add("Reply");
                    AccessData.SetColumnsName(dt, ListGroupCode);

                    var stream = RenderDataTableToExcel(dt);
                    var FileName = "回報單" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xls";

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



        public static Stream RenderDataTableToExcel(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            var intCellStyle = workbook.CreateCellStyle();
            intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

            var doubleCellStyle = workbook.CreateCellStyle();
            doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

            var dateCellStyle = workbook.CreateCellStyle();
            dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy-mm-dd HH:mm");

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    Type t = column.DataType;
                    var cell = dataRow.CreateCell(column.Ordinal);
                    if (t == typeof(bool))
                    {
                        cell.CellStyle = intCellStyle;
                        if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                        else
                        {
                            if (Convert.ToBoolean(row[column.ColumnName])) cell.SetCellValue(1);
                            else cell.SetCellValue(0);
                        }
                    }
                    else if (t == typeof(int))
                    {
                        cell.CellStyle = intCellStyle;
                        if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                        else cell.SetCellValue(Convert.ToInt32(row[column.ColumnName]));
                    }
                    else if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
                    {
                        cell.CellStyle = intCellStyle;// doubleCellStyle;
                        if (row.IsNull(column.ColumnName)) cell.SetCellValue(0.00);
                        else cell.SetCellValue(Convert.ToDouble(row[column.ColumnName]));
                    }
                    else if (t == typeof(DateTime))
                    {
                        cell.CellStyle = dateCellStyle;
                        if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                        else cell.SetCellValue(Convert.ToDateTime(row[column.ColumnName]).ToString("yyyy/MM/dd HH:mm"));
                    }
                    else
                    {
                        if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                        else cell.SetCellValue(Convert.ToString(row[column.ColumnName]).Trim());
                    }
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }
    }

}