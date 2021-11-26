using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageMailTplView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                }
                else
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                lblRowIndex.Text = "0";
                LoadData(lblAutoKey.Text);
            }
        }

        public void LoadData(string Key, int RowIndex = 0)
        {
            var AutoKey = Key.Length > 0 ? Convert.ToInt32(Key) : 0;

            RowIndex = Convert.ToInt32(lblRowIndex.Text) + RowIndex;
            RowIndex = RowIndex <= 0 ? 0 : RowIndex;
            lblRowIndex.Text = RowIndex.ToString();

            var Subject = "";
            var Body = "";


            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

            oPerformance.OutMailContent(out Subject, out Body, AutoKey, RowIndex);

            lblSubject.Text = Subject;
            lblBody.Text = Body;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            RadButton btn = sender as RadButton;
            int RowIndex = Convert.ToInt32(btn.CommandArgument);
            LoadData(lblAutoKey.Text, RowIndex);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }
    }
}