using Bll.BillBoard.Vdb;
using Dal.Dao.BillBoard;
using Bll.Tools;
using Dal.Dao.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;

namespace Portal
{
    public partial class NewsContent : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    var ID = Request.QueryString["id"];
                    var oBillboardsById = new BillboardsByIdDao();
                    var BillboardsByIdCond = new BillboardsByIdConditions();
                    BillboardsByIdCond.AccessToken = _User.AccessToken;
                    BillboardsByIdCond.RefreshToken = _User.RefreshToken;
                    BillboardsByIdCond.CompanySetting = CompanySetting;
                    BillboardsByIdCond.id = ID;
                    var Result = oBillboardsById.GetData(BillboardsByIdCond);
                    if (Result.Status && Result.Data != null)
                    {
                       
                        var rs = Result.Data as BillboardsByIdRow;
                        lblDate.Text = rs.ContentDate.ToShortDateString();
                        lblId.Text = rs.ID.ToString();
                        lblTime.Text = rs.ContentDate.ToString("HH:mm");
                        lblTitle.Text = rs.ContentTitle;
                        lblContent.Text = rs.Content;
                        
                    }
                    else
                    {
                        Response.Redirect("News.aspx");
                    }
                }
                else
                {
                    Response.Redirect("News.aspx");
                }
            }
        }

        public void LoadData(string Key = "")
        {

        }

    }
}