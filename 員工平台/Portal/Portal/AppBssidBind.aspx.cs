using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class AppBssidBind : WebPageBase
    {


        public dcAppDataContext dcApp = new dcAppDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }
        }


        public void LoadData(string Key = "")
        {

        }


        protected void btn_Save_SSID_Click(object sender, EventArgs e)
        {
            string SSID = this.txt_SSID.Text;
            string BSSID = this.txt_BSSID.Text;

            SSID_Identifier rd = new SSID_Identifier();
            rd.SSID = SSID;
            rd.BSSID = BSSID;
            rd.KeyDate = DateTime.Now;
            rd.KeyMan = _User.EmpId;
            rd.Status = true;

            dcApp.SSID_Identifier.InsertOnSubmit(rd);
            dcApp.SubmitChanges();
            lvMain.Rebind();

        }



        protected void Table_SSID_Identifier_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            List<SSID_Identifier> rdlist = (from s in dcApp.SSID_Identifier
                                            where s.Status == true
                                            select s).ToList();


            lvMain.DataSource = rdlist;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            int AutoKey = int.Parse(e.CommandArgument.ToString());

            SSID_Identifier rd = (from s in dcApp.SSID_Identifier
                                      where s.Status == true && s.AutoKey == AutoKey
                                      select s
                                       ).FirstOrDefault();

            if (rd != null)
            {
                rd.Status = false;
                dcApp.SubmitChanges();
            }

            lvMain.Rebind();
        }
    }
}