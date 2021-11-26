using Bll;
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
    public partial class AppURLSetting : WebPageBase
    {


        //public dcAppSettingDataContext dcAppSetting = new dcAppSettingDataContext();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                //txt_Name.Text = "123";
                //sel_Companies_DataBind();
            }
        }



        public void sel_Companies_DataBind()
        {
            //List<companies> companies = dcAppSetting.companies.ToList();

            //var rs = (from c in dcAppSetting.companies

            //          select new TextValueRow
            //          {
            //              Text = c.name,
            //              Value = c.id,
            //          }).ToList();



            //this.sel_Companies.DataSource = rs;
            //this.sel_Companies.DataTextField = "Text";
            //this.sel_Companies.DataValueField = "Value";
            //this.sel_Companies.DataBind();
        }







        protected void sel_Companies_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //string id = this.sel_Companies.SelectedValue;

            //companies companies = (from c in dcAppSetting.companies
            //                       where c.id == id
            //                       select c).FirstOrDefault();

            //if (companies != null)
            //{
            //    txt_Name.Text = companies.name;
            //    txt_Domain.Text = companies.domain;//網域
            //    txt_publicKey.Text = companies.publicKey;
            //    txt_privateKey.Text = companies.privateKey;
            //    txt_Domain.Text = companies.domain;
            //    txt_ServiceURL.Text = companies.serviceUrl;
            //    txt_APIURL.Text = companies.apiUrl;
            //    txt_getAuthUrl.Text = companies.getAuthUrl;
            //    txt_getTokenUrl.Text = companies.getTokenUrl;
            //    txt_getFencePointsUrl.Text = companies.getFencePointsUrl;
            //    txt_getCardTypesUrl.Text = companies.getCardTypesUrl;
            //    txt_isInPolygonUrl.Text = companies.isInPolygonUrl;
            //    txt_saveSignTypeUrl.Text = companies.saveSignTypeUrl;
            //    txt_getEmpConfigurationALLUrl.Text = companies.getEmpConfigurationALLUrl;
            //    txt_checkAppSettingUrl.Text = companies.checkAppSettingUrl;
            //    txt_asyncUploadImagesUrl.Text = companies.asyncUploadImagesUrl;
            //    txt_savePunchCardUrl.Text = companies.savePunchCardUrl;
            //    txt_getAttEndDetailUrl.Text = companies.getAttEndDetailUrl;
            //    txt_getCardDetailUrl.Text = companies.getCardDetailUrl;
            //    txt_getUserInfoUrl.Text = companies.getUserInfoUrl;
            //}


        }



        




        protected void btn_QRCode_Click(object sender, EventArgs e)
        {



            this.txt_Domain.Text = "";//網域
            //this.txt_Numbers.Text = "";//網域 統編
            this.txt_ServiceURL.Text = "";
            this.txt_APIURL.Text = "";
            this.txt_getAuthUrl.Text = "";
            this.txt_getTokenUrl.Text = "";
            this.txt_getFencePointsUrl.Text = "";
            this.txt_getCardTypesUrl.Text = "";
            this.txt_isInPolygonUrl.Text = "";
            this.txt_saveSignTypeUrl.Text = "";
            this.txt_getEmpConfigurationALLUrl.Text = "";
            this.txt_checkAppSettingUrl.Text = "";
            this.txt_asyncUploadImagesUrl.Text = "";
            this.txt_savePunchCardUrl.Text = "";
            this.txt_getAttEndDetailUrl.Text = "";
            this.txt_getCardDetailUrl.Text = "";
            this.txt_getUserInfoUrl.Text = "";





        }



        protected void btn_Click(object sender, EventArgs e)
        {


            //string id = this.sel_Companies.SelectedValue;

            //companies companies = (from c in dcAppSetting.companies
            //                       where c.id == id
            //                       select c).FirstOrDefault();

            //if (companies != null)
            //{




            //    txt_Name.Text = companies.name;
            //    txt_Domain.Text = companies.domain;//網域
            //    txt_publicKey.Text = companies.publicKey;
            //    txt_privateKey.Text = companies.privateKey;
            //    txt_Domain.Text = companies.domain;
            //    txt_ServiceURL.Text = companies.serviceUrl;
            //    txt_APIURL.Text = companies.apiUrl;
            //    txt_getAuthUrl.Text = companies.getAuthUrl;
            //    txt_getTokenUrl.Text = companies.getTokenUrl;
            //    txt_getFencePointsUrl.Text = companies.getFencePointsUrl;
            //    txt_getCardTypesUrl.Text = companies.getCardTypesUrl;
            //    txt_isInPolygonUrl.Text = companies.isInPolygonUrl;
            //    txt_saveSignTypeUrl.Text = companies.saveSignTypeUrl;
            //    txt_getEmpConfigurationALLUrl.Text = companies.getEmpConfigurationALLUrl;
            //    txt_checkAppSettingUrl.Text = companies.checkAppSettingUrl;
            //    txt_asyncUploadImagesUrl.Text = companies.asyncUploadImagesUrl;
            //    txt_savePunchCardUrl.Text = companies.savePunchCardUrl;
            //    txt_getAttEndDetailUrl.Text = companies.getAttEndDetailUrl;
            //    txt_getCardDetailUrl.Text = companies.getCardDetailUrl;
            //    txt_getUserInfoUrl.Text = companies.getUserInfoUrl;


            //}


            Response.Redirect("AppURLSettingEdit.aspx");
        }

    }
}