using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class AppCardTypeEdit : WebPageBase
    {
        public dcAppDataContext dcApp = new dcAppDataContext();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }
        }







        protected void btn_Save_CardType_Click(object sender, EventArgs e)
        {


            string CardName = this.txt_CardName.Text;
            int ItemOrder = int.Parse(this.txt_ItemOrder.Text);
            PunchCardType rd = new PunchCardType();


            rd.CardName = CardName;
            rd.ItemOrder = ItemOrder;
            rd.KeyMan = _User.EmpId;
            rd.KeyDate = DateTime.Now;
            

            dcApp.PunchCardType.InsertOnSubmit(rd);
            dcApp.SubmitChanges();



            Response.Redirect("AppCardType.aspx");













        }
         
    }
}