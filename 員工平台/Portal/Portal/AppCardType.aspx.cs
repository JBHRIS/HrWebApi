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
    public partial class AppCardType : WebPageBase
    {


        public dcAppDataContext dcApp = new dcAppDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcApp.Connection.ConnectionString = CompanySetting.ConnApp;
            }
        }


        protected void Table_PunchCardType_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            List<PunchCardType> rdlist = (from s in dcApp.PunchCardType
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

            PunchCardType rd = (from s in dcApp.PunchCardType
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




        protected void btn_Save_CardType_Click(object sender, EventArgs e)
        {




            string CardName = this.txt_CardName.Text;
            string CardType = this.txt_CardType.Text;
            int ItemOrder =  int.Parse( this.txt_ItemOrder.Text);
            PunchCardType rd = new PunchCardType();


            rd.CardName = CardName;
            rd.CardType = CardType;
            rd.KeyMan = _User.EmpId;
            rd.ItemOrder = ItemOrder;            
            rd.KeyDate = DateTime.Now;

            dcApp.PunchCardType.InsertOnSubmit(rd);
            dcApp.SubmitChanges();

        }




    }
}