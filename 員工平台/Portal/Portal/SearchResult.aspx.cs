using Bll.Menu.Vdb;
using Dal.Dao.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;


namespace Portal
{
    public partial class SearchResult : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                if (Request.QueryString["Search"] != null)
                {
                    lblSearch.Text = Request.QueryString["Search"];
                    var rs = new List<FeaturesRow>();
                    var oFeatures = new FeaturesDao();
                    var FeaturesCond = new FeaturesConditions();
                    FeaturesCond.AccessToken = _User.AccessToken;
                    FeaturesCond.RefreshToken = _User.RefreshToken;
                    FeaturesCond.CompanySetting = CompanySetting;
                    FeaturesCond.code = "Menu";
                    FeaturesCond.keyword = lblSearch.Text;

                    var Result = oFeatures.GetData(FeaturesCond);

                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            rs = Result.Data as List<FeaturesRow>;
                        }
                    }
                    var grs = rs.GroupBy(p => p.ParentKey);
                    var Res = new List<Result>();

                    var MenuData = AccessData.GetMenuList(_User,CompanySetting);
                    var Dic = new Dictionary<string,string>();
                    //Dic.Add("Menu", "目錄");
                    foreach(var Data in MenuData)
                    {
                        Dic.Add(Data.Code, Data.FileTitle);
                    }

                    foreach(var r in grs)
                    {
                        var oRes = new Result();
                        oRes.Title = Dic[r.Key];
                        foreach (var d in r)
                        {
                            oRes.Content += "<p><h4><a href = \"" + d.Page + "\">" + d.SearchTitle + "</a></h4></p>";
                        }
                        Res.Add(oRes);
                    }

                    lvMain.DataSource = Res;
                }
            }
        }
        public class Result
        {
            public string Title { get; set; }
            public string Content { get; set; }

        }
        public void LoadData(string Key = "")
        {

        }
        
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            
        }

    }
}