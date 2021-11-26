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
    public partial class News : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                News_DataBind();

            }
        }

        public void LoadData(string Key = "")
        {

        }

        protected void News_DataBind()
        {
            
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            
            var rs = new List<BillboardsRow>();
            
            var oBillboards = new BillboardsDao();
            var BillboardsCond = new BillboardsConditions();
            BillboardsCond.AccessToken = _User.AccessToken;
            BillboardsCond.RefreshToken = _User.RefreshToken;
            BillboardsCond.CompanySetting = CompanySetting;
            var Result = oBillboards.GetData(BillboardsCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<BillboardsRow>;
                    foreach (var c in rs)
                    {
                        if (c.NewsDate > DateTime.Now.AddDays(-1))
                            c.IsNew = true;
                        else
                            c.IsNew = false;
                    }
                }
            }
            

            lvMain.DataSource = rs;
        }

    }
}