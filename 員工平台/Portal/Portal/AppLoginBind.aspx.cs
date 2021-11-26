using Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class AppLoginBind : WebPageBase
    {


        public dcAppDataContext dcApp = new dcAppDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }
        }




        protected void Table_AppRegistryKey_Bind_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

            string Nobr = this.txt_Sreach_Nobr.Text.Trim();
            string Name = this.txt_Sreach_Name.Text.Trim();

            List<AppRegistryKey_Bind> rdlist = (from App in dcApp.AppRegistryKey_Bind
                                                where App.Status == true
                                                && ((Nobr.Length > 0 && App.Nobr.Contains(Nobr)) || (Name.Length > 0 && App.Name.Contains(Name)))
                                                select App).Take(100).ToList();


            lvMain.DataSource = rdlist;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            int AutoKey = int.Parse(e.CommandArgument.ToString());

            AppRegistryKey_Bind rd = (from App in dcApp.AppRegistryKey_Bind
                                      where App.Status == true && App.AutoKey == AutoKey
                                      select App
                                       ).FirstOrDefault();

            if (rd != null)
            {
                rd.Status = false;
                dcApp.SubmitChanges();
            }

            lvMain.Rebind();
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {

            //string Nobr = this.txt_Sreach_Nobr.Text;
            //string Name = this.txt_Sreach_Name.Text;

            //List<AppRegistryKey_Bind> rdlist = (from App in dcApp.AppRegistryKey_Bind
            //                                    where App.Status == true && (App.Nobr.Contains(Nobr) || App.Name.Contains(Name))
            //                                    select App).Take(100).ToList();


            //lvMain.DataSource = rdlist;

            lvMain.Rebind();
        }


        protected void btnExportExcel_Click(object sender, EventArgs e)
        {


            //var ListEmpId = ddlEmp.Value.Cast<string>().ToList();

            //var DateB = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            //var DateE = txtDateE.SelectedDate.GetValueOrDefault(DateB);

            //var rs = new List<CardViewRow>();

            ////向api取得驗証
            //var oCardView = new CardViewDao();
            //var CardViewCond = new CardViewConditions();
            //CardViewCond.AccessToken = _User.AccessToken;
            //CardViewCond.RefreshToken = _User.RefreshToken;
            //CardViewCond.isForget = isCheck.Checked;
            //CardViewCond.employeeList = ListEmpId;
            //CardViewCond.dateBegin = DateB;
            //CardViewCond.dateEnd = DateE;

            //var Result = oCardView.GetData(CardViewCond);

            //if (Result.Status)
            //{
            //    if (Result.Data != null)
            //    {
            //        rs = Result.Data as List<CardViewRow>;
            //    }
            //}

            //var dt = rs.CopyToDataTable();

            DataTable dt = new DataTable();

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Card");

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
    }
}