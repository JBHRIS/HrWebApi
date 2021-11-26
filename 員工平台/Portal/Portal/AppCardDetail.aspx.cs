using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class AppCardDetail : WebPageBase
    {
        public dcAppDataContext dcApp = new dcAppDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (CompanySetting != null)
            //{
            //    dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            //}

            if (!IsPostBack)
            {
                if (CompanySetting != null)
                {
                    dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
                }
                GetData();
            }
        }

        private void GetData()
        {
            lblAddress.Text = "";
            lblDate.Text = "";
            lblTime.Text = "";
            lblCoordinat.Text = "";
            lblBssid.Text = "";

            hlMap.NavigateUrl = @"https://www.google.com/maps/search/?api=1&query=";

            if (UnobtrusiveSession.Session["CardAppDetailsID"] != null)
            {
                int RequestValue = 0;

                RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["CardAppDetailsID"].ToString());

                var rVdb = (from c in dcApp.CardAppDetails
                            where c.AutoKey == RequestValue
                            select c).FirstOrDefault();

                if (rVdb != null)
                {
                    lblAddress.Text = rVdb.Address;
                    lblDate.Text = rVdb.CardSend.Value.ToString("yyyy/MM/dd");
                    lblTime.Text = rVdb.CardSend.Value.ToString("HH:mm");
                    lblCoordinat.Text = rVdb.Latitude.ToString() + "," + rVdb.Longitude.ToString();
                    lblBssid.Text = rVdb.BSSID;

                    hlMap.NavigateUrl += lblCoordinat.Text;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null && UnobtrusiveSession.Session["ActivePage"].ToString() != "")
                Response.Redirect(UnobtrusiveSession.Session["ActivePage"].ToString());
            else
                Response.Redirect("AppEmployeeAttendCard.aspx");
        }
    }
}