using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class AppSetting : WebPageBase
    {

        public dcAppDataContext dcApp = new dcAppDataContext();

        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnHr;
            }
        }





      


        protected void btn_Save_CardType_Click(object sender, EventArgs e)
        {


            dcApp.SubmitChanges();

        }







        protected void btnSave_Click(object sender, EventArgs e)
        {


        }




        protected void btn_Save_SSID_Click(object sender, EventArgs e)
        {




            //////
            /////
            ///
             



            string URL = this.txt_Home_URL.Text;


            //bool  b1 

            //SSID_Identifier rd = new SSID_Identifier();
            //rd.SSID = SSID;
            //rd.BSSID = BSSID;
            //rd.KeyDate = DateTime.Now;
            //rd.KeyMan = "system";
            //rd.Status = true;

            //dcApp.SSID_Identifier.InsertOnSubmit(rd);
            dcApp.SubmitChanges();
            //lvMain.Rebind();
        }

    }
}